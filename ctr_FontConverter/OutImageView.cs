// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.OutImageView
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using NintendoWare.Font.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;

namespace NintendoWare.Font
{
  public class OutImageView : UserControl, IComponentConnector
  {
    internal FileSelectComboBox IDC_OUT_IMAGE_PATH;
    internal RadioButton IDC_OUT_IMAGE_SIZE_MARGIN;
    internal RadioButton IDC_OUT_IMAGE_SIZE_SIZE;
    private bool a;

    public OutImageView()
    {
      this.DataContextChanged += new DependencyPropertyChangedEventHandler(this.a);
      this.InitializeComponent();
    }

    private static void a(ref Color A_0, COLORREF[] A_1)
    {
label_2:
      if (1 == 0)
        ;
      CHOOSECOLOR cc = new CHOOSECOLOR();
      GCHandle gcHandle = GCHandle.Alloc((object) A_1, GCHandleType.Pinned);
      cc.lStructSize = (uint) Marshal.SizeOf((object) cc);
      cc.hwndOwner = new WindowInteropHelper(Application.Current.MainWindow).Handle;
      cc.hInstance = IntPtr.Zero;
      cc.rgbResult = Gdi.RGB(A_0.R, A_0.G, A_0.B);
      cc.lpCustColors = gcHandle.AddrOfPinnedObject();
      cc.Flags = ColorChooseFlag.RgbInit | ColorChooseFlag.FullOpen;
      cc.lCustData = IntPtr.Zero;
      cc.lpfnHook = (CCHOOKPROC) null;
      cc.lpTemplateName = (string) null;
      int num = 1;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_7;
          case 1:
            if (CommonDialog.ChooseColor(cc))
            {
              num = 2;
              continue;
            }
            goto label_7;
          case 2:
            A_0 = Color.FromRgb(Gdi.GetRValue(cc.rgbResult), Gdi.GetGValue(cc.rgbResult), Gdi.GetBValue(cc.rgbResult));
            num = 0;
            continue;
          default:
            goto label_2;
        }
      }
label_7:
      gcHandle.Free();
    }

    private void a(object A_0, DependencyPropertyChangedEventArgs A_1)
    {
      int num = 2;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_6;
          case 1:
            if (A_1.OldValue != null)
            {
              num = 3;
              continue;
            }
            goto label_10;
          case 3:
            OutImageViewModel outImageViewModel1 = (OutImageViewModel) A_1.OldValue;
            num = 0;
            continue;
          case 4:
            goto label_11;
          default:
            if (A_1.NewValue != null)
            {
              if (1 == 0)
                ;
              num = 4;
              continue;
            }
            num = 1;
            continue;
        }
      }
label_6:
      return;
label_10:
      return;
label_11:
      OutImageViewModel outImageViewModel2 = (OutImageViewModel) A_1.NewValue;
    }

    private void ColorButton_Click(object A_0, RoutedEventArgs A_1)
    {
      if (1 == 0)
        ;
      Border border = (Border) ((ContentControl) A_0).Content;
      Color color = ((SolidColorBrush) border.Background).Color;
      OutImageViewModel outImageViewModel = (OutImageViewModel) this.DataContext;
      OutImageView.a(ref color, outImageViewModel.CustomColors);
      border.Background = (Brush) new SolidColorBrush(color);
    }

    [DebuggerNonUserCode]
    public void InitializeComponent()
    {
      if (this.a)
        return;
      if (1 == 0)
        ;
      this.a = true;
      Application.LoadComponent((object) this, new Uri("/ctr_FontConverter;component/view/outimageview.xaml", UriKind.Relative));
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
      int num2 = 2;
      while (true)
      {
        switch (num2)
        {
          case 0:
            num2 = 1;
            continue;
          case 1:
            goto label_10;
          case 2:
            switch (num1)
            {
              case 1:
                goto label_7;
              case 2:
                goto label_14;
              case 3:
                goto label_13;
              case 4:
                goto label_6;
              case 5:
                goto label_11;
              case 6:
                goto label_5;
              case 7:
                goto label_8;
              case 8:
                goto label_12;
              default:
                num2 = 0;
                continue;
            }
          default:
            goto label_2;
        }
      }
label_5:
      ((ButtonBase) A_1).Click += new RoutedEventHandler(this.ColorButton_Click);
      return;
label_6:
      ((ButtonBase) A_1).Click += new RoutedEventHandler(this.ColorButton_Click);
      return;
label_7:
      this.IDC_OUT_IMAGE_PATH = (FileSelectComboBox) A_1;
      return;
label_8:
      ((ButtonBase) A_1).Click += new RoutedEventHandler(this.ColorButton_Click);
      return;
label_10:
      if (1 == 0)
        ;
      this.a = true;
      return;
label_11:
      ((ButtonBase) A_1).Click += new RoutedEventHandler(this.ColorButton_Click);
      return;
label_12:
      ((ButtonBase) A_1).Click += new RoutedEventHandler(this.ColorButton_Click);
      return;
label_13:
      this.IDC_OUT_IMAGE_SIZE_SIZE = (RadioButton) A_1;
      return;
label_14:
      this.IDC_OUT_IMAGE_SIZE_MARGIN = (RadioButton) A_1;
    }
  }
}
