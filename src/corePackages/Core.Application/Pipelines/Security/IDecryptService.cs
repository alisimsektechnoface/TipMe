namespace Core.Application.Pipelines.Security
{
    public interface IDecryptService
    {
        string Encrypt(string decryptedData);
        string Decrypt(string encryptedData);
    }
}
