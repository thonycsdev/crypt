using Crypt.Domain;

namespace Crypt.Service.Interfaces
{
    public interface ICryptService
    {
        string Hash(string data);
        void HashWalletInformation(ref Wallet wallet);
    }
}
