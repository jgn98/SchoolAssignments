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
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            
            // Modtag client ID
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string clientID = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"Client ID: {clientID}");
            
            // Send hilsen tilbage
            string greeting = "Velkommen til serveren!";
            byte[] greetingData = Encoding.ASCII.GetBytes(greeting);
            stream.Write(greetingData, 0, greetingData.Length);
            
            // Modtag beskeder indtil STOP
            while (true)
            {
                bytesRead = stream.Read(buffer, 0, buffer.Length);
                if (bytesRead == 0) break;
                
                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Received: {message}");
                
                if (message == "STOP")
                {
                    Console.WriteLine("STOP command received. Shutting down...");
                    break;
                }
            }
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