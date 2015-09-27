// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.ImageBase
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Win32;
using System;

namespace NintendoWare.Font
{
  public abstract class ImageBase : IEquatable<ImageBase>
  {
    public const int AlphaTransparent = 0;
    public const int AlphaMax = 255;
    public const int AlphaOpacity = 255;
    public static readonly IntColor RgbWhite;
    public static readonly IntColor RgbBlack;
    public static readonly IntColor RgbaTransparent;
    public static readonly IntColor RgbaOpacity;
    private int a;
    private int b;
    private int c;
    private bool d;
    private bool e;
    private ImageBase.Pixel[,] f;

    public int Bpp
    {
      get
      {
        return this.c;
      }
    }

    public int Width
    {
      get
      {
        return this.a;
      }
    }

    public int Height
    {
      get
      {
        return this.b;
      }
    }

    public abstract bool IsIndexed { get; }

    public bool IsValid
    {
      get
      {
        int num = 0;
        while (true)
        {
          switch (num)
          {
            case 1:
              num = 7;
              continue;
            case 2:
              if (1 == 0)
                ;
              num = 6;
              continue;
            case 3:
              num = 4;
              continue;
            case 4:
              if (this.b >= 0)
              {
                num = 1;
                continue;
              }
              goto label_15;
            case 5:
              goto label_14;
            case 6:
              if (this.a >= 0)
              {
                num = 3;
                continue;
              }
              goto label_15;
            case 7:
              if (this.c > 0)
              {
                num = 5;
                continue;
              }
              goto label_15;
            default:
              if (this.d)
              {
                num = 2;
                continue;
              }
              goto label_15;
          }
        }
label_14:
        return this.c <= 32;
label_15:
        return false;
      }
    }

    public bool IsEnableAlpha
    {
      get
      {
        return this.e;
      }
    }

    public int AlphaBpp
    {
      get
      {
        return 8;
      }
    }

    public int ColorBpp
    {
      get
      {
        return this.Bpp;
      }
    }

    static ImageBase()
    {
      if (1 == 0)
        ;
      ImageBase.RgbWhite = GlCm.BMP_RGB(byte.MaxValue, byte.MaxValue, byte.MaxValue);
      ImageBase.RgbBlack = GlCm.BMP_RGB((byte) 0, (byte) 0, (byte) 0);
      ImageBase.RgbaTransparent = GlCm.BMP_RGBA(byte.MaxValue, byte.MaxValue, byte.MaxValue, (byte) 0);
      ImageBase.RgbaOpacity = GlCm.BMP_RGBA((byte) 0, (byte) 0, (byte) 0, byte.MaxValue);
    }

    public ImageBase()
    {
      this.a = -1;
      this.b = -1;
      this.c = 0;
      this.d = false;
      this.e = false;
    }

    public ImageBase(ImageBase right)
    {
      this.a = right.a;
      this.b = right.b;
      this.c = right.c;
      this.d = right.d;
      this.e = right.e;
      int length = right.a * right.b;
      this.f = new ImageBase.Pixel[right.b, right.a];
      Array.Copy((Array) right.f, (Array) this.f, length);
    }

    public abstract ImageBase NewSameType();

    public abstract uint GetRGB(int x, int y);

    public ImageBase.Pixel GetPixel(int x, int y)
    {
      return this.f[y, x];
    }

    public void EnableAlpha()
    {
      this.e = true;
    }

    public virtual void Create(int width, int height, int bpp)
    {
      if (1 == 0)
        ;
      this.a = width;
      this.b = height;
      this.c = bpp;
      this.d = true;
      this.e = false;
      this.f = new ImageBase.Pixel[height, width];
    }

