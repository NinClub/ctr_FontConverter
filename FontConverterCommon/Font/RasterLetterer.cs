// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.RasterLetterer
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Win32;
using System;
using System.Runtime.InteropServices;

namespace NintendoWare.Font
{
  public class RasterLetterer : Letterer
  {
    private const uint a = 0U;
    private const uint b = 16777215U;
    private const uint c = 16711680U;
    private IntPtr d;
    private IntPtr e;
    private IntPtr f;

    public RasterLetterer()
    {
      this.d = IntPtr.Zero;
      this.e = IntPtr.Zero;
      this.f = IntPtr.Zero;
    }

    public override bool LetterChar(Glyph glyph, ushort c)
    {
      int num1 = 3;
      bool flag1;
      while (true)
      {
        switch (num1)
        {
          case 0:
            goto label_6;
          case 1:
            goto label_5;
          case 2:
            if (!flag1)
            {
              num1 = 1;
              continue;
            }
            goto label_11;
          default:
            if (!this.IsGlyphExists(c))
            {
              if (1 == 0)
                ;
              num1 = 0;
              continue;
            }
            RECT lprc = new RECT(0, 0, this.CellSize, this.CellSize);
            IntPtr brushIndirect = Gdi.CreateBrushIndirect(new LOGBRUSH(BS.SOLID, Gdi.RGB(byte.MaxValue, (byte) 0, (byte) 0), UIntPtr.Zero));
            Gdi.FillRect(this.DeviceContext, ref lprc, brushIndirect);
            Gdi.DeleteObject(brushIndirect);
            flag1 = RasterLetterer.a(this.DeviceContext, 0, 0, (uint) c, this.IsUnicode);
            num1 = 2;
            continue;
        }
      }
label_5:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_FAIL_TEXTOUT);
label_6:
      return false;
label_11:
      bool flag2;
      try
      {
label_13:
        int A_1 = this.CellSize * GlCm.ROUND_UP(this.CellSize, 4);
        byte[] numArray1 = new byte[A_1];
        byte[] numArray2 = new byte[A_1];
        IndexImage image = new IndexImage();
        Letterer.GlyphInfo glyphInfo = new Letterer.GlyphInfo();
        this.a(numArray1, A_1, glyphInfo);
        this.a(numArray2, numArray1, this.CellSize, this.CellSize, glyphInfo);
        int num2 = 1;
        while (true)
        {
          switch (num2)
          {
            case 0:
              flag2 = false;
              num2 = 3;
              continue;
            case 1:
              if (glyphInfo.BmpWidth <= 0)
              {
                num2 = 0;
                continue;
              }
              glyphInfo.GlyphLeft = 0;
              glyphInfo.CharWidth = glyphInfo.BmpWidth;
              glyphInfo.GlyphAscent = this.Baseline;
              image.Create(glyphInfo.BmpWidth, glyphInfo.BmpHeight, 8);
              image.Paste(numArray2);
              image.SetGrayScaleTable(this.Bpp);
              this.MakeAlpha(image, this.Bpp);
              this.SetGlyph(glyph, image, glyphInfo);
              num2 = 2;
              continue;
            case 2:
              goto label_7;
            case 3:
              goto label_19;
            default:
              goto label_13;
          }
        }
      }
      catch (GeneralException ex)
      {
        throw ex;
      }
label_7:
      return true;
label_19:
      return flag2;
    }

    public override void Create(ref LOGFONT logfont)
    {
label_2:
      this.d = Gdi.CreateDC("DISPLAY", (string) null, (string) null, (object) null);
      int num = 1;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_13;
          case 1:
            if (this.d == IntPtr.Zero)
            {
              num = 4;
              continue;
            }
            this.DeviceContext = Gdi.CreateCompatibleDC(this.d);
            num = 5;
            continue;
          case 2:
            goto label_5;
          case 3:
            goto label_19;
          case 4:
            goto label_14;
          case 5:
            if (!(this.DeviceContext == IntPtr.Zero))
            {
              if (1 == 0)
                ;
              this.SetupFont(ref logfont);
              this.CalcurateParameter();
              this.f = Gdi.CreateCompatibleBitmap(this.d, this.CellSize, this.CellSize);
              num = 6;
              continue;
            }
            num = 3;
            continue;
          case 6:
            if (this.f == IntPtr.Zero)
            {
              num = 2;
              continue;
            }
            this.e = Gdi.SelectBitmap(this.DeviceContext, this.f);
            num = 7;
            continue;
          case 7:
            if (this.e == IntPtr.Zero)
            {
              num = 0;
              continue;
            }
            goto label_18;
          default:
            goto label_2;
        }
      }
