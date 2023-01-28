using System;

namespace XorCipher
{
    internal class XorCipher
    {
        private static Random _random = new Random();


        public static string Encryption(string message, out string key)
        {
            string encryptedMessage = "";
            key = "";

            for (int i = 0; i < message.Length; i++)
            {
                Char symbol = message[i];

                if (symbol == ' ')
                {
                    encryptedMessage += ' ';
                    key += ' ';
                    continue;
                }

                UInt16 symbolCode = Convert.ToUInt16(symbol);
                UInt16 keySymbolCode = (UInt16)_random.Next(0, UInt16.MaxValue);

                char encryptedSymbol = (char)(symbolCode ^ keySymbolCode);

                key += (char)keySymbolCode;
                encryptedMessage += encryptedSymbol;
            }

            return encryptedMessage;
        }

        public static string Decryption(string encryptedMessage, string key)
        {
            string message = "";

            if (encryptedMessage.Length != key.Length)
            {
                return message;
            }

            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                if (encryptedMessage[i] == ' ')
                {
                    message += ' ';
                    continue;
                }

                UInt16 symbolCode = Convert.ToUInt16(encryptedMessage[i]);
                UInt16 keySymbolCode = Convert.ToUInt16(key[i]);

                char messageSymbol = (char)(symbolCode ^ keySymbolCode);
                message += messageSymbol;
            }

            return message;
        }
    }
}
