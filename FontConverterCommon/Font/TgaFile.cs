// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.TgaFile
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace NintendoWare.Font
{
  public class TgaFile
  {
    private const string m_sa = "TRUEVISION-XFILE.\0";
    private const string m_sb = "fontcvtr output.";
    private string c;

    public TgaFile(string fname)
    {
      this.c = fname;
    }

    public ImageBase Load()
    {
      BinaryFile binaryFile = BinaryFile.Open(this.c, FileMode.Open, FileAccess.Read);
      ImageBase imageBase = null;
      try
      {
label_3:
        ByteOrderBinaryReader A_0 = new ByteOrderBinaryReader((Stream) binaryFile, true);
        TgaFile.TgaFileHeader A_1_1;
        this.a(A_0, out A_1_1);
        this.b(A_1_1);
        this.a(A_1_1);
        bool isIndex = A_1_1.IsIndex;
        int num = 15;
        int A_4 = 0;
        int count1 = 0;
        byte[] numArray1 = null;
        byte[] numArray2 = null;
        while (true)
        {
          switch (num)
          {
            case 0:
              IndexImage A_1_2 = new IndexImage();
              this.a(A_0, A_1_2, A_1_1);
              imageBase = (ImageBase) A_1_2;
              num = 6;
              continue;
            case 1:
              num = 14;
              continue;
            case 2:
              if ((int) A_1_1.ColorMapEntrySize != 32)
              {
                num = 12;
                continue;
              }
              goto case 16;
            case 3:
            case 10:
              TgaFile.a(numArray2, numArray1, (int) A_1_1.ImageWidth, (int) A_1_1.ImageHeight, A_4, ((int) A_1_1.ImageDesc & 16) != 0, ((int) A_1_1.ImageDesc & 32) == 0);
              imageBase.Create((int) A_1_1.ImageWidth, (int) A_1_1.ImageHeight, (int) A_1_1.PixelDepth);
              imageBase.Paste(numArray2, 1);
              num = 17;
              continue;
            case 4:
              num = 7;
              continue;
            case 5:
              if (!isIndex)
              {
                num = 1;
                continue;
              }
              goto case 4;
            case 6:
            case 13:
              A_4 = ((int) A_1_1.PixelDepth + 7) / 8;
              count1 = (int) A_1_1.ImageWidth * (int) A_1_1.ImageHeight * A_4;
              numArray1 = new byte[count1];
              numArray2 = new byte[count1];
              num = 9;
              continue;
            case 7:
              goto label_34;
            case 8:
              int count2 = (int) binaryFile.Length;
              byte[] numArray3 = new byte[count2];
              A_0.Read(numArray3, 0, count2);
              this.a(numArray1, numArray3, (int) A_1_1.ImageWidth, (int) A_1_1.ImageHeight, A_4);
              num = 3;
              continue;
            case 9:
              if (A_1_1.IsRunLengthCompressed)
              {
                num = 8;
                continue;
              }
              A_0.Read(numArray1, 0, count1);
              num = 10;
              continue;
            case 11:
              num = 2;
              continue;
            case 12:
              num = 5;
              continue;
            case 14:
              if ((int) A_1_1.PixelDepth == 32)
              {
                if (1 == 0)
                  ;
                num = 16;
                continue;
              }
              goto case 4;
            case 15:
              if (isIndex)
              {
                num = 0;
                continue;
              }
              imageBase = (ImageBase) new RgbImage();
              num = 13;
              continue;
            case 16:
              imageBase.EnableAlpha();
              num = 4;
              continue;
            case 17:
              if (isIndex)
              {
                num = 11;
                continue;
              }
              goto case 12;
            default:
              goto label_3;
          }
        }
      }
      finally
      {
        int num = 2;
        while (true)
        {
          switch (num)
          {
            case 0:
              binaryFile.Dispose();
              num = 1;
              continue;
            case 1:
              goto label_33;
            default:
              if (binaryFile != null)
              {
                num = 0;
                continue;
              }
              goto label_33;
          }
        }
label_33:;
      }
label_34:
      return imageBase;
    }

    public void Save(ImageBase image)
    {
label_2:
      IntColor[] intColorArray = (IntColor[]) null;
      TgaFile.TgaFileHeader tgaFileHeader = new TgaFile.TgaFileHeader();
      TgaFile.TgaFileFooter tgaFileFooter = new TgaFile.TgaFileFooter();
      int length1 = 0;
      int count = 0;
      int num1 = 4;
      IndexImage indexImage = null;
      int index1 = 0;
      byte[] numArray1 = null;
      ByteOrderBinaryWriter orderBinaryWriter = null;
      while (true)
      {
        switch (num1)
        {
          case 0:
            tgaFileHeader.ImageDesc = image.IsEnableAlpha ? (byte) 8 : (byte) 0;
            num1 = 7;
            continue;
          case 1:
            num1 = 12;
            continue;
          case 2:
            goto label_8;
          case 3:
            tgaFileHeader.IdLength = (byte) "fontcvtr output.".Length;
            num1 = 16;
            continue;
          case 4:
            if (image.Width <= (int) ushort.MaxValue)
            {
              num1 = 1;
              continue;
            }
            goto label_8;
          case 5:
            tgaFileHeader.ColorMapEntrySize = length1 > 0 ? (byte) 32 : (byte) 0;
            tgaFileHeader.XOrigin = (ushort) 0;
            tgaFileHeader.YOrigin = (ushort) 0;
            tgaFileHeader.ImageWidth = (ushort) image.Width;
            tgaFileHeader.ImageHeight = (ushort) image.Height;
            tgaFileHeader.PixelDepth = (byte) image.Bpp;
            num1 = 0;
            continue;
          case 6:
            index1 = 0;
            num1 = 13;
            continue;
          case 7:
            if (indexImage != null)
            {
              num1 = 6;
              continue;
            }
            goto case 17;
          case 8:
            goto label_27;
          case 9:
            if (index1 < length1)
            {
              intColorArray[index1] = indexImage.GetColorTable()[index1];
              ++index1;
              if (1 == 0)
                ;
              num1 = 10;
              continue;
            }
            num1 = 17;
            continue;
          case 10:
          case 13:
            num1 = 9;
            continue;
          case 11:
            length1 = indexImage.GetColorTableEntryNum();
            intColorArray = new IntColor[length1];
            num1 = 3;
            continue;
          case 12:
            if (image.Height > (int) ushort.MaxValue)
            {
              num1 = 2;
              continue;
            }
            indexImage = image as IndexImage;
            num1 = 14;
            continue;
          case 14:
            if (indexImage != null)
            {
              num1 = 11;
              continue;
            }
            goto case 3;
          case 15:
            tgaFileHeader.ImageType = length1 > 0 ? (byte) 9 : (byte) 10;
            tgaFileHeader.FirstEntryIndex = (ushort) 0;
            tgaFileHeader.ColorMapLength = (ushort) length1;
            num1 = 5;
            continue;
          case 16:
            tgaFileHeader.ColorMapType = length1 > 0 ? (byte) 1 : (byte) 0;
            num1 = 15;
            continue;
          case 17:
            int A_4 = (image.Bpp + 7) / 8;
            int length2 = (int) tgaFileHeader.ImageWidth * (int) tgaFileHeader.ImageHeight * A_4;
            byte[] numArray2 = new byte[length2];
            byte[] numArray3 = new byte[length2];
            image.Extract(numArray2, 1);
            TgaFile.a(numArray3, numArray2, (int) tgaFileHeader.ImageWidth, (int) tgaFileHeader.ImageHeight, A_4, false, true);
            numArray1 = new byte[length2 * 2];
            count = TgaFile.b(numArray1, numArray3, (int) tgaFileHeader.ImageWidth, (int) tgaFileHeader.ImageHeight, A_4);
            tgaFileFooter.ExtensionAreaOffset = 0U;
            tgaFileFooter.DeveloperDirectoryOffset = 0U;
            TgaFile.a("TRUEVISION-XFILE.\0", tgaFileFooter.Signature);
            orderBinaryWriter = new ByteOrderBinaryWriter((Stream) BinaryFile.Open(this.c, FileMode.Create, FileAccess.Write), true);
            num1 = 8;
            continue;
          default:
            goto label_2;
        }
      }
label_8:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_TGA_OVER_SIZE, (object) image.Width, (object) image.Height);
label_27:
      try
      {
label_29:
        orderBinaryWriter.Write((object) tgaFileHeader);
        byte[] numArray4 = new byte["fontcvtr output.".Length];
        TgaFile.a("fontcvtr output.", numArray4);
        orderBinaryWriter.Write(numArray4, 0, numArray4.Length);
        int index2 = 0;
        int num2 = 2;
        while (true)
        {
          switch (num2)
          {
            case 0:
              if (index2 >= length1)
              {
                num2 = 3;
                continue;
              }
              IntColor intColor = intColorArray[index2];
              byte[] buffer = new byte[4];
              buffer[3] = intColor.R;
              buffer[2] = intColor.G;
              buffer[1] = intColor.B;
              buffer[0] = intColor.A;
              orderBinaryWriter.Write(buffer);
              ++index2;
              num2 = 1;
              continue;
            case 1:
            case 2:
              num2 = 0;
              continue;
            case 3:
              orderBinaryWriter.Write(numArray1, 0, count);
              orderBinaryWriter.Write((object) tgaFileFooter);
              num2 = 4;
              continue;
            case 4:
              goto label_40;
            default:
              goto label_29;
          }
        }
label_40:;
      }
      finally
      {
        int num2 = 1;
        while (true)
        {
          switch (num2)
          {
            case 0:
              goto label_41;
            case 2:
              orderBinaryWriter.Dispose();
              num2 = 0;
              continue;
            default:
              if (orderBinaryWriter != null)
              {
                num2 = 2;
                continue;
              }
              goto label_41;
          }
        }
label_41:;
      }
    }

    public bool HasValidIdentifier()
    {
      BinaryFile binaryFile = BinaryFile.Open(this.c, FileMode.Open, FileAccess.Read);
      TgaFile.TgaFileFooter A_1;
      try
      {
        this.a(new ByteOrderBinaryReader((Stream) binaryFile, true), out A_1);
      }
      finally
      {
        int num = 2;
        while (true)
        {
          switch (num)
          {
            case 0:
              goto label_7;
            case 1:
              binaryFile.Dispose();
              num = 0;
              continue;
            default:
              if (binaryFile != null)
              {
                num = 1;
                continue;
              }
              goto label_7;
          }
        }
label_7:;
      }
      if (1 == 0)
        ;
      return this.a(A_1);
    }

    public bool IsIndex()
    {
      BinaryFile binaryFile = BinaryFile.Open(this.c, FileMode.Open, FileAccess.Read);
      TgaFile.TgaFileHeader A_1;
      try
      {
        this.a(new ByteOrderBinaryReader((Stream) binaryFile, true), out A_1);
      }
      finally
      {
        int num = 1;
        while (true)
        {
          switch (num)
          {
            case 0:
              goto label_8;
            case 2:
              binaryFile.Dispose();
              num = 0;
              continue;
            default:
              if (1 == 0)
                ;
              if (binaryFile != null)
              {
                num = 2;
                continue;
              }
              goto label_8;
          }
        }
label_8:;
      }
      this.b(A_1);
      return A_1.IsIndex;
    }

    public bool IsInvalid()
    {
      BinaryFile binaryFile = BinaryFile.Open(this.c, FileMode.Open, FileAccess.Read);
      TgaFile.TgaFileHeader A_1;
      try
      {
        if (1 == 0)
          ;
        this.a(new ByteOrderBinaryReader((Stream) binaryFile, true), out A_1);
      }
      finally
      {
        int num = 2;
        while (true)
        {
          switch (num)
          {
            case 0:
              binaryFile.Dispose();
              num = 1;
              continue;
            case 1:
              goto label_10;
            default:
              if (binaryFile != null)
              {
                num = 0;
                continue;
              }
              goto label_10;
          }
        }
label_10:;
      }
      try
      {
        this.b(A_1);
      }
      catch (GeneralException ex)
      {
        return true;
      }
      return false;
    }

    private static int b(byte[] A_0, int A_1, byte[] A_2, int A_3, int A_4, int A_5)
    {
      int num1 = 0;
      while (true)
      {
        switch (num1)
        {
          case 1:
            goto label_7;
          case 3:
            if (A_5 <= 0)
            {
              num1 = 1;
              continue;
            }
            int num2 = Math.Min(A_5, 128);
            int length = A_4;
            A_0[A_1++] = (byte) (128 | num2 - 1);
            Array.Copy((Array) A_2, A_3, (Array) A_0, A_1, length);
            A_1 += length;
            A_5 -= num2;
            if (1 == 0)
              ;
            num1 = 2;
            continue;
          default:
            num1 = 3;
            continue;
        }
      }
label_7:
      return A_1;
    }

    private static int a(byte[] A_0, int A_1, byte[] A_2, int A_3, int A_4, int A_5)
    {
      if (1 == 0)
        ;
      int num1 = 3;
      while (true)
      {
        switch (num1)
        {
          case 0:
            if (A_5 <= 0)
            {
              num1 = 1;
              continue;
            }
            int num2 = Math.Min(A_5, 128);
            int length = A_4 * num2;
            A_0[A_1++] = (byte) (num2 - 1);
            Array.Copy((Array) A_2, A_3, (Array) A_0, A_1, length);
            A_1 += length;
            A_5 -= num2;
            num1 = 2;
            continue;
          case 1:
            goto label_7;
          default:
            num1 = 0;
            continue;
        }
      }
label_7:
      return A_1;
    }

    private static int b(byte[] A_0, byte[] A_1, int A_2, int A_3, int A_4)
    {
label_2:
      int A_2_1 = 0;
      int A_1_1 = 0;
      int num1 = 0;
      int num2 = 9;
      int A_3_1 = 0;
      int A_5 = 0;
      int num3 = 0;
      int num4 = 0;
      bool flag1 = false;
      bool flag2 = false;
      while (true)
      {
        switch (num2)
        {
          case 0:
            ++A_5;
            num3 = A_2_1;
            A_2_1 += A_4;
            ++num4;
            num2 = 6;
            continue;
          case 1:
            if (flag1)
            {
              num2 = 17;
              continue;
            }
            A_1_1 = TgaFile.b(A_0, A_1_1, A_1, num3, A_4, A_5);
            num2 = 18;
            continue;
          case 2:
            A_1_1 = TgaFile.a(A_0, A_1_1, A_1, A_3_1, A_4, A_5 - 1);
            A_5 = 1;
            num2 = 5;
            continue;
          case 3:
            if (num4 < A_2)
            {
              flag2 = !TgaFile.a(A_1, num3, A_2_1, A_4);
              num2 = 15;
              continue;
            }
            num2 = 14;
            continue;
          case 4:
          case 6:
            num2 = 3;
            continue;
          case 5:
          case 12:
            flag1 = flag2;
            num2 = 0;
            continue;
          case 7:
            if (num1 >= A_3)
            {
              num2 = 8;
              continue;
            }
            A_5 = 1;
            flag1 = true;
            num3 = A_2_1;
            A_3_1 = A_2_1;
            A_2_1 += A_4;
            num4 = 1;
            num2 = 4;
            continue;
          case 8:
            goto label_27;
          case 9:
          case 16:
            num2 = 7;
            continue;
          case 10:
          case 18:
            ++num1;
            if (1 == 0)
              ;
            num2 = 16;
            continue;
          case 11:
            if (flag1)
            {
              num2 = 2;
              continue;
            }
            A_1_1 = TgaFile.b(A_0, A_1_1, A_1, num3, A_4, A_5);
            A_5 = 0;
            A_3_1 = A_2_1;
            num2 = 12;
            continue;
          case 13:
            num2 = 11;
            continue;
          case 14:
            num2 = 1;
            continue;
          case 15:
            if (flag2 != flag1)
            {
              num2 = 13;
              continue;
            }
            goto case 0;
          case 17:
            A_1_1 = TgaFile.a(A_0, A_1_1, A_1, A_3_1, A_4, A_5);
            num2 = 10;
            continue;
          default:
            goto label_2;
        }
      }
label_27:
      return A_1_1;
    }

    private static void a(byte[] A_0, byte[] A_1, int A_2, int A_3, int A_4, bool A_5, bool A_6)
    {
label_2:
      int length = A_2 * A_4;
      int destinationIndex = 0;
      int num1 = 0;
      int num2 = 5;
      int sourceIndex = 0;
      int num3 = 0;
      while (true)
      {
        switch (num2)
        {
          case 0:
            num2 = 9;
            continue;
          case 1:
            goto label_21;
          case 2:
            if (A_6)
            {
              num2 = 8;
              continue;
            }
            sourceIndex = length * num1;
            num2 = 11;
            continue;
          case 3:
            if (num3 < A_2)
            {
              sourceIndex -= A_4;
              Array.Copy((Array) A_1, sourceIndex, (Array) A_0, destinationIndex, A_4);
              destinationIndex += A_4;
              --num3;
              num2 = 10;
              continue;
            }
            num2 = 0;
            continue;
          case 4:
            sourceIndex += length;
            num3 = 0;
            num2 = 6;
            continue;
          case 5:
          case 14:
            num2 = 13;
            continue;
          case 6:
          case 10:
            num2 = 3;
            continue;
          case 7:
            if (!A_5)
            {
              Array.Copy((Array) A_1, sourceIndex, (Array) A_0, destinationIndex, length);
              destinationIndex += length;
              num2 = 15;
              continue;
            }
            num2 = 4;
            continue;
          case 8:
            sourceIndex = length * (A_3 - num1 - 1);
            if (1 == 0)
              ;
            num2 = 12;
            continue;
          case 9:
          case 15:
            ++num1;
            num2 = 14;
            continue;
          case 11:
          case 12:
            num2 = 7;
            continue;
          case 13:
            num2 = num1 < A_3 ? 2 : 1;
            continue;
          default:
            goto label_2;
        }
      }
label_21:;
    }

    private static bool a(byte[] A_0, string A_1)
    {
      int num = 0;
      int index = 0;
      while (true)
      {
        switch (num)
        {
          case 1:
            num = index < A_0.Length ? 6 : 7;
            continue;
          case 2:
          case 3:
            num = 1;
            continue;
          case 4:
            goto label_8;
          case 5:
            goto label_12;
          case 6:
            if ((int) A_0[index] == (int) A_1[index])
            {
              if (1 == 0)
                ;
              ++index;
              num = 3;
              continue;
            }
            num = 5;
            continue;
          case 7:
            goto label_13;
          default:
            if (A_0.Length != A_1.Length)
            {
              num = 4;
              continue;
            }
            index = 0;
            num = 2;
            continue;
        }
      }
label_8:
      return false;
label_12:
      return false;
label_13:
      return true;
    }

    private static void a(string A_0, byte[] A_1)
    {
label_2:
      int index = 0;
      int num = 2;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (index >= A_0.Length)
            {
              num = 1;
              continue;
            }
            A_1[index] = (byte) A_0[index];
            ++index;
            num = 3;
            continue;
          case 1:
            goto label_8;
          case 2:
          case 3:
            if (1 == 0)
              ;
            num = 0;
            continue;
          default:
            goto label_2;
        }
      }
