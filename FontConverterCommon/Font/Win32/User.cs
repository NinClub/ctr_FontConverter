// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Win32.User
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;
using System.Runtime.InteropServices;

namespace NintendoWare.Font.Win32
{
  public class User
  {
    private const string a = "User32.dll";

    [DllImport("User32.dll", SetLastError = true)]
    public static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);

    [DllImport("User32.dll", SetLastError = true)]
    public static extern bool GetWindowPlacement(IntPtr hWnd, [Out] WINDOWPLACEMENT wndpl);

    [DllImport("User32.dll", SetLastError = true)]
    public static extern bool SetWindowPlacement(IntPtr hWnd, [In] WINDOWPLACEMENT wndpl);
  }
}
