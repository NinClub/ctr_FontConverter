// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.ImageFontReader
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Win32;
using System.Collections.Generic;

namespace NintendoWare.Font
{
  public class ImageFontReader : FontReader
  {
    protected static readonly COLORREF DnotTransparentColor = (COLORREF) 4278190080U;
    private readonly string a;
    private readonly string b;
    private readonly GlyphImageFormat c;
    private readonly bool d;
    private int e;
    private int f;
    private int g;
    private int h;
    private int i;
    private int j;

    public ImageFontReader(string file, string order, GlyphImageFormat gif, bool isAntiLinear)
    {
      this.a = file;
      this.b = order;
      this.c = gif;
      this.d = isAntiLinear;
    }

    public override void ReadFontData(FontData fontData, CharFilter filter)
    {
label_2:
      ProgressControl.GetInstance().SetStatusString(Strings.IDS_STATUS_READ_BMP);
      ProgressControl.GetInstance().ResetProgressBarPos();
      fontData.OutputFormat = new GlyphImageFormat?(this.c);
      ImageFileFormat A_1_1 = this.a();
      ImageFileFormat imageFileFormat = A_1_1;
      int num = 11;
      FontIO.ArrangeInfo A_0_1;
      GlyphOrder glyphOrder;
      RgbImage A_0_2;
      IntColor A_5;
      while (true)
      {
        switch (num)
        {
          case 0:
          case 4:
          case 12:
            ImageBase A_1_2 = ImageFontReader.a(this.a, A_1_1);
            glyphOrder = new GlyphOrder();
            A_0_2 = new RgbImage();
            A_0_1 = new FontIO.ArrangeInfo();
            glyphOrder.Load(this.b);
            A_5 = this.a(A_0_2, A_1_2);
            fontData.NullColor = new IntColor?(A_5);
            this.a((ImageBase) A_0_2, glyphOrder);
            ImageFontReader.a((ImageBase) A_0_2, this.e, this.f);
            this.a(A_0_1, (ImageBase) A_0_2);
            num = 6;
            continue;
          case 1:
            num = 3;
            continue;
          case 2:
          case 13:
            num = 10;
            continue;
          case 3:
            if (A_0_1.Descent >= 0)
            {
              num = 9;
              continue;
            }
            break;
          case 5:
            num = 4;
            continue;
          case 6:
            if (A_0_1.Width <= 0)
            {
              if (1 == 0)
                ;
              fontData.Width = new int?(this.i);
              num = 2;
              continue;
            }
            num = 8;
            continue;
          case 7:
          case 14:
            goto label_22;
          case 8:
            fontData.SetWidth(A_0_1.Width);
            num = 13;
            continue;
          case 9:
            fontData.SetHeight(A_0_1.Ascent, A_0_1.Descent);
            num = 14;
            continue;
          case 10:
            if (A_0_1.Ascent >= 0)
            {
              num = 1;
              continue;
            }
            break;
          case 11:
            switch (imageFileFormat)
            {
              case ImageFileFormat.Bmp:
                ProgressControl.GetInstance().SetStatusString(Strings.IDS_STATUS_READ_BMP);
                ProgressControl.GetInstance().ResetProgressBarPos();
                num = 0;
                continue;
              case ImageFileFormat.Tga:
                ProgressControl.GetInstance().SetStatusString(Strings.IDS_STATUS_READ_TGA);
                ProgressControl.GetInstance().ResetProgressBarPos();
                num = 12;
                continue;
              default:
                num = 5;
                continue;
            }
          default:
            goto label_2;
        }
        fontData.Ascent = new int?(A_0_1.BaselinePos);
        fontData.Descent = new int?(this.j - A_0_1.BaselinePos);
        num = 7;
      }
label_22:
      this.a(fontData.GetGlyphList(), (ImageBase) A_0_2, filter, glyphOrder, A_0_1.BaselinePos, A_5);
    }

    public override void ValidateInput()
    {
      int num1 = 9;
      while (true)
      {
        int x;
        int hnum;
        int num2;
        int num3;
        int y;
        ImageBase A_0;
        GlyphOrder glyphOrder;
        int vnum;
        int A_3;
        int A_4;
        ushort charCode;
        bool flag;
        switch (num1)
        {
          case 0:
            if (!flag)
            {
              num1 = 2;
              continue;
            }
            break;
          case 1:
            if ((int) charCode != (int) ushort.MaxValue)
            {
              num1 = 4;
              continue;
            }
            break;
          case 2:
            ProgressControl.Warning(Strings.IDS_WARN_OVER_DRAW_MARGIN, (object) (num2 * x + num2 / 2), (object) (num3 * y + num3 / 2));
            num1 = 6;
            continue;
          case 3:
            ++y;
            num1 = 5;
            continue;
          case 4:
            flag = this.a(A_0, x * num2 + 1, y * num3 + 1, A_3, A_4);
            num1 = 0;
            continue;
          case 5:
          case 12:
            num1 = 10;
            continue;
          case 6:
            if (1 == 0)
              break;
            break;
          case 7:
          case 8:
            num1 = 14;
            continue;
          case 10:
            if (y >= vnum)
            {
              num1 = 11;
              continue;
            }
            x = 0;
            num1 = 7;
            continue;
          case 11:
            goto label_23;
          case 13:
            goto label_11;
          case 14:
            if (x >= hnum)
            {
              num1 = 3;
              continue;
            }
            charCode = glyphOrder.GetCharCode(x, y);
            num1 = 1;
            continue;
          default:
            if (!FontIO.IsFileExists(this.a))
            {
              num1 = 13;
              continue;
            }
            A_0 = ImageFontReader.a(this.a, this.a());
            FontIO.ValidateOrderFile(this.b);
            glyphOrder = new GlyphOrder();
            glyphOrder.Load(this.b);
            int width = A_0.Width;
            int height = A_0.Height;
            hnum = glyphOrder.GetHNum();
            vnum = glyphOrder.GetVNum();
            num2 = width / hnum;
            num3 = height / vnum;
            A_3 = num2 - 2;
            A_4 = num3 - 2;
            ImageFontReader.a(A_0, hnum, vnum);
            y = 0;
            num1 = 12;
            continue;
        }
        ++x;
        num1 = 8;
      }
label_23:
      return;
label_11:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_FILE_NOT_EXISTS, (object) this.a);
    }

