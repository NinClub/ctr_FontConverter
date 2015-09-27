// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.NitroFontWriter
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Runtime;
using NintendoWare.sdk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NintendoWare.Font
{
  public class NitroFontWriter : FontWriter
  {
    private readonly NitroFontWriter.SubGroupMap p = new NitroFontWriter.SubGroupMap();
    private readonly NitroFontWriter.GroupMap q = new NitroFontWriter.GroupMap();
    private readonly IntArray r = new IntArray();
    private readonly NitroFontWriter.TGLPInfo s = new NitroFontWriter.TGLPInfo();
    public const ushort UseDefault = (ushort) 65535;
    private const int a = 80;
    private const int b = 40;
    private const string c = "*";
    private readonly string d;
    private readonly string e;
    private readonly ushort f;
    private readonly int g;
    private readonly int h;
    private readonly int i;
    private readonly int j;
    private readonly CharEncoding k;
    private readonly GlyphDataType l;
    private readonly int m;
    private readonly int n;
    private readonly int o;
    private ushort t;
    private ushort u;
    private bool v;

    public NitroFontWriter(string file, string groupsFile, GlyphDataType type, ushort alter, int linefeed, int width, int left, int right, CharEncoding encoding, int sheetWidth, int sheetHeight)
    {
      this.d = file;
      this.e = groupsFile;
      this.f = alter;
      this.g = linefeed;
      this.i = left;
      this.h = width;
      this.j = right;
      this.k = encoding;
      this.l = type;
      this.v = false;
      this.m = sheetWidth;
      this.n = sheetHeight;
      this.o = 0;
    }

    public NitroFontWriter(string file, string groupsFile, GlyphDataType type, ushort alter, int linefeed, int width, int left, int right, CharEncoding encoding, int sheetPixels)
    {
      this.d = file;
      this.e = groupsFile;
      this.f = alter;
      this.g = linefeed;
      this.i = left;
      this.h = width;
      this.j = right;
      this.k = encoding;
      this.l = type;
      this.v = false;
      this.m = 0;
      this.n = 0;
      this.o = sheetPixels;
    }

    public override void WriteFontData(FontData fontData, GlyphOrder order)
    {
label_2:
      G2dFont A_0 = new G2dFont();
      FontData fontData1 = new FontData(fontData);
      ProgressControl.GetInstance().SetStatusString(string.Format(Strings.IDS_STATUS_WRITE_NITRO, (object) "bcfnt"));
      ProgressControl.GetInstance().ResetProgressBarPos();
      this.a(fontData1, fontData);
      int num1 = 7;
      int num2;
      int num3;
      while (true)
      {
        CharWidths? defaultWidth1;
        CharWidths? defaultWidth2;
        int? cellWidth;
        int num4;
        int num5;
        switch (num1)
        {
          case 0:
            num1 = 14;
            continue;
          case 1:
            if (num2 < this.j)
            {
              num1 = 17;
              continue;
            }
            goto label_37;
          case 2:
            num1 = 16;
            continue;
          case 3:
            num1 = 5;
            continue;
          case 4:
            goto label_9;
          case 5:
            num4 = this.i;
            goto label_28;
          case 6:
            if (this.j >= num3)
            {
              num1 = 13;
              continue;
            }
            goto label_19;
          case 7:
            if (this.h != (int) ushort.MaxValue)
            {
              num1 = 0;
              continue;
            }
            break;
          case 8:
            if (cellWidth.Value < this.h)
            {
              num1 = 4;
              continue;
            }
            break;
          case 9:
            cellWidth = fontData1.CellWidth;
            num1 = 8;
            continue;
          case 10:
            if (this.h == (int) ushort.MaxValue)
            {
              defaultWidth1 = fontData1.DefaultWidth;
              num1 = 12;
              continue;
            }
            num1 = 2;
            continue;
          case 11:
            if (this.j != (int) ushort.MaxValue)
            {
              num1 = 18;
              continue;
            }
            goto label_37;
          case 12:
            num5 = (int) defaultWidth1.Value.GlyphWidth;
            goto label_25;
          case 13:
            if (1 == 0)
              ;
            num1 = 1;
            continue;
          case 14:
            if (this.h >= 0)
            {
              num1 = 9;
              continue;
            }
            goto label_9;
          case 15:
            if (this.i == (int) ushort.MaxValue)
            {
              defaultWidth2 = fontData1.DefaultWidth;
              num1 = 19;
              continue;
            }
            num1 = 3;
            continue;
          case 16:
            num5 = this.h;
            goto label_25;
          case 17:
            goto label_19;
          case 18:
            num1 = 15;
            continue;
          case 19:
            num4 = (int) defaultWidth2.Value.Left;
            goto label_28;
          default:
            goto label_2;
        }
        num1 = 11;
        continue;
label_25:
        int num6 = num5;
        int num7;
        num3 = (int) sbyte.MinValue - (num7 + num6);
        num2 = (int) sbyte.MaxValue - (num7 + num6);
        num1 = 6;
        continue;
label_28:
        num7 = num4;
        num1 = 10;
      }
label_9:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_OUTOFRANGE_DEFAULTWIDTH, (object) this.h, (object) 0, (object) fontData1.CellWidth.Value);
label_19:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_OUTOFRANGE_DEFAULTRIGHTSPACE, (object) this.j, (object) num3, (object) num2);
label_37:
      this.f(A_0, fontData1);
      this.a(A_0);
    }

    public override void GetGlyphOrder(GlyphOrder glyphOrder)
    {
    }

    public override void ValidateInput()
    {
label_2:
      FontIO.ValidateOutputPath(this.d);
      int num1 = 31;
      while (true)
      {
        int num2;
        int num3;
        int num4;
        int num5;
        switch (num1)
        {
          case 0:
            if (this.m == 0)
            {
              num1 = 33;
              continue;
            }
            break;
          case 1:
            num1 = 40;
            continue;
          case 2:
            if (this.n == num5)
            {
              num1 = 11;
              continue;
            }
            goto case 16;
          case 3:
            num2 *= 2;
            num1 = 35;
            continue;
          case 4:
          case 18:
            num1 = 38;
            continue;
          case 5:
            num3 = num2;
            num1 = 3;
            continue;
          case 6:
            num1 = 42;
            continue;
          case 7:
            if (this.i != (int) ushort.MaxValue)
            {
              num1 = 1;
              continue;
            }
            goto label_57;
          case 8:
            goto label_8;
          case 9:
            num1 = 20;
            continue;
          case 10:
            if (this.g != (int) ushort.MaxValue)
            {
              num1 = 39;
              continue;
            }
            goto label_45;
          case 11:
            num4 = num5;
            num1 = 16;
            continue;
          case 12:
            num1 = 21;
            continue;
          case 13:
            if (num4 == 0)
            {
              num1 = 32;
              continue;
            }
            goto label_64;
          case 14:
            num1 = 13;
            continue;
          case 15:
            goto label_39;
          case 16:
            num5 *= 2;
            num1 = 18;
            continue;
          case 17:
            num1 = num2 <= 1024 ? 26 : 36;
            continue;
          case 19:
            goto label_56;
          case 20:
            if ((int) sbyte.MaxValue < this.i)
            {
              num1 = 19;
              continue;
            }
            goto label_57;
          case 21:
            if ((int) this.f == 0)
            {
              num1 = 8;
              continue;
            }
            goto label_33;
          case 22:
            if ((int) this.f != (int) ushort.MaxValue)
            {
              num1 = 12;
              continue;
            }
            goto label_33;
          case 23:
            num1 = 22;
            continue;
          case 24:
            num1 = 37;
            continue;
          case 25:
            if (1 == 0)
              break;
            break;
          case 26:
            if (this.m == num2)
            {
              num1 = 5;
              continue;
            }
            goto case 3;
          case 27:
            if (num3 != 0)
            {
              num1 = 14;
              continue;
            }
            goto label_26;
          case 28:
            goto label_60;
          case 29:
          case 35:
            num1 = 17;
            continue;
          case 30:
            if (this.n != 0)
            {
              num1 = 25;
              continue;
            }
            goto label_66;
          case 31:
            if (this.e != string.Empty)
            {
              num1 = 6;
              continue;
            }
            goto case 23;
          case 32:
            goto label_26;
          case 33:
            num1 = 30;
            continue;
          case 34:
            if (this.g >= 0)
            {
              num1 = 24;
              continue;
            }
            goto label_39;
          case 36:
            num5 = 32;
            num1 = 4;
            continue;
          case 37:
            if ((int) byte.MaxValue < this.g)
            {
              num1 = 15;
              continue;
            }
            goto label_45;
          case 38:
            num1 = num5 <= 1024 ? 2 : 41;
            continue;
          case 39:
            num1 = 34;
            continue;
          case 40:
            if (this.i >= (int) sbyte.MinValue)
            {
              num1 = 9;
              continue;
            }
            goto label_56;
          case 41:
            num1 = 27;
            continue;
          case 42:
            if (!FontIO.IsFileExists(this.e))
            {
              num1 = 28;
              continue;
            }
            new GlyphGroups().Load(this.e);
            num1 = 23;
            continue;
          default:
            goto label_2;
        }
        num3 = 0;
        num4 = 0;
        num2 = 32;
        num1 = 29;
        continue;
label_33:
        num1 = 10;
        continue;
label_45:
        num1 = 7;
        continue;
label_57:
        num1 = 0;
      }
label_8:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_INVALID_ALTER);
label_66:
      return;
