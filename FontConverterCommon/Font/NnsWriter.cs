// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.NnsWriter
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Runtime;
using System.IO;

namespace NintendoWare.Font
{
  public class NnsWriter
  {
    private BinaryFileHeader b = new BinaryFileHeader();
    private readonly ByteOrderBinaryWriter a;
    private uint c;
    private ushort d;
    private bool e;

    public NnsWriter(BinaryFile binaryFile)
    {
      this.a = new ByteOrderBinaryWriter((Stream) binaryFile, true);
      this.c = 0U;
      this.d = (ushort) 0;
      this.e = false;
    }

    public void WriteNnsBegin(Signature32 sig, uint version)
    {
      if (1 == 0)
        ;
      this.b.Signature = sig;
      this.b.Version = version;
      this.c = (uint) BinaryFileHeader.Length;
      this.d = (ushort) 0;
      this.e = true;
      this.a.Seek((int) this.c, SeekOrigin.Begin);
    }

    public void WriteNnsEnd()
    {
      if (1 == 0)
        ;
      this.b.ByteOrder = (ushort) 65279;
      this.b.FileSize = this.c;
      this.b.HeaderSize = (ushort) BinaryFileHeader.Length;
      this.b.DataBlocks = this.d;
      this.a.Seek(0, SeekOrigin.Begin);
      this.a.Write((object) this.b);
      this.e = false;
    }

    public bool WriteNnsBlock(NnsData nnsData, Signature32 id, int no)
    {
      NnsData.GeneralBinaryBlockInfo block = nnsData.GetBlock(id, no);
      if (block != null)
      {
        this.a(id, block.Body);
        return true;
      }
      if (1 == 0)
        ;
      return false;
    }

    public bool WriteNnsBlock(NnsData nnsData, Signature32 id)
    {
      return this.WriteNnsBlock(nnsData, id, 0);
    }

    protected void WritePadding(uint size)
    {
label_2:
      int num1 = 0;
      int num2 = 1;
      while (true)
      {
        switch (num2)
        {
          case 0:
            if ((long) num1 >= (long) size)
            {
              num2 = 2;
              continue;
            }
            this.a.Write((byte) 0);
            ++num1;
            if (1 == 0)
              ;
            num2 = 3;
            continue;
          case 1:
          case 3:
            num2 = 0;
            continue;
          case 2:
            goto label_8;
          default:
            goto label_2;
        }
      }
label_8:;
    }

    private void a(Signature32 A_0, IBinarizable A_1)
    {
      if (1 == 0)
        ;
      int blockContentsSize = A_1.GetBlockContentsSize((int) this.c + BinaryBlockHeader.Length);
      int num = GlCm.ROUND_UP(blockContentsSize, 4);
      this.a.Write((object) new BinaryBlockHeader()
      {
        Kind = A_0,
        Size = (uint) (BinaryBlockHeader.Length + num)
      });
      A_1.Write(this.a);
      this.WritePadding((uint) (num - blockContentsSize));
      this.c = (uint) this.a.BaseStream.Position;
      ++this.d;
    }
  }
}
