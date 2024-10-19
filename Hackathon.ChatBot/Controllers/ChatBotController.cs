using Hackathon.ChatBot.Code.Interfaces;
using Hackathon.ChatBot.Code.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.ChatBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatBotController : ControllerBase
    {
        private readonly ILogger<ChatBotController> _logger;
        private readonly IOpenAI openAI;

        public ChatBotController(ILogger<ChatBotController> logger, IOpenAI openAI)
        {
            _logger = logger;
            this.openAI = openAI;
        }

        [HttpGet]
        [Route("products")]
        public AggregatedProducts Get()
        {
            return new AggregatedProducts()
            {
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        Id = 1,
                        Iban = "TBGEI9201I30J120S12M21",
                        Ccy = "GEL",
                        Type = "მიმდინარე",
                        Subtype = "მიმდინარე"
                    },
                    new Account()
                    {
                        Id = 2,
                        Iban = "TBGEI9301I30J120S12M21",
                        Ccy = "USD",
                        Type = "მიმდინარე",
                        Subtype = "მიმდინარე"
                    }
                },
                Cards = new List<Card>()
                {
                    new Card()
                    {
                        Id = 1,
                        Name = "MC World Elite",
                        Type = "MasterCard"
                    }
                },
                Deposits = new List<Deposit>()
                {
                    new Deposit()
                    {
                        Id = 1,
                        Name = "Goal",
                        FriendlyName = "ახალი მობილური"
                    }
                }
            };
        }

        [HttpPost]
        [Route("chat")]
        public string Chat(string question)
        {
            return openAI.Chat(question);
        }
    }
}
