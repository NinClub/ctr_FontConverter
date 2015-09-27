// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Letterer
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Win32;
using System;

namespace NintendoWare.Font
{
  public abstract class Letterer : IDisposable
  {
    private const int a = 1;
    private const int b = 1;
    private const int c = 1;
    private const int d = 1;
    private const int e = 1;
    private const int f = 1;
    private const int g = 1;
    private bool h;
    private WidthType i;
    private int j;
    private int k;
    private int l;
    private int m;
    private int n;
    private IntPtr o;
    private IntPtr p;

    protected IntPtr DeviceContext
    {
      get
      {
        return this.o;
      }
      set
      {
        this.o = value;
      }
    }

    protected IntPtr OldFont
    {
      get
      {
        return this.p;
      }
    }

    protected bool IsUnicode
    {
      get
      {
        return this.h;
      }
    }

    protected int Bpp
    {
      get
      {
        return this.j;
      }
    }

    protected int Baseline
    {
      get
      {
        return this.l;
      }
    }

    protected int CellSize
    {
      get
      {
        return this.m;
      }
    }

    public Letterer()
    {
      this.h = false;
      this.j = 0;
      this.o = IntPtr.Zero;
      this.p = IntPtr.Zero;
      this.n = 0;
    }

    public void Dispose()
    {
      this.Dispose(true);
    }

    public abstract void Create(ref LOGFONT logfont);

    public abstract bool LetterChar(Glyph glyph, ushort c);

    public int GetFontHeight()
    {
      return this.n;
    }

    public int GetAscent()
    {
      return this.l;
    }

