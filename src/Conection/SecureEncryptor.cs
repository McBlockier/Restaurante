using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace Palacio_el_restaurante.src.Conection
{
    internal class SecureEncryptor
    {
        private const int KeySize = 256; //bits
        private const int IvSize = 128; //bits
        public byte[] encryptedData;
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

        public static string EncryptPassword(String password)
        {
            using (Aes aesAlg = Aes.Create())
            {
                String keyPass = GenerarCadenaAleatoria(32);
                String block = GenerarCadenaAleatoria(16);
                aesAlg.Key = Encoding.UTF8.GetBytes(keyPass);
                aesAlg.IV = Encoding.UTF8.GetBytes(block);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(password);
                        }
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string DecryptPassword(string encryptedPassword)
        {
            using (Aes aesAlg = Aes.Create())
            {
                String keyPass = GenerarCadenaAleatoria(32);
                String block = GenerarCadenaAleatoria(16);
                aesAlg.Key = Encoding.UTF8.GetBytes(keyPass);
                aesAlg.IV = Encoding.UTF8.GetBytes(block);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedPassword)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }



        static string GenerarCadenaAleatoria(int longitud)
        {
            const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            char[] resultado = new char[longitud];

            for (int i = 0; i < longitud; i++)
            {
                int indiceCaracter = random.Next(caracteresPermitidos.Length);
                resultado[i] = caracteresPermitidos[indiceCaracter];
            }

            return new string(resultado);
        }

        static string Desencriptar(string textoEncriptado, string clave, string iv)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(clave);
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(textoEncriptado)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
