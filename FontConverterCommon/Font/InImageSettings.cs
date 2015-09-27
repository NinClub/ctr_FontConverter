// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.InImageSettings
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;

namespace NintendoWare.Font
{
  [Serializable]
  public class InImageSettings
  {
    public StringList FilePaths { get; set; }

    public string OrderFile { get; set; }

    public GlyphImageFormat GlyphImageFormat { get; set; }

    public bool AntiLinear { get; set; }

    public InImageSettings()
    {
      this.OrderFile = "cp1252.xlor";
      this.GlyphImageFormat = !ConverterEnvironment.IsCtr ? GlyphImageFormat.A4 : GlyphImageFormat.A8;
      this.AntiLinear = false;
    }
  }
}
