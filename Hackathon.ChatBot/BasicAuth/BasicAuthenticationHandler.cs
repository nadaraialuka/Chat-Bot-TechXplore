using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Hackathon.ChatBot.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Hackathon.ChatBot.BasicAuth
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly AppDbContext _appDbContext;
        public BasicAuthenticationHandler(
            AppDbContext appDbContext,
                IOptionsMonitor<AuthenticationSchemeOptions> options,
                ILoggerFactory logger,
                UrlEncoder encoder)
                : base(options, logger, encoder)
        {
            _appDbContext = appDbContext;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue("Authorization", out Microsoft.Extensions.Primitives.StringValues value))
            {
                return AuthenticateResult.Fail("Missing Authorization Header");
            }

            try
            {
                AuthenticationHeaderValue authHeader = AuthenticationHeaderValue.Parse(value);
                byte[] credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                string[] credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                string username = credentials[0];
                string password = credentials[1];
                var hasher = new SimplePasswordHasher();
                var user = await _appDbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);
                if (user == null) 
                {
                    return AuthenticateResult.Fail("User with supplied UserName not found");
                }
                if (!hasher.VerifyPassword(password, user.PasswordHash))
                {
                    return AuthenticateResult.Fail("Password is not correct");

                }

                Claim[] claims = new[] {
                    new Claim(ClaimTypes.NameIdentifier, username),
                    new Claim(ClaimTypes.Name, username),
                };

                ClaimsIdentity identity = new(claims, Scheme.Name);
                ClaimsPrincipal principal = new(identity);
                AuthenticationTicket ticket = new(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }
        }
    }

}
