// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.NitroFontReader
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Runtime;
using NintendoWare.sdk;
using System;
using System.IO;

namespace NintendoWare.Font
{
  public class NitroFontReader : FontReader
  {
    private readonly string m_sa;

    public NitroFontReader(string file)
    {
      this.m_sa = file;
    }

    public override void ReadFontData(FontData fontData, CharFilter filter)
    {
label_2:
      if (1 == 0)
        ;
      G2dFont g2dFont = new G2dFont();
      ProgressControl.GetInstance().SetStatusString(string.Format(Strings.IDS_STATUS_READ_NITRO, (object) "bcfnt"));
      ProgressControl.GetInstance().ResetProgressBarPos();
      NitroFontReader.a(this.m_sa, g2dFont);
      int num = 2;
      while (true)
      {
        switch (num)
        {
          case 0:
            ProgressControl.Warning(string.Format(Strings.IDS_WARN_OLD_FORAMT, (object) "bcfnt"));
            num = 1;
            continue;
          case 1:
            goto label_7;
          case 2:
            if (g2dFont.IsOldVer())
            {
              num = 0;
              continue;
            }
            goto label_7;
          default:
            goto label_2;
        }
      }
label_7:
      this.a(fontData, filter, g2dFont);
    }

    public override void ValidateInput()
    {
      NitroFontReader.a(this.m_sa);
    }

    private static ImageBase.Pixel a(uint A_0)
    {
      if (1 == 0)
        ;
      ImageBase.Pixel pixel = new ImageBase.Pixel();
      byte num1 = (byte) GlCm.ExtendBits(A_0, 4, 8);
      byte num2 = (byte) GlCm.InverseNumber((uint) num1, 8);
      pixel.Color = (uint) GlCm.GrayScaleToRgb((uint) num2);
      pixel.A = num1;
      return pixel;
    }

    private static void a(string A_0)
    {
      if (!FontIO.IsFileExists(A_0))
        throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_FILE_NOT_EXISTS, (object) A_0);
      if (1 == 0)
        ;
      G2dFont A_1 = new G2dFont();
      NitroFontReader.a(A_0, A_1);
    }

    private static void a(string A_0, G2dFont A_1)
    {
      BinaryFile binaryFile = BinaryFile.Open(A_0, FileMode.Open, FileAccess.Read);
      try
      {
label_3:
        long length = binaryFile.Length;
        NnsReader nnsReader = new NnsReader((Stream) binaryFile);
        nnsReader.ReadHeader((NnsData) A_1);
        A_1.ValidateHeader();
        int num = 3;
        while (true)
        {
          switch (num)
          {
            case 0:
              goto label_15;
            case 1:
              if (binaryFile.Position < length)
              {
                nnsReader.ReadBlock((NnsData) A_1, new Func<Signature32, IBinarizable>(A_1.GenerateInstance));
                num = 4;
                continue;
              }
              num = 2;
              continue;
            case 2:
              num = 0;
              continue;
            case 3:
            case 4:
              num = 1;
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
              goto label_14;
            default:
              if (binaryFile != null)
              {
                num = 0;
                continue;
              }
              goto label_14;
          }
        }
label_14:;
      }
label_15:
      if (1 == 0)
        ;
      A_1.Rebuild();
    }

    private void a(FontData A_0, CharFilter A_1, G2dFont A_2)
    {
label_2:
      ProgressControl.GetInstance().SetProgressBarMax(65536);
      FontInformation body = ((FontInformationEx) A_2.GetBlock(RtConsts.BinBlockSigFINF).Body).Body;
      ushort A_5 = body.AlterCharIndex;
      A_0.LineHeight = new int?((int) body.Linefeed);
      int num = 4;
      NnsData.GeneralBinaryBlockInfo block1 = null;
      NnsData.GeneralBinaryBlockInfo block2 = null;
      CharEncoding A_4 = default(CharEncoding);
      while (true)
      {
        switch (num)
        {
          case 0:
            num = 3;
            continue;
          case 1:
            A_4 = (CharEncoding) body.DefaultWidth.CharWidth;
            num = 7;
            continue;
          case 2:
          case 7:
            block1 = A_2.GetBlock(RtConsts.BinBlockSigCGLP);
            block2 = A_2.GetBlock(RtConsts.BinBlockSigTGLP);
            num = 5;
            continue;
          case 3:
            if (A_2.IsOldVer())
            {
              num = 1;
              continue;
            }
            A_0.DefaultWidth = new CharWidths?(body.DefaultWidth);
            A_4 = (CharEncoding) body.Encoding;
            num = 2;
            continue;
          case 4:
            if (!A_2.IsOldVer())
            {
              num = 6;
              continue;
            }
            goto case 0;
          case 5:
            if (block1 != null)
            {
              num = 8;
              continue;
            }
            goto label_16;
          case 6:
            A_0.SetWidth((int) body.Width);
            A_0.SetHeight((int) body.Ascent, (int) body.Height - (int) body.Ascent);
            num = 0;
            continue;
          case 8:
            goto label_10;
          default:
            goto label_2;
        }
      }
label_10:
      if (1 == 0)
        ;
      this.a(A_0, A_1, A_2, (LibFormatFontGlyph) block1.Body, A_4, A_5);
      return;
label_16:
      this.a(A_0, A_1, A_2, (FontTextureGlyphEx) block2.Body, A_4, A_5);
    }

