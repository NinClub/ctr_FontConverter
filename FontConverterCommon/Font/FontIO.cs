// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.FontIO
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;
using System.IO;

namespace NintendoWare.Font
{
  public abstract class FontIO
  {
    public static void ValidateOrderFile(string file)
    {
      int num = 3;
      GlyphOrder glyphOrder;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_8;
          case 1:
            goto label_9;
          case 2:
            num = glyphOrder.GetHNum() >= 0 ? 4 : 5;
            continue;
          case 4:
            if (glyphOrder.GetVNum() < 0)
            {
              num = 1;
              continue;
            }
            goto label_12;
          case 5:
            goto label_7;
          default:
            if (!FontIO.IsFileExists(file))
            {
              if (1 == 0)
                ;
              num = 0;
              continue;
            }
            glyphOrder = new GlyphOrder();
            glyphOrder.Load(file);
            num = 2;
            continue;
        }
      }
label_12:
      return;
label_7:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_INVALID_ORDER_WIDTH, (object) glyphOrder.GetHNum());
label_8:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_FILE_NOT_EXISTS, (object) file);
label_9:
      throw GlCm.ErrMsg(ErrorType.Xml, Strings.IDS_ERR_INVALID_ORDER_HEIGHT, (object) glyphOrder.GetVNum());
    }

    public static void ValidateOutputPath(string file)
    {
      int num = 0;
      string directoryName;
      while (true)
      {
        switch (num)
        {
          case 1:
            goto label_9;
          case 2:
            goto label_12;
          case 3:
            num = 7;
            continue;
          case 4:
            goto label_16;
          case 5:
            goto label_4;
          case 6:
            goto label_20;
          case 7:
            if (!FontIO.IsFileWritable(file))
            {
              num = 5;
              continue;
            }
            goto label_15;
          case 8:
            if (!Directory.Exists(directoryName))
            {
              num = 2;
              continue;
            }
            goto label_3;
          case 9:
            if (1 == 0)
              ;
            num = !Directory.Exists(file) ? 11 : 4;
            continue;
          case 10:
            num = !(directoryName == string.Empty) ? 8 : 6;
            continue;
          case 11:
            if (!File.Exists(file))
            {
              directoryName = Path.GetDirectoryName(file);
              num = 10;
              continue;
            }
            num = 3;
            continue;
          default:
            num = !(file == string.Empty) ? 9 : 1;
            continue;
        }
      }
label_20:
      return;
label_4:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_FILE_IS_READONLY, (object) file);
label_3:
      return;
label_9:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_FILE_NOT_SPECIFIED);
label_12:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_DIRECTORY_NOT_EXISTS, (object) directoryName);
label_16:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_FILE_IS_DIRECTORY, (object) file);
label_15:;
    }

    public abstract void ValidateInput();

    protected static bool IsFileExists(string file)
    {
      if (file.Length == 0)
        throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_FILE_NOT_SPECIFIED);
      if (1 == 0)
        ;
      return File.Exists(file);
    }

    protected static bool IsFileWritable(string file)
    {
      bool flag;
      try
      {
        flag = (File.GetAttributes(file) & FileAttributes.ReadOnly) == (FileAttributes) 0;
        goto label_4;
      }
      catch (IOException ex)
      {
      }
      catch (NotSupportedException ex)
      {
      }
      return false;
label_4:
      if (1 == 0)
        ;
      return flag;
    }

    protected class ArrangeInfo
    {
      public int Width { get; set; }

      public int Ascent { get; set; }

      public int Descent { get; set; }

      public int BaselinePos { get; set; }
    }
  }
}
