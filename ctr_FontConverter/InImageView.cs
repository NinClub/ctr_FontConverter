// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.InImageView
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
  public class InImageView : UserControl, IComponentConnector
  {
    internal FileSelectComboBox IDC_IN_IMAGE_PATH;
    internal ComboBox cbImageFormat;
    private bool a;

    public InImageView()
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
        Application.LoadComponent((object) this, new Uri("/ctr_FontConverter;component/view/inimageview.xaml", UriKind.Relative));
      }
    }

    [DebuggerNonUserCode]
    internal Delegate _CreateDelegate(Type delegateType, string handler)
    {
      return Delegate.CreateDelegate(delegateType, (object) this, handler);
    }

    [DebuggerNonUserCode]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.a(int A_0, object A_1)
    {
label_2:
      int num1 = A_0;
      if (1 == 0)
        ;
      int num2 = 1;
      while (true)
      {
        switch (num2)
        {
          case 0:
            goto label_9;
          case 1:
            switch (num1)
            {
              case 1:
                goto label_7;
              case 2:
                goto label_6;
              default:
                num2 = 2;
                continue;
            }
          case 2:
            num2 = 0;
            continue;
          default:
            goto label_2;
        }
      }
label_6:
      this.cbImageFormat = (ComboBox) A_1;
      return;
label_7:
      this.IDC_IN_IMAGE_PATH = (FileSelectComboBox) A_1;
      return;
label_9:
      this.a = true;
    }
  }
}
