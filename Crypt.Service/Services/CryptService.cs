using System.Security.Cryptography;
using System.Text;

using Crypt.Domain;
using Crypt.Service.Extensions;
using Crypt.Service.Interfaces;

namespace Crypt.Service.Services
{
    public class CryptService : ICryptService
    {
        public CryptService() { }

        public string Hash(string data)
        {
            if (string.IsNullOrEmpty(data))
                throw new Exception("Empty Input");

            var key = Encoding.ASCII.GetBytes("Anthony");
            using (var sha512 = new HMACSHA512(key))
            {
                byte[] bytes = data.ToBytes();
                var result = sha512.ComputeHash(bytes);
                return MakeReadable(result);
            }
        }

        public void HashWalletInformation(ref Wallet wallet)
        {
            wallet.CreditCard!.CreditCardNumberHash = this.Hash(wallet.CreditCard.CreditCardNumber);
            wallet.Document!.UserDocumentHash = this.Hash(wallet.Document.UserDocument);
        }

        private string MakeReadable(byte[] data)
        {
            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X2"));
            }

            return sBuilder.ToString();
        }
    }
}
