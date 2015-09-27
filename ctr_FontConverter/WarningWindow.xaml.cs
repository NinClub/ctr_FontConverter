// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.WarningWindow
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using NintendoWare.Font.Properties;
using NintendoWare.Font.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Markup;

namespace NintendoWare.Font
{
  public partial class WarningWindow : Window, IComponentConnector
  {
    private const int a = 400;
    private const int b = 200;
    private Window c;
    private bool d;
    private TextBoxTraceListener e;
    internal TextBox tbMessage;
    private bool f;

    public bool HasMessage
    {
      get
      {
        return this.tbMessage.Text != string.Empty;
      }
    }

    public WarningWindow(Window owner)
    {
      this.InitializeComponent();
      this.c = owner;
      this.c.IsVisibleChanged += new DependencyPropertyChangedEventHandler(this.a);
      this.SourceInitialized += new EventHandler(this.Window_SourceInitialized);
      this.e = new TextBoxTraceListener(this.tbMessage);
      ProgressControl.AddListener((TraceListener) this.e);
      this.Closing += (CancelEventHandler) ((A_0, A_1) => this.Window_Closing(A_1, (TraceListener) this.e));
      this.tbMessage.TextChanged += new TextChangedEventHandler(this.TextBox_TextChanged);
    }

    public new void Show()
    {
      this.Owner = this.c;
      base.Show();
    }

    public new void Close()
    {
      this.d = true;
      base.Close();
    }

    public void ClearMessage()
    {
      this.tbMessage.Clear();
      this.e.ClearWarningCount();
    }

    private void Window_SourceInitialized(object A_0, EventArgs A_1)
    {
      if (1 == 0)
        ;
      RECT A_1_1;
      this.a(this.Owner, out A_1_1);
      User.SetWindowPlacement(new WindowInteropHelper((Window) this).Handle, new WINDOWPLACEMENT()
      {
        flags = 0U,
        showCmd = ShowWindowCommand.ShowNormal,
        rcNormalPosition = A_1_1
      });
    }

    private void Window_Closing(CancelEventArgs A_0, TraceListener A_1)
    {
      if (!this.d)
      {
        if (1 == 0)
          ;
        A_0.Cancel = true;
        this.Hide();
      }
      else
      {
        ProgressControl.RemoveListener(A_1);
        this.a();
      }
    }

    private void a(Window A_0, out RECT A_1)
    {
label_2:
      WINDOWPLACEMENT warningWindowPlacement = Settings.Default.WarningWindowPlacement;
      int num = 5;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_5;
          case 1:
            if (warningWindowPlacement.rcNormalPosition.bottom - warningWindowPlacement.rcNormalPosition.top < 100)
            {
              num = 0;
              continue;
            }
            goto label_13;
          case 2:
            num = 1;
            continue;
          case 3:
            if (1 == 0)
              ;
            if (warningWindowPlacement.rcNormalPosition.right - warningWindowPlacement.rcNormalPosition.left >= 100)
            {
              num = 2;
              continue;
            }
            goto label_5;
          case 4:
            num = 3;
            continue;
          case 5:
            if (warningWindowPlacement != null)
            {
              num = 4;
              continue;
            }
            goto label_5;
          default:
            goto label_2;
        }
      }
label_5:
      User.GetWindowRect(new WindowInteropHelper(A_0).Handle, out A_1);
      A_1.left = A_1.right;
      A_1.right = A_1.left + 400;
      A_1.bottom = A_1.top + 200;
      return;
label_13:
      A_1 = warningWindowPlacement.rcNormalPosition;
    }

    private void a()
    {
      if (1 == 0)
        ;
      WINDOWPLACEMENT wndpl = new WINDOWPLACEMENT();
      User.GetWindowPlacement(new WindowInteropHelper((Window) this).Handle, wndpl);
      Settings.Default.WarningWindowPlacement = wndpl;
    }

    private void a(object A_0, DependencyPropertyChangedEventArgs A_1)
    {
      int num = 0;
      while (true)
      {
        switch (num)
        {
          case 1:
            if (this.HasMessage)
            {
              num = 3;
              continue;
            }
            goto label_6;
          case 2:
            goto label_4;
          case 3:
            num = 5;
            continue;
          case 4:
            num = 1;
            continue;
          case 5:
            if ((bool) A_1.NewValue)
            {
              num = 6;
              continue;
            }
            goto label_11;
          case 6:
            if (1 == 0)
              ;
            this.Show();
            num = 2;
            continue;
          default:
            if (!this.IsVisible)
            {
              num = 4;
              continue;
            }
            goto label_15;
        }
      }
label_4:
      return;
label_15:
      return;
label_11:
      return;
label_6:;
    }

    private void TextBox_TextChanged(object A_0, TextChangedEventArgs A_1)
    {
      int num = 6;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (1 == 0)
              ;
            num = 1;
            continue;
          case 1:
            if (this.HasMessage)
            {
              num = 2;
              continue;
            }
            goto label_7;
          case 2:
            num = 5;
            continue;
          case 3:
            goto label_5;
          case 4:
            this.Show();
            num = 3;
            continue;
          case 5:
            if (this.c.IsVisible)
            {
              num = 4;
              continue;
            }
            goto label_11;
          default:
            if (!this.IsVisible)
            {
              num = 0;
              continue;
            }
            goto label_15;
        }
      }
label_5:
      return;
label_15:
      return;
label_11:
      return;
label_7:;
    }

    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this.f)
      {
        if (1 != 0)
          ;
      }
      else
      {
        this.f = true;
        Application.LoadComponent((object) this, new Uri("/ctr_FontConverter;component/warningwindow.xaml", UriKind.Relative));
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
        this.tbMessage = (TextBox) A_1;
      }
      else
        this.f = true;
    }
  }
}
