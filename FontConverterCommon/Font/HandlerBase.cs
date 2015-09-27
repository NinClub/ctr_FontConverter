// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.HandlerBase
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System.Xml;
using System.Xml.Schema;

namespace NintendoWare.Font
{
  public abstract class HandlerBase
  {
    private string m_sa;

    protected string Error
    {
      get
      {
        return this.m_sa;
      }
      set
      {
        this.m_sa = value;
      }
    }

    public static bool IsWhitespace(char c)
    {
label_2:
      char ch = c;
      if (1 == 0)
        ;
      int num = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
            switch (ch)
            {
              case '\t':
              case '\n':
              case '\r':
                goto label_6;
              case '\v':
              case '\f':
                goto label_10;
              default:
                num = 1;
                continue;
            }
          case 1:
            num = 3;
            continue;
          case 2:
            goto label_6;
          case 3:
            if ((int) ch == 32)
            {
              num = 2;
              continue;
            }
            goto label_10;
          default:
            goto label_2;
        }
      }
label_6:
      return true;
label_10:
      return false;
    }

    public XmlReader CreateReader(string filePath)
    {
      if (1 == 0)
        ;
      XmlReaderSettings settings = new XmlReaderSettings();
      settings.ProhibitDtd = false;
      settings.ValidationType = ValidationType.DTD;
      settings.ValidationEventHandler += new ValidationEventHandler(this.a);
      return XmlReader.Create(filePath, settings);
    }

    public void Parse(XmlReader reader)
    {
label_2:
      HandlerBase.AttributeList attributes = new HandlerBase.AttributeList(reader);
      int num = 7;
      XmlNodeType nodeType;
      while (true)
      {
        switch (num)
        {
          case 0:
          case 1:
          case 4:
          case 7:
          case 10:
label_8:
            num = 9;
            continue;
          case 2:
            num = 8;
            continue;
          case 3:
            if (reader.IsEmptyElement)
            {
              num = 5;
              continue;
            }
            goto case 0;
          case 5:
            this.EndElement(reader.Name);
            num = 0;
            continue;
          case 6:
            switch (nodeType)
            {
              case XmlNodeType.Element:
                this.StartElement(reader.Name, attributes);
                if (1 == 0)
                  ;
                num = 3;
                continue;
              case XmlNodeType.Attribute:
                goto label_8;
              case XmlNodeType.Text:
                this.Characters(reader.Value, reader.Value.Length);
                num = 4;
                continue;
              default:
                num = 2;
                continue;
            }
          case 8:
            if (nodeType == XmlNodeType.EndElement)
            {
              this.EndElement(reader.Name);
              num = 1;
              continue;
            }
            num = 11;
            continue;
          case 9:
            if (!reader.Read())
            {
              num = 12;
              continue;
            }
            nodeType = reader.NodeType;
            num = 6;
            continue;
          case 11:
            num = 10;
            continue;
          case 12:
            goto label_20;
          default:
            goto label_2;
        }
      }
label_20:;
    }

    protected abstract void StartElement(string name, HandlerBase.AttributeList attributes);

    protected abstract void EndElement(string name);

    protected abstract void Characters(string chars, int length);

    private void a(object A_0, ValidationEventArgs A_1)
    {
label_2:
      string str = string.Format(Strings.IDS_ERR_SAX_MSG, (object) A_1.Severity, (object) A_1.Exception.LineNumber, (object) A_1.Exception.LinePosition, (object) A_1.Message);
      int num = 1;
      while (true)
      {
        switch (num)
        {
          case 0:
            this.m_sa = str;
            num = 2;
            continue;
          case 1:
            if (this.m_sa == null)
            {
              num = 0;
              continue;
            }
            goto label_8;
          case 2:
            goto label_7;
          default:
            goto label_2;
        }
      }
label_8:
      return;
label_7:
      if (1 != 0)
        ;
    }

    public class AttributeList
    {
      private XmlReader a;

      public AttributeList(XmlReader reader)
      {
        this.a = reader;
      }

      public string GetValue(string name)
      {
        return this.a.GetAttribute(name);
      }
    }
  }
}
