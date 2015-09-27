// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.CharFilter
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;
using System.Collections.Generic;
using System.Xml;

namespace NintendoWare.Font
{
  public class CharFilter : HandlerBase
  {
    private CharFilter.OutputGlyphList i = new CharFilter.OutputGlyphList();
    private const string m_sa = "letter-list";
    private const string b = "letter";
    private const string c = "body";
    private const string d = "code";
    private const string e = "sp";
    private const string f = "version";
    private const string g = "1.0";
    private bool h;
    private int j;
    private bool k;
    private bool l;
    private bool m;

    public CharFilter()
    {
      this.j = 0;
      this.k = false;
      this.l = false;
      this.m = false;
      this.h = true;
    }

    public bool IsFiltered(ushort c)
    {
      int num = 3;
      bool flag1;
      bool flag2;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (flag2)
            {
              num = 1;
              continue;
            }
            goto label_10;
          case 1:
            goto label_5;
          case 2:
            goto label_9;
          default:
            if (1 == 0)
              ;
            if (this.h)
            {
              num = 2;
              continue;
            }
            flag2 = this.i.TryGetValue(c, out flag1);
            num = 0;
            continue;
        }
      }
label_5:
      return !flag1;
label_9:
      return false;
label_10:
      return true;
    }

    public void DumpFilter()
    {
      using (Dictionary<ushort, bool>.Enumerator enumerator = this.i.GetEnumerator())
      {
        int num = 3;
        while (true)
        {
          switch (num)
          {
            case 0:
              goto label_9;
            case 2:
              if (1 == 0)
                ;
              num = 0;
              continue;
            case 4:
              if (enumerator.MoveNext())
              {
                KeyValuePair<ushort, bool> current = enumerator.Current;
                num = 1;
                continue;
              }
              num = 2;
              continue;
            default:
              num = 4;
              continue;
          }
        }
label_9:;
      }
    }

    public void Load(string filterFilePath)
    {
      try
      {
        XmlReader reader = this.CreateReader(filterFilePath);
        try
        {
          this.Parse(reader);
        }
        finally
        {
          int num = 2;
          while (true)
          {
            switch (num)
            {
              case 0:
                goto label_7;
              case 1:
                ((IDisposable) reader).Dispose();
                num = 0;
                continue;
              default:
                if (reader != null)
                {
                  num = 1;
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
        if (this.Error != null)
          throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_XERCESC_MSG, (object) this.Error);
        throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_INVALID_FILTER_FILE);
      }
      catch (GeneralException ex)
      {
        throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_XERCESC_MSG, (object) ex.GetMsg());
      }
      catch (XmlException ex)
      {
        throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_XERCESC_MSG, (object) ex.Message);
      }
      if (1 == 0)
        ;
      this.a((ushort) 32);
      this.h = false;
    }

    public void SetOrder(GlyphOrder order)
    {
label_2:
      int hnum = order.GetHNum();
      int vnum = order.GetVNum();
      int num = 13;
      while (true)
      {
        ushort charCode1;
        CharFilter.OutputGlyphList outputGlyphList;
        int y1;
        int x1;
        int x2;
        int y2;
        ushort charCode2;
        switch (num)
        {
          case 0:
            ++y2;
            num = 12;
            continue;
          case 1:
            num = 18;
            continue;
          case 2:
            this.i = outputGlyphList;
            num = 10;
            continue;
          case 3:
            if (y1 >= vnum)
            {
              num = 2;
              continue;
            }
            x2 = 0;
            num = 9;
            continue;
          case 4:
          case 6:
            num = 3;
            continue;
          case 5:
            goto label_45;
          case 7:
            if ((int) charCode2 != (int) ushort.MaxValue)
            {
              num = 26;
              continue;
            }
            break;
          case 8:
            if (1 == 0)
              break;
            break;
          case 9:
          case 15:
            num = 30;
            continue;
          case 10:
            goto label_43;
          case 11:
          case 16:
            num = 22;
            continue;
          case 12:
          case 17:
            num = 23;
            continue;
          case 13:
            num = !this.h ? 29 : 21;
            continue;
          case 14:
            ++y1;
            num = 4;
            continue;
          case 18:
            if (this.i.ContainsKey(charCode1))
            {
              num = 19;
              continue;
            }
            goto case 27;
          case 19:
            outputGlyphList[charCode1] = true;
            num = 27;
            continue;
          case 20:
            if (this.i.Count == 0)
            {
              num = 5;
              continue;
            }
            goto label_21;
          case 21:
            y2 = 0;
            num = 17;
            continue;
          case 22:
            if (x1 < hnum)
            {
              charCode2 = order.GetCharCode(x1, y2);
              num = 7;
              continue;
            }
            num = 0;
            continue;
          case 23:
            if (y2 >= vnum)
            {
              num = 28;
              continue;
            }
            x1 = 0;
            num = 11;
            continue;
          case 24:
            if ((int) charCode1 != (int) ushort.MaxValue)
            {
              num = 1;
              continue;
            }
            goto case 27;
          case 25:
            outputGlyphList = new CharFilter.OutputGlyphList();
            y1 = 0;
            num = 6;
            continue;
          case 26:
            this.a(charCode2);
            num = 8;
            continue;
          case 27:
            ++x2;
            num = 15;
            continue;
          case 28:
            num = 20;
            continue;
          case 29:
            if (order.IsValid())
            {
              num = 25;
              continue;
            }
            goto label_39;
          case 30:
            if (x2 >= hnum)
            {
              num = 14;
              continue;
            }
            charCode1 = order.GetCharCode(x2, y1);
            num = 24;
            continue;
          default:
            goto label_2;
        }
        ++x1;
        num = 16;
      }
label_43:
      return;
label_45:
      return;
label_21:
      this.h = false;
      return;
label_39:;
    }

    public void CheckEqual(FontData font)
    {
      GlyphList glyphList = font.GetGlyphList();
      using (Dictionary<ushort, bool>.Enumerator enumerator = this.i.GetEnumerator())
      {
        int num = 3;
        while (true)
        {
          KeyValuePair<ushort, bool> current;
          switch (num)
          {
            case 0:
              if (current.Value)
              {
                num = 5;
                continue;
              }
              break;
            case 1:
              goto label_15;
            case 2:
              if (enumerator.MoveNext())
              {
                current = enumerator.Current;
                if (1 == 0)
                  ;
                num = 0;
                continue;
              }
              num = 4;
              continue;
            case 4:
              num = 1;
              continue;
            case 5:
              num = 7;
              continue;
            case 7:
              if (glyphList.GetByCode(current.Key) == null)
              {
                num = 8;
                continue;
              }
              break;
            case 8:
              ProgressControl.Warning(Strings.IDS_WARN_FONT_FILTER_MISMATCH, (object) (char) current.Key, (object) current.Key);
              num = 6;
              continue;
          }
          num = 2;
        }
label_15:;
      }
    }

    protected override void StartElement(string name, HandlerBase.AttributeList attributes)
    {
      int num = 15;
      string str;
      while (true)
      {
        switch (num)
        {
          case 0:
            this.m = true;
            num = 18;
            continue;
          case 1:
            str = attributes.GetValue("version");
            num = 16;
            continue;
          case 2:
          case 9:
          case 18:
          case 19:
          case 20:
            goto label_39;
          case 3:
            num = !(name == "sp") ? 4 : 24;
            continue;
          case 4:
            num = !(name == "letter") ? 5 : 22;
            continue;
          case 5:
            num = !(name == "body") ? 27 : 7;
            continue;
          case 6:
            if (this.Error == null)
            {
              num = 26;
              continue;
            }
            goto label_39;
          case 7:
            num = 28;
            continue;
          case 8:
            if (this.l)
            {
              num = 14;
              continue;
            }
            goto label_37;
          case 10:
            this.l = true;
            num = 19;
            continue;
          case 11:
            num = 6;
            continue;
          case 12:
            num = 25;
            continue;
          case 13:
            if (this.l)
            {
              num = 17;
              continue;
            }
            goto label_9;
          case 14:
            this.a((ushort) 32);
            num = 2;
            continue;
          case 16:
            if (str != null)
            {
              num = 12;
              continue;
            }
            goto case 11;
          case 17:
            this.k = true;
            num = 9;
            continue;
          case 21:
            if (1 == 0)
              ;
            num = 13;
            continue;
          case 22:
            num = 23;
            continue;
          case 23:
            if (this.m)
            {
              num = 10;
              continue;
            }
            goto label_4;
          case 24:
            num = 8;
            continue;
          case 25:
            if (str != "1.0")
            {
              num = 11;
              continue;
            }
            goto label_39;
          case 26:
            this.Error = string.Format(Strings.IDS_ERR_VERSION_MISMATCH, (object) "letter-list", (object) str, (object) "1.0");
            num = 20;
            continue;
          case 27:
            if (name == "letter-list")
            {
              num = 1;
              continue;
            }
            goto label_39;
          case 28:
            if (this.j == 1)
            {
              num = 0;
              continue;
            }
            goto label_3;
          default:
            num = !(name == "code") ? 3 : 21;
            continue;
        }
      }
label_3:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_TAG_MUST_BE_IN, (object) "body", (object) "letter-list");
label_4:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_TAG_MUST_BE_IN, (object) "letter", (object) "body");
label_9:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_TAG_MUST_BE_IN, (object) "code", (object) "letter");
label_37:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_TAG_MUST_BE_IN, (object) "sp", (object) "letter");
label_39:
      ++this.j;
    }

    protected override void Characters(string chars, int length)
    {
      int num = 7;
      int index;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (this.k)
            {
              num = 6;
              continue;
            }
            index = 0;
            num = 2;
            continue;
          case 1:
            goto label_15;
          case 2:
          case 4:
            num = 10;
            continue;
          case 3:
            num = 0;
            continue;
          case 5:
            ++index;
            num = 4;
            continue;
          case 6:
            goto label_8;
          case 8:
            if (1 == 0)
              ;
            this.a((ushort) chars[index]);
            num = 5;
            continue;
          case 9:
            if (!HandlerBase.IsWhitespace(chars[index]))
            {
              num = 8;
              continue;
            }
            goto case 5;
          case 10:
            num = index < length ? 9 : 1;
            continue;
          default:
            if (this.l)
            {
              num = 3;
              continue;
            }
            goto label_17;
        }
      }
label_15:
      return;
label_17:
      return;
label_8:
      uint result = 0U;
      uint.TryParse(chars, out result);
      this.a((ushort) result);
      this.k = false;
    }

    protected override void EndElement(string name)
    {
label_2:
      --this.j;
      int num = 2;
      while (true)
      {
        switch (num)
        {
          case 0:
            this.m = false;
            num = 6;
            continue;
          case 1:
            goto label_7;
          case 2:
            if (name == "code")
            {
              num = 4;
              continue;
            }
            if (1 == 0)
              ;
            num = 3;
            continue;
          case 3:
            num = !(name == "letter") ? 5 : 1;
            continue;
          case 4:
            goto label_8;
          case 5:
            if (name == "body")
            {
              num = 0;
              continue;
            }
            goto label_14;
          case 6:
            goto label_10;
          default:
            goto label_2;
        }
      }
label_10:
      return;
label_14:
      return;
label_7:
      this.l = false;
      return;
label_8:
      this.k = false;
    }

    private void a(ushort A_0)
    {
      this.i[A_0] = true;
    }

    private class OutputGlyphList : Dictionary<ushort, bool>
    {
    }
  }
}
