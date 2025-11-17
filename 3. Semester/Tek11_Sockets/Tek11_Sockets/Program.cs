using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartServer();
        }

        static void StartServer()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 1234);
            listener.Start();
            Console.WriteLine("Server listening on port 1234...");

            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected");

            HandleClient(client);

            client.Close();
            listener.Stop();
        }

        static void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);

            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"Received: {message}");
        }
    }
}