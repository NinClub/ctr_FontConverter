// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.FontData
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Runtime;
using System;
using System.Collections.Generic;

namespace NintendoWare.Font
{
  public class FontData
  {
    private readonly GlyphList m_a = new GlyphList();
    private bool b;
    private bool c;

    public int? LineHeight { get; set; }

    public int? Width { get; set; }

    public int? Ascent { get; set; }

    public int? Descent { get; set; }

    public int? BaselinePos { get; set; }

    public int? CellWidth { get; set; }

    public int? CellHeight { get; set; }

    public int? MaxCharWidth { get; set; }

    public CharWidths? DefaultWidth { get; set; }

    public ushort? AlterChar { get; set; }

    public GlyphImageFormat? OutputFormat { get; set; }

    public IntColor? NullColor { get; set; }

    public FontData()
    {
      this.b = false;
      this.c = false;
    }

    public FontData(FontData src)
    {
      this.LineHeight = src.LineHeight;
      this.Width = src.Width;
      this.Ascent = src.Ascent;
      this.Descent = src.Descent;
      this.BaselinePos = src.BaselinePos;
      this.CellWidth = src.CellWidth;
      this.CellHeight = src.CellHeight;
      this.MaxCharWidth = src.MaxCharWidth;
      this.DefaultWidth = src.DefaultWidth;
      this.AlterChar = src.AlterChar;
      this.OutputFormat = src.OutputFormat;
      this.NullColor = src.NullColor;
    }

    public void SetWidth(int w)
    {
      this.Width = new int?(w);
      this.b = true;
    }

    public void SetHeight(int a, int d)
    {
      if (1 == 0)
        ;
      this.Ascent = new int?(a);
      this.Descent = new int?(d);
      this.c = true;
    }

    public bool IsWidthExplicit()
    {
      return this.b;
    }

    public bool IsHeightExplicit()
    {
      return this.c;
    }

    public GlyphList GetGlyphList()
    {
      return this.m_a;
    }

    public void ReflectGlyph()
    {
      int num1 = 15;
      int? lineHeight = null;
      int? ascent = null;
      int A_0_1 = 0;
      int A_0_2 = 0;
      int A_0_3 = 0;
      int A_0_4 = 0;
      IEnumerator<Glyph> enumerator = null;
      CharWidths? defaultWidth = null;
      IntColor? nullColor = null;
      GlyphImageFormat? outputFormat = null;
      int? width = null;
      int? descent = null;
      while (true)
      {
        switch (num1)
        {
          case 0:
            ascent = this.Ascent;
            num1 = 20;
            continue;
          case 1:
            this.NullColor = new IntColor?(GlCm.BMP_RGBA(byte.MaxValue, byte.MaxValue, byte.MaxValue, (byte) 0));
            num1 = 13;
            continue;
          case 2:
            try
            {
              int num2 = 6;
              Glyph current = null;
              while (true)
              {
                switch (num2)
                {
                  case 0:
                    FontData.a(ref A_0_3, current.Width());
                    FontData.a(ref A_0_4, current.CharFeed());
                    num2 = 1;
                    continue;
                  case 2:
                    FontData.a(ref A_0_1, current.Ascent());
                    FontData.a(ref A_0_2, current.Descent());
                    num2 = 0;
                    continue;
                  case 3:
                    if (current.Height() > 0)
                    {
                      num2 = 2;
                      continue;
                    }
                    goto case 0;
                  case 4:
                    if (enumerator.MoveNext())
                    {
                      current = enumerator.Current;
                      num2 = 3;
                      continue;
                    }
                    num2 = 5;
                    continue;
                  case 5:
                    num2 = 7;
                    continue;
                  case 7:
                    goto label_52;
                  default:
                    num2 = 4;
                    continue;
                }
              }
            }
            finally
            {
              int num2 = 1;
              while (true)
              {
                switch (num2)
                {
                  case 0:
                    goto label_37;
                  case 2:
                    enumerator.Dispose();
                    num2 = 0;
                    continue;
                  default:
                    if (enumerator != null)
                    {
                      num2 = 2;
                      continue;
                    }
                    goto label_37;
                }
              }
label_37:;
            }
label_52:
            num1 = 3;
            continue;
          case 3:
            if (A_0_1 == int.MinValue)
            {
              num1 = 17;
              continue;
            }
            goto case 21;
          case 4:
            if (!lineHeight.HasValue)
            {
              num1 = 10;
              continue;
            }
            goto case 7;
          case 5:
            goto label_41;
          case 6:
            lineHeight = this.LineHeight;
            num1 = 4;
            continue;
          case 7:
            defaultWidth = this.DefaultWidth;
            num1 = 16;
            continue;
          case 8:
            nullColor = this.NullColor;
            num1 = 11;
            continue;
          case 9:
            if (outputFormat.HasValue)
            {
              A_0_1 = int.MinValue;
              A_0_2 = int.MinValue;
              A_0_3 = 0;
              A_0_4 = 0;
              enumerator = this.m_a.GetEnum().GetEnumerator();
              num1 = 2;
              continue;
            }
            num1 = 19;
            continue;
          case 10:
            this.LineHeight = new int?(this.Ascent.Value + this.Descent.Value);
            num1 = 7;
            continue;
          case 11:
            if (!nullColor.HasValue)
            {
              num1 = 1;
              continue;
            }
            goto label_56;
          case 12:
            if (!descent.HasValue)
            {
              num1 = 25;
              continue;
            }
            goto case 6;
          case 13:
            goto label_56;
          case 14:
            this.Width = this.MaxCharWidth;
            num1 = 0;
            continue;
          case 16:
            if (!defaultWidth.HasValue)
            {
              num1 = 22;
              continue;
            }
            goto case 8;
          case 17:
            A_0_1 = 0;
            A_0_2 = 0;
            num1 = 21;
            continue;
          case 18:
            descent = this.Descent;
            num1 = 12;
            continue;
          case 19:
            goto label_15;
          case 20:
            if (!ascent.HasValue)
            {
              num1 = 24;
              continue;
            }
            goto case 18;
          case 21:
            this.BaselinePos = new int?(A_0_1);
            this.CellHeight = new int?(A_0_1 + A_0_2);
            this.CellWidth = new int?(A_0_3);
            this.MaxCharWidth = new int?(A_0_4);
            width = this.Width;
            num1 = 23;
            continue;
          case 22:
            if (1 == 0)
              ;
            this.DefaultWidth = new CharWidths?(new CharWidths((sbyte) 0, (byte) this.CellWidth.Value, (sbyte) this.CellWidth.Value));
            num1 = 8;
            continue;
          case 23:
            if (!width.HasValue)
            {
              num1 = 14;
              continue;
            }
            goto case 0;
          case 24:
            this.Ascent = new int?(Math.Max(0, A_0_1));
            num1 = 18;
            continue;
          case 25:
            this.Descent = new int?(Math.Max(0, A_0_2));
            num1 = 6;
            continue;
          default:
            if (this.m_a.GetNum() == 0)
            {
              num1 = 5;
              continue;
            }
            outputFormat = this.OutputFormat;
            num1 = 9;
            continue;
        }
      }
label_15:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_OUTPUT_FORMAT_NOT_SPECIFIED);
label_41:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_NO_GLYPH);
label_56:
      this.m_a.SortByCode();
    }

    private static void a(ref int A_0, int A_1)
    {
      if (A_1 <= A_0)
        return;
      A_0 = A_1;
    }
  }
}
