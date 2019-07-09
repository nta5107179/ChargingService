using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class XOR
{
    /// <summary>
    /// 逐字节异或校验
    /// </summary>
    /// <param name="byteArr">需要校验的byte[]</param>
    /// <returns></returns>
    public static byte GetByte(byte[] byteArr)
    {
        byte xor = 0x00;
        xor = byteArr[0];
        for (int i = 1; i < byteArr.Length; i++)
        {
            xor = Convert.ToByte(xor ^ byteArr[i]);
        }
        return xor;
    }
}
