// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.GlyphList
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System.Collections.Generic;

namespace NintendoWare.Font
{
  public class GlyphList
  {
    private readonly GlyphList.GlyphArray a = new GlyphList.GlyphArray();
    private readonly GlyphList.GlyphMap b = new GlyphList.GlyphMap();

    public Glyph GetByCode(ushort ccode)
    {
      Glyph glyph;
      if (this.b.TryGetValue(ccode, out glyph))
        return glyph;
      if (1 == 0)
        ;
      return (Glyph) null;
    }

    public void AddGlyph(Glyph glyph, ushort ccode)
    {
label_2:
      Glyph r;
      bool flag = this.b.TryGetValue(ccode, out r);
      int num = 4;
      while (true)
      {
        switch (num)
        {
          case 0:
            ProgressControl.Warning(Strings.IDS_WARN_MULTIPLE_GLYPHS, (object) ccode, (object) ccode);
            num = 1;
            continue;
          case 1:
            goto label_7;
          case 2:
            num = 3;
            continue;
          case 3:
            if (!glyph.Equals(r))
            {
              num = 0;
              continue;
            }
            goto label_11;
          case 4:
            if (1 == 0)
              ;
            if (flag)
            {
              num = 2;
              continue;
            }
            goto label_12;
          default:
            goto label_2;
        }
      }
label_7:
      return;
label_11:
      return;
label_12:
      glyph.SetIndex((ushort) this.a.Count);
      glyph.SetCode(ccode);
      this.b[ccode] = glyph;
      this.a.Add(glyph);
    }

    public void Reserve(int num)
    {
      this.a.Capacity = num;
    }

    public int GetNum()
    {
      return this.a.Count;
    }

    public void SortByCode()
    {
      this.a.Sort((IComparer<Glyph>) new GlyphList.CodeSortPred());
      ushort index = (ushort) 0;
      using (List<Glyph>.Enumerator enumerator = this.a.GetEnumerator())
      {
        int num = 4;
        while (true)
        {
          switch (num)
          {
            case 1:
              goto label_11;
            case 2:
              num = 1;
              continue;
            case 3:
              if (enumerator.MoveNext())
              {
                enumerator.Current.SetIndex(index);
                ++index;
                num = 0;
                continue;
              }
              num = 2;
              continue;
            default:
              num = 3;
              continue;
          }
        }
      }
label_11:
      if (1 != 0)
        ;
    }

    public void SortByIndex()
    {
      this.a.Sort((IComparer<Glyph>) new GlyphList.IndexSortPred());
    }

    public IEnumerable<Glyph> GetEnum()
    {
      return (IEnumerable<Glyph>) this.a;
    }

    public Glyph GetFirstItem()
    {
      return this.a[0];
    }

    private class GlyphArray : List<Glyph>
    {
    }

    private class GlyphMap : Dictionary<ushort, Glyph>
    {
    }

    private class CodeSortPred : IComparer<Glyph>
    {
      public int Compare(Glyph left, Glyph right)
      {
        return (int) left.GetCode() - (int) right.GetCode();
      }
    }

    private class IndexSortPred : IComparer<Glyph>
    {
      public int Compare(Glyph left, Glyph right)
      {
        return (int) left.GetIndex() - (int) right.GetIndex();
      }
    }
  }
}
