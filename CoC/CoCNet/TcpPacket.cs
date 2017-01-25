using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace CoCNet
{
    class TcpPacket
    {
        public Socket actor { get; set; }
        public Socket target { get; set; }

    }
}
