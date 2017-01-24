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
            

            byte[] data = new byte[1024];
            string input;

            TcpSocket playerSocket = new TcpSocket();
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3500);

            try
            {
                playerSocket.Connect(remoteEndPoint);

            } catch (SocketException e)
            {
                Console.WriteLine("Unable to connect to server.");
                Console.WriteLine(e.ToString());
                return;
            }

            int recv = playerSocket.Receive(data);

            Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));

            while (true)
            {
                input = Console.ReadLine();
                if (input == "exit")
                    break;
                playerSocket.Send(Encoding.ASCII.GetBytes(input));
                data = new byte[1024];
                recv = playerSocket.Receive(data);
                Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
            }

            Console.WriteLine("Disconnecting from server...");

            playerSocket.Shutdown(SocketShutdown.Both);
            playerSocket.Close();
        }
    }
}
