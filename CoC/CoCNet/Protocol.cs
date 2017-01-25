using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCNet
{
    public struct TcpPacketHeader
    {
        public UInt16 key;
        public Int16 size;
    }

    public struct Command
    {
        public CommandHeader header;
        public byte[] data;
    }

    public struct CommandHeader
    {
        public Int16 order;
        public byte mission;
        public byte extra;
    }
}
