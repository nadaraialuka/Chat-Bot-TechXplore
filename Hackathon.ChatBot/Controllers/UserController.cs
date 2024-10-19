using System.Text;
using Hackathon.ChatBot.Auth;
using Hackathon.ChatBot.Context;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.ChatBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public UserController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost("login")]
        public ActionResult<LoginResponse> Login([FromBody] LoginRequest loginRequest)
        {
            Entitites.User? user = _appDbContext.Users.FirstOrDefault(x => x.UserName == loginRequest.UserName);

            SimplePasswordHasher hasher = new();

            if (user != null && hasher.VerifyPassword(loginRequest.Password, user.PasswordHash))
            {
                string base64Credentials = GenerateBase64Credentials(loginRequest.UserName, loginRequest.Password);
                return Ok(new LoginResponse { AuthToken = base64Credentials, UserId = user.Id });
            }

            return Unauthorized("Invalid username or password");
        }
        private string GenerateBase64Credentials(string username, string password)
        {
            string credentials = $"{username}:{password}";
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(credentials));
        }
    }
}
