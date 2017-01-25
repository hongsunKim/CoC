using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using CoCNet;

namespace DummyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket playerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3500);
            playerSocket.Connect(remoteEndPoint);

            while (true)
            {
                string stringData = Console.ReadLine();
                byte[] data = Encoding.ASCII.GetBytes(stringData);
                playerSocket.Send(data);
                if (stringData == "exit")
                    break;
            }

            playerSocket.Shutdown(SocketShutdown.Both);
            playerSocket.Close();
        }
    }
}