    public void SetOption(bool isUnicode, int bpp, bool hasAlpha, WidthType widthType, int fixedWidth)
    {
      int num = 1;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (8 < bpp)
            {
              if (1 == 0)
                ;
              num = 2;
              continue;
            }
            num = 5;
            continue;
          case 2:
            goto label_8;
          case 3:
            num = 6;
            continue;
          case 4:
            goto label_17;
          case 5:
            if (widthType >= WidthType.GlyphOnly)
            {
              num = 3;
              continue;
            }
            goto label_15;
          case 6:
            if (WidthType.NUM <= widthType)
            {
              num = 7;
              continue;
            }
            this.h = isUnicode;
            num = 4;
            continue;
          case 7:
            goto label_15;
          case 8:
            num = 0;
            continue;
          default:
            if (bpp >= 1)
            {
              num = 8;
              continue;
            }
            goto label_8;
        }
      }
label_8:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_OUTOFRANGE_COLORBPP, (object) bpp);
label_15:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_INVALID_WIDTH_TYPE, (object) widthType);
label_17:
      this.j = bpp == 1 ? 1 : (bpp <= 4 ? 4 : 8);
      this.i = widthType;
      this.k = fixedWidth;
    }

    protected bool GetCharABCWidthsU(IntPtr hDC, uint first, uint last, ABC[] pabc)
    {
      if (this.h)
        return Gdi.GetCharABCWidthsW(hDC, first, last, pabc);
      if (1 == 0)
        ;
      return Gdi.GetCharABCWidthsA(hDC, first, last, pabc);
    }

    protected bool GetCharWidth32U(IntPtr hDC, uint first, uint last, int[] pw)
    {
      if (!this.h)
        return Gdi.GetCharWidth32A(hDC, first, last, pw);
      if (1 == 0)
        ;
      return Gdi.GetCharWidth32W(hDC, first, last, pw);
    }

    protected abstract void Dispose(bool disposing);

    protected void CalcurateParameter()
    {
      TEXTMETRIC lptm = new TEXTMETRIC();
      if (!Gdi.GetTextMetrics(this.o, lptm))
        throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_FAIL_GETTEXTMETRICS);
      if (1 == 0)
        ;
      this.m = Math.Max(lptm.tmMaxCharWidth, lptm.tmHeight);
      this.l = lptm.tmAscent - lptm.tmInternalLeading;
      this.n = lptm.tmHeight - lptm.tmInternalLeading;
    }

    protected void SetupFont(ref LOGFONT logFont)
    {
label_2:
      IntPtr fontIndirect = Gdi.CreateFontIndirect(ref logFont);
      int num1 = 2;
      while (true)
      {
        switch (num1)
        {
          case 0:
            goto label_10;
          case 1:
            if (1 == 0)
              ;
            if (this.p == IntPtr.Zero)
            {
              num1 = 3;
              continue;
            }
            goto label_11;
          case 2:
            if (fontIndirect == IntPtr.Zero)
            {
              num1 = 0;
              continue;
            }
            this.p = Gdi.SelectFont(this.o, fontIndirect);
            num1 = 1;
            continue;
          case 3:
            goto label_5;
          default:
            goto label_2;
        }
      }
label_5:
      Gdi.DeleteFont(fontIndirect);
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_FAIL_SELECTOBJECT_NEWFONT);
label_10:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_FAIL_CREATEFONT);
label_11:
      int num2 = (int) Gdi.SetTextAlign(this.o, 0U);
      Gdi.SetMapMode(this.o, 1);
    }

    protected void CleanupFont()
    {
      int num = 0;
      IntPtr hfont = default(IntPtr);
      while (true)
      {
        switch (num)
        {
          case 1:
            if (!(hfont == IntPtr.Zero))
            {
              Gdi.DeleteFont(hfont);
              num = 3;
              continue;
            }
            num = 4;
            continue;
          case 2:
            hfont = Gdi.SelectFont(this.o, this.p);
            num = 1;
            continue;
          case 3:
            goto label_6;
          case 4:
            goto label_7;
          default:
            if (this.p != IntPtr.Zero)
            {
              if (1 == 0)
                ;
              num = 2;
              continue;
            }
            goto label_11;
        }
      }
label_6:
      return;
label_11:
      return;
label_7:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_FAIL_SELECTOBJECT_OLDFONT);
    }

    protected bool IsGlyphExists(ushort c)
    {
label_2:
      ushort[] gi = new ushort[2];
      int num = 6;
      byte[] str = null;
      int c1 = 0;
      uint glyphIndicesA = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
            str[0] = (byte) c;
            c1 = 1;
            num = 4;
            continue;
          case 1:
          case 4:
            if (1 == 0)
              ;
            glyphIndicesA = Gdi.GetGlyphIndicesA(this.o, str, c1, gi, 1U);
            num = 2;
            continue;
          case 2:
            if ((int) glyphIndicesA == 1)
            {
              num = 7;
              continue;
            }
            goto label_16;
          case 3:
            goto label_10;
          case 5:
            if ((int) c < 256)
            {
              num = 0;
              continue;
            }
            str[0] = (byte) ((uint) c >> 8);
            str[1] = (byte) ((uint) c & (uint) byte.MaxValue);
            c1 = 2;
            num = 1;
            continue;
          case 6:
            if (this.h)
            {
              num = 3;
              continue;
            }
            str = new byte[2];
            num = 5;
            continue;
          case 7:
            goto label_11;
          default:
            goto label_2;
        }
      }
label_10:
      Gdi.GetGlyphIndicesW(this.o, new ushort[1]
      {
        c
      }, 1, gi, 1U);
      return (int) gi[0] != (int) ushort.MaxValue;
label_11:
      return (int) gi[0] != (int) ushort.MaxValue;
