
using Hackathon.ChatBot.Code.Interfaces;
using Hackathon.ChatBot.Context;
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
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("PersistenceConnection")));
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
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
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                // Apply any pending migrations
                dbContext.Database.Migrate();
            }
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
