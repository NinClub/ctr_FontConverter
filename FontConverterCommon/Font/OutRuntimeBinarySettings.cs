// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.OutRuntimeBinarySettings
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;

namespace NintendoWare.Font
{
  [Serializable]
  public class OutRuntimeBinarySettings
  {
    public const string DefaultGlyphGroupFile = "";

    public StringList FilePaths { get; set; }

    public CharEncoding Encoding { get; set; }

    public bool UseDefaultAlternateChar { get; set; }

    public string AlternateChar { get; set; }

    public bool UseDefaultLineHeight { get; set; }

    public int LineHeight { get; set; }

    public bool UseDefaultLeft { get; set; }

    public int DefaultLeft { get; set; }

    public bool UseDefaultWidth { get; set; }

    public int DefaultWidth { get; set; }

    public bool UseDefaultRight { get; set; }

    public int DefaultRight { get; set; }

    public string GlyphGroupFile { get; set; }

    public int SheetPixels { get; set; }

    public OutRuntimeBinarySettings()
    {
      this.Encoding = CharEncoding.UTF16;
      this.UseDefaultAlternateChar = true;
      this.AlternateChar = string.Empty;
      this.UseDefaultLineHeight = true;
      this.LineHeight = 16;
      this.UseDefaultLeft = true;
      this.DefaultLeft = 0;
      this.UseDefaultWidth = true;
      this.DefaultWidth = 16;
      this.UseDefaultRight = true;
      this.DefaultRight = 0;
      this.GlyphGroupFile = "";
      this.SheetPixels = 0;
    }
  }
}
