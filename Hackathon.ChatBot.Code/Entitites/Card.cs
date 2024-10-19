namespace Hackathon.ChatBot.Code.Entitites
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Iban { get; set; }
        public string[] Ccys { get; set; } = ["GEL", "USD", "EUR"];
        public int CustomerId { get; set; }
    }
}
