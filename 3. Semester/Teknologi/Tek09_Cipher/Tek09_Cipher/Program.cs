using System.Runtime.CompilerServices;
using Tek09_Cipher;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter your message:");
        string message = Console.ReadLine();
        Console.WriteLine("Please enter K value:");
        int k = int.Parse(Console.ReadLine());

        var cipher = new CipherMessage
        {
            Message = message,
            K = k
        };

        Console.Clear();


        Console.WriteLine("Do you want to decrypt or encrypt message?");
        Console.WriteLine("1. Decrypt");
        Console.WriteLine("2. Encrypt");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            string decrypted = CipherMessageRepository.Decrypt(cipher);
            Console.WriteLine("Decrypted: " + decrypted);
            return;
        }
        if (choice == "2")
        {
            string encrypted = CipherMessageRepository.Encrypt(cipher);
            Console.WriteLine("Encrypted: " + encrypted);
            return;
        }
        else
        {
            Console.Write("Wrong input");
        }
    }
}