namespace Hackathon.ChatBot.Code.Entitites
{
    public class Deposit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FriendlyName { get; set; }
        public int CustomerId { get; set; }
        public string Iban { get; set; }
        public string Ccy { get; set; }
        public DateTime OpenDate { get; set; }
    }
}