    private static int a(int A_0, int A_1, int A_2)
    {
      if (A_1 < A_2)
      {
        int num1 = (1 << A_1) - 1;
        int num2 = (1 << A_2) - 1;
        return A_0 * num2 / num1;
      }
      if (1 == 0)
        ;
      return A_0 >> A_1 - A_2;
    }

    private static bool b(GlyphImageFormat A_0)
    {
      return GlyphImageInfo.GetGlyphImageInfo(A_0).IsToIntencity;
    }

    private static bool a(GlyphImageFormat A_0)
    {
      return GlyphImageInfo.GetGlyphImageInfo(A_0).HasAlpha;
    }

    private static void a(ImageBase A_0, int A_1, int A_2)
    {
label_2:
      int num1 = A_0.Width / A_1;
      int num2 = A_0.Height / A_2;
      int num3 = num1 - 4;
      int num4 = num2 - 6;
      int num5 = 1;
      while (true)
      {
        switch (num5)
        {
          case 0:
            goto label_4;
          case 1:
            num5 = num3 >= 1 ? 3 : 7;
            continue;
          case 2:
            num5 = num1 * A_1 == A_0.Width ? 6 : 0;
            continue;
          case 3:
            num5 = num4 >= 1 ? 2 : 5;
            continue;
          case 4:
            goto label_7;
          case 5:
            goto label_13;
          case 6:
            if (num2 * A_2 != A_0.Height)
            {
              if (1 == 0)
                ;
              num5 = 4;
              continue;
            }
            goto label_12;
          case 7:
            goto label_8;
          default:
            goto label_2;
        }
      }
label_4:
      throw GlCm.ErrMsg(ErrorType.Image, Strings.IDS_ERR_NON_MULTIPLY_WIDTH, (object) A_0.Width, (object) A_1);
label_7:
      throw GlCm.ErrMsg(ErrorType.Image, Strings.IDS_ERR_NON_MULTIPLY_HEIGHT, (object) A_0.Height, (object) A_2);
label_8:
      throw GlCm.ErrMsg(ErrorType.Image, Strings.IDS_ERR_UNDERMIN_IMAGEWIDTH, (object) A_0.Width, (object) (4 * A_1));
label_12:
      return;
label_13:
      throw GlCm.ErrMsg(ErrorType.Image, Strings.IDS_ERR_UNDERMIN_IMAGEHEIGHT, (object) A_0.Height, (object) (6 * A_2));
    }

    private static ImageBase a(string A_0, ImageFileFormat A_1)
    {
label_2:
      ImageFileFormat imageFileFormat = A_1;
      int num = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
            switch (imageFileFormat)
            {
              case ImageFileFormat.Bmp:
                goto label_6;
              case ImageFileFormat.Tga:
                goto label_5;
              default:
                num = 2;
                continue;
            }
          case 1:
            goto label_9;
          case 2:
            num = 1;
            continue;
          default:
            goto label_2;
        }
      }
label_5:
      return new TgaFile(A_0).Load();
label_6:
      if (1 == 0)
        ;
      return new BitmapFile(A_0).Load();
