using System.Net;
using System.Net.Sockets;

namespace Client
{
    internal class Program
    {
        static Socket sck;
        static void Main(string[] args)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            try
            {
                sck.Connect(localEndPoint);
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException: " + se.Message);
                Main(args);
            }
            Console.WriteLine("Connected to server.");
            string text = Console.ReadLine();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(text);

            sck.Send(data);
            Console.WriteLine("Data sent to server.");
            sck.Close();

        }
    }
}
