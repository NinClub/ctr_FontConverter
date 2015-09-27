// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.OutNitroViewModel
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace NintendoWare.Font
{
  public class OutNitroViewModel : OutSettingViewModel
  {
    private const string a = "font resource (*.bcfnt, *.bcfna)|*.bcfnt;*.bcfna|normal brfnt (*.bcfnt)|*.bcfnt|archived brfnt (*.bcfna)|*.bcfna|all files (*.*)|*.*";
    private const string b = ".bcfnt";
    private const string c = ".bcfna";
    private readonly OutRuntimeBinarySettings d;
    private CharEncodingViewModel[] e;
    private SheetPixelsViewModel[] f;
    private List<GlyphGroupFileViewModel> g;
    private string h;
    private bool i;

    public string CharEncodingDisplayName
    {
      get
      {
        if (!ConverterEnvironment.IsCtr)
          return Strings.DisplayNameCharacterEncodingOld;
        return Strings.DisplayNameCharacterEncoding;
      }
    }

    public CharEncoding Encoding
    {
      get
      {
        return this.d.Encoding;
      }
      set
      {
        if (value == this.d.Encoding)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.d.Encoding = value;
          this.OnPropertyChanged("Encoding");
        }
      }
    }

    public string Group
    {
      get
      {
        if (!this.i)
          return (string) null;
        return this.d.GlyphGroupFile;
      }
      set
      {
        int num = 1;
        while (true)
        {
          switch (num)
          {
            case 0:
              goto label_8;
            case 2:
              goto label_3;
            case 3:
              goto label_10;
            case 4:
              num = this.i ? 5 : 3;
              continue;
            case 5:
              if (value == this.d.GlyphGroupFile)
              {
                num = 0;
                continue;
              }
              goto label_11;
            default:
              num = value != null ? 4 : 2;
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
        this.d.GlyphGroupFile = value;
        this.OnPropertyChanged("Group");
      }
    }

    public int SheetPixels
    {
      get
      {
        return this.d.SheetPixels;
      }
      set
      {
        if (value == this.d.SheetPixels)
          return;
        if (1 == 0)
          ;
        this.d.SheetPixels = value;
        this.OnPropertyChanged("SheetPixels");
      }
    }

    public bool UseDefaultAlternateChar
    {
      get
      {
        return this.d.UseDefaultAlternateChar;
      }
      set
      {
        if (value == this.d.UseDefaultAlternateChar)
          return;
        if (1 == 0)
          ;
        this.d.UseDefaultAlternateChar = value;
        this.OnPropertyChanged("UseDefaultAlternateChar");
      }
    }

    public string AlternateChar
    {
      get
      {
        return this.d.AlternateChar;
      }
      set
      {
        if (value == this.d.AlternateChar)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.d.AlternateChar = value;
          this.OnPropertyChanged("AlternateChar");
        }
      }
    }

    public bool UseDefaultLineHeight
    {
      get
      {
        return this.d.UseDefaultLineHeight;
      }
      set
      {
        if (value == this.d.UseDefaultLineHeight)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.d.UseDefaultLineHeight = value;
          this.OnPropertyChanged("UseDefaultLineHeight");
        }
      }
    }

    public int LineHeight
    {
      get
      {
        return this.d.LineHeight;
      }
      set
      {
        if (value == this.d.LineHeight)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.d.LineHeight = value;
          this.OnPropertyChanged("LineHeight");
        }
      }
    }

    public bool UseDefaultLeft
    {
      get
      {
        return this.d.UseDefaultLeft;
      }
      set
      {
        if (value == this.d.UseDefaultLeft)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.d.UseDefaultLeft = value;
          this.OnPropertyChanged("UseDefaultLeft");
        }
      }
    }

    public int DefaultLeft
    {
      get
      {
        return this.d.DefaultLeft;
      }
      set
      {
        if (value == this.d.DefaultLeft)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.d.DefaultLeft = value;
          this.OnPropertyChanged("DefaultLeft");
        }
      }
    }

    public bool UseDefaultWidth
    {
      get
      {
        return this.d.UseDefaultWidth;
      }
      set
      {
        if (value == this.d.UseDefaultWidth)
          return;
        if (1 == 0)
          ;
        this.d.UseDefaultWidth = value;
        this.OnPropertyChanged("UseDefaultWidth");
      }
    }

    public int DefaultWidth
    {
      get
      {
        return this.d.DefaultWidth;
      }
      set
      {
        if (1 == 0)
          ;
        if (value == this.d.DefaultWidth)
          return;
        this.d.DefaultWidth = value;
        this.OnPropertyChanged("DefaultWidth");
      }
    }

    public bool UseDefaultRight
    {
      get
      {
        return this.d.UseDefaultRight;
      }
      set
      {
        if (value == this.d.UseDefaultRight)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.d.UseDefaultRight = value;
          this.OnPropertyChanged("UseDefaultRight");
        }
      }
    }

    public int DefaultRight
    {
      get
      {
        return this.d.DefaultRight;
      }
      set
      {
        if (value == this.d.DefaultRight)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.d.DefaultRight = value;
          this.OnPropertyChanged("DefaultRight");
        }
      }
    }

    public CharEncodingViewModel[] FontEncodingInfos
    {
      get
      {
        int num = 1;
        List<CharEncodingViewModel> list;
        while (true)
        {
          switch (num)
          {
            case 0:
              list = new List<CharEncodingViewModel>();
              num = 6;
              continue;
            case 2:
              goto label_11;
            case 3:
              list.Add(new CharEncodingViewModel(string.Format(Strings.UIStringDefault, (object) "Unicode"), CharEncoding.UTF16));
              num = 5;
              continue;
            case 4:
            case 5:
              list.Add(new CharEncodingViewModel("Shift_JIS", CharEncoding.SJIS));
              list.Add(new CharEncodingViewModel("CodePage 1252 (ISO 8859-1)", CharEncoding.CP1252));
              this.e = list.ToArray();
              num = 2;
              continue;
            case 6:
              if (!ConverterEnvironment.IsCtr)
              {
                if (1 == 0)
                  ;
                list.Add(new CharEncodingViewModel("UTF-8", CharEncoding.UTF8));
                list.Add(new CharEncodingViewModel(string.Format(Strings.UIStringDefault, (object) "UTF-16"), CharEncoding.UTF16));
                num = 4;
                continue;
              }
              num = 3;
              continue;
            default:
              if (this.e == null)
              {
                num = 0;
                continue;
              }
              goto label_11;
          }
        }
label_11:
        return this.e;
      }
    }

    public SheetPixelsViewModel[] SheetPixelsInfos
    {
      get
      {
        int num = 0;
        while (true)
        {
          switch (num)
          {
            case 1:
              this.f = new SheetPixelsViewModel[8]
              {
                new SheetPixelsViewModel(string.Format(Strings.UIStringDefault, (object) Strings.IDS_OUTNITRO_SHEETPIXELS_AUTO), 0),
                new SheetPixelsViewModel(Strings.IDS_OUTNITRO_SHEETPIXELS_16KP, 16384),
                new SheetPixelsViewModel(Strings.IDS_OUTNITRO_SHEETPIXELS_32KP, 32768),
                new SheetPixelsViewModel(Strings.IDS_OUTNITRO_SHEETPIXELS_64KP, 65536),
                new SheetPixelsViewModel(Strings.IDS_OUTNITRO_SHEETPIXELS_128KP, 131072),
                new SheetPixelsViewModel(Strings.IDS_OUTNITRO_SHEETPIXELS_256KP, 262144),
                new SheetPixelsViewModel(Strings.IDS_OUTNITRO_SHEETPIXELS_512KP, 524288),
                new SheetPixelsViewModel(Strings.IDS_OUTNITRO_SHEETPIXELS_1024KP, 1048576)
              };
              num = 2;
              continue;
            case 2:
              goto label_6;
            default:
              if (this.f == null)
              {
                if (1 == 0)
                  ;
                num = 1;
                continue;
              }
              goto label_6;
          }
        }
label_6:
        return this.f;
      }
    }

    public List<GlyphGroupFileViewModel> GroupInfos
    {
      get
      {
        return this.g;
      }
      set
      {
        this.g = value;
        this.OnPropertyChanged("GroupInfos");
        this.i = true;
      }
    }

    public string FileFilter
    {
      get
      {
        return "font resource (*.bcfnt, *.bcfna)|*.bcfnt;*.bcfna|normal brfnt (*.bcfnt)|*.bcfnt|archived brfnt (*.bcfna)|*.bcfna|all files (*.*)|*.*";
      }
    }

    public string FileExtension
    {
      get
      {
        return "bcfnt";
      }
    }

    public OutNitroViewModel(OutRuntimeBinarySettings settings)
    {
      if (settings == null)
        throw new ArgumentNullException("settings");
      this.d = settings;
      this.DisplayName = "bcfnt / bcfna";
      this.SetPathHistory(this.d.FilePaths);
      this.g = new List<GlyphGroupFileViewModel>()
      {
        new GlyphGroupFileViewModel(Strings.IDS_NOW_READING, (string) null)
      };
      BackgroundWorker backgroundWorker = new BackgroundWorker();
      backgroundWorker.DoWork += new DoWorkEventHandler(this.a);
      backgroundWorker.RunWorkerAsync();
      backgroundWorker.RunWorkerCompleted += (RunWorkerCompletedEventHandler) ((A_0, A_1) => this.a((NnsXmlFileList) A_1.Result));
    }

    public override void SaveState()
    {
      this.d.FilePaths = new StringList((IEnumerable<string>) this.PathHistory);
    }

    public override FontWriter GetFontWriter()
    {
      int num = 14;
      string str1;
      string str2;
      int sheetPixels;
      ushort alter;
      int linefeed;
      int width;
      int left;
      int right;
      while (true)
      {
        if (1 == 0)
          ;
        string str3;
        string str4;
        string str5;
        switch (num)
        {
          case 0:
            goto label_10;
          case 1:
            str5 = ".bcfna";
            break;
          case 2:
            goto label_26;
          case 3:
            goto label_27;
          case 4:
            num = str2 != null ? 15 : 0;
            continue;
          case 5:
            if (!string.Equals(str3, ".bcfnt", StringComparison.OrdinalIgnoreCase))
            {
              num = 13;
              continue;
            }
            goto case 7;
          case 6:
            str5 = ".bcfnt";
            break;
          case 7:
            str3 = string.Empty;
            num = 10;
            continue;
          case 8:
            goto label_28;
          case 9:
            num = string.Equals(str2, "", StringComparison.OrdinalIgnoreCase) ? 6 : 11;
            continue;
          case 10:
            str3 += str4;
            str1 = Path.ChangeExtension(str1, str3);
            this.CurrentPath = str1;
            FileOverwriteConfirmDialog.Show(str1);
            num = 16;
            continue;
          case 11:
            num = 1;
            continue;
          case 12:
            if (string.Equals(str3, ".bcfna", StringComparison.OrdinalIgnoreCase))
            {
              num = 7;
              continue;
            }
            goto case 10;
          case 13:
            num = 12;
            continue;
          case 15:
            if (sheetPixels >= 0)
            {
              str1 = this.CurrentPath;
              alter = this.a(ushort.MaxValue);
              linefeed = this.d((int) ushort.MaxValue);
              width = this.c((int) ushort.MaxValue);
              left = this.b((int) ushort.MaxValue);
              right = this.a((int) ushort.MaxValue);
              num = 9;
              continue;
            }
            num = 3;
            continue;
          case 16:
            if (!string.Equals(str2, "", StringComparison.OrdinalIgnoreCase))
            {
              num = 17;
              continue;
            }
            goto label_28;
          case 17:
            str2 = Path.Combine(this.h, str2);
            num = 8;
            continue;
          default:
            if (!this.IsReady)
            {
              num = 2;
              continue;
            }
            sheetPixels = this.d.SheetPixels;
            str2 = this.d.GlyphGroupFile;
            num = 4;
            continue;
        }
        str4 = str5;
        str3 = Path.GetExtension(str1);
        num = 5;
      }
label_10:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_GROUP_NOT_SELECTED);
label_26:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_NOW_READING);
label_27:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_INVALID_SHEETPIXELS, (object) sheetPixels);
label_28:
      return (FontWriter) new NitroFontWriter(str1, str2, GlyphDataType.Texture, alter, linefeed, width, left, right, this.d.Encoding, sheetPixels);
    }

    private void a(object A_0, DoWorkEventArgs A_1)
    {
      NnsXmlFileList nnsXmlFileList = new NnsXmlFileList("xggp", ".xggp");
      nnsXmlFileList.CollectFiles();
      A_1.Result = (object) nnsXmlFileList;
    }

    private void a(NnsXmlFileList A_0)
    {
label_2:
      this.h = A_0.GetFileDir();
      List<GlyphGroupFileViewModel> list = new List<GlyphGroupFileViewModel>(1 + A_0.GetNum());
      list.Add(new GlyphGroupFileViewModel(string.Format(Strings.UIStringDefault, (object) Strings.IDS_DEFAULT_GROUPS), ""));
      int index = 0;
      int num = 0;
      GlyphGroupFileViewModel groupFileViewModel;
      while (true)
      {
        switch (num)
        {
          case 0:
          case 2:
            num = 5;
            continue;
          case 1:
            goto label_12;
          case 3:
            if (groupFileViewModel == null)
            {
              num = 6;
              continue;
            }
            goto label_12;
          case 4:
            this.GroupInfos = list;
            string currentGroup = this.d.GlyphGroupFile;
            groupFileViewModel = this.GroupInfos.Find((Predicate<GlyphGroupFileViewModel>) (groupInfo => groupInfo.FileName == currentGroup));
            num = 3;
            continue;
          case 5:
            if (index >= A_0.GetNum())
            {
              num = 4;
              continue;
            }
            NnsFileInfo nnsFileInfo = A_0[index];
            string title = nnsFileInfo.Title;
            list.Add(new GlyphGroupFileViewModel(title, nnsFileInfo.FileName));
            ++index;
            num = 2;
            continue;
          case 6:
            if (1 == 0)
              ;
            this.d.GlyphGroupFile = this.GroupInfos[0].FileName;
            num = 1;
            continue;
          default:
            goto label_2;
        }
      }
label_12:
      this.OnPropertyChanged("Group");
      this.IsReady = true;
    }

    private ushort a()
    {
label_2:
      string alternateChar = this.d.AlternateChar;
      int num1 = 1;
      ushort c;
      ushort num2;
      while (true)
      {
        switch (num1)
        {
          case 0:
            num2 = (ushort) alternateChar[0];
            num1 = 2;
            continue;
          case 1:
            if (alternateChar.Length == 1)
            {
              if (1 == 0)
                ;
              num1 = 0;
              continue;
            }
            c = (ushort) GlCm.ParseHexNumber(alternateChar);
            num2 = GlCm.EncodingToUnicode(this.d.Encoding, c);
            num1 = 4;
            continue;
          case 2:
            goto label_11;
          case 3:
            goto label_6;
          case 4:
            if ((int) num2 == (int) ushort.MaxValue)
            {
              num1 = 3;
              continue;
            }
            goto label_11;
          default:
            goto label_2;
        }
      }
label_6:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_ALTER_TO_UNICODE, (object) c);
label_11:
      return num2;
    }

    private ushort a(ushort A_0)
    {
      if (!this.d.UseDefaultAlternateChar)
        return this.a();
      return A_0;
    }

    private int d(int A_0)
    {
      if (!this.d.UseDefaultLineHeight)
        return this.d.LineHeight;
      return A_0;
    }

    private int c(int A_0)
    {
      if (!this.d.UseDefaultWidth)
        return this.d.DefaultWidth;
      return A_0;
    }

    private int b(int A_0)
    {
      if (!this.d.UseDefaultLeft)
        return this.d.DefaultLeft;
      return A_0;
    }

    private int a(int A_0)
    {
      if (!this.d.UseDefaultRight)
        return this.d.DefaultRight;
      return A_0;
    }
  }
}
