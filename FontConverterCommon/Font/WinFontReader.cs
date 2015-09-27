// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.WinFontReader
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Win32;

namespace NintendoWare.Font
{
  public class WinFontReader : FontReader
  {
    private const int a = 0;
    private const int b = 65534;
    private readonly string c;
    private readonly int d;
    private readonly int e;
    private readonly int f;
    private readonly int g;
    private readonly WidthType h;
    private readonly bool i;
    private readonly bool j;

    public WinFontReader(string name, int size, int avgwidth, int bpp, bool hasAlpha, WidthType wt, int fixedWidth, bool isSoftAA)
    {
      this.c = name;
      this.d = size;
      this.e = avgwidth;
      this.f = bpp;
      this.j = hasAlpha;
      this.h = wt;
      this.g = fixedWidth;
      this.i = isSoftAA;
    }

    public override void ReadFontData(FontData fontData, CharFilter filter)
    {
label_2:
      bool isUnicode = true;
      LOGFONT logfont = new LOGFONT();
      GlyphList glyphList = fontData.GetGlyphList();
      Letterer letterer = (Letterer) null;
      ProgressControl.GetInstance().SetStatusString(Strings.IDS_STATUS_READ_WIN);
      ProgressControl.GetInstance().ResetProgressBarPos();
      ProgressControl.GetInstance().SetProgressBarMax(65536);
      logfont.lfHeight = -this.d;
      logfont.lfWidth = this.e;
      logfont.lfEscapement = 0;
      logfont.lfOrientation = 0;
      logfont.lfWeight = 400;
      logfont.lfItalic = (byte) 0;
      logfont.lfUnderline = (byte) 0;
      logfont.lfStrikeOut = (byte) 0;
      logfont.lfCharSet = (byte) 1;
      logfont.lfOutPrecision = (byte) 0;
      logfont.lfClipPrecision = (byte) 0;
      logfont.lfQuality = (byte) 4;
      logfont.lfPitchAndFamily = (byte) 0;
      logfont.lfFaceName = this.c;
      int num1 = 3;
      while (true)
      {
        switch (num1)
        {
          case 0:
            if (this.f <= 4)
            {
              num1 = 6;
              continue;
            }
            goto label_3;
          case 1:
            goto label_6;
          case 2:
            num1 = !this.j ? 5 : 4;
            continue;
          case 3:
            try
            {
              int num2 = 6;
              int num3;
              ushort num4;
              Glyph glyph;
              while (true)
              {
                switch (num2)
                {
                  case 0:
                  case 11:
                    ++num3;
                    num2 = 4;
                    continue;
                  case 1:
                    glyph = new Glyph();
                    num2 = 14;
                    continue;
                  case 2:
                  case 10:
                    letterer.SetOption(isUnicode, this.f, this.j, this.h, this.g);
                    letterer.Create(ref logfont);
                    num3 = 0;
                    num2 = 13;
                    continue;
                  case 3:
                    glyphList.AddGlyph(glyph, num4);
                    num2 = 11;
                    continue;
                  case 4:
                  case 13:
                    num2 = 5;
                    continue;
                  case 5:
                    if (num3 >= 65534)
                    {
                      num2 = 7;
                      continue;
                    }
                    num4 = (ushort) num3;
                    ProgressControl.GetInstance().StepProgressBar();
                    num2 = 9;
                    continue;
                  case 7:
                    num2 = 8;
                    continue;
                  case 8:
                    goto label_38;
                  case 9:
                    if (!filter.IsFiltered(num4))
                    {
                      num2 = 1;
                      continue;
                    }
                    goto case 0;
                  case 12:
                    letterer = (Letterer) new RasterLetterer();
                    num2 = 10;
                    continue;
                  case 14:
                    if (letterer.LetterChar(glyph, num4))
                    {
                      num2 = 3;
                      continue;
                    }
                    glyph = (Glyph) null;
                    num2 = 0;
                    continue;
                  default:
                    if (this.f <= 1)
                    {
                      num2 = 12;
                      continue;
                    }
                    VectorLetterer vectorLetterer = new VectorLetterer();
                    vectorLetterer.SetVectorOption(this.i);
                    letterer = (Letterer) vectorLetterer;
                    num2 = 2;
                    continue;
                }
              }
            }
            finally
            {
              int num2 = 1;
              while (true)
              {
                switch (num2)
                {
                  case 0:
                    letterer.Dispose();
                    num2 = 2;
                    continue;
                  case 2:
                    goto label_32;
                  default:
                    if (letterer != null)
                    {
                      num2 = 0;
                      continue;
                    }
                    goto label_32;
                }
              }
label_32:;
            }
label_38:
            num1 = 2;
            continue;
          case 4:
            num1 = 0;
            continue;
          case 5:
            if (this.f <= 4)
            {
              num1 = 1;
              continue;
            }
            goto label_40;
          case 6:
            goto label_4;
          default:
            goto label_2;
        }
      }
label_3:
      fontData.OutputFormat = new GlyphImageFormat?(GlyphImageFormat.LA8);
      return;
label_4:
      if (1 == 0)
        ;
      fontData.OutputFormat = new GlyphImageFormat?(GlyphImageFormat.LA4);
      return;
label_6:
      fontData.OutputFormat = new GlyphImageFormat?(GlyphImageFormat.A4);
      return;
label_40:
      fontData.OutputFormat = new GlyphImageFormat?(GlyphImageFormat.A8);
    }

    public override void ValidateInput()
    {
      int num = 10;
      FontMap installedFontNames;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_14;
          case 1:
            goto label_7;
          case 2:
            if (this.g <= 0)
            {
              num = 0;
              continue;
            }
            goto label_23;
          case 3:
            goto label_25;
          case 4:
            num = 12;
            continue;
          case 5:
            goto label_6;
          case 6:
            goto label_24;
          case 7:
            num = 2;
            continue;
          case 8:
            num = 8 >= this.f ? 17 : 5;
            continue;
          case 9:
            num = 8;
            continue;
          case 11:
            num = this.d > 0 ? 15 : 6;
            continue;
          case 12:
            num = WidthType.Fixed >= this.h ? 16 : 14;
            continue;
          case 13:
            num = installedFontNames.ContainsKey(this.c) ? 11 : 1;
            continue;
          case 14:
            goto label_13;
          case 15:
            if (this.f >= 1)
            {
              num = 9;
              continue;
            }
            goto label_6;
          case 16:
            if (this.h == WidthType.Fixed)
            {
              if (1 == 0)
                ;
              num = 7;
              continue;
            }
            goto label_28;
          case 17:
            if (this.h >= WidthType.GlyphOnly)
            {
              num = 4;
              continue;
            }
            goto label_13;
          default:
            if (this.c.Length == 0)
            {
              num = 3;
              continue;
            }
            installedFontNames = GlCm.GetInstalledFontNames();
            num = 13;
            continue;
        }
      }
label_6:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_OUTOFRANGE_COLORBPP, (object) this.f);
label_7:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_FONT_NOT_EXISTS, (object) this.c);
label_28:
      return;
label_13:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_INVALID_WIDTH_TYPE, (object) this.h);
label_14:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_UNDERMIN_FIXEDWIDTH, (object) this.g);
label_23:
      return;
label_24:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_UNDERMIN_FONTSIZE, (object) this.d);
label_25:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_FONT_NOT_SPECIFIED);
    }
  }
}
