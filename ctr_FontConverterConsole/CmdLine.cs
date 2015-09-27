// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.CmdLine
// Assembly: ctr_FontConverterConsole, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A31F2A30-66C3-4349-9B59-5CB8C11371A6
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverterConsole.exe

using System.Collections.Generic;

namespace NintendoWare.Font
{
  internal class CmdLine
  {
    private readonly CmdLine.OptionMap m_a = new CmdLine.OptionMap();
    private readonly StringList m_b = new StringList();

    public string this[string name]
    {
      get
      {
        StringList stringList;
        if (!this.m_a.TryGetValue(name, out stringList))
          return string.Empty;
        if (1 == 0)
          ;
        return stringList[0];
      }
    }

    public CmdLine(string cmdline, CmdLine.OptionDef[] options, int num)
    {
      this.a(cmdline, options, num);
    }

    public bool Exists(string name)
    {
      return this.m_a.ContainsKey(name);
    }

    public int Number(string name, int def)
    {
      StringList stringList;
      if (!this.m_a.TryGetValue(name, out stringList))
        return def;
      if (1 == 0)
        ;
      return int.Parse(stringList[0]);
    }

    public int GetNum()
    {
      return this.m_a.Count;
    }

    private bool b(char A_0)
    {
      return (int) A_0 == 0;
    }

    private bool a(char A_0)
    {
      return (int) A_0 <= 32;
    }

    private int b(string A_0, int A_1)
    {
      int num = 1;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (!this.a(A_0[A_1]))
            {
              num = 5;
              continue;
            }
            if (1 == 0)
              ;
            ++A_1;
            num = 4;
            continue;
          case 2:
            if (A_1 < A_0.Length)
            {
              num = 3;
              continue;
            }
            goto label_10;
          case 3:
            num = 0;
            continue;
          case 5:
            goto label_10;
          default:
            num = 2;
            continue;
        }
      }
label_10:
      return A_1;
    }

    private void a(string A_0, CmdLine.OptionDef[] A_1, int A_2)
    {
label_2:
      int A_1_1 = 0;
      int num = 18;
      string A_0_1 = "";
      bool flag1 = false;
      CmdLine.OptionDef A_3 = default(CmdLine.OptionDef);
      bool flag2 = false;
      bool flag3 = false;
      string str1 = "";
      string str2 = "";
      int index = 0;
      CmdLine.Option option = default(CmdLine.Option);
      while (true)
      {
        switch (num)
        {
          case 0:
          case 18:
          case 19:
          case 32:
          case 36:
          case 39:
            num = 11;
            continue;
          case 1:
            flag3 = true;
            index = 1;
            num = 21;
            continue;
          case 2:
            num = 4;
            continue;
          case 3:
            A_1_1 = this.b(A_0, A_1_1);
            num = 36;
            continue;
          case 4:
            if ((int) str2[0] == 45)
            {
              num = 1;
              continue;
            }
            flag1 = true;
            num = 28;
            continue;
          case 5:
            goto label_13;
          case 6:
            if (A_3.Type == CmdLine.Option.LTOne)
            {
              num = 9;
              continue;
            }
            goto label_35;
          case 7:
            goto label_30;
          case 8:
            if (A_0_1.Length != 0)
            {
              A_1_1 += A_0_1.Length;
              flag2 = this.a(A_0_1, A_1, A_2, out A_3);
              num = 34;
              continue;
            }
            num = 24;
            continue;
          case 9:
            StringList stringList1 = this.m_a[A_0_1];
            num = 0;
            continue;
          case 10:
            this.m_a[A_0_1].Add(str2);
            A_1_1 += str2.Length;
            num = 19;
            continue;
          case 11:
            num = A_1_1 < A_0.Length ? 22 : 12;
            continue;
          case 12:
            goto label_56;
          case 13:
          case 20:
            num = 16;
            continue;
          case 14:
          case 28:
            num = 26;
            continue;
          case 15:
            ++A_1_1;
            A_0_1 = this.a(A_0, A_1_1);
            num = 8;
            continue;
          case 16:
            if (flag3)
            {
              num = 38;
              continue;
            }
            goto case 14;
          case 17:
            flag3 = false;
            num = 20;
            continue;
          case 21:
          case 37:
            num = 23;
            continue;
          case 22:
            num = (int) A_0[A_1_1] != 45 ? 33 : 15;
            continue;
          case 23:
            if (index < str2.Length)
            {
              num = 31;
              continue;
            }
            if (1 == 0)
              ;
            num = 13;
            continue;
          case 24:
            goto label_43;
          case 25:
            if (str1.Length == 0)
            {
              num = 5;
              continue;
            }
            A_1_1 += str1.Length;
            this.m_b.Add(str1);
            num = 32;
            continue;
          case 26:
            num = !flag1 ? 6 : 10;
            continue;
          case 27:
            goto label_44;
          case 29:
            switch (option)
            {
              case CmdLine.Option.None:
                StringList stringList2 = this.m_a[A_0_1];
                num = 39;
                continue;
              case CmdLine.Option.LTOne:
              case CmdLine.Option.One:
                A_1_1 = this.b(A_0, A_1_1);
                str2 = this.a(A_0, A_1_1);
                flag1 = false;
                num = 30;
                continue;
              default:
                num = 35;
                continue;
            }
          case 30:
            if (str2.Length > 0)
            {
              num = 2;
              continue;
            }
            goto case 14;
          case 31:
            if (!char.IsDigit(str2[index]))
            {
              num = 17;
              continue;
            }
            ++index;
            num = 37;
            continue;
          case 33:
            if (this.a(A_0[A_1_1]))
            {
              num = 3;
              continue;
            }
            str1 = this.a(A_0, A_1_1);
            num = 25;
            continue;
          case 34:
            if (!flag2)
            {
              num = 7;
              continue;
            }
            option = A_3.Type;
            num = 29;
            continue;
          case 35:
            num = 27;
            continue;
          case 38:
            flag1 = true;
            num = 14;
            continue;
          default:
            goto label_2;
        }
      }
label_56:
      return;
label_13:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_TYPE0);
label_30:
      throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_UNKNONW_OPTION, (object) A_0_1);
