namespace Crypt.Domain
{
    public class CreditCard
    {
        public long Id { get; set; }
        public string CreditCardNumberHash { get; set; } = string.Empty;
        public string CreditCardNumber { get; set; } = string.Empty;
    }
}
