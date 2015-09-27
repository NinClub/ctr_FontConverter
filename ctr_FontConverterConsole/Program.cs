// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Program
// Assembly: ctr_FontConverterConsole, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A31F2A30-66C3-4349-9B59-5CB8C11371A6
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverterConsole.exe

using System;
using System.Collections.Generic;
using System.Text;

namespace NintendoWare.Font
{
  internal class Program
  {
    private const string a = "h";
    private const string b = "i";
    private const string c = "f";
    private const string d = "o";
    private const string e = "ia";
    private const string f = "ic";
    private const string g = "if";
    private const string h = "ig";
    private const string i = "in";
    private const string j = "io";
    private const string k = "isw";
    private const string l = "is";
    private const string m = "it";
    private const string n = "iw";
    private const string o = "oa";
    private const string p = "ob";
    private const string q = "ocb";
    private const string r = "ocg";
    private const string s = "ocm";
    private const string t = "ocw";
    private const string u = "ocn";
    private const string v = "oe";
    private const string w = "of";
    private const string x = "og";
    private const string y = "oh";
    private const string z = "oh";
    private const string aa = "oi";
    private const string ab = "ol";
    private const string ac = "om";
    private const string ad = "on";
    private const string ae = "oo";
    private const string af = "op";
    private const string ag = "or";
    private const string ah = "os";
    private const string ai = "ot";
    private const string aj = "ow";
    private const string ak = "ox";
    private const string al = "bmp";
    private const string am = "image";
    private const string an = "bcfnt";
    private const string ao = "win";
    private const string ap = "lc";
    private const string aq = "bmp";
    private const string ar = "image";
    private const string @as = "bcfnt";
    private const int at = -1;
    private const WidthType au = WidthType.IncludeMargin;
    private const CharEncoding av = CharEncoding.UTF16;
    private const ImageFileFormat aw = ImageFileFormat.Ext;
    private const string ax = "bcfnt";
    private const string ay = "bcfnt";
    private const string az = "image";
    private const string a0 = "image, bcfnt, win";
    private const string a1 = "image, bcfnt";
    private static readonly Program.SymbolicValue[] a2;
    private static readonly Program.SymbolicValue[] a3;
    private static readonly Program.SymbolicValue[] a4;
    private static readonly Program.SymbolicValue[] a5;
    private static readonly CmdLine.OptionDef[] a6;

    private static string InWinFormat
    {
      get
      {
        return !ConverterEnvironment.IsRvl ? "A1, A4, A6, LA1, LA4, LA6" : "I1, I4, I6, IA1, IA4, IA6";
      }
    }

