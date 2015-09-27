// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.G2dFont
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Runtime;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace NintendoWare.Font
{
  public class G2dFont : NnsData
  {
    private bool a;
    private int b;

    public G2dFont()
    {
      this.a = false;
      this.b = Marshal.SizeOf(typeof (CharWidths));
    }

    public static bool IsUnicodeEncoding(CharEncoding enc)
    {
      if (enc != CharEncoding.UTF8)
        return enc == CharEncoding.UTF16;
      return true;
    }

    public CharWidths GetGlyphWidthFromIndex(FontWidthEx fontWidthEx, int idx)
    {
      return fontWidthEx.WidthTable[idx - (int) fontWidthEx.Body.IndexBegin];
    }

    public bool IsOldVer()
    {
      return this.a;
    }

    public void SetGlyphGroupsBlock(uint sheetSize, ushort glyphsPerSheet, ushort numSheet, ushort numSet, G2dFont.SheetSetList sheetSetList, IntArray compSheetSizes)
    {
label_2:
      ushort num1 = (ushort) this.GetNumBlock(RtConsts.BinBlockSigCWDH);
      ushort num2 = (ushort) this.GetNumBlock(RtConsts.BinBlockSigCMAP);
      FontGlyphGroups fontGlyphGroups = new FontGlyphGroups();
      fontGlyphGroups.SheetSize = sheetSize;
      fontGlyphGroups.GlyphsPerSheet = glyphsPerSheet;
      fontGlyphGroups.NumSheet = numSheet;
      fontGlyphGroups.NumSet = numSet;
      fontGlyphGroups.NumCWDH = num1;
      fontGlyphGroups.NumCMAP = num2;
      FontGlyphGroupsEx fontGlyphGroupsEx = new FontGlyphGroupsEx();
      fontGlyphGroupsEx.Body = fontGlyphGroups;
      fontGlyphGroupsEx.SheetSetList = sheetSetList;
      fontGlyphGroupsEx.CompSheetSizes = compSheetSizes;
      fontGlyphGroupsEx.SizeCWDH = new int[(int) num1];
      int no1 = 0;
      int num3 = 1;
      int no2;
      while (true)
      {
        switch (num3)
        {
          case 0:
          case 1:
            num3 = 2;
            continue;
          case 2:
            if (no1 < (int) num1)
            {
              fontGlyphGroupsEx.SizeCWDH[no1] = this.GetBlock(RtConsts.BinBlockSigCWDH, no1).Get4AlignedBlockSize(0);
              ++no1;
              num3 = 0;
              continue;
            }
            num3 = 7;
            continue;
          case 3:
          case 4:
            num3 = 5;
            continue;
          case 5:
            if (no2 < (int) num2)
            {
              fontGlyphGroupsEx.SizeCMAP[no2] = this.GetBlock(RtConsts.BinBlockSigCMAP, no2).Get4AlignedBlockSize(0);
              ++no2;
              if (1 == 0)
                ;
              num3 = 4;
              continue;
            }
            num3 = 6;
            continue;
          case 6:
            goto label_13;
          case 7:
            fontGlyphGroupsEx.SizeCMAP = new int[(int) num2];
            no2 = 0;
            num3 = 3;
            continue;
          default:
            goto label_2;
        }
      }
label_13:
      this.SetBlock(RtConsts.BinBlockSigGLGR, (IBinarizable) fontGlyphGroupsEx);
    }

    public void SetInformationBlock(byte fontType, byte linefeed, byte width, byte height, byte ascent, ushort alterCharIndex, sbyte defaultLeft, byte defaultWidth, sbyte defaultRight, byte encoding)
    {
      if (1 == 0)
        ;
      FontInformation fontInformation = new FontInformation();
      sbyte num = (sbyte) ((int) defaultLeft + (int) defaultWidth + (int) defaultRight);
      fontInformation.FontType = fontType;
      fontInformation.Linefeed = (sbyte) linefeed;
      fontInformation.Width = width;
      fontInformation.Height = height;
      fontInformation.Ascent = ascent;
      fontInformation.AlterCharIndex = alterCharIndex;
      fontInformation.DefaultWidth.Left = defaultLeft;
      fontInformation.DefaultWidth.GlyphWidth = defaultWidth;
      fontInformation.DefaultWidth.CharWidth = num;
      fontInformation.Encoding = encoding;
      this.SetBlock(RtConsts.BinBlockSigFINF, (IBinarizable) new FontInformationEx()
      {
        Body = fontInformation
      });
    }

    public void SetTextureGlyphBlock(byte cellWidth, byte cellHeight, sbyte baselinePos, byte maxCharWidth, uint sheetSize, ushort sheetNum, ushort sheetFormat, ushort sheetRow, ushort sheetLine, ushort sheetWidth, ushort sheetHeight, byte[] image, int imageSize)
    {
      if (1 == 0)
        ;
      this.SetBlock(RtConsts.BinBlockSigTGLP, (IBinarizable) new FontTextureGlyphEx()
      {
        Body = new FontTextureGlyph()
        {
          CellWidth = cellWidth,
          CellHeight = cellHeight,
          BaselinePos = baselinePos,
          MaxCharWidth = maxCharWidth,
          SheetSize = sheetSize,
          SheetNum = sheetNum,
          SheetFormat = sheetFormat,
          SheetRow = sheetRow,
          SheetLine = sheetLine,
          SheetWidth = sheetWidth,
          SheetHeight = sheetHeight
        },
        SheetImage = image,
        SheetImageSize = imageSize
      });
    }

    public void AddWidthBlock(ushort ccodeBegin, ushort ccodeEnd, CharWidths[] data)
    {
      if (1 == 0)
        ;
      int length = (int) ccodeEnd - (int) ccodeBegin + 1;
      FontWidth fontWidth = new FontWidth();
      fontWidth.IndexBegin = ccodeBegin;
      fontWidth.IndexEnd = ccodeEnd;
      FontWidthEx fontWidthEx = new FontWidthEx();
      fontWidthEx.Body = fontWidth;
      fontWidthEx.WidthTable = new CharWidths[length];
      Array.Copy((Array) data, (int) ccodeBegin, (Array) fontWidthEx.WidthTable, 0, fontWidthEx.WidthTable.Length);
      this.SetBlock(RtConsts.BinBlockSigCWDH, (IBinarizable) fontWidthEx);
    }

    public void AddCMapBlock(ushort ccodeBegin, ushort ccodeEnd, FontMapMethod mappingMethod, CMapScanEntry[] entries)
    {
      if (1 == 0)
        ;
      this.SetBlock(RtConsts.BinBlockSigCMAP, (IBinarizable) new FontCodeMapEx()
      {
        Body = new FontCodeMap()
        {
          CodeBegin = ccodeBegin,
          CodeEnd = ccodeEnd,
          MappingMethod = (ushort) mappingMethod
        },
        Scan = new CMapInfoScanEx()
        {
          Body = new CMapInfoScan()
          {
            Num = (ushort) entries.Length
          },
          Entries = entries
        }
      });
    }

    public void MakeInterBlcokLink()
    {
label_2:
      List<int> list1 = new List<int>();
      List<int> list2 = new List<int>();
      list1.Capacity = 10;
      list2.Capacity = 10;
      int blockOffset = BinaryFileHeader.Length;
      NnsData.GeneralBinaryBlockInfo block1 = this.GetBlock(RtConsts.BinBlockSigGLGR);
      int num1 = 22;
      int no1;
      int no2;
      NnsData.GeneralBinaryBlockInfo block2;
      int num2;
      int no3;
      NnsData.GeneralBinaryBlockInfo block3;
      int num3;
      int num4;
      int no4;
      while (true)
      {
        switch (num1)
        {
          case 0:
          case 1:
            num1 = 6;
            continue;
          case 2:
            if (block1 != null)
            {
              list2.Add(blockOffset + BinaryBlockHeader.Length);
              blockOffset += block1.Get4AlignedBlockSize(blockOffset);
              ++no2;
              block1 = this.GetBlock(RtConsts.BinBlockSigCMAP, no2);
              num1 = 11;
              continue;
            }
            num1 = 5;
            continue;
          case 3:
            goto label_32;
          case 4:
          case 21:
            num1 = 7;
            continue;
          case 5:
            list2.Add(0);
            FontInformationEx fontInformationEx = (FontInformationEx) this.GetBlockItnl(RtConsts.BinBlockSigFINF).Body;
            fontInformationEx.Body.PtrGlyph = (uint) num3;
            fontInformationEx.Body.PtrWidth = (uint) list1[0];
            fontInformationEx.Body.PtrMap = (uint) list2[0];
            num4 = list1.Count - 1;
            no1 = 0;
            num1 = 15;
            continue;
          case 6:
            if (block1 != null)
            {
              list1.Add(blockOffset + BinaryBlockHeader.Length);
              blockOffset += block1.Get4AlignedBlockSize(blockOffset);
              ++no4;
              block1 = this.GetBlock(RtConsts.BinBlockSigCWDH, no4);
              num1 = 0;
              continue;
            }
            num1 = 13;
            continue;
          case 7:
            if (no3 >= num2)
            {
              num1 = 3;
              continue;
            }
            ((FontCodeMapEx) this.GetBlockItnl(RtConsts.BinBlockSigCMAP, no3).Body).Body.PtrNext = (uint) list2[no3 + 1];
            ++no3;
            num1 = 21;
            continue;
          case 8:
            blockOffset += block1.Get4AlignedBlockSize(blockOffset);
            num1 = 16;
            continue;
          case 9:
          case 11:
            num1 = 2;
            continue;
          case 10:
            if (block3 == null)
            {
              blockOffset += block2.Get4AlignedBlockSize(blockOffset);
              num1 = 17;
              continue;
            }
            num1 = 14;
            continue;
          case 12:
            if (no1 < num4)
            {
              ((FontWidthEx) this.GetBlockItnl(RtConsts.BinBlockSigCWDH, no1).Body).Body.PtrNext = (uint) list1[no1 + 1];
              ++no1;
              num1 = 18;
              continue;
            }
            num1 = 20;
            continue;
          case 13:
            list1.Add(0);
            no2 = 0;
            block1 = this.GetBlock(RtConsts.BinBlockSigCMAP);
            num1 = 9;
            continue;
          case 14:
            blockOffset += block3.Get4AlignedBlockSize(blockOffset);
            num1 = 19;
            continue;
          case 15:
          case 18:
            num1 = 12;
            continue;
          case 16:
            if (1 == 0)
              ;
            block1 = this.GetBlock(RtConsts.BinBlockSigFINF);
            blockOffset += block1.Get4AlignedBlockSize(blockOffset);
            block2 = this.GetBlock(RtConsts.BinBlockSigCGLP);
            block3 = this.GetBlock(RtConsts.BinBlockSigTGLP);
            num3 = blockOffset + BinaryBlockHeader.Length;
            num1 = 10;
            continue;
          case 17:
          case 19:
            no4 = 0;
            block1 = this.GetBlock(RtConsts.BinBlockSigCWDH);
            num1 = 1;
            continue;
          case 20:
            num2 = list2.Count - 1;
            no3 = 0;
            num1 = 4;
            continue;
          case 22:
            if (block1 != null)
            {
              num1 = 8;
              continue;
            }
            goto case 16;
          default:
            goto label_2;
        }
      }
label_32:;
    }

    public IBinarizable GenerateInstance(Signature32 kind)
    {
      int num = 3;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_8;
          case 1:
            num = !(kind == RtConsts.BinBlockSigTGLP) ? 2 : 4;
            continue;
          case 2:
            num = !(kind == RtConsts.BinBlockSigCWDH) ? 5 : 6;
            continue;
          case 4:
            goto label_11;
          case 5:
            if (kind == RtConsts.BinBlockSigCMAP)
            {
              num = 7;
              continue;
            }
            goto label_12;
          case 6:
            goto label_3;
          case 7:
            goto label_7;
          default:
            num = !(kind == RtConsts.BinBlockSigFINF) ? 1 : 0;
            continue;
        }
      }
label_3:
      if (1 == 0)
        ;
      return (IBinarizable) new FontWidthEx();
label_7:
      return (IBinarizable) new FontCodeMapEx();
label_8:
      return (IBinarizable) new FontInformationEx();
label_11:
      return (IBinarizable) new FontTextureGlyphEx();
label_12:
      return (IBinarizable) null;
    }

    public void Rebuild()
    {
      Dictionary<Signature32, NnsData.BlockList>.Enumerator enumerator = this.Blocks.GetEnumerator();
      try
      {
        int num = 28;
        FontInformationEx fontInformationEx;
        FontCodeMapEx fontCodeMapEx;
        NnsData.BlockList blockList;
        int index;
        NnsData.GeneralBinaryBlockInfo generalBinaryBlockInfo;
        FontWidthEx fontWidthEx;
        while (true)
        {
          switch (num)
          {
            case 0:
              num = 27;
              continue;
            case 1:
            case 3:
            case 10:
              ++index;
              num = 12;
              continue;
            case 2:
              NnsData.GeneralBinaryBlockInfo blockItnl1 = this.GetBlockItnl(RtConsts.BinBlockSigCWDH);
              fontInformationEx.Width = (FontWidthEx) blockItnl1.Body;
              num = 17;
              continue;
            case 4:
              if (index >= blockList.Count)
              {
                num = 25;
                continue;
              }
              generalBinaryBlockInfo = blockList[index];
              num = 13;
              continue;
            case 5:
              num = !(generalBinaryBlockInfo.Kind == RtConsts.BinBlockSigCWDH) ? 24 : 19;
              continue;
            case 6:
              num = 20;
              continue;
            case 7:
              NnsData.GeneralBinaryBlockInfo blockItnl2 = this.GetBlockItnl(RtConsts.BinBlockSigTGLP);
              fontInformationEx.Glyph = (FontTextureGlyphEx) blockItnl2.Body;
              num = 0;
              continue;
            case 8:
              if (!enumerator.MoveNext())
              {
                num = 6;
                continue;
              }
              blockList = enumerator.Current.Value;
              index = 0;
              num = 26;
              continue;
            case 9:
              fontCodeMapEx.Next = (FontCodeMapEx) blockList[index + 1].Body;
              num = 1;
              continue;
            case 11:
              fontInformationEx = (FontInformationEx) generalBinaryBlockInfo.Body;
              num = 15;
              continue;
            case 12:
            case 26:
              num = 4;
              continue;
            case 13:
              num = !(generalBinaryBlockInfo.Kind == RtConsts.BinBlockSigFINF) ? 5 : 11;
              continue;
            case 14:
              fontWidthEx.Next = (FontWidthEx) blockList[index + 1].Body;
              num = 3;
              continue;
            case 15:
              if ((int) fontInformationEx.Body.PtrGlyph != 0)
              {
                num = 7;
                continue;
              }
              goto case 0;
            case 16:
              NnsData.GeneralBinaryBlockInfo blockItnl3 = this.GetBlockItnl(RtConsts.BinBlockSigCMAP);
              fontInformationEx.Map = (FontCodeMapEx) blockItnl3.Body;
              num = 10;
              continue;
            case 17:
              num = 22;
              continue;
            case 18:
              fontCodeMapEx = (FontCodeMapEx) generalBinaryBlockInfo.Body;
              num = 23;
              continue;
            case 19:
              fontWidthEx = (FontWidthEx) generalBinaryBlockInfo.Body;
              num = 21;
              continue;
            case 20:
              goto label_37;
            case 21:
              if ((int) fontWidthEx.Body.PtrNext != 0)
              {
                num = 14;
                continue;
              }
              goto case 1;
            case 22:
              if ((int) fontInformationEx.Body.PtrMap != 0)
              {
                num = 16;
                continue;
              }
              goto case 1;
            case 23:
              if ((int) fontCodeMapEx.Body.PtrNext != 0)
              {
                num = 9;
                continue;
              }
              goto case 1;
            case 24:
              if (generalBinaryBlockInfo.Kind == RtConsts.BinBlockSigCMAP)
              {
                num = 18;
                continue;
              }
              goto case 1;
            case 27:
              if ((int) fontInformationEx.Body.PtrWidth != 0)
              {
                num = 2;
                continue;
              }
              goto case 17;
            default:
              num = 8;
              continue;
          }
        }
label_37:;
      }
      finally
      {
        if (1 == 0)
          ;
        enumerator.Dispose();
      }
    }

    public ushort GetGlyphIndex(ushort c)
    {
label_2:
      NnsData.GeneralBinaryBlockInfo block = this.GetBlock(RtConsts.BinBlockSigCMAP);
      int no = 0;
      int num1 = 9;
      ushort num2;
      while (true)
      {
        FontCodeMapEx A_0;
        switch (num1)
        {
          case 0:
            if (block != null)
            {
              A_0 = (FontCodeMapEx) block.Body;
              num1 = 5;
              continue;
            }
            num1 = 2;
            continue;
          case 1:
            if ((int) c <= (int) A_0.Body.CodeEnd)
            {
              num1 = 3;
              continue;
            }
            break;
          case 2:
            goto label_18;
          case 3:
            num2 = this.a(A_0, c);
            num1 = 8;
            continue;
          case 4:
            if (1 == 0)
              ;
            num1 = 1;
            continue;
          case 5:
            if ((int) A_0.Body.CodeBegin <= (int) c)
            {
              num1 = 4;
              continue;
            }
            break;
          case 6:
          case 9:
            num1 = 0;
            continue;
          case 7:
            goto label_17;
          case 8:
            if ((int) num2 != (int) ushort.MaxValue)
            {
              num1 = 7;
              continue;
            }
            goto label_18;
          default:
            goto label_2;
        }
        ++no;
        block = this.GetBlock(RtConsts.BinBlockSigCMAP, no);
        num1 = 6;
      }
label_17:
      return num2;
label_18:
      return ushort.MaxValue;
    }

    public CharWidths GetGlyphWidthInfo(ushort idx)
    {
label_3:
      NnsData.GeneralBinaryBlockInfo block = this.GetBlock(RtConsts.BinBlockSigCWDH);
      int no = 0;
      int num = 5;
      FontWidthEx fontWidthEx;
      while (true)
      {
        if (1 == 0)
          ;
        FontWidth body;
        switch (num)
        {
          case 0:
            goto label_5;
          case 1:
            if (block != null)
            {
              fontWidthEx = (FontWidthEx) block.Body;
              body = fontWidthEx.Body;
              num = 3;
              continue;
            }
            num = 7;
            continue;
          case 2:
            num = 6;
            continue;
          case 3:
            if ((int) body.IndexBegin <= (int) idx)
            {
              num = 2;
              continue;
            }
            break;
          case 4:
          case 5:
            num = 1;
            continue;
          case 6:
            if ((int) idx <= (int) body.IndexEnd)
            {
              num = 0;
              continue;
            }
            break;
          case 7:
            goto label_15;
          default:
            goto label_3;
        }
        ++no;
        block = this.GetBlock(RtConsts.BinBlockSigCWDH, no);
        num = 4;
      }
label_5:
      return this.GetGlyphWidthFromIndex(fontWidthEx, (int) idx);
label_15:
      return ((FontInformationEx) this.GetBlock(RtConsts.BinBlockSigFINF).Body).Body.DefaultWidth;
    }

    public void ValidateHeader()
    {
      int num = 6;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_18;
          case 1:
            num = 5;
            continue;
          case 2:
            num = 3;
            continue;
          case 3:
            if ((int) this.Header.ByteOrder != 65534)
            {
              num = 0;
              continue;
            }
            goto label_23;
          case 4:
            goto label_17;
          case 5:
            if ((int) this.Header.Version != (int) RtConsts.FontFileVersionOld)
            {
              if (1 == 0)
                ;
              num = 13;
              continue;
            }
            break;
          case 7:
            if ((int) this.Header.ByteOrder != 65279)
            {
              num = 2;
              continue;
            }
            goto label_23;
          case 8:
            if ((int) this.Header.DataBlocks < 2)
            {
              num = 4;
              continue;
            }
            goto label_29;
          case 9:
            goto label_15;
          case 10:
            if (this.Header.Signature != RtConsts.BinFileSigFONTA)
            {
              num = 9;
              continue;
            }
            goto label_10;
          case 11:
            num = 10;
            continue;
          case 12:
            if ((int) this.Header.Version != (int) RtConsts.FontFileVersion)
            {
              num = 1;
              continue;
            }
            break;
          case 13:
            goto label_16;
          case 14:
            goto label_22;
          case 15:
            num = (int) this.Header.HeaderSize == BinaryFileHeader.Length ? 8 : 14;
            continue;
          default:
            if (this.Header.Signature != RtConsts.BinFileSigFONT)
            {
              num = 11;
              continue;
            }
            goto label_10;
        }
        num = 15;
        continue;
