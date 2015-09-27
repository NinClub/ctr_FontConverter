// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.WorkspaceViewModel
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace NintendoWare.Font
{
  public abstract class WorkspaceViewModel : ViewModelBase
  {
    private RelayCommand a;
    private string b;
    private StringObservableCollection c;

    public ICommand CloseCommand
    {
      get
      {
label_2:
        if (1 == 0)
          ;
        int num = 3;
        while (true)
        {
          switch (num)
          {
            case 0:
              this.a = new RelayCommand((Action<object>) (A_0 => this.a()));
              num = 2;
              continue;
            case 1:
              num = 0;
              continue;
            case 2:
              goto label_8;
            case 3:
              if (this.a == null)
              {
                num = 1;
                continue;
              }
              goto label_8;
            default:
              goto label_2;
          }
        }
label_8:
        return (ICommand) this.a;
      }
    }

    public string CurrentPath
    {
      get
      {
        return this.b;
      }
      set
      {
        if (value == this.b)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.b = value;
          this.OnPropertyChanged("CurrentPath");
        }
      }
    }

    public StringObservableCollection PathHistory
    {
      get
      {
        return this.c;
      }
    }

    public event EventHandler RequestClose;

    public virtual void SavePathToHistory()
    {
      if (this.PathHistory == null)
        return;
      this.PathHistory.InsertHistoryFront(this.CurrentPath);
    }

    protected void SetPathHistory(StringList pathHistory)
    {
      int num = 5;
      while (true)
      {
        switch (num)
        {
          case 0:
          case 2:
            num = 6;
            continue;
          case 1:
            if (1 == 0)
              ;
            this.CurrentPath = this.c[0];
            num = 4;
            continue;
          case 3:
            this.c = new StringObservableCollection();
            num = 2;
            continue;
          case 4:
            goto label_9;
          case 6:
            if (this.c.Count > 0)
            {
              num = 1;
              continue;
            }
            goto label_12;
          default:
            if (pathHistory == null)
            {
              num = 3;
              continue;
            }
            this.c = new StringObservableCollection((List<string>) pathHistory);
            num = 0;
            continue;
        }
      }
label_9:
      return;
label_12:;
    }

    private void a()
    {
      EventHandler eventHandler = this.d;
      if (eventHandler == null)
        return;
      eventHandler((object) this, EventArgs.Empty);
    }
  }
}