    static Program()
    {
label_2:
      Program.a3 = new Program.SymbolicValue[4]
      {
        new Program.SymbolicValue("glyph", WidthType.GlyphOnly),
        new Program.SymbolicValue("keepsp", WidthType.GlyphOnlyKeepSpace),
        new Program.SymbolicValue("char", WidthType.IncludeMargin),
        new Program.SymbolicValue("fixed", WidthType.Fixed)
      };
      Program.a5 = new Program.SymbolicValue[3]
      {
        new Program.SymbolicValue("bmp", ImageFileFormat.Bmp),
        new Program.SymbolicValue("tga", ImageFileFormat.Tga),
        new Program.SymbolicValue("ext", ImageFileFormat.Ext)
      };
      Program.a6 = new CmdLine.OptionDef[36]
      {
        new CmdLine.OptionDef("h", CmdLine.Option.None),
        new CmdLine.OptionDef("i", CmdLine.Option.One),
        new CmdLine.OptionDef("f", CmdLine.Option.One),
        new CmdLine.OptionDef("o", CmdLine.Option.One),
        new CmdLine.OptionDef("if", CmdLine.Option.One),
        new CmdLine.OptionDef("io", CmdLine.Option.One),
        new CmdLine.OptionDef("ic", CmdLine.Option.One),
        new CmdLine.OptionDef("in", CmdLine.Option.One),
        new CmdLine.OptionDef("is", CmdLine.Option.One),
        new CmdLine.OptionDef("isw", CmdLine.Option.One),
        new CmdLine.OptionDef("it", CmdLine.Option.LTOne),
        new CmdLine.OptionDef("iw", CmdLine.Option.One),
        new CmdLine.OptionDef("ia", CmdLine.Option.None),
        new CmdLine.OptionDef("of", CmdLine.Option.One),
        new CmdLine.OptionDef("oo", CmdLine.Option.One),
        new CmdLine.OptionDef("og", CmdLine.Option.None),
        new CmdLine.OptionDef("oa", CmdLine.Option.One),
        new CmdLine.OptionDef("oh", CmdLine.Option.One),
        new CmdLine.OptionDef("ot", CmdLine.Option.One),
        new CmdLine.OptionDef("ob", CmdLine.Option.One),
        new CmdLine.OptionDef("ol", CmdLine.Option.One),
        new CmdLine.OptionDef("or", CmdLine.Option.One),
        new CmdLine.OptionDef("ow", CmdLine.Option.One),
        new CmdLine.OptionDef("oe", CmdLine.Option.One),
        new CmdLine.OptionDef("oh", CmdLine.Option.One),
        new CmdLine.OptionDef("om", CmdLine.Option.One),
        new CmdLine.OptionDef("on", CmdLine.Option.One),
        new CmdLine.OptionDef("oi", CmdLine.Option.One),
        new CmdLine.OptionDef("op", CmdLine.Option.One),
        new CmdLine.OptionDef("ox", CmdLine.Option.One),
        new CmdLine.OptionDef("os", CmdLine.Option.One),
        new CmdLine.OptionDef("ocb", CmdLine.Option.One),
        new CmdLine.OptionDef("ocg", CmdLine.Option.One),
        new CmdLine.OptionDef("ocm", CmdLine.Option.One),
        new CmdLine.OptionDef("ocw", CmdLine.Option.One),
        new CmdLine.OptionDef("ocn", CmdLine.Option.One)
      };
      List<Program.SymbolicValue> list = new List<Program.SymbolicValue>();
      list.Add(new Program.SymbolicValue("sjis", CharEncoding.SJIS));
      int num = 4;
      while (true)
      {
        string str1;
        string str2;
        switch (num)
        {
          case 0:
            num = ConverterEnvironment.IsRvl ? 5 : 6;
            continue;
          case 1:
          case 14:
            goto label_23;
          case 2:
            str1 = "IA";
            goto label_20;
          case 3:
            str1 = "LA";
            goto label_20;
          case 4:
            if (ConverterEnvironment.IsCtr)
            {
              num = 7;
              continue;
            }
            list.Add(new Program.SymbolicValue("utf8", CharEncoding.UTF8));
            list.Add(new Program.SymbolicValue("utf16", CharEncoding.UTF16));
            num = 12;
            continue;
          case 5:
            str2 = "I";
            break;
          case 6:
            if (1 == 0)
              ;
            num = 10;
            continue;
          case 7:
            list.Add(new Program.SymbolicValue("uincode", CharEncoding.UTF16));
            num = 13;
            continue;
          case 8:
            num = 3;
            continue;
          case 9:
            if (!ConverterEnvironment.IsRvl)
            {
              list.Add(new Program.SymbolicValue("RGB5A1", GlyphImageFormat.RGB5A1));
              list.Add(new Program.SymbolicValue("RGBA4", GlyphImageFormat.RGBA4));
              list.Add(new Program.SymbolicValue("RGB8", GlyphImageFormat.RGB8));
              num = 14;
              continue;
            }
            num = 11;
            continue;
          case 10:
            str2 = "A";
            break;
          case 11:
            list.Add(new Program.SymbolicValue("RGB5A3", GlyphImageFormat.RGB5A3));
            num = 1;
            continue;
          case 12:
          case 13:
            list.Add(new Program.SymbolicValue("cp1252", CharEncoding.CP1252));
            Program.a2 = list.ToArray();
            list.Clear();
            num = 0;
            continue;
          case 15:
            num = ConverterEnvironment.IsRvl ? 2 : 8;
            continue;
          default:
            goto label_2;
        }
        string str3 = str2;
        num = 15;
        continue;
label_20:
        string str4 = str1;
        list.Add(new Program.SymbolicValue(str3 + "4", GlyphImageFormat.A4));
        list.Add(new Program.SymbolicValue(str3 + "8", GlyphImageFormat.A8));
        list.Add(new Program.SymbolicValue(str4 + "4", GlyphImageFormat.LA4));
        list.Add(new Program.SymbolicValue(str4 + "8", GlyphImageFormat.LA8));
        list.Add(new Program.SymbolicValue("RGB565", GlyphImageFormat.RGB565));
        num = 9;
      }
label_23:
      list.Add(new Program.SymbolicValue("RGBA8", GlyphImageFormat.RGBA8));
      Program.a4 = list.ToArray();
    }

