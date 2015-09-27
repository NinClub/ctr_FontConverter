// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Properties.Resources
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace NintendoWare.Font.Properties
{
  [DebuggerNonUserCode]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager a;
    private static CultureInfo b;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        int num = 2;
        while (true)
        {
          switch (num)
          {
            case 0:
              Resources.a = new ResourceManager("NintendoWare.Font.Properties.Resources", typeof (Resources).Assembly);
              num = 1;
              continue;
            case 1:
              goto label_6;
            default:
              if (1 == 0)
                ;
              if (object.ReferenceEquals((object) Resources.a, (object) null))
              {
                num = 0;
                continue;
              }
              goto label_6;
          }
        }
label_6:
        return Resources.a;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return Resources.b;
      }
      set
      {
        Resources.b = value;
      }
    }

    internal Resources()
    {
    }
  }
}
