using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    internal class Program
    {
        static byte [] Buffer { get; set; }
        static Socket sck;
        static void Main(string[] args)
        {
            sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sck.Bind(new IPEndPoint(0, 1234));
            sck.Listen(100);

            Socket accepted = sck.Accept();
            Buffer = new byte[accepted.SendBufferSize];
            int receivedBytes = accepted.Receive(Buffer);
            byte[] formatted = new byte[receivedBytes];
            for (int i = 0; i < receivedBytes; i++)
            {
                formatted[i] = Buffer[i];
            }
            string strData = Encoding.ASCII.GetString(formatted);
            Console.WriteLine("Received Data: " + strData);
            accepted.Close();
            sck.Close();
        }
    }
}