    public static int Main(string[] args)
    {
      GlCm.InitLanguage();
      CommandLineProgressControl.CreateInstance();
      FontData fontData = new FontData();
      CharFilter filter = new CharFilter();
      GlyphOrder order = new GlyphOrder();
      FontReader fontReader = (FontReader) null;
      FontWriter fontWriter = (FontWriter) null;
      Rpt.InitForConsole();
      int num1;
      try
      {
label_5:
        CmdLine A_0 = new CmdLine(Environment.CommandLine, Program.a6, Program.a6.Length);
        int num2 = 9;
        while (true)
        {
          switch (num2)
          {
            case 0:
              Program.d();
              num1 = 1;
              num2 = 11;
              continue;
            case 1:
              filter.Load(A_0["f"]);
              num2 = 4;
              continue;
            case 2:
              if (A_0.Exists("f"))
              {
                num2 = 1;
                continue;
              }
              goto case 4;
            case 3:
              filter.CheckEqual(fontData);
              num2 = 10;
              continue;
            case 4:
              filter.SetOrder(order);
              fontReader.ReadFontData(fontData, filter);
              num2 = 7;
              continue;
            case 5:
              goto label_1;
            case 6:
              if (A_0.Exists("h"))
              {
                num2 = 0;
                continue;
              }
              fontReader = Program.b(A_0);
              fontWriter = Program.a(A_0);
              fontReader.ValidateInput();
              fontWriter.ValidateInput();
              fontWriter.GetGlyphOrder(order);
              num2 = 2;
              continue;
            case 7:
              if (A_0.Exists("f"))
              {
                num2 = 3;
                continue;
              }
              goto case 10;
            case 8:
              num2 = 6;
              continue;
            case 9:
              if (A_0.GetNum() != 0)
              {
                num2 = 8;
                continue;
              }
              goto case 0;
            case 10:
              fontData.ReflectGlyph();
              fontWriter.WriteFontData(fontData, order);
              num2 = 5;
              continue;
            case 11:
              goto label_22;
            default:
              goto label_5;
          }
        }
      }
      catch (GeneralException ex)
      {
        Console.Error.Write(Strings.IDS_ERROR_MSG, (object) ex.GetMsg());
        num1 = 2;
        goto label_22;
      }
label_1:
      if (1 == 0)
        ;
      return 0;
label_22:
      return num1;
    }

    private static int a(Program.SymbolicValue[] A_0, string A_1, int A_2)
    {
label_2:
      Program.SymbolicValue[] symbolicValueArray = A_0;
      int index = 0;
      int num1 = 3;
      Program.SymbolicValue symbolicValue;
      int num2;
      while (true)
      {
        switch (num1)
        {
          case 0:
            goto label_10;
          case 1:
            if (!string.Equals(A_1, symbolicValue.Symbol, StringComparison.OrdinalIgnoreCase))
            {
              ++index;
              num1 = 2;
              continue;
            }
            num1 = 4;
            continue;
          case 2:
          case 3:
            num1 = 5;
            continue;
          case 4:
            num2 = symbolicValue.Value;
            num1 = 6;
            continue;
          case 5:
            if (index >= symbolicValueArray.Length)
            {
              num1 = 0;
              continue;
            }
            symbolicValue = symbolicValueArray[index];
            num1 = 1;
            continue;
          case 6:
            goto label_13;
          default:
            goto label_2;
        }
      }
label_10:
      if (1 == 0)
        ;
      return A_2;
label_13:
      return num2;
    }

    private static void d()
    {
      Console.WriteLine(GlCm.GetProductInfo() + " - Version {0}", (object) GlCm.GetVersionString());
      Program.b();
    }

    private static WidthType e(string A_0)
    {
      WidthType widthType = (WidthType) Program.a(Program.a3, A_0, 4);
      if (widthType == WidthType.NUM)
        throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_UNKNOWN_WIDTH_TYPE, (object) A_0);
      if (1 == 0)
        ;
      return widthType;
    }

    private static ushort a(string A_0, CharEncoding A_1)
    {
      int num1 = 1;
      ushort c;
      ushort num2;
      while (true)
      {
        switch (num1)
        {
          case 0:
            if ((int) num2 == (int) ushort.MaxValue)
            {
              if (1 == 0)
                ;
              num1 = 4;
              continue;
            }
            goto label_10;
          case 2:
            num2 = (ushort) A_0[0];
            num1 = 3;
            continue;
          case 3:
            goto label_10;
          case 4:
            goto label_4;
          default:
            if (A_0.Length == 1)
            {
              num1 = 2;
              continue;
            }
            c = (ushort) GlCm.ParseHexNumber(A_0);
            num2 = GlCm.EncodingToUnicode(A_1, c);
            num1 = 0;
            continue;
        }
      }
label_4:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_ALTER_TO_UNICODE, (object) c);
label_10:
      return num2;
    }

    private static CharEncoding d(string A_0)
    {
      CharEncoding charEncoding = (CharEncoding) Program.a(Program.a2, A_0, 4);
      if (charEncoding == CharEncoding.NUM)
      {
        if (1 == 0)
          ;
        throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_UNKNOWN_ENCODING, (object) A_0);
      }
      return charEncoding;
    }

    private static GlyphImageFormat c(string A_0)
    {
      int num1 = 2;
      int num2;
      while (true)
      {
        switch (num1)
        {
          case 0:
            if (num2 == -1)
            {
              num1 = 3;
              continue;
            }
            goto label_10;
          case 1:
            goto label_9;
          case 3:
            goto label_5;
          default:
            if (1 == 0)
              ;
            if (A_0 == string.Empty)
            {
              num1 = 1;
              continue;
            }
            num2 = Program.a(Program.a4, A_0, -1);
            num1 = 0;
            continue;
        }
      }
label_5:
      throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_UNKNONW_COLOR_FORMAT, (object) A_0);
