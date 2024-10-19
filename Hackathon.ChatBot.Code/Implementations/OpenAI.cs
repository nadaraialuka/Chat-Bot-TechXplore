using Hackathon.ChatBot.Code.Interfaces;
using Hackathon.ChatBot.Code.Models;
using Microsoft.Extensions.Caching.Memory;
using OpenAI.Chat;

namespace Hackathon.ChatBot.Code.Implementations
{
    public class OpenAI : IOpenAI
    {
        private readonly IMemoryCache _cache;

        public OpenAI(IMemoryCache cache)
        {
            _cache = cache;
        }

        public ChatResponse Chat(int customerId, string question)
        {
            var prompt = $"I'm giving you context for you to answer correctly to my latest question: {Environment.NewLine}" +
                $"You are chatbot of TBC Bank, if you get question that is not related to banking, you should tell that it is out of context question, but please, don't be too strict, someone may just tell you hi/hello or have a small talk. {Environment.NewLine}" +
                $"If I ask you that I want to open new account (I may ask you with different words as well, for example: please open new account for me or can you help me open account?) you should ask me for my fullname, if you already know fullname from previous context, then ask for address, if you also know address from previous context, then ask for account type. When you have all this information, give me info in json format, like (nothing extra, only this raw json) {"{FullName: InputedFullName, Address: InputedAddress, Type: InputedType }"}{Environment.NewLine}" +
                $"If I ask you that I want to transfer money to budget (it is also called Transfer to state Treasury) you should ask me if I want to transfer 'for myself' or 'someone else', if I tell you for myself, then ask me for budget/treasure code, then ask me to choose account from this list {$"{GetCustomerAccounts(customerId)}"} by giving you the number and finally tell me 'Completed!' If I don't tell you 'for myself' but 'for someone else' then ask me personal Id of that person, then ask me full name of that person and then ask me to choose account from this list {$"{GetCustomerAccounts(customerId)}"} by giving you the number, finally tell me 'Completed!'" +
                $"Also be aware that I may not want to open account, but do something else, so don't be biased initially {Environment.NewLine}" +
                $"Below I'll tell you our conversation context as [prompt:'my input',completion:'your answers'] If I don't provide anything below, it means we didn't have conversation yet {Environment.NewLine}";

            if (_cache.TryGetValue(customerId, out List<HistoryItem>? history))
            {
                foreach (var item in history!)
                {
                    prompt += $"[prompt:{item.UserInput},completion:{item.AIOutput}]";
                }
            }
            else
            {
                history ??= new List<HistoryItem> ();
                _cache.Set(customerId, history);
            }
            
            prompt = prompt + question;

            ChatClient client = new(model: "gpt-4o", apiKey: Environment.GetEnvironmentVariable("OPENAI_API_KEY"));

            ChatCompletion completion = client.CompleteChat(prompt);

            var text = completion.Content[0].Text;

            history.Add(new HistoryItem()
            {
                UserInput = question,
                AIOutput = text
            });

            return new ChatResponse()
            {
                Answer = text,
                IsFinalAnswer = text.StartsWith('{') && text.EndsWith('}')
            };
        }

        private string GetCustomerAccounts(int customerId)
        {
            return "1. TBGE9882931030212123 (GEL)" +
                "\n2. TBGE9882931030212124 (GEL)" +
                "\n3. TBGE9882931030212125 (GEL)";
        }
    }
}
