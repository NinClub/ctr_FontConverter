// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.FontGlyphGroupsEx
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NintendoWare.Font
{
  public class FontGlyphGroupsEx : IBinarizable
  {
    public FontGlyphGroups Body { get; set; }

    public G2dFont.SheetSetList SheetSetList { get; set; }

    public IntArray CompSheetSizes { get; set; }

    public int[] SizeCWDH { get; set; }

    public int[] SizeCMAP { get; set; }

    public void Read(ByteOrderBinaryReader br, int size)
    {
    }

    public void Write(ByteOrderBinaryWriter bw)
    {
label_2:
      int num1 = (int) bw.BaseStream.Position;
      bw.Write((object) this.Body);
      int num2 = this.b();
      int num3 = BinaryFileHeader.Length + BinaryBlockHeader.Length + num2 + this.a();
      List<G2dFont.SheetSet>.Enumerator enumerator1 = this.SheetSetList.GetEnumerator();
      int num4 = 4;
      List<G2dFont.SheetSet>.Enumerator enumerator2 = default(List<G2dFont.SheetSet>.Enumerator);
      List<int>.Enumerator enumerator3 = default(List<int>.Enumerator);
      List<G2dFont.SheetSet>.Enumerator enumerator4 = default(List<G2dFont.SheetSet>.Enumerator);
      List<G2dFont.SheetSet>.Enumerator enumerator5 = default(List<G2dFont.SheetSet>.Enumerator);
      int[] sizeCwdh = null;
      int index1 = 0;
      int[] sizeCmap = null;
      int index2 = 0;
      List<G2dFont.SheetSet>.Enumerator enumerator6 = default(List<G2dFont.SheetSet>.Enumerator);
      while (true)
      {
        switch (num4)
        {
          case 0:
          case 3:
            num4 = 7;
            continue;
          case 1:
            if (index1 < sizeCwdh.Length)
            {
              uint num5 = (uint) sizeCwdh[index1];
              bw.Write(num5);
              ++index1;
              num4 = 11;
              continue;
            }
            num4 = 9;
            continue;
          case 2:
            try
            {
              int num5 = 0;
              while (true)
              {
                switch (num5)
                {
                  case 1:
                    num5 = 4;
                    continue;
                  case 3:
                    if (!enumerator3.MoveNext())
                    {
                      num5 = 1;
                      continue;
                    }
                    uint val = (uint) enumerator3.Current;
                    bw.Write(GlCm.ROUND_UP(val, 4));
                    num5 = 2;
                    continue;
                  case 4:
                    goto label_30;
                  default:
                    num5 = 3;
                    continue;
                }
              }
            }
            finally
            {
              enumerator3.Dispose();
            }
label_30:
            sizeCwdh = this.SizeCWDH;
            index1 = 0;
            num4 = 6;
            continue;
          case 4:
            try
            {
              int num5 = 1;
              while (true)
              {
                switch (num5)
                {
                  case 2:
                    if (enumerator1.MoveNext())
                    {
                      G2dFont.SheetSet current = enumerator1.Current;
                      bw.Write((ushort) num3);
                      num3 += current.Name.Length + 1;
                      num5 = 0;
                      continue;
                    }
                    num5 = 4;
                    continue;
                  case 3:
                    goto label_11;
                  case 4:
                    num5 = 3;
                    continue;
                  default:
                    num5 = 2;
                    continue;
                }
              }
            }
            finally
            {
              enumerator1.Dispose();
            }
label_11:
            bw.Seek(num1 + num2, SeekOrigin.Begin);
            enumerator3 = this.CompSheetSizes.GetEnumerator();
            num4 = 2;
            continue;
          case 5:
            try
            {
              int num5 = 3;
              while (true)
              {
                switch (num5)
                {
                  case 0:
                    num5 = 1;
                    continue;
                  case 1:
                    goto label_31;
                  case 2:
                    if (!enumerator6.MoveNext())
                    {
                      num5 = 0;
                      continue;
                    }
                    G2dFont.SheetSet current = enumerator6.Current;
                    FontGlyphGroupsEx.a(bw, current.UseCMAP);
                    num5 = 4;
                    continue;
                  default:
                    num5 = 2;
                    continue;
                }
              }
            }
            finally
            {
              enumerator6.Dispose();
            }
label_31:
            enumerator5 = this.SheetSetList.GetEnumerator();
            num4 = 13;
            continue;
          case 6:
          case 11:
            num4 = 1;
            continue;
          case 7:
            if (index2 < sizeCmap.Length)
            {
              uint num5 = (uint) sizeCmap[index2];
              bw.Write(num5);
              ++index2;
              num4 = 0;
              continue;
            }
            num4 = 8;
            continue;
          case 8:
            if (1 == 0)
              ;
            GlCm.DIV_UP((int) this.Body.NumSheet, 32);
            enumerator2 = this.SheetSetList.GetEnumerator();
            num4 = 12;
            continue;
          case 9:
            sizeCmap = this.SizeCMAP;
            index2 = 0;
            num4 = 3;
            continue;
          case 10:
            try
            {
              int num5 = 3;
              while (true)
              {
                switch (num5)
                {
                  case 0:
                    num5 = 2;
                    continue;
                  case 1:
                    if (enumerator4.MoveNext())
                    {
                      G2dFont.SheetSet current = enumerator4.Current;
                      FontGlyphGroupsEx.a(bw, current.UseCWDH);
                      num5 = 4;
                      continue;
                    }
                    num5 = 0;
                    continue;
                  case 2:
                    goto label_66;
                  default:
                    num5 = 1;
                    continue;
                }
              }
            }
            finally
            {
              enumerator4.Dispose();
            }
label_66:
            GlCm.DIV_UP((int) this.Body.NumCMAP, 32);
            enumerator6 = this.SheetSetList.GetEnumerator();
            num4 = 5;
            continue;
          case 12:
            try
            {
              int num5 = 0;
              while (true)
              {
                switch (num5)
                {
                  case 1:
                    goto label_61;
                  case 2:
                    if (!enumerator2.MoveNext())
                    {
                      num5 = 4;
                      continue;
                    }
                    G2dFont.SheetSet current = enumerator2.Current;
                    FontGlyphGroupsEx.a(bw, current.UseSheets);
                    num5 = 3;
                    continue;
                  case 4:
                    num5 = 1;
                    continue;
                  default:
                    num5 = 2;
                    continue;
                }
              }
            }
            finally
            {
              enumerator2.Dispose();
            }
label_61:
            GlCm.DIV_UP((int) this.Body.NumCWDH, 32);
            enumerator4 = this.SheetSetList.GetEnumerator();
            num4 = 10;
            continue;
          case 13:
            goto label_20;
          default:
            goto label_2;
        }
      }
label_20:
      try
      {
        int num5 = 3;
        while (true)
        {
          switch (num5)
          {
            case 0:
              if (!enumerator5.MoveNext())
              {
                num5 = 2;
                continue;
              }
              G2dFont.SheetSet current = enumerator5.Current;
              FontGlyphGroupsEx.a(bw, current.Name);
              num5 = 1;
              continue;
            case 2:
              num5 = 4;
              continue;
            case 4:
              goto label_67;
            default:
              num5 = 0;
              continue;
          }
        }
label_67:;
      }
      finally
      {
        enumerator5.Dispose();
      }
    }

    public int GetBlockContentsSize(int offset)
    {
      if (1 == 0)
        ;
      return this.b() + this.a() + Enumerable.Sum<G2dFont.SheetSet>((IEnumerable<G2dFont.SheetSet>) this.SheetSetList, (Func<G2dFont.SheetSet, int>) (A_0 => A_0.Name.Length + 1));
    }

    private static void a(ByteOrderBinaryWriter A_0, G2dFont.BitArray A_1)
    {
      using (List<uint>.Enumerator enumerator = A_1.GetEnumerator())
      {
        int num = 1;
        while (true)
        {
          switch (num)
          {
            case 0:
              if (enumerator.MoveNext())
              {
                uint current = enumerator.Current;
                A_0.Write(current);
                num = 4;
                continue;
              }
              num = 3;
              continue;
            case 2:
              goto label_11;
            case 3:
              num = 2;
              continue;
            default:
              num = 0;
              continue;
          }
        }
      }
label_11:
      if (1 != 0)
        ;
    }

    private static void a(ByteOrderBinaryWriter A_0, string A_1)
    {
      if (1 == 0)
        ;
      byte[] bytes = Encoding.ASCII.GetBytes(A_1 + (object) char.MinValue);
      A_0.Write(bytes, 0, bytes.Length);
    }

    private int b()
    {
      if (1 == 0)
        ;
      return GlCm.ROUND_UP(FontGlyphGroups.Length + 2 * (int) this.Body.NumSet, 4);
    }

    private int a()
    {
      if (1 == 0)
        ;
      return ((int) this.Body.NumSheet + (int) this.Body.NumCWDH + (int) this.Body.NumCMAP) * 4 + (GlCm.DIV_UP((int) this.Body.NumSheet, 32) + GlCm.DIV_UP((int) this.Body.NumCWDH, 32) + GlCm.DIV_UP((int) this.Body.NumCMAP, 32)) * (int) this.Body.NumSet * 4;
    }
  }
}
