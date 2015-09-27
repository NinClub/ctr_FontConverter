// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.FontWriter
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

namespace NintendoWare.Font
{
  public abstract class FontWriter : FontIO
  {
    public abstract void WriteFontData(FontData fontData, GlyphOrder order);

    public abstract void GetGlyphOrder(GlyphOrder order);
  }
}
