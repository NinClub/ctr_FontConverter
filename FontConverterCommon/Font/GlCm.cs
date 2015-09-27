// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.GlCm
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Media;

namespace NintendoWare.Font
{
  public class GlCm
  {
    private static GeneralException b = new GeneralException();
    private static readonly uint[] c = new uint[5]
    {
      uint.MaxValue,
      uint.MaxValue,
      932U,
      1252U,
      949U
    };
    private const uint a = 4294967295U;
    public const string VersionDebug = "";

    public static GeneralException ErrMsg(ErrorType type, string formatId, params object[] arg)
    {
      GlCm.b.SetMsgFormat(type, formatId, arg);
      return GlCm.b;
    }

    public static ushort UnicodeToLocal(ushort uni)
    {
      return GlCm.b(0U, uni);
    }

    public static ushort LocalToUnicode(ushort local)
    {
      return GlCm.a(0U, local);
    }

    public static ushort EncodingToUnicode(CharEncoding enc, ushort c)
    {
      uint A_0 = GlCm.c[(int) enc];
      if ((int) A_0 == -1)
        return c;
      if (1 == 0)
        ;
      return GlCm.a(A_0, c);
    }

    public static ushort UnicodeToEncoding(CharEncoding enc, ushort uni)
    {
      uint A_0 = GlCm.c[(int) enc];
      if ((int) A_0 == -1)
        return uni;
      if (1 == 0)
        ;
      return GlCm.b(A_0, uni);
    }

    private static ushort b(uint A_0, ushort A_1)
    {
label_2:
      byte[] lpMultiByteStr = new byte[2];
      bool lpUsedDefaultChar;
      int num1 = Kernel.WideCharToMultiByte(A_0, 1024U, new ushort[1]
      {
        A_1
      }, 1, lpMultiByteStr, lpMultiByteStr.Length, (byte[]) null, out lpUsedDefaultChar);
      int num2 = 7;
      ushort num3;
      int num4;
      while (true)
      {
        switch (num2)
        {
          case 0:
          case 4:
          case 5:
            goto label_14;
          case 1:
            goto label_7;
          case 2:
            switch (num4)
            {
              case -1:
              case 0:
                goto label_8;
              case 1:
                num3 = (ushort) lpMultiByteStr[0];
                num2 = 5;
                continue;
              case 2:
                num3 = (ushort) ((uint) lpMultiByteStr[0] << 8 | (uint) lpMultiByteStr[1]);
                num2 = 0;
                continue;
              default:
                num2 = 6;
                continue;
            }
          case 3:
label_8:
            num3 = ushort.MaxValue;
            num2 = 4;
            continue;
          case 6:
            if (1 == 0)
              ;
            num2 = 3;
            continue;
          case 7:
            if (lpUsedDefaultChar)
            {
              num2 = 1;
              continue;
            }
            num4 = num1;
            num2 = 2;
            continue;
          default:
            goto label_2;
        }
      }
label_7:
      return ushort.MaxValue;
label_14:
      return num3;
    }

    private static ushort a(uint A_0, ushort A_1)
    {
label_2:
      byte[] lpMultiByteStr = new byte[2];
      ushort[] lpWideCharStr = new ushort[1];
      int num1 = 2;
      int cbMultiByte;
      int num2;
      while (true)
      {
        switch (num1)
        {
          case 0:
            if (num2 != 1)
            {
              num1 = 3;
              continue;
            }
            goto label_12;
          case 1:
          case 4:
            num2 = Kernel.MultiByteToWideChar(A_0, 8U, lpMultiByteStr, cbMultiByte, lpWideCharStr, lpWideCharStr.Length);
            num1 = 0;
            continue;
          case 2:
            if ((int) A_1 < 256)
            {
              num1 = 5;
              continue;
            }
            lpMultiByteStr[0] = (byte) ((uint) A_1 >> 8);
            lpMultiByteStr[1] = (byte) A_1;
            cbMultiByte = 2;
            num1 = 4;
            continue;
          case 3:
            goto label_11;
          case 5:
            lpMultiByteStr[0] = (byte) A_1;
            cbMultiByte = 1;
            if (1 == 0)
              ;
            num1 = 1;
            continue;
          default:
            goto label_2;
        }
      }
label_11:
      return ushort.MaxValue;
label_12:
      return lpWideCharStr[0];
    }

    public static IntColor BMP_RGB(byte r, byte g, byte b)
    {
      if (1 == 0)
        ;
      return (IntColor) ((uint) ((int) r << 16 | (int) g << 8) | (uint) b);
    }

    public static IntColor BMP_RGBA(byte r, byte g, byte b, byte a)
    {
      if (1 == 0)
        ;
      return (IntColor) ((uint) a << 24 | (uint) GlCm.BMP_RGB(r, g, b));
    }