    public virtual void Clear(uint color, byte alpha)
    {
label_2:
      ImageBase.Pixel pixel = new ImageBase.Pixel();
      pixel.Color = color;
      pixel.Alpha = alpha;
      int index1 = 0;
      int num = 2;
      int index2 = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
          case 7:
            num = 5;
            continue;
          case 1:
            if (index1 < this.Height)
            {
              index2 = 0;
              num = 0;
              continue;
            }
            num = 3;
            continue;
          case 2:
          case 6:
            num = 1;
            continue;
          case 3:
            goto label_11;
          case 4:
            ++index1;
            num = 6;
            continue;
          case 5:
            if (index2 >= this.Width)
            {
              num = 4;
              continue;
            }
            this.f[index1, index2] = pixel;
            ++index2;
            num = 7;
            continue;
          default:
            goto label_2;
        }
      }
label_11:
      if (1 != 0)
        ;
    }

    public void Paste(byte[] buf)
    {
      this.Paste(buf, 0);
    }

    public void Paste(byte[] buf, int align)
    {
      if (1 == 0)
        ;
      this.Paste(buf, 0, 0, this.Width, this.Height, this.Bpp, align);
    }

    public void Paste(byte[] buf, int x, int y, int width, int height, int bpp, int align)
    {
      int num1 = 10;
      int index1 = 0;
      int num2 = 0;
      BitReader bitReader = null;
      int index2 = 0;
      int num3 = 0;
      int num4 = 0;
      int bits1 = 0;
      while (true)
      {
        switch (num1)
        {
          case 0:
            bitReader.Skip(bits1);
            ++index2;
            num1 = 2;
            continue;
          case 1:
          case 8:
            num1 = 7;
            continue;
          case 2:
          case 6:
            num1 = 4;
            continue;
          case 3:
            if (1 == 0)
              ;
            bpp = this.c;
            num1 = 5;
            continue;
          case 4:
            if (index2 >= num4)
            {
              num1 = 9;
              continue;
            }
            index1 = num3;
            num1 = 1;
            continue;
          case 5:
            num3 = x;
            num2 = x + width;
            int num5 = y;
            num4 = y + height;
            bits1 = ImageBase.CalcAlignSkipBits(width, bpp, align);
            bitReader = new BitReader(buf);
            index2 = num5;
            num1 = 6;
            continue;
          case 7:
            if (index1 >= num2)
            {
              num1 = 0;
              continue;
            }
            uint bits2 = bitReader.Read(bpp);
            this.f[index2, index1] = ImageBase.Pixel.FromUInt32(ImageBase.ReverseBytes(bits2, bpp));
            ++index1;
            num1 = 8;
            continue;
          case 9:
            goto label_16;
          default:
            if (bpp == 0)
            {
              num1 = 3;
              continue;
            }
            goto case 5;
        }
      }
label_16:;
    }

    public void Paste(ImageBase image, int x, int y)
    {
      if (1 == 0)
        ;
      this.Paste(image, 0, 0, x, y, image.Width, image.Height);
    }

    public void Paste(ImageBase image, int sx, int sy, int dx, int dy, int width, int height)
    {
      int num1 = 8;
      int num2 = 0;
      int num3 = 0;
      while (true)
      {
        switch (num1)
        {
          case 0:
            ++num3;
            num1 = 9;
            continue;
          case 1:
          case 9:
            num1 = 2;
            continue;
          case 2:
            if (num3 >= height)
            {
              num1 = 3;
              continue;
            }
            num2 = 0;
            num1 = 6;
            continue;
          case 3:
            goto label_16;
          case 4:
            if (num2 >= width)
            {
              if (1 == 0)
                ;
              num1 = 0;
              continue;
            }
            this.f[dy + num3, dx + num2] = image.f[sy + num3, sx + num2];
            ++num2;
            num1 = 5;
            continue;
          case 5:
          case 6:
            num1 = 4;
            continue;
          case 7:
            this.EnableAlpha();
            num1 = 10;
            continue;
          case 10:
            num3 = 0;
            num1 = 1;
            continue;
          default:
            if (image.IsEnableAlpha)
            {
              num1 = 7;
              continue;
            }
            goto case 10;
        }
      }
label_16:;
    }

    public virtual void SetAlpha(int x, int y, byte alpha)
    {
      this.f[y, x].Alpha = alpha;
    }

    public virtual void SetColor(int x, int y, uint color)
    {
      this.f[y, x].Color = color;
    }

    public virtual void SetColorAlpha(int x, int y, uint c, byte a)
    {
      if (1 == 0)
        ;
      this.f[y, x] = new ImageBase.Pixel()
      {
        Alpha = a,
        Color = c
      };
    }

    public virtual void SetPixel(int x, int y, ImageBase.Pixel p)
    {
      this.f[y, x] = p;
    }

    public virtual void DrawRect(int x, int y, int w, int h, uint color, byte alpha)
    {
label_2:
      int num1 = x;
      int num2 = x + w;
      int num3 = y;
      int num4 = y + h;
      int y1 = num3;
      int num5 = 4;
      int x1 = 0;
      while (true)
      {
        switch (num5)
        {
          case 0:
          case 4:
            num5 = 2;
            continue;
          case 1:
            goto label_13;
          case 2:
            if (y1 < num4)
            {
              x1 = num1;
              num5 = 7;
              continue;
            }
            num5 = 1;
            continue;
          case 3:
          case 7:
            num5 = 6;
            continue;
          case 5:
            if (1 == 0)
              ;
            ++y1;
            num5 = 0;
            continue;
          case 6:
            if (x1 >= num2)
            {
              num5 = 5;
              continue;
            }
            this.SetColorAlpha(x1, y1, color, alpha);
            ++x1;
            num5 = 3;
            continue;
          default:
            goto label_2;
        }
      }
label_13:;
    }

    public virtual void Extract(byte[] buf, int x, int y, int width, int height, int bpp, int align)
    {
label_2:
      int num1 = y;
      int num2 = y + height;
      int num3 = x;
      int num4 = x + width;
      int bits = ImageBase.CalcAlignSkipBits(width, bpp, align);
      BitWriter bitWriter = new BitWriter(buf);
      int index1 = num1;
      int num5 = 4;
      int index2 = 0;
      while (true)
      {
        switch (num5)
        {
          case 0:
            goto label_11;
          case 1:
            if (index2 >= num4)
            {
              num5 = 3;
              continue;
            }
            ImageBase.Pixel pixel = this.f[index1, index2];
            bitWriter.Write(bpp, ImageBase.ReverseBytes(pixel.IntColor, bpp));
            ++index2;
            num5 = 6;
            continue;
          case 2:
          case 4:
            num5 = 7;
            continue;
          case 3:
            bitWriter.Skip(bits);
            ++index1;
            num5 = 2;
            continue;
          case 5:
          case 6:
            num5 = 1;
            continue;
          case 7:
            if (index1 < num2)
            {
              index2 = num3;
              num5 = 5;
              continue;
            }
            num5 = 0;
            continue;
          default:
            goto label_2;
        }
      }
label_11:
      if (1 != 0)
        ;
    }

    public virtual void Extract(byte[] buf, int align)
    {
      if (1 == 0)
        ;
      this.Extract(buf, 0, 0, this.Width, this.Height, this.Bpp, align);
    }

    public virtual void Extract(ImageBase image, int x, int y, int width, int height)
    {
label_2:
      image.Create(width, height, this.c);
      int num = 1;
      int index1 = 0;
      int index2 = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (index2 >= height)
            {
              num = 4;
              continue;
            }
            index1 = 0;
            num = 2;
            continue;
          case 1:
            if (this.IsEnableAlpha)
            {
              num = 10;
              continue;
            }
            goto case 8;
          case 2:
          case 9:
            num = 7;
            continue;
          case 3:
          case 5:
            num = 0;
            continue;
          case 4:
            goto label_17;
          case 6:
            ++index2;
            num = 5;
            continue;
          case 7:
            if (index1 >= width)
            {
              if (1 == 0)
                ;
              num = 6;
              continue;
            }
            image.f[index2, index1] = this.f[index2 + y, index1 + x];
            ++index1;
            num = 9;
            continue;
          case 8:
            index2 = 0;
            num = 3;
            continue;
          case 10:
            image.EnableAlpha();
            num = 8;
            continue;
          default:
            goto label_2;
        }
      }
