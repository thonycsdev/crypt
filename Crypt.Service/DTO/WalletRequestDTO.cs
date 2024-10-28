using Crypt.Domain;

namespace Crypt.Service.DTO
{
    public class WalletRequestDTO
    {
        public string UserDocument { get; set; } = string.Empty;
        public string CreditCardNumber { get; set; } = string.Empty;
        public long Value { get; set; }

        public Wallet ToEntity()
        {
            var entity = new Wallet
            {
                Document = new Document { UserDocument = this.UserDocument },
                CreditCard = new CreditCard { CreditCardNumber = this.CreditCardNumber },
                Value = this.Value,
            };
            return entity;
        }
    }
}
