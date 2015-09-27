// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.GlyphGroupFileViewModel
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

namespace NintendoWare.Font
{
  public class GlyphGroupFileViewModel
  {
    public string DisplayName { get; private set; }

    public string FileName { get; private set; }

    public GlyphGroupFileViewModel(string displayName, string fileName)
    {
      this.DisplayName = displayName;
      this.FileName = fileName;
    }
  }
}
