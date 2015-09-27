// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.FileOverwriteConfirmDialog
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System.IO;
using System.Windows;

namespace NintendoWare.Font
{
  internal class FileOverwriteConfirmDialog
  {
    public static void Show(string file)
    {
      int num = 2;
      MessageBoxResult messageBoxResult;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_6;
          case 1:
            if (messageBoxResult != MessageBoxResult.OK)
            {
              num = 0;
              continue;
            }
            goto label_5;
          case 3:
            messageBoxResult = MessageBox.Show(string.Format(Strings.IDS_MSG_OVERWRITE_FILE, (object) file), Strings.IDS_MSG_OVERWRITE_FILE_TITLE, MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
            num = 1;
            continue;
          default:
            if (1 == 0)
              ;
            if (File.Exists(file))
            {
              num = 3;
              continue;
            }
            goto label_10;
        }
      }
label_10:
      return;
label_6:
      throw new ConvertCancelException();
label_5:;
    }
  }
}
