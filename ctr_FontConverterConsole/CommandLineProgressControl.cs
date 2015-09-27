// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.CommandLineProgressControl
// Assembly: ctr_FontConverterConsole, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A31F2A30-66C3-4349-9B59-5CB8C11371A6
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverterConsole.exe

using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace NintendoWare.Font
{
  internal class CommandLineProgressControl : IProgressControl
  {
    public static void CreateInstance()
    {
      ProgressControl.SetInstance((IProgressControl) new CommandLineProgressControl());
      ProgressControl.AddListener((TraceListener) new CommandLineProgressControl.LocalConsoleTraceListener());
    }

    public virtual bool IsCanceled()
    {
      return false;
    }

    public virtual void SetStatusString(string msgId)
    {
    }

    public virtual void ResetProgressBarPos()
    {
    }

    public virtual void SetProgressBarMax(int max)
    {
    }

    public virtual void StepProgressBar(int step)
    {
    }

    private class LocalConsoleTraceListener : ConsoleTraceListener
    {
      [ComVisible(false)]
      public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
      {
label_2:
        object[] args = (object[]) null;
        object data1 = (object) null;
        object[] data = (object[]) null;
        if (1 == 0)
          ;
        int num = 2;
        while (true)
        {
          switch (num)
          {
            case 0:
              if (!this.Filter.ShouldTrace(eventCache, source, eventType, id, message, args, data1, data))
              {
                num = 3;
                continue;
              }
              goto label_10;
            case 1:
              num = 0;
              continue;
            case 2:
              if (this.Filter != null)
              {
                num = 1;
                continue;
              }
              goto label_10;
            case 3:
              goto label_9;
            default:
              goto label_2;
          }
        }
label_9:
        return;
label_10:
        this.a();
        this.WriteLine(message);
      }

      [ComVisible(false)]
      public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
      {
label_2:
        object data1 = (object) null;
        object[] data = (object[]) null;
        int num = 0;
        while (true)
        {
          switch (num)
          {
            case 0:
              if (this.Filter != null)
              {
                if (1 == 0)
                  ;
                num = 3;
                continue;
              }
              break;
            case 1:
              goto label_13;
            case 2:
              if (!this.Filter.ShouldTrace(eventCache, source, eventType, id, format, args, data1, data))
              {
                num = 4;
                continue;
              }
              break;
            case 3:
              num = 2;
              continue;
            case 4:
              goto label_12;
            case 5:
              if (args != null)
              {
                num = 1;
                continue;
              }
              goto label_14;
            default:
              goto label_2;
          }
          this.a();
          num = 5;
        }
label_12:
        return;
label_13:
        this.WriteLine(string.Format((IFormatProvider) CultureInfo.InvariantCulture, format, args));
        return;
label_14:
        this.WriteLine(format);
      }

      private void a()
      {
        this.Write(Strings.IDS_WARNING_MSG);
      }
    }
  }
}
