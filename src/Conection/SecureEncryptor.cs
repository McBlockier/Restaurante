using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using static System.Net.Mime.MediaTypeNames;


namespace Palacio_el_restaurante.src.Conection
{
    internal class SecureEncryptor
    {
        private const int KeySize = 256; //bits
        private const int IvSize = 128; //bits
        private byte[] encryptedData;
        private string textoDesencriptado = "";

        public SecureEncryptor(String Original_Text)
        {
            byte[] clave = new byte[KeySize / 8]; 
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(clave);
            }
            encryptedData = Encrypt(Original_Text, clave);
            textoDesencriptado = Dencrypt(encryptedData, clave);
        }
        public byte[] getEncrypt()
        {
            return encryptedData;
        }
        public string getDenCrypt()
        {
            return textoDesencriptado;
        }

        private byte[] Encrypt(string texto, byte[] clave)
        {
            using (AesCng aes = new AesCng())
            {
                aes.KeySize = KeySize;
                aes.BlockSize = IvSize;
                aes.Key = clave;

                aes.GenerateIV();
                byte[] iv = aes.IV;

                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                {
                    byte[] plaintextBytes = Encoding.UTF8.GetBytes(texto);
                    byte[] ciphertextBytes = encryptor.TransformFinalBlock(plaintextBytes, 0, plaintextBytes.Length);

                    byte[] encryptedData = new byte[iv.Length + ciphertextBytes.Length];
                    Buffer.BlockCopy(iv, 0, encryptedData, 0, iv.Length);
                    Buffer.BlockCopy(ciphertextBytes, 0, encryptedData, iv.Length, ciphertextBytes.Length);

                    return encryptedData;
                }
            }
        }
        private string Dencrypt(byte[] encryptedData, byte[] clave)
        {
            using (AesCng aes = new AesCng())
            {
                aes.KeySize = KeySize;
                aes.BlockSize = IvSize;
                aes.Key = clave;

                byte[] iv = new byte[IvSize / 8];
                byte[] ciphertextBytes = new byte[encryptedData.Length - iv.Length];
                Buffer.BlockCopy(encryptedData, 0, iv, 0, iv.Length);
                Buffer.BlockCopy(encryptedData, iv.Length, ciphertextBytes, 0, ciphertextBytes.Length);

                aes.IV = iv;

                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                {
                    byte[] decryptedBytes = decryptor.TransformFinalBlock(ciphertextBytes, 0, ciphertextBytes.Length);
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
        }
    }
}
