// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Runtime.FontTextureGlyph
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System.Runtime.InteropServices;

namespace NintendoWare.Font.Runtime
{
  [StructLayout(LayoutKind.Sequential)]
  public class FontTextureGlyph
  {
    public static readonly int Length = Marshal.SizeOf(typeof (FontTextureGlyph));
    public byte CellWidth;
    public byte CellHeight;
    public sbyte BaselinePos;
    public byte MaxCharWidth;
    public uint SheetSize;
    public ushort SheetNum;
    public ushort SheetFormat;
    public ushort SheetRow;
    public ushort SheetLine;
    public ushort SheetWidth;
    public ushort SheetHeight;
    public uint SheetImage;
  }
}
