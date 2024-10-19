using Hackathon.ChatBot.Code.Models;

namespace Hackathon.ChatBot.Code.Interfaces
{
    public interface IOpenAI
    {
        ChatResponse Chat(int customerId, string question);
    }
}
