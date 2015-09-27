// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.OutImageSettings
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;
using System.Windows.Media;

namespace NintendoWare.Font
{
  [Serializable]
  public class OutImageSettings
  {
    public StringList FilePaths { get; set; }

    public string OrderFile { get; set; }

    public bool IsSizeOffsetSpec { get; set; }

    public int CellSizeWidth { get; set; }

    public int CellSizeHeight { get; set; }

    public int CellSizeLeft { get; set; }

    public int CellSizeTop { get; set; }

    public int CellMarginLeft { get; set; }

    public int CellMarginTop { get; set; }

    public int CellMarginRight { get; set; }

    public int CellMarginBottom { get; set; }

    public bool IsImageCenter { get; set; }

    public bool IsDrawGrid { get; set; }

    public ImageFileFormat OutImageFormat { get; set; }

    public Color GridColor { get; set; }

    public Color MarginColor { get; set; }

    public Color WidthBarColor { get; set; }

    public Color NullBlockColor { get; set; }

    public Color BackgroundColor { get; set; }

    public OutImageSettings()
    {
      this.OrderFile = "cp1252.xlor";
      this.IsImageCenter = true;
      this.IsDrawGrid = true;
      this.OutImageFormat = ImageFileFormat.Ext;
      this.BackgroundColor = FB.BackgroundColor;
      this.GridColor = FB.GridColor;
      this.MarginColor = FB.MarginColor;
      this.WidthBarColor = FB.WidthBarColor;
      this.NullBlockColor = FB.NullBlockColor;
    }
  }
}
