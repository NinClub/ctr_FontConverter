// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.MainWindow
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using NintendoWare.Font.Properties;
using NintendoWare.Font.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Markup;

namespace NintendoWare.Font
{
  public partial class MainWindow : Window, IComponentConnector
  {
    public const string FontBinaryTabTitleStr = "bcfnt / bcfna";
    private WarningWindow a;
    internal CheckBox IDC_USE_FILTER;
    internal FileSelectComboBox IDC_FILTER_PATH;
    private bool b;

    public MainWindow()
    {
      this.a = new WarningWindow((Window) this);
      this.InitializeComponent();
    }

    public void Init()
    {
      if (1 == 0)
        ;
      ((ViewModelBase) this.DataContext).PropertyChanged += new PropertyChangedEventHandler(this.ViewModel_PropertyChanged);
      ProgressControl.GetInstance().SetStatusString(Strings.IDS_STATUS_INITIAL);
    }

    internal void StateSave()
    {
      ((MainWindowViewModel) this.DataContext).StateSave();
    }

    private void CDlgWin_SourceInitialized(object A_0, EventArgs A_1)
    {
label_2:
      WINDOWPLACEMENT windowPlacement = Settings.Default.WindowPlacement;
      int num = 2;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_8;
          case 1:
            goto label_7;
          case 2:
            if (1 == 0)
              ;
            if (windowPlacement == null)
            {
              num = 0;
              continue;
            }
            windowPlacement.length = (uint) Marshal.SizeOf(typeof (WINDOWPLACEMENT));
            windowPlacement.flags = 0U;
            num = 1;
            continue;
          default:
            goto label_2;
        }
      }
label_8:
      return;
label_7:
      windowPlacement.showCmd = windowPlacement.showCmd == ShowWindowCommand.ShowMinimized ? ShowWindowCommand.ShowNormal : windowPlacement.showCmd;
      User.SetWindowPlacement(new WindowInteropHelper((Window) this).Handle, windowPlacement);
    }

    private void CDlgWin_Closing(object A_0, CancelEventArgs A_1)
    {
      if (1 == 0)
        ;
      this.a.Close();
      WINDOWPLACEMENT wndpl = new WINDOWPLACEMENT();
      User.GetWindowPlacement(new WindowInteropHelper((Window) this).Handle, wndpl);
      Settings.Default.WindowPlacement = wndpl;
    }

    private void ViewModel_PropertyChanged(object A_0, PropertyChangedEventArgs A_1)
    {
label_2:
      string str = "IsConvertReady";
      MainWindowViewModel mainWindowViewModel = (MainWindowViewModel) A_0;
      int num = 7;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (this.a.IsVisible)
            {
              num = 1;
              continue;
            }
            goto label_11;
          case 1:
            num = 5;
            continue;
          case 2:
            num = 3;
            continue;
          case 3:
            num = mainWindowViewModel.IsConvertReady ? 0 : 6;
            continue;
          case 4:
            goto label_8;
          case 5:
            if (!this.a.HasMessage)
            {
              num = 8;
              continue;
            }
            goto label_14;
          case 6:
            goto label_18;
          case 7:
            if (A_1.PropertyName == str)
            {
              num = 2;
              continue;
            }
            goto label_17;
          case 8:
            this.a.Hide();
            if (1 == 0)
              ;
            num = 4;
            continue;
          default:
            goto label_2;
        }
      }
label_8:
      return;
label_17:
      return;
label_14:
      return;
label_11:
      return;
label_18:
      this.a.ClearMessage();
    }

    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this.b)
      {
        if (1 != 0)
          ;
      }
      else
      {
        this.b = true;
        Application.LoadComponent((object) this, new Uri("/ctr_FontConverter;component/mainwindow.xaml", UriKind.Relative));
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
      int num2 = 2;
      while (true)
      {
        switch (num2)
        {
          case 0:
            goto label_10;
          case 1:
            num2 = 0;
            continue;
          case 2:
            switch (num1)
            {
              case 1:
                goto label_7;
              case 2:
                goto label_6;
              case 3:
                goto label_9;
              default:
                num2 = 1;
                continue;
            }
          default:
            goto label_2;
        }
      }
label_6:
      this.IDC_USE_FILTER = (CheckBox) A_1;
      return;
label_7:
      ((Window) A_1).SourceInitialized += new EventHandler(this.CDlgWin_SourceInitialized);
      ((Window) A_1).Closing += new CancelEventHandler(this.CDlgWin_Closing);
      return;
label_9:
      this.IDC_FILTER_PATH = (FileSelectComboBox) A_1;
      return;
label_10:
      this.b = true;
    }
  }
}
