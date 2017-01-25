using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCNet
{
    public class GlobalVariable
    {
        public const int iDEFAULT_SO_SNDBUF_SIZE = 256 * 1024;
        public const int iDEFAULT_SO_RCVBUF_SIZE = 256 * 1024;

        public const int iIP_HEAD_SIZE = 24;
        public const int iTCP_HEAD_SIZE = 24;

        public const int iMTU_SIZE = 1500 - (iIP_HEAD_SIZE + iTCP_HEAD_SIZE);

        public const int iMAX_PACKET_SIZE = iMTU_SIZE;

        public const int iTCP_PACKET_HEAD_SIZE = 4;
        public const int iPACKET_DATA_SIZE = iMAX_PACKET_SIZE - iTCP_PACKET_HEAD_SIZE;

        public const int iCOMMAND_HEAD_SIZE = 4;
        public const int iCOMMAND_DATA_SIZE = iPACKET_DATA_SIZE - iCOMMAND_HEAD_SIZE;
    }
}
