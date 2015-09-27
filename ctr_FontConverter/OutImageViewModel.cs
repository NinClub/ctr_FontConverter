// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.OutImageViewModel
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using NintendoWare.Font.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace NintendoWare.Font
{
  public class OutImageViewModel : OutSettingViewModel
  {
    private const string a = "Supported Images (*.bmp, *.tga)|*.bmp;*.tga|Bitmap Images (*.bmp)|*.bmp|Targa Images (*.tga)|*.tga|all files (*.*)|*.*";
    private readonly OutImageSettings b;
    private ImageFileFormatViewModel[] c;
    private List<NnsFileInfo> d;
    private OrderFileListProxy e;
    private bool f;
    private COLORREF[] g;

    public ImageFileFormatViewModel[] ImageFileFormatInfos
    {
      get
      {
        int num = 1;
        while (true)
        {
          switch (num)
          {
            case 0:
              goto label_6;
            case 2:
              this.c = new ImageFileFormatViewModel[3]
              {
                new ImageFileFormatViewModel(Strings.IDS_OUTIMAGE_FORMAT_EXT, ImageFileFormat.Ext, (string) null),
                new ImageFileFormatViewModel(Strings.IDS_OUTIMAGE_FORMAT_BMP, ImageFileFormat.Bmp, "bmp"),
                new ImageFileFormatViewModel(Strings.IDS_OUTIMAGE_FORMAT_TGA, ImageFileFormat.Tga, "tga")
              };
              num = 0;
              continue;
            default:
              if (1 == 0)
                ;
              if (this.c == null)
              {
                num = 2;
                continue;
              }
              goto label_6;
          }
        }
label_6:
        return this.c;
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
        int num = 4;
        while (true)
        {
          switch (num)
          {
            case 0:
              if (value == this.b.OrderFile)
              {
                num = 2;
                continue;
              }
              goto label_11;
            case 1:
              num = this.f ? 0 : 5;
              continue;
            case 2:
              goto label_8;
            case 3:
              goto label_3;
            case 5:
              goto label_10;
            default:
              num = value != null ? 1 : 3;
              continue;
          }
        }
label_10:
        return;
label_8:
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

    public bool IsSizeOffsetSpec
    {
      get
      {
        return this.b.IsSizeOffsetSpec;
      }
      set
      {
        if (value == this.b.IsSizeOffsetSpec)
          return;
        if (1 == 0)
          ;
        this.b.IsSizeOffsetSpec = value;
        this.OnPropertyChanged("IsSizeOffsetSpec");
        this.OnPropertyChanged("MarginSettingVisibility");
        this.OnPropertyChanged("SizeOffsetSettingVisibility");
      }
    }

    public Visibility MarginSettingVisibility
    {
      get
      {
        return this.IsSizeOffsetSpec ? Visibility.Hidden : Visibility.Visible;
      }
    }

    public Visibility SizeOffsetSettingVisibility
    {
      get
      {
        return !this.IsSizeOffsetSpec ? Visibility.Hidden : Visibility.Visible;
      }
    }

    public int CellSizeWidth
    {
      get
      {
        return this.b.CellSizeWidth;
      }
      set
      {
        if (value == this.b.CellSizeWidth)
          return;
        if (1 == 0)
          ;
        this.b.CellSizeWidth = value;
        this.OnPropertyChanged("CellSizeWidth");
      }
    }

    public int CellSizeHeight
    {
      get
      {
        return this.b.CellSizeHeight;
      }
      set
      {
        if (value == this.b.CellSizeHeight)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.b.CellSizeHeight = value;
          this.OnPropertyChanged("CellSizeHeight");
        }
      }
    }

    public int CellSizeLeft
    {
      get
      {
        return this.b.CellSizeLeft;
      }
      set
      {
        if (value == this.b.CellSizeLeft)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.b.CellSizeLeft = value;
          this.OnPropertyChanged("CellSizeLeft");
        }
      }
    }

    public int CellSizeTop
    {
      get
      {
        return this.b.CellSizeTop;
      }
      set
      {
        if (value == this.b.CellSizeTop)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.b.CellSizeTop = value;
          this.OnPropertyChanged("CellSizeTop");
        }
      }
    }

    public int CellMarginLeft
    {
      get
      {
        return this.b.CellMarginLeft;
      }
      set
      {
        if (value == this.b.CellMarginLeft)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.b.CellMarginLeft = value;
          this.OnPropertyChanged("CellMarginLeft");
        }
      }
    }

    public int CellMarginTop
    {
      get
      {
        return this.b.CellMarginTop;
      }
      set
      {
        if (value == this.b.CellMarginTop)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.b.CellMarginTop = value;
          this.OnPropertyChanged("CellMarginTop");
        }
      }
    }

    public int CellMarginRight
    {
      get
      {
        return this.b.CellMarginRight;
      }
      set
      {
        if (value == this.b.CellMarginRight)
          return;
        if (1 == 0)
          ;
        this.b.CellMarginRight = value;
        this.OnPropertyChanged("CellMarginRight");
      }
    }

    public int CellMarginBottom
    {
      get
      {
        return this.b.CellMarginBottom;
      }
      set
      {
        if (1 == 0)
          ;
        if (value == this.b.CellMarginBottom)
          return;
        this.b.CellMarginBottom = value;
        this.OnPropertyChanged("CellMarginBottom");
      }
    }

    public bool IsImageCenter
    {
      get
      {
        return this.b.IsImageCenter;
      }
      set
      {
        if (value == this.b.IsImageCenter)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.b.IsImageCenter = value;
          this.OnPropertyChanged("IsImageCenter");
        }
      }
    }

    public bool IsDrawGrid
    {
      get
      {
        return this.b.IsDrawGrid;
      }
      set
      {
        if (value == this.b.IsDrawGrid)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.b.IsDrawGrid = value;
          this.OnPropertyChanged("IsDrawGrid");
        }
      }
    }

    public ImageFileFormat OutImageFormat
    {
      get
      {
        return this.b.OutImageFormat;
      }
      set
      {
        if (value == this.b.OutImageFormat)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.b.OutImageFormat = value;
          this.OnPropertyChanged("OutImageFormat");
          this.OnPropertyChanged("FilterIndex");
        }
      }
    }

    public Color NullBlockColor
    {
      get
      {
        return this.b.NullBlockColor;
      }
      set
      {
        if (value == this.b.NullBlockColor)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.b.NullBlockColor = value;
          this.OnPropertyChanged("NullBlockColor");
        }
      }
    }

    public Color GridColor
    {
      get
      {
        return this.b.GridColor;
      }
      set
      {
        if (1 == 0)
          ;
        if (value == this.b.GridColor)
          return;
        this.b.GridColor = value;
        this.OnPropertyChanged("GridColor");
      }
    }

    public Color WidthBarColor
    {
      get
      {
        return this.b.WidthBarColor;
      }
      set
      {
        if (value == this.b.WidthBarColor)
          return;
        if (1 == 0)
          ;
        this.b.WidthBarColor = value;
        this.OnPropertyChanged("WidthBarColor");
      }
    }

    public Color MarginColor
    {
      get
      {
        return this.b.MarginColor;
      }
      set
      {
        if (value == this.b.MarginColor)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.b.MarginColor = value;
          this.OnPropertyChanged("MarginColor");
        }
      }
    }

    public Color BackgroundColor
    {
      get
      {
        return this.b.BackgroundColor;
      }
      set
      {
        if (value == this.b.BackgroundColor)
          return;
        if (1 == 0)
          ;
        this.b.BackgroundColor = value;
        this.OnPropertyChanged("BackgroundColor");
      }
    }

    public List<NnsFileInfo> OrderInfos
    {
      get
      {
        int num = 0;
        while (true)
        {
          switch (num)
          {
            case 0:
              if (1 == 0)
                break;
              break;
            case 1:
              goto label_6;
            case 2:
              this.e.Loaded += new EventHandler(this.a);
              this.d = this.e.OrderFiles;
              this.f = this.e.IsLoaded;
              this.IsReady = this.f;
              num = 1;
              continue;
          }
          if (this.d == null)
            num = 2;
          else
            break;
        }
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

    public COLORREF[] CustomColors
    {
      get
      {
        if (this.g == null)
          this.g = new COLORREF[16];
        return this.g;
      }
    }

    public string FileFilter
    {
      get
      {
        return "Supported Images (*.bmp, *.tga)|*.bmp;*.tga|Bitmap Images (*.bmp)|*.bmp|Targa Images (*.tga)|*.tga|all files (*.*)|*.*";
      }
    }

    public int FilterIndex
    {
      get
      {
        return (int) this.OutImageFormat;
      }
    }

    public OutImageViewModel(OutImageSettings settings, OrderFileListProxy orderFileListProxy)
    {
      this.DisplayName = "Image";
      this.b = settings;
      this.e = orderFileListProxy;
      this.SetPathHistory(this.b.FilePaths);
    }

    public override FontWriter GetFontWriter()
    {
      int num = 0;
      int cellWidth;
      int cellHeight;
      ImageFileFormat outImageFormat;
      string str1;
      int marginLeft;
      int marginTop;
      string str2;
      bool isDrawGrid;
      int marginRight;
      int marginBottom;
      while (true)
      {
        int index;
        ImageFileFormat imageFileFormat;
        string a;
        string extension;
        switch (num)
        {
          case 1:
            marginLeft = this.b.CellSizeLeft;
            marginTop = this.b.CellSizeTop;
            num = 19;
            continue;
          case 2:
            num = 22;
            continue;
          case 3:
            imageFileFormat = ImageFileFormat.Ext;
            index = 0;
            num = 20;
            continue;
          case 4:
            str1 = str1 + "." + this.ImageFileFormatInfos[(int) outImageFormat].FileExtension;
            this.CurrentPath = str1;
            num = 7;
            continue;
          case 5:
            if (imageFileFormat != outImageFormat)
            {
              num = 2;
              continue;
            }
            goto label_44;
          case 6:
            imageFileFormat = this.ImageFileFormatInfos[index].Format;
            num = 17;
            continue;
          case 7:
            goto label_44;
          case 8:
            if (this.ImageFileFormatInfos[index].FileExtension != null)
            {
              num = 16;
              continue;
            }
            break;
          case 9:
            if (outImageFormat != ImageFileFormat.Ext)
            {
              num = 3;
              continue;
            }
            goto label_44;
          case 10:
            if (this.b.IsImageCenter)
            {
              num = 24;
              continue;
            }
            marginRight = this.b.CellMarginRight;
            marginBottom = this.b.CellMarginBottom;
            num = 12;
            continue;
          case 11:
            goto label_12;
          case 12:
          case 13:
          case 19:
          case 30:
            num = 9;
            continue;
          case 14:
            goto label_26;
          case 15:
            if (!this.b.IsSizeOffsetSpec)
            {
              marginLeft = this.b.CellMarginLeft;
              marginTop = this.b.CellMarginTop;
              num = 10;
              continue;
            }
            if (1 == 0)
              ;
            num = 26;
            continue;
          case 16:
            a = "." + this.ImageFileFormatInfos[index].FileExtension;
            extension = Path.GetExtension(str1);
            num = 21;
            continue;
          case 17:
          case 29:
            num = 5;
            continue;
          case 18:
            str1 = Path.Combine(Path.GetDirectoryName(str1), Path.GetFileNameWithoutExtension(str1));
            num = 4;
            continue;
          case 20:
          case 28:
            num = 27;
            continue;
          case 21:
            if (string.Equals(a, extension, StringComparison.OrdinalIgnoreCase))
            {
              num = 6;
              continue;
            }
            break;
          case 22:
            if (imageFileFormat != ImageFileFormat.Ext)
            {
              num = 18;
              continue;
            }
            goto case 4;
          case 23:
            if (str2 != null)
            {
              str2 = Path.Combine(this.e.OrderFilesDir, str2);
              isDrawGrid = this.b.IsDrawGrid;
              outImageFormat = this.b.OutImageFormat;
              num = 15;
              continue;
            }
            num = 11;
            continue;
          case 24:
            marginRight = marginLeft;
            marginBottom = marginTop;
            num = 13;
            continue;
          case 25:
            if (!this.b.IsImageCenter)
            {
              num = 1;
              continue;
            }
            marginLeft = -1;
            marginTop = -1;
            num = 30;
            continue;
          case 26:
            cellWidth = this.b.CellSizeWidth;
            cellHeight = this.b.CellSizeHeight;
            num = 25;
            continue;
          case 27:
            num = index < this.ImageFileFormatInfos.Length ? 8 : 29;
            continue;
          default:
            if (!this.IsReady)
            {
              num = 14;
              continue;
            }
            cellWidth = -1;
            cellHeight = -1;
            marginLeft = 0;
            marginTop = 0;
            marginRight = 0;
            marginBottom = 0;
            str1 = this.CurrentPath;
            str2 = this.b.OrderFile;
            num = 23;
            continue;
        }
        ++index;
        num = 28;
      }
label_12:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_ORDER_NOT_SELECTED);
label_26:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_NOW_READING);
label_44:
      FileOverwriteConfirmDialog.Show(str1);
      return (FontWriter) new ImageFontWriter(str1, str2, outImageFormat, isDrawGrid, cellWidth, cellHeight, marginLeft, marginTop, marginRight, marginBottom, (uint) GlCm.ColorToUint(this.b.GridColor), (uint) GlCm.ColorToUint(this.b.MarginColor), (uint) GlCm.ColorToUint(this.b.WidthBarColor), (uint) GlCm.ColorToUint(this.b.NullBlockColor), (uint) GlCm.ColorToUint(this.b.BackgroundColor));
    }

    public override void SaveState()
    {
      this.b.FilePaths = new StringList((IEnumerable<string>) this.PathHistory);
    }

    private void a(object A_0, EventArgs A_1)
    {
label_2:
      this.OrderInfos = this.e.OrderFiles;
      string currentOrderFile = this.b.OrderFile;
      NnsFileInfo nnsFileInfo = this.OrderInfos.Find((Predicate<NnsFileInfo>) (orderInfo => orderInfo.FileName == currentOrderFile));
      int num = 1;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_7;
          case 1:
            if (nnsFileInfo == null)
            {
              num = 2;
              continue;
            }
            goto label_7;
          case 2:
            this.b.OrderFile = this.d[0].FileName;
            if (1 == 0)
              ;
            num = 0;
            continue;
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
