namespace Crypt.Service.DTO
{
    public class WalletRequestDTO
    {
        public string UserDocument { get; set; } = string.Empty;
        public string CreditCardNumber { get; set; } = string.Empty;
        public long Value { get; set; }
    }
}
