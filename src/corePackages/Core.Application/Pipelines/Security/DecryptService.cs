using Core.Helpers.Helpers;

namespace Core.Application.Pipelines.Security
{
    public class DecryptService : IDecryptService
    {
        private readonly string _securityKey = "zKbVE-yEO'Gg9n7)e[8vJOf=dsUf&eP}";

        public string Encrypt(string decryptedData)
        {
            string encryptData = HashingHelper.AESEncrypt(decryptedData, _securityKey);
            return encryptData;
        }
        public string Decrypt(string encryptedData)
        {
            string decryptData = HashingHelper.AESDecrypt(encryptedData, _securityKey);
            return decryptData;
        }
    }
}
