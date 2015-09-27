// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.OutNitroView
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace NintendoWare.Font
{
  public class OutNitroView : UserControl, IComponentConnector
  {
    internal FileSelectComboBox IDC_OUT_NITRO_PATH;
    private bool a;

    public OutNitroView()
    {
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this.a)
      {
        if (1 != 0)
          ;
      }
      else
      {
        this.a = true;
        Application.LoadComponent((object) this, new Uri("/ctr_FontConverter;component/view/outnitroview.xaml", UriKind.Relative));
      }
    }

    [DebuggerNonUserCode]
    internal Delegate _CreateDelegate(Type delegateType, string handler)
    {
      return Delegate.CreateDelegate(delegateType, (object) this, handler);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [DebuggerNonUserCode]
    void IComponentConnector.a(int A_0, object A_1)
    {
      if (A_0 == 1)
      {
        if (1 == 0)
          ;
        this.IDC_OUT_NITRO_PATH = (FileSelectComboBox) A_1;
      }
      else
        this.a = true;
    }
  }
}
