// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.GlyphImageFormatViewModel
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

namespace NintendoWare.Font
{
  public class GlyphImageFormatViewModel
  {
    public string DisplayName { get; private set; }

    public GlyphImageInfo Info { get; private set; }

    public GlyphImageFormatViewModel(string displayName, GlyphImageInfo info)
    {
      this.DisplayName = displayName;
      this.Info = info;
    }
  }
}
