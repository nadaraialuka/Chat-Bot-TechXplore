using Hackathon.ChatBot.Code.Entitites;
using Hackathon.ChatBot.Code.Interfaces;
using Hackathon.ChatBot.Code.Models;
using Hackathon.ChatBot.Context;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.ChatBot.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatBotController : ControllerBase
    {
        private readonly ILogger<ChatBotController> _logger;
        private readonly IOpenAI openAI;
        private readonly AppDbContext context;

        public ChatBotController(ILogger<ChatBotController> logger, IOpenAI openAI, AppDbContext context)
        {
            _logger = logger;
            this.openAI = openAI;
            this.context = context;
        }

        [HttpGet]
        [Route("products")]
        public AggregatedProducts Get([FromHeader] int customerId)
        {
            return new AggregatedProducts()
            {
                Accounts = context.Accounts.Where(a => a.CustomerId == customerId),
                Cards = context.Cards.Where(a => a.CustomerId == customerId),
                Deposits = context.Deposits.Where(a => a.CustomerId == customerId)
            };
        }

        [HttpPost]
        [Route("chat")]
        public async Task<ActionResult<ChatResponse>> Chat([FromQuery]string question, [FromHeader]int customerId)
        {
            //await Task.Delay(2_000);
            //return Ok(new ChatResponse { Answer = "Hello Mariamoo", IsFinalAnswer =false});
            return openAI.Chat(customerId, question);
        }
    }
}
