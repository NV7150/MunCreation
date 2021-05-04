using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MunCommunication {
    public class SimpleEncryptor : EncryptTool{
        public string encryptString(string str) {
            var sha256 = SHA256.Create();
            var encoded = Encoding.UTF8.GetBytes(str);
            var hashVal = sha256.ComputeHash(encoded);
            var hashedStr = string.Concat(hashVal.Select(b => $"{b:x2}"));
            
            return hashedStr;
        }
    }
}