label_26:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_INVALID_SHEET_SIZE, (object) this.m, (object) this.n);
label_39:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_OUTOFRANGE_LINEHEIGHT, (object) this.g, (object) 0, (object) byte.MaxValue);
label_56:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_OUTOFRANGE_DEFAULTLEFTSPACE, (object) this.i, (object) sbyte.MinValue, (object) sbyte.MaxValue);
label_60:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_FILE_NOT_EXISTS, (object) this.e);
label_64:;
    }

    private static int a(NitroFontWriter.Group A_0, NitroFontWriter.Group A_1)
    {
      return A_0.CompareTo(A_1);
    }

    private static uint a(ImageBase.Pixel A_0)
    {
      if (1 == 0)
        ;
      return GlCm.InverseNumber((uint) GlCm.RgbToGrayScale((IntColor) A_0.IntColor) >> 4, 4);
    }

    private static int a(int A_0, int A_1)
    {
      if (A_0 != (int) ushort.MaxValue)
        return A_0;
      return A_1;
    }

    private static void a(NitroFontWriter.SubGroupMap A_0, IntIntMap A_1, NitroFontWriter.CodeExistsMap A_2, GlyphGroups.Group A_3, CharEncoding A_4)
    {
label_2:
      NitroFontWriter.SubGroup sg = new NitroFontWriter.SubGroup();
      List<ushort>.Enumerator enumerator = A_3.Chars.GetEnumerator();
      int num1 = 0;
      while (true)
      {
        switch (num1)
        {
          case 0:
            try
            {
              int num2 = 2;
              while (true)
              {
                ushort index;
                bool flag;
                switch (num2)
                {
                  case 0:
                    num2 = 3;
                    continue;
                  case 1:
                    NitroFontWriter.GlyphCode glyphCode = new NitroFontWriter.GlyphCode(index, (ushort) 0);
                    sg.CodeList.Add(glyphCode);
                    A_2[index] = true;
                    num2 = 6;
                    continue;
                  case 3:
                    goto label_3;
                  case 4:
                    if (enumerator.MoveNext())
                    {
                      ushort current = enumerator.Current;
                      index = GlCm.UnicodeToEncoding(A_4, current);
                      num2 = 8;
                      continue;
                    }
                    num2 = 0;
                    continue;
                  case 5:
                    flag = A_2.ContainsKey(index);
                    num2 = 7;
                    continue;
                  case 7:
                    if (flag)
                    {
                      num2 = 1;
                      continue;
                    }
                    break;
                  case 8:
                    if ((int) index != (int) ushort.MaxValue)
                    {
                      num2 = 5;
                      continue;
                    }
                    break;
                }
                num2 = 4;
              }
            }
            finally
            {
              if (1 == 0)
                ;
              enumerator.Dispose();
            }
label_3:
            num1 = 1;
            continue;
          case 1:
            if (sg.CodeList.Count == 0)
            {
              num1 = 2;
              continue;
            }
            goto label_22;
          case 2:
            goto label_19;
          default:
            goto label_2;
        }
      }
label_19:
      return;
label_22:
      A_0.Add(sg);
      A_1.Add(A_3.Index, sg.Index);
    }

    private static void a(NitroFontWriter.SubGroupMap A_0, IntIntMap A_1, NitroFontWriter.CodeExistsMap A_2, GlyphGroups.GroupList A_3, CharEncoding A_4)
    {
      using (List<GlyphGroups.Group>.Enumerator enumerator = A_3.GetEnumerator())
      {
        int num = 5;
        GlyphGroups.Group current;
        while (true)
        {
          switch (num)
          {
            case 1:
              if (current.Groups.Count == 0)
              {
                num = 3;
                continue;
              }
              NitroFontWriter.a(A_0, A_1, A_2, current.Groups, A_4);
              num = 0;
              continue;
            case 3:
              NitroFontWriter.a(A_0, A_1, A_2, current, A_4);
              num = 2;
              continue;
            case 4:
              if (enumerator.MoveNext())
              {
                current = enumerator.Current;
                if (1 == 0)
                  ;
                num = 1;
                continue;
              }
              num = 6;
              continue;
            case 6:
              num = 7;
              continue;
            case 7:
              goto label_13;
            default:
              num = 4;
              continue;
          }
        }
label_13:;
      }
    }

    private static void a(IntIntMap A_0, NitroFontWriter.GroupMap A_1, IntIntMap A_2, GlyphGroups.Group A_3)
    {
label_2:
      IntIntMap intIntMap = new IntIntMap();
      int num1 = 5;
      int index;
      bool flag1;
      bool flag2;
      List<GlyphGroups.Group>.Enumerator enumerator;
      while (true)
      {
        switch (num1)
        {
          case 0:
            NitroFontWriter.Group group1 = new NitroFontWriter.Group(A_3.Index, A_3.Name);
            GlCm.MakeListFromMapKey<int, int>((List<int>) group1.SubGroups, (Dictionary<int, int>) intIntMap);
            A_1[group1.Name] = group1;
            num1 = 1;
            continue;
          case 1:
            goto label_23;
          case 2:
            A_0.Add(intIntMap);
            NitroFontWriter.Group group2;
            flag2 = A_1.TryGetValue(A_3.Name, out group2);
            num1 = 10;
            continue;
          case 3:
            flag1 = A_2.TryGetValue(A_3.Index, out index);
            num1 = 4;
            continue;
          case 4:
            if (flag1)
            {
              if (1 == 0)
                ;
              num1 = 9;
              continue;
            }
            goto case 7;
          case 5:
            if (A_3.Groups.Count == 0)
            {
              num1 = 3;
              continue;
            }
            enumerator = A_3.Groups.GetEnumerator();
            num1 = 8;
            continue;
          case 6:
            if (intIntMap.Count > 0)
            {
              num1 = 2;
              continue;
            }
            goto label_28;
          case 7:
label_5:
            num1 = 6;
            continue;
          case 8:
            try
            {
              int num2 = 1;
              while (true)
              {
                switch (num2)
                {
                  case 0:
                    goto label_5;
                  case 2:
                    if (enumerator.MoveNext())
                    {
                      GlyphGroups.Group current = enumerator.Current;
                      NitroFontWriter.a(intIntMap, A_1, A_2, current);
                      num2 = 4;
                      continue;
                    }
                    num2 = 3;
                    continue;
                  case 3:
                    num2 = 0;
                    continue;
                  default:
                    num2 = 2;
                    continue;
                }
              }
            }
            finally
            {
              enumerator.Dispose();
            }
          case 9:
            intIntMap[index] = 1;
            num1 = 7;
            continue;
          case 10:
            if (!flag2)
            {
              num1 = 0;
              continue;
            }
            goto label_25;
          default:
            goto label_2;
        }
      }
label_23:
      return;
label_28:
      return;
label_25:;
    }

    private static void a(NitroFontWriter.GroupMap A_0, IntIntMap A_1, GlyphGroups.GroupList A_2)
    {
label_2:
      IntIntMap A_0_1 = new IntIntMap();
      List<GlyphGroups.Group>.Enumerator enumerator = A_2.GetEnumerator();
      if (1 == 0)
        ;
      int num1 = 3;
      int num2;
      bool flag;
      while (true)
      {
        switch (num1)
        {
          case 0:
            if (flag)
            {
              num1 = 1;
              continue;
            }
            goto label_17;
          case 1:
            NitroFontWriter.Group group = new NitroFontWriter.Group(A_0.Count, "*");
            group.SubGroups.Add(num2);
            A_0[group.Name] = group;
            num1 = 2;
            continue;
          case 2:
            goto label_14;
          case 3:
            try
            {
              int num3 = 0;
              while (true)
              {
                switch (num3)
                {
                  case 1:
                    goto label_4;
                  case 2:
                    if (enumerator.MoveNext())
                    {
                      GlyphGroups.Group current = enumerator.Current;
                      NitroFontWriter.a(A_0_1, A_0, A_1, current);
                      num3 = 4;
                      continue;
                    }
                    num3 = 3;
                    continue;
                  case 3:
                    num3 = 1;
                    continue;
                  default:
                    num3 = 2;
                    continue;
                }
              }
            }
            finally
            {
              enumerator.Dispose();
            }
label_4:
            flag = A_1.TryGetValue(-1, out num2);
            num1 = 0;
            continue;
          default:
            goto label_2;
        }
      }
label_14:
      return;
label_17:;
    }

    private static void a(NitroFontWriter.GroupMap A_0, NitroFontWriter.SubGroupMap A_1, FontData A_2)
    {
      NitroFontWriter.SubGroup sg = new NitroFontWriter.SubGroup();
      IEnumerator<Glyph> enumerator = A_2.GetGlyphList().GetEnum().GetEnumerator();
      try
      {
        int num = 1;
        while (true)
        {
          switch (num)
          {
            case 0:
              goto label_14;
            case 2:
              if (enumerator.MoveNext())
              {
                NitroFontWriter.GlyphCode glyphCode = new NitroFontWriter.GlyphCode(enumerator.Current.GetCode(), (ushort) 0);
                sg.CodeList.Add(glyphCode);
                num = 4;
                continue;
              }
              num = 3;
              continue;
            case 3:
              num = 0;
              continue;
            default:
              num = 2;
              continue;
          }
        }
      }
      finally
      {
        int num = 2;
        while (true)
        {
          switch (num)
          {
            case 0:
              enumerator.Dispose();
              num = 1;
              continue;
            case 1:
              goto label_13;
            default:
              if (enumerator != null)
              {
                num = 0;
                continue;
              }
              goto label_13;
          }
        }
label_13:;
      }
label_14:
      if (1 == 0)
        ;
      A_1.Add(sg);
      NitroFontWriter.Group group = new NitroFontWriter.Group(0, string.Empty);
      group.SubGroups.Add(0);
      A_0[group.Name] = group;
    }

    private void a(NitroFontWriter.SubGroupMap A_0, IntIntMap A_1, GlyphGroups.GroupList A_2, FontData A_3, CharEncoding A_4)
    {
label_3:
      NitroFontWriter.CodeExistsMap A_2_1 = new NitroFontWriter.CodeExistsMap();
      IEnumerator<Glyph> enumerator1 = A_3.GetGlyphList().GetEnum().GetEnumerator();
      int num1 = 2;
      NitroFontWriter.SubGroup sg;
      while (true)
      {
        if (1 == 0)
          ;
        Dictionary<ushort, bool>.Enumerator enumerator2;
        switch (num1)
        {
          case 0:
            if (sg.CodeList.Count == 0)
            {
              num1 = 3;
              continue;
            }
            goto label_33;
          case 1:
            try
            {
              int num2 = 4;
              while (true)
              {
                KeyValuePair<ushort, bool> current;
                switch (num2)
                {
                  case 0:
                    NitroFontWriter.GlyphCode glyphCode = new NitroFontWriter.GlyphCode(current.Key, (ushort) 0);
                    sg.CodeList.Add(glyphCode);
                    num2 = 2;
                    continue;
                  case 1:
                    if (enumerator2.MoveNext())
                    {
                      current = enumerator2.Current;
                      num2 = 3;
                      continue;
                    }
                    num2 = 5;
                    continue;
                  case 3:
                    if (!current.Value)
                    {
                      num2 = 0;
                      continue;
                    }
                    break;
                  case 5:
                    num2 = 6;
                    continue;
                  case 6:
                    goto label_28;
                }
                num2 = 1;
              }
            }
            finally
            {
              enumerator2.Dispose();
            }
label_28:
            num1 = 0;
            continue;
          case 2:
            try
            {
              int num2 = 1;
              while (true)
              {
                switch (num2)
                {
                  case 0:
                    goto label_31;
                  case 2:
                    num2 = 0;
                    continue;
                  case 4:
                    if (!enumerator1.MoveNext())
                    {
                      num2 = 2;
                      continue;
                    }
                    Glyph current = enumerator1.Current;
                    A_2_1.Add(current.GetCode(), false);
                    num2 = 3;
                    continue;
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
                    goto label_27;
                  case 2:
                    enumerator1.Dispose();
                    num2 = 0;
                    continue;
                  default:
                    if (enumerator1 != null)
                    {
                      num2 = 2;
                      continue;
                    }
                    goto label_27;
                }
              }
label_27:;
            }
label_31:
            NitroFontWriter.a(A_0, A_1, A_2_1, A_2, A_4);
            sg = new NitroFontWriter.SubGroup();
            enumerator2 = A_2_1.GetEnumerator();
            num1 = 1;
            continue;
          case 3:
            goto label_32;
          default:
            goto label_3;
        }
      }
label_32:
      return;
label_33:
      A_0.Add(sg);
      A_1.Add(-1, sg.Index);
    }

    private void b(G2dFont.BitArray A_0, int A_1)
    {
label_2:
      int index1 = GlCm.DIV_UP(A_1, 32);
      int num1 = 4;
      int index2;
      int num2;
      while (true)
      {
        switch (num1)
        {
          case 0:
            index2 = 0;
            num1 = 11;
            continue;
          case 1:
          case 11:
            num1 = 8;
            continue;
          case 2:
            num2 = index1 - A_0.Count;
            num1 = 10;
            continue;
          case 3:
            num1 = 9;
            continue;
          case 4:
            if (A_0.Count != index1)
            {
              num1 = 3;
              continue;
            }
            goto case 0;
          case 5:
            num1 = 13;
            continue;
          case 6:
            if (num2 <= 0)
            {
              num1 = 5;
              continue;
            }
            A_0.Add(0U);
            --num2;
            num1 = 12;
            continue;
          case 7:
            goto label_21;
          case 8:
            if (index2 < index1)
            {
              A_0[index2] = 0U;
              ++index2;
              num1 = 1;
              continue;
            }
            num1 = 7;
            continue;
          case 9:
            if (A_0.Count < index1)
            {
              num1 = 2;
              continue;
            }
            A_0.RemoveRange(index1, A_0.Count);
            num1 = 0;
            continue;
          case 10:
          case 12:
            num1 = 6;
            continue;
          case 13:
            if (1 == 0)
              goto case 0;
            else
              goto case 0;
          default:
            goto label_2;
        }
      }
label_21:;
    }

    private void a(G2dFont.BitArray A_0, int A_1)
    {
      if (1 == 0)
        ;
      int num1 = A_1 % 32;
      int num2 = A_1 / 32;
      List<uint> list;
      int index;
      (list = (List<uint>) A_0)[index = num2] = list[index] | (uint) (1 << 31 - num1);
    }

    private void a(G2dFont.BitArray A_0, NitroFontWriter.IndexList A_1)
    {
      using (List<int>.Enumerator enumerator = A_1.GetEnumerator())
      {
        int num = 1;
        while (true)
        {
          switch (num)
          {
            case 0:
              if (enumerator.MoveNext())
              {
                int current = enumerator.Current;
                this.a(A_0, current);
                if (1 == 0)
                  ;
                num = 3;
                continue;
              }
              num = 4;
              continue;
            case 2:
              goto label_9;
            case 4:
              num = 2;
              continue;
            default:
              num = 0;
              continue;
          }
        }
label_9:;
      }
    }

    private void a(FontData A_0, FontData A_1)
    {
      if (1 == 0)
        ;
      GlyphList glyphList1 = A_1.GetGlyphList();
      GlyphList glyphList2 = A_0.GetGlyphList();
      glyphList2.Reserve(glyphList1.GetNum());
      IEnumerator<Glyph> enumerator = glyphList1.GetEnum().GetEnumerator();
      try
      {
        int num = 5;
        Glyph current;
        ushort code;
        ushort ccode;
        while (true)
        {
          switch (num)
          {
            case 1:
              goto label_19;
            case 2:
              if (enumerator.MoveNext())
              {
                current = enumerator.Current;
                code = current.GetCode();
                ccode = GlCm.UnicodeToEncoding(this.k, code);
                num = 6;
                continue;
              }
              num = 4;
              continue;
            case 3:
              ProgressControl.Warning(Strings.IDS_WARN_CANT_REPRESENT_IN_LOCAL, (object) code, (object) code);
              num = 0;
              continue;
            case 4:
              num = 1;
              continue;
            case 6:
              if ((int) ccode == (int) ushort.MaxValue)
              {
                num = 3;
                continue;
              }
              glyphList2.AddGlyph(new Glyph(current), ccode);
              num = 7;
              continue;
            default:
              num = 2;
              continue;
          }
        }
      }
      finally
      {
        int num = 1;
        while (true)
        {
          switch (num)
          {
            case 0:
              goto label_18;
            case 2:
              enumerator.Dispose();
              num = 0;
              continue;
            default:
              if (enumerator != null)
              {
                num = 2;
                continue;
              }
              goto label_18;
          }
        }
label_18:;
      }
label_19:
      glyphList2.SortByCode();
    }

    private void f(G2dFont A_0, FontData A_1)
    {
label_2:
      ProgressControl.GetInstance().SetProgressBarMax(A_1.GetGlyphList().GetNum() * 3);
      int? cellWidth = A_1.CellWidth;
      int num = 5;
      int? cellHeight;
      int? baselinePos1;
      int? baselinePos2;
      int? maxCharWidth;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_17;
          case 1:
            goto label_6;
          case 2:
            goto label_22;
          case 3:
            if (maxCharWidth.Value <= (int) byte.MaxValue)
            {
              baselinePos2 = A_1.BaselinePos;
              num = 4;
              continue;
            }
            num = 1;
            continue;
          case 4:
            if (baselinePos2.Value <= (int) sbyte.MaxValue)
            {
              baselinePos1 = A_1.BaselinePos;
              num = 9;
              continue;
            }
            num = 6;
            continue;
          case 5:
            if (cellWidth.Value > (int) byte.MaxValue)
            {
              num = 8;
              continue;
            }
            cellHeight = A_1.CellHeight;
            num = 7;
            continue;
          case 6:
            goto label_5;
          case 7:
            if (cellHeight.Value > (int) byte.MaxValue)
            {
              num = 2;
              continue;
            }
            if (1 == 0)
              ;
            maxCharWidth = A_1.MaxCharWidth;
            num = 3;
            continue;
          case 8:
            goto label_13;
          case 9:
            if (baselinePos1.Value < (int) sbyte.MinValue)
            {
              num = 0;
              continue;
            }
            goto label_23;
          default:
            goto label_2;
        }
      }
