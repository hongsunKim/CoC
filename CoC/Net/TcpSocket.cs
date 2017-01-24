using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Net
{
    class TcpSocket
    {
        public Socket socket { get; set; }

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
    }
}