    public static uint ExtendBits(uint e, int srcLen, int dstLen)
    {
      if (1 == 0)
        ;
      int num1 = (1 << srcLen) - 1;
      int num2 = (1 << dstLen) - 1;
      return (uint) ((ulong) e * (ulong) num2 / (ulong) num1);
    }

    public static uint ExtractBits(uint e, int right, int len)
    {
      if (1 == 0)
        ;
      return (uint) ((ulong) (e >> right) & (ulong) ((1 << len) - 1));
    }

    public static uint InverseNumber(uint num, int len)
    {
      if (1 == 0)
        ;
      return (uint) ((ulong) ((1 << len) - 1) - (ulong) num);
    }

    public static byte RgbToGrayScale(IntColor c)
    {
      if (1 == 0)
        ;
      return (byte) (((int) (byte) GlCm.ExtractBits((uint) c, 16, 8) + (int) (byte) GlCm.ExtractBits((uint) c, 8, 8) + (int) (byte) GlCm.ExtractBits((uint) c, 0, 8)) / 3);
    }

    public static IntColor GrayScaleToRgb(uint level)
    {
      return GlCm.BMP_RGB((byte) level, (byte) level, (byte) level);
    }

    public static IntColor ColorToUint(Color c)
    {
      if (1 == 0)
        ;
      return GlCm.BMP_RGBA(c.R, c.G, c.B, c.A);
    }

    public static void MakeListFromMapKey<KeyT, ValueT>(List<KeyT> list, Dictionary<KeyT, ValueT> map)
    {
      list.Clear();
      list.Capacity = map.Count;
      using (Dictionary<KeyT, ValueT>.Enumerator enumerator = map.GetEnumerator())
      {
        int num = 1;
        while (true)
        {
          switch (num)
          {
            case 0:
              if (enumerator.MoveNext())
              {
                KeyValuePair<KeyT, ValueT> current = enumerator.Current;
                list.Add(current.Key);
                num = 4;
                continue;
              }
              num = 2;
              continue;
            case 2:
              num = 3;
              continue;
            case 3:
              goto label_10;
            case 4:
              num = 0;
              continue;
            default:
              if (1 == 0)
                goto case 4;
              else
                goto case 4;
          }
        }
      }
label_10:
      list.Sort();
    }

    public static void MakeListFromMapValue<KeyT, ValueT>(List<ValueT> list, Dictionary<KeyT, ValueT> map)
    {
      list.Clear();
      list.Capacity = map.Count;
      using (Dictionary<KeyT, ValueT>.Enumerator enumerator = map.GetEnumerator())
      {
        int num = 3;
        while (true)
        {
          switch (num)
          {
            case 0:
              num = 1;
              continue;
            case 1:
              goto label_9;
            case 4:
              if (enumerator.MoveNext())
              {
                KeyValuePair<KeyT, ValueT> current = enumerator.Current;
                list.Add(current.Value);
                if (1 == 0)
                  ;
                num = 2;
                continue;
              }
              num = 0;
              continue;
            default:
              num = 4;
              continue;
          }
        }
label_9:;
      }
    }

    public static FontMap GetInstalledFontNames()
    {
      if (1 == 0)
        ;
      FontMap fontMap = new FontMap();
      FONTENUMPROC lpProc = (FONTENUMPROC) ((elfe, ntme, fontType, param) =>
      {
label_2:
        string index = elfe.elfLogFont.lfFaceName;
        int num1 = 6;
        while (true)
        {
          int num2;
          switch (num1)
          {
            case 0:
              num1 = 7;
              continue;
            case 1:
              num2 = 0;
              break;
            case 2:
              num2 = 1;
              break;
            case 3:
              num1 = 5;
              continue;
            case 4:
              if ((int) index[0] != 64)
              {
                num1 = 3;
                continue;
              }
              goto label_20;
            case 5:
              if (!fontMap.ContainsKey(index))
              {
                num1 = 0;
                continue;
              }
              goto label_20;
            case 6:
              if (ConverterEnvironment.IsCtr)
              {
                num1 = 9;
                continue;
              }
              goto case 3;
            case 7:
              if (((long) fontType & -2L) == 0L)
              {
                if (1 == 0)
                  ;
                num1 = 1;
                continue;
              }
              num1 = 8;
              continue;
            case 8:
              num1 = 2;
              continue;
            case 9:
              num1 = 4;
              continue;
            case 10:
              goto label_20;
            default:
              goto label_2;
          }
          FontType type = (FontType) num2;
          fontMap[index] = new FontInfo(index, type);
          num1 = 10;
        }
label_20:
        return 1;
      });
      IntPtr dc = Gdi.CreateDC("DISPLAY", (string) null, (string) null, (object) null);
      LOGFONT logfont = new LOGFONT()
      {
        lfCharSet = (byte) 1,
        lfFaceName = string.Empty,
        lfPitchAndFamily = (byte) 0
      };
      Gdi.EnumFontFamiliesEx(dc, ref logfont, lpProc, IntPtr.Zero, 0U);
      Gdi.DeleteDC(dc);
      return fontMap;
    }

