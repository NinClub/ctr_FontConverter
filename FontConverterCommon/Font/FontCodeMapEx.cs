// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.FontCodeMapEx
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Runtime;

namespace NintendoWare.Font
{
  public class FontCodeMapEx : IBinarizable
  {
    private FontCodeMap a;

    public FontCodeMap Body
    {
      get
      {
        return this.a;
      }
      set
      {
        this.a = value;
      }
    }

    public FontCodeMapEx Next { get; set; }

    public ushort[] MapInfo { get; set; }

    public CMapInfoScanEx Scan { get; set; }

    public void Read(ByteOrderBinaryReader br, int size)
    {
label_2:
      br.Read<FontCodeMap>(out this.a);
      FontMapMethod fontMapMethod = (FontMapMethod) this.a.MappingMethod;
      int num = 3;
      CMapInfoScanEx cmapInfoScanEx;
      int index1;
      int index2;
      int length;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_19;
          case 1:
            goto label_18;
          case 2:
          case 5:
            num = 9;
            continue;
          case 3:
            switch (fontMapMethod)
            {
              case FontMapMethod.Direct:
                goto label_10;
              case FontMapMethod.Table:
                length = (int) this.a.CodeEnd - (int) this.a.CodeBegin + 1;
                this.MapInfo = new ushort[length];
                index2 = 0;
                num = 8;
                continue;
              case FontMapMethod.Scan:
                CMapInfoScan cmapInfoScan;
                br.Read<CMapInfoScan>(out cmapInfoScan);
                cmapInfoScanEx = new CMapInfoScanEx();
                cmapInfoScanEx.Body = cmapInfoScan;
                cmapInfoScanEx.Entries = new CMapScanEntry[(int) cmapInfoScanEx.Body.Num];
                index1 = 0;
                if (1 == 0)
                  ;
                num = 2;
                continue;
              default:
                num = 1;
                continue;
            }
          case 4:
          case 8:
            num = 7;
            continue;
          case 6:
            goto label_12;
          case 7:
            if (index2 >= length)
            {
              num = 6;
              continue;
            }
            this.MapInfo[index2] = br.ReadUInt16();
            ++index2;
            num = 4;
            continue;
          case 9:
            if (index1 < (int) cmapInfoScanEx.Body.Num)
            {
              br.Read<CMapScanEntry>(out cmapInfoScanEx.Entries[index1]);
              ++index1;
              num = 5;
              continue;
            }
            num = 0;
            continue;
          default:
            goto label_2;
        }
      }
label_12:
      return;
label_18:
      return;
label_10:
      this.MapInfo = new ushort[1]
      {
        br.ReadUInt16()
      };
      return;
label_19:
      this.Scan = cmapInfoScanEx;
    }

    public void Write(ByteOrderBinaryWriter bw)
    {
label_2:
      bw.Write((object) this.a);
      int num1 = 1;
      ushort[] mapInfo;
      int index1;
      CMapScanEntry[] entries;
      int index2;
      while (true)
      {
        switch (num1)
        {
          case 0:
            goto label_7;
          case 1:
            if (this.Scan != null)
            {
              num1 = 2;
              continue;
            }
            mapInfo = this.MapInfo;
            index1 = 0;
            if (1 == 0)
              ;
            num1 = 4;
            continue;
          case 2:
            bw.Write((object) this.Scan.Body);
            entries = this.Scan.Entries;
            index2 = 0;
            num1 = 9;
            continue;
          case 3:
            goto label_17;
          case 4:
          case 5:
            num1 = 6;
            continue;
          case 6:
            if (index1 >= mapInfo.Length)
            {
              num1 = 0;
              continue;
            }
            ushort num2 = mapInfo[index1];
            bw.Write(num2);
            ++index1;
            num1 = 5;
            continue;
          case 7:
            if (index2 < entries.Length)
            {
              CMapScanEntry cmapScanEntry = entries[index2];
              bw.Write((object) cmapScanEntry);
              ++index2;
              num1 = 8;
              continue;
            }
            num1 = 3;
            continue;
          case 8:
          case 9:
            num1 = 7;
            continue;
          default:
            goto label_2;
        }
      }
label_17:
      return;
label_7:;
    }

    public int GetBlockContentsSize(int offset)
    {
      if (1 == 0)
        ;
      return FontCodeMap.Length + (this.Scan != null ? CMapInfoScan.Length + CMapScanEntry.Length * this.Scan.Entries.Length : this.MapInfo.Length * 2);
    }
  }
}
