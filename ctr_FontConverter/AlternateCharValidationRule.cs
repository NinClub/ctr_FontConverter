// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.AlternateCharValidationRule
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System;
using System.Globalization;
using System.Windows.Controls;

namespace NintendoWare.Font
{
  public class AlternateCharValidationRule : ValidationRule
  {
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
label_2:
      string s = value as string;
      int num = 2;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_13;
          case 1:
            goto label_11;
          case 2:
            num = s != null ? 6 : 1;
            continue;
          case 3:
            goto label_14;
          case 4:
            num = s.Length != 0 ? 7 : 0;
            continue;
          case 5:
            goto label_15;
          case 6:
            num = s.Length != 1 ? 4 : 3;
            continue;
          case 7:
            if (s.Length > 4)
            {
              num = 5;
              continue;
            }
            goto label_4;
          default:
            goto label_2;
        }
      }
label_4:
      try
      {
        if (1 == 0)
          ;
        int.Parse(s, NumberStyles.AllowHexSpecifier);
      }
      catch (FormatException ex)
      {
        return AlternateCharValidationRule.a();
      }
      catch (OverflowException ex)
      {
        return AlternateCharValidationRule.a();
      }
      return ValidationResult.ValidResult;
label_11:
      return new ValidationResult(false, (object) "Illegal type");
label_13:
      return ValidationResult.ValidResult;
label_14:
      return ValidationResult.ValidResult;
label_15:
      return AlternateCharValidationRule.a();
    }

    private static ValidationResult a()
    {
      return new ValidationResult(false, (object) Strings.ErrorAlternateCharFormat);
    }
  }
}
