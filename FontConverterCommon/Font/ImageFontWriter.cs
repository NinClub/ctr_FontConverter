// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.ImageFontWriter
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;
using System.IO;

namespace NintendoWare.Font
{
  public class ImageFontWriter : FontWriter
  {
    private readonly string[] m_sa = new string[3]
    {
      null,
      "bmp",
      "tga"
    };
    private readonly string m_sb;
    private readonly string m_sc;
    private readonly ImageFileFormat d;
    private readonly bool e;
    private readonly int f;
    private readonly int g;
    private readonly int h;
    private readonly int i;
    private readonly uint j;
    private readonly uint k;
    private readonly uint l;
    private readonly uint m;
    private readonly uint n;
    private int o;
    private int p;
    private int q;
    private int r;
    private int s;
    private int t;
    private int u;
    private int v;
    private int w;
    private int x;

    public ImageFontWriter(string file, string order, ImageFileFormat format, bool isDrawGrid, int cellWidth, int cellHeight, int marginLeft, int marginTop, int marginRight, int marginBottom, uint colorGrid, uint colorMargin, uint colorWidthBar, uint colorNullCell, uint colorBackground)
    {
      this.m_sb = file;
      this.m_sc = order;
      this.d = format;
      this.e = isDrawGrid;
      this.f = marginLeft;
      this.g = marginRight;
      this.h = marginTop;
      this.i = marginBottom;
      this.s = cellWidth;
      this.t = cellHeight;
      this.j = colorGrid;
      this.k = colorMargin;
      this.l = colorWidthBar;
      this.m = colorNullCell;
      this.n = colorBackground;
    }

    public override void WriteFontData(FontData fontData, GlyphOrder order)
    {
label_2:
      ImageFileFormat imageFileFormat1 = this.d;
      int num = 5;
      ImageFileFormat imageFileFormat2 = default(ImageFileFormat);
      int index = 0;
      string b = "";
      string a = "";
      while (true)
      {
        switch (num)
        {
          case 0:
          case 6:
            num = 11;
            continue;
          case 1:
            if (imageFileFormat1 == ImageFileFormat.Ext)
            {
              num = 2;
              continue;
            }
            break;
          case 2:
            goto label_15;
          case 3:
            imageFileFormat1 = (ImageFileFormat) index;
            num = 15;
            continue;
          case 4:
            b = Path.GetExtension(this.m_sb);
            num = 12;
            continue;
          case 5:
            if (imageFileFormat1 == ImageFileFormat.Ext)
            {
              num = 4;
              continue;
            }
            break;
          case 7:
            switch (imageFileFormat2)
            {
              case ImageFileFormat.Bmp:
                goto label_13;
              case ImageFileFormat.Tga:
                goto label_16;
              default:
                num = 9;
                continue;
            }
          case 8:
            goto label_29;
          case 9:
            num = 8;
            continue;
          case 10:
          case 15:
            num = 1;
            continue;
          case 11:
            if (1 == 0)
              ;
            if (index >= this.m_sa.Length)
            {
              num = 10;
              continue;
            }
            a = this.m_sa[index];
            num = 14;
            continue;
          case 12:
            if (b != string.Empty)
            {
              num = 16;
              continue;
            }
            goto case 13;
          case 13:
            index = 1;
            num = 0;
            continue;
          case 14:
            if (!string.Equals(a, b, StringComparison.InvariantCultureIgnoreCase))
            {
              ++index;
              num = 6;
              continue;
            }
            num = 3;
            continue;
          case 16:
            b = b.Substring(1);
            num = 13;
            continue;
          default:
            goto label_2;
        }
        imageFileFormat2 = imageFileFormat1;
        num = 7;
      }
label_13:
      ProgressControl.GetInstance().SetStatusString(Strings.IDS_STATUS_WRITE_BMP);
      ProgressControl.GetInstance().ResetProgressBarPos();
      ImageBase image1 = this.c(fontData, order);
      ProgressControl.GetInstance().SetStatusString(Strings.IDS_STATUS_WRITE_BMP_FILE);
      new BitmapFile(this.m_sb).Save(image1);
      return;
label_15:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_UNKNOWN_IMAGE_EXT);
label_16:
      ProgressControl.GetInstance().SetStatusString(Strings.IDS_STATUS_WRITE_TGA);
      ProgressControl.GetInstance().ResetProgressBarPos();
      ImageBase image2 = this.c(fontData, order);
      ProgressControl.GetInstance().SetStatusString(Strings.IDS_STATUS_WRITE_TGA_FILE);
      new TgaFile(this.m_sb).Save(image2);
      return;
label_29:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_UNKNOWN_IMAGE_FORMAT_INT);
    }

    public override void GetGlyphOrder(GlyphOrder order)
    {
      order.Load(this.m_sc);
    }

    public override void ValidateInput()
    {
label_2:
      FontIO.ValidateOutputPath(this.m_sb);
      FontIO.ValidateOrderFile(this.m_sc);
      if (1 == 0)
        ;
      int num = 2;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (this.t == 0)
            {
              num = 3;
              continue;
            }
            goto label_8;
          case 1:
            goto label_9;
          case 2:
            num = this.s != 0 ? 0 : 1;
            continue;
          case 3:
            goto label_5;
          default:
            goto label_2;
        }
      }
