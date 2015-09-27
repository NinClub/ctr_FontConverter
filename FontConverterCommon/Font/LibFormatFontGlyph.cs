// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.LibFormatFontGlyph
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System.Runtime.InteropServices;

namespace NintendoWare.Font
{
  [StructLayout(LayoutKind.Sequential)]
  public class LibFormatFontGlyph
  {
    public byte CellWidth;
    public byte CellHeight;
    public ushort CellSize;
    public sbyte BaselinePos;
    public byte MaxCharWidth;
    public byte Bpp;
    private byte a;
  }
}
