using System.Text;

namespace Crypt.Service.Extensions
{
    public static class StringExtensions
    {
        public static byte[] ToBytes(this string data)
        {
            return Encoding.ASCII.GetBytes(data);
        }
    }
}