    private void a(FontData A_0, CharFilter A_1, G2dFont A_2, FontTextureGlyphEx A_3, CharEncoding A_4, ushort A_5)
    {
label_2:
      RgbImage rgbImage = new RgbImage();
      bool flag = ((int) A_3.Body.SheetFormat & 32768) != 0;
      ushort num1 = (ushort) ((uint) A_3.Body.SheetFormat & (uint) short.MaxValue);
      int num2 = 11;
      byte[] numArray = null;
      ByteOrderBinaryReader orderBinaryReader = null;
      byte[] dst = null;
      int offset = 0;
      int dstOffs = 0;
      int num3 = 0;
      GlyphImageFormat A_2_1 = default(GlyphImageFormat);
      int width = 0;
      int height = 0;
      int num4 = 0;
      ushort glyphIndex = 0;
      ushort A_5_1 = 0;
      int num5 = 0;
      while (true)
      {
        switch (num2)
        {
          case 0:
            num5 = (int) this.a((NintendoWare.Font.Revolution.TextureFormat) num1);
            break;
          case 1:
            if (flag)
            {
              if (1 == 0)
                ;
              num2 = 8;
              continue;
            }
            goto case 12;
          case 2:
            goto label_26;
          case 3:
            num5 = (int) this.a((NintendoWare.Font.Ctr.TextureFormat) num1);
            break;
          case 4:
            this.a(A_0, A_2, A_3.Body, rgbImage, glyphIndex, A_5_1);
            num2 = 14;
            continue;
          case 5:
            if (num3 < (int) A_3.Body.SheetNum)
            {
              orderBinaryReader.Seek(offset, SeekOrigin.Begin);
              uint num6 = orderBinaryReader.ReadUInt32();
              int srcOffs = offset + 4;
              Util.nitroDecompress(numArray, srcOffs, (int) num6, dst, dstOffs, (sbyte) 1);
              offset = srcOffs + (int) num6;
              dstOffs += (int) A_3.Body.SheetSize;
              ++num3;
              num2 = 7;
              continue;
            }
            num2 = 16;
            continue;
          case 6:
          case 7:
            num2 = 5;
            continue;
          case 8:
            orderBinaryReader = new ByteOrderBinaryReader((Stream) new MemoryStream(numArray), true);
            dst = new byte[/*(IntPtr) */(A_3.Body.SheetSize * (uint) A_3.Body.SheetNum)];
            offset = 0;
            dstOffs = 0;
            num3 = 0;
            num2 = 6;
            continue;
          case 9:
            num2 = 3;
            continue;
          case 10:
            if ((int) A_5_1 != (int) ushort.MaxValue)
            {
              num2 = 4;
              continue;
            }
            goto case 14;
          case 11:
            num2 = ConverterEnvironment.IsRvl ? 0 : 9;
            continue;
          case 12:
            rgbImage.Create(width, height, 32);
            rgbImage.Clear((uint) ImageBase.RgbWhite, (byte) 0);
            rgbImage.EnableAlpha();
            this.a(rgbImage, numArray, A_2_1, A_3.Body);
            num4 = 0;
            num2 = 17;
            continue;
          case 13:
            if (num4 >= 65536)
            {
              num2 = 2;
              continue;
            }
            ushort num7 = (ushort) num4;
            glyphIndex = A_2.GetGlyphIndex(num7);
            A_5_1 = this.a(A_0, A_1, A_4, A_5, num7, glyphIndex);
            ProgressControl.GetInstance().StepProgressBar();
            num2 = 10;
            continue;
          case 14:
            ++num4;
            num2 = 15;
            continue;
          case 15:
          case 17:
            num2 = 13;
            continue;
          case 16:
            numArray = dst;
            num2 = 12;
            continue;
          default:
            goto label_2;
        }
        A_2_1 = (GlyphImageFormat) num5;
        A_0.OutputFormat = new GlyphImageFormat?(A_2_1);
        A_0.BaselinePos = new int?((int) A_3.Body.BaselinePos);
        int num8 = (int) A_3.Body.SheetNum;
        width = (int) A_3.Body.SheetWidth;
        height = (int) A_3.Body.SheetHeight * num8;
        numArray = A_3.SheetImage;
        dst = (byte[]) null;
        num2 = 1;
      }
label_26:;
    }