label_17:;
    }

    public virtual byte GetAlpha(int x, int y)
    {
      return this.f[y, x].Alpha;
    }

    public virtual uint GetColor(int x, int y)
    {
      return this.f[y, x].Color;
    }

    public bool Equals(ImageBase right)
    {
      int num = 14;
      int y = 0;
      int x = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_3;
          case 1:
            goto label_26;
          case 2:
            if ((int) this.GetAlpha(x, y) != (int) right.GetAlpha(x, y))
            {
              num = 3;
              continue;
            }
            break;
          case 3:
            goto label_24;
          case 4:
            goto label_12;
          case 5:
            goto label_20;
          case 6:
            num = this.c == right.c ? 13 : 12;
            continue;
          case 7:
            num = (int) this.GetColor(x, y) == (int) right.GetColor(x, y) ? 8 : 0;
            continue;
          case 8:
            if (this.IsEnableAlpha)
            {
              num = 19;
              continue;
            }
            break;
          case 9:
            if (this.IsEnableAlpha == right.IsEnableAlpha)
            {
              y = 0;
              num = 11;
              continue;
            }
            num = 4;
            continue;
          case 10:
            num = this.e == right.e ? 9 : 1;
            continue;
          case 11:
          case 27:
            num = 25;
            continue;
          case 12:
            goto label_21;
          case 13:
            num = this.d == right.d ? 10 : 23;
            continue;
          case 15:
            num = this.a == right.a ? 18 : 20;
            continue;
          case 16:
          case 17:
            num = 22;
            continue;
          case 18:
            num = this.b == right.b ? 6 : 26;
            continue;
          case 19:
            num = 2;
            continue;
          case 20:
            goto label_7;
          case 21:
            if (1 == 0)
              ;
            ++y;
            num = 27;
            continue;
          case 22:
            num = x < this.a ? 7 : 21;
            continue;
          case 23:
            goto label_19;
          case 24:
            goto label_35;
          case 25:
            if (y >= this.b)
            {
              num = 24;
              continue;
            }
            x = 0;
            num = 16;
            continue;
          case 26:
            goto label_5;
          default:
            num = right != null ? 15 : 5;
            continue;
        }
        ++x;
        num = 17;
      }
