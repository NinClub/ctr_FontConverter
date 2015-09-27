// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.ImageFileFormatViewModel
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

namespace NintendoWare.Font
{
  public class ImageFileFormatViewModel
  {
    public string Title { get; private set; }

    public ImageFileFormat Format { get; private set; }

    public string FileExtension { get; private set; }

    public ImageFileFormatViewModel(string title, ImageFileFormat format, string fileExtension)
    {
      this.Title = title;
      this.Format = format;
      this.FileExtension = fileExtension;
    }
  }
}
