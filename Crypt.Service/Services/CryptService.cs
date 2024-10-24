using System.Security.Cryptography;
using System.Text;

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

            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = data.ToBytes();
                var result = sha512.ComputeHash(bytes);
                return MakeReadable(result);
            }
        }

        private string MakeReadable(byte[] data)
        {
            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("X"));
            }

            return sBuilder.ToString();
        }
    }
}
