// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Win32.FONTENUMPROC
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;
using System.Runtime.InteropServices;

namespace NintendoWare.Font.Win32
{
  public delegate int FONTENUMPROC([In] ENUMLOGFONTEX lpelfe, [In] NEWTEXTMETRICEX lpntme, uint FontType, IntPtr lParam);
}