label_35:
      throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_LACK_PARAMETER);
label_43:
      throw GlCm.ErrMsg(ErrorType.CmdLine, Strings.IDS_ERR_ILLEGAL_HYPHON);
label_44:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_UNKNOWN_OPTION_TYPE, (object) A_3.Type);
    }

    private bool a(string A_0, CmdLine.OptionDef[] A_1, int A_2, out CmdLine.OptionDef A_3)
    {
label_2:
      int index = 0;
      int num = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
          case 1:
            num = 2;
            continue;
          case 2:
            num = index < A_2 ? 3 : 4;
            continue;
          case 3:
            if (!(A_1[index].Name == A_0))
            {
              ++index;
              num = 1;
              continue;
            }
            num = 5;
            continue;
          case 4:
            goto label_10;
          case 5:
            goto label_7;
          default:
            goto label_2;
        }
      }
label_7:
      if (1 == 0)
        ;
      A_3 = A_1[index];
      return true;
label_10:
      A_3 = new CmdLine.OptionDef();
      return false;
    }

    private string a(string A_0, int A_1)
    {
label_2:
      bool flag = false;
      int num = 3;
      int index = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
            num = 1;
            continue;
          case 1:
            if (!this.a(A_0[index]))
            {
              num = 5;
              continue;
            }
            goto label_22;
          case 2:
            ++A_1;
            flag = true;
            num = 10;
            continue;
          case 3:
            if ((int) A_0[A_1] == 34)
            {
              num = 2;
              continue;
            }
            goto case 10;
          case 4:
            num = index < A_0.Length ? 14 : 12;
            continue;
          case 5:
            if (1 == 0)
              ;
            num = 8;
            continue;
          case 6:
            if ((int) A_0[index] != 34)
            {
              num = 13;
              continue;
            }
            goto label_22;
          case 7:
          case 11:
            num = 4;
            continue;
          case 8:
            if (flag)
            {
              num = 9;
              continue;
            }
            goto case 13;
          case 9:
            num = 6;
            continue;
          case 10:
            index = A_1;
            num = 11;
            continue;
          case 12:
            goto label_22;
          case 13:
            ++index;
            num = 7;
            continue;
          case 14:
            if (!flag)
            {
              num = 0;
              continue;
            }
            goto case 5;
          default:
            goto label_2;
        }
      }
label_22:
      return A_0.Substring(A_1, index - A_1);
    }

    public struct OptionDef
    {
      public readonly string Name;
      public readonly CmdLine.Option Type;

      public OptionDef(string name, CmdLine.Option type)
      {
        this.Name = name;
        this.Type = type;
      }
    }

    public enum Option
    {
      None,
      LTOne,
      One,
    }

    protected class OptionMap : Dictionary<string, StringList>
    {
      public new StringList this[string key]
      {
        get
        {
          int num = 1;
          StringList stringList = null;
          while (true)
          {
            switch (num)
            {
              case 0:
                stringList = new StringList();
                this.Add(key, stringList);
                num = 2;
                continue;
              case 2:
                goto label_6;
              default:
                if (1 == 0)
                  ;
                if (!this.TryGetValue(key, out stringList))
                {
                  num = 0;
                  continue;
                }
                goto label_6;
            }
          }
label_6:
          return stringList;
        }
      }
    }
  }
}
