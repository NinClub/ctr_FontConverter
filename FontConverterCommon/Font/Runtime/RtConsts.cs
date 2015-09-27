// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Runtime.RtConsts
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font;

namespace NintendoWare.Font.Runtime
{
  public class RtConsts
  {
    public const ushort InvalidCharCode = (ushort) 65535;
    public const ushort InvalidGlyphIndex = (ushort) 65535;
    public static readonly Signature32 BinFileSigFONT;
    public static readonly Signature32 BinFileSigFONTA;
    public static readonly Signature32 BinBlockSigFINF;
    public static readonly Signature32 BinBlockSigCGLP;
    public static readonly Signature32 BinBlockSigTGLP;
    public static readonly Signature32 BinBlockSigCWDH;
    public static readonly Signature32 BinBlockSigCMAP;
    public static readonly Signature32 BinBlockSigGLGR;
    public static readonly Signature32 BinBlockSigHTGL;
    public static readonly uint FontFileVersionOld;
    public static readonly uint FontFileVersion;

    static RtConsts()
    {
      if (1 == 0)
        ;
      RtConsts.BinFileSigFONT = new Signature32("CFNT");
      RtConsts.BinFileSigFONTA = new Signature32("CFNA");
      RtConsts.BinBlockSigFINF = new Signature32("FINF");
      RtConsts.BinBlockSigCGLP = new Signature32("CGLP");
      RtConsts.BinBlockSigTGLP = new Signature32("TGLP");
      RtConsts.BinBlockSigCWDH = new Signature32("CWDH");
      RtConsts.BinBlockSigCMAP = new Signature32("CMAP");
      RtConsts.BinBlockSigGLGR = new Signature32("GLGR");
      RtConsts.BinBlockSigHTGL = new Signature32("HTGL");
      RtConsts.FontFileVersionOld = RtConsts.MakeVersion((byte) 3, (byte) 0, (byte) 0, (byte) 0);
      RtConsts.FontFileVersion = RtConsts.MakeVersion((byte) 3, (byte) 0, (byte) 0, (byte) 0);
    }

    public static ushort MakeVersion(byte major, byte minor)
    {
      return (ushort) ((uint) major << 8 | (uint) minor);
    }

    public static uint MakeVersion(byte major, byte minor, byte micro, byte binaryBugFix)
    {
      if (1 == 0)
        ;
      return (uint) ((int) major << 24 | (int) minor << 16 | (int) micro << 8) | (uint) binaryBugFix;
    }
  }
}
