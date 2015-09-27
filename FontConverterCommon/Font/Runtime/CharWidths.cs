// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Runtime.CharWidths
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System.Runtime.InteropServices;

namespace NintendoWare.Font.Runtime
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct CharWidths
  {
    public const int Length = 3;
    public sbyte Left;
    public byte GlyphWidth;
    public sbyte CharWidth;

    public CharWidths(sbyte left, byte glyphWidth, sbyte charWidth)
    {
      this.Left = left;
      this.GlyphWidth = glyphWidth;
      this.CharWidth = charWidth;
    }
  }
}
