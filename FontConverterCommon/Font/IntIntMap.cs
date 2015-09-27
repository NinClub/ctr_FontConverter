// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.IntIntMap
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System.Collections.Generic;

namespace NintendoWare.Font
{
  public class IntIntMap : Dictionary<int, int>
  {
    public void Add(IntIntMap rhs)
    {
      using (Dictionary<int, int>.Enumerator enumerator = rhs.GetEnumerator())
      {
        int num1 = 0;
        KeyValuePair<int, int> current = default(KeyValuePair<int, int>);
        int num2 = 0;
        bool flag = false;
        while (true)
        {
          switch (num1)
          {
            case 1:
              goto label_13;
            case 2:
              if (1 == 0)
                ;
              if (flag)
              {
                num1 = 7;
                continue;
              }
              this.Add(current.Key, current.Value);
              num1 = 6;
              continue;
            case 3:
              num1 = 1;
              continue;
            case 4:
              if (enumerator.MoveNext())
              {
                current = enumerator.Current;
                flag = this.TryGetValue(current.Key, out num2);
                num1 = 2;
                continue;
              }
              num1 = 3;
              continue;
            case 7:
              this[current.Key] = num2 + current.Value;
              num1 = 5;
              continue;
            default:
              num1 = 4;
              continue;
          }
        }
label_13:;
      }
    }
  }
}