label_9:
      throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_NO_COLOR_FORMAT);
label_10:
      return (GlyphImageFormat) num2;
    }

    private static ImageFileFormat b(string A_0)
    {
      ImageFileFormat imageFileFormat = (ImageFileFormat) Program.a(Program.a5, A_0, 3);
      if (imageFileFormat == ImageFileFormat.NUM)
      {
        if (1 == 0)
          ;
        throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_UNKNOWN_IMAGE_FORMAT_STR, (object) A_0);
      }
      return imageFileFormat;
    }

    private static void a(out int A_0, out int A_1, string A_2)
    {
      string[] strArray = A_2.Split('x');
      if (strArray.Length == 2)
      {
        if (1 == 0)
          ;
        try
        {
          A_0 = int.Parse(strArray[0]);
          A_1 = int.Parse(strArray[1]);
          return;
        }
        catch (FormatException ex)
        {
        }
        catch (OverflowException ex)
        {
        }
      }
      throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_INVALID_SHEET_SIZE_FORMAT);
    }

    private static void a(string A_0, out int A_1, out bool A_2)
    {
label_2:
      int length = A_0.Length;
      int num = 1;
      while (true)
      {
        switch (num)
        {
          case 0:
            num = 8;
            continue;
          case 1:
            switch (length)
            {
              case 0:
                goto label_15;
              case 1:
                goto label_27;
              case 2:
                num = 9;
                continue;
              case 3:
                num = 2;
                continue;
              default:
                num = 13;
                continue;
            }
          case 2:
            if ((int) char.ToUpperInvariant(A_0[0]) != 73)
            {
              num = 14;
              continue;
            }
            goto case 0;
          case 3:
            if (A_1 >= 1)
            {
              num = 16;
              continue;
            }
            goto label_17;
          case 4:
            goto label_16;
          case 5:
            if (8 < A_1)
            {
              num = 17;
              continue;
            }
            goto label_35;
          case 6:
            goto label_27;
          case 7:
          case 15:
            num = 3;
            continue;
          case 8:
            if ((int) char.ToUpperInvariant(A_0[1]) == 65)
            {
              A_1 = (int) A_0[2] - 48;
              A_2 = true;
              num = 7;
              continue;
            }
            num = 4;
            continue;
          case 9:
            if ((int) char.ToUpperInvariant(A_0[0]) != 73)
            {
              num = 18;
              continue;
            }
            break;
          case 10:
            if ((int) char.ToUpperInvariant(A_0[0]) == 76)
            {
              num = 0;
              continue;
            }
            goto label_16;
          case 11:
            goto label_28;
          case 12:
            if ((int) char.ToUpperInvariant(A_0[0]) != 65)
            {
              num = 11;
              continue;
            }
            break;
          case 13:
            if (1 == 0)
              ;
            num = 6;
            continue;
          case 14:
            num = 10;
            continue;
          case 16:
            num = 5;
            continue;
          case 17:
            goto label_17;
          case 18:
            num = 12;
            continue;
          default:
            goto label_2;
        }
        A_1 = (int) A_0[1] - 48;
        A_2 = false;
        num = 15;
      }
label_15:
      throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_NO_FORMAT);
label_16:
      throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_ILLEGAL_FORMAT_SYNTAX, (object) A_0);
label_17:
      throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_ILLEGAL_FORMAT_SYNTAX, (object) A_0);
label_35:
      return;
label_27:
      throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_ILLEGAL_FORMAT_SYNTAX, (object) A_0);
label_28:
      throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_ILLEGAL_FORMAT_SYNTAX, (object) A_0);
    }

    private static FontReader b(CmdLine A_0)
    {
      int num1 = 19;
      int avgwidth;
      int A_1;
      bool A_2;
      WidthType wt;
      while (true)
      {
        int num2;
        switch (num1)
        {
          case 0:
            goto label_25;
          case 1:
            num1 = A_0.Exists("it") ? 6 : 21;
            continue;
          case 2:
            num1 = Program.a(A_0["i"], "bcfnt") != 0 ? 14 : 4;
            continue;
          case 3:
            goto label_11;
          case 4:
            goto label_10;
          case 5:
            goto label_31;
          case 6:
            num2 = (int) Program.e(A_0["it"]);
            break;
          case 7:
            if (wt == WidthType.Fixed)
            {
              num1 = 20;
              continue;
            }
            goto label_22;
          case 8:
            avgwidth = A_0.Number("isw", 0);
            num1 = 3;
            continue;
          case 9:
            goto label_30;
          case 10:
            if (!A_0.Exists("iw"))
            {
              num1 = 15;
              continue;
            }
            goto label_22;
          case 11:
            num1 = A_0.Exists("is") ? 7 : 0;
            continue;
          case 12:
            if (A_0.Exists("isw"))
            {
              num1 = 8;
              continue;
            }
            goto label_11;
          case 13:
            if (A_0["i"].Length == 0)
            {
              num1 = 9;
              continue;
            }
            goto label_33;
          case 14:
            num1 = Program.a(A_0["i"], "win") != 0 ? 13 : 16;
            continue;
          case 15:
            goto label_8;
          case 16:
            num1 = 1;
            continue;
          case 17:
            num1 = Program.a(A_0["i"], "image") != 0 ? 2 : 5;
            continue;
          case 18:
            num1 = 17;
            continue;
          case 20:
            num1 = 10;
            continue;
          case 21:
            num1 = 22;
            continue;
          case 22:
            num2 = 2;
            break;
          default:
            if (1 == 0)
              ;
            if (Program.a(A_0["i"], "bmp") != 0)
            {
              num1 = 18;
              continue;
            }
            goto label_31;
        }
        wt = (WidthType) num2;
        Program.a(A_0["ic"], out A_1, out A_2);
        num1 = 11;
        continue;
label_22:
        avgwidth = 0;
        num1 = 12;
      }
label_8:
      throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_FIXED_WIDTH_NOT_SPECIFIED);
