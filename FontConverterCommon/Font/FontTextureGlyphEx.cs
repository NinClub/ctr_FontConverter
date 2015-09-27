// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.FontTextureGlyphEx
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Runtime;
using System.IO;

namespace NintendoWare.Font
{
  public class FontTextureGlyphEx : IBinarizable
  {
    public const int GlyphDataAlignSize = 128;
    private FontTextureGlyph a;

    public FontTextureGlyph Body
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

    public byte[] SheetImage { get; set; }

    public int SheetImageSize { get; set; }

    public void Read(ByteOrderBinaryReader br, int size)
    {
      if (1 == 0)
        ;
      long num = br.BaseStream.Position + (long) size;
      br.Read<FontTextureGlyph>(out this.a);
      br.Seek((int) this.a.SheetImage, SeekOrigin.Begin);
      this.SheetImage = new byte[num - (long) (int) this.a.SheetImage];
      br.Read(this.SheetImage, 0, this.SheetImage.Length);
    }

    public void Write(ByteOrderBinaryWriter bw)
    {
      if (1 == 0)
        ;
      int offset = GlCm.ROUND_UP((int) bw.BaseStream.Position + FontTextureGlyph.Length, 128);
      this.a.SheetImage = (uint) offset;
      bw.Write((object) this.a);
      bw.Seek(offset, SeekOrigin.Begin);
      bw.Write(this.SheetImage, 0, this.SheetImageSize);
    }

    public int GetBlockContentsSize(int offset)
    {
      if (1 == 0)
        ;
      return GlCm.ROUND_UP(offset + FontTextureGlyph.Length, 128) + this.SheetImageSize - offset;
    }
  }
}
