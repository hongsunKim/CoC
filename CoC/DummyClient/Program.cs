using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace DummyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket playerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3500);
            playerSocket.Connect(remoteEndPoint);

            byte[] buffer = new byte[256];
            playerSocket.Receive(buffer);

            Console.WriteLine(Encoding.UTF8.GetString(buffer));

            playerSocket.Shutdown(SocketShutdown.Both);
            playerSocket.Close();
        }
    }
}
