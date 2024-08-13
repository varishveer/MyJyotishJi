using System.Security.Cryptography;

namespace MyJyotishGApi.Controllers
{
    public class KeyGenerator
    {
        public static void Main()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] key = new byte[32]; // 32 bytes = 256 bits
                rng.GetBytes(key);
                 string base64Key = Convert.ToBase64String(key);
                Console.WriteLine("Generated Key (Base64): " + base64Key);
            }
        }
    }
}
