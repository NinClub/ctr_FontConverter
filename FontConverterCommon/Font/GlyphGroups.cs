// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.GlyphGroups
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

namespace NintendoWare.Font
{
  public class GlyphGroups : HandlerBase
  {
    private readonly GlyphGroups.GroupList i = new GlyphGroups.GroupList();
    private const string m_sa = "glyph-groups";
    private const string b = "body";
    private const string c = "group";
    private const string d = "sp";
    private const string e = "name";
    private const string f = "index";
    private const string g = "version";
    private const string h = "1.0";
    private bool j;
    private int k;
    private bool l;
    private GlyphGroups.Group m;

    public GlyphGroups()
    {
      this.j = false;
      this.k = 0;
      this.l = false;
      this.m = (GlyphGroups.Group) null;
    }

    public bool IsValid()
    {
      return this.j;
    }

    public GlyphGroups.GroupList GetGroups()
    {
      return this.i;
    }

    public void Load(string orderFilePath)
    {
      try
      {
        XmlReader reader = this.CreateReader(orderFilePath);
        try
        {
          this.Parse(reader);
        }
        finally
        {
          int num = 1;
          while (true)
          {
            switch (num)
            {
              case 0:
                goto label_7;
              case 2:
                ((IDisposable) reader).Dispose();
                num = 0;
                continue;
              default:
                if (reader != null)
                {
                  num = 2;
                  continue;
                }
                goto label_7;
            }
          }
label_7:;
        }
      }
      catch (HandlerBaseException ex)
      {
        if (this.Error == null)
        {
          if (1 == 0)
            ;
          throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_XERCESC_MSG, (object) this.Error);
        }
        throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_INVALID_GROUP_FILE);
      }
      catch (GeneralException ex)
      {
        throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_XERCESC_MSG, (object) ex.GetMsg());
      }
      catch (XmlException ex)
      {
        throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_XERCESC_MSG, (object) ex.Message);
      }
      IntIntMap A_2 = new IntIntMap();
      int A_1 = -1;
      GlyphGroups.a(this.i, ref A_1, A_2);
      this.j = true;
    }

    protected string ConvertGroupName(string str)
    {
      int num = 2;
      Match match = null;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_8;
          case 1:
            goto label_9;
          case 3:
            if (match.Success)
            {
              num = 0;
              continue;
            }
            goto label_10;
          default:
            if (str == string.Empty)
            {
              num = 1;
              continue;
            }
            match = Regex.Match(str, "([^0-9a-zA-Z_])");
            num = 3;
            continue;
        }
      }
label_8:
      if (1 == 0)
        ;
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_GROUP_NAME_INVALID_CHAR, (object) str, (object) match.Value);
label_9:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_GROUP_REQUIRE_NAME);
label_10:
      return str;
    }

    protected override void StartElement(string name, HandlerBase.AttributeList attributes)
    {
      int num = 3;
      GlyphGroups.Group group = null;
      string str1 = "";
      string str2 = "";
      string s = "";
      int result = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (this.k == 1)
            {
              num = 6;
              continue;
            }
            goto label_48;
          case 1:
            if (int.TryParse(s, out result))
            {
              num = 12;
              continue;
            }
            goto case 34;
          case 2:
            num = 0;
            continue;
          case 4:
            group.Parent = this.m;
            group.Parent.Groups.Add(group);
            num = 7;
            continue;
          case 5:
          case 17:
          case 26:
          case 31:
            goto label_49;
          case 6:
            this.l = true;
            num = 17;
            continue;
          case 7:
          case 29:
            this.m = group;
            num = 5;
            continue;
          case 8:
            if (this.l)
            {
              num = 30;
              continue;
            }
            goto label_45;
          case 9:
            str1 = attributes.GetValue("version");
            num = 23;
            continue;
          case 10:
            if (this.m != null)
            {
              num = 19;
              continue;
            }
            goto label_13;
          case 11:
            num = 1;
            continue;
          case 12:
            group.Index = result;
            num = 34;
            continue;
          case 13:
            num = !(name == "body") ? 15 : 2;
            continue;
          case 14:
            goto label_32;
          case 15:
            if (name == "glyph-groups")
            {
              num = 9;
              continue;
            }
            goto label_49;
          case 16:
            num = 27;
            continue;
          case 18:
            this.Error = string.Format(Strings.IDS_ERR_VERSION_MISMATCH, (object) "glyph-groups", (object) str1, (object) "1.0");
            num = 31;
            continue;
          case 19:
            this.m.Chars.Add((ushort) 32);
            num = 26;
            continue;
          case 20:
            if (s != null)
            {
              num = 11;
              continue;
            }
            goto case 34;
          case 21:
            num = 32;
            continue;
          case 22:
            if (this.m == null)
            {
              group.Parent = (GlyphGroups.Group) null;
              this.i.Add(group);
              num = 29;
              continue;
            }
            if (1 == 0)
              ;
            num = 4;
            continue;
          case 23:
            if (str1 != null)
            {
              num = 21;
              continue;
            }
            goto case 16;
          case 24:
            if (str2 == null)
            {
              num = 14;
              continue;
            }
            group.Name = this.ConvertGroupName(str2);
            num = 20;
            continue;
          case 25:
            num = !(name == "group") ? 13 : 28;
            continue;
          case 27:
            if (this.Error == null)
            {
              num = 18;
              continue;
            }
            goto label_49;
          case 28:
            num = 8;
            continue;
          case 30:
            str2 = attributes.GetValue("name");
            s = attributes.GetValue("index");
            group = new GlyphGroups.Group();
            num = 24;
            continue;
          case 32:
            if (str1 != "1.0")
            {
              num = 16;
              continue;
            }
            goto label_49;
          case 33:
            num = 10;
            continue;
          case 34:
            num = 22;
            continue;
          default:
            num = !(name == "sp") ? 25 : 33;
            continue;
        }
      }
