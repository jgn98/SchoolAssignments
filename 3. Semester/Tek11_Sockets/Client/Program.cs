using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartClient();
        }

        static void StartClient()
        {
            TcpClient client = new TcpClient();
            
            if (!TryConnect(client, "127.0.0.1", 1234))
            {
                Console.WriteLine("Failed to connect to server.");
                return;
            }
            
            Console.WriteLine("Connected to server.");
            SendMessage(client);
            client.Close();
        }

        static bool TryConnect(TcpClient client, string host, int port)
        {
            int maxRetries = 3;
            for (int i = 0; i < maxRetries; i++)
            {
                try
                {
                    client.Connect(host, port);
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

        static void SendMessage(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            
            Console.Write("Enter message: ");
            string text = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(text);
            
            stream.Write(data, 0, data.Length);
            Console.WriteLine("Data sent to server.");
        }
    }
}