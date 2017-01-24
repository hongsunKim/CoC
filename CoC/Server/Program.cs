using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //Container for player info
            Dictionary<TcpSocket, int> playerManager = new Dictionary<TcpSocket, int>();

            //Getting host IP address
            IPAddress address = IPAddress.Any;

            //Creating IPEndPoint Struct
            //Using 3500 Port... It will be defined by GlobalVariable Class later.
            IPEndPoint localEndPoint = new IPEndPoint(address, 3500);

            //Creating listner socket
            //Using 1280 backLog... It will be defined in GlobalVariable Class later.
            TcpSocket listener = new TcpSocket();
            listener.Bind(localEndPoint);
            listener.Listen(1280);



            TcpSocket client = listener.Accept();

            IPEndPoint remoteEndPoint = (IPEndPoint)client.socket.RemoteEndPoint;
            Console.WriteLine("Connected wirh {0} at port {1}.", remoteEndPoint.Address, remoteEndPoint.Port);

            string welcome = "Welcome to my test server";

            byte[] data = new byte[1024];
            data = Encoding.ASCII.GetBytes(welcome);
            client.Send(data);

            while (true)
            {
                data = new byte[1024];
                int recv = client.Receive(data);
                if(recv == 0)
                {
                    break;
                }

                Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
                client.Send(data);
            }

            Console.WriteLine("Disconnected from {0}.", remoteEndPoint.Address);
            client.Close();
            listener.Close();
        }
    }
}