label_5:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_UNDERMIN_CELLHEIGHT, (object) this.t);
label_8:
      return;
label_9:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_UNDERMIN_CELLWIDTH, (object) this.s);
    }

    private ImageBase c(FontData A_0, GlyphOrder A_1)
    {
label_2:
      this.b(A_0, A_1);
      ImageBase A_0_1 = this.a(A_0, A_1);
      this.a(A_0_1, A_0, A_1);
      int num = 1;
      FontIO.ArrangeInfo A_1_1 = null;
      while (true)
      {
        switch (num)
        {
          case 0:
            A_1_1 = new FontIO.ArrangeInfo();
            A_1_1.BaselinePos = A_0.BaselinePos.Value;
            num = 2;
            continue;
          case 1:
            if (this.e)
            {
              num = 3;
              continue;
            }
            goto case 0;
          case 2:
            A_1_1.Width = A_0.IsWidthExplicit() ? A_0.Width.Value : -1;
            num = 5;
            continue;
          case 3:
            this.a(A_0_1, this.u, this.v);
            num = 0;
            continue;
          case 4:
            goto label_10;
          case 5:
            A_1_1.Ascent = A_0.IsHeightExplicit() ? A_0.Ascent.Value : -1;
            if (1 == 0)
              ;
            num = 4;
            continue;
          default:
            goto label_2;
        }
      }
label_10:
      A_1_1.Descent = A_0.IsHeightExplicit() ? A_0.Descent.Value : -1;
      this.a(A_0_1, A_1_1, this.e);
      return A_0_1;
    }

    private void b(FontData A_0, GlyphOrder A_1)
    {
label_2:
      this.q = Math.Max(A_0.CellWidth.Value, A_0.MaxCharWidth.Value);
      this.r = Math.Max(A_0.CellHeight.Value, A_0.BaselinePos.Value);
      int num1 = 30;
      int? width = null;
      int num2 = 0;
      int num3 = 0;
      int? ascent = null;
      int? descent = null;
      while (true)
      {
        switch (num1)
        {
          case 0:
            num1 = 1;
            continue;
          case 1:
            if (this.r > this.t)
            {
              int num4 = this.t - this.r;
              int num5 = this.r - A_0.BaselinePos.Value;
              this.p = num4 - num4 * num5 / this.r;
              num1 = 20;
              continue;
            }
            num1 = 5;
            continue;
          case 2:
            num2 = this.p + A_0.BaselinePos.Value;
            num3 = this.t - num2;
            ascent = A_0.Ascent;
            num1 = 29;
            continue;
          case 3:
          case 12:
          case 17:
            num1 = 9;
            continue;
          case 4:
          case 14:
          case 20:
          case 21:
            num1 = 22;
            continue;
          case 5:
            this.p = (this.t - this.r) / 2;
            num1 = 14;
            continue;
          case 6:
            if (1 == 0)
              ;
            this.t += A_0.Descent.Value - num3;
            num1 = 19;
            continue;
          case 7:
            this.s = this.f + this.q + this.g;
            this.o = this.f;
            num1 = 12;
            continue;
          case 8:
            num1 = 10;
            continue;
          case 9:
            num1 = this.t >= 0 ? 25 : 28;
            continue;
          case 10:
            if (A_0.IsHeightExplicit())
            {
              num1 = 2;
              continue;
            }
            goto label_40;
          case 11:
            if (this.f < 0)
            {
              num1 = 16;
              continue;
            }
            this.o = this.f;
            num1 = 17;
            continue;
          case 13:
            descent = A_0.Descent;
            num1 = 23;
            continue;
          case 15:
            if (width.Value > this.s)
            {
              num1 = 26;
              continue;
            }
            goto case 8;
          case 16:
            num1 = 18;
            continue;
          case 18:
            this.o = (this.s - this.q + (this.s > this.q ? 1 : -1)) / 2;
            num1 = 3;
            continue;
          case 19:
            goto label_40;
          case 22:
            if (A_0.IsWidthExplicit())
            {
              num1 = 27;
              continue;
            }
            goto case 8;
          case 23:
            if (descent.Value > num3)
            {
              num1 = 6;
              continue;
            }
            goto label_40;
          case 24:
            int num6 = A_0.Ascent.Value - num2;
            this.p += num6;
            this.t += num6;
            num1 = 13;
            continue;
          case 25:
            if (this.h < 0)
            {
              num1 = 0;
              continue;
            }
            this.p = this.h;
            num1 = 4;
            continue;
          case 26:
            int num7 = A_0.Width.Value - this.s;
            this.o += num7 / 2;
            this.s += num7;
            num1 = 8;
            continue;
          case 27:
            width = A_0.Width;
            num1 = 15;
            continue;
          case 28:
            this.t = this.h + this.r + this.i;
            this.p = this.h;
            num1 = 21;
            continue;
          case 29:
            if (ascent.Value > num2)
            {
              num1 = 24;
              continue;
            }
            goto case 13;
          case 30:
            num1 = this.s >= 0 ? 11 : 7;
            continue;
          default:
            goto label_2;
        }
      }
label_40:
      this.u = this.s + 4;
      this.v = this.t + 6;
      this.w = A_1.GetHNum();
      this.x = A_1.GetVNum();
    }

    private ImageBase a(FontData A_0, GlyphOrder A_1)
    {
      if (1 == 0)
        ;
      int width = A_1.GetHNum() * this.u;
      int height = A_1.GetVNum() * this.v;
      RgbImage rgbImage = new RgbImage();
      rgbImage.Create(width, height, 32);
      rgbImage.EnableAlpha();
      rgbImage.Clear(this.n, (byte) 0);
      return (ImageBase) rgbImage;
    }

    private void a(ImageBase A_0, int A_1, int A_2)
    {
label_2:
      int width = A_0.Width;
      int height = A_0.Height;
      byte alpha = (byte) 0;
      int x1 = 1;
      int num = 6;
      int x2 = 0;
      int y1 = 0;
      int y2 = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
            y2 = 1;
            num = 9;
            continue;
          case 1:
          case 10:
            num = 14;
            continue;
          case 2:
            if (y2 >= height)
            {
              num = 13;
              continue;
            }
            int y3 = y2 + A_2 - 5;
            int y4 = y2 + A_2 - 3;
            A_0.DrawRect(0, y2, width, 1, this.k, alpha);
            A_0.DrawRect(0, y3, width, 1, this.k, alpha);
            A_0.DrawRect(0, y4, width, 1, this.k, alpha);
            y2 += A_2;
            num = 12;
            continue;
          case 3:
          case 6:
            num = 8;
            continue;
          case 4:
            goto label_23;
          case 5:
          case 15:
            num = 7;
            continue;
          case 7:
            if (x2 >= width)
            {
              num = 11;
              continue;
            }
            int x3 = x2 + A_1 - 1;
            A_0.DrawRect(x2, 0, 1, height, this.j, alpha);
            A_0.DrawRect(x3, 0, 1, height, this.j, alpha);
            x2 += A_1;
            num = 15;
            continue;
          case 8:
            if (1 == 0)
              ;
            if (x1 >= width)
            {
              num = 0;
              continue;
            }
            int x4 = x1 + A_1 - 3;
            A_0.DrawRect(x1, 0, 1, height, this.k, alpha);
            A_0.DrawRect(x4, 0, 1, height, this.k, alpha);
            x1 += A_1;
            num = 3;
            continue;
          case 9:
          case 12:
            num = 2;
            continue;
          case 11:
            y1 = 0;
            num = 1;
            continue;
          case 13:
            x2 = 0;
            num = 5;
            continue;
          case 14:
            if (y1 < height)
            {
              int y5 = y1 + A_2 - 1;
              A_0.DrawRect(0, y1, width, 1, this.j, alpha);
              A_0.DrawRect(0, y5, width, 1, this.j, alpha);
              y1 += A_2;
              num = 10;
              continue;
            }
            num = 4;
            continue;
          default:
            goto label_2;
        }
      }