    private GlyphImageFormat a(NintendoWare.Font.Revolution.TextureFormat A_0)
    {
label_2:
      NintendoWare.Font.Revolution.TextureFormat textureFormat = A_0;
      int num = 4;
      GlyphImageFormat glyphImageFormat = default(GlyphImageFormat);
      while (true)
      {
        switch (num)
        {
          case 0:
          case 2:
          case 3:
          case 5:
          case 6:
          case 8:
          case 9:
            goto label_15;
          case 1:
            num = 7;
            continue;
          case 4:
            switch (textureFormat)
            {
              case NintendoWare.Font.Revolution.TextureFormat.I4:
                glyphImageFormat = GlyphImageFormat.A4;
                num = 3;
                continue;
              case NintendoWare.Font.Revolution.TextureFormat.I8:
                glyphImageFormat = GlyphImageFormat.A8;
                num = 2;
                continue;
              case NintendoWare.Font.Revolution.TextureFormat.IA4:
                glyphImageFormat = GlyphImageFormat.LA4;
                num = 6;
                continue;
              case NintendoWare.Font.Revolution.TextureFormat.IA8:
                glyphImageFormat = GlyphImageFormat.LA8;
                num = 8;
                continue;
              case NintendoWare.Font.Revolution.TextureFormat.RGB565:
                glyphImageFormat = GlyphImageFormat.RGB565;
                num = 0;
                continue;
              case NintendoWare.Font.Revolution.TextureFormat.RGB5A3:
                glyphImageFormat = GlyphImageFormat.RGB5A3;
                if (1 == 0)
                  ;
                num = 9;
                continue;
              case NintendoWare.Font.Revolution.TextureFormat.RGBA8:
                glyphImageFormat = GlyphImageFormat.RGBA8;
                num = 5;
                continue;
              default:
                num = 1;
                continue;
            }
          case 7:
            goto label_12;
          default:
            goto label_2;
        }
      }
label_12:
      throw new InvalidOperationException("unsupported format. " + (object) A_0);
label_15:
      return glyphImageFormat;
    }

    private GlyphImageFormat a(NintendoWare.Font.Ctr.TextureFormat A_0)
    {
label_2:
      NintendoWare.Font.Ctr.TextureFormat textureFormat = A_0;
      int num = 8;
      GlyphImageFormat glyphImageFormat = default(GlyphImageFormat);
      while (true)
      {
        switch (num)
        {
          case 0:
          case 1:
          case 2:
          case 4:
          case 5:
          case 6:
          case 7:
          case 11:
            goto label_17;
          case 3:
            num = 9;
            continue;
          case 8:
            switch (textureFormat)
            {
              case NintendoWare.Font.Ctr.TextureFormat.RGBA8:
                glyphImageFormat = GlyphImageFormat.RGBA8;
                num = 11;
                continue;
              case NintendoWare.Font.Ctr.TextureFormat.RGB8:
                glyphImageFormat = GlyphImageFormat.RGB8;
                num = 10;
                continue;
              case NintendoWare.Font.Ctr.TextureFormat.RGB5A1:
                glyphImageFormat = GlyphImageFormat.RGB5A1;
                num = 0;
                continue;
              case NintendoWare.Font.Ctr.TextureFormat.RGB565:
                glyphImageFormat = GlyphImageFormat.RGB565;
                num = 1;
                continue;
              case NintendoWare.Font.Ctr.TextureFormat.RGBA4:
                glyphImageFormat = GlyphImageFormat.RGBA4;
                num = 5;
                continue;
              case NintendoWare.Font.Ctr.TextureFormat.LA8:
                glyphImageFormat = GlyphImageFormat.LA8;
                num = 6;
                continue;
              case (NintendoWare.Font.Ctr.TextureFormat) 6:
              case (NintendoWare.Font.Ctr.TextureFormat) 7:
              case (NintendoWare.Font.Ctr.TextureFormat) 10:
                goto label_12;
              case NintendoWare.Font.Ctr.TextureFormat.A8:
                glyphImageFormat = GlyphImageFormat.A8;
                num = 7;
                continue;
              case NintendoWare.Font.Ctr.TextureFormat.LA4:
                glyphImageFormat = GlyphImageFormat.LA4;
                num = 2;
                continue;
              case NintendoWare.Font.Ctr.TextureFormat.A4:
                glyphImageFormat = GlyphImageFormat.A4;
                num = 4;
                continue;
              default:
                num = 3;
                continue;
            }
          case 9:
            goto label_12;
          case 10:
            goto label_11;
          default:
            goto label_2;
        }
      }
label_11:
      if (1 == 0)
        goto label_17;
      else
        goto label_17;
label_12:
      throw new InvalidOperationException("unsupported format. " + (object) A_0);
label_17:
      return glyphImageFormat;
    }

