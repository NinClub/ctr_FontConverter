// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Win32.WINDOWPLACEMENT
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;
using System.Runtime.InteropServices;

namespace NintendoWare.Font.Win32
{
  [Serializable]
  [StructLayout(LayoutKind.Sequential)]
  public class WINDOWPLACEMENT
  {
    public uint length;
    public uint flags;
    public ShowWindowCommand showCmd;
    public POINT ptMinPosition;
    public POINT ptMaxPosition;
    public RECT rcNormalPosition;

    public WINDOWPLACEMENT()
    {
      this.length = (uint) Marshal.SizeOf(typeof (WINDOWPLACEMENT));
    }
  }
}
