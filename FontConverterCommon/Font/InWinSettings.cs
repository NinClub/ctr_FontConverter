// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.InWinSettings
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;

namespace NintendoWare.Font
{
  [Serializable]
  public class InWinSettings
  {
    private const int DefaultFontSize = 16;

    public string FontName { get; set; }

    public string Bpp { get; set; }

    public int FontSize { get; set; }

    public WidthType WidthType { get; set; }

    public int FixedValue { get; set; }

    public int AverageWidth { get; set; }

    public bool EnableAverageWidth { get; set; }

    public bool EnableSoftAntialiasing { get; set; }

    public InWinSettings()
    {
      this.FontName = "Tahoma";
      this.Bpp = ConverterEnvironment.IsCtr ? "A8" : "A4";
      this.FontSize = 16;
      this.WidthType = WidthType.IncludeMargin;
      this.FixedValue = 16;
      this.AverageWidth = 16;
      this.EnableAverageWidth = false;
      this.EnableSoftAntialiasing = true;
    }
  }
}
