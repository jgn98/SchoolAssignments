using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Numerics;

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
            bool running = true;
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            
            string clientID = "Client_Jonas_2024";
            byte[] idData = Encoding.ASCII.GetBytes(clientID);
            stream.Write(idData, 0, idData.Length);
            Console.WriteLine($"Sent ID: {clientID}");
            
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string publicKeyString = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"Received public key: {publicKeyString}");
            
            string[] keyParts = publicKeyString.Split(':');
            int n = int.Parse(keyParts[0]);
            int e = int.Parse(keyParts[1]);
            
            while (running)
            {
                Console.Write("\nEnter message: ");
                string message = Console.ReadLine();
                
                string encryptedMessage = EncryptMessage(message, n, e);
                Console.WriteLine($"Encrypted: {encryptedMessage}");
                
                byte[] messageData = Encoding.ASCII.GetBytes(encryptedMessage);
                stream.Write(messageData, 0, messageData.Length);
                
                if (message == "STOP")
                {
                    Console.WriteLine("Shutting down client...");
                    running = false;
                }
            }
        }

        static string EncryptMessage(string message, int n, int e)
        {
            List<string> encryptedValues = new List<string>();
            
            foreach (char c in message)
            {
                int asciiValue = (int)c;
                
                BigInteger m = asciiValue;
                BigInteger nBig = n;
                BigInteger eBig = e;
                
                BigInteger encrypted = BigInteger.ModPow(m, eBig, nBig);
                
                encryptedValues.Add(encrypted.ToString());
            }
            
            return string.Join(":", encryptedValues);
        }
    }
}