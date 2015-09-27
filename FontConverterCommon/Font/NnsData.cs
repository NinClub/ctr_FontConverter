// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.NnsData
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Runtime;
using System.Collections.Generic;

namespace NintendoWare.Font
{
  public class NnsData
  {
    private readonly NnsData.BlockMap m_a = new NnsData.BlockMap();
    private BinaryFileHeader b;

    protected NnsData.BlockMap Blocks
    {
      get
      {
        return this.m_a;
      }
    }

    protected BinaryFileHeader Header
    {
      get
      {
        return this.b;
      }
    }

    public void SetHeader(BinaryFileHeader header)
    {
      this.b = header;
    }

    public NnsData.GeneralBinaryBlockInfo GetBlock(Signature32 id, int no)
    {
      int num = 3;
      NnsData.BlockList blockList = null;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_5;
          case 1:
            num = 2;
            continue;
          case 2:
            if (no < blockList.Count)
            {
              num = 0;
              continue;
            }
            goto label_9;
          default:
            if (1 == 0)
              ;
            if (this.m_a.TryGetValue(id, out blockList))
            {
              num = 1;
              continue;
            }
            goto label_9;
        }
      }
label_5:
      return blockList[no];
label_9:
      return (NnsData.GeneralBinaryBlockInfo) null;
    }

    public int GetNumBlock(Signature32 id)
    {
      NnsData.BlockList blockList;
      if (this.m_a.TryGetValue(id, out blockList))
        return blockList.Count;
      if (1 == 0)
        ;
      return 0;
    }

    public void SetBlock(Signature32 id, IBinarizable body)
    {
      if (1 == 0)
        ;
      this.a(id, new NnsData.GeneralBinaryBlockInfo()
      {
        Kind = id,
        Body = body
      });
    }

    public NnsData.GeneralBinaryBlockInfo GetBlock(Signature32 id)
    {
      return this.GetBlock(id, 0);
    }

    protected NnsData.GeneralBinaryBlockInfo GetBlockItnl(Signature32 id, int no)
    {
      int num = 1;
      NnsData.BlockList blockList = null;
      while (true)
      {
        switch (num)
        {
          case 0:
            num = 3;
            continue;
          case 2:
            goto label_4;
          case 3:
            if (no < blockList.Count)
            {
              if (1 == 0)
                ;
              num = 2;
              continue;
            }
            goto label_9;
          default:
            if (this.m_a.TryGetValue(id, out blockList))
            {
              num = 0;
              continue;
            }
            goto label_9;
        }
      }
label_4:
      return blockList[no];
label_9:
      return (NnsData.GeneralBinaryBlockInfo) null;
    }

    protected NnsData.GeneralBinaryBlockInfo GetBlockItnl(Signature32 id)
    {
      return this.GetBlockItnl(id, 0);
    }

    private void a(Signature32 A_0, NnsData.GeneralBinaryBlockInfo A_1)
    {
      int num = 2;
      NnsData.BlockList blockList1 = null;
      while (true)
      {
        switch (num)
        {
          case 0:
            blockList1 = new NnsData.BlockList();
            this.m_a.Add(A_0, blockList1);
            num = 1;
            continue;
          case 1:
            goto label_7;
          case 3:
            goto label_5;
          default:
            NnsData.BlockList blockList2;
            if (!this.m_a.TryGetValue(A_0, out blockList2))
            {
              num = 0;
              continue;
            }
            blockList1 = blockList2;
            num = 3;
            continue;
        }
      }
label_5:
      if (1 == 0)
        ;
label_7:
      blockList1.Add(A_1);
    }

    public class GeneralBinaryBlockInfo
    {
      public Signature32 Kind { get; set; }

      public IBinarizable Body { get; set; }

      public int Get4AlignedBlockSize(int blockOffset)
      {
        if (1 == 0)
          ;
        int num = GlCm.ROUND_UP(this.Body.GetBlockContentsSize(blockOffset + BinaryBlockHeader.Length), 4);
        return BinaryBlockHeader.Length + num;
      }
    }

    protected class BlockList : List<NnsData.GeneralBinaryBlockInfo>
    {
    }

    protected class BlockMap : Dictionary<Signature32, NnsData.BlockList>
    {
    }
  }
}
