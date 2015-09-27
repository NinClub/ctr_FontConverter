// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.ViewModelBase
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System;
using System.ComponentModel;
using System.Diagnostics;

namespace NintendoWare.Font
{
  public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
  {
    public virtual string DisplayName { get; protected set; }

    protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public void Dispose()
    {
      this.OnDispose();
    }

    [DebuggerStepThrough]
    [Conditional("DEBUG")]
    public void VerifyPropertyName(string propertyName)
    {
      int num = 3;
      string message;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (this.ThrowOnInvalidPropertyName)
            {
              num = 2;
              continue;
            }
            goto label_5;
          case 1:
            message = "Invalid property name: " + propertyName;
            num = 0;
            continue;
          case 2:
            goto label_6;
          default:
            if (1 == 0)
              ;
            if (TypeDescriptor.GetProperties((object) this)[propertyName] == null)
            {
              num = 1;
              continue;
            }
            goto label_10;
        }
      }
label_10:
      return;
label_6:
      throw new Exception(message);
label_5:;
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
label_2:
      if (1 == 0)
        ;
      PropertyChangedEventHandler changedEventHandler = this.a;
      int num = 1;
      while (true)
      {
        switch (num)
        {
          case 0:
            PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
            changedEventHandler((object) this, e);
            num = 2;
            continue;
          case 1:
            if (changedEventHandler != null)
            {
              num = 0;
              continue;
            }
            goto label_8;
          case 2:
            goto label_6;
          default:
            goto label_2;
        }
      }
label_6:
      return;
label_8:;
    }

    protected virtual void OnDispose()
    {
    }
  }
}