label_10:
        num = 7;
        continue;
label_23:
        num = 12;
      }
label_29:
      return;
label_15:
      throw GlCm.ErrMsg(ErrorType.Font, Strings.IDS_ERR_INVALID_FONT_FILE, (object) "bcfnt");
label_16:
      throw GlCm.ErrMsg(ErrorType.Font, Strings.IDS_ERR_UNSUPPORTED_VERSION, (object) "bcfnt", (object) G2dFont.a(this.Header.Version), (object) G2dFont.a(RtConsts.FontFileVersion));
label_17:
      throw GlCm.ErrMsg(ErrorType.Font, Strings.IDS_ERR_TOO_FEW_BLOCKS, (object) this.Header.DataBlocks);
label_18:
      throw GlCm.ErrMsg(ErrorType.Font, Strings.IDS_ERR_INVALID_FONT_FILE, (object) "bcfnt");
label_22:
      throw GlCm.ErrMsg(ErrorType.Font, Strings.IDS_ERR_UNEXPECTED_HEADER_SIZE, (object) "bcfnt", (object) this.Header.HeaderSize, (object) BinaryFileHeader.Length);
    }

    public void AddCMapBlock(ushort ccodeBegin, ushort ccodeEnd, FontMapMethod mappingMethod, ushort[] data)
    {
      if (1 == 0)
        ;
      this.SetBlock(RtConsts.BinBlockSigCMAP, (IBinarizable) new FontCodeMapEx()
      {
        Body = new FontCodeMap()
        {
          CodeBegin = ccodeBegin,
          CodeEnd = ccodeEnd,
          MappingMethod = (ushort) mappingMethod
        },
        MapInfo = data
      });
    }

    private static string a(uint A_0)
    {
      if (1 == 0)
        ;
      return string.Format("{0}.{1}.{2}.{3}", (object) (uint) ((int) (A_0 >> 24) & (int) byte.MaxValue), (object) (uint) ((int) (A_0 >> 16) & (int) byte.MaxValue), (object) (uint) ((int) (A_0 >> 8) & (int) byte.MaxValue), (object) (uint) ((int) A_0 & (int) byte.MaxValue));
    }

    private ushort a(FontCodeMapEx A_0, ushort A_1)
    {
label_2:
      ushort num1 = ushort.MaxValue;
      FontCodeMap body = A_0.Body;
      FontMapMethod fontMapMethod = (FontMapMethod) body.MappingMethod;
      int num2 = 4;
      int index1;
      int num3;
      int num4;
      CMapScanEntry[] entries;
      while (true)
      {
        switch (num2)
        {
          case 0:
          case 7:
          case 9:
            num2 = 5;
            continue;
          case 1:
            goto label_9;
          case 2:
          case 8:
          case 13:
          case 14:
            goto label_20;
          case 3:
            num2 = (int) entries[index1].Code >= (int) A_1 ? 12 : 11;
            continue;
          case 4:
            switch (fontMapMethod)
            {
              case FontMapMethod.Direct:
                ushort num5 = A_0.MapInfo[0];
                num1 = (ushort) ((uint) A_1 - (uint) body.CodeBegin + (uint) num5);
                num2 = 14;
                continue;
              case FontMapMethod.Table:
                int index2 = (int) A_1 - (int) body.CodeBegin;
                num1 = A_0.MapInfo[index2];
                num2 = 8;
                continue;
              case FontMapMethod.Scan:
                entries = A_0.Scan.Entries;
                num4 = 0;
                num3 = (int) A_0.Scan.Body.Num - 1;
                num2 = 7;
                continue;
              default:
                num2 = 6;
                continue;
            }
          case 5:
            if (num4 > num3)
            {
              num2 = 2;
              continue;
            }
            index1 = num4 + (num3 - num4) / 2;
            num2 = 3;
            continue;
          case 6:
            num2 = 13;
            continue;
          case 10:
            num3 = index1 - 1;
            num2 = 0;
            continue;
          case 11:
            num4 = index1 + 1;
            num2 = 9;
            continue;
          case 12:
            if ((int) A_1 >= (int) entries[index1].Code)
            {
              num1 = entries[index1].Index;
              num2 = 1;
              continue;
            }
            num2 = 10;
            continue;
          default:
            goto label_2;
        }
      }
label_9:
      if (1 == 0)
        ;
label_20:
      return num1;
    }

    public class BitArray : List<uint>
    {
    }

    public class SheetSetList : List<G2dFont.SheetSet>
    {
    }

    public class SheetSet
    {
      private readonly G2dFont.BitArray a = new G2dFont.BitArray();
      private readonly G2dFont.BitArray b = new G2dFont.BitArray();
      private readonly G2dFont.BitArray c = new G2dFont.BitArray();

      public string Name { get; private set; }

      public G2dFont.BitArray UseSheets
      {
        get
        {
          return this.a;
        }
      }

      public G2dFont.BitArray UseCWDH
      {
        get
        {
          return this.b;
        }
      }

      public G2dFont.BitArray UseCMAP
      {
        get
        {
          return this.c;
        }
      }

      public SheetSet(string name)
      {
        this.Name = name;
      }
    }
  }
}
