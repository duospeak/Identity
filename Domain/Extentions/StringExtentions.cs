using System.Security.Cryptography;
using System.Text;

namespace System
{
    public static class StringExtentions
    {
        public static string GetMD5(this string str)
        {
            byte[] data = Encoding.ASCII.GetBytes(str);
            data = MD5.Create().ComputeHash(data);
            return Convert.ToBase64String(data);
        }
    }
}
