// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.SheetPixelsViewModel
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

namespace NintendoWare.Font
{
  public class SheetPixelsViewModel
  {
    public string Name { get; private set; }

    public int Pixels { get; private set; }

    public SheetPixelsViewModel(string name, int pixels)
    {
      this.Name = name;
      this.Pixels = pixels;
    }
  }
}
