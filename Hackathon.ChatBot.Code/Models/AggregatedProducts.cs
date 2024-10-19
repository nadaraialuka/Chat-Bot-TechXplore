using Hackathon.ChatBot.Code.Entitites;

namespace Hackathon.ChatBot.Code.Models
{
    public class AggregatedProducts
    {
        public IEnumerable<Account> Accounts { get; set; }
        public IEnumerable<Card> Cards { get; set; }
        public IEnumerable<Deposit> Deposits { get; set; }
    }
}
