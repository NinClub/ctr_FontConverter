// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Win32.BITMAPFILEHEADER
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System.Runtime.InteropServices;

namespace NintendoWare.Font.Win32
{
  [StructLayout(LayoutKind.Sequential, Pack = 2)]
  public struct BITMAPFILEHEADER
  {
    public ushort bfType;
    public uint bfSize;
    public ushort bfReserved1;
    public ushort bfReserved2;
    public uint bfOffBits;
  }
}