label_10:
      return (FontReader) new NitroFontReader(A_0["if"]);
label_11:
      return (FontReader) new WinFontReader(A_0["in"], A_0.Number("is", -1), avgwidth, A_1, A_2, wt, A_0.Number("iw", -1), A_0.Exists("ia"));
label_25:
      throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_FONT_SIZE_NOT_SPECIFIED);
label_30:
      throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_REQUIRE_INPUT_FORMAT);
label_31:
      return (FontReader) new ImageFontReader(A_0["if"], A_0["io"], Program.c(A_0["ic"]), A_0.Exists("ia"));
label_33:
      throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_UNKNOWN_INPUT_FORMAT, (object) A_0["i"]);
    }

    private static FontWriter a(CmdLine A_0)
    {
      int num1 = 44;
      string file;
      string order;
      bool isDrawGrid;
      int cellWidth;
      int cellHeight;
      int num2;
      int marginRight;
      int num3;
      int marginBottom;
      ImageFileFormat format;
      IntColor intColor1;
      IntColor intColor2;
      IntColor intColor3;
      IntColor intColor4;
      CharEncoding charEncoding;
      int sheetPixels;
      int A_0_1;
      int A_1;
      while (true)
      {
        bool flag;
        int num4;
        IntColor intColor5;
        int num5;
        IntColor intColor6;
        IntColor intColor7;
        IntColor intColor8;
        int num6;
        switch (num1)
        {
          case 0:
            num1 = 49;
            continue;
          case 1:
            goto label_54;
          case 2:
            num1 = 54;
            continue;
          case 3:
            num4 = A_0.Exists("oh") ? 1 : 0;
            break;
          case 4:
            goto label_72;
          case 5:
            num1 = A_0.Exists("ocg") ? 17 : 2;
            continue;
          case 6:
            intColor5 = GlCm.ColorToUint(FB.BackgroundColor);
            goto label_35;
          case 7:
            num1 = A_0.Exists("oe") ? 38 : 19;
            continue;
          case 8:
            goto label_77;
          case 9:
            if (A_0["o"].Length == 0)
            {
              num1 = 8;
              continue;
            }
            goto label_78;
          case 10:
            sheetPixels = A_0.Number("os", 0) * 1024;
            num1 = 59;
            continue;
          case 11:
            cellWidth = A_0.Number("ow", -1);
            cellHeight = A_0.Number("oh", -1);
            num2 = A_0.Number("ol", -1);
            num3 = A_0.Number("ot", -1);
            num1 = 51;
            continue;
          case 12:
            num1 = A_0.Exists("ow") ? 34 : 42;
            continue;
          case 13:
            num1 = !A_0.Exists("os") ? 36 : 10;
            continue;
          case 14:
            num5 = (int) Program.b(A_0["oi"]);
            goto label_30;
          case 15:
            num1 = A_0.Exists("ocb") ? 20 : 16;
            continue;
          case 16:
            num1 = 6;
            continue;
          case 17:
            intColor6 = GlCm.ToColor(A_0["ocg"]);
            goto label_40;
          case 18:
            intColor7 = GlCm.ColorToUint(FB.WidthBarColor);
            goto label_50;
          case 19:
            num1 = 50;
            continue;
          case 20:
            intColor5 = GlCm.ToColor(A_0["ocb"]);
            goto label_35;
          case 21:
            ProgressControl.Warning(Strings.IDS_WARN_OW_OH_OR);
            num1 = 37;
            continue;
          case 22:
            intColor7 = GlCm.ToColor(A_0["ocw"]);
            goto label_50;
          case 23:
            A_0_1 = 0;
            A_1 = 0;
            Program.a(out A_0_1, out A_1, A_0["ox"]);
            num1 = 28;
            continue;
          case 24:
            file = A_0["of"];
            order = A_0["oo"];
            isDrawGrid = !A_0.Exists("og");
            cellWidth = -1;
            cellHeight = -1;
            num2 = 0;
            marginRight = 0;
            num3 = 0;
            marginBottom = 0;
            num1 = 12;
            continue;
          case 25:
            intColor8 = GlCm.ColorToUint(FB.MarginColor);
            goto label_45;
          case 26:
            if (A_0.Exists("or"))
            {
              num1 = 21;
              continue;
            }
            goto case 37;
          case 27:
            num1 = 18;
            continue;
          case 28:
            goto label_68;
          case 29:
            ProgressControl.Warning(Strings.IDS_WARN_OW_OH_OB);
            num1 = 11;
            continue;
          case 30:
            num1 = 32;
            continue;
          case 31:
            num1 = A_0.Exists("oa") ? 46 : 39;
            continue;
          case 32:
            goto label_53;
          case 33:
            num1 = A_0.Exists("oi") ? 14 : 41;
            continue;
          case 34:
            num4 = 1;
            break;
          case 35:
            num5 = 0;
            goto label_30;
          case 36:
            if (A_0.Exists("ox"))
            {
              num1 = 23;
              continue;
            }
            goto case 59;
          case 37:
            num1 = 45;
            continue;
          case 38:
            num6 = (int) Program.d(A_0["oe"]);
            goto label_62;
          case 39:
            num1 = 4;
            continue;
          case 40:
            intColor8 = GlCm.ToColor(A_0["ocm"]);
            goto label_45;
          case 41:
            if (1 == 0)
              ;
            num1 = 35;
            continue;
          case 42:
            num1 = 3;
            continue;
          case 43:
            num1 = Program.a(A_0["o"], "bcfnt") != 0 ? 9 : 58;
            continue;
          case 45:
            if (A_0.Exists("ob"))
            {
              num1 = 29;
              continue;
            }
            goto case 11;
          case 46:
            goto label_73;
          case 47:
            num1 = 25;
            continue;
          case 48:
            if (flag)
            {
              num1 = 57;
              continue;
            }
            num2 = A_0.Number("ol", 0);
            num3 = A_0.Number("ot", 0);
            marginRight = A_0.Number("or", num2);
            marginBottom = A_0.Number("ob", num3);
            num1 = 53;
            continue;
          case 49:
            num1 = Program.a(A_0["o"], "image") != 0 ? 43 : 24;
            continue;
          case 50:
            num6 = 1;
            goto label_62;
          case 51:
          case 53:
            num1 = 33;
            continue;
          case 52:
            num1 = A_0.Exists("ocn") ? 1 : 30;
            continue;
          case 54:
            intColor6 = GlCm.ColorToUint(FB.GridColor);
            goto label_40;
          case 55:
            num1 = A_0.Exists("ocw") ? 22 : 27;
            continue;
          case 56:
            num1 = A_0.Exists("ocm") ? 40 : 47;
            continue;
          case 57:
            num1 = 26;
            continue;
          case 58:
            num1 = 7;
            continue;
          case 59:
            num1 = 31;
            continue;
          default:
            if (Program.a(A_0["o"], "bmp") != 0)
            {
              num1 = 0;
              continue;
            }
            goto case 24;
        }
        flag = num4 != 0;
        num1 = 48;
        continue;
label_30:
        format = (ImageFileFormat) num5;
        num1 = 15;
        continue;
label_35:
        intColor1 = intColor5;
        num1 = 5;
        continue;
label_40:
        intColor2 = intColor6;
        num1 = 56;
        continue;
label_45:
        intColor3 = intColor8;
        num1 = 55;
        continue;
label_50:
        intColor4 = intColor7;
        num1 = 52;
        continue;
label_62:
        charEncoding = (CharEncoding) num6;
        sheetPixels = 0;
        num1 = 13;
      }
label_53:
      IntColor intColor9 = GlCm.ColorToUint(FB.NullBlockColor);
      goto label_55;
label_54:
      intColor9 = GlCm.ToColor(A_0["ocn"]);
label_55:
      IntColor intColor10 = intColor9;
      return (FontWriter) new ImageFontWriter(file, order, format, isDrawGrid, cellWidth, cellHeight, num2, num3, marginRight, marginBottom, (uint) intColor2, (uint) intColor3, (uint) intColor4, (uint) intColor10, (uint) intColor1);
label_68:
      return (FontWriter) new NitroFontWriter(A_0["of"], A_0["op"], GlyphDataType.Texture, A_0.Exists("oa") ? Program.a(A_0["oa"], charEncoding) : ushort.MaxValue, A_0.Number("oh", (int) ushort.MaxValue), A_0.Number("ow", (int) ushort.MaxValue), A_0.Number("ol", (int) ushort.MaxValue), A_0.Number("or", (int) ushort.MaxValue), charEncoding, A_0_1, A_1);
label_72:
      int num7 = (int) ushort.MaxValue;
      goto label_74;
label_73:
      num7 = (int) Program.a(A_0["oa"], charEncoding);
label_74:
      ushort alter = (ushort) num7;
      return (FontWriter) new NitroFontWriter(A_0["of"], A_0["op"], GlyphDataType.Texture, alter, A_0.Number("oh", (int) ushort.MaxValue), A_0.Number("ow", (int) ushort.MaxValue), A_0.Number("ol", (int) ushort.MaxValue), A_0.Number("or", (int) ushort.MaxValue), charEncoding, sheetPixels);
label_77:
      throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_REQUIRE_OUTPUT_FORMAT);
