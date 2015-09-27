// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.IntColor
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

namespace NintendoWare.Font
{
  public struct IntColor
  {
    private uint a;

    public byte R
    {
      get
      {
        return (byte) (this.a >> 16);
      }
    }

    public byte G
    {
      get
      {
        return (byte) (this.a >> 8);
      }
    }

    public byte B
    {
      get
      {
        return (byte) this.a;
      }
    }

    public byte A
    {
      get
      {
        return (byte) (this.a >> 24);
      }
    }

    private IntColor(uint A_0)
    {
      this.a = A_0;
    }

    public static implicit operator uint(IntColor val)
    {
      return val.a;
    }

    public static implicit operator IntColor(uint val)
    {
      return new IntColor(val);
    }
  }
}
