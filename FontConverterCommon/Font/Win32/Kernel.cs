// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Win32.Kernel
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System.Runtime.InteropServices;

namespace NintendoWare.Font.Win32
{
  public class Kernel
  {
    private const string a = "Kernel32.dll";

    [DllImport("Kernel32.dll", SetLastError = true)]
    public static extern int WideCharToMultiByte(uint CodePage, uint dwFlags, [In] ushort[] wideCharStr, int cchWideChar, [Out] byte[] lpMultiByteStr, int cbMultiByte, [In] byte[] lpDefaultChar, [MarshalAs(UnmanagedType.Bool)] out bool lpUsedDefaultChar);

    [DllImport("Kernel32.dll", SetLastError = true)]
    public static extern int MultiByteToWideChar(uint CodePage, uint dwFlags, [In] byte[] lpMultiByteStr, int cbMultiByte, [Out] ushort[] lpWideCharStr, int cchWideChar);
  }
}
