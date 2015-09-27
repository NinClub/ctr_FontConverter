// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.PixelPickerRvl
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

namespace NintendoWare.Font
{
  public class PixelPickerRvl : IPixelPicker
  {
    private readonly RgbImage a;
    private readonly int b;

    public int BlockW { get; private set; }

    public int BlockH { get; private set; }

    public int BlockPixelNum { get; private set; }

    public PixelPickerRvl(RgbImage sheet, int bpp)
    {
      this.a = sheet;
      this.BlockW = bpp >= 16 ? 4 : 8;
      this.BlockH = bpp != 4 ? 4 : 8;
      this.BlockPixelNum = this.BlockW * this.BlockH;
      this.b = sheet.Width / this.BlockW;
    }

    public PixelPos GetPixel(int pos)
    {
      if (1 == 0)
        ;
      return new PixelPos(0 + pos % this.BlockW + pos / this.BlockPixelNum % this.b * this.BlockW, 0 + pos % this.BlockPixelNum / this.BlockW + pos / this.BlockPixelNum / this.b * this.BlockH);
    }
  }
}
