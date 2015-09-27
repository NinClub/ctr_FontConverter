// Decompiled with JetBrains decompiler
// Type: NintendoWare.sdk.Util
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;
using System.Diagnostics;
using System.IO;

namespace NintendoWare.sdk
{
  public class Util
  {
    private static byte[][] h = new byte[2][];
    private static byte i = (byte) 1;
    private static readonly TextWriter j = Console.Error;
    private static Util.HuffCompressionInfo k = new Util.HuffCompressionInfo();
    private const int a = 128;
    private const int b = 16;
    private const int c = 32;
    private const int d = 48;
    private const int e = 64;
    private const int f = 80;
    private const int g = 240;

    [Conditional("DEBUG_PRINT")]
    private static void f(TextWriter A_0, string A_1, params object[] A_2)
    {
      A_0.Write(A_1, A_2);
    }

    [Conditional("DEBUG_PRINT_DIFFFILT")]
    private static void e(TextWriter A_0, string A_1, params object[] A_2)
    {
      A_0.Write(A_1, A_2);
    }

    [Conditional("DEBUG_PRINT_RL")]
    private static void d(TextWriter A_0, string A_1, params object[] A_2)
    {
      A_0.Write(A_1, A_2);
    }

    [Conditional("DEBUG_PRINT_HUFF")]
    private static void c(TextWriter A_0, string A_1, params object[] A_2)
    {
      A_0.Write(A_1, A_2);
    }

    [Conditional("DEBUG_PRINT_LZ")]
    private static void b(TextWriter A_0, string A_1, params object[] A_2)
    {
      A_0.Write(A_1, A_2);
    }

    [Conditional("DEBUG_PRINT_DATAMATCH")]
    private static void a(TextWriter A_0, string A_1, params object[] A_2)
    {
      A_0.Write(A_1, A_2);
    }

    public static int nitroCompress(byte[] src, int srcOffs, int srcSize, byte[] dst, int dstOffs, string compList, byte rawHeaderFlag)
    {
label_2:
      int num1 = 0;
      char[] chArray1 = new char[16];
      Util.h[0] = new byte[srcSize * 3 + 512];
      Util.h[1] = new byte[srcSize * 3 + 512];
      byte[] A_0 = Util.h[0];
      Util.i = (byte) 1;
      int A_1 = srcSize;
      int num2 = 19;
      int startIndex;
      char[] chArray2;
      char ch;
      while (true)
      {
        switch (num2)
        {
          case 0:
            A_0 = Util.h[(int) Util.i];
            Util.i ^= (byte) 1;
            A_1 = num1;
            ++startIndex;
            num2 = 2;
            continue;
          case 1:
            if ((int) ch != 114)
            {
              num2 = 20;
              continue;
            }
            goto case 0;
          case 2:
          case 12:
            ch = chArray2[startIndex];
            num2 = 13;
            continue;
          case 3:
            if (1 == 0)
              ;
            num2 = 22;
            continue;
          case 4:
            num2 = 7;
            continue;
          case 5:
          case 21:
            chArray2 = (compList + (object) char.MinValue).ToCharArray();
            startIndex = 0;
            num2 = 12;
            continue;
          case 6:
            Util.h[1] = (byte[]) null;
            num2 = 17;
            continue;
          case 7:
            if ((int) ch != 108)
            {
              num2 = 18;
              continue;
            }
            goto case 0;
          case 8:
          case 25:
            Util.a(A_0, A_1, dst, dstOffs);
            num2 = 24;
            continue;
          case 9:
            num2 = 25;
            continue;
          case 10:
            num2 = 11;
            continue;
          case 11:
            if ((int) ch != 76)
            {
              num2 = 16;
              continue;
            }
            goto case 0;
          case 13:
            num2 = (int) ch > 100 ? 23 : 10;
            continue;
          case 14:
            A_1 += 4;
            Array.Copy((Array) BitConverter.GetBytes((uint) (srcSize << 8)), (Array) A_0, 4);
            Array.Copy((Array) src, srcOffs, (Array) A_0, 4, srcSize);
            num2 = 5;
            continue;
          case 15:
            if ((int) ch != 100)
            {
              num2 = 9;
              continue;
            }
            goto case 0;
          case 16:
            num2 = 15;
            continue;
          case 17:
            goto label_26;
          case 18:
            num2 = 1;
            continue;
          case 19:
            if ((int) rawHeaderFlag != 0)
            {
              num2 = 14;
              continue;
            }
            Array.Copy((Array) src, srcOffs, (Array) A_0, 0, srcSize);
            num2 = 21;
            continue;
          case 20:
            num2 = 8;
            continue;
          case 22:
            if (Util.h[1] != null)
            {
              num2 = 6;
              continue;
            }
            goto label_26;
          case 23:
            if ((int) ch == 104)
            {
              ++startIndex;
              byte A_3 = byte.Parse(new string(chArray2, startIndex, 1));
              chArray1[0] = '\n';
              num1 = Util.a(A_0, A_1, Util.h[(int) Util.i], A_3);
              num2 = 0;
              continue;
            }
            num2 = 4;
            continue;
          case 24:
            if (Util.h[0] != null)
            {
              num2 = 26;
              continue;
            }
            goto case 3;
          case 26:
            Util.h[0] = (byte[]) null;
            num2 = 3;
            continue;
          default:
            goto label_2;
        }
      }
label_26:
      return A_1;
    }

    private static int a(byte[] A_0, int A_1, byte[] A_2, int A_3)
    {
label_2:
      int index = 0;
      A_1 = A_1 + 3 & -4;
      uint num1 = 0U;
      if (1 == 0)
        ;
      int num2 = 3;
      while (true)
      {
        switch (num2)
        {
          case 0:
            goto label_8;
          case 1:
            if ((long) num1 >= (long) (A_1 - 1))
            {
              num2 = 0;
              continue;
            }
            A_2[A_3] = A_0[index];
            ++A_3;
            ++index;
            ++num1;
            num2 = 2;
            continue;
          case 2:
          case 3:
            num2 = 1;
            continue;
          default:
            goto label_2;
        }
      }
label_8:
      A_2[A_3] = A_0[index];
      return A_1;
    }

