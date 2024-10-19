using Hackathon.ChatBot.Code.Interfaces;
using OpenAI.Chat;

namespace Hackathon.ChatBot.Code.Implementations
{
    public class OpenAI : IOpenAI
    {
        public string Chat(string question)
        {
            ChatClient client = new(model: "gpt-4o", apiKey: "sk-dFHbcUWmAltL1xBLLArAaewjFoHJUhC6yNpyYTVBIqT3BlbkFJKV5znMtt9sMs-HnIsDztS-R9gn3Dg2e5713AUZW6EA");

            ChatCompletion completion = client.CompleteChat(question);

            return completion.Content[0].Text;
        }
    }
}