label_78:
      throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_UNKNOWN_OUTPUT_FORMAT, (object) A_0["o"]);
    }

    private static int a(string A_0, string A_1)
    {
      return string.Compare(A_0, A_1, StringComparison.InvariantCulture);
    }

    private static void b()
    {
label_2:
      if (1 == 0)
        ;
      Program.a(Strings.UsageTitile);
      Program.a(string.Format("  {0} -i <in_fmt> <in_opt> -o <out_fmt> <out_opt> [-f <filter>]", (object) GlCm.GetExecFileName()));
      Program.a();
      Program.a(" -i <in_fmt>              " + string.Format(Strings.UsageInputFormat, (object) "image, bcfnt, win"));
      Program.a(" -o <out_fmt>             " + string.Format(Strings.UsageOutputFormat, (object) "image, bcfnt"));
      Program.a(" -f <filter>              " + Strings.UsageCharacterFilterFile);
      Program.a();
      Program.a(string.Format(Strings.UsageOptionPatterns, (object) "in_opt", (object) "in_fmt"));
      Program.a(" -i " + string.Format(Strings.UsageInputCase, (object) "image"));
      Program.a("   -if <image>            " + Strings.UsageImageFile);
      Program.a("   -io <order>            " + Strings.UsageCharacterOrderFile);
      string str1 = Program.a(Program.a4);
      Program.a("   -ic <format>           " + string.Format(Strings.UsageTextureFormat1, (object) str1));
      Program.a("                          " + string.Format(Strings.UsageTextureFormat2, (object) str1));
      Program.a("   -ia                    " + Strings.UsageEnableLinearInterpolation);
      Program.a();
      Program.a(" -i " + string.Format(Strings.UsageInputCase, (object) "bcfnt"));
      Program.a("   -if <bcfnt>            " + string.Format(Strings.UsageFontBinaryFile, (object) "bcfnt"));
      Program.a();
      Program.a(" -i " + string.Format(Strings.UsageInputCase, (object) "win"));
      Program.a("   -in <name>             " + Strings.UsageFontName);
      Program.a("   -is <size>             " + Strings.UsageFontSize);
      Program.a("   -isw <width>           " + Strings.UsageAverageWidth);
      Program.a("   -ic <format>           " + string.Format(Strings.UsageTextureFormat1, (object) Program.InWinFormat));
      Program.a("                          " + string.Format(Strings.UsageTextureFormat2, (object) Program.InWinFormat));
      Program.a("   -ia                    " + Strings.UsageUseSoftAntialias);
      string str2 = Program.a(Program.a3);
      Program.a(string.Format("   -it <type={0}>        ", (object) Program.a(Program.a3, 2)) + string.Format(Strings.UsageGlyphWidth1, (object) str2));
      Program.a("                          " + string.Format(Strings.UsageGlyphWidth2, (object) str2));
      Program.a("   -iw <width>            " + Strings.UsageFixedWidth);
      Program.a();
      Program.a(string.Format(Strings.UsageOptionPatterns, (object) "out_opt", (object) "out_fmt"));
      Program.a(" -o " + string.Format(Strings.UsageInputCase, (object) "image"));
      Program.a("   -of <image>            " + Strings.UsageImageFile);
      Program.a("   -oo <order>            " + Strings.UsageCharacterOrderFile);
      string str3 = Program.a(Program.a5);
      Program.a(string.Format("   -oi <format={0}>       ", (object) Program.a(Program.a5, 0)) + string.Format(Strings.UsageImageFileFormat1, (object) str3));
      Program.a("                          " + string.Format(Strings.UsageImageFileFormat2, (object) str3));
      Program.a("   -og                    " + Strings.UsageDontDrawGrid);
      Program.a("   -ow <width>            " + Strings.UsageCellWidth);
      Program.a("   -oh <height>           " + Strings.UsageCellHeight);
      Program.a("   -ot <top=0>            " + Strings.UsageCellTopMarginWidth);
      Program.a("   -ob <bottom=top>       " + Strings.UsageCellBottomMarginWidth);
      Program.a("   -ol <left=0>           " + Strings.UsageCellLeftMarginWidth);
      Program.a("   -or <right=left>       " + Strings.UsageCellRightMarginWidth);
      Program.a("   -ocg <color=000000>    " + Strings.UsageGridColor);
      Program.a("   -ocm <color=99AA99>    " + Strings.UsageMarginColor);
      Program.a("   -ocw <color=FF0000>    " + Strings.UsageWidthLineColor);
      Program.a("   -ocn <color=FF7F7F>    " + Strings.UsageNullCellColor);
      Program.a();
      Program.a(" -o " + string.Format(Strings.UsageInputCase, (object) "bcfnt"));
      Program.a("   -of <bcfnt>            " + string.Format(Strings.UsageFontBinaryFile, (object) "bcfnt"));
      string str4 = Program.a(Program.a2);
      int num = 1;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_5;
          case 1:
            num = ConverterEnvironment.IsCtr ? 0 : 3;
            continue;
          case 2:
            goto label_7;
          case 3:
            num = 2;
            continue;
          default:
            goto label_2;
        }
      }
