using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Jeu
{
    class cCryptage
    {
        #region Cryptographie de la sauvegarde du joueur
        private TripleDESCryptoServiceProvider TripleDes = new TripleDESCryptoServiceProvider();

        //Constructeur de la classe
        public cCryptage(string Key)
        {
            TripleDes.Key = TruncateHash(Key,(byte)(TripleDes.KeySize / 8));
            TripleDes.IV = TruncateHash("",(byte)(TripleDes.BlockSize / 8));
        }


        private byte[] TruncateHash(string key, int length)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            
            //Hash the key. 
            byte[] keyBytes = System.Text.Encoding.Unicode.GetBytes(key);
            byte[] hash = sha1.ComputeHash(keyBytes);

            //Resize the key -1
            Array.Resize(ref hash, length);
            return hash;
        }

        public string EncryptData(string plaintext)
        {
            //Convert the plaintext strign to a byte array
            byte[] plaintextBytes = System.Text.Encoding.Unicode.GetBytes(plaintext);
            
            //Creates the stream
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //Create the encoder to write the stream.
            CryptoStream encStream = new CryptoStream(ms, TripleDes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
            //User the crypto stream to write the byte array to the stream
            encStream.Write(plaintextBytes, 0, plaintextBytes.Length);
            encStream.FlushFinalBlock();
            //Convert the encrypted stream to a printable string
            return Convert.ToBase64String(ms.ToArray());
        }

        public string DecryptData(string encryptedText)
        {
            byte[] encryptedBytes;
            //Convert the encrypted text string to a byte array.
            try
            {
                encryptedBytes = Convert.FromBase64String(encryptedText);
            }

            catch
            {
                MessageBox.Show("HACKER!!!!!!!!!!!!!!", "SAUVEGARDE INVALIDE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null ;
            }
            //Creates the stream
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //Creates the decoder to write to the stream.
            CryptoStream decStream = new CryptoStream(ms, TripleDes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
            //User the crypto stream to write the byte array to the stream.
            decStream.Write(encryptedBytes, 0, encryptedBytes.Length);
            decStream.FlushFinalBlock();
            //Convert the plaintext stream to a string.
            return System.Text.Encoding.Unicode.GetString(ms.ToArray());
        }
        #endregion
    }
}

    

