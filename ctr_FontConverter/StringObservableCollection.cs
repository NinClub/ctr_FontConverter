// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.StringObservableCollection
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NintendoWare.Font
{
  public class StringObservableCollection : ObservableCollection<string>
  {
    private const int a = 10;

    public StringObservableCollection()
    {
    }

    public StringObservableCollection(List<string> list)
      : base(list)
    {
    }

    public void InsertHistoryFront(string str)
    {
      int num = 4;
      int oldIndex;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_4;
          case 1:
            if (1 == 0)
              ;
            if (this.Count < 10)
            {
              num = 0;
              continue;
            }
            this.RemoveAt(this.Count - 1);
            num = 6;
            continue;
          case 2:
            goto label_18;
          case 3:
            goto label_16;
          case 5:
            this.Move(oldIndex, 0);
            num = 3;
            continue;
          case 6:
          case 9:
            num = 1;
            continue;
          case 7:
            num = 9;
            continue;
          case 8:
            if (oldIndex != 0)
            {
              num = 5;
              continue;
            }
            goto label_12;
          case 10:
            num = oldIndex != -1 ? 8 : 7;
            continue;
          default:
            if (str == string.Empty)
            {
              num = 2;
              continue;
            }
            oldIndex = this.IndexOf(str);
            num = 10;
            continue;
        }
      }
label_16:
      return;
label_18:
      return;
label_4:
      this.Insert(0, str);
      return;
label_12:;
    }
  }
}
