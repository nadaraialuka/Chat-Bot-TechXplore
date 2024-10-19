using Hackathon.ChatBot.Code.Interfaces;
using Microsoft.Extensions.Configuration;
using OpenAI.Chat;

namespace Hackathon.ChatBot.Code.Implementations
{
    public class OpenAI : IOpenAI
    {
        private readonly string _key;

        public OpenAI(IConfiguration configuration)
        {
            _key = configuration.GetSection("Customer_Name").Value!;
        }

        public string Chat(string question)
        {
            ChatClient client = new(model: "gpt-4o", apiKey: "");

            ChatCompletion completion = client.CompleteChat(question);

            return completion.Content[0].Text;
        }
    }
}
