// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.RgbImage
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

namespace NintendoWare.Font
{
  public class RgbImage : ImageBase
  {
    public override bool IsIndexed
    {
      get
      {
        return false;
      }
    }

    public RgbImage()
    {
    }

    public RgbImage(RgbImage other)
      : base((ImageBase) other)
    {
    }

    public override ImageBase NewSameType()
    {
      return (ImageBase) new RgbImage();
    }

    public override uint GetRGB(int x, int y)
    {
      return this.GetColor(x, y);
    }
  }
}
