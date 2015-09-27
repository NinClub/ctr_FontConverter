// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.NnsXmlFileList
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace NintendoWare.Font
{
  public class NnsXmlFileList
  {
    private readonly NnsXmlFileList.NnsFileList a = new NnsXmlFileList.NnsFileList();
    private string b;
    private string c;

    public NnsFileInfo this[int no]
    {
      get
      {
        return this.a[no];
      }
    }

    public NnsXmlFileList(string findDir, string findExt)
    {
      this.b = findDir;
      this.c = findExt;
    }

    public static string GetExeFileDir()
    {
      return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
    }

    public int GetNum()
    {
      return this.a.Count;
    }

    public string GetFileDir()
    {
      return Path.Combine(NnsXmlFileList.GetExeFileDir(), this.b);
    }

    public void CollectFiles()
    {
label_2:
      string[] strArray1 = (string[]) null;
      string path2 = this.b;
      string b = this.c;
      string path1 = Path.Combine(NnsXmlFileList.GetExeFileDir(), path2);
      int num = 10;
      while (true)
      {
        NnsFileInfo nnsFileInfo;
        string path3;
        string filePath;
        string searchPattern;
        NnsXmlFile nnsXmlFile;
        int index;
        string[] strArray2;
        string extension;
        switch (num)
        {
          case 0:
            goto label_28;
          case 1:
            try
            {
              strArray1 = Directory.GetFiles(path1, searchPattern);
              goto label_23;
            }
            catch (IOException ex)
            {
              goto label_23;
            }
            catch (UnauthorizedAccessException ex)
            {
              goto label_23;
            }
          case 2:
            searchPattern = "*" + b;
            num = 1;
            continue;
          case 3:
          case 12:
            num = 9;
            continue;
          case 4:
            try
            {
              nnsXmlFile.Load(nnsFileInfo, filePath);
            }
            catch (GeneralException ex)
            {
              ProgressControl.Warning(ex.GetMsg());
            }
            num = 14;
            continue;
          case 5:
            nnsXmlFile = new NnsXmlFile();
            strArray2 = strArray1;
            index = 0;
            num = 12;
            continue;
          case 6:
            if (strArray1 != null)
            {
              num = 5;
              continue;
            }
            goto label_28;
          case 7:
            if (string.Equals(extension, b, StringComparison.InvariantCultureIgnoreCase))
            {
              num = 13;
              continue;
            }
            break;
          case 8:
            this.a.Add(nnsFileInfo);
            num = 11;
            continue;
          case 9:
            if (index >= strArray2.Length)
            {
              num = 0;
              continue;
            }
            path3 = strArray2[index];
            Path.GetFileNameWithoutExtension(path3);
            extension = Path.GetExtension(path3);
            num = 7;
            continue;
          case 10:
            if (Directory.Exists(path1))
            {
              num = 2;
              continue;
            }
            goto label_23;
          case 11:
            if (1 == 0)
              break;
            break;
          case 13:
            nnsFileInfo = new NnsFileInfo();
            filePath = path3;
            num = 4;
            continue;
          case 14:
            if (nnsXmlFile.IsSuccess())
            {
              num = 8;
              continue;
            }
            break;
          default:
            goto label_2;
        }
        ++index;
        num = 3;
        continue;
label_23:
        num = 6;
      }
label_28:
      this.a.Sort();
    }

    private class NnsFileList : List<NnsFileInfo>
    {
    }
  }
}