label_5:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_OVERMAX_BASELINEPOS, (object) A_1.BaselinePos.Value, (object) sbyte.MaxValue);
label_6:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_OVERMAX_MAXCHARWIDTH, (object) A_1.MaxCharWidth.Value, (object) byte.MaxValue);
label_13:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_OVERMAX_GLYPHWIDTH, (object) A_1.CellWidth.Value, (object) byte.MaxValue);
label_17:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_UNDERMIN_BASELINEPOS, (object) A_1.BaselinePos.Value, (object) sbyte.MinValue);
label_22:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_OVERMAX_FONTHEIGHT, (object) A_1.CellHeight.Value, (object) byte.MaxValue);
label_23:
      this.a(this.s, A_1);
      this.a(A_1);
      this.d(A_0, A_1);
      this.c(A_0, A_1);
      this.b(A_0, A_1);
      this.a(A_0, A_1);
      this.e(A_0, A_1);
      A_0.MakeInterBlcokLink();
    }

    private void a(FontData A_0)
    {
      int num1 = 7;
      int index1;
      List<int> list1;
      NitroFontWriter.SurplusList surplusList1;
      int index2;
      NitroFontWriter.SheetSurplus sheetSurplus1;
      int num2;
      uint num3;
      ushort key;
      List<int>[] listArray;
      int index3;
      Dictionary<int, NitroFontWriter.SubGroup>.Enumerator enumerator1;
      bool flag1;
      List<NitroFontWriter.SheetSurplus>.Enumerator enumerator2;
      NitroFontWriter.SharedCodeMap sharedCodeMap;
      List<int> list2;
      int index4;
      Glyph byCode1;
      GlyphGroups.GroupList groups;
      int index5;
      int index6;
      int index7;
      List<int> list3;
      List<int>.Enumerator enumerator3;
      int num4;
      Dictionary<ushort, List<int>>.Enumerator enumerator4;
      KeyValuePair<ushort, List<int>> current1;
      KeyValuePair<ushort, List<int>> current2;
      Dictionary<ushort, List<int>>.Enumerator enumerator5;
      IEnumerator<NitroFontWriter.SheetSurplus> enumerator6;
      NitroFontWriter.SurplusList surplusList2;
      Dictionary<string, NitroFontWriter.Group>.Enumerator enumerator7;
      List<NitroFontWriter.GlyphCode>.Enumerator enumerator8;
      int A_1_1;
      List<int> list4;
      ushort num5;
      NitroFontWriter.SubGroup sg;
      int surplus1;
      int index8;
      int num6;
      NitroFontWriter.SheetSurplus sheetSurplus2;
      GlyphList glyphList;
      ushort? alterChar;
      int count1;
      ushort uni;
      Dictionary<ushort, int> codeSubIndexDic;
      while (true)
      {
        switch (num1)
        {
          case 0:
            NitroFontWriter.SheetSurplus sheetSurplus3 = surplusList1[list1[1]];
            int num7 = GlCm.DIV_UP(sheetSurplus3.NumGlyph, this.s.CellNum);
            sheetSurplus3.Sub.SheetIndexBegin = A_1_1;
            sheetSurplus3.Sub.SheetIndexBeginOffset = num4;
            sheetSurplus3.Sub.SheetIndexEnd = A_1_1 + num7 - 1;
            A_1_1 += num7 - 1;
            num4 += sheetSurplus3.NumGlyph % this.s.CellNum;
            num1 = 20;
            continue;
          case 1:
            if ((int) num5 != (int) ushort.MaxValue)
            {
              num1 = 71;
              continue;
            }
            num5 = A_0_1.GetGlyphList().GetFirstItem().GetCode();
            num1 = 78;
            continue;
          case 2:
            NitroFontWriter.a(this.q, this.p, A_0_1);
            num1 = 97;
            continue;
          case 3:
            enumerator7 = this.q.GetEnumerator();
            num1 = 37;
            continue;
          case 4:
          case 18:
          case 61:
            num1 = 59;
            continue;
          case 5:
            sg = new NitroFontWriter.SubGroup();
            this.p.Add(sg);
            NitroFontWriter.GlyphCode glyphCode1 = new NitroFontWriter.GlyphCode(current2.Key, (ushort) 0);
            sg.CodeList.Add(glyphCode1);
            codeSubIndexDic[current2.Key] = sg.Index;
            enumerator4 = enumerator5;
            num1 = 74;
            continue;
          case 6:
            if (list4[index8] != list1[index1])
            {
              ++index1;
              num1 = 45;
              continue;
            }
            num1 = 72;
            continue;
          case 8:
            goto label_38;
          case 9:
            num1 = 46;
            continue;
          case 10:
            num1 = 54;
            continue;
          case 11:
            if (index4 < surplusList1.Count)
            {
              num1 = 95;
              continue;
            }
            ++index6;
            num1 = 61;
            continue;
          case 12:
            alterChar = A_0_1.AlterChar;
            num5 = alterChar.Value;
            num1 = 16;
            continue;
          case 13:
            if (this.q.Count == 0)
            {
              num1 = 2;
              continue;
            }
            goto case 97;
          case 14:
            try
            {
              int num8 = 5;
              NitroFontWriter.SheetSurplus current3;
              while (true)
              {
                switch (num8)
                {
                  case 0:
                    num8 = 2;
                    continue;
                  case 1:
                    if (current3.Surplus <= 0)
                    {
                      num8 = 3;
                      continue;
                    }
                    goto case 0;
                  case 2:
                    goto label_300;
                  case 3:
                    int num9 = GlCm.DIV_UP(current3.NumGlyph, this.s.CellNum);
                    current3.Sub.SheetIndexBegin = A_1_1;
                    current3.Sub.SheetIndexBeginOffset = 0;
                    current3.Sub.SheetIndexEnd = A_1_1 + num9 - 1;
                    A_1_1 += num9;
                    ++count1;
                    num8 = 6;
                    continue;
                  case 4:
                    if (enumerator2.MoveNext())
                    {
                      current3 = enumerator2.Current;
                      num8 = 1;
                      continue;
                    }
                    num8 = 0;
                    continue;
                  default:
                    num8 = 4;
                    continue;
                }
              }
            }
            finally
            {
              enumerator2.Dispose();
            }
label_300:
            surplusList1.RemoveRange(0, count1);
            index3 = 0;
            num1 = 31;
            continue;
          case 15:
          case 105:
            num1 = 111;
            continue;
          case 16:
            num1 = 1;
            continue;
          case 17:
            ++index8;
            num1 = 119;
            continue;
          case 19:
          case 85:
            num1 = 40;
            continue;
          case 20:
            ++A_1_1;
            index7 = list4.Count - 1;
            num1 = 19;
            continue;
          case 21:
          case 109:
            num1 = 87;
            continue;
          case 22:
            list4.Add(index2);
            num2 += sheetSurplus1.Surplus;
            num1 = 77;
            continue;
          case 23:
            if (G2dFont.IsUnicodeEncoding(this.k))
            {
              num1 = 73;
              continue;
            }
            goto label_313;
          case 24:
            if ((int) num5 == (int) ushort.MaxValue)
            {
              num1 = 35;
              continue;
            }
            goto case 78;
          case 25:
          case 116:
            num1 = 58;
            continue;
          case 26:
            if (list1.Count > 1)
            {
              num1 = 0;
              continue;
            }
            goto case 20;
          case 27:
            index8 = 0;
            num1 = 114;
            continue;
          case 28:
            if (index3 >= surplusList1.Count)
            {
              num1 = 118;
              continue;
            }
            num2 = 0;
            list1 = new List<int>();
            list4 = new List<int>();
            sheetSurplus2 = surplusList1[index3];
            num1 = 47;
            continue;
          case 29:
            num1 = 13;
            continue;
          case 30:
            try
            {
              int num8 = 4;
              while (true)
              {
                switch (num8)
                {
                  case 0:
                    num8 = 2;
                    continue;
                  case 1:
                    if (enumerator6.MoveNext())
                    {
                      NitroFontWriter.SheetSurplus current3 = enumerator6.Current;
                      surplusList2.Add(current3);
                      num8 = 3;
                      continue;
                    }
                    num8 = 0;
                    continue;
                  case 2:
                    goto label_250;
                  default:
                    num8 = 1;
                    continue;
                }
              }
            }
            finally
            {
              int num8 = 0;
              while (true)
              {
                switch (num8)
                {
                  case 1:
                    goto label_92;
                  case 2:
                    enumerator6.Dispose();
                    num8 = 1;
                    continue;
                  default:
                    if (enumerator6 != null)
                    {
                      num8 = 2;
                      continue;
                    }
                    goto label_92;
                }
              }
label_92:;
            }
label_250:
            surplusList1 = surplusList2;
            count1 = 0;
            enumerator2 = surplusList1.GetEnumerator();
            num1 = 14;
            continue;
          case 31:
          case 46:
          case 53:
            num1 = 28;
            continue;
          case 32:
            NitroFontWriter.SheetSurplus sheetSurplus4 = surplusList1[list1[0]];
            int num10 = GlCm.DIV_UP(sheetSurplus4.NumGlyph, this.s.CellNum);
            sheetSurplus4.Sub.SheetIndexBegin = A_1_1;
            sheetSurplus4.Sub.SheetIndexBeginOffset = num4;
            sheetSurplus4.Sub.SheetIndexEnd = A_1_1 + num10 - 1;
            A_1_1 += num10 - 1;
            num4 += sheetSurplus4.NumGlyph % this.s.CellNum;
            num1 = 27;
            continue;
          case 33:
            if (!flag1)
            {
              num1 = 110;
              continue;
            }
            goto case 17;
          case 34:
            if (listArray[(int) key].Count > 1)
            {
              num1 = 43;
              continue;
            }
            goto case 80;
          case 35:
            goto label_312;
          case 36:
            ++index4;
            num1 = 70;
            continue;
          case 37:
            try
            {
              int num8 = 7;
              while (true)
              {
                KeyValuePair<string, NitroFontWriter.Group> current3;
                NitroFontWriter.IndexList indexList1;
                int count2;
                int index9;
                NitroFontWriter.SubGroup subGroup;
                bool flag2;
                switch (num8)
                {
                  case 0:
                    num8 = 4;
                    continue;
                  case 2:
                    enumerator8 = subGroup.CodeList.GetEnumerator();
                    num8 = 3;
                    continue;
                  case 3:
                    try
                    {
                      int num9 = 8;
                      while (true)
                      {
                        NitroFontWriter.IndexList indexList2;
                        int num11;
                        bool flag3;
                        switch (num9)
                        {
                          case 0:
                            if (!enumerator8.MoveNext())
                            {
                              num9 = 7;
                              continue;
                            }
                            NitroFontWriter.GlyphCode current4 = enumerator8.Current;
                            flag3 = codeSubIndexDic.TryGetValue(current4.CharCode, out num11);
                            num9 = 6;
                            continue;
                          case 1:
                            indexList2 = current3.Value.SubGroups;
                            num9 = 4;
                            continue;
                          case 2:
                            goto label_99;
                          case 3:
                            indexList2.Add(num11);
                            num9 = 5;
                            continue;
                          case 4:
                            if (!indexList2.Contains(num11))
                            {
                              num9 = 3;
                              continue;
                            }
                            break;
                          case 6:
                            if (flag3)
                            {
                              num9 = 1;
                              continue;
                            }
                            break;
                          case 7:
                            num9 = 2;
                            continue;
                        }
                        num9 = 0;
                      }
                    }
                    finally
                    {
                      enumerator8.Dispose();
                    }
                  case 4:
                    goto label_129;
                  case 5:
                    if (flag2)
                    {
                      num8 = 6;
                      continue;
                    }
                    break;
                  case 6:
                    num8 = 8;
                    continue;
                  case 8:
                    if (subGroup != null)
                    {
                      num8 = 2;
                      continue;
                    }
                    break;
                  case 9:
                    if (index9 >= count2)
                    {
                      num8 = 1;
                      continue;
                    }
                    flag2 = this.p.TryGetValue(indexList1[index9], out subGroup);
                    num8 = 5;
                    continue;
                  case 10:
                    if (enumerator7.MoveNext())
                    {
                      current3 = enumerator7.Current;
                      indexList1 = current3.Value.SubGroups;
                      count2 = indexList1.Count;
                      index9 = 0;
                      num8 = 12;
                      continue;
                    }
                    num8 = 0;
                    continue;
                  case 11:
                  case 12:
                    num8 = 9;
                    continue;
                  default:
                    num8 = 10;
                    continue;
                }
label_99:
                ++index9;
                num8 = 11;
              }
            }
            finally
            {
              enumerator7.Dispose();
            }
label_129:
            list3 = new List<int>();
            enumerator1 = this.p.GetEnumerator();
            num1 = 92;
            continue;
          case 38:
            num1 = index1 < list1.Count ? 6 : 107;
            continue;
          case 39:
            if (!sharedCodeMap.TryGetValue(key, out list2))
            {
              num1 = 113;
              continue;
            }
            goto case 84;
          case 40:
            if (index7 < 0)
            {
              num1 = 9;
              continue;
            }
            surplusList1.RemoveAt(list4[index7]);
            --index7;
            num1 = 85;
            continue;
          case 41:
            NitroFontWriter.GlyphCode glyphCode2 = new NitroFontWriter.GlyphCode(current1.Key, (ushort) 0);
            sg.CodeList.Add(glyphCode2);
            codeSubIndexDic[current1.Key] = sg.Index;
            current1.Value.Clear();
            num1 = 64;
            continue;
          case 42:
            try
            {
              int num8 = 0;
              while (true)
              {
                KeyValuePair<int, NitroFontWriter.SubGroup> current3;
                int index9;
                switch (num8)
                {
                  case 1:
                    NitroFontWriter.CodeList codeList = current3.Value.CodeList;
                    index9 = current3.Value.Index;
                    enumerator8 = codeList.GetEnumerator();
                    num8 = 5;
                    continue;
                  case 2:
                    if (current3.Value != null)
                    {
                      num8 = 1;
                      continue;
                    }
                    break;
                  case 3:
                    num8 = 6;
                    continue;
                  case 4:
                    if (!enumerator1.MoveNext())
                    {
                      num8 = 3;
                      continue;
                    }
                    current3 = enumerator1.Current;
                    num8 = 2;
                    continue;
                  case 5:
                    try
                    {
                      int num9 = 2;
                      while (true)
                      {
                        switch (num9)
                        {
                          case 0:
                            if (!enumerator8.MoveNext())
                            {
                              num9 = 4;
                              continue;
                            }
                            NitroFontWriter.GlyphCode current4 = enumerator8.Current;
                            listArray[(int) current4.CharCode].Add(index9);
                            num9 = 1;
                            continue;
                          case 3:
                            goto label_166;
                          case 4:
                            num9 = 3;
                            continue;
                          default:
                            num9 = 0;
                            continue;
                        }
                      }
                    }
                    finally
                    {
                      enumerator8.Dispose();
                    }
                  case 6:
                    goto label_218;
                }
label_166:
                num8 = 4;
              }
            }
            finally
            {
              enumerator1.Dispose();
            }
label_218:
            num6 = this.p.Count - 1;
            codeSubIndexDic = new Dictionary<ushort, int>();
            sharedCodeMap = new NitroFontWriter.SharedCodeMap();
            num3 = 0U;
            num1 = 99;
            continue;
          case 43:
            num1 = 39;
            continue;
          case 44:
            if (num2 + sheetSurplus1.Surplus <= this.s.CellNum)
            {
              num1 = 50;
              continue;
            }
            goto case 77;
          case 45:
          case 102:
            num1 = 38;
            continue;
          case 47:
            if (sheetSurplus2.NumGlyph > this.s.CellNum)
            {
              num1 = 69;
              continue;
            }
            goto case 55;
          case 48:
            if (surplus1 + surplusList1[index4].Surplus > this.s.CellNum)
            {
              num1 = 36;
              continue;
            }
            goto case 75;
          case 49:
            if (this.p.Count != 0)
            {
              num1 = 29;
              continue;
            }
            goto case 2;
          case 50:
            num1 = 79;
            continue;
          case 51:
            alterChar = A_0_1.AlterChar;
            num1 = 63;
            continue;
          case 52:
            num1 = index4 < surplusList1.Count ? 48 : 75;
            continue;
          case 54:
            if (list1.Count <= 1)
            {
              num1 = 101;
              continue;
            }
            goto case 77;
          case 55:
            list4.Add(index3);
            num2 += sheetSurplus2.Surplus;
            index2 = index3 + 1;
            num1 = 25;
            continue;
          case 56:
            if (current2.Value.Count > 0)
            {
              num1 = 5;
              continue;
            }
            goto case 21;
          case 57:
          case 70:
            num1 = 52;
            continue;
          case 58:
            if (index2 < surplusList1.Count)
            {
              sheetSurplus1 = surplusList1[index2];
              num1 = 44;
              continue;
            }
            num1 = 115;
            continue;
          case 59:
            if (index6 < surplusList1.Count)
            {
              surplus1 = surplusList1[index6].Surplus;
              index4 = index6 + 1;
              num1 = 57;
              continue;
            }
            num1 = 88;
            continue;
          case 60:
          case 107:
            num1 = 33;
            continue;
          case 62:
            if (num3 < 65536U)
            {
              key = (ushort) num3;
              num1 = 34;
              continue;
            }
            num1 = 83;
            continue;
          case 63:
            if (alterChar.HasValue)
            {
              num1 = 12;
              continue;
            }
            goto case 16;
          case 64:
          case 74:
            num1 = 66;
            continue;
          case 65:
            try
            {
              int num8 = 4;
              while (true)
              {
                NitroFontWriter.CodeList codeList;
                NitroFontWriter.GlyphCode glyphCode3;
                KeyValuePair<int, NitroFontWriter.SubGroup> current3;
                switch (num8)
                {
                  case 0:
                    goto label_132;
                  case 1:
                    codeList.Add(glyphCode3);
                    num8 = 3;
                    continue;
                  case 2:
                    num8 = 0;
                    continue;
                  case 5:
                    if (!codeList.Contains(glyphCode3))
                    {
                      num8 = 1;
                      continue;
                    }
                    break;
                  case 6:
                    if (current3.Value != null)
                    {
                      num8 = 8;
                      continue;
                    }
                    break;
                  case 7:
                    if (enumerator1.MoveNext())
                    {
                      current3 = enumerator1.Current;
                      num8 = 6;
                      continue;
                    }
                    num8 = 2;
                    continue;
                  case 8:
                    glyphCode3 = new NitroFontWriter.GlyphCode(this.t, (ushort) 0);
                    codeList = current3.Value.CodeList;
                    num8 = 5;
                    continue;
                }
                num8 = 7;
              }
            }
            finally
            {
              enumerator1.Dispose();
            }
label_132:
            listArray = new List<int>[65536];
            index5 = 0;
            if (1 == 0)
              ;
            num1 = 105;
            continue;
          case 66:
            if (!enumerator4.MoveNext())
            {
              num1 = 93;
              continue;
            }
            current1 = enumerator4.Current;
            num1 = 90;
            continue;
          case 67:
            enumerator6 = Enumerable.OrderBy<NitroFontWriter.SheetSurplus, int>((IEnumerable<NitroFontWriter.SheetSurplus>) surplusList1, (Func<NitroFontWriter.SheetSurplus, int>) (A_0_2 => A_0_2.Surplus)).GetEnumerator();
            num1 = 30;
            continue;
          case 68:
            GlyphGroups glyphGroups = new GlyphGroups();
            glyphGroups.Load(this.e);
            groups = glyphGroups.GetGroups();
            num1 = 82;
            continue;
          case 69:
            list1.Add(index3);
            num1 = 55;
            continue;
          case 71:
            uni = num5;
            num5 = GlCm.UnicodeToEncoding(this.k, uni);
            num1 = 24;
            continue;
          case 72:
            flag1 = true;
            num1 = 60;
            continue;
          case 73:
            goto label_304;
          case 75:
            num1 = 11;
            continue;
          case 76:
            if (list1.Count > 0)
            {
              num1 = 32;
              continue;
            }
            goto case 27;
          case 77:
            ++index2;
            num1 = 116;
            continue;
          case 78:
            this.t = num5;
            enumerator1 = this.p.GetEnumerator();
            num1 = 65;
            continue;
          case 79:
            if (sheetSurplus1.NumGlyph > this.s.CellNum)
            {
              num1 = 10;
              continue;
            }
            goto case 22;
          case 80:
            ++num3;
            num1 = 89;
            continue;
          case 81:
            try
            {
              int num8 = 3;
              while (true)
              {
                int index9;
                NitroFontWriter.CodeList codeList;
                ushort num9;
                Glyph byCode2;
                KeyValuePair<int, NitroFontWriter.SubGroup> current3;
                switch (num8)
                {
                  case 0:
                    if (G2dFont.IsUnicodeEncoding(this.k))
                    {
                      num8 = 12;
                      continue;
                    }
                    goto label_263;
                  case 1:
                    goto label_302;
                  case 2:
                    num8 = 1;
                    continue;
                  case 4:
                    codeList = current3.Value.CodeList;
                    codeList.Sort();
                    num9 = (ushort) (current3.Value.SheetIndexBegin * this.s.CellNum + current3.Value.SheetIndexBeginOffset);
                    index9 = 0;
                    num8 = 10;
                    continue;
                  case 5:
                  case 10:
                    num8 = 13;
                    continue;
                  case 6:
                    if (!enumerator1.MoveNext())
                    {
                      num8 = 2;
                      continue;
                    }
                    current3 = enumerator1.Current;
                    num8 = 8;
                    continue;
                  case 7:
                    num8 = 0;
                    continue;
                  case 8:
                    if (current3.Value != null)
                    {
                      num8 = 4;
                      continue;
                    }
                    break;
                  case 9:
                    if (byCode2 == null)
                    {
                      num8 = 7;
                      continue;
                    }
                    byCode2.SetIndex(codeList[index9].GryphIndex);
                    ++index9;
                    num8 = 5;
                    continue;
                  case 12:
                    goto label_264;
                  case 13:
                    if (index9 >= codeList.Count)
                    {
                      num8 = 11;
                      continue;
                    }
                    codeList[index9] = new NitroFontWriter.GlyphCode(codeList[index9].CharCode, num9++);
                    byCode2 = glyphList.GetByCode(codeList[index9].CharCode);
                    num8 = 9;
                    continue;
                }
                num8 = 6;
              }
label_263:
              throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_ALTER_NOT_INCLUDED_LOCAL, (object) this.f, (object) this.t);
label_264:
              throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_ALTER_NOT_INCLUDED_UNICODE, (object) this.f, (object) this.t);
            }
            finally
            {
              enumerator1.Dispose();
            }
label_302:
            byCode1 = A_0_1.GetGlyphList().GetByCode(this.t);
            num1 = 117;
            continue;
          case 82:
            if (groups.Count > 0)
            {
              num1 = 103;
              continue;
            }
            goto case 91;
          case 83:
            enumerator5 = sharedCodeMap.GetEnumerator();
            num1 = 21;
            continue;
          case 84:
            sharedCodeMap[key] = listArray[(int) key];
            listArray[(int) key] = list2;
            num1 = 80;
            continue;
          case 86:
            try
            {
              int num8 = 3;
              while (true)
              {
                switch (num8)
                {
                  case 1:
                    num8 = 2;
                    continue;
                  case 2:
                    goto label_210;
                  case 4:
                    if (!enumerator2.MoveNext())
                    {
                      num8 = 1;
                      continue;
                    }
                    NitroFontWriter.SheetSurplus current3 = enumerator2.Current;
                    int num9 = GlCm.DIV_UP(current3.NumGlyph, this.s.CellNum);
                    current3.Sub.SheetIndexBegin = A_1_1;
                    current3.Sub.SheetIndexBeginOffset = 0;
                    current3.Sub.SheetIndexEnd = A_1_1 + num9 - 1;
                    A_1_1 += num9;
                    num8 = 0;
                    continue;
                  default:
                    num8 = 4;
                    continue;
                }
              }
            }
            finally
            {
              enumerator2.Dispose();
            }
label_210:
            surplusList1.Clear();
            this.s.SheetNum = A_1_1;
            this.s.AllSheetCellNum = this.s.SheetNum * this.s.CellNum;
            glyphList = A_0_1.GetGlyphList();
            enumerator1 = this.p.GetEnumerator();
            num1 = 81;
            continue;
          case 87:
            if (enumerator5.MoveNext())
            {
              current2 = enumerator5.Current;
              num1 = 56;
              continue;
            }
            num1 = 3;
            continue;
          case 88:
            enumerator2 = surplusList1.GetEnumerator();
            num1 = 86;
            continue;
          case 89:
          case 99:
            num1 = 62;
            continue;
          case 90:
            if (Enumerable.SequenceEqual<int>((IEnumerable<int>) current1.Value, (IEnumerable<int>) current2.Value))
            {
              num1 = 41;
              continue;
            }
            goto case 64;
          case 91:
            num1 = 49;
            continue;
          case 92:
            try
            {
              int num8 = 7;
              while (true)
              {
                KeyValuePair<int, NitroFontWriter.SubGroup> current3;
                NitroFontWriter.CodeList codeList;
                switch (num8)
                {
                  case 0:
                    list3.Add(current3.Key);
                    num8 = 9;
                    continue;
                  case 1:
                    if (codeList.Count == 0)
                    {
                      num8 = 0;
                      continue;
                    }
                    break;
                  case 2:
                    codeList = current3.Value.CodeList;
                    num8 = 3;
                    continue;
                  case 3:
                    codeList.RemoveAll((Predicate<NitroFontWriter.GlyphCode>) (c => codeSubIndexDic.ContainsKey(c.CharCode)));
                    num8 = 1;
                    continue;
                  case 4:
                    if (current3.Value != null)
                    {
                      num8 = 5;
                      continue;
                    }
                    break;
                  case 5:
                    num8 = 6;
                    continue;
                  case 6:
                    if (current3.Value.Index <= num6)
                    {
                      num8 = 2;
                      continue;
                    }
                    break;
                  case 8:
                    num8 = 11;
                    continue;
                  case 10:
                    if (enumerator1.MoveNext())
                    {
                      current3 = enumerator1.Current;
                      num8 = 4;
                      continue;
                    }
                    num8 = 8;
                    continue;
                  case 11:
                    goto label_59;
                }
                num8 = 10;
              }
            }
            finally
            {
              enumerator1.Dispose();
            }
label_59:
            enumerator3 = list3.GetEnumerator();
            num1 = 98;
            continue;
          case 93:
            current2.Value.Clear();
            num1 = 109;
            continue;
          case 94:
            num4 = 0;
            num1 = 76;
            continue;
          case 95:
            int A_2 = 0;
            this.a(surplusList1[index6], ref A_1_1, ref A_2);
            this.a(surplusList1[index4], ref A_1_1, ref A_2);
            ++A_1_1;
            surplusList1.RemoveAt(index4);
            surplusList1.RemoveAt(index6);
            num1 = 4;
            continue;
          case 96:
            if (list4.Count > 2)
            {
              num1 = 94;
              continue;
            }
            ++index3;
            num1 = 53;
            continue;
          case 97:
            num5 = this.f;
            num1 = 108;
            continue;
          case 98:
            try
            {
              int num8 = 0;
              while (true)
              {
                switch (num8)
                {
                  case 1:
                    num8 = 4;
                    continue;
                  case 2:
                    if (enumerator3.MoveNext())
                    {
                      this.p[enumerator3.Current] = (NitroFontWriter.SubGroup) null;
                      num8 = 3;
                      continue;
                    }
                    num8 = 1;
                    continue;
                  case 4:
                    goto label_208;
                  default:
                    num8 = 2;
                    continue;
                }
              }
            }
            finally
            {
              enumerator3.Dispose();
            }
label_208:
            surplusList1 = new NitroFontWriter.SurplusList();
            A_1_1 = 0;
            enumerator1 = this.p.GetEnumerator();
            num1 = 106;
            continue;
          case 100:
            enumerator1 = this.p.GetEnumerator();
            num1 = 42;
            continue;
          case 101:
            list1.Add(index2);
            num1 = 22;
            continue;
          case 103:
            IntIntMap A_1_2 = new IntIntMap();
            this.a(this.p, A_1_2, groups, A_0_1, this.k);
            NitroFontWriter.a(this.q, A_1_2, groups);
            this.v = true;
            num1 = 91;
            continue;
          case 104:
            if (index8 >= list4.Count)
            {
              num1 = 112;
              continue;
            }
            flag1 = false;
            index1 = 0;
            num1 = 102;
            continue;
          case 106:
            try
            {
              int num8 = 3;
              while (true)
              {
                NitroFontWriter.SubGroup sub;
                switch (num8)
                {
                  case 0:
                    if (enumerator1.MoveNext())
                    {
                      sub = enumerator1.Current.Value;
                      num8 = 1;
                      continue;
                    }
                    num8 = 2;
                    continue;
                  case 1:
                    if (sub != null)
                    {
                      num8 = 6;
                      continue;
                    }
                    break;
                  case 2:
                    num8 = 4;
                    continue;
                  case 4:
                    goto label_206;
                  case 6:
                    int count2 = sub.CodeList.Count;
                    int surplus2 = count2 % this.s.CellNum;
                    NitroFontWriter.SheetSurplus sheetSurplus5 = new NitroFontWriter.SheetSurplus(sub, count2, surplus2);
                    surplusList1.Add(sheetSurplus5);
                    num8 = 5;
                    continue;
                }
                num8 = 0;
              }
            }
            finally
            {
              enumerator1.Dispose();
            }
label_206:
            surplusList2 = new NitroFontWriter.SurplusList();
            num1 = 67;
            continue;
          case 108:
            if ((int) num5 == (int) ushort.MaxValue)
            {
              num1 = 51;
              continue;
            }
            goto case 16;
          case 110:
            NitroFontWriter.SheetSurplus sheetSurplus6 = surplusList1[list4[index8]];
            sheetSurplus6.Sub.SheetIndexBegin = A_1_1;
            sheetSurplus6.Sub.SheetIndexBeginOffset = num4;
            sheetSurplus6.Sub.SheetIndexEnd = A_1_1;
            num4 += sheetSurplus6.NumGlyph;
            num1 = 17;
            continue;
          case 111:
            if (index5 < listArray.Length)
            {
              listArray[index5] = new List<int>();
              ++index5;
              num1 = 15;
              continue;
            }
            num1 = 100;
            continue;
          case 112:
            num1 = 26;
            continue;
          case 113:
            list2 = new List<int>();
            num1 = 84;
            continue;
          case 114:
          case 119:
            num1 = 104;
            continue;
          case 115:
            num1 = 96;
            continue;
          case 117:
            num1 = byCode1 == null ? 23 : 8;
            continue;
          case 118:
            index6 = 0;
            num1 = 18;
            continue;
          default:
            if (this.e != string.Empty)
            {
              num1 = 68;
              continue;
            }
            goto case 91;
        }
      }
