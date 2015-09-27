// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.FileSelectComboBox
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace NintendoWare.Font
{
  public partial class FileSelectComboBox : UserControl, IComponentConnector
  {
    public static readonly DependencyProperty PathHistoryProperty;
    public static readonly DependencyProperty CurrentPathProperty;
    internal ComboBox combBox;
    private bool a;

    public ObservableCollection<string> PathHistory
    {
      get
      {
        return (ObservableCollection<string>) this.GetValue(FileSelectComboBox.PathHistoryProperty);
      }
      set
      {
        this.SetValue(FileSelectComboBox.PathHistoryProperty, (object) value);
      }
    }

    public string CurrentPath
    {
      get
      {
        return (string) this.GetValue(FileSelectComboBox.CurrentPathProperty);
      }
      set
      {
        this.SetValue(FileSelectComboBox.CurrentPathProperty, (object) value);
      }
    }

    static FileSelectComboBox()
    {
      if (1 == 0)
        ;
      FileSelectComboBox.PathHistoryProperty = DependencyProperty.Register("PathHistory", typeof (ObservableCollection<string>), typeof (FileSelectComboBox));
      FileSelectComboBox.CurrentPathProperty = DependencyProperty.Register("CurrentPath", typeof (string), typeof (FileSelectComboBox));
    }

    public FileSelectComboBox()
    {
      this.InitializeComponent();
      this.combBox.DataContext = (object) this;
    }

    private void ComboBox_PreviewDragOver(object A_0, DragEventArgs A_1)
    {
      int num = 3;
      while (true)
      {
        switch (num)
        {
          case 0:
            A_1.Effects = DragDropEffects.Copy;
            num = 2;
            continue;
          case 1:
          case 2:
            goto label_7;
          default:
            if (1 == 0)
              ;
            if (this.IsSingleFile(A_1) != null)
            {
              num = 0;
              continue;
            }
            A_1.Effects = DragDropEffects.None;
            num = 1;
            continue;
        }
      }
label_7:
      A_1.Handled = true;
    }

    private void ComboBox_PreviewDrop(object A_0, DragEventArgs A_1)
    {
label_2:
      A_1.Handled = true;
      string A_0_1 = this.IsSingleFile(A_1);
      int num = 3;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (A_0 is ComboBox)
            {
              num = 1;
              continue;
            }
            goto label_10;
          case 1:
            this.a(A_0_1);
            num = 2;
            continue;
          case 2:
            goto label_6;
          case 3:
            if (1 == 0)
              ;
            num = A_0_1 != null ? 0 : 4;
            continue;
          case 4:
            goto label_9;
          default:
            goto label_2;
        }
      }
label_9:
      return;
label_6:
      return;
label_10:;
    }

    private void a(string A_0)
    {
      this.combBox.Text = A_0;
    }

    private string IsSingleFile(DragEventArgs A_0)
    {
      int num = 2;
      string[] strArray;
      while (true)
      {
        switch (num)
        {
          case 0:
            strArray = A_0.Data.GetData(DataFormats.FileDrop, true) as string[];
            num = 5;
            continue;
          case 1:
            num = 3;
            continue;
          case 3:
            if (File.Exists(strArray[0]))
            {
              num = 4;
              continue;
            }
            goto label_12;
          case 4:
            goto label_4;
          case 5:
            if (1 == 0)
              ;
            if (strArray.Length == 1)
            {
              num = 1;
              continue;
            }
            goto label_12;
          default:
            if (A_0.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
              num = 0;
              continue;
            }
            goto label_12;
        }
      }
label_4:
      return strArray[0];
label_12:
      return (string) null;
    }

    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this.a)
        return;
      if (1 == 0)
        ;
      this.a = true;
      Application.LoadComponent((object) this, new Uri("/ctr_FontConverter;component/fileselectcombobox.xaml", UriKind.Relative));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [DebuggerNonUserCode]
    void IComponentConnector.a(int A_0, object A_1)
    {
      if (A_0 == 1)
      {
        if (1 == 0)
          ;
        this.combBox = (ComboBox) A_1;
        this.combBox.PreviewDragOver += new DragEventHandler(this.ComboBox_PreviewDragOver);
        this.combBox.PreviewDrop += new DragEventHandler(this.ComboBox_PreviewDrop);
      }
      else
        this.a = true;
    }
  }
}