    private void a(FontData A_0, G2dFont A_1, FontTextureGlyph A_2, RgbImage A_3, ushort A_4, ushort A_5)
    {
      if (1 == 0)
        ;
      CharWidths glyphWidthInfo = A_1.GetGlyphWidthInfo(A_4);
      Glyph glyph = new Glyph();
      GlyphList glyphList = A_0.GetGlyphList();
      RgbImage image = new RgbImage();
      int num1 = (int) A_2.SheetRow * (int) A_2.SheetLine;
      int num2 = (int) A_4 / num1;
      int num3 = (int) A_4 % num1;
      int num4 = num3 % (int) A_2.SheetRow;
      int num5 = num3 / (int) A_2.SheetRow;
      int num6 = num4 * ((int) A_2.CellWidth + 1) + 1;
      int num7 = num5 * ((int) A_2.CellHeight + 1) + 1;
      int num8 = num2 * (int) A_2.SheetHeight;
      int x = num6;
      int y = num7 + num8;
      byte num9 = glyphWidthInfo.GlyphWidth;
      byte num10 = A_2.CellHeight;
      A_3.Extract((ImageBase) image, x, y, (int) num9, (int) num10);
      IntColor nullColor = (IntColor) A_3.GetPixel(0, 0).IntColor;
      int l = (int) glyphWidthInfo.Left;
      int r = (int) glyphWidthInfo.CharWidth - (l + (int) glyphWidthInfo.GlyphWidth);
      glyph.SetGlyphImage(image, l, r, A_0.BaselinePos.Value, nullColor);
      glyphList.AddGlyph(glyph, A_5);
    }

    private void a(FontData A_0, CharFilter A_1, G2dFont A_2, LibFormatFontGlyph A_3, CharEncoding A_4, ushort A_5)
    {
label_2:
      A_0.BaselinePos = new int?((int) A_3.BaselinePos);
      int num1 = 0;
      int num2 = 1;
      ushort glyphIndex = 0;
      ushort A_4_1 = 0;
      while (true)
      {
        switch (num2)
        {
          case 0:
            this.a(A_0, A_2, A_3, glyphIndex, A_4_1);
            num2 = 3;
            continue;
          case 1:
          case 6:
            if (1 == 0)
              ;
            num2 = 5;
            continue;
          case 2:
            goto label_12;
          case 3:
            ++num1;
            num2 = 6;
            continue;
          case 4:
            if ((int) A_4_1 != (int) ushort.MaxValue)
            {
              num2 = 0;
              continue;
            }
            goto case 3;
          case 5:
            if (num1 < 65536)
            {
              ushort num3 = (ushort) num1;
              glyphIndex = A_2.GetGlyphIndex(num3);
              A_4_1 = this.a(A_0, A_1, A_4, A_5, num3, glyphIndex);
              ProgressControl.GetInstance().StepProgressBar();
              num2 = 4;
              continue;
            }
            num2 = 2;
            continue;
          default:
            goto label_2;
        }
      }
label_12:;
    }

    private void a(FontData A_0, G2dFont A_1, LibFormatFontGlyph A_2, ushort A_3, ushort A_4)
    {
    }

    private ushort a(FontData A_0, CharFilter A_1, CharEncoding A_2, ushort A_3, ushort A_4, ushort A_5)
    {
label_3:
      ushort c = ushort.MaxValue;
      int num = 8;
      while (true)
      {
        if (1 == 0)
          ;
        switch (num)
        {
          case 0:
            if (A_1.IsFiltered(c))
            {
              num = 5;
              continue;
            }
            goto label_17;
          case 1:
            num = 0;
            continue;
          case 2:
            goto label_12;
          case 3:
            if ((int) A_5 == (int) A_3)
            {
              num = 7;
              continue;
            }
            goto case 1;
          case 4:
            num = (int) c != (int) ushort.MaxValue ? 3 : 6;
            continue;
          case 5:
            goto label_11;
          case 6:
            goto label_16;
          case 7:
            A_0.AlterChar = new ushort?(c);
            num = 1;
            continue;
          case 8:
            if ((int) A_5 == (int) ushort.MaxValue)
            {
              num = 2;
              continue;
            }
            c = GlCm.EncodingToUnicode(A_2, A_4);
            num = 4;
            continue;
          default:
            goto label_3;
        }
      }
label_11:
      return ushort.MaxValue;
label_12:
      return ushort.MaxValue;
label_16:
      ProgressControl.Warning(Strings.IDS_WARN_CANT_REPRESETN_IN_UNICODE, (object) A_4);
      return ushort.MaxValue;
label_17:
      return c;
    }