label_38:
      this.u = byCode1.GetIndex();
      return;
label_304:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_ALTER_NOT_INCLUDED_UNICODE, (object) this.f, (object) this.t);
label_312:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_ALTER_TO_LOCAL, (object) uni, (object) uni);
label_313:
      throw GlCm.ErrMsg(ErrorType.Parameter, Strings.IDS_ERR_ALTER_NOT_INCLUDED_LOCAL, (object) this.f, (object) this.t);
    }

    private void a(NitroFontWriter.SheetSurplus A_0, ref int A_1, ref int A_2)
    {
      if (1 == 0)
        ;
      int num = GlCm.DIV_UP(A_0.NumGlyph, this.s.CellNum);
      A_0.Sub.SheetIndexBegin = A_1;
      A_0.Sub.SheetIndexBeginOffset = A_2;
      A_0.Sub.SheetIndexEnd = A_1 + num - 1;
      A_1 += num - 1;
      A_2 += A_0.NumGlyph % this.s.CellNum;
    }

    private void e(G2dFont A_0, FontData A_1)
    {
      int num1 = 0;
      List<NitroFontWriter.Group> list;
      G2dFont.SheetSetList sheetSetList;
      int numBlock1;
      int numBlock2;
      List<NitroFontWriter.Group>.Enumerator enumerator1;
      while (true)
      {
        if (1 == 0)
          ;
        int numBlock3;
        Dictionary<int, NitroFontWriter.SubGroup>.Enumerator enumerator2;
        switch (num1)
        {
          case 1:
            goto label_7;
          case 2:
            try
            {
              int num2 = 0;
              while (true)
              {
                KeyValuePair<int, NitroFontWriter.SubGroup> current;
                int num3;
                switch (num2)
                {
                  case 1:
                    if (enumerator2.MoveNext())
                    {
                      current = enumerator2.Current;
                      num2 = 7;
                      continue;
                    }
                    num2 = 8;
                    continue;
                  case 2:
                    if (num3 >= numBlock3)
                    {
                      num2 = 4;
                      continue;
                    }
                    current.Value.MapBlocks.Add(num3);
                    ++num3;
                    num2 = 9;
                    continue;
                  case 3:
                    goto label_5;
                  case 5:
                  case 9:
                    num2 = 2;
                    continue;
                  case 6:
                    current.Value.MapBlocks.Capacity = numBlock3;
                    num3 = 0;
                    num2 = 5;
                    continue;
                  case 7:
                    if (current.Value != null)
                    {
                      num2 = 6;
                      continue;
                    }
                    break;
                  case 8:
                    num2 = 3;
                    continue;
                }
                num2 = 1;
              }
            }
            finally
            {
              enumerator2.Dispose();
            }
label_5:
            list = new List<NitroFontWriter.Group>();
            GlCm.MakeListFromMapValue<string, NitroFontWriter.Group>(list, (Dictionary<string, NitroFontWriter.Group>) this.q);
            list.Sort(new Comparison<NitroFontWriter.Group>(NitroFontWriter.a));
            sheetSetList = new G2dFont.SheetSetList();
            numBlock1 = A_0.GetNumBlock(RtConsts.BinBlockSigCWDH);
            numBlock2 = A_0.GetNumBlock(RtConsts.BinBlockSigCMAP);
            enumerator1 = list.GetEnumerator();
            num1 = 1;
            continue;
          case 3:
            goto label_49;
          default:
            if (this.q.Count < 2)
            {
              num1 = 3;
              continue;
            }
            numBlock3 = A_0.GetNumBlock(RtConsts.BinBlockSigCMAP);
            enumerator2 = this.p.GetEnumerator();
            num1 = 2;
            continue;
        }
      }
label_49:
      return;
label_7:
      try
      {
        int num2 = 1;
        G2dFont.SheetSet sheetSet;
        List<int>.Enumerator enumerator2;
        while (true)
        {
          switch (num2)
          {
            case 2:
              if (enumerator1.MoveNext())
              {
                NitroFontWriter.Group current = enumerator1.Current;
                sheetSet = new G2dFont.SheetSet(current.Name);
                this.b(sheetSet.UseSheets, this.s.SheetNum);
                this.b(sheetSet.UseCWDH, numBlock1);
                this.b(sheetSet.UseCMAP, numBlock2);
                enumerator2 = current.SubGroups.GetEnumerator();
                num2 = 5;
                continue;
              }
              num2 = 3;
              continue;
            case 3:
              num2 = 4;
              continue;
            case 4:
              goto label_51;
            case 5:
              try
              {
                int num3 = 0;
                while (true)
                {
                  NitroFontWriter.SubGroup subGroup1;
                  bool flag;
                  NitroFontWriter.SubGroup subGroup2;
                  int sheetIndexBegin;
                  switch (num3)
                  {
                    case 1:
                      if (flag)
                      {
                        num3 = 7;
                        continue;
                      }
                      break;
                    case 2:
                      goto label_13;
                    case 3:
                      if (subGroup1 != null)
                      {
                        num3 = 4;
                        continue;
                      }
                      break;
                    case 4:
                      subGroup2 = subGroup1;
                      sheetIndexBegin = subGroup2.SheetIndexBegin;
                      num3 = 5;
                      continue;
                    case 5:
                    case 8:
                      num3 = 9;
                      continue;
                    case 6:
                      num3 = 2;
                      continue;
                    case 7:
                      num3 = 3;
                      continue;
                    case 9:
                      if (sheetIndexBegin <= subGroup2.SheetIndexEnd)
                      {
                        this.a(sheetSet.UseSheets, sheetIndexBegin);
                        ++sheetIndexBegin;
                        num3 = 8;
                        continue;
                      }
                      num3 = 11;
                      continue;
                    case 11:
                      this.a(sheetSet.UseCWDH, subGroup2.WidthBlocks);
                      this.a(sheetSet.UseCMAP, subGroup2.MapBlocks);
                      num3 = 10;
                      continue;
                    case 12:
                      if (enumerator2.MoveNext())
                      {
                        flag = this.p.TryGetValue(enumerator2.Current, out subGroup1);
                        num3 = 1;
                        continue;
                      }
                      num3 = 6;
                      continue;
                  }
                  num3 = 12;
                }
              }
              finally
              {
                enumerator2.Dispose();
              }
label_13:
              sheetSetList.Add(sheetSet);
              num2 = 0;
              continue;
            default:
              num2 = 2;
              continue;
          }
        }
      }
      finally
      {
        enumerator1.Dispose();
      }
label_51:
      A_0.SetGlyphGroupsBlock((uint) this.s.SheetBytes, (ushort) this.s.CellNum, (ushort) this.s.SheetNum, (ushort) list.Count, sheetSetList, this.r);
    }

    private void d(G2dFont A_0, FontData A_1)
    {
label_2:
      CharWidths charWidths = A_1.DefaultWidth.Value;
      int num1 = A_1.Width.Value;
      int num2 = A_1.Ascent.Value;
      int num3 = A_1.Descent.Value;
      int num4 = NitroFontWriter.a(this.g, A_1.LineHeight.Value);
      int num5 = 0;
      while (true)
      {
        switch (num5)
        {
          case 0:
            if (num4 > (int) sbyte.MaxValue)
            {
              num5 = 2;
              continue;
            }
            goto label_7;
          case 1:
            goto label_7;
          case 2:
            if (1 == 0)
              ;
            ProgressControl.Warning(Strings.IDS_WARN_OVERMAX_LINEFEED, (object) num4, (object) sbyte.MaxValue);
            num5 = 1;
            continue;
          default:
            goto label_2;
        }
      }
label_7:
      A_0.SetInformationBlock((byte) this.l, (byte) num4, (byte) num1, (byte) (num2 + num3), (byte) num2, this.u, (sbyte) NitroFontWriter.a(this.i, (int) charWidths.Left), (byte) NitroFontWriter.a(this.h, (int) charWidths.GlyphWidth), (sbyte) NitroFontWriter.a(this.j, (int) charWidths.CharWidth - ((int) charWidths.Left + (int) charWidths.GlyphWidth)), (byte) this.k);
    }

    private void c(G2dFont A_0, FontData A_1)
    {
label_2:
      int length = this.s.SheetBytes * this.s.SheetNum;
      byte[] numArray = new byte[length];
      this.a(numArray, this.s, A_1);
      int num1 = 3;
      ushort sheetFormat;
      byte[] image;
      int imageSize;
      while (true)
      {
        int num2;
        switch (num1)
        {
          case 0:
            if (1 == 0)
              ;
            byte[] A_0_1 = new byte[this.s.SheetBytes * 2 * this.s.SheetNum];
            uint num3 = this.a(A_0_1, numArray, this.s);
            sheetFormat |= (ushort) short.MinValue;
            image = A_0_1;
            imageSize = (int) num3;
            num1 = 4;
            continue;
          case 1:
            num1 = 6;
            continue;
          case 2:
            if (this.v)
            {
              num1 = 0;
              continue;
            }
            goto label_12;
          case 3:
            num1 = ConverterEnvironment.IsRvl ? 5 : 1;
            continue;
          case 4:
            goto label_12;
          case 5:
            num2 = (int) this.b(A_1.OutputFormat.Value);
            break;
          case 6:
            num2 = (int) this.a(A_1.OutputFormat.Value);
            break;
          default:
            goto label_2;
        }
        sheetFormat = (ushort) num2;
        image = numArray;
        imageSize = length;
        num1 = 2;
      }
label_12:
      A_0.SetTextureGlyphBlock((byte) this.s.CellWidth, (byte) this.s.CellHeight, (sbyte) A_1.BaselinePos.Value, (byte) A_1.MaxCharWidth.Value, (uint) this.s.SheetBytes, (ushort) this.s.SheetNum, sheetFormat, (ushort) this.s.CellHCount, (ushort) this.s.CellVCount, (ushort) this.s.SheetWidth, (ushort) this.s.SheetHeight, image, imageSize);
    }

    private ushort b(GlyphImageFormat A_0)
    {
label_2:
      if (1 == 0)
        ;
      GlyphImageFormat glyphImageFormat = A_0;
      int num = 6;
      NintendoWare.Font.Revolution.TextureFormat textureFormat;
      while (true)
      {
        switch (num)
        {
          case 0:
            num = 5;
            continue;
          case 1:
          case 2:
          case 3:
          case 4:
          case 7:
          case 8:
          case 9:
            goto label_15;
          case 5:
            goto label_12;
          case 6:
            switch (glyphImageFormat)
            {
              case GlyphImageFormat.A4:
                textureFormat = NintendoWare.Font.Revolution.TextureFormat.I4;
                num = 9;
                continue;
              case GlyphImageFormat.A8:
                textureFormat = NintendoWare.Font.Revolution.TextureFormat.I8;
                num = 3;
                continue;
              case GlyphImageFormat.LA4:
                textureFormat = NintendoWare.Font.Revolution.TextureFormat.IA4;
                num = 8;
                continue;
              case GlyphImageFormat.LA8:
                textureFormat = NintendoWare.Font.Revolution.TextureFormat.IA8;
                num = 4;
                continue;
              case GlyphImageFormat.RGB565:
                textureFormat = NintendoWare.Font.Revolution.TextureFormat.RGB565;
                num = 2;
                continue;
              case GlyphImageFormat.RGB5A1:
              case GlyphImageFormat.RGBA4:
              case GlyphImageFormat.RGB8:
                goto label_12;
              case GlyphImageFormat.RGB5A3:
                textureFormat = NintendoWare.Font.Revolution.TextureFormat.RGB5A3;
                num = 1;
                continue;
              case GlyphImageFormat.RGBA8:
                textureFormat = NintendoWare.Font.Revolution.TextureFormat.RGBA8;
                num = 7;
                continue;
              default:
                num = 0;
                continue;
            }
          default:
            goto label_2;
        }
      }
label_12:
      throw new InvalidOperationException("unsupported format. " + (object) A_0);
label_15:
      return (ushort) textureFormat;
    }

    private ushort a(GlyphImageFormat A_0)
    {
label_2:
      GlyphImageFormat glyphImageFormat = A_0;
      int num = 10;
      NintendoWare.Font.Ctr.TextureFormat textureFormat;
      while (true)
      {
        switch (num)
        {
          case 0:
          case 1:
          case 2:
          case 3:
          case 6:
          case 7:
          case 8:
          case 9:
          case 11:
            goto label_17;
          case 4:
            goto label_11;
          case 5:
            num = 4;
            continue;
          case 10:
            switch (glyphImageFormat)
            {
              case GlyphImageFormat.A4:
                textureFormat = NintendoWare.Font.Ctr.TextureFormat.A4;
                num = 11;
                continue;
              case GlyphImageFormat.A8:
                textureFormat = NintendoWare.Font.Ctr.TextureFormat.A8;
                if (1 == 0)
                  ;
                num = 9;
                continue;
              case GlyphImageFormat.LA4:
                textureFormat = NintendoWare.Font.Ctr.TextureFormat.LA4;
                num = 1;
                continue;
              case GlyphImageFormat.LA8:
                textureFormat = NintendoWare.Font.Ctr.TextureFormat.LA8;
                num = 0;
                continue;
              case GlyphImageFormat.RGB565:
                textureFormat = NintendoWare.Font.Ctr.TextureFormat.RGB565;
                num = 8;
                continue;
              case GlyphImageFormat.RGB5A1:
                textureFormat = NintendoWare.Font.Ctr.TextureFormat.RGB5A1;
                num = 7;
                continue;
              case GlyphImageFormat.RGB5A3:
                goto label_11;
              case GlyphImageFormat.RGBA4:
                textureFormat = NintendoWare.Font.Ctr.TextureFormat.RGBA4;
                num = 3;
                continue;
              case GlyphImageFormat.RGB8:
                textureFormat = NintendoWare.Font.Ctr.TextureFormat.RGB8;
                num = 2;
                continue;
              case GlyphImageFormat.RGBA8:
                textureFormat = NintendoWare.Font.Ctr.TextureFormat.RGBA8;
                num = 6;
                continue;
              default:
                num = 5;
                continue;
            }
          default:
            goto label_2;
        }
      }
label_11:
      throw new InvalidOperationException("unsupported format. " + (object) A_0);
label_17:
      return (ushort) textureFormat;
    }

    private void b(G2dFont A_0, FontData A_1)
    {
label_2:
      GlyphList glyphList = A_1.GetGlyphList();
      CharWidths[] data = new CharWidths[this.s.AllSheetCellNum];
      ushort num1 = (ushort) 0;
      ushort num2 = ushort.MaxValue;
      Dictionary<int, NitroFontWriter.SubGroup>.Enumerator enumerator1 = this.p.GetEnumerator();
      int num3 = 3;
      Dictionary<int, NitroFontWriter.SubGroup>.Enumerator enumerator2;
      while (true)
      {
        switch (num3)
        {
          case 0:
            if ((int) num2 <= (int) num1)
            {
              num3 = 2;
              continue;
            }
            goto label_46;
          case 1:
            goto label_46;
          case 2:
            A_0.AddWidthBlock(num2, num1, data);
            num3 = 1;
            continue;
          case 3:
            try
            {
              int num4 = 6;
              while (true)
              {
                KeyValuePair<int, NitroFontWriter.SubGroup> current1;
                List<NitroFontWriter.GlyphCode>.Enumerator enumerator3;
                switch (num4)
                {
                  case 0:
                    try
                    {
                      int num5 = 3;
                      while (true)
                      {
                        ushort gryphIndex;
                        Glyph byCode;
                        switch (num5)
                        {
                          case 1:
                            num5 = 8;
                            continue;
                          case 2:
                            if (enumerator3.MoveNext())
                            {
                              NitroFontWriter.GlyphCode current2 = enumerator3.Current;
                              ushort charCode = current2.CharCode;
                              gryphIndex = current2.GryphIndex;
                              byCode = glyphList.GetByCode(charCode);
                              num5 = 6;
                              continue;
                            }
                            num5 = 7;
                            continue;
                          case 4:
                            goto label_17;
                          case 5:
                            data[(int) gryphIndex] = new CharWidths()
                            {
                              Left = (sbyte) byCode.Left(),
                              GlyphWidth = (byte) byCode.Width(),
                              CharWidth = (sbyte) byCode.CharFeed()
                            };
                            num2 = Math.Min(num2, gryphIndex);
                            num1 = Math.Max(num1, gryphIndex);
                            ProgressControl.GetInstance().StepProgressBar();
                            num5 = 0;
                            continue;
                          case 6:
                            if (byCode != null)
                            {
                              num5 = 1;
                              continue;
                            }
                            break;
                          case 7:
                            num5 = 4;
                            continue;
                          case 8:
                            if ((int) gryphIndex < this.s.AllSheetCellNum)
                            {
                              num5 = 5;
                              continue;
                            }
                            break;
                        }
                        num5 = 2;
                      }
                    }
                    finally
                    {
                      enumerator3.Dispose();
                    }
                  case 1:
                    if (current1.Value != null)
                    {
                      num4 = 4;
                      continue;
                    }
                    break;
                  case 2:
                    goto label_44;
                  case 3:
                    num4 = 2;
                    continue;
                  case 4:
                    enumerator3 = current1.Value.CodeList.GetEnumerator();
                    num4 = 0;
                    continue;
                  case 5:
                    if (!enumerator1.MoveNext())
                    {
                      num4 = 3;
                      continue;
                    }
                    current1 = enumerator1.Current;
                    num4 = 1;
                    continue;
                }
label_17:
                num4 = 5;
              }
            }
            finally
            {
              enumerator1.Dispose();
            }
label_44:
            enumerator2 = this.p.GetEnumerator();
            num3 = 4;
            continue;
          case 4:
            try
            {
              int num4 = 0;
              while (true)
              {
                KeyValuePair<int, NitroFontWriter.SubGroup> current;
                switch (num4)
                {
                  case 1:
                    num4 = 6;
                    continue;
                  case 2:
                    current.Value.WidthBlocks.Add(0);
                    num4 = 4;
                    continue;
                  case 3:
                    if (enumerator2.MoveNext())
                    {
                      current = enumerator2.Current;
                      num4 = 5;
                      continue;
                    }
                    num4 = 1;
                    continue;
                  case 5:
                    if (current.Value != null)
                    {
                      num4 = 2;
                      continue;
                    }
                    break;
                  case 6:
                    goto label_40;
                }
                num4 = 3;
              }
            }
            finally
            {
              enumerator2.Dispose();
            }
label_40:
            num3 = 0;
            continue;
          default:
            goto label_2;
        }
      }
label_46:
      if (1 != 0)
        ;
    }

    private void a(G2dFont A_0, FontData A_1)
    {
      GlyphList glyphList = A_1.GetGlyphList();
      NitroFontWriter.GlyphLinkedList A_2 = new NitroFontWriter.GlyphLinkedList();
      IEnumerator<Glyph> enumerator = glyphList.GetEnum().GetEnumerator();
      try
      {
        int num = 1;
        while (true)
        {
          switch (num)
          {
            case 0:
              goto label_14;
            case 2:
              num = 0;
              continue;
            case 4:
              if (enumerator.MoveNext())
              {
                Glyph current = enumerator.Current;
                A_2.AddLast(current);
                num = 3;
                continue;
              }
              num = 2;
              continue;
            default:
              num = 4;
              continue;
          }
        }
      }
      finally
      {
        int num = 1;
        while (true)
        {
          switch (num)
          {
            case 0:
              goto label_13;
            case 2:
              enumerator.Dispose();
              num = 0;
              continue;
            default:
              if (enumerator != null)
              {
                num = 2;
                continue;
              }
              goto label_13;
          }
        }
label_13:;
      }
label_14:
      if (1 == 0)
        ;
      this.c(A_0, (NitroFontWriter.SubGroup) null, A_2, A_1);
      this.b(A_0, (NitroFontWriter.SubGroup) null, A_2, A_1);
      this.a(A_0, (NitroFontWriter.SubGroup) null, A_2, A_1);
    }

    private void c(G2dFont A_0, NitroFontWriter.SubGroup A_1, NitroFontWriter.GlyphLinkedList A_2, FontData A_3)
    {
label_2:
      NitroFontWriter.Range A_0_1 = new NitroFontWriter.Range();
      LinkedListNode<Glyph> A_2_1 = A_2.First;
      int num = 4;
      while (true)
      {
        bool flag;
        switch (num)
        {
          case 0:
            num = 9;
            continue;
          case 1:
            if (flag)
            {
              A_2_1 = A_0_1.Last.Next;
              num = 6;
              continue;
            }
            num = 5;
            continue;
          case 2:
            ushort index = A_0_1.First.Value.GetIndex();
            A_0.AddCMapBlock(A_0_1.First.Value.GetCode(), A_0_1.Last.Value.GetCode(), FontMapMethod.Direct, new ushort[1]
            {
              index
            });
            ProgressControl.GetInstance().StepProgressBar((int) A_0_1.Last.Value.GetIndex() - (int) A_0_1.First.Value.GetIndex());
            A_2.Erase(A_0_1.First, A_0_1.Last);
            num = 7;
            continue;
          case 3:
            if (A_2_1 != null)
            {
              if (1 == 0)
                ;
              num = 0;
              continue;
            }
            goto label_17;
          case 4:
          case 7:
            num = 3;
            continue;
          case 5:
            goto label_19;
          case 6:
            if ((int) A_0_1.Last.Value.GetCode() - (int) A_0_1.First.Value.GetCode() + 1 >= 80)
            {
              num = 2;
              continue;
            }
            break;
          case 8:
            goto label_16;
          case 9:
            if (A_2_1 == A_2.Last.Next)
            {
              num = 8;
              continue;
            }
            break;
          default:
            goto label_2;
        }
        flag = this.b(ref A_0_1, A_2.Last, A_2_1);
        num = 1;
      }
label_16:
      return;
label_19:
      return;
label_17:;
    }

    private void b(G2dFont A_0, NitroFontWriter.SubGroup A_1, NitroFontWriter.GlyphLinkedList A_2, FontData A_3)
    {
label_2:
      NitroFontWriter.Range A_0_1 = new NitroFontWriter.Range();
      LinkedListNode<Glyph> A_2_1 = A_2.First;
      int num1 = 0;
      while (true)
      {
        NitroFontWriter.Range A_0_2;
        bool flag1;
        int num2;
        int num3;
        NitroFontWriter.Range A_0_3;
        float num4;
        float num5;
        Glyph byCode;
        ushort code1;
        int index;
        int length;
        ushort code2;
        ushort[] data;
        bool flag2;
        int num6;
        switch (num1)
        {
          case 0:
          case 27:
          case 28:
            num1 = 16;
            continue;
          case 1:
            num1 = byCode != null ? 7 : 18;
            continue;
          case 2:
          case 6:
          case 29:
            A_0_3 = new NitroFontWriter.Range();
            A_0_2 = new NitroFontWriter.Range();
            num4 = 0.0f;
            num5 = 0.0f;
            num1 = 14;
            continue;
          case 3:
            A_2_1 = A_0_1.Last.Next;
            num1 = 27;
            continue;
          case 4:
            A_0.AddCMapBlock(code1, code2, FontMapMethod.Table, data);
            A_2_1 = A_0_1.Last.Next;
            ProgressControl.GetInstance().StepProgressBar((int) A_0_1.Last.Value.GetIndex() - (int) A_0_1.First.Value.GetIndex());
            A_2.Erase(A_0_1.First, A_0_1.Last);
            num1 = 28;
            continue;
          case 5:
            LinkedListNode<Glyph> previous = A_0_1.First.Previous;
            flag1 = this.a(ref A_0_2, A_2.First, previous);
            num1 = 37;
            continue;
          case 7:
            num6 = (int) byCode.GetIndex();
            goto label_47;
          case 8:
            num1 = 31;
            continue;
          case 9:
            int num7 = (int) A_0_2.Last.Value.GetCode() - (int) A_0_2.First.Value.GetCode() + 1;
            int num8 = (int) A_0_1.First.Value.GetCode() - (int) A_0_2.Last.Value.GetCode() - 1;
            num2 += num7;
            num3 += num8;
            A_0_1.First = A_0_2.First;
            num1 = 2;
            continue;
          case 10:
            LinkedListNode<Glyph> next = A_0_1.Last.Next;
            flag2 = this.b(ref A_0_3, A_2.Last, next);
            num1 = 22;
            continue;
          case 11:
          case 33:
            num1 = 12;
            continue;
          case 12:
            if (index < length)
            {
              byCode = A_3.GetGlyphList().GetByCode((ushort) ((uint) code1 + (uint) index));
              num1 = 1;
              continue;
            }
            num1 = 4;
            continue;
          case 13:
            num1 = (double) num4 <= (double) num5 ? 23 : 19;
            continue;
          case 14:
            if (A_0_1.Last != A_2.Last.Next)
            {
              num1 = 10;
              continue;
            }
            goto case 8;
          case 15:
            if (A_0_1.First != A_2.Last.Next)
            {
              num2 = (int) A_0_1.Last.Value.GetCode() - (int) A_0_1.First.Value.GetCode() + 1;
              num3 = 0;
              num1 = 6;
              continue;
            }
            num1 = 21;
            continue;
          case 16:
            if (A_2_1 != null)
            {
              num1 = 25;
              continue;
            }
            goto label_35;
          case 17:
            if ((double) num4 >= 0.5)
            {
              num1 = 20;
              continue;
            }
            break;
          case 18:
            num1 = 34;
            continue;
          case 19:
            num1 = 17;
            continue;
          case 20:
            int num9 = (int) A_0_3.Last.Value.GetCode() - (int) A_0_3.First.Value.GetCode() + 1;
            int num10 = (int) A_0_3.First.Value.GetCode() - (int) A_0_1.Last.Value.GetCode() - 1;
            num2 += num9;
            num3 += num10;
            A_0_1.Last = A_0_3.Last;
            num1 = 29;
            continue;
          case 21:
            goto label_54;
          case 22:
            if (flag2)
            {
              num1 = 35;
              continue;
            }
            goto case 8;
          case 23:
            if ((double) num5 >= 0.5)
            {
              num1 = 9;
              continue;
            }
            break;
          case 24:
            if (A_2_1 != A_2.Last.Next)
            {
              this.b(ref A_0_1, A_2.Last, A_2_1);
              num1 = 15;
              continue;
            }
            num1 = 30;
            continue;
          case 25:
            num1 = 24;
            continue;
          case 26:
            int num11 = (int) A_0_2.Last.Value.GetCode() - (int) A_0_2.First.Value.GetCode() + 1;
            int num12 = (int) A_0_1.First.Value.GetCode() - (int) A_0_2.Last.Value.GetCode() - 1;
            int num13 = num2 + num11;
            int num14 = num13 + num3 + num12;
            num5 = (float) num13 / (float) num14;
            num1 = 36;
            continue;
          case 30:
            goto label_51;
          case 31:
            if (A_0_1.First != A_2.First)
            {
              num1 = 5;
              continue;
            }
            goto case 36;
          case 32:
            if (num2 < 40)
            {
              num1 = 3;
              continue;
            }
            code1 = A_0_1.First.Value.GetCode();
            code2 = A_0_1.Last.Value.GetCode();
            length = (int) code2 - (int) code1 + 1;
            data = new ushort[length];
            index = 0;
            num1 = 11;
            continue;
          case 34:
            num6 = (int) ushort.MaxValue;
            goto label_47;
          case 35:
            if (1 == 0)
              ;
            int num15 = (int) A_0_3.Last.Value.GetCode() - (int) A_0_3.First.Value.GetCode() + 1;
            int num16 = (int) A_0_3.First.Value.GetCode() - (int) A_0_1.Last.Value.GetCode() - 1;
            int num17 = num2 + num15;
            int num18 = num17 + num3 + num16;
            num4 = (float) num17 / (float) num18;
            num1 = 8;
            continue;
          case 36:
            num1 = 13;
            continue;
          case 37:
            if (flag1)
            {
              num1 = 26;
              continue;
            }
            goto case 36;
          default:
            goto label_2;
        }
        num1 = 32;
        continue;
label_47:
        ushort num19 = (ushort) num6;
        data[index] = num19;
        ++index;
        num1 = 33;
      }
label_51:
      return;
label_54:
      return;
label_35:;
    }

    private bool b(ref NitroFontWriter.Range A_0, LinkedListNode<Glyph> A_1, LinkedListNode<Glyph> A_2)
    {
      int num1 = 8;
      LinkedListNode<Glyph> next;
      ushort num2;
      ushort num3;
      LinkedListNode<Glyph> linkedListNode;
      while (true)
      {
        switch (num1)
        {
          case 0:
            num1 = 11;
            continue;
          case 1:
            if ((int) next.Value.GetIndex() == (int) num2)
            {
              num1 = 10;
              continue;
            }
            goto label_18;
          case 2:
          case 4:
            num1 = 3;
            continue;
          case 3:
            num1 = next != A_1.Next ? 7 : 5;
            continue;
          case 5:
            goto label_18;
          case 6:
            num1 = 1;
            continue;
          case 7:
            if ((int) next.Value.GetCode() == (int) num3)
            {
              num1 = 6;
              continue;
            }
            goto label_18;
          case 9:
            goto label_9;
          case 10:
            linkedListNode = next;
            next = linkedListNode.Next;
            ++num3;
            ++num2;
            if (1 == 0)
              ;
            num1 = 2;
            continue;
          case 11:
            if (A_2 == A_1.Next)
            {
              num1 = 9;
              continue;
            }
            num3 = (ushort) ((uint) A_2.Value.GetCode() + 1U);
            num2 = (ushort) ((uint) A_2.Value.GetIndex() + 1U);
            linkedListNode = A_2;
            next = linkedListNode.Next;
            num1 = 4;
            continue;
          default:
            if (A_2 != null)
            {
              num1 = 0;
              continue;
            }
            goto label_9;
        }
      }
label_9:
      return false;
label_18:
      A_0.First = A_2;
      A_0.Last = linkedListNode;
      return true;
    }

    private bool a(ref NitroFontWriter.Range A_0, LinkedListNode<Glyph> A_1, LinkedListNode<Glyph> A_2)
    {
      int num1 = 2;
      LinkedListNode<Glyph> previous1;
      ushort num2;
      LinkedListNode<Glyph> previous2;
      while (true)
      {
        switch (num1)
        {
          case 0:
            if ((int) previous1.Value.GetCode() == (int) num2)
            {
              num1 = 4;
              continue;
            }
            goto label_19;
          case 1:
            goto label_15;
          case 3:
            if (A_2 == A_1)
            {
              num1 = 8;
              continue;
            }
            previous2 = A_2.Previous;
            num1 = 9;
            continue;
          case 4:
            previous1 = previous1.Previous;
            --num2;
            num1 = 10;
            continue;
          case 5:
            num1 = previous1 != A_1 ? 0 : 6;
            continue;
          case 6:
            goto label_19;
          case 7:
            num1 = 3;
            continue;
          case 8:
            goto label_8;
          case 9:
            if (previous2 != A_1)
            {
              num2 = (ushort) ((uint) previous2.Value.GetCode() - 1U);
              previous1 = previous2.Previous;
              num1 = 11;
              continue;
            }
            num1 = 1;
            continue;
          case 10:
          case 11:
            num1 = 5;
            continue;
          default:
            if (A_2 != null)
            {
              if (1 == 0)
                ;
              num1 = 7;
              continue;
            }
            goto label_8;
        }
      }
label_8:
      return false;
label_15:
      return false;
label_19:
      A_0.First = previous1.Next;
      A_0.Last = previous2;
      return true;
    }

    private void a(G2dFont A_0, NitroFontWriter.SubGroup A_1, NitroFontWriter.GlyphLinkedList A_2, FontData A_3)
    {
      if (1 == 0)
        ;
label_2:
      int count = A_2.Count;
      ushort num1 = (ushort) 0;
      List<CMapScanEntry> list = new List<CMapScanEntry>(count);
      LinkedList<Glyph>.Enumerator enumerator = A_2.GetEnumerator();
      int num2 = 1;
      while (true)
      {
        switch (num2)
        {
          case 0:
            if ((int) num1 <= 0)
            {
              num2 = 2;
              continue;
            }
            goto label_15;
          case 1:
            try
            {
              int num3 = 3;
              while (true)
              {
                switch (num3)
                {
                  case 0:
                    goto label_3;
                  case 1:
                    num3 = 0;
                    continue;
                  case 2:
                    if (enumerator.MoveNext())
                    {
                      Glyph current = enumerator.Current;
                      CMapScanEntry cmapScanEntry;
                      cmapScanEntry.Code = current.GetCode();
                      cmapScanEntry.Index = current.GetIndex();
                      list.Add(cmapScanEntry);
                      ++num1;
                      ProgressControl.GetInstance().StepProgressBar();
                      num3 = 4;
                      continue;
                    }
                    num3 = 1;
                    continue;
                  default:
                    num3 = 2;
                    continue;
                }
              }
            }
            finally
            {
              enumerator.Dispose();
            }
label_3:
            num2 = 0;
            continue;
          case 2:
            goto label_13;
          default:
            goto label_2;
        }
      }
label_13:
      return;
label_15:
      A_0.AddCMapBlock((ushort) 0, ushort.MaxValue, FontMapMethod.Scan, list.ToArray());
    }

    private void a(NitroFontWriter.TGLPInfo A_0, FontData A_1)
    {
label_2:
      A_0.SheetBpp = GlyphImageInfo.GetGlyphImageInfo(A_1.OutputFormat.Value).Bpp;
      A_0.AllSheetCellNum = A_1.GetGlyphList().GetNum();
      A_0.CellWidth = A_1.CellWidth.Value;
      A_0.CellHeight = A_1.CellHeight.Value;
      int num = 5;
      while (true)
      {
        switch (num)
        {
          case 0:
          case 2:
            goto label_11;
          case 1:
            num = 4;
            continue;
          case 3:
            this.a(A_0, this.o);
            if (1 == 0)
              ;
            num = 2;
            continue;
          case 4:
            if (this.n != 0)
            {
              A_0.SheetWidth = this.m;
              A_0.SheetHeight = this.n;
              num = 0;
              continue;
            }
            num = 3;
            continue;
          case 5:
            if (this.m != 0)
            {
              num = 1;
              continue;
            }
            goto case 3;
          default:
            goto label_2;
        }
      }
label_11:
      A_0.CellHCount = A_0.SheetWidth / (A_0.CellWidth + 1);
      A_0.CellVCount = A_0.SheetHeight / (A_0.CellHeight + 1);
      A_0.CellNum = A_0.CellHCount * A_0.CellVCount;
      A_0.SheetNum = GlCm.DIV_UP(A_0.AllSheetCellNum, A_0.CellNum);
      A_0.SheetBytes = GlCm.DIV_UP(A_0.SheetWidth * A_0.SheetHeight * A_0.SheetBpp, 8);
    }

    private void a(NitroFontWriter.TGLPInfo A_0, int A_1)
    {
label_2:
      int num1 = (A_0.CellWidth + 1) * (A_0.CellHeight + 1) * A_0.AllSheetCellNum;
      int num2 = int.MaxValue;
      int num3 = 32;
      int num4 = 7;
      int num5;
      int num6;
      int num7;
      int num8;
      while (true)
      {
        switch (num4)
        {
          case 0:
            if (1 == 0)
              ;
            num4 = 19;
            continue;
          case 1:
            num2 = num5;
            A_0.SheetWidth = num3;
            A_0.SheetHeight = num6;
            num4 = 8;
            continue;
          case 2:
            if (A_1 != 0)
            {
              num4 = 0;
              continue;
            }
            goto case 10;
          case 3:
            int divider = (num7 + 1) / (A_0.CellWidth + 1) * ((num8 + 1) / (A_0.CellHeight + 1));
            int num9 = GlCm.DIV_UP(A_0.AllSheetCellNum, divider);
            num5 = num7 * num8 * num9 - num1;
            num4 = 5;
            continue;
          case 4:
            num6 = 32;
            num4 = 11;
            continue;
          case 5:
            if (num5 < num2)
            {
              num4 = 1;
              continue;
            }
            goto case 8;
          case 6:
            if (num3 > 1024)
            {
              num4 = 20;
              continue;
            }
            num7 = num3 - 2;
            num4 = 13;
            continue;
          case 7:
          case 14:
            num4 = 6;
            continue;
          case 8:
            num6 *= 2;
            num4 = 9;
            continue;
          case 9:
          case 11:
            num4 = 16;
            continue;
          case 10:
            num8 = num6 - 2;
            num4 = 18;
            continue;
          case 12:
            num3 *= 2;
            num4 = 14;
            continue;
          case 13:
            if (num7 >= A_0.CellWidth)
            {
              num4 = 4;
              continue;
            }
            goto case 12;
          case 15:
            if (num2 == int.MaxValue)
            {
              num4 = 17;
              continue;
            }
            goto label_31;
          case 16:
            num4 = num6 <= 1024 ? 2 : 12;
            continue;
          case 17:
            goto label_14;
          case 18:
            if (num8 >= A_0.CellHeight)
            {
              num4 = 3;
              continue;
            }
            goto case 8;
          case 19:
            if (num3 * num6 == A_1)
            {
              num4 = 10;
              continue;
            }
            goto case 8;
          case 20:
            num4 = 15;
            continue;
          default:
            goto label_2;
        }
      }
label_31:
      return;
label_14:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_INVALID_SHEETPIXELS, (object) A_1);
    }

    private void a(byte[] A_0, NitroFontWriter.TGLPInfo A_1, FontData A_2)
    {
      if (1 == 0)
        ;
      RgbImage rgbImage = new RgbImage();
      this.a(rgbImage, A_1, A_2);
      this.a(A_0, rgbImage, A_2.OutputFormat.Value, A_1);
    }

    private void a(RgbImage A_0, NitroFontWriter.TGLPInfo A_1, FontData A_2)
    {
      GlyphList glyphList = A_2.GetGlyphList();
      RgbImage image = new RgbImage();
      A_0.Create(A_1.SheetWidth, A_1.SheetHeight * A_1.SheetNum, 32);
      A_0.Clear((uint) A_2.NullColor.Value, (byte) 0);
      A_0.EnableAlpha();
      int num1 = A_1.CellWidth + 1;
      int num2 = A_1.CellHeight + 1;
      Dictionary<int, NitroFontWriter.SubGroup>.Enumerator enumerator1 = this.p.GetEnumerator();
      try
      {
        int num3 = 1;
        while (true)
        {
          KeyValuePair<int, NitroFontWriter.SubGroup> current1;
          List<NitroFontWriter.GlyphCode>.Enumerator enumerator2;
          switch (num3)
          {
            case 0:
              num3 = 6;
              continue;
            case 2:
              if (current1.Value != null)
              {
                num3 = 4;
                continue;
              }
              break;
            case 3:
              try
              {
                int num4 = 3;
                while (true)
                {
                  ushort gryphIndex;
                  int x;
                  int num5;
                  int y;
                  Glyph byCode;
                  switch (num4)
                  {
                    case 1:
                      goto label_4;
                    case 2:
                      if (enumerator2.MoveNext())
                      {
                        NitroFontWriter.GlyphCode current2 = enumerator2.Current;
                        ushort charCode = current2.CharCode;
                        gryphIndex = current2.GryphIndex;
                        num5 = (int) gryphIndex / A_1.CellHCount;
                        byCode = glyphList.GetByCode(charCode);
                        num4 = 10;
                        continue;
                      }
                      num4 = 9;
                      continue;
                    case 4:
                      if (num5 < this.s.AllSheetCellNum)
                      {
                        num4 = 6;
                        continue;
                      }
                      break;
                    case 5:
                      if (byCode != null)
                      {
                        num4 = 7;
                        continue;
                      }
                      break;
                    case 6:
                      x = (int) gryphIndex % A_1.CellHCount * num1 + 1;
                      y = num5 / A_1.CellVCount * A_1.SheetHeight + num5 % A_1.CellVCount * num2 + 1;
                      num4 = 5;
                      continue;
                    case 7:
                      byCode.ExtractGlyphImage(image, A_2.BaselinePos.Value);
                      A_0.Paste((ImageBase) image, x, y);
                      num4 = 0;
                      continue;
                    case 8:
                      num4 = 4;
                      continue;
                    case 9:
                      num4 = 1;
                      continue;
                    case 10:
                      if (byCode != null)
                      {
                        num4 = 8;
                        continue;
                      }
                      break;
                  }
                  num4 = 2;
                }
              }
              finally
              {
                enumerator2.Dispose();
              }
            case 4:
              enumerator2 = current1.Value.CodeList.GetEnumerator();
              num3 = 3;
              continue;
            case 5:
              if (!enumerator1.MoveNext())
              {
                num3 = 0;
                continue;
              }
              current1 = enumerator1.Current;
              num3 = 2;
              continue;
            case 6:
              goto label_28;
          }
label_4:
          num3 = 5;
        }
label_28:;
      }
      finally
      {
        if (1 == 0)
          ;
        enumerator1.Dispose();
      }
    }

    private void a(byte[] A_0, RgbImage A_1, GlyphImageFormat A_2, NitroFontWriter.TGLPInfo A_3)
    {
label_2:
      int bpp = GlyphImageInfo.GetGlyphImageInfo(A_2).Bpp;
      GlyphImageFormat glyphImageFormat = A_2;
      int num = 5;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_6;
          case 1:
            goto label_23;
          case 2:
            if (ConverterEnvironment.IsRvl)
            {
              num = 1;
              continue;
            }
            goto label_29;
          case 3:
            if (ConverterEnvironment.IsRvl)
            {
              if (1 == 0)
                ;
              num = 9;
              continue;
            }
            goto label_32;
          case 4:
            if (ConverterEnvironment.IsRvl)
            {
              num = 0;
              continue;
            }
            goto label_31;
          case 5:
            switch (glyphImageFormat)
            {
              case GlyphImageFormat.A4:
                num = 8;
                continue;
              case GlyphImageFormat.A8:
                goto label_20;
              case GlyphImageFormat.LA4:
                num = 2;
                continue;
              case GlyphImageFormat.LA8:
                num = 4;
                continue;
              case GlyphImageFormat.RGB565:
                goto label_12;
              case GlyphImageFormat.RGB5A1:
                goto label_5;
              case GlyphImageFormat.RGB5A3:
                goto label_30;
              case GlyphImageFormat.RGBA4:
                goto label_21;
              case GlyphImageFormat.RGB8:
                goto label_8;
              case GlyphImageFormat.RGBA8:
                num = 3;
                continue;
              default:
                num = 6;
                continue;
            }
          case 6:
            goto label_28;
          case 7:
            goto label_24;
          case 8:
            if (ConverterEnvironment.IsRvl)
            {
              num = 7;
              continue;
            }
            goto label_7;
          case 9:
            goto label_22;
          default:
            goto label_2;
        }
      }
