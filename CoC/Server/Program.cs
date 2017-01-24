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
            Dictionary<Socket, int> playerManager = new Dictionary<Socket, int>();

            //Getting host IP address
            IPAddress address = IPAddress.Parse("0.0.0.0");

            //Creating IPEndPoint Struct
            //Using 3500 Port... It will be defined by GlobalVariable Class later.
            IPEndPoint localEndPoint = new IPEndPoint(address, 3500);

            //Creating listner socket
            //Using 1280 backLog... It will be defined in GlobalVariable Class later.
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(1280);

            //Set non blocking option
            //listener.Blocking = false;
            
            //Loop for Accepting Connection from Client
            while (true)
            {
                try
                {
                    Socket clientSocket = listener.Accept();
                    playerManager.Add(clientSocket, clientSocket.Handle.ToInt32());
                    Console.WriteLine("player{0} connected.", clientSocket.Handle.ToInt32());
                }
                catch (SocketException e)
                {
                    //Console.WriteLine(e.ToString());
                }

                foreach(var player in playerManager)
                {
                    try
                    {
                        StringBuilder data = new StringBuilder("Nice to meet you player");
                        data.Append(player.Value);
                        data.Append(".");
                        byte[] byteData = Encoding.UTF8.GetBytes(data.ToString());
                        player.Key.Send(byteData);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
            }
            

        }
    }
}
