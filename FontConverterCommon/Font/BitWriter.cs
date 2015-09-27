// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.BitWriter
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;

namespace NintendoWare.Font
{
  public class BitWriter : IDisposable
  {
    private int a;
    private byte[] b;
    private int c;
    private byte d;

    public BitWriter(byte[] buf)
    {
      this.b = buf;
      this.a = 8;
      this.d = (byte) 0;
    }

    public void Dispose()
    {
      this.Flush();
    }

    public void Flush()
    {
      if (this.a >= 8)
        return;
      this.a();
    }

    public void Write(int bits, uint data)
    {
      int num = 1;
      while (true)
      {
        switch (num)
        {
          case 0:
            num = 3;
            continue;
          case 2:
            goto label_7;
          case 3:
            if (bits <= 8)
            {
              num = 2;
              continue;
            }
            bits -= 8;
            this.a(8, (byte) (data >> bits));
            num = 0;
            continue;
          default:
            if (1 == 0)
              goto case 0;
            else
              goto case 0;
        }
      }
label_7:
      this.a(bits, (byte) data);
    }

    public void Fill(int bits, int num, uint data)
    {
      int num1 = 2;
      while (true)
      {
        switch (num1)
        {
          case 0:
            goto label_7;
          case 1:
            num1 = 3;
            continue;
          case 3:
            if (num-- <= 0)
            {
              num1 = 0;
              continue;
            }
            this.Write(bits, data);
            num1 = 1;
            continue;
          default:
            if (1 == 0)
              goto case 1;
            else
              goto case 1;
        }
      }
label_7:;
    }

    public void Skip(int bits)
    {
      if (bits > this.a)
      {
        bits -= this.a;
        this.c += bits / 8;
        this.a = 8 - bits % 8;
        this.d = this.b[this.c];
      }
      else
      {
        if (1 == 0)
          ;
        this.a -= bits;
      }
    }

    private void a()
    {
      if (1 == 0)
        ;
      this.b[this.c++] = this.d;
      this.d = (byte) 0;
      this.a = 8;
    }

    private void a(int A_0, byte A_1)
    {
      int num = 3;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_11;
          case 1:
            goto label_5;
          case 2:
            if (this.a <= 0)
            {
              num = 4;
              continue;
            }
            goto label_10;
          case 4:
            this.a();
            num = 1;
            continue;
          default:
            if (this.a < A_0)
            {
              num = 0;
              continue;
            }
            A_1 &= (byte) ((int) byte.MaxValue >> 8 - A_0);
            this.d |= (byte) ((uint) A_1 << this.a - A_0);
            this.a -= A_0;
            if (1 == 0)
              ;
            num = 2;
            continue;
        }
      }
label_5:
      return;
label_10:
      return;
label_11:
      int A_0_1 = A_0 - this.a;
      this.a(this.a, (byte) ((uint) A_1 >> A_0_1));
      this.a(A_0_1, A_1);
    }
  }
}
