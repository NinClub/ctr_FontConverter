// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Win32.FIXED
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

namespace NintendoWare.Font.Win32
{
  public struct FIXED
  {
    public ushort fract;
    public short value;

    public FIXED(ushort aFract, short aValue)
    {
      this.fract = aFract;
      this.value = aValue;
    }
  }
}
