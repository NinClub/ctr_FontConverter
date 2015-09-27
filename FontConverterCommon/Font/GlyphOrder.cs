// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.GlyphOrder
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;
using System.Collections.Generic;
using System.Xml;

namespace NintendoWare.Font
{
  public class GlyphOrder : HandlerBase
  {
    private readonly List<ushort> n = new List<ushort>();
    private readonly bool[] o = new bool[65536];
    public const ushort NullGlyph = (ushort) 65535;
    private const int m_na = 65536;
    private const string b = "letter-order";
    private const string c = "area";
    private const string d = "body";
    private const string e = "order";
    private const string f = "code";
    private const string g = "null";
    private const string h = "sp";
    private const string i = "width";
    private const string j = "height";
    private const string k = "version";
    private const string l = "1.1";
    private const string m = "1.0";
    private int p;
    private int q;
    private bool r;
    private bool s;
    private bool t;
    private string u;
    private int v;
    private bool w;
    private bool x;
    private bool y;

    public GlyphOrder()
    {
      this.p = 16;
      this.q = 0;
      this.v = 0;
      this.w = false;
      this.x = false;
      this.y = false;
      this.r = false;
      this.s = false;
      this.u = (string) null;
      this.t = false;
    }

    public bool IsValid()
    {
      return this.s;
    }

    public int GetHNum()
    {
      return this.p;
    }

    public int GetVNum()
    {
      return this.q;
    }

    public void Load(string orderFilePath)
    {
label_2:
      this.u = orderFilePath;
      int num1 = 1;
      while (true)
      {
        switch (num1)
        {
          case 0:
            num1 = 7;
            continue;
          case 1:
            try
            {
              XmlReader reader = this.CreateReader(orderFilePath);
              try
              {
                this.Parse(reader);
              }
              finally
              {
                int num2 = 1;
                while (true)
                {
                  switch (num2)
                  {
                    case 0:
                      goto label_16;
                    case 2:
                      ((IDisposable) reader).Dispose();
                      num2 = 0;
                      continue;
                    default:
                      if (reader != null)
                      {
                        num2 = 2;
                        continue;
                      }
                      goto label_16;
                  }
                }
label_16:;
              }
            }
            catch (HandlerBaseException ex)
            {
              if (this.Error != null)
                throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_XERCESC_MSG, (object) this.Error);
              throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_INVALID_ORDER_FILE);
            }
            catch (GeneralException ex)
            {
              throw;
            }
            catch (XmlException ex)
            {
              throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_XERCESC_MSG, (object) ex.Message);
            }
            num1 = 2;
            continue;
          case 2:
            num1 = this.p > 0 ? 3 : 4;
            continue;
          case 3:
            if (this.r)
            {
              num1 = 0;
              continue;
            }
            this.q = (this.n.Count + this.p - 1) / this.p;
            num1 = 6;
            continue;
          case 4:
            goto label_7;
          case 5:
            goto label_8;
          case 6:
            goto label_27;
          case 7:
            if (this.q <= 0)
            {
              if (1 == 0)
                ;
              num1 = 5;
              continue;
            }
            goto label_27;
          default:
            goto label_2;
        }
      }
