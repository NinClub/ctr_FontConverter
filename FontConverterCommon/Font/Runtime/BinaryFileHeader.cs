// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Runtime.BinaryFileHeader
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font;
using System.Runtime.InteropServices;

namespace NintendoWare.Font.Runtime
{
  [StructLayout(LayoutKind.Sequential)]
  public class BinaryFileHeader
  {
    public static readonly int Length = Marshal.SizeOf(typeof (BinaryFileHeader));
    public Signature32 Signature;
    public ushort ByteOrder;
    public ushort HeaderSize;
    public uint Version;
    public uint FileSize;
    public ushort DataBlocks;
    private ushort a;
  }
}
