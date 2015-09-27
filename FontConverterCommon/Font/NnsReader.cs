// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.NnsReader
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Runtime;
using System;
using System.IO;

namespace NintendoWare.Font
{
  public class NnsReader
  {
    private readonly ByteOrderBinaryReader a;

    public NnsReader(Stream stream)
    {
      this.a = new ByteOrderBinaryReader(stream, true);
    }

    public int ReadHeader(NnsData nnsData)
    {
      BinaryFileHeader header;
      this.a.Read<BinaryFileHeader>(out header);
      nnsData.SetHeader(header);
      return (int) header.HeaderSize;
    }

    public void ReadBlock(NnsData nnsData, Func<Signature32, IBinarizable> factory)
    {
label_2:
      if (1 == 0)
        ;
      long position = this.a.BaseStream.Position;
      BinaryBlockHeader binaryBlockHeader;
      this.a.Read<BinaryBlockHeader>(out binaryBlockHeader);
      int size = (int) binaryBlockHeader.Size - BinaryBlockHeader.Length;
      IBinarizable body = factory(binaryBlockHeader.Kind);
      int num = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
            if (body != null)
            {
              num = 1;
              continue;
            }
            goto label_7;
          case 1:
            body.Read(this.a, size);
            nnsData.SetBlock(binaryBlockHeader.Kind, body);
            num = 2;
            continue;
          case 2:
            goto label_7;
          default:
            goto label_2;
        }
      }
label_7:
      this.a.Seek((int) (position + (long) binaryBlockHeader.Size), SeekOrigin.Begin);
    }
  }
}