label_9:
      throw GlCm.ErrMsg(ErrorType.Image, Strings.IDS_ERR_FAIL_INPUT_IMAGE_DETECTION);
    }

    private void a(GlyphList A_0, ImageBase A_1, CharFilter A_2, GlyphOrder A_3, int A_4, IntColor A_5)
    {
label_2:
      ProgressControl.GetInstance().SetProgressBarMax(this.e * this.f);
      A_0.Reserve(this.f * this.e);
      int num1 = 0;
      int num2 = 5;
      int num3;
      ushort charCode;
      while (true)
      {
        switch (num2)
        {
          case 0:
            if (!A_2.IsFiltered(charCode))
            {
              num2 = 12;
              continue;
            }
            goto case 8;
          case 1:
            if (1 == 0)
              goto case 8;
            else
              goto case 8;
          case 2:
            num2 = 0;
            continue;
          case 3:
            if (num3 >= this.e)
            {
              num2 = 4;
              continue;
            }
            charCode = A_3.GetCharCode(num3, num1);
            ProgressControl.GetInstance().StepProgressBar();
            num2 = 10;
            continue;
          case 4:
            ++num1;
            num2 = 6;
            continue;
          case 5:
          case 6:
            num2 = 7;
            continue;
          case 7:
            if (num1 < this.f)
            {
              num3 = 0;
              num2 = 13;
              continue;
            }
            num2 = 11;
            continue;
          case 8:
            ++num3;
            num2 = 9;
            continue;
          case 9:
          case 13:
            num2 = 3;
            continue;
          case 10:
            if ((int) charCode == (int) ushort.MaxValue)
            {
              this.a(A_1, num3, num1, A_5);
              num2 = 1;
              continue;
            }
            num2 = 2;
            continue;
          case 11:
            goto label_21;
          case 12:
            this.a(A_0, A_1, num3, num1, charCode, A_4, A_5);
            num2 = 8;
            continue;
          default:
            goto label_2;
        }
      }
label_21:;
    }

    private void a(ImageBase A_0, GlyphOrder A_1)
    {
      if (1 == 0)
        ;
      this.e = A_1.GetHNum();
      this.f = A_1.GetVNum();
      this.g = A_0.Width / this.e;
      this.h = A_0.Height / this.f;
      this.i = this.g - 4;
      this.j = this.h - 6;
    }

    private void a(FontIO.ArrangeInfo A_0, ImageBase A_1)
    {
label_2:
      int num1 = 1;
      int num2 = 2 + this.i + 1;
      uint num3 = 0U;
      uint num4 = 0U;
      List<int> list1 = new List<int>();
      List<int> list2 = new List<int>();
      int x = num1;
      int num5 = 5;
      IntArray intArray1;
      while (true)
      {
        int y;
        uint rgb1;
        uint num6;
        uint rgb2;
        IntArray intArray2;
        int count;
        uint num7;
        IntArray intArray3;
        int num8;
        IntArray intArray4;
        switch (num5)
        {
          case 0:
            list2.Add(x);
            num5 = 61;
            continue;
          case 1:
            if (y < num8)
            {
              rgb1 = A_1.GetRGB(0, y);
              num5 = 28;
              continue;
            }
            num5 = 43;
            continue;
          case 2:
            goto label_79;
          case 3:
          case 7:
          case 11:
            int num9 = 1;
            num8 = 2 + this.j + 1;
            num7 = 0U;
            num6 = 0U;
            intArray3 = new IntArray();
            intArray2 = new IntArray();
            y = num9;
            num5 = 52;
            continue;
          case 4:
            num5 = list2.Count != 2 ? 16 : 26;
            continue;
          case 5:
          case 54:
            num5 = 34;
            continue;
          case 6:
            num4 = rgb2;
            list2.Add(x);
            num5 = 39;
            continue;
          case 8:
            if (list1.Count != 0)
            {
              num5 = 48;
              continue;
            }
            goto case 56;
          case 9:
            num5 = 41;
            continue;
          case 10:
            if (list2.Count > 0)
            {
              num5 = 58;
              continue;
            }
            goto label_67;
          case 12:
            num5 = 4;
            continue;
          case 13:
            num3 = rgb2;
            list1.Add(x);
            num5 = 27;
            continue;
          case 14:
            if (intArray1.Count == 0)
            {
              num5 = 2;
              continue;
            }
            goto label_85;
          case 15:
            num5 = 24;
            continue;
          case 16:
            num5 = list1.Count != 2 ? 8 : 47;
            continue;
          case 17:
            if (intArray2.Count == 0)
            {
              num5 = 31;
              continue;
            }
            goto label_76;
          case 18:
          case 21:
          case 46:
          case 59:
            ++y;
            num5 = 44;
            continue;
          case 19:
            num5 = 20;
            continue;
          case 20:
            num5 = 14;
            continue;
          case 22:
            intArray4 = intArray2;
            goto label_30;
          case 23:
            intArray4 = intArray3;
            goto label_30;
          case 24:
            if ((int) rgb2 == (int) num3)
            {
              if (1 == 0)
                ;
              num5 = 35;
              continue;
            }
            goto label_70;
          case 25:
            if ((int) rgb1 == (int) num7)
            {
              num5 = 40;
              continue;
            }
            break;
          case 26:
            A_0.Width = list2[1] - list2[0] - 1;
            num5 = 3;
            continue;
          case 27:
          case 33:
          case 39:
          case 61:
            ++x;
            num5 = 54;
            continue;
          case 28:
            if (intArray3.Count > 0)
            {
              num5 = 42;
              continue;
            }
            break;
          case 29:
            intArray2.Add(y);
            num5 = 21;
            continue;
          case 30:
            switch (count)
            {
              case 1:
                goto label_59;
              case 2:
                goto label_12;
              case 3:
                goto label_64;
              default:
                num5 = 19;
                continue;
            }
          case 31:
            num6 = rgb1;
            intArray2.Add(y);
            num5 = 18;
            continue;
          case 32:
            num5 = intArray3.Count < intArray2.Count ? 23 : 55;
            continue;
          case 34:
            if (x < num2)
            {
              rgb2 = A_1.GetRGB(x, 0);
              num5 = 36;
              continue;
            }
            num5 = 12;
            continue;
          case 35:
            list1.Add(x);
            num5 = 33;
            continue;
          case 36:
            if (list1.Count > 0)
            {
              num5 = 15;
              continue;
            }
            goto label_70;
          case 37:
            if (intArray2.Count > 0)
            {
              num5 = 9;
              continue;
            }
            goto label_77;
          case 38:
            if (list2.Count == 0)
            {
              num5 = 56;
              continue;
            }
            goto label_37;
          case 40:
            intArray3.Add(y);
            num5 = 59;
            continue;
          case 41:
            if ((int) rgb1 == (int) num6)
            {
              num5 = 29;
              continue;
            }
            goto label_77;
          case 42:
            num5 = 25;
            continue;
          case 43:
            num5 = 57;
            continue;
          case 44:
          case 52:
            num5 = 1;
            continue;
          case 45:
            if ((int) rgb2 == (int) num4)
            {
              num5 = 0;
              continue;
            }
            goto label_67;
          case 47:
            A_0.Width = list1[1] - list1[0] - 1;
            num5 = 7;
            continue;
          case 48:
            num5 = 38;
            continue;
          case 49:
            num5 = list1.Count != 0 ? 50 : 13;
            continue;
          case 50:
            if (list2.Count == 0)
            {
              num5 = 6;
              continue;
            }
            goto label_40;
          case 51:
            num5 = intArray3.Count != 0 ? 17 : 60;
            continue;
          case 53:
            goto label_33;
          case 55:
            num5 = 22;
            continue;
          case 56:
            A_0.Width = -1;
            num5 = 11;
            continue;
          case 57:
            num5 = intArray3.Count != intArray2.Count ? 32 : 53;
            continue;
          case 58:
            num5 = 45;
            continue;
          case 60:
            num7 = rgb1;
            intArray3.Add(y);
            num5 = 46;
            continue;
          default:
            goto label_2;
        }
        num5 = 37;
        continue;
label_30:
        intArray1 = intArray4;
        count = intArray1.Count;
        num5 = 30;
        continue;
label_67:
        num5 = 49;
        continue;
label_70:
        num5 = 10;
        continue;
label_77:
        num5 = 51;
      }
label_12:
      A_0.BaselinePos = intArray1[1] - 2;
      A_0.Ascent = intArray1[1] - intArray1[0] - 1;
      A_0.Descent = 0;
      return;
label_33:
      throw GlCm.ErrMsg(ErrorType.Image, Strings.IDS_ERR_UNSUPPORTED_VERTICAL_INFO);
label_37:
      throw GlCm.ErrMsg(ErrorType.Image, Strings.IDS_ERR_ILLEGAL_HORIZONTAL_INFO);
label_40:
      throw GlCm.ErrMsg(ErrorType.Image, Strings.IDS_ERR_ILLEGAL_HORIZONTAL_INFO);
label_59:
      A_0.BaselinePos = intArray1[0] - 2;
      A_0.Ascent = -1;
      A_0.Descent = -1;
      return;
label_64:
      A_0.BaselinePos = intArray1[1] - 2;
      A_0.Ascent = intArray1[1] - intArray1[0] - 1;
      A_0.Descent = intArray1[2] - intArray1[1];
      return;
label_76:
      throw GlCm.ErrMsg(ErrorType.Image, Strings.IDS_ERR_ILLEGAL_VERTICAL_INFO);
label_79:
      throw GlCm.ErrMsg(ErrorType.Image, Strings.IDS_ERR_NO_BASELINE);
label_85:
      throw GlCm.ErrMsg(ErrorType.Image, Strings.IDS_ERR_ILLEGAL_VERTICAL_INFO);
    }

    private void a(GlyphList A_0, ImageBase A_1, int A_2, int A_3, ushort A_4, int A_5, IntColor A_6)
    {
label_2:
      int num1 = A_2 * this.g + 2;
      int num2 = A_3 * this.h + 2;
      RgbImage image = new RgbImage();
      RgbImage bar = new RgbImage();
      int num3 = 11;
      while (true)
      {
        Glyph glyph;
        switch (num3)
        {
          case 0:
            if (ImageFontReader.a(this.c))
            {
              num3 = 6;
              continue;
            }
            break;
          case 1:
            num3 = 3;
            continue;
          case 2:
            A_0.AddGlyph(glyph, A_4);
            num3 = 13;
            continue;
          case 3:
            if (glyph.Right() != 0)
            {
              num3 = 2;
              continue;
            }
            goto label_26;
          case 4:
          case 9:
            A_1.Extract((ImageBase) bar, num1, num2 + this.j + 1, this.i, 1);
            glyph = new Glyph();
            num3 = 10;
            continue;
          case 5:
            num3 = 12;
            continue;
          case 6:
            image.Create(this.i + 2, this.j + 2, A_1.Bpp);
            image.Clear((uint) A_6, (byte) 0);
            image.Paste(A_1, num1, num2, 1, 1, this.i, this.j);
            this.a((ImageBase) image);
            ++A_5;
            num3 = 9;
            continue;
          case 7:
            num3 = 0;
            continue;
          case 8:
            if (glyph.Left() == 0)
            {
              num3 = 5;
              continue;
            }
            goto case 2;
          case 10:
            try
            {
              glyph.SetGlyphImageWithWidthBar(image, bar, A_5, A_6);
            }
            catch (GlyphException ex)
            {
              if (ex.ErrorCode == 1)
                throw GlCm.ErrMsg(ErrorType.Image, Strings.IDS_ERR_MULTI_WIDTHLINE, (object) (this.g * A_2 + this.g / 2), (object) (this.h * A_3 + this.h / 2));
            }
            num3 = 8;
            continue;
          case 11:
            if (this.d)
            {
              num3 = 7;
              continue;
            }
            break;
          case 12:
            if (glyph.Width() == 0)
            {
              if (1 == 0)
                ;
              num3 = 1;
              continue;
            }
            goto case 2;
          case 13:
            goto label_24;
          default:
            goto label_2;
        }
        A_1.Extract((ImageBase) image, num1, num2, this.i, this.j);
        num3 = 4;
      }
label_24:
      return;
label_26:;
    }

    private void a(ImageBase A_0)
    {
label_2:
      int width1 = A_0.Width;
      int height1 = A_0.Height;
      int width2 = width1 + 2;
      int height2 = height1 + 2;
      RgbImage rgbImage = new RgbImage();
      rgbImage.Create(width2, height2, 24);
      rgbImage.Clear(0U, (byte) 0);
      rgbImage.Paste(A_0, 0, 0, 1, 1, width1, height1);
      int y = 0;
      int num1 = 3;
      int num2;
      ImageBase.Pixel[] pixelArray;
      int index1;
      int num3;
      int num4;
      int num5;
      int x;
      ImageBase.Pixel pixel;
      int index2;
      int num6;
      while (true)
      {
        switch (num1)
        {
          case 0:
            pixelArray = new ImageBase.Pixel[8];
            index2 = 0;
            num5 = 0;
            num1 = 20;
            continue;
          case 1:
            if (num6 != 1)
            {
              num1 = 9;
              continue;
            }
            goto case 22;
          case 2:
            goto label_43;
          case 3:
          case 31:
            num1 = 11;
            continue;
          case 4:
            ++index2;
            num1 = 22;
            continue;
          case 5:
            ++y;
            num1 = 31;
            continue;
          case 6:
            if (num5 >= 3)
            {
              num1 = 7;
              continue;
            }
            num6 = 0;
            num1 = 18;
            continue;
          case 7:
            num1 = 19;
            continue;
          case 8:
            num1 = 1;
            continue;
          case 9:
            pixelArray[index2] = rgbImage.GetPixel(x + num5, y + num6);
            num1 = 21;
            continue;
          case 10:
            pixel.R = (byte) ((num2 + index2 / 2) / index2);
            pixel.G = (byte) ((num3 + index2 / 2) / index2);
            pixel.B = (byte) ((num4 + index2 / 2) / index2);
            num1 = 14;
            continue;
          case 11:
            if (y >= height1)
            {
              num1 = 2;
              continue;
            }
            x = 0;
            num1 = 17;
            continue;
          case 12:
            if (index1 < index2)
            {
              num2 += (int) pixelArray[index1].R;
              num3 += (int) pixelArray[index1].G;
              num4 += (int) pixelArray[index1].B;
              ++index1;
              num1 = 25;
              continue;
            }
            num1 = 10;
            continue;
          case 13:
            num1 = num6 < 3 ? 27 : 29;
            continue;
          case 14:
            A_0.SetColor(x, y, pixel.Color);
            ++x;
            num1 = 30;
            continue;
          case 15:
            if ((int) pixel.A == 0)
            {
              num1 = 0;
              continue;
            }
            goto case 14;
          case 16:
            num2 = 0;
            num3 = 0;
            num4 = 0;
            index1 = 0;
            if (1 == 0)
              ;
            num1 = 23;
            continue;
          case 17:
          case 30:
            num1 = 26;
            continue;
          case 18:
          case 28:
            num1 = 13;
            continue;
          case 19:
            if (index2 > 0)
            {
              num1 = 16;
              continue;
            }
            goto case 14;
          case 20:
          case 24:
            num1 = 6;
            continue;
          case 21:
            if ((int) pixelArray[index2].A != 0)
            {
              num1 = 4;
              continue;
            }
            goto case 22;
          case 22:
            ++num6;
            num1 = 28;
            continue;
          case 23:
          case 25:
            num1 = 12;
            continue;
          case 26:
            if (x >= width1)
            {
              num1 = 5;
              continue;
            }
            pixel = rgbImage.GetPixel(x + 1, y + 1);
            num1 = 15;
            continue;
          case 27:
            if (num5 == 1)
            {
              num1 = 8;
              continue;
            }
            goto case 9;
          case 29:
            ++num5;
            num1 = 24;
            continue;
          default:
            goto label_2;
        }
      }
label_43:;
    }

    private void a(ImageBase A_0, int A_1, int A_2, IntColor A_3)
    {
      if (1 == 0)
        ;
label_2:
      int x = A_1 * this.g + 2;
      int y = A_2 * this.h + 2;
      RgbImage rgbImage1 = new RgbImage();
      RgbImage rgbImage2 = new RgbImage();
      A_0.Extract((ImageBase) rgbImage1, x, y, this.i, this.j);
      A_0.Extract((ImageBase) rgbImage2, x, y + this.j + 1, this.i, 1);
      int num = 2;
      while (true)
      {
        switch (num)
        {
          case 0:
            ProgressControl.Warning(Strings.IDS_WARN_NON_WHITE_NULL, (object) (this.g * A_1 + this.g / 2), (object) (this.h * A_2 + this.h / 2), (object) this.b);
            num = 1;
            continue;
          case 1:
            goto label_5;
          case 2:
            if (!this.a((ImageBase) rgbImage1, (ImageBase) rgbImage2, A_3))
            {
              num = 0;
              continue;
            }
            goto label_7;
          default:
            goto label_2;
        }
      }
label_5:
      return;
label_7:;
    }

    private bool a(ImageBase A_0, ImageBase A_1, IntColor A_2)
    {
      int num = 2;
      int x1;
      int y;
      int x2;
      uint intColor;
      ImageBase.Pixel pixel1;
      ImageBase.Pixel pixel2;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (y < A_0.Height)
            {
              x2 = 0;
              num = 13;
              continue;
            }
            num = 15;
            continue;
          case 1:
          case 16:
            num = 0;
            continue;
          case 3:
            goto label_7;
          case 4:
          case 13:
            num = 8;
            continue;
          case 5:
            if ((int) pixel1.IntColor != (int) (uint) A_2)
            {
              num = 3;
              continue;
            }
            ++x1;
            num = 19;
            continue;
          case 6:
            goto label_31;
          case 7:
            num = 10;
            continue;
          case 8:
            if (x2 >= A_0.Width)
            {
              num = 11;
              continue;
            }
            pixel2 = A_0.GetPixel(x2, y);
            num = 17;
            continue;
          case 9:
            goto label_26;
          case 10:
            if (A_0.Width > 0)
            {
              num = 12;
              continue;
            }
            goto case 15;
          case 11:
            ++y;
            num = 1;
            continue;
          case 12:
            intColor = A_0.GetPixel(0, 0).IntColor;
            y = 0;
            if (1 == 0)
              ;
            num = 16;
            continue;
          case 14:
          case 19:
            num = 18;
            continue;
          case 15:
            x1 = 0;
            num = 14;
            continue;
          case 17:
            if ((int) pixel2.IntColor != (int) intColor)
            {
              num = 9;
              continue;
            }
            ++x2;
            num = 4;
            continue;
          case 18:
            if (x1 < A_1.Width)
            {
              pixel1 = A_1.GetPixel(x1, 0);
              num = 5;
              continue;
            }
            num = 6;
            continue;
          default:
            if (A_0.Height > 0)
            {
              num = 7;
              continue;
            }
            goto case 15;
        }
      }
