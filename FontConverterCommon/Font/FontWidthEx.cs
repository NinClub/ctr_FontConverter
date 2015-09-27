// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.FontWidthEx
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Runtime;

namespace NintendoWare.Font
{
  public class FontWidthEx : IBinarizable
  {
    private FontWidth a;

    public FontWidth Body
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

    public FontWidthEx Next { get; set; }

    public CharWidths[] WidthTable { get; set; }

    public void Read(ByteOrderBinaryReader br, int size)
    {
label_2:
      br.Read<FontWidth>(out this.a);
      this.WidthTable = new CharWidths[(int) this.a.IndexEnd + 1 - (int) this.a.IndexBegin];
      int index = 0;
      if (1 == 0)
        ;
      int num = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
          case 1:
            num = 2;
            continue;
          case 2:
            if (index >= this.WidthTable.Length)
            {
              num = 3;
              continue;
            }
            br.Read<CharWidths>(out this.WidthTable[index]);
            ++index;
            num = 1;
            continue;
          case 3:
            goto label_8;
          default:
            goto label_2;
        }
      }
label_8:;
    }

    public void Write(ByteOrderBinaryWriter bw)
    {
label_2:
      bw.Write((object) this.a);
      CharWidths[] widthTable = this.WidthTable;
      int index = 0;
      if (1 == 0)
        ;
      int num = 3;
      while (true)
      {
        switch (num)
        {
          case 0:
          case 3:
            num = 1;
            continue;
          case 1:
            if (index >= widthTable.Length)
            {
              num = 2;
              continue;
            }
            CharWidths charWidths = widthTable[index];
            bw.Write((object) charWidths);
            ++index;
            num = 0;
            continue;
          case 2:
            goto label_8;
          default:
            goto label_2;
        }
      }
label_8:;
    }

    public int GetBlockContentsSize(int offset)
    {
      return FontWidth.Length + this.WidthTable.Length * 3;
    }
  }
}
