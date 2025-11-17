using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Program
    {
        static Socket sck;
        
        static void Main(string[] args)
        {
            StartClient();
        }

        static void StartClient()
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            
            if (!TryConnect(serverEndPoint))
            {
                Console.WriteLine("Failed to connect to server.");
                return;
            }
            
            Console.WriteLine("Connected to server.");
            SendMessage();
            sck.Close();
        }

        static bool TryConnect(IPEndPoint endPoint)
        {
            int maxRetries = 3;
            for (int i = 0; i < maxRetries; i++)
            {
                try
                {
                    sck.Connect(endPoint);
                    return true;
                }
                catch (SocketException se)
                {
                    Console.WriteLine($"Connection attempt {i + 1} failed: {se.Message}");
                    if (i < maxRetries - 1)
                    {
                        Console.WriteLine("Retrying...");
                        Thread.Sleep(1000);
                    }
                }
            }
            return false;
        }

        static void SendMessage()
        {
            Console.Write("Enter message: ");
            string text = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(text);
            
            sck.Send(data);
            Console.WriteLine("Data sent to server.");
        }
    }
}