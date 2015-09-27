// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Properties.Settings
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using NintendoWare.Font;
using NintendoWare.Font.Win32;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NintendoWare.Font.Properties
{
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
  [CompilerGenerated]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings a = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        return Settings.a;
      }
    }

    [DebuggerNonUserCode]
    [UserScopedSetting]
    public WINDOWPLACEMENT WindowPlacement
    {
      get
      {
        return (WINDOWPLACEMENT) this["WindowPlacement"];
      }
      set
      {
        this["WindowPlacement"] = (object) value;
      }
    }

    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    [UserScopedSetting]
    public bool IsWarningFontLicence
    {
      get
      {
        return (bool) this["IsWarningFontLicence"];
      }
      set
      {
        this["IsWarningFontLicence"] = (object) (bool) (value ? 1 : 0);
      }
    }

    [DebuggerNonUserCode]
    [UserScopedSetting]
    public WINDOWPLACEMENT WarningWindowPlacement
    {
      get
      {
        return (WINDOWPLACEMENT) this["WarningWindowPlacement"];
      }
      set
      {
        this["WarningWindowPlacement"] = (object) value;
      }
    }

    [DebuggerNonUserCode]
    [UserScopedSetting]
    public ConvertSettings ConvertSettings
    {
      get
      {
        return (ConvertSettings) this["ConvertSettings"];
      }
      set
      {
        this["ConvertSettings"] = (object) value;
      }
    }
  }
}