    private static int a(byte[] A_0, int A_1, byte[] A_2, byte A_3)
    {
label_2:
      Util.HuffCompressionInfo huffCompressionInfo = Util.k;
      Util.b(huffCompressionInfo, A_3);
      Util.a(huffCompressionInfo.huffTable, A_0, A_1, A_3);
      Util.a(huffCompressionInfo, A_3);
      int num1 = 4;
      int num2;
      while (true)
      {
        switch (num1)
        {
          case 0:
            if (1 == 0)
              ;
            if (A_1 > 0)
            {
              num1 = 5;
              continue;
            }
            break;
          case 1:
            num1 = 0;
            continue;
          case 2:
          case 3:
            goto label_11;
          case 4:
            if (A_1 < 16777216)
            {
              num1 = 1;
              continue;
            }
            break;
          case 5:
            Array.Copy((Array) BitConverter.GetBytes((uint) (A_1 << 8 | 32) | (uint) A_3), (Array) A_2, 4);
            num2 = 4;
            num1 = 3;
            continue;
          default:
            goto label_2;
        }
        Array.Copy((Array) BitConverter.GetBytes(32U | (uint) A_3), (Array) A_2, 4);
        Array.Copy((Array) BitConverter.GetBytes(A_1), 0, (Array) A_2, 4, 4);
        num2 = 8;
        num1 = 2;
      }
label_11:
      int A_1_1 = num2;
      int A_3_1 = A_1_1 + Util.a(A_2, A_1_1, huffCompressionInfo);
      return A_3_1 + Util.a(huffCompressionInfo.huffTable, A_0, A_2, A_3_1, A_1, A_3);
    }

    private static void b(Util.HuffCompressionInfo A_0, byte A_1)
    {
label_2:
      int num1 = 1 << (int) A_1;
      A_0.huffTreeTop = (ushort) 1;
      A_0.bitSize = A_1;
      Util.HuffData[] huffDataArray = A_0.huffTable;
      int index1 = 0;
      int num2 = 3;
      byte[] numArray;
      int index2;
      Util.HuffTreeCtrlData[] huffTreeCtrlDataArray;
      while (true)
      {
        switch (num2)
        {
          case 0:
          case 1:
            num2 = 2;
            continue;
          case 2:
            if (index2 < 256)
            {
              numArray[index2 * 2] = (byte) 0;
              numArray[index2 * 2 + 1] = (byte) 0;
              huffTreeCtrlDataArray[index2] = new Util.HuffTreeCtrlData(1);
              ++index2;
              num2 = 1;
              continue;
            }
            num2 = 6;
            continue;
          case 3:
          case 4:
            num2 = 7;
            continue;
          case 5:
            numArray = A_0.huffTree;
            huffTreeCtrlDataArray = A_0.huffTreeCtrl;
            index2 = 0;
            num2 = 0;
            continue;
          case 6:
            goto label_13;
          case 7:
            if (1 == 0)
              ;
            if (index1 < num1 * 2)
            {
              huffDataArray[index1] = new Util.HuffData((ushort) index1);
              ++index1;
              num2 = 4;
              continue;
            }
            num2 = 5;
            continue;
          default:
            goto label_2;
        }
      }
label_13:;
    }

    private static void a(Util.HuffData[] A_0, byte[] A_1, int A_2, byte A_3)
    {
      int num = 9;
      int index1;
      int index2;
      while (true)
      {
        switch (num)
        {
          case 0:
          case 6:
            num = 4;
            continue;
          case 1:
            num = 3;
            continue;
          case 2:
            goto label_16;
          case 3:
            if (index2 < A_2)
            {
              ++A_0[(int) A_1[index2]].Freq;
              ++index2;
              num = 1;
              continue;
            }
            num = 2;
            continue;
          case 4:
            if (index1 >= A_2)
            {
              num = 5;
              continue;
            }
            int index3 = ((int) A_1[index1] & 240) >> 4;
            ++A_0[index3].Freq;
            int index4 = (int) A_1[index1] & 15;
            ++A_0[index4].Freq;
            ++index1;
            num = 6;
            continue;
          case 5:
            goto label_5;
          case 7:
            index2 = 0;
            num = 8;
            continue;
          case 8:
            if (1 == 0)
              goto case 1;
            else
              goto case 1;
          default:
            if ((int) A_3 == 8)
            {
              num = 7;
              continue;
            }
            index1 = 0;
            num = 0;
            continue;
        }
      }
label_5:
      return;
label_16:;
    }

    private static void a(Util.HuffCompressionInfo A_0, byte A_1)
    {
      if (1 == 0)
        ;
      Util.HuffData[] A_0_1 = A_0.huffTable;
      ushort A_1_1 = Util.a(A_0_1, A_1);
      Util.a(A_0_1, A_1_1, 0U);
      int num = (int) Util.a(A_0_1, A_1_1);
      Util.b(A_0, A_1_1);
      A_0.huffTree[0] = (byte) --A_0.huffTreeTop;
    }

