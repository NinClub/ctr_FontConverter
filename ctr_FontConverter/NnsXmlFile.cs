// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.NnsXmlFile
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System;
using System.IO;
using System.Xml;

namespace NintendoWare.Font
{
  public class NnsXmlFile : HandlerBase
  {
    private const string a = "letter-order";
    private const string b = "head";
    private const string c = "title";
    private const string d = "comment";
    private const string e = "version";
    private const string f = "1.0";
    private bool g;
    private bool h;
    private bool i;
    private bool j;
    private int k;
    private NnsFileInfo l;

    public NnsXmlFile()
    {
      this.g = false;
      this.k = 0;
      this.h = false;
      this.i = false;
      this.j = false;
      this.l = (NnsFileInfo) null;
    }

    public bool IsSuccess()
    {
      return this.g;
    }

    public void Load(NnsFileInfo nnsFileInfo, string filePath)
    {
      this.g = false;
      this.h = false;
      this.i = false;
      this.j = false;
      this.k = 0;
      this.l = nnsFileInfo;
      nnsFileInfo.Path = filePath;
      nnsFileInfo.FileName = Path.GetFileName(filePath);
      try
      {
        XmlReader reader = this.CreateReader(filePath);
        try
        {
          if (1 == 0)
            ;
          this.Parse(reader);
        }
        finally
        {
          int num = 0;
          while (true)
          {
            switch (num)
            {
              case 1:
                ((IDisposable) reader).Dispose();
                num = 2;
                continue;
              case 2:
                goto label_9;
              default:
                if (reader != null)
                {
                  num = 1;
                  continue;
                }
                goto label_9;
            }
          }
label_9:;
        }
      }
      catch (HandlerBaseException ex)
      {
        this.l = (NnsFileInfo) null;
        if (this.Error != null)
          throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_XERCESC_MSG, (object) this.Error);
        throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_XERCESC_UNKNOWN);
      }
      catch (XmlException ex)
      {
        this.l = (NnsFileInfo) null;
        throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_XERCESC_MSG, (object) ex.Message);
      }
      catch
      {
        this.l = (NnsFileInfo) null;
        throw;
      }
      this.l = (NnsFileInfo) null;
      this.g = true;
    }

    protected override void StartElement(string name, HandlerBase.AttributeList attributes)
    {
      int num = 8;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (this.h)
            {
              num = 15;
              continue;
            }
            goto label_13;
          case 1:
            this.j = true;
            num = 13;
            continue;
          case 2:
            num = 3;
            continue;
          case 3:
            if (this.k == 2)
            {
              num = 10;
              continue;
            }
            goto label_18;
          case 4:
            num = 16;
            continue;
          case 5:
          case 13:
          case 17:
            goto label_28;
          case 6:
            num = 0;
            continue;
          case 7:
            num = 18;
            continue;
          case 9:
            if (name == "head")
            {
              num = 7;
              continue;
            }
            goto label_28;
          case 10:
            this.i = true;
            num = 17;
            continue;
          case 11:
            this.h = true;
            num = 5;
            continue;
          case 12:
            if (this.k == 2)
            {
              num = 1;
              continue;
            }
            goto label_13;
          case 14:
            num = !(name == "title") ? 9 : 6;
            continue;
          case 15:
            num = 12;
            continue;
          case 16:
            if (1 == 0)
              ;
            if (this.h)
            {
              num = 2;
              continue;
            }
            goto label_18;
          case 18:
            if (this.k == 1)
            {
              num = 11;
              continue;
            }
            goto label_14;
          default:
            num = !(name == "comment") ? 14 : 4;
            continue;
        }
      }
label_13:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_TAG_MUST_BE_IN, (object) "title", (object) "head");
label_14:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_TAG_MUST_BE_IN, (object) "head", (object) "letter-order");
label_18:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_TAG_MUST_BE_IN, (object) "comment", (object) "head");
label_28:
      ++this.k;
    }

    protected override void Characters(string chars, int length)
    {
      int num = 3;
      while (true)
      {
        switch (num)
        {
          case 0:
            this.l.Title += chars;
            num = 2;
            continue;
          case 1:
            if (1 == 0)
              ;
            if (this.j)
            {
              num = 0;
              continue;
            }
            goto label_8;
          case 2:
            goto label_4;
          case 4:
            goto label_9;
          default:
            num = !this.i ? 1 : 4;
            continue;
        }
      }
label_4:
      return;
label_8:
      return;
label_9:
      this.l.Comment += chars;
    }

    protected override void EndElement(string name)
    {
label_2:
      --this.k;
      int num = 2;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_10;
          case 1:
            this.h = false;
            num = 0;
            continue;
          case 2:
            num = !(name == "comment") ? 3 : 4;
            continue;
          case 3:
            num = !(name == "title") ? 6 : 5;
            continue;
          case 4:
            goto label_4;
          case 5:
            goto label_7;
          case 6:
            if (name == "head")
            {
              num = 1;
              continue;
            }
            goto label_12;
          default:
            goto label_2;
        }
      }
label_10:
      return;
label_4:
      if (1 == 0)
        ;
      this.i = false;
      return;
label_12:
      return;
label_7:
      this.j = false;
    }
  }
}