label_13:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_TAG_MUST_BE_IN, (object) "sp", (object) "group");
label_32:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_GROUP_REQUIRE_NAME);
label_45:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_TAG_MUST_BE_IN, (object) "group", (object) "body");
label_48:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_TAG_MUST_BE_IN, (object) "body", (object) "glyph-groups");
label_49:
      ++this.k;
    }

    protected override void Characters(string chars, int length)
    {
      int num = 6;
      int index = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_10;
          case 1:
            index = 0;
            num = 2;
            continue;
          case 2:
          case 7:
            num = 5;
            continue;
          case 3:
            if (!HandlerBase.IsWhitespace(chars[index]))
            {
              num = 4;
              continue;
            }
            goto case 8;
          case 4:
            this.m.Chars.Add((ushort) chars[index]);
            num = 8;
            continue;
          case 5:
            if (1 == 0)
              ;
            num = index < length ? 3 : 0;
            continue;
          case 8:
            ++index;
            num = 7;
            continue;
          default:
            if (this.m != null)
            {
              num = 1;
              continue;
            }
            goto label_13;
        }
      }
label_10:
      return;
label_13:;
    }

    protected override void EndElement(string name)
    {
label_2:
      --this.k;
      int num = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (name == "group")
            {
              if (1 == 0)
                ;
              num = 4;
              continue;
            }
            num = 5;
            continue;
          case 1:
            goto label_9;
          case 2:
            this.l = false;
            num = 1;
            continue;
          case 3:
            goto label_10;
          case 4:
            num = 6;
            continue;
          case 5:
            if (name == "body")
            {
              num = 2;
              continue;
            }
            goto label_16;
          case 6:
            if (this.m != null)
            {
              num = 3;
              continue;
            }
            goto label_14;
          default:
            goto label_2;
        }
      }
label_9:
      return;
label_16:
      return;
label_10:
      this.m = this.m.Parent;
      return;
label_14:;
    }

    private static void a(GlyphGroups.GroupList A_0, ref int A_1, IntIntMap A_2)
    {
      using (List<GlyphGroups.Group>.Enumerator enumerator = A_0.GetEnumerator())
      {
        int num = 12;
        GlyphGroups.Group current = null;
        bool flag = false;
        while (true)
        {
          switch (num)
          {
            case 0:
              if (!enumerator.MoveNext())
              {
                num = 10;
                continue;
              }
              current = enumerator.Current;
              num = 2;
              continue;
            case 1:
              if (!flag)
              {
                A_2[current.Index] = 1;
                GlyphGroups.a(current.Groups, ref A_1, A_2);
                num = 15;
                continue;
              }
              num = 16;
              continue;
            case 2:
              num = A_1 >= 0 ? 8 : 3;
              continue;
            case 3:
              A_1 = 0;
              num = 4;
              continue;
            case 4:
              num = 7;
              continue;
            case 5:
              if (current.Index < 0)
              {
                num = 18;
                continue;
              }
              goto case 4;
            case 6:
              num = 5;
              continue;
            case 7:
              if (current.Index < 0)
              {
                num = 9;
                continue;
              }
              goto case 13;
            case 8:
              if (A_1 > 0)
              {
                num = 14;
                continue;
              }
              break;
            case 9:
              current.Index = A_1++;
              num = 13;
              continue;
            case 10:
              num = 17;
              continue;
            case 11:
              goto label_25;
            case 13:
              flag = A_2.ContainsKey(current.Index);
              num = 1;
              continue;
            case 14:
              num = 20;
              continue;
            case 16:
              goto label_19;
            case 17:
              goto label_33;
            case 18:
              goto label_12;
            case 19:
              if (A_1 == 0)
              {
                num = 6;
                continue;
              }
              goto case 4;
            case 20:
              if (current.Index >= 0)
              {
                num = 11;
                continue;
              }
              break;
            default:
              num = 0;
              continue;
          }
          num = 19;
        }
label_33:
        return;
label_12:
        throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_GROUP_INDEX);
label_19:
        if (1 == 0)
          ;
        throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_GROUP_INDEX_DUPLICATE, (object) current.Index);
label_25:
        throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_GROUP_INDEX);
      }
    }

    public class CharCodeList : List<ushort>
    {
    }

    public class GroupList : List<GlyphGroups.Group>
    {
    }

    public class Group
    {
      private readonly GlyphGroups.GroupList a = new GlyphGroups.GroupList();
      private readonly GlyphGroups.CharCodeList b = new GlyphGroups.CharCodeList();

      public int Index { get; set; }

      public string Name { get; set; }

      public GlyphGroups.Group Parent { get; set; }

      public GlyphGroups.GroupList Groups
      {
        get
        {
          return this.a;
        }
      }

      public GlyphGroups.CharCodeList Chars
      {
        get
        {
          return this.b;
        }
      }

      public Group()
      {
        this.Index = -1;
        this.Parent = (GlyphGroups.Group) null;
      }
    }
  }
}