    private static ushort a(Util.HuffData[] A_0, byte A_1)
    {
label_2:
      ushort num1 = (ushort) (1U << (int) A_1);
      ushort num2 = num1;
      int index1 = -1;
      int index2 = -1;
      int num3 = 31;
      int index3;
      while (true)
      {
        switch (num3)
        {
          case 0:
          case 20:
            goto label_22;
          case 1:
            if (index1 < 0)
            {
              num3 = 14;
              continue;
            }
            goto case 38;
          case 2:
            if (A_0[index3].Freq < A_0[index1].Freq)
            {
              num3 = 18;
              continue;
            }
            goto case 9;
          case 3:
            if (index2 < 0)
            {
              num3 = 41;
              continue;
            }
            A_0[(int) num2].Freq = A_0[index1].Freq + A_0[index2].Freq;
            A_0[(int) num2].ChNo_0 = (short) index1;
            A_0[(int) num2].ChNo_1 = (short) index2;
            num3 = 10;
            continue;
          case 4:
            num3 = index2 >= 0 ? 42 : 43;
            continue;
          case 5:
          case 11:
            num3 = 44;
            continue;
          case 6:
            num3 = 4;
            continue;
          case 7:
            num3 = 8;
            continue;
          case 8:
            if ((int) A_0[index3].PaNo == 0)
            {
              num3 = 39;
              continue;
            }
            goto case 9;
          case 9:
          case 24:
            ++index3;
            num3 = 5;
            continue;
          case 10:
            if ((int) A_0[index1].LeafDepth > (int) A_0[index2].LeafDepth)
            {
              num3 = 23;
              continue;
            }
            A_0[(int) num2].LeafDepth = (ushort) ((uint) A_0[index2].LeafDepth + 1U);
            num3 = 34;
            continue;
          case 12:
            if ((int) A_0[index3].Freq != 0)
            {
              num3 = 28;
              continue;
            }
            goto case 30;
          case 13:
            if ((int) A_0[index3].PaNo == 0)
            {
              num3 = 32;
              continue;
            }
            goto case 30;
          case 14:
            index1 = 0;
            num3 = 38;
            continue;
          case 15:
          case 21:
            num3 = 33;
            continue;
          case 16:
            index1 = index3;
            num3 = 9;
            continue;
          case 17:
            if (index3 != index1)
            {
              num3 = 6;
              continue;
            }
            goto case 30;
          case 18:
            index1 = index3;
            num3 = 24;
            continue;
          case 19:
            index2 = index3;
            num3 = 37;
            continue;
          case 22:
            num3 = index1 >= 0 ? 2 : 16;
            continue;
          case 23:
            if (1 == 0)
              ;
            A_0[(int) num2].LeafDepth = (ushort) ((uint) A_0[index1].LeafDepth + 1U);
            num3 = 40;
            continue;
          case 25:
            num3 = 3;
            continue;
          case 26:
            if ((int) num2 == (int) num1)
            {
              num3 = 35;
              continue;
            }
            --num2;
            num3 = 0;
            continue;
          case 27:
            index3 = 0;
            num3 = 21;
            continue;
          case 28:
            num3 = 13;
            continue;
          case 29:
            if ((int) A_0[index3].Freq != 0)
            {
              num3 = 7;
              continue;
            }
            goto case 9;
          case 30:
          case 37:
            ++index3;
            num3 = 15;
            continue;
          case 31:
          case 36:
            index3 = 0;
            num3 = 11;
            continue;
          case 32:
            num3 = 17;
            continue;
          case 33:
            num3 = index3 < (int) num2 ? 12 : 25;
            continue;
          case 34:
          case 40:
            A_0[index1].PaNo = A_0[index2].PaNo = (short) num2;
            A_0[index1].Bit = (byte) 0;
            A_0[index2].Bit = (byte) 1;
            Util.a(A_0, (ushort) index1, (ushort) index2);
            ++num2;
            index1 = index2 = -1;
            num3 = 36;
            continue;
          case 35:
            num3 = 1;
            continue;
          case 38:
            A_0[(int) num2].Freq = A_0[index1].Freq;
            A_0[(int) num2].ChNo_0 = (short) index1;
            A_0[(int) num2].ChNo_1 = (short) index1;
            A_0[(int) num2].LeafDepth = (ushort) 1;
            A_0[index1].PaNo = (short) num2;
            A_0[index1].Bit = (byte) 0;
            A_0[index1].PaDepth = (ushort) 1;
            num3 = 20;
            continue;
          case 39:
            num3 = 22;
            continue;
          case 41:
            num3 = 26;
            continue;
          case 42:
            if (A_0[index3].Freq < A_0[index2].Freq)
            {
              num3 = 19;
              continue;
            }
            goto case 30;
          case 43:
            index2 = index3;
            num3 = 30;
            continue;
          case 44:
            num3 = index3 < (int) num2 ? 29 : 27;
            continue;
          default:
            goto label_2;
        }
      }
label_22:
      return num2;
    }

