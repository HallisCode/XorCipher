using System;
using System.IO;

namespace XorCipher
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                DisplayMenu();
            }
        }

        private static void DisplayMenu()
        {
            int commandNumber = 0;

            Console.WriteLine(
                    "List of commands:\n\n" +
                    "> 1 Encryption\n" +
                    "> 2 Decryption\n" +
                    "> 3 Exit \n\n" +
                    "Enter the number of command :");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out commandNumber)
                    && commandNumber > 0 && commandNumber <= 3)
                {
                    break;
                };

                Console.WriteLine("\nThis command does not exist, enter the command :");
            }

            switch (commandNumber)
            {
                case (1):
                    Encryption();
                    break;

                case (2):
                    Decryption();
                    break;

                case (3):
                    Environment.Exit(0);
                    break;
            }
        }

        private static void Encryption()
        {
            string message = "";
            string key = "";

            string messagePath = InputFilePath("Enter the path to the text file containing your message :");
            string pathResult = InputDirectoryPath("Enter the path to the folder where the encrypted text and the key will be located:");

            using (StreamReader fileMessage = new StreamReader(messagePath))
            {
                message = fileMessage.ReadToEnd();
            }

            string result = XorCipher.Encryption(message, out key);

            using (StreamWriter fileMessage = new StreamWriter(pathResult + @"\message.txt", false, System.Text.Encoding.UTF8))
            {
                fileMessage.Write(result);
            }

            using (StreamWriter fileKey = new StreamWriter(pathResult + @"\key.txt", false, System.Text.Encoding.UTF8))
            {
                fileKey.Write(key);
            }

            Console.WriteLine("\nCompleted!\n");
        }

        private static void Decryption()
        {
            string message = "";
            string key = "";

            string messagePath = InputFilePath("Enter the path to the text file containing the encrypted message :");
            string keyPath = InputFilePath("Enter the path to the text file with the key :");

            using (StreamReader fileMessage = new StreamReader(messagePath))
            {
                message = fileMessage.ReadToEnd();
            }

            using (StreamReader fileKey = new StreamReader(keyPath))
            {
                key = fileKey.ReadToEnd();
            }

            string result = XorCipher.Decryption(message, key);

            Console.WriteLine($"\nDecrypted Message :\n{result}\n\n");
        }

        private static string InputFilePath(string message)
        {
            Console.WriteLine($"\n{message}");
            string path = Console.ReadLine();

            while (!File.Exists(path))
            {
                Console.WriteLine("\nIncorrect path to the file is specified, enter it again:");
                path = Console.ReadLine();
            }

            return path;
        }

        private static string InputDirectoryPath(string message)
        {
            Console.WriteLine($"\n{message}");
            string path = Console.ReadLine();

            while (!Directory.Exists(path))
            {
                Console.WriteLine("\nIncorrect directory path specified, enter it again:");
                path = Console.ReadLine();
            }

            return path;
        }
    }
}
