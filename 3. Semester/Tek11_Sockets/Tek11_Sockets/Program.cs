using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Numerics;

namespace Server
{
    public readonly struct DecryptData
    {
        public DecryptData(int n, int e, int d)
        {
            N = n;
            E = e;
            D = d;
        }
        public int N { get; init; }
        public int E { get; init; }
        public int D { get; init; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            StartServer();
        }

        static void StartServer()
        {
            IPAddress serverIP = GetIPAddress();
            
            TcpListener listener = new TcpListener(serverIP, 1234);
            listener.Start();
            Console.WriteLine($"Server listening on {serverIP}:1234...");

            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Client connected");

            HandleClient(client);

            client.Close();
            listener.Stop();
            Console.WriteLine("Server shut down.");
        }

        static void HandleClient(TcpClient client)
        {
            DecryptData keys = new DecryptData(4819, 41, 3881);
            
            bool running = true;
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            
            // Modtag client ID
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string clientID = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"Client ID: {clientID}");
            
            // Send public key (n:e)
            string publicKey = $"{keys.N}:{keys.E}";
            byte[] keyData = Encoding.ASCII.GetBytes(publicKey);
            stream.Write(keyData, 0, keyData.Length);
            Console.WriteLine($"Sent public key: {publicKey}");
            
            // Modtag krypterede beskeder indtil STOP
            while (running)
            {
                bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0) break;
                
                string encryptedMessage = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Received (encrypted): {encryptedMessage}");
                
                string decryptedMessage = DecryptMessage(encryptedMessage, keys);
                Console.WriteLine($"Decrypted: {decryptedMessage}");
                
                if (decryptedMessage == "STOP")
                {
                    Console.WriteLine("STOP command received. Shutting down...");
                    running = false;
                }
            }
        }

        static string DecryptMessage(string encryptedMessage, DecryptData keys)
        {
            string[] encryptedValues = encryptedMessage.Split(':');
            StringBuilder decrypted = new StringBuilder();
            
            foreach (string encValue in encryptedValues)
            {
                BigInteger c = BigInteger.Parse(encValue);
                BigInteger n = keys.N;
                BigInteger d = keys.D;
                
                // m = c^d mod n
                BigInteger m = BigInteger.ModPow(c, d, n);
                
                char decryptedChar = (char)(int)m;
                decrypted.Append(decryptedChar);
            }
            
            return decrypted.ToString();
        }

        private static IPAddress GetIPAddress()
        {
            int counter = 1;
            List<IPAddress> myIP4s = LoadIPv4();
            foreach (IPAddress ip in myIP4s)
            {
                ChColor(ConsoleColor.DarkYellow, ConsoleColor.Black);
                Console.Write($" {counter}: ");
                ChColor(ConsoleColor.Black, ConsoleColor.White);
                Console.WriteLine($" {ip} ");
                counter++;
            }
            Console.Write("\n\n Input number : ");
            int choice = 1;
            if (Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out choice))
            {
                Console.Clear();
                return myIP4s[choice - 1];
            }
            else
            {
                throw new FormatException();
            }
        }

        private static List<IPAddress> LoadIPv4()
        {
            string hostName = Dns.GetHostName();
            IPAddress[] myIPs = Dns.GetHostEntry(hostName).AddressList;
            List<IPAddress> myIP4s = new List<IPAddress>();
            foreach (IPAddress ip in myIPs)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    myIP4s.Add(ip);
                }
            }
            return myIP4s;
        }

        private static void ChColor(ConsoleColor bg, ConsoleColor fg)
        {
            Console.BackgroundColor = bg;
            Console.ForegroundColor = fg;
        }
    }
}