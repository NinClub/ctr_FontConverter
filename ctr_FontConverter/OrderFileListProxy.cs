// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.OrderFileListProxy
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace NintendoWare.Font
{
  public class OrderFileListProxy
  {
    private List<NnsFileInfo> a;

    public bool IsLoaded { get; private set; }

    public string OrderFilesDir { get; private set; }

    public List<NnsFileInfo> OrderFiles
    {
      get
      {
label_2:
        int num = 2;
        BackgroundWorker backgroundWorker;
        while (true)
        {
          switch (num)
          {
            case 0:
              num = 1;
              continue;
            case 1:
              if (this.a == null)
              {
                num = 5;
                continue;
              }
              goto label_11;
            case 2:
              if (!this.IsLoaded)
              {
                if (1 == 0)
                  ;
                num = 0;
                continue;
              }
              goto label_11;
            case 3:
              backgroundWorker.RunWorkerCompleted += (RunWorkerCompletedEventHandler) ((A_0, A_1) => this.a((NnsXmlFileList) A_1.Result));
              this.a = new List<NnsFileInfo>()
              {
                new NnsFileInfo()
                {
                  Title = Strings.IDS_NOW_READING,
                  FileName = (string) null
                }
              };
              num = 4;
              continue;
            case 4:
              goto label_11;
            case 5:
              backgroundWorker = new BackgroundWorker();
              backgroundWorker.DoWork += new DoWorkEventHandler(this.a);
              backgroundWorker.RunWorkerAsync();
              num = 3;
              continue;
            default:
              goto label_2;
          }
        }
label_11:
        return this.a;
      }
    }

    public event EventHandler Loaded;

    private void a(object A_0, DoWorkEventArgs A_1)
    {
      NnsXmlFileList nnsXmlFileList = new NnsXmlFileList("xlor", ".xlor");
      nnsXmlFileList.CollectFiles();
      A_1.Result = (object) nnsXmlFileList;
    }

    private void a(NnsXmlFileList A_0)
    {
      int num1 = 2;
      List<NnsFileInfo> list;
      EventHandler eventHandler;
      int index;
      while (true)
      {
        switch (num1)
        {
          case 0:
            EventArgs e = new EventArgs();
            eventHandler((object) this, e);
            num1 = 9;
            continue;
          case 1:
            int num2 = (int) MessageBox.Show(Strings.IDS_WARN_NO_GLYPH_ORDER, Strings.IDS_ERROR, MessageBoxButton.OK, MessageBoxImage.Hand);
            num1 = 6;
            continue;
          case 3:
            if (index < A_0.GetNum())
            {
              NnsFileInfo nnsFileInfo = A_0[index];
              list.Add(nnsFileInfo);
              ++index;
              num1 = 7;
              continue;
            }
            num1 = 4;
            continue;
          case 4:
            this.a = list;
            this.IsLoaded = true;
            eventHandler = this.b;
            num1 = 8;
            continue;
          case 5:
          case 7:
            num1 = 3;
            continue;
          case 6:
            this.OrderFilesDir = A_0.GetFileDir();
            list = new List<NnsFileInfo>(A_0.GetNum());
            index = 0;
            num1 = 5;
            continue;
          case 8:
            if (1 == 0)
              ;
            if (eventHandler != null)
            {
              num1 = 0;
              continue;
            }
            goto label_16;
          case 9:
            goto label_12;
          default:
            if (A_0.GetNum() == 0)
            {
              num1 = 1;
              continue;
            }
            goto case 6;
        }
      }
label_12:
      return;
label_16:;
    }
  }
}
