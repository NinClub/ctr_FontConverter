// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.SettingViewModel
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

namespace NintendoWare.Font
{
  public abstract class SettingViewModel : WorkspaceViewModel
  {
    private bool a;

    public bool IsReady
    {
      get
      {
        return this.a;
      }
      set
      {
        if (value == this.a)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.a = value;
          this.OnPropertyChanged("IsReady");
        }
      }
    }

    public abstract void SaveState();
  }
}