label_7:
      return false;
label_26:
      return false;
label_31:
      return true;
    }

    private IntColor a(RgbImage A_0, ImageBase A_1)
    {
label_2:
      A_0.Create(A_1.Width, A_1.Height, 24);
      int num1 = 70;
      while (true)
      {
        bool flag;
        byte num2;
        int x1;
        int y1;
        byte alpha1;
        int width;
        int height;
        int x2;
        int y2;
        IntColor intColor1;
        int y3;
        byte num3;
        byte num4;
        int y4;
        int x3;
        int A_1_1;
        int A_2;
        int num5;
        int y5;
        int x4;
        IndexImage indexImage;
        int x5;
        int x6;
        int alphaBpp1;
        int alphaBpp2;
        int alphaBits;
        int y6;
        byte num6;
        int num7;
        int num8;
        int num9;
        switch (num1)
        {
          case 0:
          case 34:
            IntColor intColor2 = GlCm.BMP_RGB((byte) num5, (byte) num5, (byte) num5);
            A_0.SetColor(x3, y4, (uint) intColor2);
            ++x3;
            num1 = 38;
            continue;
          case 1:
            A_0.EnableAlpha();
            num1 = 56;
            continue;
          case 2:
            if (1 == 0)
              ;
            if (y2 >= A_1.Height)
            {
              num1 = 10;
              continue;
            }
            x2 = 0;
            num1 = 24;
            continue;
          case 3:
          case 65:
            num1 = 46;
            continue;
          case 4:
          case 43:
            num1 = 72;
            continue;
          case 5:
            if (this.c != GlyphImageFormat.LA4)
            {
              num1 = 78;
              continue;
            }
            goto label_79;
          case 6:
            if (x4 >= width)
            {
              num1 = 30;
              continue;
            }
            byte alpha2 = (byte) ImageFontReader.a((int) (byte) ImageFontReader.a((int) A_1.GetAlpha(x4, y3), alphaBpp1, alphaBits), alphaBits, alphaBpp2);
            A_0.SetAlpha(x4, y3, alpha2);
            ++x4;
            num1 = 62;
            continue;
          case 7:
          case 57:
            num1 = 71;
            continue;
          case 8:
            ++y2;
            num1 = 75;
            continue;
          case 9:
          case 53:
            num1 = 69;
            continue;
          case 10:
            A_0.EnableAlpha();
            num1 = 55;
            continue;
          case 11:
            if (flag)
            {
              num1 = 68;
              continue;
            }
            alphaBpp1 = A_1.AlphaBpp;
            alphaBpp2 = A_0.AlphaBpp;
            alphaBits = GlyphImageInfo.GetGlyphImageInfo(this.c).AlphaBits;
            y3 = 0;
            num1 = 7;
            continue;
          case 12:
            num7 = (int) num4;
            goto label_70;
          case 13:
          case 75:
            num1 = 2;
            continue;
          case 14:
            num5 = ImageFontReader.a((int) indexImage.GetColor(x3, y4), A_1_1, A_2);
            num1 = 0;
            continue;
          case 15:
          case 80:
            num1 = 67;
            continue;
          case 16:
          case 29:
            num1 = 64;
            continue;
          case 17:
            num1 = x3 < A_1.Width ? 40 : 22;
            continue;
          case 18:
            num8 = 4;
            goto label_90;
          case 19:
            if (ImageFontReader.a(this.c))
            {
              num1 = 44;
              continue;
            }
            break;
          case 20:
          case 52:
            num1 = 28;
            continue;
          case 21:
          case 55:
          case 56:
            goto label_100;
          case 22:
            ++y4;
            num1 = 63;
            continue;
          case 23:
            ++y5;
            num1 = 4;
            continue;
          case 24:
          case 36:
            num1 = 79;
            continue;
          case 25:
            num1 = 48;
            continue;
          case 26:
          case 74:
            num1 = 11;
            continue;
          case 27:
            A_0.EnableAlpha();
            num1 = 21;
            continue;
          case 28:
            num1 = x6 < A_1.Width ? 54 : 32;
            continue;
          case 30:
            ++y3;
            num1 = 57;
            continue;
          case 31:
            flag = false;
            num1 = 26;
            continue;
          case 32:
            ++y6;
            num1 = 9;
            continue;
          case 33:
            num1 = 66;
            continue;
          case 35:
            num1 = (int) A_0.GetColor(x2, y2) == (int) (uint) intColor1 ? 45 : 76;
            continue;
          case 37:
          case 62:
            num1 = 6;
            continue;
          case 38:
          case 42:
            num1 = 17;
            continue;
          case 39:
            indexImage = A_1 as IndexImage;
            num1 = 49;
            continue;
          case 40:
            if (indexImage == null)
            {
              ImageBase.Pixel pixel = A_1.GetPixel(x3, y4);
              num5 = ImageFontReader.a(((int) pixel.R + (int) pixel.G + (int) pixel.B) / 3 >> 8 - A_1_1, A_1_1, A_2);
              num1 = 34;
              continue;
            }
            num1 = 14;
            continue;
          case 41:
          case 66:
            intColor1 = (IntColor) A_0.GetPixel(0, 0).Color;
            num1 = 19;
            continue;
          case 44:
            num1 = 77;
            continue;
          case 45:
            num7 = (int) num3;
            goto label_70;
          case 46:
            if (y1 >= height)
            {
              num1 = 74;
              continue;
            }
            x1 = 0;
            num1 = 16;
            continue;
          case 47:
            num1 = 5;
            continue;
          case 48:
            num9 = (int) num2;
            goto label_91;
          case 49:
            if (this.c != GlyphImageFormat.A4)
            {
              num1 = 47;
              continue;
            }
            goto label_79;
          case 50:
          case 63:
            num1 = 58;
            continue;
          case 51:
            ++y1;
            num1 = 3;
            continue;
          case 54:
            num1 = (int) A_0.GetColor(x6, y6) == (int) (uint) intColor1 ? 59 : 25;
            continue;
          case 58:
            if (y4 < A_1.Height)
            {
              x3 = 0;
              num1 = 42;
              continue;
            }
            num1 = 33;
            continue;
          case 59:
            num9 = (int) num6;
            goto label_91;
          case 60:
            if ((int) A_1.GetAlpha(x1, y1) != (int) alpha1)
            {
              num1 = 31;
              continue;
            }
            ++x1;
            num1 = 29;
            continue;
          case 61:
            num8 = 8;
            goto label_90;
          case 64:
            num1 = x1 < width ? 60 : 51;
            continue;
          case 67:
            if (x5 >= A_1.Width)
            {
              num1 = 23;
              continue;
            }
            uint rgb = A_1.GetRGB(x5, y5);
            IntColor intColor3 = GlCm.BMP_RGB((byte) (rgb >> 16 & (uint) byte.MaxValue), (byte) (rgb >> 8 & (uint) byte.MaxValue), (byte) (rgb & (uint) byte.MaxValue));
            A_0.SetColor(x5, y5, (uint) intColor3);
            ++x5;
            num1 = 15;
            continue;
          case 68:
            ProgressControl.Warning(Strings.IDS_WARN_ONE_ALPHA);
            num3 = (byte) 0;
            num4 = byte.MaxValue;
            y2 = 0;
            num1 = 13;
            continue;
          case 69:
            if (y6 < A_1.Height)
            {
              x6 = 0;
              num1 = 52;
              continue;
            }
            num1 = 1;
            continue;
          case 70:
            if (ImageFontReader.b(this.c))
            {
              num1 = 39;
              continue;
            }
            y5 = 0;
            num1 = 43;
            continue;
          case 71:
            if (y3 < height)
            {
              x4 = 0;
              num1 = 37;
              continue;
            }
            num1 = 27;
            continue;
          case 72:
            if (y5 >= A_1.Height)
            {
              num1 = 41;
              continue;
            }
            x5 = 0;
            num1 = 80;
            continue;
          case 73:
            width = A_1.Width;
            height = A_1.Height;
            alpha1 = A_1.GetAlpha(0, 0);
            flag = true;
            y1 = 0;
            num1 = 65;
            continue;
          case 76:
            num1 = 12;
            continue;
          case 77:
            if (A_1.IsEnableAlpha)
            {
              num1 = 73;
              continue;
            }
            break;
          case 78:
            num1 = 61;
            continue;
          case 79:
            num1 = x2 < A_1.Width ? 35 : 8;
            continue;
          default:
            goto label_2;
        }
        num6 = (byte) 0;
        num2 = byte.MaxValue;
        y6 = 0;
        num1 = 53;
        continue;
label_70:
        byte alpha3 = (byte) num7;
        A_0.SetAlpha(x2, y2, alpha3);
        ++x2;
        num1 = 36;
        continue;
label_79:
        num1 = 18;
        continue;
label_90:
        A_1_1 = num8;
        A_2 = A_0.ColorBpp / 3;
        y4 = 0;
        num1 = 50;
        continue;
label_91:
        byte alpha4 = (byte) num9;
        A_0.SetAlpha(x6, y6, alpha4);
        ++x6;
        num1 = 20;
      }
label_100:
      return (IntColor) A_0.GetPixel(0, 0).IntColor;
    }

    private ImageFileFormat a()
    {
label_2:
      ImageFileFormat imageFileFormat = ImageFileFormat.Ext;
      BitmapFile bitmapFile = new BitmapFile(this.a);
      TgaFile tgaFile = new TgaFile(this.a);
      bool flag1 = bitmapFile.HasValidIdentifier();
      bool flag2 = tgaFile.HasValidIdentifier();
      int num = 2;
      bool flag3;
      bool flag4;
      while (true)
      {
        switch (num)
        {
          case 0:
            num = !flag1 ? 1 : 7;
            continue;
          case 1:
            if (flag2)
            {
              num = 9;
              continue;
            }
            flag4 = bitmapFile.IsInvalid();
            flag3 = tgaFile.IsInvalid();
            num = 13;
            continue;
          case 2:
            if (flag1)
            {
              num = 18;
              continue;
            }
            goto case 6;
          case 3:
          case 8:
          case 14:
          case 19:
            if (1 == 0)
              ;
            num = 22;
            continue;
          case 4:
            if (ImageFileFormat.NUM <= imageFileFormat)
            {
              num = 21;
              continue;
            }
            goto label_34;
          case 5:
            num = 16;
            continue;
          case 6:
            num = 0;
            continue;
          case 7:
            imageFileFormat = ImageFileFormat.Bmp;
            num = 3;
            continue;
          case 9:
            imageFileFormat = ImageFileFormat.Tga;
            num = 14;
            continue;
          case 10:
            num = 4;
            continue;
          case 11:
            if (!flag3)
            {
              num = 5;
              continue;
            }
            goto case 3;
          case 12:
            if (flag3)
            {
              num = 20;
              continue;
            }
            goto case 3;
          case 13:
            if (flag4)
            {
              num = 15;
              continue;
            }
            goto case 5;
          case 15:
            num = 11;
            continue;
          case 16:
            num = !flag4 ? 12 : 23;
            continue;
          case 17:
            if (!flag2)
            {
              num = 6;
              continue;
            }
            goto case 3;
          case 18:
            num = 17;
            continue;
          case 20:
            imageFileFormat = ImageFileFormat.Bmp;
            num = 19;
            continue;
          case 21:
            goto label_17;
          case 22:
            if (imageFileFormat <= ImageFileFormat.Ext)
            {
              num = 10;
              continue;
            }
            goto label_34;
          case 23:
            imageFileFormat = ImageFileFormat.Tga;
            num = 8;
            continue;
          default:
            goto label_2;
        }
      }
label_17:
      throw GlCm.ErrMsg(ErrorType.Image, Strings.IDS_ERR_FAIL_INPUT_IMAGE_DETECTION);
label_34:
      return imageFileFormat;
    }

    private uint b(ImageBase A_0, int A_1, int A_2, int A_3)
    {
label_2:
      uint rgb = A_0.GetRGB(A_1, A_2);
      int x = A_1;
      int num = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
            num = 5;
            continue;
          case 1:
            if ((int) A_0.GetRGB(x, A_2) == (int) rgb)
            {
              ++x;
              num = 3;
              continue;
            }
            num = 4;
            continue;
          case 2:
            goto label_10;
          case 3:
            if (1 == 0)
              goto case 0;
            else
              goto case 0;
          case 4:
            goto label_5;
          case 5:
            num = x < A_1 + A_3 ? 1 : 2;
            continue;
          default:
            goto label_2;
        }
      }
