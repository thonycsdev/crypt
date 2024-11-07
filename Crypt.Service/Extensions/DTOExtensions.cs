using Crypt.Domain;
using Crypt.Service.DTO;

namespace Crypt.Service.Extensions
{
    public static class DTOExtensions
    {
        public static WalletResponseDTO ToResponse(this Wallet entity)
        {
            var response = new WalletResponseDTO
            {
                Id = entity.Id,
                Value = entity.Value,
                CreditCardNumber = entity.CreditCard.CreditCardNumber,
                UserDocument = entity.Document.UserDocument,
                CreditCardNumberHash = entity.CreditCard.CreditCardNumberHash,
                UserDocumentHash = entity.Document.UserDocumentHash,
            };

            return response;
        }
    }
}
