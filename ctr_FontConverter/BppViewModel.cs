// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.BppViewModel
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

namespace NintendoWare.Font
{
  public class BppViewModel
  {
    public int Bpp { get; private set; }

    public bool HasAlpha { get; private set; }

    public string DisplayName { get; private set; }

    public bool Is2Bit
    {
      get
      {
        return this.Bpp == 1;
      }
    }

    public string TypeName { get; private set; }

    public BppViewModel(int bpp, bool hasAlpha, string displayName, string typeName)
    {
      this.Bpp = bpp;
      this.HasAlpha = hasAlpha;
      this.DisplayName = displayName;
      this.TypeName = typeName;
    }
  }
}
