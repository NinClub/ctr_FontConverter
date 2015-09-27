// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.CharEncodingViewModel
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

namespace NintendoWare.Font
{
  public class CharEncodingViewModel
  {
    public string Name { get; private set; }

    public CharEncoding Encoding { get; private set; }

    public CharEncodingViewModel(string name, CharEncoding encoding)
    {
      this.Name = name;
      this.Encoding = encoding;
    }
  }
}
