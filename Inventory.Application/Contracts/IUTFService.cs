namespace Inventory.Application.Contracts
{
    public interface IUTFService
    {
        public string Encryptdata(string plainText);
        public string Decryptdata(string cipherText);
    }
}