    private void a(RgbImage A_0, byte[] A_1, GlyphImageFormat A_2, FontTextureGlyph A_3)
    {
label_2:
      int bpp = GlyphImageInfo.GetGlyphImageInfo(A_2).Bpp;
      GlyphImageFormat glyphImageFormat = A_2;
      int num = 8;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (1 == 0)
              ;
            if (ConverterEnvironment.IsRvl)
            {
              num = 2;
              continue;
            }
            goto label_7;
          case 1:
            goto label_28;
          case 2:
            goto label_24;
          case 3:
            goto label_6;
          case 4:
            if (ConverterEnvironment.IsRvl)
            {
              num = 3;
              continue;
            }
            goto label_31;
          case 5:
            if (ConverterEnvironment.IsRvl)
            {
              num = 7;
              continue;
            }
            goto label_29;
          case 6:
            if (ConverterEnvironment.IsRvl)
            {
              num = 9;
              continue;
            }
            goto label_32;
          case 7:
            goto label_23;
          case 8:
            switch (glyphImageFormat)
            {
              case GlyphImageFormat.A4:
                num = 0;
                continue;
              case GlyphImageFormat.A8:
                goto label_20;
              case GlyphImageFormat.LA4:
                num = 5;
                continue;
              case GlyphImageFormat.LA8:
                num = 4;
                continue;
              case GlyphImageFormat.RGB565:
                goto label_13;
              case GlyphImageFormat.RGB5A1:
                goto label_5;
              case GlyphImageFormat.RGB5A3:
                goto label_30;
              case GlyphImageFormat.RGBA4:
                goto label_21;
              case GlyphImageFormat.RGB8:
                goto label_8;
              case GlyphImageFormat.RGBA8:
                num = 6;
                continue;
              default:
                num = 1;
                continue;
            }
          case 9:
            goto label_22;
          default:
            goto label_2;
        }
      }
label_28:
      return;
label_5:
      this.a(A_0, bpp, new NitroFontReader.PixelReader(new NitroFontReader.Reader(A_1).ReadPixelRGB5A1));
      return;
label_6:
      this.a(A_0, bpp, new NitroFontReader.PixelReader(new NitroFontReader.Reader(A_1).ReadPixelAL8));
      return;
label_7:
      this.a(A_0, bpp, new NitroFontReader.PixelReader(new NitroFontReader.A4Reader(A_1).ReadPixelA4));
      return;
label_8:
      this.a(A_0, bpp, new NitroFontReader.PixelReader(new NitroFontReader.Reader(A_1).ReadPixelRGB8));
      return;
label_13:
      this.a(A_0, bpp, new NitroFontReader.PixelReader(new NitroFontReader.Reader(A_1).ReadPixelRGB565));
      return;
label_20:
      this.a(A_0, bpp, new NitroFontReader.PixelReader(new NitroFontReader.Reader(A_1).ReadPixelA8));
      return;
label_21:
      this.a(A_0, bpp, new NitroFontReader.PixelReader(new NitroFontReader.Reader(A_1).ReadPixelRGBA4));
      return;
label_22:
      this.a(A_0, A_1);
      return;
label_23:
      this.a(A_0, bpp, new NitroFontReader.PixelReader(new NitroFontReader.Reader(A_1).ReadPixelAL4));
      return;
label_24:
      this.a(A_0, bpp, new NitroFontReader.PixelReader(new NitroFontReader.A4Reader(A_1).ReadPixelA4_Rvl));
      return;
label_29:
      this.a(A_0, bpp, new NitroFontReader.PixelReader(new NitroFontReader.Reader(A_1).ReadPixelLA4));
      return;
label_30:
      this.a(A_0, bpp, new NitroFontReader.PixelReader(new NitroFontReader.Reader(A_1).ReadPixelA3RGB5));
      return;
label_31:
      this.a(A_0, bpp, new NitroFontReader.PixelReader(new NitroFontReader.Reader(A_1).ReadPixelLA8));
      return;
