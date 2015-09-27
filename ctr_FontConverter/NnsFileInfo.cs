// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.NnsFileInfo
// Assembly: ctr_FontConverter, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: A1999911-6192-4667-8515-010F2AF851B1
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\ctr_FontConverter.exe

using System;

namespace NintendoWare.Font
{
  public class NnsFileInfo : IComparable<NnsFileInfo>
  {
    public string Title { get; set; }

    public string Comment { get; set; }

    public string Path { get; set; }

    public string FileName { get; set; }

    public int CompareTo(NnsFileInfo rhs)
    {
      int num = string.Compare(this.Title, rhs.Title, StringComparison.Ordinal);
      if (num == 0)
        return string.Compare(this.FileName, rhs.FileName, StringComparison.OrdinalIgnoreCase);
      if (1 == 0)
        ;
      return num;
    }
  }
}
