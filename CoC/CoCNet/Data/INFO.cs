using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoCNet.Data
{
    struct SInfoUserInGsToCl
    {
        uint target;
        char[] name;

        byte[] GetBytes()
        {
            byte[] result = new byte[GlobalVariable.iMAX_PACKET_SIZE];

            byte[] targetByte = BitConverter.GetBytes(target);
            byte[] nameByte = Encoding.UTF8.GetBytes(name);

            int offSet = 0;

            Buffer.BlockCopy(targetByte, 0, result, offSet, targetByte.Length);
            offSet += targetByte.Length;
            Buffer.BlockCopy(nameByte, 0, result, offSet, nameByte.Length);
            offSet += nameByte.Length;

            return result;
        }
	}
}
