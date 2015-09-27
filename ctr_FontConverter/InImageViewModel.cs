// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.InImageViewModel
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System;
using System.Collections.Generic;
using System.IO;

namespace NintendoWare.Font
{
  public class InImageViewModel : InSettingViewModel
  {
    private const string a = "Supported Images (*.bmp, *.tga)|*.bmp;*.tga|Bitmap Images (*.bmp)|*.bmp|Targa Images (*.tga)|*.tga|all files (*.*)|*.*";
    private readonly InImageSettings b;
    private static GlyphImageFormatViewModel[] c;
    private List<NnsFileInfo> d;
    private OrderFileListProxy e;
    private bool f;

    public static GlyphImageFormatViewModel[] GlyphImageFormats
    {
      get
      {
        int num = 11;
        while (true)
        {
          List<GlyphImageFormatViewModel> list;
          string str1;
          string str2;
          switch (num)
          {
            case 0:
              list.Add(new GlyphImageFormatViewModel("RGB5A1", GlyphImageInfo.GetGlyphImageInfo(GlyphImageFormat.RGB5A1)));
              list.Add(new GlyphImageFormatViewModel("RGBA4", GlyphImageInfo.GetGlyphImageInfo(GlyphImageFormat.RGBA4)));
              list.Add(new GlyphImageFormatViewModel("RGB8", GlyphImageInfo.GetGlyphImageInfo(GlyphImageFormat.RGB8)));
              num = 16;
              continue;
            case 1:
              if (1 == 0)
                ;
              num = 14;
              continue;
            case 2:
              num = ConverterEnvironment.IsRvl ? 5 : 1;
              continue;
            case 3:
              str1 = "LA";
              break;
            case 4:
              str1 = "IA";
              break;
            case 5:
              str2 = "I";
              goto label_22;
            case 6:
              if (ConverterEnvironment.IsCtr)
              {
                num = 0;
                continue;
              }
              goto case 16;
            case 7:
              if (ConverterEnvironment.IsRvl)
              {
                num = 15;
                continue;
              }
              goto case 12;
            case 8:
              num = 3;
              continue;
            case 9:
              num = 2;
              continue;
            case 10:
              num = ConverterEnvironment.IsRvl ? 4 : 8;
              continue;
            case 12:
              num = 6;
              continue;
            case 13:
              goto label_24;
            case 14:
              str2 = "A";
              goto label_22;
            case 15:
              list.Add(new GlyphImageFormatViewModel("RGB5A3", GlyphImageInfo.GetGlyphImageInfo(GlyphImageFormat.RGB5A3)));
              num = 12;
              continue;
            case 16:
              list.Add(new GlyphImageFormatViewModel("RGBA8", GlyphImageInfo.GetGlyphImageInfo(GlyphImageFormat.RGBA8)));
              InImageViewModel.c = list.ToArray();
              num = 13;
              continue;
            default:
              if (InImageViewModel.c == null)
              {
                num = 9;
                continue;
              }
              goto label_24;
          }
          string str3 = str1;
          list = new List<GlyphImageFormatViewModel>(10);
          string str4;
          list.Add(new GlyphImageFormatViewModel(str4 + "4", GlyphImageInfo.GetGlyphImageInfo(GlyphImageFormat.A4)));
          list.Add(new GlyphImageFormatViewModel(str4 + "8", GlyphImageInfo.GetGlyphImageInfo(GlyphImageFormat.A8)));
          list.Add(new GlyphImageFormatViewModel(str3 + "4", GlyphImageInfo.GetGlyphImageInfo(GlyphImageFormat.LA4)));
          list.Add(new GlyphImageFormatViewModel(str3 + "8", GlyphImageInfo.GetGlyphImageInfo(GlyphImageFormat.LA8)));
          list.Add(new GlyphImageFormatViewModel("RGB565", GlyphImageInfo.GetGlyphImageInfo(GlyphImageFormat.RGB565)));
          num = 7;
          continue;
label_22:
          str4 = str2;
          num = 10;
        }
label_24:
        return InImageViewModel.c;
      }
    }

