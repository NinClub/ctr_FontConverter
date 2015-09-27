// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.GeneralException
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;
using System.Text;

namespace NintendoWare.Font
{
  public class GeneralException : Exception
  {
    private static readonly string[] a;
    private ErrorType b;
    private string c;

    static GeneralException()
    {
      if (1 == 0)
        ;
      GeneralException.a = new string[10]
      {
        Strings.IDS_ERRORTYPE_NULL,
        Strings.IDS_ERRORTYPE_IMAGE,
        Strings.IDS_ERRORTYPE_BMP,
        Strings.IDS_ERRORTYPE_TGA,
        Strings.IDS_ERRORTYPE_CMDLINE,
        Strings.IDS_ERRORTYPE_FIO,
        Strings.IDS_ERRORTYPE_FONT,
        Strings.IDS_ERRORTYPE_INTERNAL,
        Strings.IDS_ERRORTYPE_PARAMETER,
        Strings.IDS_ERRORTYPE_XML
      };
    }

    public string GetMsg()
    {
      return this.c;
    }

    public void SetMsg(string msg)
    {
      this.c = msg;
    }

    public void SetMsgFormat(ErrorType type, string formatId, params object[] paramAry)
    {
      if (1 == 0)
        ;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(GeneralException.a[(int) type]);
      stringBuilder.Append(":\n");
      stringBuilder.Append(string.Format(formatId, paramAry));
      this.c = stringBuilder.ToString();
      this.b = type;
    }
  }
}
