// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.FB
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System.Windows.Media;

namespace NintendoWare.Font
{
  public class FB
  {
    public const int BorderWidth = 1;
    public const int PaddingWidth = 1;
    public const int BarWidth = 1;
    public const int NoCellAreaTop = 2;
    public const int NoCellAreaBottom = 4;
    public const int NoCellAreaLeft = 2;
    public const int NoCellAreaRight = 2;
    public const int NoCellAreaH = 4;
    public const int NoCellAreaV = 6;
    public static readonly Color BackgroundColor;
    public static readonly Color GridColor;
    public static readonly Color MarginColor;
    public static readonly Color WidthBarColor;
    public static readonly Color NullBlockColor;

    static FB()
    {
      if (1 == 0)
        ;
      FB.BackgroundColor = Color.FromRgb(byte.MaxValue, byte.MaxValue, byte.MaxValue);
      FB.GridColor = Color.FromRgb((byte) 0, (byte) 0, (byte) 0);
      FB.MarginColor = Color.FromRgb((byte) 153, (byte) 170, (byte) 153);
      FB.WidthBarColor = Color.FromRgb(byte.MaxValue, (byte) 0, (byte) 0);
      FB.NullBlockColor = Color.FromRgb(byte.MaxValue, (byte) 127, (byte) 127);
    }
  }
}