    public string OrderFile
    {
      get
      {
        if (!this.f)
          return (string) null;
        return this.b.OrderFile;
      }
      set
      {
        int num = 5;
        while (true)
        {
          switch (num)
          {
            case 0:
              goto label_10;
            case 1:
              goto label_3;
            case 2:
              goto label_8;
            case 3:
              if (value == this.b.OrderFile)
              {
                num = 2;
                continue;
              }
              goto label_11;
            case 4:
              num = this.f ? 3 : 0;
              continue;
            default:
              num = value != null ? 4 : 1;
              continue;
          }
        }
label_8:
        return;
label_10:
        return;
label_3:
        if (1 != 0)
          ;
        return;
label_11:
        this.b.OrderFile = value;
        this.OnPropertyChanged("OrderFile");
      }
    }

    public List<NnsFileInfo> OrderInfos
    {
      get
      {
        int num = 1;
        while (true)
        {
          switch (num)
          {
            case 0:
              this.e.Loaded += new EventHandler(this.a);
              this.d = this.e.OrderFiles;
              this.f = this.e.IsLoaded;
              this.IsReady = this.f;
              num = 2;
              continue;
            case 2:
              goto label_5;
            default:
              if (this.d == null)
              {
                num = 0;
                continue;
              }
              goto label_6;
          }
        }
label_5:
        if (1 == 0)
          ;
label_6:
        return this.d;
      }
      private set
      {
        this.d = value;
        this.OnPropertyChanged("OrderInfos");
        this.f = true;
      }
    }

    public GlyphImageFormat GlyphImageFormat
    {
      get
      {
        return this.b.GlyphImageFormat;
      }
      set
      {
        if (value == this.b.GlyphImageFormat)
          return;
        if (1 == 0)
          ;
        this.b.GlyphImageFormat = value;
        this.OnPropertyChanged("GlyphImageFormat");
      }
    }

    public bool AntiLinear
    {
      get
      {
        return this.b.AntiLinear;
      }
      set
      {
        if (value == this.b.AntiLinear)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.b.AntiLinear = value;
          this.OnPropertyChanged("AntiLinear");
        }
      }
    }

    public string FileFilter
    {
      get
      {
        return "Supported Images (*.bmp, *.tga)|*.bmp;*.tga|Bitmap Images (*.bmp)|*.bmp|Targa Images (*.tga)|*.tga|all files (*.*)|*.*";
      }
    }

    public InImageViewModel(InImageSettings settings, OrderFileListProxy orderFileListProxy)
    {
      this.DisplayName = "Image";
      this.b = settings;
      this.e = orderFileListProxy;
      this.SetPathHistory(this.b.FilePaths);
    }

    public override FontReader GetFontReader()
    {
      int num = 1;
      string orderFile;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_9;
          case 2:
            if (orderFile == null)
            {
              num = 3;
              continue;
            }
            goto label_10;
          case 3:
            goto label_5;
          default:
            if (1 == 0)
              ;
            if (!this.IsReady)
            {
              num = 0;
              continue;
            }
            orderFile = this.OrderFile;
            num = 2;
            continue;
        }
      }
label_5:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_ORDER_NOT_SELECTED);
label_9:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_NOW_READING);
label_10:
      return (FontReader) new ImageFontReader(this.CurrentPath, Path.Combine(this.e.OrderFilesDir, orderFile), this.GlyphImageFormat, this.AntiLinear);
    }

    public override void SaveState()
    {
      this.b.FilePaths = new StringList((IEnumerable<string>) this.PathHistory);
    }

    private void a(object A_0, EventArgs A_1)
    {
label_2:
      if (1 == 0)
        ;
      this.OrderInfos = this.e.OrderFiles;
      string currentOrderFile = this.b.OrderFile;
      NnsFileInfo nnsFileInfo = this.OrderInfos.Find((Predicate<NnsFileInfo>) (orderInfo => orderInfo.FileName == currentOrderFile));
      int num = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (nnsFileInfo == null)
            {
              num = 1;
              continue;
            }
            goto label_7;
          case 1:
            this.b.OrderFile = this.OrderInfos[0].FileName;
            num = 2;
            continue;
          case 2:
            goto label_7;
          default:
            goto label_2;
        }
      }
label_7:
      this.OnPropertyChanged("OrderFile");
      this.IsReady = true;
    }
  }
}
