// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Runtime.CMapScanEntry
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System.Runtime.InteropServices;

namespace NintendoWare.Font.Runtime
{
  public struct CMapScanEntry
  {
    public static readonly int Length = Marshal.SizeOf(typeof (CMapScanEntry));
    public ushort Code;
    public ushort Index;
  }
}
