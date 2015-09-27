// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.FileDialogButton
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace NintendoWare.Font
{
  public partial class FileDialogButton : UserControl, IComponentConnector
  {
    public static readonly DependencyProperty FilePathProperty;
    public static readonly DependencyProperty FileFilterProperty;
    public static readonly DependencyProperty FilterIndexProperty;
    public static readonly DependencyProperty FileExtensionProperty;
    public static readonly DependencyProperty IsOutputProperty;
    private bool a;

    public string FilePath
    {
      get
      {
        return (string) this.GetValue(FileDialogButton.FilePathProperty);
      }
      set
      {
        this.SetValue(FileDialogButton.FilePathProperty, (object) value);
      }
    }

    public string FileFilter
    {
      get
      {
        return (string) this.GetValue(FileDialogButton.FileFilterProperty);
      }
      set
      {
        this.SetValue(FileDialogButton.FileFilterProperty, (object) value);
      }
    }

    public int FilterIndex
    {
      get
      {
        return (int) this.GetValue(FileDialogButton.FilterIndexProperty);
      }
      set
      {
        this.SetValue(FileDialogButton.FilterIndexProperty, (object) value);
      }
    }

    public string FileExtension
    {
      get
      {
        return (string) this.GetValue(FileDialogButton.FileExtensionProperty);
      }
      set
      {
        this.SetValue(FileDialogButton.FileExtensionProperty, (object) value);
      }
    }

    public bool IsOutput
    {
      get
      {
        return (bool) this.GetValue(FileDialogButton.IsOutputProperty);
      }
      set
      {
        this.SetValue(FileDialogButton.IsOutputProperty, (object) (bool) (value ? 1 : 0));
      }
    }

    static FileDialogButton()
    {
      if (1 == 0)
        ;
      FileDialogButton.FilePathProperty = DependencyProperty.Register("FilePath", typeof (string), typeof (FileDialogButton));
      FileDialogButton.FileFilterProperty = DependencyProperty.Register("FileFilter", typeof (string), typeof (FileDialogButton));
      FileDialogButton.FilterIndexProperty = DependencyProperty.Register("FilterIndex", typeof (int), typeof (FileDialogButton));
      FileDialogButton.FileExtensionProperty = DependencyProperty.Register("FileExtension", typeof (string), typeof (FileDialogButton));
      FileDialogButton.IsOutputProperty = DependencyProperty.Register("IsOutput", typeof (bool), typeof (FileDialogButton));
    }

    public FileDialogButton()
    {
      this.InitializeComponent();
    }

    private void Button_Click(object A_0, RoutedEventArgs A_1)
    {
      this.a();
    }

    private void a()
    {
      int num1 = 6;
      while (true)
      {
        bool? nullable;
        FileDialog fileDialog;
        bool flag;
        string currentDirectory;
        int num2;
        switch (num1)
        {
          case 0:
          case 8:
            fileDialog.Filter = this.FileFilter;
            fileDialog.FilterIndex = 1 + this.FilterIndex;
            fileDialog.FileName = this.FilePath;
            fileDialog.DefaultExt = this.FileExtension;
            fileDialog.Title = "Select File";
            currentDirectory = Directory.GetCurrentDirectory();
            nullable = fileDialog.ShowDialog();
            num1 = 10;
            continue;
          case 1:
            this.FilePath = fileDialog.FileName;
            num1 = 7;
            continue;
          case 2:
            if (flag)
            {
              num1 = 1;
              continue;
            }
            goto label_17;
          case 3:
            if (1 == 0)
              ;
            num1 = 5;
            continue;
          case 4:
            num2 = nullable.GetValueOrDefault() ? 1 : 0;
            break;
          case 5:
            num2 = 0;
            break;
          case 7:
            goto label_14;
          case 9:
            fileDialog = (FileDialog) new OpenFileDialog();
            num1 = 8;
            continue;
          case 10:
            num1 = nullable.HasValue ? 4 : 3;
            continue;
          default:
            if (!this.IsOutput)
            {
              num1 = 9;
              continue;
            }
            fileDialog = (FileDialog) new SaveFileDialog()
            {
              OverwritePrompt = true
            };
            num1 = 0;
            continue;
        }
        flag = num2 != 0;
        Directory.SetCurrentDirectory(currentDirectory);
        num1 = 2;
      }
label_14:
      return;
label_17:;
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
        Application.LoadComponent((object) this, new Uri("/ctr_FontConverter;component/filedialogbutton.xaml", UriKind.Relative));
      }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [DebuggerNonUserCode]
    void IComponentConnector.a(int A_0, object A_1)
    {
      if (A_0 == 1)
      {
        ((ButtonBase) A_1).Click += new RoutedEventHandler(this.Button_Click);
      }
      else
      {
        if (1 == 0)
          ;
        this.a = true;
      }
    }
  }
}
