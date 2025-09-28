namespace Inventory.Application.Contracts
{
    public interface IMailService
    {
        public void SendMail(string subject, string body, string to, string cc = null, string bcc = null, Dictionary<string, byte[]> attachments = null);
    }
}
