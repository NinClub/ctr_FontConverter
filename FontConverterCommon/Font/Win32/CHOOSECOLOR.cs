// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Win32.CHOOSECOLOR
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;
using System.Runtime.InteropServices;

namespace NintendoWare.Font.Win32
{
  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
  public class CHOOSECOLOR
  {
    public uint lStructSize;
    public IntPtr hwndOwner;
    public IntPtr hInstance;
    public COLORREF rgbResult;
    public IntPtr lpCustColors;
    public ColorChooseFlag Flags;
    public IntPtr lCustData;
    [MarshalAs(UnmanagedType.FunctionPtr)]
    public CCHOOKPROC lpfnHook;
    [MarshalAs(UnmanagedType.LPTStr)]
    public string lpTemplateName;
  }
}
