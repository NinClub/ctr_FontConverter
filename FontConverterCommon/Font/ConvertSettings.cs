// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.ConvertSettings
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;

namespace NintendoWare.Font
{
  [Serializable]
  public class ConvertSettings
  {
    public int InputMode { get; set; }

    public int OutputMode { get; set; }

    public bool UseFilter { get; set; }

    public StringList FilePaths { get; set; }

    public InImageSettings InImageSettings { get; set; }

    public InRuntimeBinarySettings InRuntimeBinarySettings { get; set; }

    public InWinSettings InWinSettings { get; set; }

    public OutImageSettings OutImageSettings { get; set; }

    public OutRuntimeBinarySettings OutRuntimeBinarySettings { get; set; }

    public ConvertSettings()
    {
      this.InputMode = 2;
      this.InImageSettings = new InImageSettings();
      this.InRuntimeBinarySettings = new InRuntimeBinarySettings();
      this.InWinSettings = new InWinSettings();
      this.OutImageSettings = new OutImageSettings();
      this.OutRuntimeBinarySettings = new OutRuntimeBinarySettings();
    }
  }
}
