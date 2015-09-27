// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Runtime.FontInformation
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System.Runtime.InteropServices;

namespace NintendoWare.Font.Runtime
{
  [StructLayout(LayoutKind.Sequential)]
  public class FontInformation
  {
    public static readonly int Length = Marshal.SizeOf(typeof (FontInformation));
    public byte FontType;
    public sbyte Linefeed;
    public ushort AlterCharIndex;
    public CharWidths DefaultWidth;
    public byte Encoding;
    public uint PtrGlyph;
    public uint PtrWidth;
    public uint PtrMap;
    public byte Height;
    public byte Width;
    public byte Ascent;
    private byte a;
  }
}
