using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tek09_Cipher
{
    internal class CipherMessageRepository
    {
        public static List<int> ConvertToIndexes(string text)
        {
            List<int> indexes = new List<int>();
            foreach (char c in text.ToUpper())
            {
                if (char.IsLetter(c))
                    indexes.Add(c - 'A');
            }
            return indexes;
        }

        // Konverterer indeks tilbage til tekst
        public static string ConvertToText(List<int> indexes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int i in indexes)
                sb.Append((char)('A' + i));
            return sb.ToString();
        }

        // Krypterer ét indeks med en given K-værdi
        public static int EncryptIndex(int index, int k)
        {
            return (index + k) % 26;
        }

        // Dekrypterer ét indeks med en given K-værdi
        public static int DecryptIndex(int index, int k)
        {
            return (index - k + 26) % 26;
        }

        // Krypterer hele beskeden
        public static string Encrypt(CipherMessage input)
        {
            var indexes = ConvertToIndexes(input.Message);
            var encryptedIndexes = new List<int>();

            foreach (int index in indexes)
                encryptedIndexes.Add(EncryptIndex(index, input.K));

            return ConvertToText(encryptedIndexes);
        }

        // Dekrypterer hele beskeden
        public static string Decrypt(CipherMessage input)
        {
            var indexes = ConvertToIndexes(input.Message);
            var decryptedIndexes = new List<int>();

            foreach (int index in indexes)
                decryptedIndexes.Add(DecryptIndex(index, input.K));

            return ConvertToText(decryptedIndexes);
        }
    }

}