label_8:;
    }

    private static bool a(byte[] A_0, int A_1, int A_2, int A_3)
    {
label_3:
      int num1 = 0;
      int num2 = 3;
      while (true)
      {
        if (1 == 0)
          ;
        switch (num2)
        {
          case 0:
            goto label_10;
          case 1:
            if ((int) A_0[A_1++] == (int) A_0[A_2++])
            {
              ++num1;
              num2 = 2;
              continue;
            }
            num2 = 4;
            continue;
          case 2:
          case 3:
            num2 = 5;
            continue;
          case 4:
            goto label_5;
          case 5:
            num2 = num1 < A_3 ? 1 : 0;
            continue;
          default:
            goto label_3;
        }
      }
label_5:
      return false;
label_10:
      return true;
    }

    private void a(ByteOrderBinaryReader A_0, out TgaFile.TgaFileHeader A_1)
    {
      if (1 == 0)
        ;
      A_0.Seek(0, SeekOrigin.Begin);
      A_0.Read<TgaFile.TgaFileHeader>(out A_1);
      A_0.Seek((int) A_1.IdLength, SeekOrigin.Current);
    }

    private void a(ByteOrderBinaryReader A_0, out TgaFile.TgaFileFooter A_1)
    {
      if (1 == 0)
        ;
      int num = Marshal.SizeOf(typeof (TgaFile.TgaFileFooter));
      A_0.Seek(-num, SeekOrigin.End);
      A_0.Read<TgaFile.TgaFileFooter>(out A_1);
      Array.ForEach<byte>(A_1.Signature, (Action<byte>) (A_0_2 => {}));
    }

    private void a(ByteOrderBinaryReader A_0, IndexImage A_1, TgaFile.TgaFileHeader A_2)
    {
label_2:
      int num1 = ((int) A_2.ColorMapEntrySize + 7) / 8;
      int num2 = (int) A_2.ColorMapLength;
      int count = num1 * num2;
      IntColor[] table = new IntColor[num2];
      byte[] buffer = new byte[count];
      int index1 = 0;
      A_0.Read(buffer, 0, count);
      int index2 = 0;
      int num3 = 2;
      int num4 = 0;
      int num5 = 0;
      int num6 = 0;
      int num7 = 0;
      byte num8 = 0;
      int num9 = 0;
      int num10 = 0;
      while (true)
      {
        switch (num3)
        {
          case 0:
            if ((int) num8 == 24)
            {
              num4 = (int) buffer[index1 + 2];
              num5 = (int) buffer[index1 + 1];
              num6 = (int) buffer[index1];
              num7 = (int) byte.MaxValue;
              num3 = 13;
              continue;
            }
            num3 = 4;
            continue;
          case 1:
            num10 = (int) byte.MaxValue;
            break;
          case 2:
          case 15:
            num3 = 19;
            continue;
          case 3:
            if ((int) num8 != 32)
            {
              num3 = 9;
              continue;
            }
            num4 = (int) buffer[index1 + 3];
            num5 = (int) buffer[index1 + 2];
            num6 = (int) buffer[index1 + 1];
            num7 = (int) buffer[index1];
            num3 = 6;
            continue;
          case 4:
            num3 = 3;
            continue;
          case 5:
            int num11;
            num7 = num11 = 0;
            num6 = num11;
            num5 = num11;
            num4 = num11;
            num3 = 10;
            continue;
          case 6:
          case 10:
          case 12:
          case 13:
          case 18:
            table[index2] = GlCm.BMP_RGBA((byte) num4, (byte) num5, (byte) num6, (byte) num7);
            index1 += num1;
            ++index2;
            num3 = 15;
            continue;
          case 7:
            num3 = 14;
            continue;
          case 8:
            switch (num8)
            {
              case (byte) 15:
                int num12 = (int) buffer[index1 + 1] << 8 | (int) buffer[index1];
                num4 = num12 & 31;
                num5 = num12 >> 5 & 31;
                num6 = num12 >> 10 & 31;
                num7 = (int) byte.MaxValue;
                num3 = 18;
                continue;
              case (byte) 16:
                num9 = (int) buffer[index1 + 1] << 8 | (int) buffer[index1];
                num4 = num9 & 31;
                num5 = num9 >> 5 & 31;
                num6 = num9 >> 10 & 31;
                num3 = 16;
                continue;
              default:
                num3 = 17;
                continue;
            }
          case 9:
            num3 = 5;
            continue;
          case 11:
            goto label_27;
          case 14:
            num10 = 0;
            break;
          case 16:
            num3 = num9 >> 15 != 0 ? 1 : 7;
            continue;
          case 17:
            num3 = 0;
            continue;
          case 19:
            if (index2 >= num2)
            {
              num3 = 11;
              continue;
            }
            num8 = A_2.ColorMapEntrySize;
            num3 = 8;
            continue;
          default:
            goto label_2;
        }
        num7 = num10;
        num3 = 12;
      }
label_27:
      if (1 == 0)
        ;
      A_1.SetColorTable(table, num2);
    }

    private void b(TgaFile.TgaFileHeader A_0)
    {
      int num1 = 2;
      int num2 = 0;
      int num3 = 0;
      while (true)
      {
        switch (num1)
        {
          case 0:
            num1 = num3 != 0 ? 3 : 9;
            continue;
          case 1:
            num1 = 4;
            continue;
          case 3:
            if (num2 >= num3)
            {
              num1 = 6;
              continue;
            }
            break;
          case 4:
            if ((int) A_0.ColorMapType != 1)
            {
              num1 = 5;
              continue;
            }
            num2 = (int) A_0.FirstEntryIndex;
            num3 = (int) A_0.ColorMapLength;
            num1 = 0;
            continue;
          case 5:
            goto label_24;
          case 6:
            goto label_19;
          case 7:
            num1 = 10;
            continue;
          case 8:
            goto label_20;
          case 9:
            goto label_25;
          case 10:
            if ((int) A_0.ImageHeight == 0)
            {
              num1 = 8;
              continue;
            }
            goto label_23;
          case 11:
            num1 = 12;
            continue;
          case 12:
            if ((int) A_0.ImageType == 9)
            {
              num1 = 1;
              continue;
            }
            break;
          case 13:
            if ((int) A_0.ImageWidth != 0)
            {
              num1 = 7;
              continue;
            }
            goto label_20;
          default:
            if ((int) A_0.ImageType != 1)
            {
              if (1 == 0)
                ;
              num1 = 11;
              continue;
            }
            goto case 1;
        }
        num1 = 13;
      }
label_23:
      return;
label_19:
      throw GlCm.ErrMsg(ErrorType.Tga, Strings.IDS_ERR_PALEETE_OVER_ENTRY);
label_20:
      throw GlCm.ErrMsg(ErrorType.Tga, Strings.IDS_ERR_ILLEGAL_IMAGE_SIZE, (object) this.c, (object) A_0.ImageWidth, (object) A_0.ImageHeight);
label_24:
      throw GlCm.ErrMsg(ErrorType.Tga, Strings.IDS_ERR_REQUIRE_PALETTE);
label_25:
      throw GlCm.ErrMsg(ErrorType.Tga, Strings.IDS_ERR_PALETTE_NO_ENTRY);
    }

    private void a(TgaFile.TgaFileHeader A_0)
    {
label_2:
      bool flag = false;
      int num = 19;
      while (true)
      {
        switch (num)
        {
          case 0:
            if ((int) A_0.ImageType == 9)
            {
              num = 23;
              continue;
            }
            goto case 33;
          case 1:
            num = 10;
            continue;
          case 2:
            num = 37;
            continue;
          case 3:
            if (!flag)
            {
              num = 6;
              continue;
            }
            goto label_65;
          case 4:
            if ((int) A_0.PixelDepth != 32)
            {
              num = 8;
              continue;
            }
            goto label_45;
          case 5:
            goto label_14;
          case 6:
            num = 4;
            continue;
          case 7:
            num = 20;
            continue;
          case 8:
            goto label_65;
          case 9:
            if (1 == 0)
              ;
            if ((int) A_0.ColorMapEntrySize != 32)
            {
              num = 30;
              continue;
            }
            goto label_53;
          case 10:
            if ((int) A_0.ImageType != 10)
            {
              num = 31;
              continue;
            }
            break;
          case 11:
            num = 28;
            continue;
          case 12:
            goto label_32;
          case 13:
            if ((int) A_0.PixelDepth != 8)
            {
              num = 7;
              continue;
            }
            goto label_45;
          case 14:
            if ((int) A_0.ColorMapEntrySize != 24)
            {
              num = 32;
              continue;
            }
            goto label_53;
          case 15:
            if (((int) A_0.ImageDesc & 15) != 8)
            {
              num = 16;
              continue;
            }
            goto label_60;
          case 16:
            num = 38;
            continue;
          case 17:
            if ((int) A_0.PixelDepth != 16)
            {
              num = 34;
              continue;
            }
            goto label_45;
          case 18:
            num = 17;
            continue;
          case 19:
            if ((int) A_0.ImageType != 1)
            {
              num = 25;
              continue;
            }
            break;
          case 20:
            if (flag)
            {
              num = 18;
              continue;
            }
            goto case 34;
          case 21:
            if ((int) A_0.ImageType != 2)
            {
              num = 11;
              continue;
            }
            break;
          case 22:
            num = ((int) A_0.ImageDesc & 192) == 0 ? 15 : 5;
            continue;
          case 23:
            num = 14;
            continue;
          case 24:
            if (flag)
            {
              num = 36;
              continue;
            }
            goto case 7;
          case 25:
            num = 21;
            continue;
          case 26:
            if ((int) A_0.ImageType != 1)
            {
              num = 35;
              continue;
            }
            goto case 23;
          case 27:
            if (!flag)
            {
              num = 2;
              continue;
            }
            goto case 29;
          case 28:
            if ((int) A_0.ImageType != 9)
            {
              num = 1;
              continue;
            }
            break;
          case 29:
            num = 3;
            continue;
          case 30:
            goto label_33;
          case 31:
            goto label_40;
          case 32:
            num = 9;
            continue;
          case 33:
            num = 24;
            continue;
          case 34:
            num = 27;
            continue;
          case 35:
            num = 0;
            continue;
          case 36:
            num = 13;
            continue;
          case 37:
            if ((int) A_0.PixelDepth != 24)
            {
              num = 29;
              continue;
            }
            goto label_45;
          case 38:
            if (((int) A_0.ImageDesc & 15) != 0)
            {
              num = 12;
              continue;
            }
            goto label_64;
          default:
            goto label_2;
        }
        num = 26;
        continue;
label_45:
        num = 22;
        continue;
label_53:
        flag = true;
        num = 33;
      }
label_14:
      throw GlCm.ErrMsg(ErrorType.Tga, Strings.IDS_ERR_TGA_UNSUPPORTED_IMAGE_DESC, (object) A_0.ImageDesc);
label_64:
      return;
label_60:
      return;
label_32:
      throw GlCm.ErrMsg(ErrorType.Tga, Strings.IDS_ERR_TGA_UNSUPPORTED_ALPHA, (object) A_0.ImageDesc);
label_33:
      throw GlCm.ErrMsg(ErrorType.Tga, Strings.IDS_ERR_TGA_UNSUPPORTED_PALETTE_ENTRY, (object) A_0.ColorMapEntrySize);
label_40:
      throw GlCm.ErrMsg(ErrorType.Tga, Strings.IDS_ERR_TGA_UNSUPPORTED_IMAGE_TYPE, (object) A_0.ImageType);
label_65:
      throw GlCm.ErrMsg(ErrorType.Tga, Strings.IDS_ERR_TGA_UNSUPPORTED_BPP, (object) A_0.ImageType, (object) A_0.PixelDepth);
    }

    private bool a(TgaFile.TgaFileFooter A_0)
    {
      return TgaFile.a(A_0.Signature, "TRUEVISION-XFILE.\0");
    }

    private void a(byte[] A_0, byte[] A_1, int A_2, int A_3, int A_4)
    {
label_2:
      int num1 = A_2 * A_3 * A_4;
      int sourceIndex = 0;
      int destinationIndex = 0;
      int num2 = 2;
      int num3 = 0;
      int num4 = 0;
      byte num5 = 0;
      while (true)
      {
        switch (num2)
        {
          case 0:
          case 2:
          case 10:
            num2 = 9;
            continue;
          case 1:
            if (num3 >= num4)
            {
              num2 = 7;
              continue;
            }
            Array.Copy((Array) A_1, sourceIndex, (Array) A_0, destinationIndex, A_4);
            destinationIndex += A_4;
            ++num3;
            num2 = 3;
            continue;
          case 3:
          case 8:
            num2 = 1;
            continue;
          case 4:
            if (((int) num5 & 128) != 0)
            {
              num2 = 5;
              continue;
            }
            int length = A_4 * num4;
            Array.Copy((Array) A_1, sourceIndex, (Array) A_0, destinationIndex, length);
            destinationIndex += length;
            sourceIndex += length;
            if (1 == 0)
              ;
            num2 = 0;
            continue;
          case 5:
            num3 = 0;
            num2 = 8;
            continue;
          case 6:
            goto label_17;
          case 7:
            sourceIndex += A_4;
            num2 = 10;
            continue;
          case 9:
            if (destinationIndex >= num1)
            {
              num2 = 6;
              continue;
            }
            num5 = A_1[sourceIndex++];
            num4 = ((int) num5 & (int) sbyte.MaxValue) + 1;
            num2 = 4;
            continue;
          default:
            goto label_2;
        }
      }
label_17:;
    }

    protected enum ColorMap
    {
      None,
      Exists,
    }

    [Flags]
    protected enum ImageType
    {
      FlagRunLengthCompressed = 8,
      None = 0,
      ColorMap = 1,
      TrueColor = 2,
      BlackAndWhite = TrueColor | ColorMap,
      RunLengthColorMap = ColorMap | FlagRunLengthCompressed,
      RunLengthTrueColor = TrueColor | FlagRunLengthCompressed,
      RunLengthBlackAndWhite = RunLengthTrueColor | ColorMap,
    }

    [Flags]
    protected enum ImageDescFormat
    {
      AlphaMask = 15,
      RightToLeft = 16,
      TopToBottom = 32,
      UnusedMask = 192,
    }

    [Flags]
    protected enum RunLengthPacketFormat
    {
      RunLengthFlag = 128,
      NumDataMask = 127,
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    private class TgaFileHeader
    {
      public byte IdLength;
      public byte ColorMapType;
      public byte ImageType;
      public ushort FirstEntryIndex;
      public ushort ColorMapLength;
      public byte ColorMapEntrySize;
      public ushort XOrigin;
      public ushort YOrigin;
      public ushort ImageWidth;
      public ushort ImageHeight;
      public byte PixelDepth;
      public byte ImageDesc;

      public bool IsIndex
      {
        get
        {
          return ((int) this.ImageType & 3) == 1;
        }
      }

      public bool IsRunLengthCompressed
      {
        get
        {
          return ((int) this.ImageType & 8) != 0;
        }
      }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    private class TgaFileFooter
    {
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
      public byte[] Signature = new byte[18];
      public const int SignatureSize = 18;
      public uint ExtensionAreaOffset;
      public uint DeveloperDirectoryOffset;
    }
  }
}
