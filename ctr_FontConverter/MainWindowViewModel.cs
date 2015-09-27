// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.MainWindowViewModel
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace NintendoWare.Font
{
  public class MainWindowViewModel : WorkspaceViewModel, IProgressControl
  {
    private readonly OrderFileListProxy d = new OrderFileListProxy();
    private bool l = true;
    private const string a = "Filter List (*.xllt)|*.xllt|all files (*.*)|*.*";
    private const string b = "xllt";
    private const int c = 200;
    private ProgressBarViewModel e;
    private ReadOnlyCollection<InSettingViewModel> f;
    private ReadOnlyCollection<OutSettingViewModel> g;
    private ConvertSettings h;
    private RelayCommand i;
    private RelayCommand j;
    private bool k;
    private int m;
    private int n;
    private string o;

    public ReadOnlyCollection<InSettingViewModel> InSettings
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
              this.f = new ReadOnlyCollection<InSettingViewModel>((IList<InSettingViewModel>) this.b());
              num = 0;
              continue;
            default:
              if (1 == 0)
                ;
              if (this.f == null)
              {
                num = 2;
                continue;
              }
              goto label_6;
          }
        }
label_6:
        return this.f;
      }
    }

    public ReadOnlyCollection<OutSettingViewModel> OutSettings
    {
      get
      {
        int num = 2;
        while (true)
        {
          switch (num)
          {
            case 0:
              this.g = new ReadOnlyCollection<OutSettingViewModel>((IList<OutSettingViewModel>) this.a());
              num = 1;
              continue;
            case 1:
              goto label_6;
            default:
              if (1 == 0)
                ;
              if (this.g == null)
              {
                num = 0;
                continue;
              }
              goto label_6;
          }
        }
label_6:
        return this.g;
      }
    }

    public int InputMode
    {
      get
      {
        return this.h.InputMode;
      }
      set
      {
        if (value == this.h.InputMode)
          return;
        if (1 == 0)
          ;
        this.h.InputMode = value;
        this.OnPropertyChanged("InputMode");
      }
    }

    public int OutputMode
    {
      get
      {
        return this.h.OutputMode;
      }
      set
      {
        if (value == this.h.OutputMode)
          return;
        if (1 == 0)
          ;
        this.h.OutputMode = value;
        this.OnPropertyChanged("OutputMode");
      }
    }

    public bool UseFilter
    {
      get
      {
        return this.h.UseFilter;
      }
      set
      {
        if (value == this.h.UseFilter)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.h.UseFilter = value;
          this.OnPropertyChanged("UseFilter");
        }
      }
    }

    public ProgressBarViewModel ProgressViewModel
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
              this.e = new ProgressBarViewModel()
              {
                Value = 0,
                Minimum = 0,
                Maximum = 100
              };
              num = 0;
              continue;
            default:
              if (1 == 0)
                ;
              if (this.e == null)
              {
                num = 2;
                continue;
              }
              goto label_6;
          }
        }
