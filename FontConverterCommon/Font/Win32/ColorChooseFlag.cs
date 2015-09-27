// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Win32.ColorChooseFlag
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;

namespace NintendoWare.Font.Win32
{
  [Flags]
  public enum ColorChooseFlag
  {
    RgbInit = 1,
    FullOpen = 2,
    PreventFullOpen = 4,
    ShowHelp = 8,
    EnableHook = 16,
    EnableTemplate = 32,
    EnableTemplateHandle = 64,
    SolidColor = 128,
    AnyColor = 256,
  }
}
