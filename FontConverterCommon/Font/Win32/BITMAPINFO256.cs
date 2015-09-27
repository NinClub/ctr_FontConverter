// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Win32.BITMAPINFO256
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System.Runtime.InteropServices;

namespace NintendoWare.Font.Win32
{
  [StructLayout(LayoutKind.Sequential)]
  public class BITMAPINFO256
  {
    public const int ColorNum = 256;
    public BITMAPINFOHEADER bmiHeader;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
    public RGBQUAD[] bmiColors;
  }
}