label_3:
      return false;
label_5:
      return false;
label_7:
      return false;
label_12:
      return false;
label_19:
      return false;
label_20:
      return false;
label_21:
      return false;
label_24:
      return false;
label_26:
      return false;
label_35:
      return true;
    }

    public virtual void ScanOpacityRect(ref RECT rect)
    {
label_2:
      rect.left = this.a;
      rect.right = 0;
      rect.top = this.b;
      rect.bottom = 0;
      int y = 0;
      int num1 = 23;
      int num2 = 0;
      int x1 = 0;
      int x2 = 0;
      int num3 = 0;
      while (true)
      {
        switch (num1)
        {
          case 0:
            if (num3 > rect.right)
            {
              num1 = 25;
              continue;
            }
            goto case 26;
          case 1:
            if (y >= this.b)
            {
              num1 = 27;
              continue;
            }
            num2 = this.a;
            num3 = this.a;
            x1 = 0;
            num1 = 14;
            continue;
          case 2:
            goto label_44;
          case 3:
            num2 = x1;
            num1 = 32;
            continue;
          case 4:
            num1 = x2 >= num2 ? 28 : 31;
            continue;
          case 5:
            num1 = x1 < this.a ? 20 : 29;
            continue;
          case 6:
            if (num2 < num3)
            {
              num1 = 24;
              continue;
            }
            goto case 22;
          case 7:
          case 31:
            num1 = 6;
            continue;
          case 8:
          case 34:
            num1 = 4;
            continue;
          case 9:
            num1 = 0;
            continue;
          case 10:
          case 23:
            num1 = 1;
            continue;
          case 11:
            rect.left = 0;
            rect.right = 0;
            rect.top = 0;
            rect.bottom = 0;
            num1 = 2;
            continue;
          case 12:
            if (rect.left <= rect.right)
            {
              num1 = 16;
              continue;
            }
            goto case 11;
          case 13:
            rect.bottom = y + 1;
            num1 = 22;
            continue;
          case 14:
          case 21:
            num1 = 5;
            continue;
          case 15:
            if (num2 < rect.left)
            {
              num1 = 17;
              continue;
            }
            goto case 9;
          case 16:
            num1 = 19;
            continue;
          case 17:
            rect.left = num2;
            num1 = 9;
            continue;
          case 18:
            rect.top = y;
            num1 = 13;
            continue;
          case 19:
            if (1 == 0)
              ;
            if (rect.top > rect.bottom)
            {
              num1 = 11;
              continue;
            }
            goto label_46;
          case 20:
            if ((int) this.GetAlpha(x1, y) == 0)
            {
              ++x1;
              num1 = 21;
              continue;
            }
            num1 = 3;
            continue;
          case 22:
            ++y;
            num1 = 10;
            continue;
          case 24:
            num1 = 15;
            continue;
          case 25:
            rect.right = num3;
            num1 = 26;
            continue;
          case 26:
            num1 = 30;
            continue;
          case 27:
            num1 = 12;
            continue;
          case 28:
            if ((int) this.GetAlpha(x2, y) == 0)
            {
              --x2;
              num1 = 34;
              continue;
            }
            num1 = 33;
            continue;
          case 29:
          case 32:
            x2 = this.a - 1;
            num1 = 8;
            continue;
          case 30:
            if (y < rect.top)
            {
              num1 = 18;
              continue;
            }
            goto case 13;
          case 33:
            num3 = x2 + 1;
            num1 = 7;
            continue;
          default:
            goto label_2;
        }
      }
label_44:
      return;
label_46:;
    }

    public virtual void ScanNonNullRect(ref RECT rect, IntColor nullColor)
    {
label_2:
      rect.left = this.a;
      rect.right = 0;
      rect.top = this.b;
      rect.bottom = 0;
      int index1 = 0;
      int num1 = 12;
      int num2 = 0;
      int index2 = 0;
      int index3 = 0;
      int num3 = 0;
      while (true)
      {
        switch (num1)
        {
          case 0:
            num1 = 31;
            continue;
          case 1:
          case 21:
            num1 = 14;
            continue;
          case 2:
          case 22:
            index3 = this.a - 1;
            num1 = 18;
            continue;
          case 3:
            rect.left = 0;
            rect.right = 0;
            rect.top = 0;
            rect.bottom = 0;
            num1 = 20;
            continue;
          case 4:
            if (index1 >= this.b)
            {
              num1 = 0;
              continue;
            }
            num2 = this.a;
            num3 = this.a;
            index2 = 0;
            num1 = 34;
            continue;
          case 5:
          case 18:
            num1 = 30;
            continue;
          case 6:
            rect.left = num2;
            num1 = 26;
            continue;
          case 7:
            ++index1;
            num1 = 33;
            continue;
          case 8:
            if (num2 < rect.left)
            {
              num1 = 6;
              continue;
            }
            goto case 26;
          case 9:
            num2 = index2;
            num1 = 22;
            continue;
          case 10:
            if (index1 < rect.top)
            {
              num1 = 15;
              continue;
            }
            goto case 27;
          case 11:
            num1 = 8;
            continue;
          case 12:
          case 33:
            num1 = 4;
            continue;
          case 13:
            num3 = index3 + 1;
            num1 = 1;
            continue;
          case 14:
            if (num2 < num3)
            {
              num1 = 11;
              continue;
            }
            goto case 7;
          case 15:
            rect.top = index1;
            num1 = 27;
            continue;
          case 16:
            rect.right = num3;
            num1 = 25;
            continue;
          case 17:
            if ((int) this.f[index1, index2].IntColor == (int) (uint) nullColor)
            {
              ++index2;
              num1 = 28;
              continue;
            }
            num1 = 9;
            continue;
          case 19:
            if ((int) this.f[index1, index3].IntColor == (int) (uint) nullColor)
            {
              --index3;
              num1 = 5;
              continue;
            }
            num1 = 13;
            continue;
          case 20:
            goto label_44;
          case 23:
            num1 = 29;
            continue;
          case 24:
            num1 = index2 < this.a ? 17 : 2;
            continue;
          case 25:
            num1 = 10;
            continue;
          case 26:
            num1 = 32;
            continue;
          case 27:
            rect.bottom = index1 + 1;
            num1 = 7;
            continue;
          case 28:
          case 34:
            num1 = 24;
            continue;
          case 29:
            if (rect.top > rect.bottom)
            {
              num1 = 3;
              continue;
            }
            goto label_46;
          case 30:
            num1 = index3 >= num2 ? 19 : 21;
            continue;
          case 31:
            if (rect.left <= rect.right)
            {
              if (1 == 0)
                ;
              num1 = 23;
              continue;
            }
            goto case 3;
          case 32:
            if (num3 > rect.right)
            {
              num1 = 16;
              continue;
            }
            goto case 25;
          default:
            goto label_2;
        }
      }
label_44:
      return;
label_46:;
    }

    public override bool Equals(object obj)
    {
      if (1 == 0)
        ;
      int num = 0;
      ImageBase right = null;
      while (true)
      {
        switch (num)
        {
          case 1:
            goto label_9;
          case 2:
            if (right != null)
            {
              num = 3;
              continue;
            }
            goto label_10;
          case 3:
            goto label_5;
          default:
            if (obj == null)
            {
              num = 1;
              continue;
            }
            right = obj as ImageBase;
            num = 2;
            continue;
        }
      }
label_5:
      return this.Equals(right);
label_9:
      return false;
label_10:
      return false;
    }

    public override int GetHashCode()
    {
label_2:
      int num1 = this.a ^ this.b ^ this.c ^ this.d.GetHashCode() ^ this.e.GetHashCode();
      int y = 0;
      int num2 = 4;
      int x = 0;
      while (true)
      {
        switch (num2)
        {
          case 0:
          case 8:
            num2 = 3;
            continue;
          case 1:
            goto label_17;
          case 2:
            if (y >= this.b)
            {
              num2 = 1;
              continue;
            }
            x = 0;
            num2 = 8;
            continue;
          case 3:
            if (x >= this.a)
            {
              num2 = 5;
              continue;
            }
            num1 ^= this.GetColor(x, y).GetHashCode();
            num2 = 9;
            continue;
          case 4:
          case 7:
            num2 = 2;
            continue;
          case 5:
            ++y;
            if (1 == 0)
              ;
            num2 = 7;
            continue;
          case 6:
            num1 ^= this.GetAlpha(x, y).GetHashCode();
            num2 = 10;
            continue;
          case 9:
            if (this.IsEnableAlpha)
            {
              num2 = 6;
              continue;
            }
            goto case 10;
          case 10:
            ++x;
            num2 = 0;
            continue;
          default:
            goto label_2;
        }
      }
label_17:
      return num1;
    }

    protected static int CalcAlignSkipBits(int width, int bpp, int align)
    {
      if (align == 0)
      {
        if (1 == 0)
          ;
        return 0;
      }
      int num1 = align * 8;
      int num2 = width * bpp % num1;
      return (num1 - num2) % num1;
    }

    protected static bool IsValidBpp(int bpp)
    {
      int num = 3;
      while (true)
      {
        switch (num)
        {
          case 0:
            num = 4;
            continue;
          case 1:
            goto label_4;
          case 2:
            num = 7;
            continue;
          case 4:
            if (bpp != 2)
            {
              num = 1;
              continue;
            }
            goto label_11;
          case 5:
            num = 6;
            continue;
          case 6:
            if (bpp != 1)
            {
              num = 0;
              continue;
            }
            goto label_11;
          case 7:
            if (bpp % 8 != 0)
            {
              num = 5;
              continue;
            }
            goto label_11;
          default:
            if (bpp > 0)
            {
              num = 2;
              continue;
            }
            goto label_15;
        }
      }
label_4:
      return bpp == 4;
label_11:
      return true;
label_15:
      if (1 == 0)
        ;
      return false;
    }

    protected static uint ReverseBytes(uint bits, int bitNum)
    {
label_2:
      if (1 == 0)
        ;
      uint num1 = bits & (uint) byte.MaxValue;
      int num2 = 0;
      while (true)
      {
        switch (num2)
        {
          case 0:
            if (bitNum <= 8)
            {
              num2 = 3;
              continue;
            }
            num1 = (uint) ((int) num1 << 8 | (int) (bits >> 8) & (int) byte.MaxValue);
            num2 = 4;
            continue;
          case 1:
            goto label_11;
          case 2:
            goto label_9;
          case 3:
            goto label_10;
          case 4:
            if (bitNum > 16)
            {
              num1 = (uint) ((int) num1 << 8 | (int) (bits >> 16) & (int) byte.MaxValue);
              num2 = 5;
              continue;
            }
            num2 = 2;
            continue;
          case 5:
            if (bitNum <= 24)
            {
              num2 = 1;
              continue;
            }
            goto label_15;
          default:
            goto label_2;
        }
      }
label_9:
      return num1;
label_10:
      return num1;
label_11:
      return num1;
label_15:
      return (uint) ((int) num1 << 8 | (int) (bits >> 24) & (int) byte.MaxValue);
    }

    public struct Pixel
    {
      private byte a;
      private byte b;
      private byte c;
      private byte d;

      public byte B
      {
        get
        {
          return this.a;
        }
        set
        {
          this.a = value;
        }
      }

      public byte G
      {
        get
        {
          return this.b;
        }
        set
        {
          this.b = value;
        }
      }

      public byte R
      {
        get
        {
          return this.c;
        }
        set
        {
          this.c = value;
        }
      }

      public byte A
      {
        get
        {
          return this.d;
        }
        set
        {
          this.d = value;
        }
      }

      public uint Color
      {
        get
        {
          if (1 == 0)
            ;
          return (uint) ((int) this.c << 16 | (int) this.b << 8) | (uint) this.a;
        }
        set
        {
          if (1 == 0)
            ;
          this.a = (byte) value;
          this.b = (byte) (value >> 8);
          this.c = (byte) (value >> 16);
        }
      }

      public byte Alpha
      {
        get
        {
          return this.d;
        }
        set
        {
          this.d = value;
        }
      }

      public uint IntColor
      {
        get
        {
          return (uint) this.d << 24 | this.Color;
        }
        set
        {
          this.Color = value;
          this.d = (byte) (value >> 24);
        }
      }

      public static ImageBase.Pixel FromUInt32(uint value)
      {
        return new ImageBase.Pixel()
        {
          IntColor = value
        };
      }
    }
  }
}
