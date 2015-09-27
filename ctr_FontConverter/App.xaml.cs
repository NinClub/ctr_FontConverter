// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.App
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using NintendoWare.Font.Properties;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;

namespace NintendoWare.Font
{
  public partial class App : Application
  {
    private MainWindow a;
    private bool b;

    private void a(object A_0, StartupEventArgs A_1)
    {
label_2:
      GlCm.InitLanguage();
      MainWindow window = new MainWindow();
      int num1 = 0;
      ConvertSettings settings;
      while (true)
      {
        switch (num1)
        {
          case 0:
            if (1 == 0)
              ;
            if (!Settings.Default.IsWarningFontLicence)
            {
              num1 = 3;
              continue;
            }
            goto case 4;
          case 1:
            if (settings == null)
            {
              num1 = 5;
              continue;
            }
            goto label_11;
          case 2:
            goto label_11;
          case 3:
            int num2 = (int) MessageBox.Show(string.Format(Strings.IDS_LICENSE_WARNING_MSG, (object) "CTR"), Strings.IDS_LICENSE_WARNING_TITLE, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            Settings.Default.IsWarningFontLicence = true;
            num1 = 4;
            continue;
          case 4:
            settings = Settings.Default.ConvertSettings;
            num1 = 1;
            continue;
          case 5:
            settings = new ConvertSettings();
            Settings.Default.ConvertSettings = settings;
            num1 = 2;
            continue;
          default:
            goto label_2;
        }
      }
label_11:
      MainWindowViewModel viewModel = new MainWindowViewModel(settings);
      EventHandler handler = (EventHandler) null;
      handler = (EventHandler) ((A_1_2, A_2) =>
      {
        viewModel.RequestClose -= handler;
        window.Close();
      });
      viewModel.RequestClose += handler;
      window.DataContext = (object) viewModel;
      window.Init();
      this.a = window;
      this.a.Show();
    }

    private void a(object A_0, DispatcherUnhandledExceptionEventArgs A_1)
    {
      int num1 = 4;
      while (true)
      {
        switch (num1)
        {
          case 0:
            if (A_1.Exception is OutOfMemoryException)
            {
              num1 = 2;
              continue;
            }
            goto label_10;
          case 1:
            goto label_6;
          case 2:
            A_1.Handled = true;
            this.Shutdown(2);
            num1 = 1;
            continue;
          case 3:
            goto label_11;
          default:
            if (A_1.Exception is GeneralException)
            {
              if (1 == 0)
                ;
              num1 = 3;
              continue;
            }
            num1 = 0;
            continue;
        }
      }
label_6:
      return;
label_10:
      return;
label_11:
      int num2 = (int) MessageBox.Show(((GeneralException) A_1.Exception).GetMsg(), Strings.IDS_ERROR, MessageBoxButton.OK, MessageBoxImage.Hand);
      A_1.Handled = true;
      this.Shutdown(1);
    }

    private void a(object A_0, ExitEventArgs A_1)
    {
      if (this.a != null)
        this.a.StateSave();
      Settings.Default.Save();
    }

    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this.b)
        return;
      if (1 == 0)
        ;
      this.b = true;
      this.Startup += new StartupEventHandler(this.a);
      this.Exit += new ExitEventHandler(this.a);
      this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(this.a);
      Application.LoadComponent((object) this, new Uri("/ctr_FontConverter;component/app.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [STAThread]
    public static void Main()
    {
      App app = new App();
      app.InitializeComponent();
      app.Run();
    }
  }
}