label_32:
      this.a(A_0, bpp, new NitroFontReader.PixelReader(new NitroFontReader.Reader(A_1).ReadPixelRGBA8));
    }

    private void a(RgbImage A_0, int A_1, NitroFontReader.PixelReader A_2)
    {
label_2:
      if (1 == 0)
        ;
      IPixelPicker pixelPicker = PixelPickerCreater.Create(A_0, A_1);
      int num1 = A_0.Width * A_0.Height;
      int pos = 0;
      int num2 = 2;
      while (true)
      {
        switch (num2)
        {
          case 0:
            goto label_8;
          case 1:
            if (pos >= num1)
            {
              num2 = 0;
              continue;
            }
            PixelPos pixel = pixelPicker.GetPixel(pos);
            A_0.SetPixel(pixel.X, pixel.Y, A_2());
            ++pos;
            num2 = 3;
            continue;
          case 2:
          case 3:
            num2 = 1;
            continue;
          default:
            goto label_2;
        }
      }
label_8:;
    }

    private void a(RgbImage A_0, byte[] A_1)
    {
label_2:
      int bpp = 32;
      IPixelPicker pixelPicker = PixelPickerCreater.Create(A_0, bpp);
      ByteOrderBinaryReader orderBinaryReader1 = new ByteOrderBinaryReader((Stream) new MemoryStream(A_1), true);
      byte[] buffer = new byte[pixelPicker.BlockPixelNum * 2];
      int num1 = 0;
      int num2 = 3;
      int num3 = 0;
      ByteOrderBinaryReader orderBinaryReader2 = null;
      int pos = 0;
      while (true)
      {
        switch (num2)
        {
          case 0:
            num1 += pixelPicker.BlockH;
            num2 = 2;
            continue;
          case 1:
            num3 += pixelPicker.BlockW;
            if (1 == 0)
              ;
            num2 = 8;
            continue;
          case 2:
          case 3:
            num2 = 4;
            continue;
          case 4:
            if (num1 >= A_0.Height)
            {
              num2 = 5;
              continue;
            }
            num3 = 0;
            num2 = 6;
            continue;
          case 5:
            goto label_18;
          case 6:
          case 8:
            num2 = 10;
            continue;
          case 7:
          case 9:
            num2 = 11;
            continue;
          case 10:
            if (num3 >= A_0.Width)
            {
              num2 = 0;
              continue;
            }
            orderBinaryReader1.Read(buffer, 0, buffer.Length);
            orderBinaryReader2 = new ByteOrderBinaryReader((Stream) new MemoryStream(buffer), true);
            pos = 0;
            num2 = 9;
            continue;
          case 11:
            if (pos >= pixelPicker.BlockPixelNum)
            {
              num2 = 1;
              continue;
            }
            ImageBase.Pixel p = new ImageBase.Pixel();
            ushort num4 = orderBinaryReader2.ReadUInt16();
            ushort num5 = orderBinaryReader1.ReadUInt16();
            p.A = (byte) GlCm.ExtractBits((uint) num4, 8, 8);
            p.R = (byte) GlCm.ExtractBits((uint) num4, 0, 8);
            p.G = (byte) GlCm.ExtractBits((uint) num5, 8, 8);
            p.B = (byte) GlCm.ExtractBits((uint) num5, 0, 8);
            PixelPos pixel = pixelPicker.GetPixel(pos);
            A_0.SetPixel(num3 + pixel.X, num1 + pixel.Y, p);
            ++pos;
            num2 = 7;
            continue;
          default:
            goto label_2;
        }
      }
label_18:;
    }

    private delegate ImageBase.Pixel PixelReader();

    private class A4Reader
    {
      private readonly MemoryStream a;
      private byte b;
      private byte c;

      public A4Reader(byte[] image)
      {
        this.a = new MemoryStream(image);
      }

      public ImageBase.Pixel ReadPixelA4_Rvl()
      {
label_2:
        this.b ^= (byte) 1;
        if (1 == 0)
          ;
        int num = 2;
        int right = 0;
        while (true)
        {
          switch (num)
          {
            case 0:
            case 3:
              goto label_8;
            case 1:
              this.c = (byte) this.a.ReadByte();
              right = 4;
              num = 0;
              continue;
            case 2:
              if ((int) this.b != 0)
              {
                num = 1;
                continue;
              }
              right = 0;
              num = 3;
              continue;
            default:
              goto label_2;
          }
        }
label_8:
        return NitroFontReader.a(GlCm.ExtractBits((uint) this.c, right, 4));
      }

      public ImageBase.Pixel ReadPixelA4()
      {
label_2:
        this.b ^= (byte) 1;
        if (1 == 0)
          ;
        int num = 3;
        int right = 0;
        while (true)
        {
          switch (num)
          {
            case 0:
              this.c = (byte) this.a.ReadByte();
              right = 0;
              num = 2;
              continue;
            case 1:
            case 2:
              goto label_8;
            case 3:
              if ((int) this.b != 0)
              {
                num = 0;
                continue;
              }
              right = 4;
              num = 1;
              continue;
            default:
              goto label_2;
          }
        }
label_8:
        return NitroFontReader.a(GlCm.ExtractBits((uint) this.c, right, 4));
      }
    }

    private class Reader
    {
      private ByteOrderBinaryReader a;

      public Reader(byte[] image)
      {
        this.a = new ByteOrderBinaryReader((Stream) new MemoryStream(image), true);
      }

      public ImageBase.Pixel ReadPixelA8()
      {
        if (1 == 0)
          ;
        ImageBase.Pixel pixel = new ImageBase.Pixel();
        byte num1 = this.a.ReadByte();
        byte num2 = (byte) GlCm.InverseNumber((uint) num1, 8);
        pixel.Color = (uint) GlCm.GrayScaleToRgb((uint) num2);
        pixel.A = num1;
        return pixel;
      }

      public ImageBase.Pixel ReadPixelAL4()
      {
        if (1 == 0)
          ;
        ImageBase.Pixel pixel = new ImageBase.Pixel();
        byte num1 = this.a.ReadByte();
        uint bits1 = GlCm.ExtractBits((uint) num1, 0, 4);
        uint bits2 = GlCm.ExtractBits((uint) num1, 4, 4);
        byte num2 = (byte) GlCm.InverseNumber(GlCm.ExtendBits(bits1, 4, 8), 8);
        pixel.Color = (uint) GlCm.GrayScaleToRgb((uint) num2);
        pixel.A = (byte) GlCm.ExtendBits(bits2, 4, 8);
        return pixel;
      }

      public ImageBase.Pixel ReadPixelLA4()
      {
        if (1 == 0)
          ;
        ImageBase.Pixel pixel = new ImageBase.Pixel();
        byte num1 = this.a.ReadByte();
        uint bits1 = GlCm.ExtractBits((uint) num1, 4, 4);
        uint bits2 = GlCm.ExtractBits((uint) num1, 0, 4);
        byte num2 = (byte) GlCm.InverseNumber(GlCm.ExtendBits(bits1, 4, 8), 8);
        pixel.Color = (uint) GlCm.GrayScaleToRgb((uint) num2);
        pixel.A = (byte) GlCm.ExtendBits(bits2, 4, 8);
        return pixel;
      }

      public ImageBase.Pixel ReadPixelAL8()
      {
        if (1 == 0)
          ;
        ImageBase.Pixel pixel = new ImageBase.Pixel();
        ushort num1 = this.a.ReadUInt16();
        byte num2 = (byte) GlCm.InverseNumber(GlCm.ExtractBits((uint) num1, 0, 8), 8);
        pixel.Color = (uint) GlCm.GrayScaleToRgb((uint) num2);
        pixel.A = (byte) GlCm.ExtractBits((uint) num1, 8, 8);
        return pixel;
      }

      public ImageBase.Pixel ReadPixelLA8()
      {
        if (1 == 0)
          ;
        ImageBase.Pixel pixel = new ImageBase.Pixel();
        ushort num1 = this.a.ReadUInt16();
        byte num2 = (byte) GlCm.InverseNumber(GlCm.ExtractBits((uint) num1, 8, 8), 8);
        pixel.Color = (uint) GlCm.GrayScaleToRgb((uint) num2);
        pixel.A = (byte) GlCm.ExtractBits((uint) num1, 0, 8);
        return pixel;
      }

      public ImageBase.Pixel ReadPixelRGB565()
      {
        if (1 == 0)
          ;
        ImageBase.Pixel pixel = new ImageBase.Pixel();
        ushort num = this.a.ReadUInt16();
        uint bits1 = GlCm.ExtractBits((uint) num, 11, 5);
        uint bits2 = GlCm.ExtractBits((uint) num, 5, 6);
        uint bits3 = GlCm.ExtractBits((uint) num, 0, 5);
        pixel.R = (byte) GlCm.ExtendBits(bits1, 5, 8);
        pixel.G = (byte) GlCm.ExtendBits(bits2, 6, 8);
        pixel.B = (byte) GlCm.ExtendBits(bits3, 5, 8);
        pixel.A = byte.MaxValue;
        return pixel;
      }

      public ImageBase.Pixel ReadPixelA3RGB5()
      {
label_2:
        ImageBase.Pixel pixel = new ImageBase.Pixel();
        ushort num1 = this.a.ReadUInt16();
        if (1 == 0)
          ;
        int num2 = 0;
        while (true)
        {
          switch (num2)
          {
            case 0:
              if (((int) num1 & 32768) != 0)
              {
                num2 = 2;
                continue;
              }
              uint bits1 = GlCm.ExtractBits((uint) num1, 12, 3);
              uint bits2 = GlCm.ExtractBits((uint) num1, 8, 4);
              uint bits3 = GlCm.ExtractBits((uint) num1, 4, 4);
              uint bits4 = GlCm.ExtractBits((uint) num1, 0, 4);
              pixel.A = (byte) GlCm.ExtendBits(bits1, 3, 8);
              pixel.R = (byte) GlCm.ExtendBits(bits2, 4, 8);
              pixel.G = (byte) GlCm.ExtendBits(bits3, 4, 8);
              pixel.B = (byte) GlCm.ExtendBits(bits4, 4, 8);
              num2 = 3;
              continue;
            case 1:
            case 3:
              goto label_8;
            case 2:
              uint bits5 = GlCm.ExtractBits((uint) num1, 10, 5);
              uint bits6 = GlCm.ExtractBits((uint) num1, 5, 5);
              uint bits7 = GlCm.ExtractBits((uint) num1, 0, 5);
              pixel.A = byte.MaxValue;
              pixel.R = (byte) GlCm.ExtendBits(bits5, 5, 8);
              pixel.G = (byte) GlCm.ExtendBits(bits6, 5, 8);
              pixel.B = (byte) GlCm.ExtendBits(bits7, 5, 8);
              num2 = 1;
              continue;
            default:
              goto label_2;
          }
        }
label_8:
        return pixel;
      }

      public ImageBase.Pixel ReadPixelRGB5A1()
      {
        if (1 == 0)
          ;
        ImageBase.Pixel pixel = new ImageBase.Pixel();
        ushort num = this.a.ReadUInt16();
        uint bits1 = GlCm.ExtractBits((uint) num, 11, 5);
        uint bits2 = GlCm.ExtractBits((uint) num, 6, 5);
        uint bits3 = GlCm.ExtractBits((uint) num, 1, 5);
        uint bits4 = GlCm.ExtractBits((uint) num, 0, 1);
        pixel.R = (byte) GlCm.ExtendBits(bits1, 5, 8);
        pixel.G = (byte) GlCm.ExtendBits(bits2, 5, 8);
        pixel.B = (byte) GlCm.ExtendBits(bits3, 5, 8);
        pixel.A = (byte) GlCm.ExtendBits(bits4, 1, 8);
        return pixel;
      }

      public ImageBase.Pixel ReadPixelRGBA4()
      {
        if (1 == 0)
          ;
        ImageBase.Pixel pixel = new ImageBase.Pixel();
        ushort num = this.a.ReadUInt16();
        uint bits1 = GlCm.ExtractBits((uint) num, 12, 4);
        uint bits2 = GlCm.ExtractBits((uint) num, 8, 4);
        uint bits3 = GlCm.ExtractBits((uint) num, 4, 4);
        uint bits4 = GlCm.ExtractBits((uint) num, 0, 4);
        pixel.R = (byte) GlCm.ExtendBits(bits1, 4, 8);
        pixel.G = (byte) GlCm.ExtendBits(bits2, 4, 8);
        pixel.B = (byte) GlCm.ExtendBits(bits3, 4, 8);
        pixel.A = (byte) GlCm.ExtendBits(bits4, 4, 8);
        return pixel;
      }

      public ImageBase.Pixel ReadPixelRGB8()
      {
        if (1 == 0)
          ;
        ImageBase.Pixel pixel = new ImageBase.Pixel();
        uint e = this.a.Read24Bits();
        pixel.R = (byte) GlCm.ExtractBits(e, 16, 8);
        pixel.G = (byte) GlCm.ExtractBits(e, 8, 8);
        pixel.B = (byte) GlCm.ExtractBits(e, 0, 8);
        pixel.A = byte.MaxValue;
        return pixel;
      }

      public ImageBase.Pixel ReadPixelRGBA8()
      {
        if (1 == 0)
          ;
        ImageBase.Pixel pixel = new ImageBase.Pixel();
        uint e = this.a.ReadUInt32();
        pixel.R = (byte) GlCm.ExtractBits(e, 24, 8);
        pixel.G = (byte) GlCm.ExtractBits(e, 16, 8);
        pixel.B = (byte) GlCm.ExtractBits(e, 8, 8);
        pixel.A = (byte) GlCm.ExtractBits(e, 0, 8);
        return pixel;
      }
    }
  }
}
