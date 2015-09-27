// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.ProgressBarViewModel
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

namespace NintendoWare.Font
{
  public class ProgressBarViewModel : ViewModelBase
  {
    private int a;
    private int b;
    private int c;

    public int Value
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
          this.OnPropertyChanged("Value");
        }
      }
    }

    public int Minimum
    {
      get
      {
        return this.b;
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
          this.b = value;
          this.OnPropertyChanged("Minimum");
        }
      }
    }

    public int Maximum
    {
      get
      {
        return this.c;
      }
      set
      {
        if (value == this.a)
          return;
        if (1 == 0)
          ;
        this.c = value;
        this.OnPropertyChanged("Maximum");
      }
    }
  }
}