label_6:
        return this.e;
      }
    }

    public ICommand ConvertCommand
    {
      get
      {
label_2:
        int num = 9;
        while (true)
        {
          switch (num)
          {
            case 0:
              this.i = new RelayCommand((Action<object>) (A_0 => this.f()), (Predicate<object>) (A_0 => this.CanConvert));
              this.i.Text = Strings.IDS_EXEC_BUTTON_DEFAULT;
              num = 1;
              continue;
            case 1:
              goto label_10;
            case 2:
              this.j = new RelayCommand((Action<object>) (A_0 => this.e()), (Predicate<object>) (A_0 => this.CanCancel));
              this.j.Text = Strings.IDS_EXEC_BUTTON_CONVERTING;
              num = 3;
              continue;
            case 3:
              goto label_15;
            case 4:
              if (this.i == null)
              {
                num = 5;
                continue;
              }
              goto label_10;
            case 5:
              if (1 == 0)
                ;
              num = 0;
              continue;
            case 6:
              num = 2;
              continue;
            case 7:
              if (this.j == null)
              {
                num = 6;
                continue;
              }
              goto label_15;
            case 8:
              num = 4;
              continue;
            case 9:
              num = !this.IsConvertReady ? 7 : 8;
              continue;
            default:
              goto label_2;
          }
        }
label_10:
        return (ICommand) this.i;
label_15:
        return (ICommand) this.j;
      }
    }

    public bool IsConvertReady
    {
      get
      {
        return this.l;
      }
      set
      {
        if (value == this.l)
        {
          if (1 != 0)
            ;
        }
        else
        {
          this.l = value;
          this.OnPropertyChanged("IsConvertReady");
          this.OnPropertyChanged("ConvertCommand");
        }
      }
    }

    public string StateString
    {
      get
      {
        return this.o;
      }
      set
      {
        this.o = value;
        this.OnPropertyChanged("StateString");
        MainWindowViewModel.g();
      }
    }

    public string FileFilter
    {
      get
      {
        return "Filter List (*.xllt)|*.xllt|all files (*.*)|*.*";
      }
    }

    public string FileExtension
    {
      get
      {
        return "xllt";
      }
    }

    private bool CanConvert
    {
      get
      {
        return this.IsConvertReady;
      }
    }

    private bool CanCancel
    {
      get
      {
        return !this.IsConvertReady;
      }
    }

    public MainWindowViewModel(ConvertSettings settings)
    {
      this.DisplayName = GlCm.GetProductInfo() + " Version " + GlCm.GetVersionString();
      this.h = settings;
      this.SetPathHistory(this.h.FilePaths);
      ProgressControl.SetInstance((IProgressControl) this);
    }

    public void StateSave()
    {
      this.h.FilePaths = new StringList((IEnumerable<string>) this.PathHistory);
      IEnumerator<InSettingViewModel> enumerator1 = this.f.GetEnumerator();
      try
      {
        int num = 4;
        while (true)
        {
          switch (num)
          {
            case 0:
              if (!enumerator1.MoveNext())
              {
                num = 3;
                continue;
              }
              enumerator1.Current.SaveState();
              num = 2;
              continue;
            case 1:
              goto label_15;
            case 3:
              num = 1;
              continue;
            default:
              num = 0;
              continue;
          }
        }
      }
      finally
      {
        int num = 2;
        while (true)
        {
          switch (num)
          {
            case 0:
              goto label_29;
            case 1:
              enumerator1.Dispose();
              num = 0;
              continue;
            default:
              if (enumerator1 != null)
              {
                num = 1;
                continue;
              }
              goto label_29;
          }
        }
label_29:;
      }
label_15:
      IEnumerator<OutSettingViewModel> enumerator2 = this.g.GetEnumerator();
      try
      {
        int num = 0;
        while (true)
        {
          switch (num)
          {
            case 1:
              num = 4;
              continue;
            case 2:
              if (!enumerator2.MoveNext())
              {
                num = 1;
                continue;
              }
              enumerator2.Current.SaveState();
              num = 3;
              continue;
            case 3:
              if (1 == 0)
                break;
              break;
            case 4:
              goto label_28;
          }
          num = 2;
        }
label_28:;
      }
      finally
      {
        int num = 0;
        while (true)
        {
          switch (num)
          {
            case 1:
              goto label_14;
            case 2:
              enumerator2.Dispose();
              num = 1;
              continue;
            default:
              if (enumerator2 != null)
              {
                num = 2;
                continue;
              }
              goto label_14;
          }
        }
label_14:;
      }
    }

    public override void SavePathToHistory()
    {
      if (1 == 0)
        ;
      int num = 0;
      while (true)
      {
        switch (num)
        {
          case 1:
            base.SavePathToHistory();
            num = 2;
            continue;
          case 2:
            goto label_6;
          default:
            if (this.UseFilter)
            {
              num = 1;
              continue;
            }
            goto label_6;
        }
      }
label_6:
      this.f[this.h.InputMode].SavePathToHistory();
      this.g[this.h.OutputMode].SavePathToHistory();
    }

    public FontReader GetFontReader()
    {
      return this.f[this.h.InputMode].GetFontReader();
    }

    public FontWriter GetFontWriter()
    {
      return this.g[this.h.OutputMode].GetFontWriter();
    }

    public void LoadFilter(CharFilter filter)
    {
      string currentPath = this.CurrentPath;
      if (currentPath.Length == 0)
      {
        if (1 == 0)
          ;
        throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_USE_FILTER_BUT_NO_FILTER);
      }
      filter.Load(currentPath);
    }

    public bool IsCanceled()
    {
      MainWindowViewModel.g();
      return this.k;
    }

    public void SetStatusString(string msgId)
    {
      this.StateString = msgId;
    }

    public void ResetProgressBarPos()
    {
      if (1 == 0)
        ;
      this.ProgressViewModel.Value = 0;
      MainWindowViewModel.g();
      this.m = 0;
      this.n = 1;
    }

    public void SetProgressBarMax(int max)
    {
label_2:
      this.n = 1;
      this.ProgressViewModel.Minimum = 0;
      this.ProgressViewModel.Maximum = max;
      if (1 == 0)
        ;
      int num = 1;
      while (true)
      {
        switch (num)
        {
          case 0:
          case 1:
            num = 2;
            continue;
          case 2:
            if (max <= 200)
            {
              num = 3;
              continue;
            }
            max /= 2;
            this.n *= 2;
            num = 0;
            continue;
          case 3:
            goto label_8;
          default:
            goto label_2;
        }
      }
label_8:
      MainWindowViewModel.g();
    }

    public void StepProgressBar(int step)
    {
label_2:
      int num1 = this.m;
      this.m += step;
      int num2 = 2;
      while (true)
      {
        switch (num2)
        {
          case 0:
            goto label_7;
          case 1:
            goto label_8;
          case 2:
            if (this.m / this.n != num1 / this.n)
            {
              num2 = 4;
              continue;
            }
            goto label_12;
          case 3:
            if (!this.IsCanceled())
            {
              if (1 == 0)
                ;
              MainWindowViewModel.g();
              num2 = 0;
              continue;
            }
            num2 = 1;
            continue;
          case 4:
            this.ProgressViewModel.Value = this.m;
            num2 = 3;
            continue;
          default:
            goto label_2;
        }
      }
label_7:
      return;
label_12:
      return;
label_8:
      throw new ConvertCancelException();
    }

    private static void g()
    {
      DispatcherHelper.DoEvents();
    }

    private void f()
    {
      if (1 == 0)
        ;
      FontData fontData = new FontData();
      CharFilter filter = new CharFilter();
      GlyphOrder order = new GlyphOrder();
      this.k = false;
      this.IsConvertReady = false;
      try
      {
label_4:
        this.SetStatusString(Strings.IDS_STATUS_PREPAIR);
        this.d();
        FontReader fontReader = this.GetFontReader();
        FontWriter fontWriter = this.GetFontWriter();
        fontReader.ValidateInput();
        fontWriter.ValidateInput();
        this.SetStatusString(Strings.IDS_STATUS_LOAD_ORDER);
        fontWriter.GetGlyphOrder(order);
        int num = 0;
        while (true)
        {
          switch (num)
          {
            case 0:
              if (this.UseFilter)
              {
                num = 1;
                continue;
              }
              goto case 3;
            case 1:
              this.SetStatusString(Strings.IDS_STATUS_LOAD_FILTER);
              this.LoadFilter(filter);
              num = 3;
              continue;
            case 2:
              if (this.UseFilter)
              {
                num = 5;
                continue;
              }
              goto case 6;
            case 3:
              filter.SetOrder(order);
              fontReader.ReadFontData(fontData, filter);
              num = 2;
              continue;
            case 4:
              goto label_17;
            case 5:
              filter.CheckEqual(fontData);
              num = 6;
              continue;
            case 6:
              fontData.ReflectGlyph();
              fontWriter.WriteFontData(fontData, order);
              this.SetStatusString(Strings.IDS_STATUS_FINISH);
              this.SavePathToHistory();
              num = 4;
              continue;
            default:
              goto label_4;
          }
        }
      }
      catch (GeneralException ex)
      {
        ProgressControl.Error(ex.GetMsg());
        this.SetStatusString(Strings.IDS_STATUS_ERROR);
        this.ResetProgressBarPos();
      }
      catch (ConvertCancelException ex)
      {
        this.SetStatusString(Strings.IDS_STATUS_CANCELED);
        this.ResetProgressBarPos();
      }
      catch (OutOfMemoryException ex)
      {
        ProgressControl.Error(Strings.IDS_ERR_OVER_MEMORY);
        this.SetStatusString(Strings.IDS_STATUS_ERROR);
        this.ResetProgressBarPos();
      }
      catch
      {
        ProgressControl.Error(Strings.IDS_ERR_UNKNOWN_EXCEPTION);
        this.SetStatusString(Strings.IDS_STATUS_ERROR);
        this.ResetProgressBarPos();
      }
label_17:
      this.ResetProgressBarPos();
      this.IsConvertReady = true;
    }

    private void e()
    {
      this.k = true;
    }

    private void d()
    {
      this.c();
    }

    private void c()
    {
      int num = 5;
      string currentPath;
      while (true)
      {
        switch (num)
        {
          case 0:
            currentPath = this.CurrentPath;
            num = 4;
            continue;
          case 1:
            if (!File.Exists(currentPath))
            {
              num = 3;
              continue;
            }
            goto label_9;
          case 2:
            num = 1;
            continue;
          case 3:
            goto label_5;
          case 4:
            if (1 == 0)
              ;
            if (currentPath.Length != 0)
            {
              num = 2;
              continue;
            }
            goto label_4;
          default:
            if (this.UseFilter)
            {
              num = 0;
              continue;
            }
            goto label_14;
        }
      }
label_14:
      return;
label_5:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_FILTER_NOT_EXISTS, (object) currentPath);
label_9:
      return;
label_4:;
    }

    private List<InSettingViewModel> b()
    {
      if (1 == 0)
        ;
      return new List<InSettingViewModel>()
      {
        (InSettingViewModel) new InImageViewModel(this.h.InImageSettings, this.d),
        (InSettingViewModel) new InNitroViewModel(this.h.InRuntimeBinarySettings),
        (InSettingViewModel) new InWinViewModel(this.h.InWinSettings)
      };
    }

    private List<OutSettingViewModel> a()
    {
      if (1 == 0)
        ;
      return new List<OutSettingViewModel>()
      {
        (OutSettingViewModel) new OutImageViewModel(this.h.OutImageSettings, this.d),
        (OutSettingViewModel) new OutNitroViewModel(this.h.OutRuntimeBinarySettings)
      };
    }
  }
}