label_5:
      string str5 = Strings.StrCharacterCode;
      goto label_8;
label_7:
      str5 = Strings.StrEncoding;
label_8:
      string str6 = str5;
      Program.a(string.Format("   -oe <encoding={0}>   ", (object) Program.a(Program.a2, 1)) + string.Format(Strings.UsageCharacterEncoding1, (object) str6));
      Program.a("                          " + string.Format(Strings.UsageCharacterEncoding2, (object) str4));
      Program.a("   -op <glyphgroup>       " + Strings.UsageGlhphGroupFile);
      Program.a("   -os <sheetsize>        " + Strings.UsageKPixelUnitSheetSize);
      Program.a("   -oa <char code>        " + Strings.UsageAlternateCharacter);
      Program.a("   -oh <linefeed>         " + Strings.UsageLinefeed);
      Program.a("   -ol <left>             " + Strings.UsageDefaultLeftSpace);
      Program.a("   -ow <width>            " + Strings.UsageDefaultWidth);
      Program.a("   -or <left>             " + Strings.UsageDefaultRightSpace);
    }

    private static void a(string A_0)
    {
      Console.WriteLine(A_0);
    }

    private static void a()
    {
      Console.WriteLine();
    }

    private static string a(Program.SymbolicValue[] A_0)
    {
label_2:
      StringBuilder stringBuilder = new StringBuilder();
      Program.SymbolicValue[] symbolicValueArray = A_0;
      int index = 0;
      int num = 4;
      Program.SymbolicValue symbolicValue;
      while (true)
      {
        switch (num)
        {
          case 0:
            stringBuilder.Append(", ");
            num = 3;
            continue;
          case 1:
          case 4:
            num = 2;
            continue;
          case 2:
            if (index < symbolicValueArray.Length)
            {
              symbolicValue = symbolicValueArray[index];
              num = 6;
              continue;
            }
            num = 5;
            continue;
          case 3:
            stringBuilder.Append(symbolicValue.Symbol);
            ++index;
            if (1 == 0)
              ;
            num = 1;
            continue;
          case 5:
            goto label_12;
          case 6:
            if (stringBuilder.Length > 0)
            {
              num = 0;
              continue;
            }
            goto case 3;
          default:
            goto label_2;
        }
      }
label_12:
      return stringBuilder.ToString();
    }

    private static string a(Program.SymbolicValue[] A_0, int A_1)
    {
label_2:
      Program.SymbolicValue[] symbolicValueArray = A_0;
      int index = 0;
      int num = 0;
      Program.SymbolicValue symbolicValue;
      string str;
      while (true)
      {
        switch (num)
        {
          case 0:
          case 4:
            num = 2;
            continue;
          case 1:
            if (symbolicValue.Value != A_1)
            {
              if (1 == 0)
                ;
              ++index;
              num = 4;
              continue;
            }
            num = 6;
            continue;
          case 2:
            if (index >= symbolicValueArray.Length)
            {
              num = 5;
              continue;
            }
            symbolicValue = symbolicValueArray[index];
            num = 1;
            continue;
          case 3:
            goto label_13;
          case 5:
            goto label_11;
          case 6:
            str = symbolicValue.Symbol;
            num = 3;
            continue;
          default:
            goto label_2;
        }
      }
label_11:
      return (string) null;
label_13:
      return str;
    }

    private class SymbolicValue
    {
      public readonly string Symbol;
      public readonly int Value;

      public SymbolicValue(string symbol, CharEncoding value)
      {
        this.Symbol = symbol;
        this.Value = (int) value;
      }

      public SymbolicValue(string symbol, WidthType value)
      {
        this.Symbol = symbol;
        this.Value = (int) value;
      }

      public SymbolicValue(string symbol, GlyphImageFormat value)
      {
        this.Symbol = symbol;
        this.Value = (int) value;
      }

      public SymbolicValue(string symbol, ImageFileFormat value)
      {
        this.Symbol = symbol;
        this.Value = (int) value;
      }
    }
  }
}
