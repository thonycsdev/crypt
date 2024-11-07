namespace Crypt.Domain
{
    public class Wallet
    {
        public long Id { get; set; }
        public Document Document { get; set; } = new();
        public long DocumentId { get; set; }
        public CreditCard CreditCard { get; set; } = new();
        public long CreditCardId { get; set; }
        public long Value { get; set; }
    }
}
