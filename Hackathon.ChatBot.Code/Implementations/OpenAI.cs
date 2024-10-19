using Hackathon.ChatBot.Code.Interfaces;
using Microsoft.Extensions.Configuration;
using OpenAI.Chat;

namespace Hackathon.ChatBot.Code.Implementations
{
    public class OpenAI : IOpenAI
    {
        public string Chat(string question)
        {
            ChatClient client = new(model: "gpt-4o", apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            ChatCompletion completion = client.CompleteChat(question);

            return completion.Content[0].Text;
        }
    }
}