label_28:
      return;
label_5:
      this.a(A_1, bpp, new NitroFontWriter.PixelWriter(new NitroFontWriter.Writer(A_0).WritePixelRGB5A1));
      return;
label_6:
      this.a(A_1, bpp, new NitroFontWriter.PixelWriter(new NitroFontWriter.Writer(A_0).WritePixelAL8));
      return;
label_7:
      this.a(A_1, bpp, new NitroFontWriter.PixelWriter(new NitroFontWriter.A4Writer(A_0).WritePixelA4_LH));
      return;
label_8:
      this.a(A_1, bpp, new NitroFontWriter.PixelWriter(new NitroFontWriter.Writer(A_0).WritePixelRGB8));
      return;
label_12:
      this.a(A_1, bpp, new NitroFontWriter.PixelWriter(new NitroFontWriter.Writer(A_0).WritePixelRGB565));
      return;
label_20:
      this.a(A_1, bpp, new NitroFontWriter.PixelWriter(new NitroFontWriter.Writer(A_0).WritePixelA8));
      return;
label_21:
      this.a(A_1, bpp, new NitroFontWriter.PixelWriter(new NitroFontWriter.Writer(A_0).WritePixelRGBA4));
      return;
label_22:
      this.a(A_0, A_1);
      return;
label_23:
      this.a(A_1, bpp, new NitroFontWriter.PixelWriter(new NitroFontWriter.Writer(A_0).WritePixelAL4));
      return;