label_5:
      return uint.MaxValue;
label_10:
      return rgb;
    }

    private uint a(ImageBase A_0, int A_1, int A_2, int A_3)
    {
label_3:
      uint rgb = A_0.GetRGB(A_1, A_2);
      int y = A_2;
      int num = 0;
      while (true)
      {
        if (1 == 0)
          ;
        switch (num)
        {
          case 0:
          case 5:
            num = 1;
            continue;
          case 1:
            num = y < A_2 + A_3 ? 3 : 4;
            continue;
          case 2:
            goto label_5;
          case 3:
            if ((int) A_0.GetRGB(A_1, y) == (int) rgb)
            {
              ++y;
              num = 5;
              continue;
            }
            num = 2;
            continue;
          case 4:
            goto label_10;
          default:
            goto label_3;
        }
      }
label_5:
      return uint.MaxValue;
label_10:
      return rgb;
    }

    private bool a(ImageBase A_0, int A_1, int A_2, int A_3, int A_4)
    {
label_2:
      uint num1 = this.b(A_0, A_1, A_2, A_3);
      int num2 = 4;
      while (true)
      {
        switch (num2)
        {
          case 0:
            goto label_12;
          case 1:
            num2 = (int) this.a(A_0, A_1, A_2, A_4) == (int) num1 ? 5 : 3;
            continue;
          case 2:
            goto label_5;
          case 3:
            goto label_4;
          case 4:
            num2 = (int) num1 != -1 ? 9 : 8;
            continue;
          case 5:
            if ((int) this.a(A_0, A_1 + A_3 - 1, A_2, A_4) != (int) num1)
            {
              num2 = 0;
              continue;
            }
            goto label_17;
          case 6:
            goto label_16;
          case 7:
            num2 = (int) this.b(A_0, A_1, A_2 + A_4 - 1, A_3) == (int) num1 ? 1 : 2;
            continue;
          case 8:
            goto label_10;
          case 9:
            if ((int) this.b(A_0, A_1, A_2 + A_4 - 3, A_3) != (int) num1)
            {
              num2 = 6;
              continue;
            }
            if (1 == 0)
              ;
            num2 = 7;
            continue;
          default:
            goto label_2;
        }
      }
label_4:
      return false;
label_5:
      return false;
label_10:
      return false;
label_12:
      return false;
label_16:
      return false;
label_17:
      return true;
    }
  }
}