    private static void a(Util.HuffData[] A_0, ushort A_1, ushort A_2)
    {
label_2:
      ++A_0[(int) A_1].PaDepth;
      ++A_0[(int) A_2].PaDepth;
      int num = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
            if ((int) A_0[(int) A_1].LeafDepth != 0)
            {
              num = 4;
              continue;
            }
            goto case 2;
          case 1:
            Util.a(A_0, (ushort) A_0[(int) A_2].ChNo_0, (ushort) A_0[(int) A_2].ChNo_1);
            num = 3;
            continue;
          case 2:
            if (1 == 0)
              ;
            num = 5;
            continue;
          case 3:
            goto label_10;
          case 4:
            Util.a(A_0, (ushort) A_0[(int) A_1].ChNo_0, (ushort) A_0[(int) A_1].ChNo_1);
            num = 2;
            continue;
          case 5:
            if ((int) A_0[(int) A_2].LeafDepth != 0)
            {
              num = 1;
              continue;
            }
            goto label_12;
          default:
            goto label_2;
        }
      }
label_10:
      return;
label_12:;
    }

    private static void a(Util.HuffData[] A_0, ushort A_1, uint A_2)
    {
label_2:
      if (1 == 0)
        ;
      A_0[(int) A_1].HuffCode = A_2 << 1 | (uint) A_0[(int) A_1].Bit;
      int num = 2;
      while (true)
      {
        switch (num)
        {
          case 0:
            Util.a(A_0, (ushort) A_0[(int) A_1].ChNo_0, A_0[(int) A_1].HuffCode);
            Util.a(A_0, (ushort) A_0[(int) A_1].ChNo_1, A_0[(int) A_1].HuffCode);
            num = 1;
            continue;
          case 1:
            goto label_6;
          case 2:
            if ((int) A_0[(int) A_1].LeafDepth != 0)
            {
              num = 0;
              continue;
            }
            goto label_8;
          default:
            goto label_2;
        }
      }
label_6:
      return;
label_8:;
    }

    private static ushort a(Util.HuffData[] A_0, ushort A_1)
    {
label_2:
      ushort num1 = A_0[(int) A_1].LeafDepth;
      int num2 = 4;
      ushort num3;
      ushort num4;
      while (true)
      {
        switch (num2)
        {
          case 0:
            if (1 == 0)
              ;
            num4 = Util.a(A_0, (ushort) A_0[(int) A_1].ChNo_0);
            num3 = Util.a(A_0, (ushort) A_0[(int) A_1].ChNo_1);
            num2 = 1;
            continue;
          case 1:
          case 3:
            goto label_10;
          case 2:
            num2 = 0;
            continue;
          case 4:
            switch (num1)
            {
              case (ushort) 0:
                goto label_6;
              case (ushort) 1:
                num4 = num3 = (ushort) 0;
                num2 = 3;
                continue;
              default:
                num2 = 2;
                continue;
            }
          default:
            goto label_2;
        }
      }
label_6:
      return (ushort) 0;
label_10:
      A_0[(int) A_1].HWord = (ushort) ((int) num4 + (int) num3 + 1);
      return (ushort) ((int) num4 + (int) num3 + 1);
    }

    private static void b(Util.HuffCompressionInfo A_0, ushort A_1)
    {
label_2:
      bool A_2_1 = false;
      A_0.huffTreeTop = (ushort) 1;
      int num1 = 0;
      A_0.huffTreeCtrl[0].leftOffsetNeed = (byte) 0;
      A_0.huffTreeCtrl[0].rightNodeNo = A_1;
      int num2 = 5;
      short num3;
      short num4;
      short num5;
      bool A_2_2;
      short num6;
      ushort num7;
      ushort num8;
      int num9;
      while (true)
      {
        switch (num2)
        {
          case 0:
            A_2_2 = true;
            num2 = 32;
            continue;
          case 1:
            num2 = 7;
            continue;
          case 2:
            if ((int) A_0.huffTreeCtrl[(int) num6].leftOffsetNeed != 0)
            {
              num2 = 20;
              continue;
            }
            goto case 45;
          case 3:
            Util.b(A_0, (ushort) num3, A_2_1);
            num2 = 48;
            continue;
          case 4:
            num2 = (int) num4 <= (int) num5 ? 51 : 13;
            continue;
          case 5:
          case 27:
          case 48:
            num8 = (ushort) 0;
            num6 = (short) 0;
            num2 = 47;
            continue;
          case 6:
          case 31:
            num2 = 29;
            continue;
          case 7:
            num2 = (int) num4 <= (int) num5 ? 60 : 38;
            continue;
          case 8:
            if (num9 > num1)
            {
              num2 = 40;
              continue;
            }
            goto case 10;
          case 9:
          case 47:
            num2 = 12;
            continue;
          case 10:
          case 54:
            ++num6;
            num2 = 31;
            continue;
          case 11:
            if (num9 > num1)
            {
              num2 = 36;
              continue;
            }
            goto case 18;
          case 12:
            num2 = (int) num6 < (int) A_0.huffTreeTop ? 2 : 41;
            continue;
          case 13:
            num3 = num6;
            A_2_1 = true;
            num2 = 54;
            continue;
          case 14:
            num2 = 49;
            continue;
          case 15:
            ++num6;
            num2 = 9;
            continue;
          case 16:
            if ((uint) num4 + (uint) num8 <= 64U)
            {
              num2 = 39;
              continue;
            }
            goto case 18;
          case 17:
            num2 = 62;
            continue;
          case 18:
          case 44:
            num2 = 53;
            continue;
          case 19:
            num2 = 56;
            continue;
          case 20:
            ++num8;
            num2 = 45;
            continue;
          case 21:
            num2 = 8;
            continue;
          case 22:
            goto label_83;
          case 23:
            num2 = 4;
            continue;
          case 24:
          case 34:
            num2 = 33;
            continue;
          case 25:
            if ((int) num7 == 0)
            {
              num2 = 19;
              continue;
            }
            goto case 43;
          case 26:
            if ((uint) num4 + (uint) num8 <= 64U)
            {
              num2 = 14;
              continue;
            }
            goto case 10;
          case 28:
            ++num8;
            num2 = 15;
            continue;
          case 29:
            if ((int) num6 < (int) A_0.huffTreeTop)
            {
              num9 = (int) A_0.huffTreeTop - (int) num6;
              num2 = 30;
              continue;
            }
            num2 = 59;
            continue;
          case 30:
            if ((int) A_0.huffTreeCtrl[(int) num6].leftOffsetNeed != 0)
            {
              num2 = 58;
              continue;
            }
            goto case 18;
          case 32:
            num2 = 25;
            continue;
          case 33:
            if ((int) num6 >= (int) A_0.huffTreeTop)
            {
              num2 = 22;
              continue;
            }
            num7 = (ushort) 0;
            A_2_2 = false;
            num2 = 57;
            continue;
          case 35:
            if (Util.a(A_0, (ushort) num4))
            {
              num2 = 1;
              continue;
            }
            goto case 18;
          case 36:
            num3 = num6;
            A_2_1 = false;
            num2 = 44;
            continue;
          case 37:
            num2 = 61;
            continue;
          case 38:
            num3 = num6;
            A_2_1 = false;
            num2 = 18;
            continue;
          case 39:
            num2 = 35;
            continue;
          case 40:
            num3 = num6;
            A_2_1 = true;
            num2 = 10;
            continue;
          case 41:
            num5 = (short) -1;
            num3 = (short) -1;
            A_2_2 = false;
            num6 = (short) 0;
            num2 = 6;
            continue;
          case 42:
            num4 = (short) A_0.huffTable[(int) A_0.huffTreeCtrl[(int) num6].rightNodeNo].HWord;
            num2 = 26;
            continue;
          case 43:
            Util.a(A_0, (ushort) num6, A_2_2);
            num2 = 27;
            continue;
          case 45:
            num2 = 55;
            continue;
          case 46:
            num7 = A_0.huffTable[(int) A_0.huffTreeCtrl[(int) num6].leftNodeNo].HWord;
            num2 = 17;
            continue;
          case 49:
            if (Util.a(A_0, (ushort) num4))
            {
              num2 = 23;
              continue;
            }
            goto case 10;
          case 50:
            if ((int) num3 >= 0)
            {
              num2 = 3;
              continue;
            }
            num6 = (short) 0;
            num2 = 34;
            continue;
          case 51:
            if (1 == 0)
              ;
            if ((int) num4 == (int) num5)
            {
              num2 = 21;
              continue;
            }
            goto case 10;
          case 52:
            num2 = 11;
            continue;
          case 53:
            if ((int) A_0.huffTreeCtrl[(int) num6].rightOffsetNeed != 0)
            {
              num2 = 42;
              continue;
            }
            goto case 10;
          case 55:
            if ((int) A_0.huffTreeCtrl[(int) num6].rightOffsetNeed != 0)
            {
              num2 = 28;
              continue;
            }
            goto case 15;
          case 56:
            if (A_2_2)
            {
              num2 = 43;
              continue;
            }
            ++num6;
            num2 = 24;
            continue;
          case 57:
            if ((int) A_0.huffTreeCtrl[(int) num6].leftOffsetNeed != 0)
            {
              num2 = 46;
              continue;
            }
            goto case 17;
          case 58:
            num4 = (short) A_0.huffTable[(int) A_0.huffTreeCtrl[(int) num6].leftNodeNo].HWord;
            num2 = 16;
            continue;
          case 59:
            num2 = 50;
            continue;
          case 60:
            if ((int) num4 == (int) num5)
            {
              num2 = 52;
              continue;
            }
            goto case 18;
          case 61:
            if ((int) A_0.huffTable[(int) A_0.huffTreeCtrl[(int) num6].rightNodeNo].HWord > (int) num7)
            {
              num2 = 0;
              continue;
            }
            goto case 32;
          case 62:
            if ((int) A_0.huffTreeCtrl[(int) num6].rightOffsetNeed != 0)
            {
              num2 = 37;
              continue;
            }
            goto case 32;
          default:
            goto label_2;
        }
      }
label_83:;
    }

    private static void b(Util.HuffCompressionInfo A_0, ushort A_1, bool A_2)
    {
label_2:
      ushort A_1_1 = A_0.huffTreeTop;
      Util.a(A_0, A_1, A_2);
      int num = 5;
      while (true)
      {
        switch (num)
        {
          case 0:
            A_0.huffTreeCtrl[(int) A_1].rightOffsetNeed = (byte) 0;
            num = 10;
            continue;
          case 1:
            if ((int) A_0.huffTreeCtrl[(int) A_1_1].leftOffsetNeed != 0)
            {
              num = 6;
              continue;
            }
            goto case 12;
          case 2:
          case 3:
          case 10:
            num = 4;
            continue;
          case 4:
            num = (int) A_1_1 < (int) A_0.huffTreeTop ? 1 : 7;
            continue;
          case 5:
            if (A_2)
            {
              num = 0;
              continue;
            }
            A_0.huffTreeCtrl[(int) A_1].leftOffsetNeed = (byte) 0;
            num = 3;
            continue;
          case 6:
            Util.a(A_0, A_1_1, false);
            A_0.huffTreeCtrl[(int) A_1_1].leftOffsetNeed = (byte) 0;
            num = 12;
            continue;
          case 7:
            goto label_18;
          case 8:
            ++A_1_1;
            num = 2;
            continue;
          case 9:
            Util.a(A_0, A_1_1, true);
            A_0.huffTreeCtrl[(int) A_1_1].rightOffsetNeed = (byte) 0;
            num = 8;
            continue;
          case 11:
            if (1 == 0)
              ;
            if ((int) A_0.huffTreeCtrl[(int) A_1_1].rightOffsetNeed != 0)
            {
              num = 9;
              continue;
            }
            goto case 8;
          case 12:
            num = 11;
            continue;
          default:
            goto label_2;
        }
      }
label_18:;
    }

    private static bool a(Util.HuffCompressionInfo A_0, ushort A_1)
    {
label_2:
      short num1 = (short) (64 - (int) A_1);
      ushort num2 = (ushort) 0;
      int num3 = 4;
      while (true)
      {
        switch (num3)
        {
          case 0:
            if ((int) A_0.huffTreeTop - (int) num2 <= (int) num1)
            {
              num3 = 3;
              continue;
            }
            goto label_3;
          case 1:
            num3 = 5;
            continue;
          case 2:
          case 4:
            num3 = 12;
            continue;
          case 3:
            if (1 == 0)
              ;
            --num1;
            num3 = 10;
            continue;
          case 5:
            if ((int) A_0.huffTreeCtrl[(int) num2].rightOffsetNeed != 0)
            {
              num3 = 13;
              continue;
            }
            goto case 10;
          case 6:
            --num1;
            num3 = 1;
            continue;
          case 7:
            if ((int) A_0.huffTreeCtrl[(int) num2].leftOffsetNeed != 0)
            {
              num3 = 9;
              continue;
            }
            goto case 1;
          case 8:
            goto label_22;
          case 9:
            num3 = 11;
            continue;
          case 10:
            ++num2;
            num3 = 2;
            continue;
          case 11:
            if ((int) A_0.huffTreeTop - (int) num2 <= (int) num1)
            {
              num3 = 6;
              continue;
            }
            goto label_17;
          case 12:
            num3 = (int) num2 < (int) A_0.huffTreeTop ? 7 : 8;
            continue;
          case 13:
            num3 = 0;
            continue;
          default:
            goto label_2;
        }
      }
label_3:
      return false;
label_17:
      return false;
label_22:
      return true;
    }

    private static void a(Util.HuffCompressionInfo A_0, ushort A_1, bool A_2)
    {
label_2:
      ushort num1 = (ushort) 0;
      Util.HuffData[] huffDataArray = A_0.huffTable;
      byte[] numArray = A_0.huffTree;
      Util.HuffTreeCtrlData[] huffTreeCtrlDataArray = A_0.huffTreeCtrl;
      ushort num2 = A_0.huffTreeTop;
      int num3 = 7;
      ushort num4;
      while (true)
      {
        switch (num3)
        {
          case 0:
            num1 |= (ushort) 128;
            numArray[(int) num2 * 2] = (byte) huffDataArray[(int) num4].ChNo_0;
            huffTreeCtrlDataArray[(int) num2].leftNodeNo = (ushort) (byte) huffDataArray[(int) num4].ChNo_0;
            huffTreeCtrlDataArray[(int) num2].leftOffsetNeed = (byte) 0;
            num3 = 5;
            continue;
          case 1:
          case 5:
            num3 = 9;
            continue;
          case 2:
            goto label_14;
          case 3:
            num1 |= (ushort) 64;
            numArray[(int) num2 * 2 + 1] = (byte) huffDataArray[(int) num4].ChNo_1;
            huffTreeCtrlDataArray[(int) num2].rightNodeNo = (ushort) (byte) huffDataArray[(int) num4].ChNo_1;
            huffTreeCtrlDataArray[(int) num2].rightOffsetNeed = (byte) 0;
            num3 = 10;
            continue;
          case 4:
          case 8:
            num3 = 11;
            continue;
          case 6:
          case 10:
            num1 |= (ushort) ((int) num2 - (int) A_1 - 1);
            num3 = 2;
            continue;
          case 7:
            if (A_2)
            {
              num3 = 12;
              continue;
            }
            num4 = huffTreeCtrlDataArray[(int) A_1].leftNodeNo;
            huffTreeCtrlDataArray[(int) A_1].leftOffsetNeed = (byte) 0;
            num3 = 4;
            continue;
          case 9:
            if ((int) huffDataArray[(int) huffDataArray[(int) num4].ChNo_1].LeafDepth != 0)
            {
              huffTreeCtrlDataArray[(int) num2].rightNodeNo = (ushort) huffDataArray[(int) num4].ChNo_1;
              num3 = 6;
              continue;
            }
            num3 = 3;
            continue;
          case 11:
            if ((int) huffDataArray[(int) huffDataArray[(int) num4].ChNo_0].LeafDepth == 0)
            {
              if (1 == 0)
                ;
              num3 = 0;
              continue;
            }
            huffTreeCtrlDataArray[(int) num2].leftNodeNo = (ushort) huffDataArray[(int) num4].ChNo_0;
            num3 = 1;
            continue;
          case 12:
            num4 = huffTreeCtrlDataArray[(int) A_1].rightNodeNo;
            huffTreeCtrlDataArray[(int) A_1].rightOffsetNeed = (byte) 0;
            num3 = 8;
            continue;
          default:
            goto label_2;
        }
      }
label_14:
      numArray[(int) A_1 * 2 + (A_2 ? 1 : 0)] = (byte) num1;
      ++A_0.huffTreeTop;
    }

    private static int a(byte[] A_0, int A_1, Util.HuffCompressionInfo A_2)
    {
label_2:
      int num1 = 0;
      int index = 0;
      int num2 = 1;
      while (true)
      {
        switch (num2)
        {
          case 0:
            if ((num1 & 1) != 0)
            {
              num2 = 3;
              continue;
            }
            goto case 10;
          case 1:
          case 7:
            num2 = 2;
            continue;
          case 2:
            if (1 == 0)
              ;
            if (index >= ((int) A_2.huffTreeTop + 1) * 2)
            {
              num2 = 9;
              continue;
            }
            A_0[A_1 + num1++] = A_2.huffTree[index];
            ++index;
            num2 = 7;
            continue;
          case 3:
            ++A_2.huffTreeTop;
            A_0[A_1] = (byte) ((uint) A_0[A_1] + 1U);
            num2 = 10;
            continue;
          case 4:
            num2 = (num1 & 3) != 0 ? 0 : 8;
            continue;
          case 5:
          case 6:
            num2 = 4;
            continue;
          case 8:
            goto label_15;
          case 9:
            num2 = 5;
            continue;
          case 10:
            A_0[A_1 + num1++] = (byte) 0;
            num2 = 6;
            continue;
          default:
            goto label_2;
        }
      }
label_15:
      return num1;
    }

    private static int a(Util.HuffData[] A_0, byte[] A_1, byte[] A_2, int A_3, int A_4, byte A_5)
    {
label_2:
      uint num1 = 0U;
      int num2 = 0;
      int num3 = 0;
      int index1 = 0;
      int num4 = 17;
      int num5;
      int num6;
      byte num7;
      int index2;
      while (true)
      {
        switch (num4)
        {
          case 0:
          case 10:
            num4 = 2;
            continue;
          case 1:
            num4 = 22;
            continue;
          case 2:
            if (num6 >= num2 / 8)
            {
              num4 = 14;
              continue;
            }
            A_2[A_3 + num3++] = (byte) (num1 >> num2 - (num6 + 1) * 8);
            ++num6;
            num4 = 10;
            continue;
          case 3:
          case 8:
            num4 = 28;
            continue;
          case 4:
            num2 %= 8;
            num4 = 24;
            continue;
          case 5:
            num4 = num5 < 2 ? 19 : 16;
            continue;
          case 6:
            if (index1 >= A_4)
            {
              num4 = 1;
              continue;
            }
            num7 = A_1[index1];
            num4 = 25;
            continue;
          case 7:
          case 27:
            num4 = 5;
            continue;
          case 9:
          case 30:
            num1 = num1 << (int) A_0[index2].PaDepth | A_0[index2].HuffCode;
            num2 += (int) A_0[index2].PaDepth;
            num6 = 0;
            num4 = 0;
            continue;
          case 11:
            num4 = 6;
            continue;
          case 12:
            if ((num3 & 3) == 0)
            {
              num4 = 20;
              continue;
            }
            A_2[A_3 + num3++] = (byte) 0;
            num4 = 31;
            continue;
          case 13:
          case 31:
            num4 = 12;
            continue;
          case 14:
            num2 %= 8;
            ++num5;
            num4 = 27;
            continue;
          case 15:
            num1 = num1 << (int) A_0[(int) num7].PaDepth | A_0[(int) num7].HuffCode;
            num2 += (int) A_0[(int) num7].PaDepth;
            num5 = 0;
            num4 = 3;
            continue;
          case 16:
          case 24:
            ++index1;
            num4 = 11;
            continue;
          case 17:
            if (1 == 0)
              goto case 11;
            else
              goto case 11;
          case 18:
          case 21:
            num4 = 23;
            continue;
          case 19:
            if (num5 == 0)
            {
              index2 = (int) num7 & 15;
              num4 = 30;
              continue;
            }
            num4 = 32;
            continue;
          case 20:
            index1 = 0;
            num4 = 18;
            continue;
          case 22:
            if (num2 != 0)
            {
              num4 = 26;
              continue;
            }
            goto case 13;
          case 23:
            if (index1 < num3 / 4)
            {
              byte num8 = A_2[A_3 + index1 * 4];
              A_2[A_3 + index1 * 4] = A_2[A_3 + index1 * 4 + 3];
              A_2[A_3 + index1 * 4 + 3] = num8;
              byte num9 = A_2[A_3 + index1 * 4 + 1];
              A_2[A_3 + index1 * 4 + 1] = A_2[A_3 + index1 * 4 + 2];
              A_2[A_3 + index1 * 4 + 2] = num9;
              ++index1;
              num4 = 21;
              continue;
            }
            num4 = 29;
            continue;
          case 25:
            if ((int) A_5 != 8)
            {
              num5 = 0;
              num4 = 7;
              continue;
            }
            num4 = 15;
            continue;
          case 26:
            A_2[A_3 + num3++] = (byte) (num1 << 8 - num2);
            num4 = 13;
            continue;
          case 28:
            if (num5 < num2 / 8)
            {
              A_2[A_3 + num3++] = (byte) (num1 >> num2 - (num5 + 1) * 8);
              ++num5;
              num4 = 8;
              continue;
            }
            num4 = 4;
            continue;
          case 29:
            goto label_43;
          case 32:
            index2 = (int) num7 >> 4;
            num4 = 9;
            continue;
          default:
            goto label_2;
        }
      }
label_43:
      return num3;
    }

    private static bool a(byte[] A_0, int A_1, byte A_2)
    {
label_2:
      int index1 = A_1;
      int num1 = index1 + 1;
      byte num2 = A_0[index1];
      int num3 = A_1 + ((int) num2 + 1) * 2;
      byte[] numArray = new byte[64];
      int index2 = 0;
      int num4 = 10;
      while (true)
      {
        int num5;
        int num6;
        int num7;
        switch (num4)
        {
          case 0:
            num7 = ((int) A_0[index1] & 63) + 1 << 1;
            num5 = (index1 >> 1 << 1) + num7;
            num4 = 20;
            continue;
          case 1:
            num4 = index1 < num3 ? 15 : 2;
            continue;
          case 2:
            goto label_37;
          case 3:
            if ((int) num2 >= 16)
            {
              num4 = 24;
              continue;
            }
            break;
          case 4:
            num4 = num5 < num3 ? 19 : 11;
            continue;
          case 5:
            if (((int) A_0[index1] & 64) != 0)
            {
              num4 = 6;
              continue;
            }
            goto case 9;
          case 6:
            int num8 = (num6 & -2) + num7 + 1;
            numArray[num8 / 8] |= (byte) (1 << num8 % 8);
            num4 = 9;
            continue;
          case 7:
            if (index2 >= 64)
            {
              num4 = 23;
              continue;
            }
            numArray[index2] = (byte) 0;
            ++index2;
            num4 = 21;
            continue;
          case 8:
            if (num6 < (int) num2 * 2)
            {
              num4 = 16;
              continue;
            }
            goto case 9;
          case 9:
            ++num6;
            ++index1;
            num4 = 13;
            continue;
          case 10:
          case 21:
            num4 = 7;
            continue;
          case 11:
            goto label_36;
          case 12:
            num4 = 3;
            continue;
          case 13:
          case 25:
            num4 = 1;
            continue;
          case 14:
            int num9 = (num6 & -2) + num7;
            numArray[num9 / 8] |= (byte) (1 << num9 % 8);
            num4 = 17;
            continue;
          case 15:
            if (((int) numArray[num6 / 8] & 1 << num6 % 8) == 0)
            {
              num4 = 0;
              continue;
            }
            goto case 9;
          case 16:
            num4 = 4;
            continue;
          case 17:
            num4 = 5;
            continue;
          case 18:
            if ((int) A_2 == 4)
            {
              if (1 == 0)
                ;
              num4 = 12;
              continue;
            }
            break;
          case 19:
            if (((int) A_0[index1] & 128) != 0)
            {
              num4 = 14;
              continue;
            }
            goto case 17;
          case 20:
            if ((int) A_0[index1] == 0)
            {
              num4 = 22;
              continue;
            }
            goto case 16;
          case 22:
            num4 = 8;
            continue;
          case 23:
            num4 = 18;
            continue;
          case 24:
            goto label_19;
          default:
            goto label_2;
        }
        num6 = 1;
        index1 = num1;
        num4 = 25;
      }
label_19:
      return false;
label_36:
      return false;
label_37:
      return true;
    }

    private static int a(byte[] A_0, int A_1, int A_2, byte[] A_3, int A_4, int A_5)
    {
      int num1 = 1;
      uint num2;
      while (true)
      {
        switch (num1)
        {
          case 0:
          case 4:
            num1 = 5;
            continue;
          case 2:
            goto label_4;
          case 3:
            goto label_11;
          case 5:
            if ((long) num2 < (long) A_5)
            {
              A_3[A_4] = A_0[A_1];
              ++A_4;
              ++A_1;
              ++num2;
              num1 = 0;
              continue;
            }
            num1 = 3;
            continue;
          default:
            if (A_2 < A_5)
            {
              num1 = 2;
              continue;
            }
            num2 = 0U;
            num1 = 4;
            continue;
        }
      }
label_4:
      if (1 == 0)
        ;
      return -1;
label_11:
      return A_5;
    }

    private static int a(byte[] A_0, int A_1, int A_2, byte[] A_3, int A_4, byte A_5)
    {
label_2:
      byte num1 = (byte) 0;
      bool flag = false;
      ushort num2 = (ushort) (((int) A_0[A_1] + 1) * 2);
      uint num3 = (uint) num2;
      int num4 = 0;
      ushort num5 = (ushort) 1;
      byte num6 = A_0[A_1 + 1];
      int num7 = 14;
      while (true)
      {
        byte num8;
        ushort num9;
        uint num10;
        switch (num7)
        {
          case 0:
            goto label_46;
          case 1:
          case 9:
          case 18:
            num7 = 6;
            continue;
          case 2:
            if (flag)
            {
              num7 = 12;
              continue;
            }
            num1 = A_0[A_1 + (int) num5 * 2 + (int) num8];
            flag = true;
            num7 = 1;
            continue;
          case 3:
            num7 = 13;
            continue;
          case 4:
            if ((int) num8 == 1)
            {
              num7 = 29;
              continue;
            }
            break;
          case 5:
            goto label_26;
          case 6:
            if (num4 >= A_4)
            {
              num7 = 19;
              continue;
            }
            num5 = (ushort) 1;
            num6 = A_0[A_1 + 1];
            num7 = 26;
            continue;
          case 7:
            if ((int) num8 == 0)
            {
              num7 = 3;
              continue;
            }
            goto case 22;
          case 8:
            if (((int) num6 & 64) != 0)
            {
              num7 = 28;
              continue;
            }
            break;
          case 10:
            num1 = A_0[A_1 + (int) num5 * 2 + (int) num8];
            A_3[num4++] = num1;
            num7 = 18;
            continue;
          case 11:
            if (A_2 < (int) num2)
            {
              num7 = 27;
              continue;
            }
            goto case 20;
          case 12:
            num1 |= (byte) ((uint) A_0[A_1 + (int) num5 * 2 + (int) num8] << 4);
            A_3[num4++] = num1;
            flag = false;
            num7 = 9;
            continue;
          case 13:
            if (((int) num6 & 128) == 0)
            {
              num7 = 22;
              continue;
            }
            goto case 28;
          case 14:
            num7 = Util.a(A_0, A_1, A_5) ? 11 : 5;
            continue;
          case 15:
            if ((long) num3 <= (long) A_2)
            {
              num9 = (ushort) 0;
              num7 = 25;
              continue;
            }
            num7 = 21;
            continue;
          case 16:
          case 25:
            num7 = 17;
            continue;
          case 17:
            if ((int) num9 >= 32)
            {
              num7 = 20;
              continue;
            }
            num8 = (byte) (num10 >> 31);
            num10 <<= 1;
            num7 = 7;
            continue;
          case 19:
            goto label_37;
          case 20:
            num7 = 23;
            continue;
          case 21:
            goto label_9;
          case 22:
            num7 = 4;
            continue;
          case 23:
            if (num4 >= A_4)
            {
              num7 = 0;
              continue;
            }
            byte[] numArray1 = A_0;
            long num11 = (long) A_1;
            int num12 = (int) num3;
            int num13 = 1;
            uint num14 = (uint) (num12 + num13);
            long num15 = (long) (uint) num12;
            IntPtr index1 = checked ((IntPtr) unchecked (num11 + num15));
            int num16 = (int) numArray1[index1];
            byte[] numArray2 = A_0;
            long num17 = (long) A_1;
            int num18 = (int) num14;
            int num19 = 1;
            uint num20 = (uint) (num18 + num19);
            long num21 = (long) (uint) num18;
            IntPtr index2 = checked ((IntPtr) unchecked (num17 + num21));
            int num22 = (int) numArray2[index2] << 8;
            int num23 = num16 | num22;
            byte[] numArray3 = A_0;
            long num24 = (long) A_1;
            int num25 = (int) num20;
            int num26 = 1;
            uint num27 = (uint) (num25 + num26);
            long num28 = (long) (uint) num25;
            IntPtr index3 = checked ((IntPtr) unchecked (num24 + num28));
            int num29 = (int) numArray3[index3] << 16;
            int num30 = num23 | num29;
            byte[] numArray4 = A_0;
            long num31 = (long) A_1;
            int num32 = (int) num27;
            int num33 = 1;
            num3 = (uint) (num32 + num33);
            long num34 = (long) (uint) num32;
            IntPtr index4 = checked ((IntPtr) unchecked (num31 + num34));
            int num35 = (int) numArray4[index4] << 24;
            num10 = (uint) (num30 | num35);
            num7 = 15;
            continue;
          case 24:
          case 26:
            ++num9;
            num7 = 16;
            continue;
          case 27:
            goto label_45;
          case 28:
            num7 = 30;
            continue;
          case 29:
            num7 = 8;
            continue;
          case 30:
            num7 = (int) A_5 != 8 ? 2 : 10;
            continue;
          default:
            goto label_2;
        }
        num6 = A_0[A_1 + (int) num5 * 2 + (int) num8];
        num5 += (ushort) (((int) num6 & 63) + 1);
        num7 = 24;
      }
label_9:
      return -1;
label_26:
      return -1;
label_37:
      return num4;
label_45:
      if (1 == 0)
        ;
      return -1;
label_46:
      return num4;
    }

    public static int nitroDecompress(byte[] src, int srcOffs, int srcSize, byte[] dst, int dstOffs, sbyte depth)
    {
label_2:
      int num1 = 0;
      int newSize = srcSize * 3 + 512;
      sbyte num2 = (sbyte) 0;
      Util.h[0] = new byte[newSize];
      Util.h[1] = new byte[newSize];
      byte[] A_0 = Util.h[0];
      Util.i = (byte) 1;
      Array.Copy((Array) src, srcOffs, (Array) A_0, 0, srcSize);
      int num3 = 25;
      uint num4;
      byte num5;
      uint num6;
      sbyte num7;
      while (true)
      {
        switch (num3)
        {
          case 0:
          case 11:
          case 28:
            num3 = 9;
            continue;
          case 1:
            num3 = 17;
            continue;
          case 2:
            num3 = 6;
            continue;
          case 3:
            if ((int) num4 != 48)
            {
              num3 = 2;
              continue;
            }
            goto case 1;
          case 4:
            num7 = (sbyte) -1;
            num3 = 28;
            continue;
          case 5:
            if ((int) num4 != 32)
            {
              num3 = 8;
              continue;
            }
            num1 = Util.a(A_0, (int) num5, srcSize - (int) num5, Util.h[(int) Util.i], num1, (byte) (num6 & 15U));
            num3 = 1;
            continue;
          case 6:
            if ((int) num4 != 128)
            {
              num3 = 38;
              continue;
            }
            goto case 1;
          case 7:
            if (num1 == 0)
            {
              num3 = 33;
              continue;
            }
            goto case 21;
          case 8:
            num3 = 10;
            continue;
          case 9:
            if ((int) num2 != (int) num7)
            {
              num6 = BitConverter.ToUInt32(A_0, 0);
              num1 = (int) (num6 >> 8);
              num5 = (byte) 4;
              num3 = 7;
              continue;
            }
            num3 = 18;
            continue;
          case 10:
          case 12:
            num1 = Util.a(A_0, (int) num5, srcSize - (int) num5, dst, dstOffs, num1);
            num3 = 32;
            continue;
          case 13:
            num3 = 5;
            continue;
          case 14:
            num3 = 29;
            continue;
          case 15:
            num3 = 36;
            continue;
          case 16:
            Util.h[0] = (byte[]) null;
            num3 = 15;
            continue;
          case 17:
            if (num1 < 0)
            {
              num3 = 31;
              continue;
            }
            A_0 = Util.h[(int) Util.i];
            Util.i ^= (byte) 1;
            srcSize = num1;
            ++num2;
            num3 = 11;
            continue;
          case 18:
            num1 = Util.a(A_0, 0, num1, dst, dstOffs, num1);
            num3 = 34;
            continue;
          case 19:
            num4 = num6 & 240U;
            num3 = 22;
            continue;
          case 20:
            if (Util.h[1] != null)
            {
              num3 = 27;
              continue;
            }
            goto label_32;
          case 21:
            num3 = 37;
            continue;
          case 22:
            num3 = num4 > 32U ? 3 : 14;
            continue;
          case 23:
            goto label_32;
          case 24:
            Util.h[1] = (byte[]) null;
            num3 = 39;
            continue;
          case 25:
            if ((int) depth < 1)
            {
              num3 = 4;
              continue;
            }
            num7 = depth;
            num3 = 0;
            continue;
          case 26:
            if (1 == 0)
              ;
            num3 = 20;
            continue;
          case 27:
            Util.h[1] = (byte[]) null;
            num3 = 23;
            continue;
          case 29:
            if ((int) num4 != 16)
            {
              num3 = 13;
              continue;
            }
            goto case 1;
          case 30:
            newSize = num1 * 3 + 512;
            Array.Resize<byte>(ref Util.h[0], newSize);
            Array.Resize<byte>(ref Util.h[1], newSize);
            A_0 = Util.h[(int) Util.i ^ 1];
            num3 = 19;
            continue;
          case 31:
            goto label_26;
          case 32:
            if (Util.h[0] != null)
            {
              num3 = 16;
              continue;
            }
            goto case 15;
          case 33:
            num1 = BitConverter.ToInt32(A_0, 4);
            num5 = (byte) 8;
            num3 = 21;
            continue;
          case 34:
            if (Util.h[0] != null)
            {
              num3 = 35;
              continue;
            }
            goto case 26;
          case 35:
            Util.h[0] = (byte[]) null;
            num3 = 26;
            continue;
          case 36:
            if (Util.h[1] != null)
            {
              num3 = 24;
              continue;
            }
            goto label_20;
          case 37:
            if (newSize < num1)
            {
              num3 = 30;
              continue;
            }
            goto case 19;
          case 38:
            num3 = 12;
            continue;
          case 39:
            goto label_20;
          default:
            goto label_2;
        }
      }
label_20:
      return num1;
label_26:
      return -1;
label_32:
      return num1;
    }

    private struct HuffData
    {
      public ushort No;
      public short PaNo;
      public uint Freq;
      public short ChNo_0;
      public short ChNo_1;
      public ushort PaDepth;
      public ushort LeafDepth;
      public uint HuffCode;
      public byte Bit;
      public ushort HWord;

      public HuffData(ushort no)
      {
        this.No = no;
        this.ChNo_0 = this.ChNo_1 = (short) -1;
        this.PaNo = (short) 0;
        this.Freq = 0U;
        this.PaDepth = (ushort) 0;
        this.LeafDepth = (ushort) 0;
        this.HuffCode = 0U;
        this.Bit = (byte) 0;
        this.HWord = (ushort) 0;
      }
    }

    private struct HuffTreeCtrlData
    {
      public byte leftOffsetNeed;
      public byte rightOffsetNeed;
      public ushort leftNodeNo;
      public ushort rightNodeNo;

      public HuffTreeCtrlData(int dummy)
      {
        this.leftOffsetNeed = this.rightOffsetNeed = (byte) 1;
        this.leftNodeNo = this.rightNodeNo = (ushort) 0;
      }
    }

    private class HuffCompressionInfo
    {
      public readonly Util.HuffData[] huffTable = new Util.HuffData[512];
      public readonly byte[] huffTree = new byte[512];
      public readonly Util.HuffTreeCtrlData[] huffTreeCtrl = new Util.HuffTreeCtrlData[256];
      public ushort huffTreeTop;
      public byte bitSize;
      public byte padding_0;
    }
  }
}
