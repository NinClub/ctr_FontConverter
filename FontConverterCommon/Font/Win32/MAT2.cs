// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Win32.MAT2
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System.Runtime.InteropServices;

namespace NintendoWare.Font.Win32
{
  [StructLayout(LayoutKind.Sequential)]
  public class MAT2
  {
    public FIXED eM11;
    public FIXED eM12;
    public FIXED eM21;
    public FIXED eM22;

    public MAT2(FIXED aEM11, FIXED aEM12, FIXED aEM21, FIXED aEM22)
    {
      this.eM11 = aEM11;
      this.eM12 = aEM12;
      this.eM21 = aEM21;
      this.eM22 = aEM22;
    }
  }
}
