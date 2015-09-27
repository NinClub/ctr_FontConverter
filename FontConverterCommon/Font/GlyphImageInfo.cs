// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.GlyphImageInfo
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

namespace NintendoWare.Font
{
  public class GlyphImageInfo
  {
    private static readonly GlyphImageInfo[] a;

    public GlyphImageFormat GlyphImageFormat { get; private set; }

    public int Bpp { get; private set; }

    public bool IsToIntencity { get; private set; }

    public int AlphaBits { get; private set; }

    public bool HasAlpha
    {
      get
      {
        return this.AlphaBits > 0;
      }
    }

    static GlyphImageInfo()
    {
      if (1 == 0)
        ;
      GlyphImageInfo.a = new GlyphImageInfo[10];
      GlyphImageInfo.a[0] = new GlyphImageInfo(GlyphImageFormat.A4, 4, true, 0);
      GlyphImageInfo.a[1] = new GlyphImageInfo(GlyphImageFormat.A8, 8, true, 0);
      GlyphImageInfo.a[2] = new GlyphImageInfo(GlyphImageFormat.LA4, 8, true, 4);
      GlyphImageInfo.a[3] = new GlyphImageInfo(GlyphImageFormat.LA8, 16, true, 8);
      GlyphImageInfo.a[4] = new GlyphImageInfo(GlyphImageFormat.RGB565, 16, false, 0);
      GlyphImageInfo.a[5] = new GlyphImageInfo(GlyphImageFormat.RGB5A1, 16, false, 1);
      GlyphImageInfo.a[6] = new GlyphImageInfo(GlyphImageFormat.RGB5A3, 16, false, 3);
      GlyphImageInfo.a[7] = new GlyphImageInfo(GlyphImageFormat.RGBA4, 16, false, 4);
      GlyphImageInfo.a[8] = new GlyphImageInfo(GlyphImageFormat.RGB8, 24, false, 0);
      GlyphImageInfo.a[9] = new GlyphImageInfo(GlyphImageFormat.RGBA8, 32, false, 8);
    }

    public GlyphImageInfo(GlyphImageFormat glyphImageFormat, int bpp, bool isToIntencity, int alphaBits)
    {
      this.GlyphImageFormat = glyphImageFormat;
      this.Bpp = bpp;
      this.IsToIntencity = isToIntencity;
      this.AlphaBits = alphaBits;
    }

    public static GlyphImageInfo GetGlyphImageInfo(GlyphImageFormat format)
    {
      return GlyphImageInfo.a[(int) format];
    }
  }
}