    public static IntColor ToColor(string str)
    {
label_2:
      int startIndex = 0;
      int num1 = 3;
      int num2;
      bool flag;
      IntColor intColor;
      while (true)
      {
        switch (num1)
        {
          case 0:
            if (num2 != 6)
            {
              num1 = 7;
              continue;
            }
            uint result;
            flag = uint.TryParse(str.Substring(startIndex), NumberStyles.AllowHexSpecifier, (IFormatProvider) null, out result);
            intColor = GlCm.BMP_RGB((byte) GlCm.ExtractBits(result, 16, 8), (byte) GlCm.ExtractBits(result, 8, 8), (byte) GlCm.ExtractBits(result, 0, 8));
            num1 = 1;
            continue;
          case 1:
            if (!flag)
            {
              if (1 == 0)
                ;
              num1 = 5;
              continue;
            }
            goto label_17;
          case 2:
            ++startIndex;
            num1 = 8;
            continue;
          case 3:
            num1 = !str.StartsWith("0x", StringComparison.InvariantCulture) ? 4 : 9;
            continue;
          case 4:
            if (str.StartsWith("#", StringComparison.InvariantCulture))
            {
              num1 = 2;
              continue;
            }
            goto case 6;
          case 5:
            goto label_10;
          case 6:
          case 8:
            num2 = str.Length - startIndex;
            num1 = 0;
            continue;
          case 7:
            goto label_4;
          case 9:
            startIndex += 2;
            num1 = 6;
            continue;
          default:
            goto label_2;
        }
      }
label_4:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_ILLEGAL_COLOR_FORMAT, (object) str);
label_10:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_ILLEGAL_COLOR_FORMAT, (object) str);
label_17:
      return intColor;
    }

    public static int ROUND_UP(int val, int align)
    {
      if (1 == 0)
        ;
      return val + align - 1 & ~(align - 1);
    }

    public static uint ROUND_UP(uint val, int align)
    {
      if (1 == 0)
        ;
      return (uint) ((ulong) ((long) val + (long) align - 1L) & (ulong) ~(align - 1));
    }

    public static int DIV_UP(int val, int divider)
    {
      return (val + divider - 1) / divider;
    }

    public static uint DIV_UP(uint val, uint divider)
    {
      return (uint) ((int) val + (int) divider - 1) / divider;
    }

    public static int ParseHexNumber(string nptr)
    {
      int result;
      if (int.TryParse(nptr, NumberStyles.AllowHexSpecifier, (IFormatProvider) null, out result))
        return result;
      return 0;
    }

    public static void InitLanguage()
    {
      int num = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (1 == 0)
              break;
            break;
          case 1:
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            num = 2;
            continue;
          case 2:
            goto label_5;
        }
        if (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName != "ja")
          num = 1;
        else
          goto label_7;
      }
label_5:
      return;
label_7:;
    }

    public static string GetProductInfo()
    {
label_2:
      string str = "Font Converter";
      object[] customAttributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof (AssemblyProductAttribute), false);
      int num = 7;
      string execFileName;
      int length;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (customAttributes.Length > 0)
            {
              num = 1;
              continue;
            }
            goto label_14;
          case 1:
            str = string.Empty;
            execFileName = GlCm.GetExecFileName();
            length = execFileName.IndexOf('_');
            num = 3;
            continue;
          case 2:
            str += ((AssemblyProductAttribute) customAttributes[0]).Product;
            num = 4;
            continue;
          case 3:
            if (length != -1)
            {
              num = 5;
              continue;
            }
            goto case 2;
          case 4:
            goto label_14;
          case 5:
            if (1 == 0)
              ;
            str = str + execFileName.Substring(0, length).ToUpperInvariant() + " ";
            num = 2;
            continue;
          case 6:
            num = 0;
            continue;
          case 7:
            if (customAttributes != null)
            {
              num = 6;
              continue;
            }
            goto label_14;
          default:
            goto label_2;
        }
      }
label_14:
      return str;
    }

    public static string GetExecFileName()
    {
      return Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location);
    }

    public static string GetVersionString()
    {
      return GlCm.a() ?? "";
    }

    private static string a()
    {
label_2:
      Version version = Assembly.GetEntryAssembly().GetName().Version;
      int num = 3;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_4;
          case 1:
            goto label_7;
          case 2:
            if (1 == 0)
              ;
            num = 1;
            continue;
          case 3:
            num = version.Revision == 0 ? 0 : 2;
            continue;
          default:
            goto label_2;
        }
      }
label_4:
      string format = "{0}.{1}.{2}";
      goto label_8;
label_7:
      format = "{0}.{1}.{2}.{3}";
label_8:
      return string.Format(format, (object) version.Major, (object) version.Minor, (object) version.Build, (object) version.Revision);
    }
  }
}
