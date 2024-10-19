
using Hackathon.ChatBot.Context;
using Hackathon.ChatBot.Hubs;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.ChatBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSignalR();
            builder.Services.AddDbContext<ChatDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ChatDbConnection")));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapHub<ChatHub>("/chathub");


            app.MapControllers();

            app.Run();
        }
    }
}
