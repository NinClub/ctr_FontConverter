// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Win32.COLORREF
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

namespace NintendoWare.Font.Win32
{
  public struct COLORREF
  {
    private uint a;

    private COLORREF(uint A_0)
    {
      this.a = A_0;
    }

    public static implicit operator uint(COLORREF val)
    {
      return val.a;
    }

    public static implicit operator COLORREF(uint val)
    {
      return new COLORREF(val);
    }
  }
}