label_7:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_INVALID_ORDER_WIDTH, (object) this.p);
label_8:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_INVALID_ORDER_HEIGHT, (object) (bool) (this.r ? 1 : 0));
label_27:
      this.s = true;
    }

    public ushort GetCharCode(int x, int y)
    {
      int num = 8;
      int index;
      while (true)
      {
        switch (num)
        {
          case 0:
            num = 2;
            continue;
          case 1:
            num = 9;
            continue;
          case 2:
            num = this.p > x ? 4 : 3;
            continue;
          case 3:
            goto label_9;
          case 4:
            if (y >= 0)
            {
              num = 1;
              continue;
            }
            goto label_4;
          case 5:
            if (index >= this.n.Count)
            {
              num = 6;
              continue;
            }
            goto label_18;
          case 6:
            goto label_10;
          case 7:
            goto label_4;
          case 9:
            if (1 == 0)
              ;
            if (this.q <= y)
            {
              num = 7;
              continue;
            }
            index = y * this.p + x;
            num = 5;
            continue;
          default:
            if (x >= 0)
            {
              num = 0;
              continue;
            }
            goto label_9;
        }
      }
label_4:
      return ushort.MaxValue;
label_9:
      return ushort.MaxValue;
label_10:
      return ushort.MaxValue;
label_18:
      return this.n[index];
    }

    protected override void StartElement(string name, HandlerBase.AttributeList attributes)
    {
      int num = 20;
      string s1;
      string str1;
      bool flag;
      string s2;
      while (true)
      {
        switch (num)
        {
          case 0:
            num = 21;
            continue;
          case 1:
            str1 = attributes.GetValue("version");
            flag = false;
            num = 40;
            continue;
          case 2:
            num = !(name == "area") ? 32 : 17;
            continue;
          case 3:
            num = 9;
            continue;
          case 4:
            goto label_22;
          case 5:
            if (str1 != "1.1")
            {
              num = 37;
              continue;
            }
            goto case 16;
          case 6:
            if (str1 != "1.0")
            {
              num = 24;
              continue;
            }
            this.t = true;
            num = 16;
            continue;
          case 7:
          case 13:
          case 14:
          case 15:
          case 25:
          case 27:
            goto label_65;
          case 8:
            if (this.w)
            {
              num = 11;
              continue;
            }
            goto label_27;
          case 9:
            if (s1 != null)
            {
              num = 33;
              continue;
            }
            goto label_65;
          case 10:
            num = !(name == "sp") ? 43 : 30;
            continue;
          case 11:
            this.a((ushort) 32);
            num = 13;
            continue;
          case 12:
            if (this.Error == null)
            {
              num = 4;
              continue;
            }
            goto label_65;
          case 16:
          case 31:
          case 48:
            num = 18;
            continue;
          case 17:
            num = 41;
            continue;
          case 18:
            if (flag)
            {
              num = 19;
              continue;
            }
            goto label_65;
          case 19:
            num = 12;
            continue;
          case 21:
            if (this.w)
            {
              num = 39;
              continue;
            }
            goto label_29;
          case 22:
            if (1 == 0)
              ;
            this.y = true;
            num = 25;
            continue;
          case 23:
            if (name == "letter-order")
            {
              num = 1;
              continue;
            }
            goto label_65;
          case 24:
            flag = true;
            num = 48;
            continue;
          case 26:
            flag = true;
            num = 31;
            continue;
          case 28:
            num = 36;
            continue;
          case 29:
            if (this.w)
            {
              num = 42;
              continue;
            }
            goto label_62;
          case 30:
            num = 8;
            continue;
          case 32:
            num = !(name == "body") ? 23 : 28;
            continue;
          case 33:
            int.TryParse(s1, out this.q);
            this.r = true;
            num = 27;
            continue;
          case 34:
            num = !(name == "order") ? 2 : 45;
            continue;
          case 35:
            int.TryParse(s2, out this.p);
            num = 3;
            continue;
          case 36:
            if (this.v == 1)
            {
              num = 22;
              continue;
            }
            goto label_3;
          case 37:
            num = 6;
            continue;
          case 38:
            s2 = attributes.GetValue("width");
            s1 = attributes.GetValue("height");
            num = 44;
            continue;
          case 39:
            this.x = true;
            num = 14;
            continue;
          case 40:
            num = str1 != null ? 5 : 26;
            continue;
          case 41:
            if (this.y)
            {
              num = 38;
              continue;
            }
            goto label_48;
          case 42:
            this.a(ushort.MaxValue);
            num = 15;
            continue;
          case 43:
            num = !(name == "code") ? 34 : 0;
            continue;
          case 44:
            if (s2 != null)
            {
              num = 35;
              continue;
            }
            goto case 3;
          case 45:
            num = 46;
            continue;
          case 46:
            if (this.y)
            {
              num = 49;
              continue;
            }
            goto label_23;
          case 47:
            num = 29;
            continue;
          case 49:
            this.w = true;
            num = 7;
            continue;
          default:
            num = !(name == "null") ? 10 : 47;
            continue;
        }
      }
label_3:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_TAG_MUST_BE_IN, (object) "body", (object) "letter-order");
label_22:
      string str2 = "1.1" + " or " + "1.0";
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_VERSION_MISMATCH, (object) "letter-order", (object) str1, (object) str2);
label_23:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_TAG_MUST_BE_IN, (object) "order", (object) "body");
label_27:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_TAG_MUST_BE_IN, (object) "sp", (object) "order");
label_29:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_TAG_MUST_BE_IN, (object) "code", (object) "order");
label_48:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_TAG_MUST_BE_IN, (object) "area", (object) "body");
label_62:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_TAG_MUST_BE_IN, (object) "null", (object) "order");
label_65:
      ++this.v;
    }

    protected override void Characters(string chars, int length)
    {
      int num = 8;
      int index;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (1 == 0)
              goto case 2;
            else
              goto case 2;
          case 1:
            goto label_15;
          case 2:
            num = 10;
            continue;
          case 3:
            ++index;
            num = 0;
            continue;
          case 4:
            this.a((ushort) chars[index]);
            num = 3;
            continue;
          case 5:
            if (!HandlerBase.IsWhitespace(chars[index]))
            {
              num = 4;
              continue;
            }
            goto case 3;
          case 6:
            if (this.x)
            {
              num = 9;
              continue;
            }
            index = 0;
            num = 2;
            continue;
          case 7:
            num = 6;
            continue;
          case 9:
            goto label_7;
          case 10:
            num = index < length ? 5 : 1;
            continue;
          default:
            if (this.w)
            {
              num = 7;
              continue;
            }
            goto label_17;
        }
      }
