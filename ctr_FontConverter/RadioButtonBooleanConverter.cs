// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.RadioButtonBooleanConverter
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace NintendoWare.Font
{
  [ValueConversion(typeof (bool), typeof (bool))]
  public class RadioButtonBooleanConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
label_2:
      string str = parameter as string;
      if (1 == 0)
        ;
      int num = 3;
      bool result;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (!bool.TryParse(str, out result))
            {
              num = 1;
              continue;
            }
            goto label_9;
          case 1:
            goto label_5;
          case 2:
            goto label_8;
          case 3:
            num = str != null ? 0 : 2;
            continue;
          default:
            goto label_2;
        }
      }
label_5:
      return DependencyProperty.UnsetValue;
label_8:
      return DependencyProperty.UnsetValue;
label_9:
      return (object) (bool) (result == (bool) value ? 1 : 0);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      string str = parameter as string;
      if (str != null)
        return (object) (bool) (bool.Parse(str) ? 1 : 0);
      if (1 == 0)
        ;
      return DependencyProperty.UnsetValue;
    }
  }
}
