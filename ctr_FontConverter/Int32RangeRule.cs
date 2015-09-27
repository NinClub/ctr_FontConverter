// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Int32RangeRule
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System;
using System.Globalization;
using System.Windows.Controls;

namespace NintendoWare.Font
{
  public class Int32RangeRule : ValidationRule
  {
    public int Min { get; set; }

    public int Max { get; set; }

    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
label_2:
      int num1 = 0;
      int num2 = 1;
      ValidationResult validationResult;
      while (true)
      {
        switch (num2)
        {
          case 0:
            if (num1 > this.Max)
            {
              num2 = 4;
              continue;
            }
            goto label_10;
          case 1:
            if (1 == 0)
              ;
            try
            {
label_13:
              string s = value as string;
              int num3 = 1;
              while (true)
              {
                switch (num3)
                {
                  case 0:
                    goto label_7;
                  case 1:
                    if (s == null)
                    {
                      num3 = 3;
                      continue;
                    }
                    num1 = int.Parse(s);
                    num3 = 0;
                    continue;
                  case 2:
                    goto label_21;
                  case 3:
                    validationResult = new ValidationResult(false, (object) "Illegal type");
                    num3 = 2;
                    continue;
                  default:
                    goto label_13;
                }
              }
            }
            catch (FormatException ex)
            {
              validationResult = Int32RangeRule.a((Exception) ex);
              goto label_21;
            }
            catch (OverflowException ex)
            {
              validationResult = Int32RangeRule.a((Exception) ex);
              goto label_21;
            }
label_7:
            num2 = 3;
            continue;
          case 2:
            num2 = 0;
            continue;
          case 3:
            if (num1 >= this.Min)
            {
              num2 = 2;
              continue;
            }
            goto label_20;
          case 4:
            goto label_20;
          default:
            goto label_2;
        }
      }
label_10:
      return ValidationResult.ValidResult;
label_20:
      return new ValidationResult(false, (object) string.Format(Strings.ErrorNumberRange, (object) this.Min, (object) this.Max));
label_21:
      return validationResult;
    }

    private static ValidationResult a(Exception A_0)
    {
      return new ValidationResult(false, (object) A_0.Message);
    }
  }
}
