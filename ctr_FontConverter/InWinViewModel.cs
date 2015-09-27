// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.InWinViewModel
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using NintendoWare.Font.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace NintendoWare.Font
{
  public class InWinViewModel : InSettingViewModel
  {
    private const int a = 16;
    private readonly InWinSettings b;
    private FontMap c;
    private ICollection<FontInfo> d;
    private BppViewModel[] e;
    private WidthTypeViewModel[] f;
    private IEnumerable<int> g;
    private ListCollectionView h;
    private bool i;
    private bool j;

    public string FontName
    {
      get
      {
        if (!this.i)
          return Strings.IDS_NOW_READING;
        return this.b.FontName;
      }
      set
      {
        int num = 0;
        while (true)
        {
          switch (num)
          {
            case 1:
              if (value == this.b.FontName)
              {
                num = 5;
                continue;
              }
              goto label_12;
            case 2:
              num = this.i ? 1 : 4;
              continue;
            case 3:
              goto label_7;
            case 4:
              goto label_11;
            case 5:
              goto label_8;
            default:
              if (value == null)
              {
                if (1 == 0)
                  ;
                num = 3;
                continue;
              }
              num = 2;
              continue;
          }
        }
label_8:
        return;
label_11:
        return;
label_7:
        return;
label_12:
        this.b.FontName = value;
        this.a();
      }
    }

    public string Bpp
    {
      get
      {
        return this.b.Bpp;
      }
      set
      {
        int num = 2;
        while (true)
        {
          switch (num)
          {
            case 0:
              goto label_7;
            case 1:
              if (value == this.b.Bpp)
              {
                num = 0;
                continue;
              }
              goto label_8;
            case 3:
              goto label_4;
            default:
              if (1 == 0)
                ;
              num = value != null ? 1 : 3;
              continue;
          }
        }
label_4:
        return;
label_7:
        return;
label_8:
        this.b.Bpp = value;
        this.OnPropertyChanged("Bpp");
      }
    }

    public int FontSize
    {
      get
      {
        int num = this.j ? 1 : 0;
        return this.b.FontSize;
      }
      set
      {
        int num = 3;
        while (true)
        {
          switch (num)
          {
            case 0:
              goto label_4;
            case 1:
              if (value == this.b.FontSize)
              {
                num = 2;
                continue;
              }
              goto label_9;
            case 2:
              goto label_7;
            default:
              num = !this.j ? 1 : 0;
              continue;
          }
        }
label_4:
        return;
label_7:
        if (1 != 0)
          ;
        return;
label_9:
        this.b.FontSize = value;
        this.OnPropertyChanged("FontSize");
      }
    }

    public WidthTypeViewModel[] WidthTypes
    {
      get
      {
        int num = 2;
        while (true)
        {
          switch (num)
          {
            case 0:
              goto label_5;
            case 1:
              this.f = new WidthTypeViewModel[4]
              {
                new WidthTypeViewModel(Strings.IDS_INWIN_WIDTHTYPE_GLYPH_ONLY, WidthType.GlyphOnly),
                new WidthTypeViewModel(Strings.IDS_INWIN_WIDTHTYPE_GLYPH_ONLY_KEEPSP, WidthType.GlyphOnlyKeepSpace),
                new WidthTypeViewModel(Strings.IDS_INWIN_WIDTHTYPE_INCLUDE_MARGIN, WidthType.IncludeMargin),
                new WidthTypeViewModel(Strings.IDS_INWIN_WIDTHTYPE_FIXED_WIDTH, WidthType.Fixed)
              };
              num = 0;
              continue;
            default:
              if (this.f == null)
              {
                num = 1;
                continue;
              }
              goto label_6;
          }
        }
label_5:
        if (1 == 0)
          ;
label_6:
        return this.f;
      }
    }

    public WidthType WidthType
    {
      get
      {
        return this.b.WidthType;
      }
      set
      {
        if (value == this.b.WidthType)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.b.WidthType = value;
          this.OnPropertyChanged("WidthType");
          this.OnPropertyChanged("IsEnabledFixedValue");
        }
      }
    }

    public bool IsEnabledFixedValue
    {
      get
      {
        return this.WidthType == WidthType.Fixed;
      }
    }

    public int FixedValue
    {
      get
      {
        return this.b.FixedValue;
      }
      set
      {
        if (value == this.b.FixedValue)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.b.FixedValue = value;
          this.OnPropertyChanged("FixedValue");
        }
      }
    }

    public int AverageWidth
    {
      get
      {
        int num = this.j ? 1 : 0;
        return this.b.AverageWidth;
      }
      set
      {
        int num = 2;
        while (true)
        {
          switch (num)
          {
            case 0:
              if (value == this.b.AverageWidth)
              {
                num = 1;
                continue;
              }
              goto label_8;
            case 1:
              goto label_7;
            case 3:
              goto label_4;
            default:
              if (1 == 0)
                ;
              num = !this.j ? 0 : 3;
              continue;
          }
        }
label_4:
        return;
label_7:
        return;
label_8:
        this.b.AverageWidth = value;
        this.OnPropertyChanged("AverageWidth");
      }
    }

    public bool EnableAverageWidth
    {
      get
      {
        return this.b.EnableAverageWidth;
      }
      set
      {
        if (value == this.b.EnableAverageWidth)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.b.EnableAverageWidth = value;
          this.OnPropertyChanged("EnableAverageWidth");
        }
      }
    }

    public bool EnableSoftAntialiasing
    {
      get
      {
        return this.b.EnableSoftAntialiasing;
      }
      set
      {
        if (value == this.b.EnableSoftAntialiasing)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.b.EnableSoftAntialiasing = value;
          this.OnPropertyChanged("EnableSoftAntialiasing");
        }
      }
    }

    public ICollection<FontInfo> Fonts
    {
      get
      {
label_2:
        int num = 3;
        BackgroundWorker backgroundWorker;
        while (true)
        {
          switch (num)
          {
            case 0:
              this.d = (ICollection<FontInfo>) new List<FontInfo>()
              {
                new FontInfo(Strings.IDS_NOW_READING, FontType.Vector)
              };
              backgroundWorker = new BackgroundWorker();
              backgroundWorker.DoWork += new DoWorkEventHandler(this.a);
              backgroundWorker.RunWorkerAsync();
              num = 1;
              continue;
            case 1:
              backgroundWorker.RunWorkerCompleted += (RunWorkerCompletedEventHandler) ((A_0, A_1) => this.a((FontMap) A_1.Result));
              if (1 == 0)
                ;
              num = 2;
              continue;
            case 2:
              goto label_8;
            case 3:
              if (this.d == null)
              {
                num = 0;
                continue;
              }
              goto label_8;
            default:
              goto label_2;
          }
        }
label_8:
        return this.d;
      }
      private set
      {
        this.d = value;
        this.OnPropertyChanged("Fonts");
        this.i = true;
      }
    }

    public IEnumerable<int> FontSizes
    {
      get
      {
        return this.g;
      }
      private set
      {
        if (1 == 0)
          ;
        if (value == this.g)
          return;
        this.g = value;
        this.OnPropertyChanged("FontSizes");
      }
    }

    public ICollectionView Bpps
    {
      get
      {
        int num = 1;
        while (true)
        {
          switch (num)
          {
            case 0:
              this.h = new ListCollectionView((IList) this.FormatTypeValue);
              num = 2;
              continue;
            case 2:
              goto label_6;
            default:
              if (1 == 0)
                ;
              if (this.h == null)
              {
                num = 0;
                continue;
              }
              goto label_6;
          }
        }
label_6:
        return (ICollectionView) this.h;
      }
    }

    private BppViewModel[] FormatTypeValue
    {
      get
      {
        if (this.e == null)
          this.e = InWinViewModel.d();
        return this.e;
      }
    }

    public InWinViewModel(InWinSettings settings)
    {
      this.DisplayName = "Windows Font";
      this.b = settings;
    }

    public override void SaveState()
    {
    }

    public override FontReader GetFontReader()
    {
      int num = 2;
      int avgwidth;
      BppViewModel bppViewModel;
      while (true)
      {
        switch (num)
        {
          case 0:
            avgwidth = this.AverageWidth;
            num = 3;
            continue;
          case 1:
            if (this.EnableAverageWidth)
            {
              num = 0;
              continue;
            }
            goto label_10;
          case 3:
            goto label_10;
          case 4:
            goto label_9;
          default:
            if (1 == 0)
              ;
            if (!this.IsReady)
            {
              num = 4;
              continue;
            }
            bppViewModel = (BppViewModel) this.Bpps.CurrentItem;
            avgwidth = 0;
            num = 1;
            continue;
        }
      }
label_9:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_NOW_READING);
label_10:
      return (FontReader) new WinFontReader(this.FontName, this.FontSize, avgwidth, bppViewModel.Bpp, bppViewModel.HasAlpha, this.WidthType, this.FixedValue, this.EnableSoftAntialiasing);
    }

    private static List<int> a(string A_0)
    {
      if (1 == 0)
        ;
      List<int> sizes = new List<int>();
      FONTENUMPROC lpProc = (FONTENUMPROC) ((elfex, ntmex, fontType, param) =>
      {
        sizes.Add(ntmex.ntmTm.tmHeight);
        return 1;
      });
      IntPtr dc = Gdi.CreateDC("DISPLAY", (string) null, (string) null, (object) null);
      Gdi.EnumFontFamiliesEx(dc, ref new LOGFONT()
      {
        lfCharSet = (byte) 1,
        lfPitchAndFamily = (byte) 0,
        lfFaceName = A_0
      }, lpProc, IntPtr.Zero, 0U);
      Gdi.DeleteDC(dc);
      return sizes;
    }

    private static BppViewModel[] d()
    {
      int num = 1;
      string str1;
      while (true)
      {
        string str2;
        switch (num)
        {
          case 0:
            goto label_4;
          case 2:
            num = 6;
            continue;
          case 3:
            if (ConverterEnvironment.IsRvl)
            {
              if (1 == 0)
                ;
              num = 7;
              continue;
            }
            num = 5;
            continue;
          case 4:
            str2 = "I";
            break;
          case 5:
            num = 0;
            continue;
          case 6:
            str2 = "A";
            break;
          case 7:
            goto label_7;
          default:
            num = ConverterEnvironment.IsRvl ? 4 : 2;
            continue;
        }
        str1 = str2;
        num = 3;
      }
label_4:
      string str3 = "LA";
      goto label_14;
label_7:
      str3 = "IA";
label_14:
      string str4 = str3;
      return new List<BppViewModel>()
      {
        new BppViewModel(1, false, string.Format(Strings.IDS_INWIN_FORMAT_I1, (object) str1), "A1"),
        new BppViewModel(4, false, string.Format(Strings.IDS_INWIN_FORMAT_I4, (object) str1), "A4"),
        new BppViewModel(6, false, string.Format(Strings.IDS_INWIN_FORMAT_I8, (object) str1), "A8"),
        new BppViewModel(1, true, string.Format(Strings.IDS_INWIN_FORMAT_I1, (object) str4), "LA1"),
        new BppViewModel(4, true, string.Format(Strings.IDS_INWIN_FORMAT_I4, (object) str4), "LA4"),
        new BppViewModel(6, true, string.Format(Strings.IDS_INWIN_FORMAT_I8, (object) str4), "LA8")
      }.ToArray();
    }

    private void a(object A_0, DoWorkEventArgs A_1)
    {
      A_1.Result = (object) GlCm.GetInstalledFontNames();
    }

    private void a(FontMap A_0)
    {
      if (1 == 0)
        ;
label_2:
      this.c = A_0;
      this.Fonts = (ICollection<FontInfo>) this.c.Values;
      int num = 2;
      while (true)
      {
        switch (num)
        {
          case 0:
            this.b.FontName = Enumerable.First<FontInfo>((IEnumerable<FontInfo>) this.Fonts).FaceName;
            num = 1;
            continue;
          case 1:
            goto label_6;
          case 2:
            if (!A_0.ContainsKey(this.b.FontName))
            {
              num = 0;
              continue;
            }
            goto label_6;
          default:
            goto label_2;
        }
      }
label_6:
      this.a();
      this.IsReady = true;
    }

    private void c()
    {
      if (1 == 0)
        ;
      this.j = true;
      this.FontSizes = Enumerable.Distinct<int>((IEnumerable<int>) Enumerable.OrderBy<int, int>((IEnumerable<int>) InWinViewModel.a(this.FontName), (Func<int, int>) (A_0 => A_0)));
      this.j = false;
    }

    private void b()
    {
label_2:
      bool flag = this.c[this.FontName].Type != FontType.Vector;
      int num = 3;
      while (true)
      {
        switch (num)
        {
          case 0:
            num = 4;
            continue;
          case 1:
            goto label_7;
          case 2:
            goto label_8;
          case 3:
            if (flag)
            {
              if (1 == 0)
                ;
              num = 0;
              continue;
            }
            this.Bpps.Filter = (Predicate<object>) null;
            num = 1;
            continue;
          case 4:
            if (this.Bpps.Filter == null)
            {
              num = 2;
              continue;
            }
            goto label_12;
          default:
            goto label_2;
        }
      }
label_7:
      return;
label_8:
      this.Bpps.Filter = new Predicate<object>(this.a);
      return;
label_12:;
    }

    private bool a(object A_0)
    {
      BppViewModel bppViewModel = A_0 as BppViewModel;
      if (bppViewModel != null)
        return bppViewModel.Is2Bit;
      return false;
    }

    private void a()
    {
      this.OnPropertyChanged("FontName");
      this.c();
      this.b();
    }
  }
}
