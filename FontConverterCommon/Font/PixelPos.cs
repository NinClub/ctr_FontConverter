// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.PixelPos
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

namespace NintendoWare.Font
{
  public struct PixelPos
  {
    private int a;
    private int b;

    public int X
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

    public int Y
    {
      get
      {
        return this.b;
      }
      set
      {
        this.b = value;
      }
    }

    public PixelPos(int x, int y)
    {
      this.a = x;
      this.b = y;
    }
  }
}
