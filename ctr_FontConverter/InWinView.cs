// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.InWinView
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
  public class InWinView : UserControl, IComponentConnector
  {
    internal CheckBox cbEnableAverageWidth;
    private bool a;

    public InWinView()
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
        Application.LoadComponent((object) this, new Uri("/ctr_FontConverter;component/view/inwinview.xaml", UriKind.Relative));
      }
    }

    [DebuggerNonUserCode]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.a(int A_0, object A_1)
    {
      if (A_0 == 1)
      {
        if (1 == 0)
          ;
        this.cbEnableAverageWidth = (CheckBox) A_1;
      }
      else
        this.a = true;
    }
  }
}
