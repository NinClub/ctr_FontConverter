// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.PixelPickerCtr
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

namespace NintendoWare.Font
{
  public class PixelPickerCtr : IPixelPicker
  {
    private readonly RgbImage a;
    private readonly int b;

    public int BlockW
    {
      get
      {
        return 8;
      }
    }

    public int BlockH
    {
      get
      {
        return 8;
      }
    }

    public int BlockPixelNum
    {
      get
      {
        return this.BlockW * this.BlockH;
      }
    }

    public PixelPickerCtr(RgbImage sheet, int bpp)
    {
      this.a = sheet;
      this.b = sheet.Width / this.BlockW;
    }

    public PixelPos GetPixel(int pos)
    {
      if (1 == 0)
        ;
      return new PixelPos(0 + (pos & 1) + (pos >> 1 & 2) + (pos >> 2 & 4) + pos / this.BlockPixelNum % this.b * this.BlockW, 0 + (pos >> 1 & 1) + (pos >> 2 & 2) + (pos >> 3 & 4) + pos / this.BlockPixelNum / this.b * this.BlockH);
    }
  }
}