label_16:
      return false;
    }

    protected void MakeAlpha(IndexImage image, int bpp)
    {
label_2:
      int num1 = (1 << bpp) - 1;
      image.EnableAlpha();
      int y = 0;
      int num2 = 3;
      int x = 0;
      while (true)
      {
        switch (num2)
        {
          case 0:
          case 3:
            num2 = 4;
            continue;
          case 1:
          case 5:
            num2 = 6;
            continue;
          case 2:
            ++y;
            num2 = 0;
            continue;
          case 4:
            if (y < image.Height)
            {
              x = 0;
              if (1 == 0)
                ;
              num2 = 1;
              continue;
            }
            num2 = 7;
            continue;
          case 6:
            if (x >= image.Width)
            {
              num2 = 2;
              continue;
            }
            byte alpha = (byte) ((ulong) (image.GetColor(x, y) * (uint) byte.MaxValue) / (ulong) num1);
            image.SetAlpha(x, y, alpha);
            ++x;
            num2 = 5;
            continue;
          case 7:
            goto label_13;
          default:
            goto label_2;
        }
      }
label_13:;
    }

    protected void SetGlyph(Glyph glyph, IndexImage image, Letterer.GlyphInfo info)
    {
label_2:
      RECT rect = new RECT();
      IndexImage indexImage = new IndexImage();
      RgbImage image1 = new RgbImage();
      image.ScanOpacityRect(ref rect);
      int width = rect.right - rect.left;
      int height = rect.bottom - rect.top;
      int baseline = info.GlyphAscent - rect.top;
      image.Extract((ImageBase) indexImage, rect.left, rect.top, width, height);
      indexImage.SetColorTable(image.GetColorTable(), image.GetColorTableEntryNum());
      WidthType widthType = this.i;
      int num = 22;
      int y = 0;
      int l = 0;
      int r = 0;
      int x = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
          case 6:
            if (1 == 0)
              ;
            num = 13;
            continue;
          case 1:
            l = info.GlyphLeft + rect.left;
            r = info.CharWidth - width - l;
            num = 11;
            continue;
          case 2:
            goto label_13;
          case 3:
            if (y >= indexImage.Height)
            {
              num = 10;
              continue;
            }
            x = 0;
            num = 6;
            continue;
          case 4:
          case 5:
            num = 3;
            continue;
          case 7:
          case 9:
          case 11:
          case 12:
          case 14:
          case 18:
          case 23:
            image1.Create(indexImage.Width, indexImage.Height, 32);
            image1.Clear((uint) ImageBase.RgbBlack, (byte) 0);
            image1.EnableAlpha();
            y = 0;
            num = 4;
            continue;
          case 8:
            if (width <= 0)
            {
              l = info.CharWidth;
              r = 0;
              num = 18;
              continue;
            }
            num = 15;
            continue;
          case 10:
            goto label_34;
          case 13:
            if (x >= indexImage.Width)
            {
              num = 17;
              continue;
            }
            uint rgb = indexImage.GetRGB(x, y);
            byte alpha = indexImage.GetAlpha(x, y);
            image1.SetColorAlpha(x, y, rgb, alpha);
            ++x;
            num = 0;
            continue;
          case 15:
            l = 0;
            r = 0;
            num = 7;
            continue;
          case 16:
            if (width > 0)
            {
              num = 1;
              continue;
            }
            l = info.CharWidth;
            r = 0;
            num = 12;
            continue;
          case 17:
            ++y;
            num = 5;
            continue;
          case 19:
            if (width > 0)
            {
              num = 21;
              continue;
            }
            l = this.k;
            r = 0;
            num = 9;
            continue;
          case 20:
            num = 2;
            continue;
          case 21:
            l = (this.k - width) / 2;
            r = this.k - l - width;
            num = 14;
            continue;
          case 22:
            switch (widthType)
            {
              case WidthType.GlyphOnly:
                l = 0;
                r = 0;
                num = 23;
                continue;
              case WidthType.GlyphOnlyKeepSpace:
                num = 8;
                continue;
              case WidthType.IncludeMargin:
                num = 16;
                continue;
              case WidthType.Fixed:
                num = 19;
                continue;
              default:
                num = 20;
                continue;
            }
          default:
            goto label_2;
        }
      }
label_13:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_INVALID_WIDTH_TYPE);
label_34:
      IntColor nullColor = (IntColor) 0U;
      glyph.SetGlyphImage(image1, l, r, baseline, nullColor);
    }

    protected class GlyphInfo
    {
      public int BmpWidth { get; set; }

      public int BmpHeight { get; set; }

      public int GlyphLeft { get; set; }

      public int CharWidth { get; set; }

      public int GlyphAscent { get; set; }

      public byte Black { get; set; }

      public byte White { get; set; }
    }
  }
}
