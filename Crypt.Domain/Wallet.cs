namespace Crypt.Domain
{
    public class Wallet
    {
        public long Id { get; set; }
        public string UserDocument { get; set; } = string.Empty;
        public string CreditCardNumber { get; set; } = string.Empty;
        public long Value { get; set; }
    }
}
