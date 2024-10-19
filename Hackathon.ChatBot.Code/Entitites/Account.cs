namespace Hackathon.ChatBot.Code.Entitites
{
    public class Account
    {
        public int Id { get; set; }
        public string Iban { get; set; }
        public string Ccy { get; set; }
        public string Type { get; set; }
        public string Subtype { get; set; }
        public int CustomerId { get; set; }
    }
}
