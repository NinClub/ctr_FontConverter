// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.BitmapFile
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace NintendoWare.Font
{
  public class BitmapFile
  {
    private const ushort m_ua = (ushort) 19778;
    private string m_sb;

    public BitmapFile(string fname)
    {
      this.m_sb = fname;
    }

    public ImageBase Load()
    {
      BitmapFile.BITMAPHEADER bitmapheader = new BitmapFile.BITMAPHEADER();
      BinaryFile binaryFile = BinaryFile.Open(this.m_sb, FileMode.Open, FileAccess.Read);
      ImageBase imageBase = null;
      try
      {
label_3:
        ByteOrderBinaryReader A_0 = new ByteOrderBinaryReader((Stream) binaryFile, true);
        this.a(A_0, bitmapheader);
        this.b(bitmapheader);
        this.a(bitmapheader);
        bool flag1 = BitmapFile.a((int) bitmapheader.bmih.biBitCount);
        int num1 = 2;
        bool flag2 = false;
        int height = 0;
        int count = 0;
        byte[] numArray = null;
        int num2 = 0;
        int num3 = 0;
        while (true)
        {
          switch (num1)
          {
            case 0:
            case 5:
              flag2 = bitmapheader.bmih.biHeight > 0;
              height = Math.Abs(bitmapheader.bmih.biHeight);
              count = this.c(ref bitmapheader.bmih);
              numArray = new byte[this.b(ref bitmapheader.bmih)];
              A_0.Seek((int) bitmapheader.bmfh.bfOffBits, SeekOrigin.Begin);
              num1 = 3;
              continue;
            case 1:
            case 10:
              num1 = 6;
              continue;
            case 2:
              if (flag1)
              {
                num1 = 13;
                continue;
              }
              imageBase = (ImageBase) new RgbImage();
              int num4 = (int) bitmapheader.bmih.biCompression;
              num1 = 0;
              continue;
            case 3:
              if (flag2)
              {
                num1 = 15;
                continue;
              }
              num2 = 0;
              num1 = 17;
              continue;
            case 4:
              num1 = 14;
              continue;
            case 6:
              if (num3 < height)
              {
                int index = (height - num3 - 1) * count;
                A_0.Read(numArray, index, count);
                ++num3;
                num1 = 1;
                continue;
              }
              num1 = 4;
              continue;
            case 7:
              if ((int) bitmapheader.bmih.biBitCount == 32)
              {
                num1 = 8;
                continue;
              }
              goto case 12;
            case 8:
              imageBase.EnableAlpha();
              num1 = 12;
              continue;
            case 9:
              if (1 == 0)
                goto case 14;
              else
                goto case 14;
            case 11:
              if (num2 >= height)
              {
                num1 = 9;
                continue;
              }
              int index1 = num2 * count;
              A_0.Read(numArray, index1, count);
              ++num2;
              num1 = 18;
              continue;
            case 12:
              num1 = 16;
              continue;
            case 13:
              IndexImage A_1 = new IndexImage();
              imageBase = (ImageBase) A_1;
              this.a(A_0, A_1, (int) bitmapheader.bmih.biBitCount);
              num1 = 5;
              continue;
            case 14:
              imageBase.Create(bitmapheader.bmih.biWidth, height, (int) bitmapheader.bmih.biBitCount);
              imageBase.Paste(numArray, 4);
              num1 = 7;
              continue;
            case 15:
              num3 = 0;
              num1 = 10;
              continue;
            case 16:
              goto label_34;
            case 17:
            case 18:
              num1 = 11;
              continue;
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
      int num1 = Marshal.SizeOf(typeof (BITMAPINFOHEADER));
      BITMAPFILEHEADER bitmapfileheader = new BITMAPFILEHEADER();
      IndexImage indexImage = image as IndexImage;
      int num2 = 10;
      int length = 0;
      byte[] numArray = null;
      int index1 = 0;
      RGBQUAD[] array = null;
      int num3 = 0;
      int num4 = 0;
      BITMAPINFOHEADER bitmapinfoheader = default(BITMAPINFOHEADER);
      ByteOrderBinaryWriter bw = null;
      while (true)
      {
        switch (num2)
        {
          case 0:
          case 4:
            length = BitmapFile.a(image.Width, image.Height, num3);
            bitmapinfoheader = new BITMAPINFOHEADER();
            array = (RGBQUAD[]) null;
            bitmapfileheader.bfType = (ushort) 19778;
            bitmapfileheader.bfSize = (uint) (Marshal.SizeOf(bitmapfileheader.GetType()) + num1 + length);
            bitmapfileheader.bfOffBits = (uint) (Marshal.SizeOf(bitmapfileheader.GetType()) + num1);
            bitmapinfoheader.biSize = (uint) Marshal.SizeOf(bitmapinfoheader.GetType());
            bitmapinfoheader.biWidth = image.Width;
            bitmapinfoheader.biHeight = image.Height;
            bitmapinfoheader.biPlanes = (ushort) 1;
            bitmapinfoheader.biBitCount = (ushort) num3;
            bitmapinfoheader.biCompression = 0U;
            bitmapinfoheader.biSizeImage = (uint) length;
            bitmapinfoheader.biXPelsPerMeter = 2834;
            bitmapinfoheader.biYPelsPerMeter = 2834;
            bitmapinfoheader.biClrUsed = (uint) num4;
            bitmapinfoheader.biClrImportant = (uint) num4;
            num2 = 3;
            continue;
          case 1:
            if (1 == 0)
              goto case 8;
            else
              goto case 8;
          case 2:
            numArray = new byte[length];
            image.Extract(numArray, 4);
            bw = new ByteOrderBinaryWriter((Stream) BinaryFile.Open(this.m_sb, FileMode.Create, FileAccess.Write), true);
            num2 = 9;
            continue;
          case 3:
            if (indexImage != null)
            {
              num2 = 5;
              continue;
            }
            goto case 2;
          case 5:
            array = new RGBQUAD[indexImage.GetColorTableEntryNum()];
            index1 = 0;
            num2 = 1;
            continue;
          case 6:
            if (index1 < array.Length)
            {
              IntColor intColor = indexImage.GetColorTable()[index1];
              array[index1].rgbRed = intColor.R;
              array[index1].rgbGreen = intColor.G;
              array[index1].rgbBlue = intColor.B;
              array[index1].rgbReserved = intColor.A;
              ++index1;
              num2 = 8;
              continue;
            }
            num2 = 2;
            continue;
          case 7:
            num4 = indexImage.GetColorTableEntryNum();
            int num5 = 256;
            num1 += num5 * Marshal.SizeOf(typeof (RGBQUAD));
            num3 = 8;
            num2 = 4;
            continue;
          case 8:
            num2 = 6;
            continue;
          case 9:
            goto label_8;
          case 10:
            if (indexImage != null)
            {
              num2 = 7;
              continue;
            }
            num3 = image.Bpp;
            num4 = 0;
            num2 = 0;
            continue;
          default:
            goto label_2;
        }
      }
label_8:
      try
      {
label_10:
        bw.Write((object) bitmapfileheader);
        bw.Write((object) bitmapinfoheader);
        int num6 = 3;
        int count = 0;
        int num7 = 0;
        while (true)
        {
          switch (num6)
          {
            case 0:
            case 6:
              num6 = 1;
              continue;
            case 1:
              if (num7 > length)
              {
                num6 = 4;
                continue;
              }
              int index2 = length - num7;
              bw.Write(numArray, index2, count);
              num7 += count;
              num6 = 6;
              continue;
            case 2:
              goto label_36;
            case 3:
              if (array != null)
              {
                num6 = 8;
                continue;
              }
              goto case 7;
            case 4:
              num6 = 2;
              continue;
            case 5:
              Array.ForEach<RGBQUAD>(array, (Action<RGBQUAD>) (col => bw.Write((object) col)));
              num6 = 7;
              continue;
            case 7:
              count = BitmapFile.a(image.Width, num3);
              num7 = count;
              num6 = 0;
              continue;
            case 8:
              num6 = 5;
              continue;
            default:
              goto label_10;
          }
        }
label_36:;
      }
      finally
      {
        int num6 = 0;
        while (true)
        {
          switch (num6)
          {
            case 1:
              bw.Dispose();
              num6 = 2;
              continue;
            case 2:
              goto label_26;
            default:
              if (bw != null)
              {
                num6 = 1;
                continue;
              }
              goto label_26;
          }
        }
label_26:;
      }
    }

    public bool IsIndex()
    {
      BitmapFile.BITMAPHEADER bitmapheader = new BitmapFile.BITMAPHEADER();
      BinaryFile binaryFile = BinaryFile.Open(this.m_sb, FileMode.Open, FileAccess.Read);
      try
      {
        this.a(new ByteOrderBinaryReader((Stream) binaryFile, true), bitmapheader);
      }
      finally
      {
        int num = 1;
        while (true)
        {
          switch (num)
          {
            case 0:
              goto label_7;
            case 2:
              binaryFile.Dispose();
              num = 0;
              continue;
            default:
              if (binaryFile != null)
              {
                num = 2;
                continue;
              }
              goto label_7;
          }
        }
label_7:;
      }
      if (1 == 0)
        ;
      this.b(bitmapheader);
      return BitmapFile.a((int) bitmapheader.bmih.biBitCount);
    }

    public bool HasValidIdentifier()
    {
      BitmapFile.BITMAPHEADER A_1 = new BitmapFile.BITMAPHEADER();
      BinaryFile binaryFile = BinaryFile.Open(this.m_sb, FileMode.Open, FileAccess.Read);
      try
      {
        this.a(new ByteOrderBinaryReader((Stream) binaryFile, true), A_1);
      }
      finally
      {
        int num = 0;
        while (true)
        {
          switch (num)
          {
            case 1:
              goto label_8;
            case 2:
              binaryFile.Dispose();
              num = 1;
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
      return (int) A_1.bmfh.bfType == 19778;
    }

    public bool IsInvalid()
    {
      BitmapFile.BITMAPHEADER bitmapheader = new BitmapFile.BITMAPHEADER();
      BinaryFile binaryFile = BinaryFile.Open(this.m_sb, FileMode.Open, FileAccess.Read);
      try
      {
        if (1 == 0)
          ;
        this.a(new ByteOrderBinaryReader((Stream) binaryFile, true), bitmapheader);
      }
      finally
      {
        int num = 2;
        while (true)
        {
          switch (num)
          {
            case 0:
              goto label_10;
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
              goto label_10;
          }
        }
label_10:;
      }
      try
      {
        this.b(bitmapheader);
      }
      catch (GeneralException ex)
      {
        return true;
      }
      return false;
    }

    private static int a(int A_0, int A_1)
    {
      return (A_0 * A_1 + 31) / 32 * 4;
    }

    private static int a(int A_0, int A_1, int A_2)
    {
      return BitmapFile.a(A_0, A_2) * A_1;
    }

    private static bool a(int A_0)
    {
      return A_0 < 16;
    }

    private int c(ref BITMAPINFOHEADER A_0)
    {
      return BitmapFile.a(A_0.biWidth, (int) A_0.biBitCount);
    }

    private int b(ref BITMAPINFOHEADER A_0)
    {
      int num = this.c(ref A_0);
      return Math.Abs(A_0.biHeight) * num;
    }

    private int a(ref BITMAPINFOHEADER A_0)
    {
      if ((int) A_0.biClrUsed == 0)
        return 1 << (int) A_0.biBitCount;
      if (1 == 0)
        ;
      return (int) A_0.biClrUsed;
    }

    private void a(ByteOrderBinaryReader A_0, BitmapFile.BITMAPHEADER A_1)
    {
      if (1 == 0)
        ;
      A_0.Seek(0, SeekOrigin.Begin);
      A_0.Read<BITMAPFILEHEADER>(out A_1.bmfh);
      A_0.Read<BITMAPINFOHEADER>(out A_1.bmih);
    }

    private void a(ByteOrderBinaryReader A_0, IndexImage A_1, int A_2)
    {
label_2:
      int num1 = 1 << A_2;
      IntColor[] table = new IntColor[num1];
      int index = 0;
      if (1 == 0)
        ;
      int num2 = 1;
      while (true)
      {
        switch (num2)
        {
          case 0:
            goto label_8;
          case 1:
          case 2:
            num2 = 3;
            continue;
          case 3:
            if (index >= num1)
            {
              num2 = 0;
              continue;
            }
            RGBQUAD rgbquad;
            A_0.Read<RGBQUAD>(out rgbquad);
            table[index] = GlCm.BMP_RGBA(rgbquad.rgbRed, rgbquad.rgbGreen, rgbquad.rgbBlue, rgbquad.rgbReserved);
            ++index;
            num2 = 2;
            continue;
          default:
            goto label_2;
        }
      }
label_8:
      A_1.SetColorTable(table, num1);
    }

    private void b(BitmapFile.BITMAPHEADER A_0)
    {
      int num1 = 13;
      int num2 = 0;
      int num3 = 0;
      while (true)
      {
        switch (num1)
        {
          case 0:
            num3 = Marshal.SizeOf(A_0.bmfh.GetType()) + Marshal.SizeOf(A_0.bmih.GetType());
            num1 = 10;
            continue;
          case 1:
            if ((int) A_0.bmfh.bfReserved2 == 0)
            {
              num1 = 19;
              continue;
            }
            goto label_22;
          case 2:
            if ((long) num2 > (long) A_0.bmih.biSizeImage)
            {
              num1 = 9;
              continue;
            }
            goto case 0;
          case 3:
            if (A_0.bmih.biWidth > 0)
            {
              num1 = 4;
              continue;
            }
            goto label_20;
          case 4:
            num1 = 17;
            continue;
          case 5:
            goto label_20;
          case 6:
            num1 = 1;
            continue;
          case 7:
            if ((int) A_0.bmfh.bfReserved1 == 0)
            {
              num1 = 6;
              continue;
            }
            goto label_22;
          case 8:
            int num4 = this.a(ref A_0.bmih);
            num3 += Marshal.SizeOf(typeof (RGBQUAD)) * num4;
            num1 = 15;
            continue;
          case 9:
            GlCm.ErrMsg(ErrorType.Bmp, Strings.IDS_ERR_ILLEGAL_IMAGE_SIZE, (object) this.m_sb, (object) A_0.bmih.biSizeImage, (object) num2);
            num1 = 0;
            continue;
          case 10:
            if ((int) A_0.bmih.biBitCount <= 8)
            {
              num1 = 8;
              continue;
            }
            goto label_32;
          case 11:
            num1 = (long) A_0.bmih.biSize >= (long) Marshal.SizeOf(A_0.bmih.GetType()) ? 3 : 14;
            continue;
          case 12:
            num1 = 11;
            continue;
          case 14:
            goto label_22;
          case 15:
            goto label_29;
          case 16:
            num1 = 7;
            continue;
          case 17:
            if (A_0.bmih.biHeight != 0)
            {
              num2 = this.b(ref A_0.bmih);
              num1 = 2;
              continue;
            }
            if (1 == 0)
              ;
            num1 = 5;
            continue;
          case 18:
            if ((long) A_0.bmfh.bfOffBits >= (long) (Marshal.SizeOf(A_0.bmfh.GetType()) + Marshal.SizeOf(A_0.bmih.GetType())))
            {
              num1 = 12;
              continue;
            }
            goto label_22;
          case 19:
            num1 = 18;
            continue;
          default:
            if ((int) A_0.bmfh.bfType == 19778)
            {
              num1 = 16;
              continue;
            }
            goto label_22;
        }
      }
label_29:
      return;
label_32:
      return;
label_20:
      throw GlCm.ErrMsg(ErrorType.Bmp, Strings.IDS_ERR_ILLEGAL_IMAGE_SIZE, (object) this.m_sb, (object) A_0.bmih.biWidth, (object) A_0.bmih.biHeight);
label_22:
      throw GlCm.ErrMsg(ErrorType.Bmp, Strings.IDS_ERR_INVALID_BMP_FILE, (object) this.m_sb);
    }

    private void a(BitmapFile.BITMAPHEADER A_0)
    {
      int num = 5;
      while (true)
      {
        switch (num)
        {
          case 0:
            if ((int) A_0.bmih.biCompression == 0)
            {
              num = 1;
              continue;
            }
            goto label_12;
          case 1:
            num = 2;
            continue;
          case 2:
            if ((int) A_0.bmih.biPlanes != 1)
            {
              num = 12;
              continue;
            }
            goto label_25;
          case 3:
            if ((int) A_0.bmih.biBitCount != 24)
            {
              num = 8;
              continue;
            }
            break;
          case 4:
            num = 3;
            continue;
          case 6:
            if ((int) A_0.bmih.biBitCount != 4)
            {
              num = 13;
              continue;
            }
            break;
          case 7:
            if ((int) A_0.bmih.biBitCount != 32)
            {
              num = 11;
              continue;
            }
            break;
          case 8:
            num = 7;
            continue;
          case 9:
            num = 6;
            continue;
          case 10:
            if ((int) A_0.bmih.biBitCount != 8)
            {
              num = 4;
              continue;
            }
            break;
          case 11:
            goto label_7;
          case 12:
            goto label_12;
          case 13:
            num = 10;
            continue;
          default:
            if ((int) A_0.bmih.biBitCount != 1)
            {
              num = 9;
              continue;
            }
            break;
        }
        num = 0;
      }
label_7:
      if (1 == 0)
        ;
      throw GlCm.ErrMsg(ErrorType.Bmp, Strings.IDS_ERR_BMP_UNSUPPORTED_BPP, (object) this.m_sb, (object) A_0.bmih.biBitCount);
label_12:
      throw GlCm.ErrMsg(ErrorType.Bmp, Strings.IDS_ERR_UNSUPPORTED_BMP, (object) this.m_sb);
label_25:;
    }

    private class BITMAPHEADER
    {
      public BITMAPFILEHEADER bmfh;
      public BITMAPINFOHEADER bmih;
    }
  }
}
