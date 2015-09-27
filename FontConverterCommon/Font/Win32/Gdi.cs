// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Win32.Gdi
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;
using System.Runtime.InteropServices;

namespace NintendoWare.Font.Win32
{
  public class Gdi
  {
    private const string a = "Gdi32.dll";
    private const string b = "User32.dll";

    [DllImport("Gdi32.dll")]
    public static extern IntPtr SelectObject(IntPtr hdc, IntPtr h);

    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern bool DeleteObject(IntPtr ho);

    [DllImport("Gdi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern IntPtr CreateDC(string driver, string device, string output, [In] object dm);

    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern bool DeleteDC(IntPtr hdc);

    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int cx, int cy);

    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern bool GetCharABCWidthsA(IntPtr hdc, uint wFirst, uint wLast, [Out] ABC[] lpABC);

    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern bool GetCharABCWidthsW(IntPtr hdc, uint wFirst, uint wLast, [Out] ABC[] lpABC);

    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern bool GetCharWidth32A(IntPtr hdc, uint iFirst, uint iLast, [Out] int[] lpBuffer);

    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern bool GetCharWidth32W(IntPtr hdc, uint iFirst, uint iLast, [Out] int[] lpBuffer);

    [DllImport("Gdi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern IntPtr CreateFontIndirect([In] ref LOGFONT lf);

    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern int SetMapMode(IntPtr hdc, int iMode);

    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern uint SetTextAlign(IntPtr hdc, uint align);

    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern bool GetTextMetrics(IntPtr hdc, [Out] TEXTMETRIC lptm);

    [DllImport("Gdi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    public static extern int EnumFontFamiliesEx(IntPtr hdc, [In] ref LOGFONT logfont, [In] FONTENUMPROC lpProc, IntPtr lParam, uint dwFlags);

    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern uint GetGlyphOutlineA(IntPtr hdc, uint uChar, int fuFormat, [Out] GLYPHMETRICS gm, int cjBuffer, [Out] byte[] buffer, [In] MAT2 mat2);

    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern uint GetGlyphOutlineW(IntPtr hdc, uint uChar, int fuFormat, [Out] GLYPHMETRICS gm, int cjBuffer, [Out] byte[] buffer, [In] MAT2 mat2);

    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern uint GetGlyphIndicesA(IntPtr hdc, byte[] str, int c, [Out] ushort[] gi, uint fl);

    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern uint GetGlyphIndicesW(IntPtr hdc, ushort[] str, int c, [Out] ushort[] gi, uint fl);

    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern IntPtr CreateBrushIndirect([In] LOGBRUSH lbrush);

    [DllImport("User32.dll", SetLastError = true)]
    public static extern int FillRect(IntPtr hDC, [In] ref RECT lprc, IntPtr hbr);

    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern int GetDIBits(IntPtr hdc, IntPtr hbm, uint start, uint cLines, [Out] byte[] vBits, [In, Out] BITMAPINFO256 lpbmi, DIB usage);

    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern bool TextOutA(IntPtr hdc, int x, int y, byte[] lpString, int c);

    [DllImport("Gdi32.dll", SetLastError = true)]
    public static extern bool TextOutW(IntPtr hdc, int x, int y, ushort[] lpString, int c);

    public static IntPtr SelectFont(IntPtr hdc, IntPtr hfont)
    {
      return Gdi.SelectObject(hdc, hfont);
    }

    public static bool DeleteFont(IntPtr hfont)
    {
      return Gdi.DeleteObject(hfont);
    }

    public static IntPtr SelectBitmap(IntPtr hdc, IntPtr hbm)
    {
      return Gdi.SelectObject(hdc, hbm);
    }

    public static bool DeleteBitmap(IntPtr hbm)
    {
      return Gdi.DeleteObject(hbm);
    }

    public static COLORREF RGB(byte r, byte g, byte b)
    {
      if (1 == 0)
        ;
      return (COLORREF) ((uint) ((int) r | (int) g << 8 | (int) b << 16));
    }

    public static byte LOBYTE(uint w)
    {
      return (byte) (w & (uint) byte.MaxValue);
    }

    public static byte GetRValue(COLORREF rgb)
    {
      return Gdi.LOBYTE((uint) rgb);
    }

    public static byte GetGValue(COLORREF rgb)
    {
      return Gdi.LOBYTE((uint) rgb >> 8);
    }

    public static byte GetBValue(COLORREF rgb)
    {
      return Gdi.LOBYTE((uint) rgb >> 16);
    }
  }
}
