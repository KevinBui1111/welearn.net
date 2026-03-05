using System.Security.Cryptography;
using static System.Text.Encoding;
using Convert = System.Convert;

namespace welearn.net.play.Doodle.Support;

public static class OldEncConn {
    private const string ENCRYPT_SECRET_STRING = "secret";

    public static string EncryptString(string Message) {
        byte[] Results;

        // Step 1. We hash the passphrase using MD5
        // We use the MD5 hash generator as the result is a 128 bit byte array
        // which is a valid length for the TripleDES encoder we use below

        var HashProvider = MD5.Create();
        var tDesKey = HashProvider.ComputeHash(UTF8.GetBytes(ENCRYPT_SECRET_STRING));

        // Step 2. Create a new TripleDESCryptoServiceProvider object
        var tripleDes = TripleDES.Create();

        // Step 3. Set up the encoder
        tripleDes.Key = tDesKey;
        tripleDes.Mode = CipherMode.ECB;
        tripleDes.Padding = PaddingMode.PKCS7;

        // Step 4. Convert the input string to a byte[]
        var DataToEncrypt = UTF8.GetBytes(Message);

        // Step 5. Attempt to encrypt the string
        try {
            Results = tripleDes
                .CreateEncryptor()
                .TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
        }
        finally {
            // Clear the TripleDes and Hash provider services of any sensitive information
            tripleDes.Clear();
            HashProvider.Clear();
        }

        // Step 6. Return the encrypted string as a base64 encoded string
        return Convert.ToBase64String(Results);
    }

    public static string DecryptString(string Message) {
        byte[] Results;

        // Step 1. We hash the passphrase using MD5
        // We use the MD5 hash generator as the result is a 128 bit byte array
        // which is a valid length for the TripleDES encoder we use below

        var HashProvider = MD5.Create();
        var tripleDesKey = HashProvider.ComputeHash(UTF8.GetBytes(ENCRYPT_SECRET_STRING));

        // Step 2. Create a new TripleDESCryptoServiceProvider object
        var tripleDes = TripleDES.Create();

        // Step 3. Set up the decoder
        tripleDes.Key = tripleDesKey;
        tripleDes.Mode = CipherMode.ECB;
        tripleDes.Padding = PaddingMode.PKCS7;

        // Step 4. Convert the input string to a byte[]
        var DataToDecrypt = Convert.FromBase64String(Message);

        // Step 5. Attempt to decrypt the string
        try {
            Results = tripleDes
                .CreateDecryptor()
                .TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
        }
        finally {
            // Clear the TripleDes and Hash provider services of any sensitive information
            tripleDes.Clear();
            HashProvider.Clear();
        }

        // Step 6. Return the decrypted string in UTF8 format
        return UTF8.GetString(Results);
    }
}