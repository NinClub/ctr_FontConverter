// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.DispatcherHelper
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System;
using System.Windows.Threading;

namespace NintendoWare.Font
{
  public class DispatcherHelper
  {
    private static DispatcherOperationCallback a = new DispatcherOperationCallback(DispatcherHelper.a);

    public static void DoEvents()
    {
label_2:
      if (1 == 0)
        ;
      DispatcherFrame frame = new DispatcherFrame();
      DispatcherOperation dispatcherOperation = Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, (Delegate) DispatcherHelper.a, (object) frame);
      Dispatcher.PushFrame(frame);
      int num = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (dispatcherOperation.Status != DispatcherOperationStatus.Completed)
            {
              num = 2;
              continue;
            }
            goto label_8;
          case 1:
            goto label_6;
          case 2:
            dispatcherOperation.Abort();
            num = 1;
            continue;
          default:
            goto label_2;
        }
      }
label_6:
      return;
label_8:;
    }

    private static object a(object A_0)
    {
      (A_0 as DispatcherFrame).Continue = false;
      return (object) null;
    }
  }
}
