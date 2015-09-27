// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Rpt
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System.Diagnostics;

namespace NintendoWare.Font
{
  public class Rpt
  {
    [Conditional("DEBUG")]
    public static void _RPT0(string format)
    {
    }

    [Conditional("DEBUG")]
    public static void _RPT1(string format, object arg1)
    {
    }

    [Conditional("DEBUG")]
    public static void _RPT2(string format, object arg1, object arg2)
    {
    }

    [Conditional("DEBUG")]
    public static void _RPT3(string format, object arg1, object arg2, object arg3)
    {
    }

    [Conditional("DEBUG")]
    public static void _RPT4(string format, object arg1, object arg2, object arg3, object arg4)
    {
    }

    public static void InitForConsole()
    {
      Debug.Listeners.Remove("Default");
      Debug.Listeners.Add((TraceListener) new ConsoleTraceListener(true));
    }
  }
}
