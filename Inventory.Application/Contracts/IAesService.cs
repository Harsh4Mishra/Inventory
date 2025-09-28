namespace Inventory.Application.Contracts
{
    public interface IAesService
    {
        public Task<string> EncryptString(string key, string plainText);
        public Task<string> DecryptString(string key, string cipherText);
        public Task<string> GenerateRandomKey();
    }
}
