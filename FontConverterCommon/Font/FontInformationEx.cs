// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.FontInformationEx
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Runtime;

namespace NintendoWare.Font
{
  public class FontInformationEx : IBinarizable
  {
    private FontInformation a;

    public FontInformation Body
    {
      get
      {
        return this.a;
      }
      set
      {
        this.a = value;
      }
    }

    public FontTextureGlyphEx Glyph { get; set; }

    public FontWidthEx Width { get; set; }

    public FontCodeMapEx Map { get; set; }

    public void Read(ByteOrderBinaryReader br, int size)
    {
      br.Read<FontInformation>(out this.a);
    }

    public void Write(ByteOrderBinaryWriter bw)
    {
      bw.Write((object) this.a);
    }

    public int GetBlockContentsSize(int offset)
    {
      return FontInformation.Length;
    }
  }
}
