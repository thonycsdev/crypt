namespace Crypt.Domain
{
    public class Wallet
    {
        public long Id { get; set; }
        public Document Document { get; set; } = new();
        public CreditCard CreditCard { get; set; } = new();
        public long Value { get; set; }
    }
}