label_5:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_FAIL_CREATECOMPATIBLEBITMAP);
label_13:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_FAIL_SELECTOBJECT_NEWBMP);
label_14:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_FAIL_CREATEDC);
label_18:
      return;
label_19:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_FAIL_CREATECOMPATIBLEDC);
    }

    protected override void Dispose(bool disposing)
    {
label_2:
      this.CleanupFont();
      int num1 = 11;
      while (true)
      {
        IntPtr num2;
        switch (num1)
        {
          case 0:
            goto label_9;
          case 1:
            if (this.d != IntPtr.Zero)
            {
              num1 = 2;
              continue;
            }
            goto label_23;
          case 2:
            Gdi.DeleteDC(this.d);
            num1 = 12;
            continue;
          case 3:
            if (num2 == IntPtr.Zero)
            {
              num1 = 0;
              continue;
            }
            break;
          case 4:
            num1 = 1;
            continue;
          case 5:
            if (this.DeviceContext != IntPtr.Zero)
            {
              num1 = 6;
              continue;
            }
            goto case 4;
          case 6:
            Gdi.DeleteDC(this.DeviceContext);
            num1 = 4;
            continue;
          case 7:
            num1 = 5;
            continue;
          case 8:
            Gdi.DeleteBitmap(this.f);
            if (1 == 0)
              ;
            num1 = 7;
            continue;
          case 9:
            num2 = Gdi.SelectBitmap(this.DeviceContext, this.e);
            num1 = 3;
            continue;
          case 10:
            if (this.f != IntPtr.Zero)
            {
              num1 = 8;
              continue;
            }
            goto case 7;
          case 11:
            if (this.e != IntPtr.Zero)
            {
              num1 = 9;
              continue;
            }
            break;
          case 12:
            goto label_19;
          default:
            goto label_2;
        }
        num1 = 10;
      }
label_19:
      return;
label_9:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_FAIL_SELECTOBJECT_OLDBMP);
label_23:;
    }

    private static bool a(IntPtr A_0, int A_1, int A_2, uint A_3, bool A_4)
    {
      int num = 0;
      byte[] lpString1;
      int c;
      while (true)
      {
        switch (num)
        {
          case 1:
          case 3:
            goto label_11;
          case 2:
            goto label_8;
          case 4:
            lpString1[0] = (byte) (A_3 >> 8);
            lpString1[1] = (byte) (A_3 & (uint) byte.MaxValue);
            c = 2;
            num = 1;
            continue;
          case 5:
            if (A_3 > (uint) byte.MaxValue)
            {
              num = 4;
              continue;
            }
            if (1 == 0)
              ;
            lpString1[0] = (byte) (A_3 & (uint) byte.MaxValue);
            c = 1;
            num = 3;
            continue;
          default:
            if (A_4)
            {
              num = 2;
              continue;
            }
            lpString1 = new byte[2];
            num = 5;
            continue;
        }
      }
label_8:
      ushort[] lpString2 = new ushort[1]
      {
        (ushort) A_3
      };
      return Gdi.TextOutW(A_0, A_1, A_2, lpString2, 1);
label_11:
      return Gdi.TextOutA(A_0, A_1, A_2, lpString1, c);
    }

    private static uint a(RGBQUAD A_0)
    {
      return (uint) GlCm.BMP_RGB(A_0.rgbRed, A_0.rgbGreen, A_0.rgbBlue);
    }

    private void a(byte[] A_0, int A_1, Letterer.GlyphInfo A_2)
    {
label_2:
      BITMAPINFO256 lpbmi = new BITMAPINFO256();
      lpbmi.bmiHeader.biSize = (uint) Marshal.SizeOf(lpbmi.bmiHeader.GetType());
      lpbmi.bmiHeader.biWidth = this.CellSize;
      lpbmi.bmiHeader.biHeight = this.CellSize;
      lpbmi.bmiHeader.biPlanes = (ushort) 1;
      lpbmi.bmiHeader.biBitCount = (ushort) 8;
      lpbmi.bmiHeader.biCompression = 0U;
      lpbmi.bmiHeader.biSizeImage = (uint) A_1;
      Gdi.SelectBitmap(this.DeviceContext, this.e);
      int diBits = Gdi.GetDIBits(this.DeviceContext, this.f, 0U, (uint) this.CellSize, A_0, lpbmi, DIB.RGB_COLORS);
      Gdi.SelectBitmap(this.DeviceContext, this.f);
      int num1 = 10;
      int index;
      uint num2;
      while (true)
      {
        switch (num1)
        {
          case 0:
          case 3:
          case 7:
            ++index;
            num1 = 8;
            continue;
          case 1:
          case 8:
            num1 = 11;
            continue;
          case 2:
            goto label_21;
          case 4:
            if ((int) num2 == 0)
            {
              A_2.Black = (byte) index;
              num1 = 7;
              continue;
            }
            num1 = 5;
            continue;
          case 5:
            num1 = 12;
            continue;
          case 6:
            num1 = 0;
            continue;
          case 9:
            goto label_9;
          case 10:
            if (diBits != this.CellSize)
            {
              num1 = 9;
              continue;
            }
            A_2.Black = (byte) 0;
            A_2.White = (byte) 0;
            index = 0;
            num1 = 1;
            continue;
          case 11:
            if (index >= 256)
            {
              if (1 == 0)
                ;
              num1 = 2;
              continue;
            }
            num2 = RasterLetterer.a(lpbmi.bmiColors[index]);
            num1 = 4;
            continue;
          case 12:
            if ((int) num2 == 16777215)
            {
              A_2.White = (byte) index;
              num1 = 3;
              continue;
            }
            num1 = 6;
            continue;
          default:
            goto label_2;
        }
      }
label_21:
      return;
label_9:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_FAIL_GETDIBITS);
    }

    private void a(byte[] A_0, byte[] A_1, int A_2, int A_3, Letterer.GlyphInfo A_4)
    {
label_2:
      int num1 = GlCm.ROUND_UP(A_2, 4);
      byte num2 = (byte) 0;
      byte num3 = (byte) ((1 << this.Bpp) - 1);
      int num4 = (A_3 - 1) * num1;
      int index1 = 0;
      A_4.BmpHeight = A_3;
      A_4.BmpWidth = A_2;
      int num5 = 0;
      int num6 = 14;
      int index2;
      int num7;
      while (true)
      {
        switch (num6)
        {
          case 0:
          case 14:
            num6 = 7;
            continue;
          case 1:
          case 12:
            goto label_23;
          case 2:
            A_0[index1] = num2;
            num6 = 13;
            continue;
          case 3:
          case 16:
            if (1 == 0)
              ;
            num4 -= num1;
            ++num5;
            num6 = 0;
            continue;
          case 4:
            num6 = (int) A_1[index2] != (int) A_4.White ? 9 : 2;
            continue;
          case 5:
            num6 = num7 < A_2 ? 19 : 16;
            continue;
          case 6:
            A_0[index1] = num3;
            num6 = 18;
            continue;
          case 7:
            if (num5 >= A_3)
            {
              num6 = 12;
              continue;
            }
            index2 = num4;
            num7 = 0;
            num6 = 10;
            continue;
          case 8:
            A_4.BmpHeight = num5;
            num6 = 17;
            continue;
          case 9:
            if (num7 != 0)
            {
              A_4.BmpWidth = num7;
              num6 = 3;
              continue;
            }
            num6 = 8;
            continue;
          case 10:
          case 15:
            num6 = 5;
            continue;
          case 11:
            A_4.BmpWidth = 0;
            num6 = 1;
            continue;
          case 13:
          case 18:
            ++index1;
            ++index2;
            ++num7;
            num6 = 15;
            continue;
          case 17:
            if (num5 == 0)
            {
              num6 = 11;
              continue;
            }
            goto label_23;
          case 19:
            num6 = (int) A_1[index2] != (int) A_4.Black ? 4 : 6;
            continue;
          default:
            goto label_2;
        }
      }
label_23:
      A_4.White = num2;
      A_4.Black = num3;
    }
  }
}
