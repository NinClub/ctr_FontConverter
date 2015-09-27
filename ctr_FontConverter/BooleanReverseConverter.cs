// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.BooleanReverseConverter
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
  public class BooleanReverseConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return (object) (bool) (!(bool) value ? 1 : 0);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return DependencyProperty.UnsetValue;
    }
  }
}
