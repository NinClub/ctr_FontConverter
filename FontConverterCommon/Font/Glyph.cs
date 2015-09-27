// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Glyph
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Win32;
using System;

namespace NintendoWare.Font
{
  public class Glyph : IEquatable<Glyph>
  {
    public const int WidthLineSplitError = 1;
    private const int m_na = 0;
    private readonly RgbImage b;
    private int c;
    private int d;
    private int e;
    private ushort f;
    private ushort g;

    public Glyph()
    {
      this.c = 0;
      this.d = 0;
      this.e = 0;
      this.b = new RgbImage();
    }

    public Glyph(Glyph orig)
    {
      this.c = orig.c;
      this.d = orig.d;
      this.e = orig.e;
      this.b = new RgbImage(orig.b);
    }

    public void SetIndex(ushort index)
    {
      this.f = index;
    }

    public void SetCode(ushort code)
    {
      this.g = code;
    }

    public ushort GetIndex()
    {
      return this.f;
    }

    public ushort GetCode()
    {
      return this.g;
    }

    public int GetImageDataLen()
    {
      if (1 == 0)
        ;
      return (this.Width() * this.Height() * this.b.Bpp + 7) / 8;
    }

    public int CharFeed()
    {
      return this.d + this.Width() + this.e;
    }

    public int Width()
    {
      return this.b.Width;
    }

    public int Height()
    {
      return this.b.Height;
    }

    public int Left()
    {
      return this.d;
    }

    public int Right()
    {
      return this.e;
    }

    public int Ascent()
    {
      return this.c;
    }

    public int Descent()
    {
      return this.Height() - this.c;
    }

    public void SetGlyphImageWithWidthBar(RgbImage image, RgbImage bar, int baseline, IntColor nullColor)
    {
      if (1 == 0)
        ;
      RECT rect = new RECT();
      image.ScanNonNullRect(ref rect, nullColor);
      this.a(bar, ref rect, nullColor);
      this.a(image, ref rect, baseline);
    }

    public void SetGlyphImage(RgbImage image, int l, int r, int baseline, IntColor nullColor)
    {
      if (1 == 0)
        ;
      RECT rect = new RECT();
      image.ScanNonNullRect(ref rect, nullColor);
      this.d = l;
      this.e = r;
      this.a(image, ref rect, baseline);
    }

    public void SetGlyphImageInclude(RgbImage image, int l, int r, int baseline)
    {
      if (1 == 0)
        ;
      RECT rect = new RECT();
      image.ScanOpacityRect(ref rect);
      this.d = rect.left + l;
      this.e = image.Width - rect.right + r;
      this.a(image, ref rect, baseline);
    }

    public void SetGlyphImage(RgbImage image, int baseline)
    {
      if (1 == 0)
        ;
      RECT rect = new RECT();
      image.ScanOpacityRect(ref rect);
      this.d = rect.left;
      this.e = image.Width - rect.right;
      this.a(image, ref rect, baseline);
    }

    public void ExtractGlyphImage(RgbImage image, int baseline)
    {
      if (1 == 0)
        ;
      int y = Math.Max(baseline - this.Ascent(), 0);
      int height = y + this.Height();
      image.Create(this.Width(), height, this.b.Bpp);
      image.EnableAlpha();
      image.Clear((uint) ImageBase.RgbWhite, (byte) 0);
      image.Paste((ImageBase) this.b, 0, y);
    }

    public bool Equals(Glyph r)
    {
      int num = 6;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_13;
          case 1:
            num = this.e == r.e ? 2 : 7;
            continue;
          case 2:
            if (!this.b.Equals((ImageBase) r.b))
            {
              num = 3;
              continue;
            }
            goto label_14;
          case 3:
            goto label_11;
          case 4:
            goto label_4;
          case 5:
            num = this.d == r.d ? 1 : 4;
            continue;
          case 7:
            goto label_3;
          case 8:
            num = this.c == r.c ? 5 : 0;
            continue;
          case 9:
            goto label_9;
          default:
            num = r != null ? 8 : 9;
            continue;
        }
      }
label_3:
      return false;
label_4:
      if (1 == 0)
        ;
      return false;
label_9:
      return false;
label_11:
      return false;
label_13:
      return false;
label_14:
      return true;
    }

    public override bool Equals(object obj)
    {
      int num = 0;
      Glyph r;
      while (true)
      {
        switch (num)
        {
          case 1:
            if (r != null)
            {
              num = 2;
              continue;
            }
            goto label_10;
          case 2:
            goto label_4;
          case 3:
            goto label_9;
          default:
            if (obj == null)
            {
              num = 3;
              continue;
            }
            r = obj as Glyph;
            if (1 == 0)
              ;
            num = 1;
            continue;
        }
      }
label_4:
      return this.Equals(r);
label_9:
      return false;
label_10:
      return false;
    }

    public override int GetHashCode()
    {
      if (1 == 0)
        ;
      return this.c ^ this.d ^ this.e ^ this.b.GetHashCode();
    }

    private void a(RgbImage A_0, ref RECT A_1, IntColor A_2)
    {
label_2:
      int width = A_0.Width;
      int num1 = -1;
      int num2 = width;
      int num3 = 0;
      int num4 = 0;
      while (true)
      {
        switch (num4)
        {
          case 0:
            num4 = 11;
            continue;
          case 1:
            num2 = num3 - 1;
            num4 = 14;
            continue;
          case 2:
          case 6:
            num4 = 3;
            continue;
          case 3:
            num4 = num3 < width ? 16 : 19;
            continue;
          case 4:
            if ((int) A_0.GetRGB(num3++, 0) != (int) (uint) A_2)
            {
              num4 = 8;
              continue;
            }
            goto case 13;
          case 5:
            if (A_1.right - A_1.left > 0)
            {
              num4 = 12;
              continue;
            }
            goto label_15;
          case 7:
            num4 = 9;
            continue;
          case 8:
            goto label_14;
          case 9:
            if (num1 >= 0)
            {
              num4 = 20;
              continue;
            }
            goto label_31;
          case 10:
            num1 = num3 - 1;
            num4 = 2;
            continue;
          case 11:
            if (num3 >= width)
            {
              num4 = 15;
              continue;
            }
            if (1 == 0)
              ;
            num4 = 17;
            continue;
          case 12:
            goto label_19;
          case 13:
          case 14:
            num4 = 18;
            continue;
          case 15:
            num4 = 6;
            continue;
          case 16:
            if ((int) A_0.GetRGB(num3++, 0) == (int) (uint) A_2)
            {
              num4 = 1;
              continue;
            }
            goto case 2;
          case 17:
            if ((int) A_0.GetRGB(num3++, 0) != (int) (uint) A_2)
            {
              num4 = 10;
              continue;
            }
            goto case 0;
          case 18:
            num4 = num3 < width ? 4 : 7;
            continue;
          case 19:
            num4 = 13;
            continue;
          case 20:
            num4 = 5;
            continue;
          default:
            goto label_2;
        }
      }
label_14:
      throw new GlyphException(1);
label_15:
      this.d = num2 - num1;
      this.e = 0;
      return;
label_19:
      this.d = A_1.left - num1;
      this.e = num2 - A_1.right;
      return;
label_31:
      this.d = 0;
      this.e = -(A_1.right - A_1.left);
    }

    private void a(RgbImage A_0, ref RECT A_1, int A_2)
    {
      if (1 == 0)
        ;
      int width = A_1.right - A_1.left;
      int height = A_1.bottom - A_1.top;
      A_0.Extract((ImageBase) this.b, A_1.left, A_1.top, width, height);
      this.c = A_2 - A_1.top;
    }
  }
}
