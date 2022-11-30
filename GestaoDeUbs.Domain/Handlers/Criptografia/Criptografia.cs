using System.Security.Cryptography;
using System.Text;

namespace GestaoDeUbs.Domain.Handlers.Criptografia;

public class Criptografia
{
    #region AES

    private static byte[] Key = Encoding.ASCII.GetBytes("!QAZ2WSX#EDC4RFV");
    private static byte[] IV = Encoding.ASCII.GetBytes("5TGB&YHN7UJM(IK<");

    public static string AesEncrypt(string texto)
    {
        byte[] retorno;

        using (var aesAlg = criarAes())
        {
            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (var streamWriter = new StreamWriter(cryptoStream))
                    {
                        streamWriter.Write(texto.Replace(" ", "_ESPACO_"));
                    }
                    retorno = memoryStream.ToArray();
                }
            }
        }

        return Convert.ToBase64String(retorno);
    }

    public static string AesDecrypt(string texto)
    {
        string retorno;
        byte[] textoCriptografado = Convert.FromBase64String(texto.Replace(" ", "+"));

        using (var aesAlg = criarAes())
        {
            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (var memoryStream = new MemoryStream(textoCriptografado))
            {
                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (var streamReader = new StreamReader(cryptoStream))
                    {
                        retorno = streamReader.ReadToEnd();
                    }
                }
            }
        }

        return retorno.Replace("_ESPACO_", " ");
    }

    private static Aes criarAes()
    {
        var aesAlg = Aes.Create();
        aesAlg.Key = Key;
        aesAlg.IV = IV;
        aesAlg.Mode = CipherMode.CFB;
        aesAlg.Padding = PaddingMode.PKCS7;

        return aesAlg;
    }

    #endregion
}
