// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.BitReader
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

namespace NintendoWare.Font
{
  public class BitReader
  {
    private byte[] a;
    private byte b;
    private int c;
    private int d;

    public BitReader(byte[] buf)
    {
      this.a = buf;
      this.c = 0;
    }

    public void NextByte()
    {
      if (this.c >= 8)
        return;
      this.c = 0;
    }

    public uint Read(int bits)
    {
label_2:
      uint num1 = 0U;
      if (1 == 0)
        ;
      int num2 = 0;
      while (true)
      {
        switch (num2)
        {
          case 0:
          case 2:
            num2 = 1;
            continue;
          case 1:
            if (bits <= 8)
            {
              num2 = 3;
              continue;
            }
            num1 = num1 << 8 | (uint) this.a(8);
            bits -= 8;
            num2 = 2;
            continue;
          case 3:
            goto label_8;
          default:
            goto label_2;
        }
      }
label_8:
      return num1 << bits | (uint) this.a(bits);
    }

    public void Skip(int bits)
    {
      int num = 2;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_6;
          case 1:
            bits -= this.c;
            this.d += bits / 8;
            bits %= 8;
            this.a();
            num = 0;
            continue;
          default:
            if (1 == 0)
              ;
            if (bits > this.c)
            {
              num = 1;
              continue;
            }
            goto label_6;
        }
      }
label_6:
      this.c -= bits;
    }

    private void a()
    {
      if (1 == 0)
        ;
      this.b = this.a[this.d++];
      this.c = 8;
    }

    private byte a(int A_0)
    {
      if (this.c < A_0)
      {
        int A_0_1 = A_0 - this.c;
        byte num = (byte) ((uint) this.a(this.c) << A_0_1);
        this.a();
        return (byte) ((uint) num | (uint) this.a(A_0_1));
      }
      if (1 == 0)
        ;
      byte num1 = (byte) ((uint) (byte) ((uint) this.b >> this.c - A_0) & (uint) (byte) ((int) byte.MaxValue >> 8 - A_0));
      this.c -= A_0;
      return num1;
    }
  }
}
