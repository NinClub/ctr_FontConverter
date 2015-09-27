// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.ProgressControl
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System.Diagnostics;

namespace NintendoWare.Font
{
  public class ProgressControl
  {
    private static TraceSource b = new TraceSource("FontConverterTrace", SourceLevels.All);
    private static ProgressControl a;
    private IProgressControl c;

    static ProgressControl()
    {
      ProgressControl.b.Listeners.Remove("Default");
    }

    private ProgressControl(IProgressControl A_0)
    {
      this.c = A_0;
    }

    public static void SetInstance(IProgressControl ctrl)
    {
      ProgressControl.a = new ProgressControl(ctrl);
    }

    public static ProgressControl GetInstance()
    {
      return ProgressControl.a;
    }

    public static void AddListener(TraceListener listener)
    {
      ProgressControl.b.Listeners.Add(listener);
    }

    public static void RemoveListener(TraceListener listener)
    {
      ProgressControl.b.Listeners.Remove(listener);
    }

    public static void Error(string message)
    {
      ProgressControl.b.TraceEvent(TraceEventType.Error, 0, message);
    }

    public static void Error(string format, params object[] arg)
    {
      ProgressControl.b.TraceEvent(TraceEventType.Error, 0, format, arg);
    }

    public static void Warning(string message)
    {
      ProgressControl.b.TraceEvent(TraceEventType.Warning, 0, message);
    }

    public static void Warning(string format, params object[] arg)
    {
      ProgressControl.b.TraceEvent(TraceEventType.Warning, 0, format, arg);
    }

    public bool IsCanceled()
    {
      return this.c.IsCanceled();
    }

    public void SetStatusString(string msgId)
    {
      this.c.SetStatusString(msgId);
    }

    public void ResetProgressBarPos()
    {
      this.c.ResetProgressBarPos();
    }

    public void SetProgressBarMax(int max)
    {
      this.c.SetProgressBarMax(max);
    }

    public void StepProgressBar(int step)
    {
      this.c.StepProgressBar(step);
    }

    public void StepProgressBar()
    {
      this.StepProgressBar(1);
    }
  }
}
