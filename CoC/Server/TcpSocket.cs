using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class TcpSocket
    {
        public Socket socket { get; set; }

        public TcpSocket()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public TcpSocket(Socket socket_)
        {
            socket = socket_;
        }

        public void Bind(IPEndPoint endPoint)
        {
            socket.Bind(endPoint);
        }

        public void Listen(int backLog)
        {
            socket.Listen(backLog);
        }

        public TcpSocket Accept()
        {
            TcpSocket result = new TcpSocket(socket.Accept());
            return result;
        }

        public void Connect(IPEndPoint endPoint)
        {
            socket.Connect(endPoint);
        }

        public int Send(byte[] data)
        {
            int total = 0;
            int size = data.Length;
            int leftData = size;
            int sent;

            byte[] dataSize = new byte[4];
            dataSize = BitConverter.GetBytes(size);
            sent = socket.Send(dataSize);

            while (total < size)
            {
                sent = socket.Send(data, total, leftData, SocketFlags.None);
                total += sent;
                leftData -= sent;
            }
            return total;
        }

        public int Receive(byte[] buffer)
        {
            int total = 0;
            byte[] dataSize = new byte[4];
            socket.Receive(dataSize, 0, 4, SocketFlags.None);
            int leftData = BitConverter.ToInt32(dataSize, 0);
            int received;

            while (leftData <= 0)
            {
                received = socket.Receive(buffer, total, leftData, SocketFlags.None);
                total += received;
                leftData -= received;
            }

            return total;
        }

        public void Shutdown(SocketShutdown o)
        {
            socket.Shutdown(o);
        }

        public void Close()
        {
            socket.Close();
        }
    }
}