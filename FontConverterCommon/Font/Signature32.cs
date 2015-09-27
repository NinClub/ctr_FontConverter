// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Signature32
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;

namespace NintendoWare.Font
{
  public struct Signature32 : IEquatable<Signature32>
  {
    public byte B0;
    public byte B1;
    public byte B2;
    public byte B3;

    public Signature32(string signature)
    {
      if (signature == null)
        throw new ArgumentNullException("signature");
      if (signature.Length != 4)
        throw new ArgumentException("signature length must be 4.");
      this.B0 = (byte) signature[0];
      this.B1 = (byte) signature[1];
      this.B2 = (byte) signature[2];
      this.B3 = (byte) signature[3];
    }

    public Signature32(char c0, char c1, char c2, char c3)
    {
      this.B0 = (byte) c0;
      this.B1 = (byte) c1;
      this.B2 = (byte) c2;
      this.B3 = (byte) c3;
    }

    public static bool operator ==(Signature32 left, Signature32 right)
    {
      return left.Equals(right);
    }

    public static bool operator !=(Signature32 left, Signature32 right)
    {
      return !left.Equals(right);
    }

    public override bool Equals(object obj)
    {
      if (obj is Signature32)
        return this.Equals((Signature32) obj);
      return false;
    }

    public bool Equals(Signature32 other)
    {
      int num = 5;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_5;
          case 1:
            if ((int) this.B1 == (int) other.B1)
            {
              num = 2;
              continue;
            }
            goto label_12;
          case 2:
            num = 4;
            continue;
          case 3:
            num = 1;
            continue;
          case 4:
            if ((int) this.B2 == (int) other.B2)
            {
              num = 0;
              continue;
            }
            goto label_12;
          default:
            if ((int) this.B0 == (int) other.B0)
            {
              if (1 == 0)
                ;
              num = 3;
              continue;
            }
            goto label_12;
        }
      }
label_5:
      return (int) this.B3 == (int) other.B3;
label_12:
      return false;
    }

    public override int GetHashCode()
    {
      if (1 == 0)
        ;
      return (int) this.B0 << 24 | (int) this.B1 << 16 | (int) this.B2 << 8 | (int) this.B3;
    }
  }
}
