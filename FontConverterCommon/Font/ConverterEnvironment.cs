// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.ConverterEnvironment
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

namespace NintendoWare.Font
{
  public class ConverterEnvironment
  {
    public const int TextureDataAlignSize = 128;
    public const ushort ByteOrderMark = (ushort) 65279;
    public const bool IsTargetLittleEndian = true;
    public const string PlatformName = "CTR";
    public const string PlatformChar = "C";
    public const string PlatformCharSmall = "c";

    public static bool IsRvl
    {
      get
      {
        return false;
      }
    }

    public static bool IsCtr
    {
      get
      {
        return true;
      }
    }
  }
}
