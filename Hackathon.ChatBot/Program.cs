using Hackathon.ChatBot.Code.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.ChatBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<IOpenAI, Code.Implementations.OpenAI>();
            builder.Services.AddMemoryCache();

            builder.Services.AddControllers();

            // Swagger for API documentation
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSignalR();
            builder.Services.AddDbContext<Context.AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("PersistenceConnection")));
            var app = builder.Build();

            // Swagger configuration
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Make sure to use Authentication before Authorization
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
