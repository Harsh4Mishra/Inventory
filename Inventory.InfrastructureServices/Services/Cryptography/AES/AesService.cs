using Inventory.Application.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace Inventory.InfrastructureServices.Services.Cryptography.AES
{
    public class AesService : IAesService
    {
        public Task<string> EncryptString(string key, string plainText)
        {
            ValidateKeySize(key);  // Validate key size

            byte[] iv = new byte[16];  // AES uses a 16-byte IV
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);  // Ensure the key is 16, 24, or 32 bytes long
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Task.FromResult(Convert.ToBase64String(array));
        }
        private void ValidateKeySize(string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            if (keyBytes.Length != 16 && keyBytes.Length != 24 && keyBytes.Length != 32)
            {
                throw new ArgumentException("Key size must be 128, 192, or 256 bits (16, 24, or 32 bytes).");
            }
        }

        public Task<string> DecryptString(string key, string cipherText)
        {
            ValidateKeySize(key);  // Validate key size

            byte[] iv = new byte[16];  // AES uses a 16-byte IV
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);  // Ensure the key is 16, 24, or 32 bytes long
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            string plainText = streamReader.ReadToEnd();
                            return Task.FromResult(plainText);
                        }
                    }
                }
            }
        }



        // This generates a 256-bit key (32 bytes).
        public Task<string> GenerateRandomKey()
        {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            char[] chars = new char[32];  // 32 chars for 256-bit key

            for (int i = 0; i < 32; i++)
            {
                chars[i] = validChars[random.Next(validChars.Length)];
            }
            return Task.FromResult(new string(chars));
        }
    }
}
