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
            Console.Write("Enter server IP address: ");
            string serverIPString = Console.ReadLine();
            
            Console.Write("Enter server port: ");
            int port = int.Parse(Console.ReadLine());
            
            IPAddress serverIP = IPAddress.Parse(serverIPString);
            
            TcpClient client = new TcpClient();
            
            try
            {
                client.Connect(serverIP, port);
                Console.WriteLine($"Connected to server at {serverIP}:{port}");
                
                CommunicateWithServer(client);
            }
            catch (SocketException se)
            {
                Console.WriteLine($"Connection failed: {se.Message}");
            }
            finally
            {
                client.Close();
            }
        }

        static void CommunicateWithServer(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            
            // Send client ID
            string clientID = "Client_Jonas_2024";
            byte[] idData = Encoding.ASCII.GetBytes(clientID);
            stream.Write(idData, 0, idData.Length);
            Console.WriteLine($"Sent ID: {clientID}");
            
            // Modtag hilsen fra server
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string greeting = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"Server says: {greeting}");
            
            // Send beskeder indtil STOP
            while (true)
            {
                Console.Write("\nEnter message: ");
                string message = Console.ReadLine();
                
                byte[] messageData = Encoding.ASCII.GetBytes(message);
                stream.Write(messageData, 0, messageData.Length);
                
                if (message == "STOP")
                {
                    Console.WriteLine("Shutting down client...");
                    break;
                }
            }
        }
    }
}