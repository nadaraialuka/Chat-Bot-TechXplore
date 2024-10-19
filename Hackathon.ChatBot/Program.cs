
using Hackathon.ChatBot.Code.Interfaces;
using Hackathon.ChatBot.Code.Implementations;

namespace Hackathon.ChatBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddTransient<IOpenAI, Code.Implementations.OpenAI> ();
            builder.Services.AddMemoryCache();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSignalR();
            //builder.Services.AddDbContext<ChatDbContext>(options =>
            //    options.UseSqlServer(builder.Configuration.GetConnectionString("ChatDbConnection")));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //app.MapHub<ChatHub>("/chathub");


            app.MapControllers();

            app.Run();
        }
    }
}
