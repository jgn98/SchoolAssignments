using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    internal class Program
    {
        static Socket sck;
        
        static void Main(string[] args)
        {
            StartServer();
        }

        static void StartServer()
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(IPAddress.Any, 1234));
            sck.Listen(100);
            
            Console.WriteLine("Server listening on port 1234...");

            Socket accepted = sck.Accept();
            Console.WriteLine("Client connected");
            
            HandleClient(accepted);
            
            accepted.Close();
            sck.Close();
        }

        static void HandleClient(Socket client)
        {
            byte[] buffer = new byte[client.SendBufferSize];
            int receivedBytes = client.Receive(buffer);
            
            byte[] formatted = new byte[receivedBytes];
            Array.Copy(buffer, formatted, receivedBytes);
            
            string strData = Encoding.ASCII.GetString(formatted);
            Console.WriteLine("Received Data: " + strData);
        }
    }
}