label_23:;
    }

    private void a(ImageBase A_0, FontIO.ArrangeInfo A_1, bool A_2)
    {
label_2:
      byte a = (byte) 0;
      int num1 = 2;
      int y1 = 0;
      int x1 = 0;
      uint c = 0;
      int x2 = 0;
      int y2 = 0;
      int num2 = 0;
      while (true)
      {
        switch (num1)
        {
          case 0:
            if (x1 >= 1)
            {
              num1 = 11;
              continue;
            }
            goto label_25;
          case 1:
            if (A_1.Ascent >= 0)
            {
              num1 = 16;
              continue;
            }
            goto label_31;
          case 2:
            num1 = A_2 ? 15 : 5;
            continue;
          case 3:
            goto label_31;
          case 4:
            num1 = 14;
            continue;
          case 5:
            num1 = 17;
            continue;
          case 6:
            A_0.SetColorAlpha(x1, 0, c, a);
            A_0.SetColorAlpha(x2, 0, c, a);
            num1 = 18;
            continue;
          case 7:
            A_0.SetColorAlpha(0, y1, c, a);
            A_0.SetColorAlpha(0, y2, c, a);
            num1 = 3;
            continue;
          case 8:
            num1 = 0;
            continue;
          case 9:
            if (A_1.Width > 0)
            {
              num1 = 8;
              continue;
            }
            goto label_25;
          case 10:
            if (x2 <= 2 + this.s)
            {
              num1 = 6;
              continue;
            }
            goto label_25;
          case 11:
            num1 = 10;
            continue;
          case 12:
            num1 = 19;
            continue;
          case 13:
            if (y1 >= 1)
            {
              num1 = 12;
              continue;
            }
            goto label_31;
          case 14:
            if (y2 <= 2 + this.t)
            {
              num1 = 7;
              continue;
            }
            goto label_31;
          case 15:
            num2 = (int) this.n;
            break;
          case 16:
            num1 = 13;
            continue;
          case 17:
            num2 = (int) this.j;
            break;
          case 18:
            if (1 == 0)
              goto label_25;
            else
              goto label_25;
          case 19:
            if (A_1.Descent >= 0)
            {
              num1 = 4;
              continue;
            }
            goto label_31;
          default:
            goto label_2;
        }
        c = (uint) num2;
        x1 = 2 + (this.s - A_1.Width) / 2 - 1;
        x2 = x1 + A_1.Width + 1;
        int y3 = 2 + this.p + A_1.BaselinePos;
        y1 = y3 - A_1.Ascent - 1;
        y2 = y3 + A_1.Descent;
        A_0.SetColorAlpha(0, y3, c, a);
        num1 = 9;
        continue;
label_25:
        num1 = 1;
      }
label_31:
      A_0.SetColorAlpha(0, 0, this.n, a);
    }

    private void a(ImageBase A_0, FontData A_1, int A_2, int A_3, Glyph A_4)
    {
label_2:
      int baseline = A_1.BaselinePos.Value;
      int num1 = A_2 * this.u + 2;
      int num2 = A_3 * this.v + 2;
      int num3 = A_4.Width();
      int val2 = A_4.CharFeed();
      int num4 = Math.Max(A_4.Left(), 0);
      int num5 = Math.Max(A_4.Right(), 0);
      int num6 = (this.q - (num4 + num3 + num5)) / 2;
      int num7 = 3;
      int num8 = 0;
      int num9 = 0;
      int num10 = 0;
      int num11 = 0;
      byte alpha = 0;
      while (true)
      {
        switch (num7)
        {
          case 0:
            goto label_10;
          case 1:
            int num12 = Math.Max(0, this.o + num6 - Math.Min(0, A_4.Left()));
            int num13 = 0;
            int w = Math.Min(num8 - num12, val2);
            int h = num9;
            A_0.DrawRect(num10 + num12, num11 + num13, w, h, this.l, alpha);
            num7 = 0;
            continue;
          case 2:
            if (val2 > 0)
            {
              num7 = 1;
              continue;
            }
            goto label_12;
          case 3:
            if (num3 > 0)
            {
              num7 = 4;
              continue;
            }
            goto case 5;
          case 4:
            RgbImage image = new RgbImage();
            A_4.ExtractGlyphImage(image, baseline);
            int num14 = Math.Max(0, this.o + num6 + num4);
            int num15 = Math.Max(0, this.p);
            int width = Math.Min(this.s - num14, image.Width);
            int height = Math.Min(this.t - num15, image.Height);
            int sx = 0;
            int sy = 0;
            A_0.Paste((ImageBase) image, sx, sy, num1 + num14, num2 + num15, width, height);
            num7 = 5;
            continue;
          case 5:
            alpha = (byte) 0;
            num10 = num1;
            num11 = num2 + this.t + 1;
            num8 = this.s;
            num9 = 1;
            if (1 == 0)
              ;
            num7 = 2;
            continue;
          default:
            goto label_2;
        }
      }
label_10:
      return;
label_12:;
    }

    private void a(ImageBase A_0, FontData A_1, int A_2, int A_3)
    {
      if (1 == 0)
        ;
      int x = A_2 * this.u + 2;
      int y = A_3 * this.v + 2;
      A_0.DrawRect(x, y, this.s, this.t, this.m, (byte) 0);
    }

    private void a(ImageBase A_0, FontData A_1, GlyphOrder A_2)
    {
label_2:
      ProgressControl.GetInstance().SetProgressBarMax(this.w * this.x);
      int num1 = 0;
      int num2 = 7;
      int num3 = 0;
      ushort charCode = 0;
      Glyph byCode = null;
      while (true)
      {
        switch (num2)
        {
          case 0:
            if (num1 < this.x)
            {
              num3 = 0;
              num2 = 8;
              continue;
            }
            num2 = 2;
            continue;
          case 1:
            byCode = A_1.GetGlyphList().GetByCode(charCode);
            num2 = 3;
            continue;
          case 2:
            goto label_21;
          case 3:
            if (byCode != null)
            {
              num2 = 6;
              continue;
            }
            goto case 11;
          case 4:
          case 8:
            num2 = 10;
            continue;
          case 5:
            ++num1;
            num2 = 9;
            continue;
          case 6:
            this.a(A_0, A_1, num3, num1, byCode);
            if (1 == 0)
              ;
            num2 = 11;
            continue;
          case 7:
          case 9:
            num2 = 0;
            continue;
          case 10:
            if (num3 >= this.w)
            {
              num2 = 5;
              continue;
            }
            charCode = A_2.GetCharCode(num3, num1);
            num2 = 13;
            continue;
          case 11:
          case 12:
            ProgressControl.GetInstance().StepProgressBar();
            ++num3;
            num2 = 4;
            continue;
          case 13:
            if ((int) charCode == (int) ushort.MaxValue)
            {
              this.a(A_0, A_1, num3, num1);
              num2 = 12;
              continue;
            }
            num2 = 1;
            continue;
          default:
            goto label_2;
        }
      }
label_21:;
    }
  }
}
