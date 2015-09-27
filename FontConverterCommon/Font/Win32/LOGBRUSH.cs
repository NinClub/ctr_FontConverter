// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Win32.LOGBRUSH
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;
using System.Runtime.InteropServices;

namespace NintendoWare.Font.Win32
{
  [StructLayout(LayoutKind.Sequential)]
  public class LOGBRUSH
  {
    public BS lbStyle;
    public COLORREF lbColor;
    public UIntPtr lbHatch;

    public LOGBRUSH(BS aLbStyle, COLORREF aLbColor, UIntPtr aLbHatch)
    {
      this.lbStyle = aLbStyle;
      this.lbColor = aLbColor;
      this.lbHatch = aLbHatch;
    }
  }
}
