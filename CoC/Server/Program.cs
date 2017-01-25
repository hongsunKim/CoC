using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using CoCNet;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //플레이어 매니저
            Dictionary<int, Socket> playerManager = new Dictionary<int, Socket>();

            //Buffer
            byte[] buffer = new byte[1024];

            //Setting as Any
            IPAddress address = IPAddress.Any;

            //Creating IPEndPoint Struct
            //Using 3500 Port... It will be defined by GlobalVariable Class later.
            IPEndPoint localEndPoint = new IPEndPoint(address, 3500);

            //Creating listner socket
            //Using 1280 backLog... It will be defined in GlobalVariable Class later.
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(localEndPoint);
            listener.Listen(1280);
            listener.Blocking = false;

            //listener.BeginAccept()

            while (true)
            {
                try
                {
                    Socket client = listener.Accept();
                }
                catch
                {

                }
            }

            //while (true)
            //{
            //    //클라이언트 접속 시도가 있다면 접속허가한다.
            //    //접속된 놈 매니저에 넣는다.
            //    //접속한 클라이언트에게 서버에서 발급받은 키 번호를 전송한다.
            //    try
            //    {
            //        Socket client = listener.Accept();
            //        playerManager.Add(client.Handle.ToInt32(), client);
            //        byte[] data;
            //        data = BitConverter.GetBytes(client.Handle.ToInt32());
            //        client.Send(data, sizeof(int), SocketFlags.None);

            //    } //접속 시도가 없을시, 
            //    catch
            //    {
            //        //매니저 클래스를 돌면서
            //        foreach(var player in playerManager)
            //        {
            //            //읽을 정보가 있다면 읽는다.
            //            try
            //            {
            //                byte[] data = new byte[1024];
            //                int recv = player.Value.Receive(data);
            //                string stringData = Encoding.UTF8.GetString(data, 0, recv);
            //                Console.WriteLine(stringData);
            //                if(stringData == "exit")
            //                {
            //                    player.Value.Shutdown(SocketShutdown.Both);
            //                    player.Value.Close();
            //                }
            //            } //없으면 그냥 넘어간다.
            //            catch
            //            {

            //            }
            //        }
            //    }

            //}



        }
    }
}
