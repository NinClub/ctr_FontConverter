// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.InNitroViewModel
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System.Collections.Generic;

namespace NintendoWare.Font
{
  public class InNitroViewModel : InSettingViewModel
  {
    private const string a = "font resource (*.bcfnt, *.bcfna)|*.bcfnt;*.bcfna|normal brfnt (*.bcfnt)|*.bcfnt|archived brfnt (*.bcfna)|*.bcfna|all files (*.*)|*.*";
    private readonly InRuntimeBinarySettings b;

    public string FileFilter
    {
      get
      {
        return "font resource (*.bcfnt, *.bcfna)|*.bcfnt;*.bcfna|normal brfnt (*.bcfnt)|*.bcfnt|archived brfnt (*.bcfna)|*.bcfna|all files (*.*)|*.*";
      }
    }

    public string FileExtension
    {
      get
      {
        return "bcfnt";
      }
    }

    public InNitroViewModel(InRuntimeBinarySettings settings)
    {
      this.DisplayName = "bcfnt / bcfna";
      this.b = settings;
      this.SetPathHistory(this.b.FilePaths);
    }

    public override void SaveState()
    {
      this.b.FilePaths = new StringList((IEnumerable<string>) this.PathHistory);
    }

    public override FontReader GetFontReader()
    {
      return (FontReader) new NitroFontReader(this.CurrentPath);
    }
  }
}