label_15:
      return;
label_17:
      return;
label_7:
      uint result = 0U;
      uint.TryParse(chars, out result);
      this.a((ushort) result);
      this.x = false;
    }

    protected override void EndElement(string name)
    {
label_2:
      --this.v;
      int num = 6;
      while (true)
      {
        switch (num)
        {
          case 0:
            this.y = false;
            if (1 == 0)
              ;
            num = 4;
            continue;
          case 1:
            goto label_7;
          case 2:
            num = !(name == "order") ? 5 : 3;
            continue;
          case 3:
            goto label_6;
          case 4:
            goto label_10;
          case 5:
            if (name == "body")
            {
              num = 0;
              continue;
            }
            goto label_12;
          case 6:
            num = !(name == "code") ? 2 : 1;
            continue;
          default:
            goto label_2;
        }
      }
label_10:
      return;
label_12:
      return;
label_6:
      this.w = false;
      return;
label_7:
      this.x = false;
    }

    private void a(ushort A_0)
    {
      int num = 3;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (this.o[(int) A_0])
            {
              num = 5;
              continue;
            }
            goto label_12;
          case 1:
            num = 0;
            continue;
          case 2:
            num = 4;
            continue;
          case 4:
            if (!this.t)
            {
              num = 1;
              continue;
            }
            goto label_12;
          case 5:
            goto label_5;
          default:
            if ((int) A_0 != (int) ushort.MaxValue)
            {
              if (1 == 0)
                ;
              num = 2;
              continue;
            }
            goto label_12;
        }
      }
label_5:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_MULTIPLE_ORDER_LETTER, (object) A_0, (object) (char) A_0);
label_12:
      this.o[(int) A_0] = true;
      this.n.Add(A_0);
    }
  }
}