label_24:
      this.a(A_1, bpp, new NitroFontWriter.PixelWriter(new NitroFontWriter.A4Writer(A_0).WritePixelA4_HL));
      return;
label_29:
      this.a(A_1, bpp, new NitroFontWriter.PixelWriter(new NitroFontWriter.Writer(A_0).WritePixelLA4));
      return;
label_30:
      this.a(A_1, bpp, new NitroFontWriter.PixelWriter(new NitroFontWriter.Writer(A_0).WritePixelA3RGB5));
      return;
label_31:
      this.a(A_1, bpp, new NitroFontWriter.PixelWriter(new NitroFontWriter.Writer(A_0).WritePixelLA8));
      return;
label_32:
      this.a(A_1, bpp, new NitroFontWriter.PixelWriter(new NitroFontWriter.Writer(A_0).WritePixelRGBA8));
    }

    private void a(RgbImage A_0, int A_1, NitroFontWriter.PixelWriter A_2)
    {
      if (1 == 0)
        ;
label_2:
      IPixelPicker pixelPicker = PixelPickerCreater.Create(A_0, A_1);
      int num1 = A_0.Width * A_0.Height;
      int pos = 0;
      int num2 = 2;
      while (true)
      {
        switch (num2)
        {
          case 0:
            goto label_7;
          case 1:
          case 2:
            num2 = 3;
            continue;
          case 3:
            if (pos >= num1)
            {
              num2 = 0;
              continue;
            }
            PixelPos pixel = pixelPicker.GetPixel(pos);
            A_2(A_0.GetPixel(pixel.X, pixel.Y));
            ++pos;
            num2 = 1;
            continue;
          default:
            goto label_2;
        }
      }
label_7:;
    }

    private void a(byte[] A_0, RgbImage A_1)
    {
label_2:
      int bpp = 32;
      IPixelPicker pixelPicker = PixelPickerCreater.Create(A_1, bpp);
      ByteOrderBinaryWriter orderBinaryWriter1 = new ByteOrderBinaryWriter((Stream) new MemoryStream(A_0), true);
      byte[] buffer = new byte[pixelPicker.BlockPixelNum * 2];
      int num1 = 0;
      int num2 = 4;
      int num3;
      ByteOrderBinaryWriter orderBinaryWriter2;
      int pos;
      while (true)
      {
        switch (num2)
        {
          case 0:
            if (num3 >= A_1.Width)
            {
              num2 = 8;
              continue;
            }
            orderBinaryWriter2 = new ByteOrderBinaryWriter((Stream) new MemoryStream(buffer), true);
            pos = 0;
            num2 = 1;
            continue;
          case 1:
          case 9:
            num2 = 5;
            continue;
          case 2:
          case 4:
            num2 = 7;
            continue;
          case 3:
          case 11:
            num2 = 0;
            continue;
          case 5:
            if (pos >= pixelPicker.BlockPixelNum)
            {
              num2 = 6;
              continue;
            }
            PixelPos pixel1 = pixelPicker.GetPixel(pos);
            ImageBase.Pixel pixel2 = A_1.GetPixel(num3 + pixel1.X, num1 + pixel1.Y);
            orderBinaryWriter1.Write((ushort) ((uint) pixel2.A << 8 | (uint) pixel2.R));
            orderBinaryWriter2.Write((ushort) ((uint) pixel2.G << 8 | (uint) pixel2.B));
            ++pos;
            num2 = 9;
            continue;
          case 6:
            orderBinaryWriter1.Write(buffer, 0, buffer.Length);
            num3 += pixelPicker.BlockW;
            if (1 == 0)
              ;
            num2 = 3;
            continue;
          case 7:
            if (num1 >= A_1.Height)
            {
              num2 = 10;
              continue;
            }
            num3 = 0;
            num2 = 11;
            continue;
          case 8:
            num1 += pixelPicker.BlockH;
            num2 = 2;
            continue;
          case 10:
            goto label_18;
          default:
            goto label_2;
        }
      }
label_18:;
    }

    private uint a(byte[] A_0, byte[] A_1, NitroFontWriter.TGLPInfo A_2)
    {
label_2:
      ByteOrderBinaryWriter orderBinaryWriter = new ByteOrderBinaryWriter((Stream) new MemoryStream(A_0), true);
      int offset = 0;
      int srcOffs = 0;
      this.r.Clear();
      int num1 = 0;
      int num2 = 1;
      while (true)
      {
        switch (num2)
        {
          case 0:
            if (1 == 0)
              goto case 1;
            else
              goto case 1;
          case 1:
            num2 = 2;
            continue;
          case 2:
            if (num1 >= A_2.SheetNum)
            {
              num2 = 3;
              continue;
            }
            orderBinaryWriter.Seek(offset, SeekOrigin.Begin);
            int dstOffs = offset + 4;
            int num3 = GlCm.ROUND_UP(Util.nitroCompress(A_1, srcOffs, A_2.SheetBytes, A_0, dstOffs, "h8", (byte) 0), 4);
            orderBinaryWriter.Write(num3);
            offset = dstOffs + num3;
            srcOffs += A_2.SheetBytes;
            this.r.Add(num3);
            ++num1;
            num2 = 0;
            continue;
          case 3:
            goto label_8;
          default:
            goto label_2;
        }
      }
label_8:
      return (uint) offset;
    }

    private void a(G2dFont A_0)
    {
label_2:
      if (1 == 0)
        ;
      bool flag = A_0.GetBlock(RtConsts.BinBlockSigGLGR) != null;
      int num1 = 1;
      BinaryFile binaryFile;
      Signature32 sig;
      while (true)
      {
        Signature32 signature32;
        switch (num1)
        {
          case 0:
            signature32 = RtConsts.BinFileSigFONT;
            break;
          case 1:
            num1 = flag ? 2 : 4;
            continue;
          case 2:
            signature32 = RtConsts.BinFileSigFONTA;
            break;
          case 3:
            goto label_5;
          case 4:
            num1 = 0;
            continue;
          default:
            goto label_2;
        }
        sig = signature32;
        binaryFile = BinaryFile.Open(this.d, FileMode.Create, FileAccess.Write);
        num1 = 3;
      }
label_5:
      try
      {
label_7:
        NnsWriter nnsWriter = new NnsWriter(binaryFile);
        nnsWriter.WriteNnsBegin(sig, RtConsts.FontFileVersion);
        nnsWriter.WriteNnsBlock((NnsData) A_0, RtConsts.BinBlockSigGLGR);
        nnsWriter.WriteNnsBlock((NnsData) A_0, RtConsts.BinBlockSigFINF);
        NnsData.GeneralBinaryBlockInfo block1 = A_0.GetBlock(RtConsts.BinBlockSigCGLP);
        NnsData.GeneralBinaryBlockInfo block2 = A_0.GetBlock(RtConsts.BinBlockSigTGLP);
        int num2 = 2;
        int no;
        while (true)
        {
          switch (num2)
          {
            case 0:
            case 6:
              num2 = 9;
              continue;
            case 1:
              goto label_34;
            case 2:
              num2 = block2 == null ? 10 : 11;
              continue;
            case 3:
            case 8:
              no = 0;
              num2 = 13;
              continue;
            case 4:
              no = 0;
              num2 = 0;
              continue;
            case 5:
              if (nnsWriter.WriteNnsBlock((NnsData) A_0, RtConsts.BinBlockSigCWDH, no))
              {
                ++no;
                num2 = 7;
                continue;
              }
              num2 = 4;
              continue;
            case 7:
            case 13:
              num2 = 5;
              continue;
            case 9:
              if (!nnsWriter.WriteNnsBlock((NnsData) A_0, RtConsts.BinBlockSigCMAP, no))
              {
                num2 = 14;
                continue;
              }
              ++no;
              num2 = 6;
              continue;
            case 10:
              if (block1 != null)
              {
                num2 = 12;
                continue;
              }
              goto case 3;
            case 11:
              nnsWriter.WriteNnsBlock((NnsData) A_0, RtConsts.BinBlockSigTGLP);
              num2 = 3;
              continue;
            case 12:
              nnsWriter.WriteNnsBlock((NnsData) A_0, RtConsts.BinBlockSigCGLP);
              num2 = 8;
              continue;
            case 14:
              nnsWriter.WriteNnsEnd();
              num2 = 1;
              continue;
            default:
              goto label_7;
          }
        }
label_34:;
      }
      finally
      {
        int num2 = 1;
        while (true)
        {
          switch (num2)
          {
            case 0:
              binaryFile.Dispose();
              num2 = 2;
              continue;
            case 2:
              goto label_29;
            default:
              if (binaryFile != null)
              {
                num2 = 0;
                continue;
              }
              goto label_29;
          }
        }
label_29:;
      }
    }

    private delegate void PixelWriter(ImageBase.Pixel pixel);

    public struct GlyphCode : IEquatable<NitroFontWriter.GlyphCode>, IComparable<NitroFontWriter.GlyphCode>
    {
      private readonly ushort a;
      private ushort b;

      public ushort CharCode
      {
        get
        {
          return this.b;
        }
      }

      public ushort GryphIndex
      {
        get
        {
          return this.a;
        }
      }

      public GlyphCode(ushort charCode, ushort gryphIndex)
      {
        this.b = charCode;
        this.a = gryphIndex;
      }

      public static bool operator ==(NitroFontWriter.GlyphCode lhs, NitroFontWriter.GlyphCode rhs)
      {
        return lhs.Equals(rhs);
      }

      public static bool operator !=(NitroFontWriter.GlyphCode lhs, NitroFontWriter.GlyphCode rhs)
      {
        return !lhs.Equals(rhs);
      }

      public bool Equals(NitroFontWriter.GlyphCode rhs)
      {
        if ((int) this.b != (int) rhs.b)
          return false;
        if (1 == 0)
          ;
        return (int) this.a == (int) rhs.a;
      }

      public override bool Equals(object obj)
      {
        if (obj is NitroFontWriter.GlyphCode)
          return this.Equals((NitroFontWriter.GlyphCode) obj);
        return false;
      }

      public override int GetHashCode()
      {
        return (int) this.b << 16 | (int) this.a;
      }

      public int CompareTo(NitroFontWriter.GlyphCode other)
      {
        return (int) this.b - (int) other.b;
      }
    }

    private struct Range
    {
      public LinkedListNode<Glyph> First { get; set; }

      public LinkedListNode<Glyph> Last { get; set; }
    }

    public class IndexList : List<int>
    {
    }

    public class CodeList : List<NitroFontWriter.GlyphCode>
    {
    }

    public class SubGroup
    {
      private NitroFontWriter.CodeList a = new NitroFontWriter.CodeList();
      private NitroFontWriter.IndexList b = new NitroFontWriter.IndexList();
      private NitroFontWriter.IndexList c = new NitroFontWriter.IndexList();

      public NitroFontWriter.CodeList CodeList
      {
        get
        {
          return this.a;
        }
      }

      public NitroFontWriter.IndexList WidthBlocks
      {
        get
        {
          return this.b;
        }
      }

      public NitroFontWriter.IndexList MapBlocks
      {
        get
        {
          return this.c;
        }
      }

      public int Index { get; set; }

      public int SheetIndexBegin { get; set; }

      public int SheetIndexBeginOffset { get; set; }

      public int SheetIndexEnd { get; set; }
    }

    public sealed class Group : IComparable<NitroFontWriter.Group>
    {
      public readonly NitroFontWriter.IndexList SubGroups = new NitroFontWriter.IndexList();
      public readonly int Index;
      public readonly string Name;

      public Group(int index, string name)
      {
        this.Index = index;
        this.Name = name;
      }

      public int CompareTo(NitroFontWriter.Group other)
      {
        return this.Index - other.Index;
      }
    }

    public class SubGroupMap : Dictionary<int, NitroFontWriter.SubGroup>
    {
      public void Add(NitroFontWriter.SubGroup sg)
      {
        sg.Index = this.Count;
        this.Add(sg.Index, sg);
      }

      public void Remove(int no)
      {
        if (!this.ContainsKey(no))
          return;
        this[no] = (NitroFontWriter.SubGroup) null;
      }
    }

    public class GroupMap : Dictionary<string, NitroFontWriter.Group>
    {
    }

    public class SheetSurplus : IComparable<NitroFontWriter.SheetSurplus>
    {
      public NitroFontWriter.SubGroup Sub { get; private set; }

      public int NumGlyph { get; private set; }

      public int Surplus { get; private set; }

      public SheetSurplus(NitroFontWriter.SubGroup sub, int numGlyph, int surplus)
      {
        this.Sub = sub;
        this.NumGlyph = numGlyph;
        this.Surplus = surplus;
      }

      public int CompareTo(NitroFontWriter.SheetSurplus other)
      {
        return this.Surplus - other.Surplus;
      }
    }

    protected class GlyphLinkedList : LinkedList<Glyph>
    {
      public void Erase(LinkedListNode<Glyph> first, LinkedListNode<Glyph> last)
      {
        int num = 6;
        LinkedListNode<Glyph> linkedListNode;
        LinkedListNode<Glyph> next;
        while (true)
        {
          switch (num)
          {
            case 0:
              if (last == null)
              {
                num = 3;
                continue;
              }
              next = last.Next;
              linkedListNode = first;
              num = 5;
              continue;
            case 1:
              if (linkedListNode != next)
              {
                if (1 == 0)
                  ;
                LinkedListNode<Glyph> node = linkedListNode;
                linkedListNode = node.Next;
                this.Remove(node);
                num = 7;
                continue;
              }
              num = 4;
              continue;
            case 2:
              goto label_6;
            case 3:
              goto label_5;
            case 4:
              goto label_13;
            case 5:
            case 7:
              num = 1;
              continue;
            default:
              num = first != null ? 0 : 2;
              continue;
          }
        }
label_13:
        return;
label_5:
        throw new ArgumentNullException("last");
label_6:
        throw new ArgumentNullException("first");
      }
    }

    private class SharedCodeMap : Dictionary<ushort, List<int>>
    {
    }

    private class TGLPInfo
    {
      public int SheetBpp { get; set; }

      public int SheetWidth { get; set; }

      public int SheetHeight { get; set; }

      public int SheetBytes { get; set; }

      public int SheetNum { get; set; }

      public int CellWidth { get; set; }

      public int CellHeight { get; set; }

      public int CellHCount { get; set; }

      public int CellVCount { get; set; }

      public int CellNum { get; set; }

      public int AllSheetCellNum { get; set; }
    }

    private class CodeExistsMap : Dictionary<ushort, bool>
    {
    }

    private class A4Writer
    {
      private readonly MemoryStream a;
      private byte b;
      private byte c;

      public A4Writer(byte[] image)
      {
        this.a = new MemoryStream(image);
      }

      public void WritePixelA4_HL(ImageBase.Pixel pixel)
      {
        uint num = NitroFontWriter.a(pixel);
        this.b ^= (byte) 1;
        if ((int) this.b != 0)
        {
          if (1 == 0)
            ;
          this.c = (byte) num;
        }
        else
          this.a.WriteByte((byte) ((uint) this.c << 4 | num));
      }

      public void WritePixelA4_LH(ImageBase.Pixel pixel)
      {
        uint num = NitroFontWriter.a(pixel);
        this.b ^= (byte) 1;
        if ((int) this.b != 0)
        {
          if (1 == 0)
            ;
          this.c = (byte) num;
        }
        else
          this.a.WriteByte((byte) ((uint) this.c | num << 4));
      }
    }

    private class Writer
    {
      private readonly ByteOrderBinaryWriter a;

      public Writer(byte[] image)
      {
        this.a = new ByteOrderBinaryWriter((Stream) new MemoryStream(image), true);
      }

      public void WritePixelA8(ImageBase.Pixel pixel)
      {
        if (1 == 0)
          ;
        this.a.Write((byte) GlCm.InverseNumber((uint) GlCm.RgbToGrayScale((IntColor) pixel.IntColor), 8));
      }

      public void WritePixelAL4(ImageBase.Pixel pixel)
      {
        if (1 == 0)
          ;
        int num = (int) GlCm.RgbToGrayScale((IntColor) pixel.IntColor) >> 4;
        this.a.Write((byte) ((uint) pixel.A & 240U | GlCm.InverseNumber((uint) num, 4)));
      }

      public void WritePixelLA4(ImageBase.Pixel pixel)
      {
        if (1 == 0)
          ;
        this.a.Write((byte) (GlCm.InverseNumber((uint) GlCm.RgbToGrayScale((IntColor) pixel.IntColor) >> 4, 4) << 4 | (uint) pixel.A >> 4));
      }

      public void WritePixelAL8(ImageBase.Pixel pixel)
      {
        if (1 == 0)
          ;
        int num = (int) GlCm.RgbToGrayScale((IntColor) pixel.IntColor);
        this.a.Write((ushort) ((uint) pixel.A << 8 | GlCm.InverseNumber((uint) num, 8)));
      }

      public void WritePixelLA8(ImageBase.Pixel pixel)
      {
        if (1 == 0)
          ;
        this.a.Write((ushort) (GlCm.InverseNumber((uint) GlCm.RgbToGrayScale((IntColor) pixel.IntColor), 8) << 8 | (uint) pixel.A));
      }

      public void WritePixelRGB565(ImageBase.Pixel pixel)
      {
        if (1 == 0)
          ;
        this.a.Write((ushort) ((uint) ((int) (ushort) ((uint) pixel.R >> 3) << 11 | (int) (ushort) ((uint) pixel.G >> 2) << 5) | (uint) (ushort) ((uint) pixel.B >> 3)));
      }

      public void WritePixelA3RGB5(ImageBase.Pixel pixel)
      {
        int num1 = 1;
        ushort num2;
        while (true)
        {
          switch (num1)
          {
            case 0:
            case 3:
              goto label_7;
            case 2:
              num2 = (ushort) ((uint) (32768 | (int) (ushort) ((uint) pixel.R >> 3) << 10 | (int) (ushort) ((uint) pixel.G >> 3) << 5) | (uint) (ushort) ((uint) pixel.B >> 3));
              num1 = 0;
              continue;
            default:
              if (1 == 0)
                ;
              if ((int) pixel.A == (int) byte.MaxValue)
              {
                num1 = 2;
                continue;
              }
              num2 = (ushort) ((uint) ((int) (ushort) ((uint) pixel.A >> 5) << 12 | (int) (ushort) ((uint) pixel.R >> 4) << 8 | (int) (ushort) ((uint) pixel.G >> 4) << 4) | (uint) (ushort) ((uint) pixel.B >> 4));
              num1 = 3;
              continue;
          }
        }
label_7:
        this.a.Write(num2);
      }

      public void WritePixelRGB5A1(ImageBase.Pixel pixel)
      {
        if (1 == 0)
          ;
        this.a.Write((ushort) ((uint) ((int) (ushort) ((uint) pixel.R >> 3) << 11 | (int) (ushort) ((uint) pixel.G >> 3) << 6 | (int) (ushort) ((uint) pixel.B >> 3) << 1) | (uint) (ushort) ((uint) pixel.A >> 7)));
      }

      public void WritePixelRGBA4(ImageBase.Pixel pixel)
      {
        if (1 == 0)
          ;
        this.a.Write((ushort) ((uint) ((int) (ushort) ((uint) pixel.R >> 4) << 12 | (int) (ushort) ((uint) pixel.G >> 4) << 8 | (int) (ushort) ((uint) pixel.B >> 4) << 4) | (uint) (ushort) ((uint) pixel.A >> 4)));
      }

      public void WritePixelRGB8(ImageBase.Pixel pixel)
      {
        if (1 == 0)
          ;
        this.a.Write24Bits((uint) ((int) pixel.R << 16 | (int) pixel.G << 8) | (uint) pixel.B);
      }

      public void WritePixelRGBA8(ImageBase.Pixel pixel)
      {
        if (1 == 0)
          ;
        this.a.Write((uint) ((int) pixel.R << 24 | (int) pixel.G << 16 | (int) pixel.B << 8) | (uint) pixel.A);
      }
    }

    private class SurplusList : List<NitroFontWriter.SheetSurplus>
    {
    }
  }
}
