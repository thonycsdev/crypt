namespace Crypt.Service.DTO
{
    public class WalletResponseDTO
    {
        public long Id { get; set; }
        public string UserDocument { get; set; } = string.Empty;
        public string CreditCardNumber { get; set; } = string.Empty;
        public long Value { get; set; }
    }
}
