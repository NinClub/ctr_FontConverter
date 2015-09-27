// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.TextBoxTraceListener
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Windows.Controls;

namespace NintendoWare.Font
{
  public class TextBoxTraceListener : TraceListener
  {
    private const int a = 100;
    private readonly Delegate b;
    private TextBox c;
    private int d;

    public TextBoxTraceListener(TextBox textBox)
    {
      if (textBox == null)
        throw new ArgumentNullException("textBox");
      this.c = textBox;
      this.b = (Delegate) new Action<string>(this.a);
    }

    public void ClearWarningCount()
    {
      this.d = 0;
    }

    public override void Write(string message)
    {
      if (!this.EnsureWriter())
        return;
      this.b(message);
    }

    public override void WriteLine(string message)
    {
      if (!this.EnsureWriter())
      {
        if (1 != 0)
          ;
      }
      else
      {
        this.b(message + "\r\n");
        this.NeedIndent = true;
      }
    }

    [ComVisible(false)]
    public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
    {
label_2:
      object[] args = (object[]) null;
      object data1 = (object) null;
      object[] data = (object[]) null;
      int num = 7;
      while (true)
      {
        switch (num)
        {
          case 0:
            num = this.d > 100 ? 3 : 11;
            continue;
          case 1:
            if (!this.Filter.ShouldTrace(eventCache, source, eventType, id, message, args, data1, data))
            {
              num = 9;
              continue;
            }
            break;
          case 2:
            if (this.Filter != null)
            {
              if (1 == 0)
                ;
              num = 8;
              continue;
            }
            break;
          case 3:
            if (this.d == 101)
            {
              num = 10;
              continue;
            }
            goto label_16;
          case 4:
            goto label_6;
          case 5:
            goto label_20;
          case 6:
            num = eventType != TraceEventType.Error ? 0 : 4;
            continue;
          case 7:
            if (eventType != TraceEventType.Error)
            {
              num = 12;
              continue;
            }
            goto case 13;
          case 8:
            num = 1;
            continue;
          case 9:
            goto label_23;
          case 10:
            this.WriteLine(Strings.IDS_WARN_OVERMAX_WARNING);
            num = 5;
            continue;
          case 11:
            goto label_5;
          case 12:
            ++this.d;
            num = 13;
            continue;
          case 13:
            num = 2;
            continue;
          default:
            goto label_2;
        }
        num = 6;
      }
label_20:
      return;
label_23:
      return;
label_5:
      this.a();
      this.WriteLine(message);
      return;
label_6:
      this.b();
      this.WriteLine(message);
      this.c.ScrollToEnd();
      return;
label_16:;
    }

    [ComVisible(false)]
    public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
    {
label_2:
      object data1 = (object) null;
      object[] data = (object[]) null;
      int num = 15;
      while (true)
      {
        switch (num)
        {
          case 0:
            this.b();
            num = 16;
            continue;
          case 1:
            this.a();
            num = 13;
            continue;
          case 2:
            num = eventType != TraceEventType.Error ? 14 : 0;
            continue;
          case 3:
            this.WriteLine(string.Format((IFormatProvider) CultureInfo.InvariantCulture, format, args));
            num = 8;
            continue;
          case 4:
            if (1 == 0)
              break;
            break;
          case 5:
            this.WriteLine(Strings.IDS_WARN_OVERMAX_WARNING);
            num = 17;
            continue;
          case 6:
            if (this.Filter != null)
            {
              num = 18;
              continue;
            }
            goto label_23;
          case 7:
            if (!this.Filter.ShouldTrace(eventCache, source, eventType, id, format, args, data1, data))
            {
              num = 12;
              continue;
            }
            goto label_23;
          case 8:
          case 11:
            goto label_8;
          case 9:
            if (this.d == 101)
            {
              num = 5;
              continue;
            }
            goto label_19;
          case 10:
            ++this.d;
            num = 4;
            continue;
          case 12:
            goto label_32;
          case 13:
            if (args != null)
            {
              num = 19;
              continue;
            }
            goto label_12;
          case 14:
            num = this.d > 100 ? 9 : 1;
            continue;
          case 15:
            if (eventType != TraceEventType.Error)
            {
              num = 10;
              continue;
            }
            break;
          case 16:
            if (args != null)
            {
              num = 3;
              continue;
            }
            this.WriteLine(format);
            num = 11;
            continue;
          case 17:
            goto label_30;
          case 18:
            num = 7;
            continue;
          case 19:
            goto label_22;
          default:
            goto label_2;
        }
        num = 6;
        continue;
label_23:
        num = 2;
      }
label_32:
      return;
label_30:
      return;
label_8:
      this.c.ScrollToEnd();
      return;
label_12:
      this.WriteLine(format);
      return;
label_19:
      return;
label_22:
      this.WriteLine(string.Format((IFormatProvider) CultureInfo.InvariantCulture, format, args));
    }

    internal bool EnsureWriter()
    {
      return true;
    }

    private void b()
    {
      this.WriteLine(Strings.IDS_ERROR_HR);
    }

    private void a()
    {
      this.Write(Strings.IDS_WARNING + ": ");
    }

    private void b(string A_0)
    {
      int num = 0;
      while (true)
      {
        switch (num)
        {
          case 1:
            goto label_4;
          case 2:
            num = 4;
            continue;
          case 3:
            this.WriteIndent();
            if (1 == 0)
              ;
            num = 2;
            continue;
          case 4:
            if (this.c.Dispatcher.CheckAccess())
            {
              num = 1;
              continue;
            }
            goto label_10;
          default:
            if (this.NeedIndent)
            {
              num = 3;
              continue;
            }
            goto case 2;
        }
      }
label_4:
      this.a(A_0);
      return;
label_10:
      this.c.Dispatcher.BeginInvoke(this.b, new object[1]
      {
        (object) A_0
      });
    }

    private void a(string A_0)
    {
      this.c.AppendText(A_0);
    }
  }
}
