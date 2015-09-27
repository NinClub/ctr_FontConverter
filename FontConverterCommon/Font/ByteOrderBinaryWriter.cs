// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.ByteOrderBinaryWriter
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace NintendoWare.Font
{
  public class ByteOrderBinaryWriter : IDisposable
  {
    private BinaryWriter m_a;
    private byte[] m_ub;
    private bool c;

    public Stream BaseStream
    {
      get
      {
        return this.m_a.BaseStream;
      }
    }

    public ByteOrderBinaryWriter(Stream output, bool isLittleEndian)
    {
      if (output == null)
        throw new ArgumentNullException("output");
      if (!output.CanWrite)
        throw new ArgumentException("output not CanWrite");
      this.m_a = new BinaryWriter(output);
      this.m_ub = new byte[8];
      this.c = isLittleEndian;
    }

    public void Dispose()
    {
      this.m_a.Close();
    }

    public void Flush()
    {
      this.m_a.Flush();
    }

    public long Seek(int offset, SeekOrigin origin)
    {
      return this.m_a.Seek(offset, origin);
    }

    public void Write(bool value)
    {
      this.m_a.Write(value);
    }

    public void Write(byte value)
    {
      this.m_a.Write(value);
    }

    public void Write(sbyte value)
    {
      this.m_a.Write(value);
    }

    public void Write(byte[] buffer)
    {
      if (buffer == null)
      {
        if (1 == 0)
          ;
        throw new ArgumentNullException("buffer");
      }
      this.m_a.Write(buffer, 0, buffer.Length);
    }

    public void Write(byte[] buffer, int index, int count)
    {
      this.m_a.Write(buffer, index, count);
    }

    public void Write(short value)
    {
      this.Write((ushort) value);
    }

    public void Write(ushort value)
    {
      if (this.c)
      {
        if (1 == 0)
          ;
        this.m_a.Write(value);
      }
      else
      {
        this.m_ub[0] = (byte) ((uint) value >> 8);
        this.m_ub[1] = (byte) value;
        this.m_a.Write(this.m_ub, 0, 2);
      }
    }

    public void Write(int value)
    {
      this.Write((uint) value);
    }

    public void Write(uint value)
    {
      if (this.c)
      {
        this.m_a.Write(value);
      }
      else
      {
        if (1 == 0)
          ;
        this.m_ub[0] = (byte) (value >> 24);
        this.m_ub[1] = (byte) (value >> 16);
        this.m_ub[2] = (byte) (value >> 8);
        this.m_ub[3] = (byte) value;
        this.m_a.Write(this.m_ub, 0, 4);
      }
    }

    public void Write(long value)
    {
      this.Write((ulong) value);
    }

    public void Write(ulong value)
    {
      if (this.c)
      {
        this.m_a.Write(value);
      }
      else
      {
        if (1 == 0)
          ;
        this.m_ub[0] = (byte) (value >> 56);
        this.m_ub[1] = (byte) (value >> 48);
        this.m_ub[2] = (byte) (value >> 40);
        this.m_ub[3] = (byte) (value >> 32);
        this.m_ub[4] = (byte) (value >> 24);
        this.m_ub[5] = (byte) (value >> 16);
        this.m_ub[6] = (byte) (value >> 8);
        this.m_ub[7] = (byte) value;
        this.m_a.Write(this.m_ub, 0, 8);
      }
    }

    public void Write24Bits(uint value)
    {
      int num = 0;
      while (true)
      {
        switch (num)
        {
          case 1:
            goto label_5;
          case 2:
            this.m_ub[0] = (byte) value;
            this.m_ub[1] = (byte) (value >> 8);
            this.m_ub[2] = (byte) (value >> 16);
            num = 3;
            continue;
          case 3:
            goto label_7;
          default:
            if (this.c)
            {
              num = 2;
              continue;
            }
            this.m_ub[0] = (byte) (value >> 16);
            this.m_ub[1] = (byte) (value >> 8);
            this.m_ub[2] = (byte) value;
            num = 1;
            continue;
        }
      }
label_5:
      if (1 == 0)
        ;
label_7:
      this.m_a.Write(this.m_ub, 0, 3);
    }

    public void Write(object obj)
    {
      this.a((FieldInfo) null, obj);
    }

    private void a(FieldInfo A_0, object A_1)
    {
label_2:
      Type type = A_1.GetType();
      int num1 = 2;
      IEnumerator enumerator = null;
      FieldInfo[] fields = null;
      int index = 0;
      Type elementType = null;
      MarshalAsAttribute marshalAsAttribute = null;
      while (true)
      {
        switch (num1)
        {
          case 0:
            goto label_25;
          case 1:
            goto label_11;
          case 2:
            num1 = !type.IsPrimitive ? 12 : 8;
            continue;
          case 3:
            goto label_6;
          case 4:
            num1 = UnmanagedType.ByValArray == marshalAsAttribute.Value ? 13 : 6;
            continue;
          case 5:
            if (index < fields.Length)
            {
              FieldInfo A_0_1 = fields[index];
              this.a(A_0_1, A_0_1.GetValue(A_1));
              ++index;
              num1 = 7;
              continue;
            }
            num1 = 9;
            continue;
          case 6:
            goto label_26;
          case 7:
          case 18:
            num1 = 5;
            continue;
          case 8:
            goto label_21;
          case 9:
            goto label_45;
          case 10:
            num1 = marshalAsAttribute != null ? 4 : 0;
            continue;
          case 11:
            if (!elementType.IsPrimitive)
            {
              enumerator = ((IEnumerable) A_1).GetEnumerator();
              num1 = 14;
              continue;
            }
            num1 = 1;
            continue;
          case 12:
            if (!type.IsArray)
            {
              fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
              index = 0;
              num1 = 18;
              continue;
            }
            if (1 == 0)
              ;
            num1 = 15;
            continue;
          case 13:
            if (((Array) A_1).Length != marshalAsAttribute.SizeConst)
            {
              num1 = 16;
              continue;
            }
            elementType = type.GetElementType();
            num1 = 11;
            continue;
          case 14:
            goto label_27;
          case 15:
            num1 = 17;
            continue;
          case 16:
            goto label_5;
          case 17:
            if (A_0 != null)
            {
              marshalAsAttribute = (MarshalAsAttribute) Attribute.GetCustomAttribute((MemberInfo) A_0, typeof (MarshalAsAttribute));
              num1 = 10;
              continue;
            }
            num1 = 3;
            continue;
          default:
            goto label_2;
        }
      }
label_45:
      return;
label_5:
      throw new InvalidOperationException("Length is Invalid!");
label_6:
      throw new InvalidOperationException("fInfo required");
label_11:
      this.a(elementType, A_1);
      return;
label_21:
      this.b(type, A_1);
      return;
label_25:
      throw new InvalidOperationException("MarshalAs required");
label_26:
      throw new InvalidOperationException("ByValArray only!");
label_27:
      try
      {
        int num2 = 4;
        while (true)
        {
          switch (num2)
          {
            case 0:
              if (enumerator.MoveNext())
              {
                this.a((FieldInfo) null, enumerator.Current);
                num2 = 2;
                continue;
              }
              num2 = 1;
              continue;
            case 1:
              num2 = 3;
              continue;
            case 3:
              goto label_40;
            default:
              num2 = 0;
              continue;
          }
        }
label_40:;
      }
      finally
      {
label_36:
        IDisposable disposable = enumerator as IDisposable;
        int num2 = 1;
        while (true)
        {
          switch (num2)
          {
            case 0:
              disposable.Dispose();
              num2 = 2;
              continue;
            case 1:
              if (disposable != null)
              {
                num2 = 0;
                continue;
              }
              goto label_41;
            case 2:
              goto label_41;
            default:
              goto label_36;
          }
        }
label_41:;
      }
    }

    private void b(Type A_0, object A_1)
    {
      int num = 2;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_9;
          case 1:
            if (A_0 == typeof (uint))
            {
              num = 4;
              continue;
            }
            goto label_16;
          case 3:
            goto label_4;
          case 4:
            goto label_11;
          case 5:
            num = A_0 != typeof (short) ? 7 : 10;
            continue;
          case 6:
            goto label_14;
          case 7:
            num = A_0 != typeof (ushort) ? 11 : 6;
            continue;
          case 8:
            goto label_13;
          case 9:
            num = A_0 != typeof (byte) ? 5 : 8;
            continue;
          case 10:
            goto label_12;
          case 11:
            num = A_0 != typeof (int) ? 1 : 3;
            continue;
          default:
            num = A_0 != typeof (sbyte) ? 9 : 0;
            continue;
        }
      }
label_4:
      if (1 == 0)
        ;
      this.Write((int) A_1);
      return;
label_9:
      this.Write((sbyte) A_1);
      return;
label_11:
      this.Write((uint) A_1);
      return;
label_12:
      this.Write((short) A_1);
      return;
label_13:
      this.Write((byte) A_1);
      return;
label_14:
      this.Write((ushort) A_1);
      return;
label_16:
      throw new InvalidOperationException(string.Format("Unsupport type. - {0}", (object) A_0));
    }

    private void a(Type A_0, object A_1)
    {
label_2:
      int num = 17;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_5;
          case 1:
            num = A_0 != typeof (short) ? 10 : 8;
            continue;
          case 2:
            goto label_8;
          case 3:
            num = A_0 != typeof (int) ? 4 : 5;
            continue;
          case 4:
            if (A_0 == typeof (uint))
            {
              num = 15;
              continue;
            }
            goto label_23;
          case 5:
            num = 14;
            continue;
          case 6:
            num = 2;
            continue;
          case 7:
            num = A_0 != typeof (byte) ? 1 : 6;
            continue;
          case 8:
            num = 12;
            continue;
          case 9:
            goto label_22;
          case 10:
            num = A_0 != typeof (ushort) ? 3 : 11;
            continue;
          case 11:
            num = 16;
            continue;
          case 12:
            goto label_11;
          case 13:
            num = 0;
            continue;
          case 14:
            goto label_18;
          case 15:
            num = 9;
            continue;
          case 16:
            goto label_14;
          case 17:
            num = A_0 != typeof (sbyte) ? 7 : 13;
            continue;
          default:
            goto label_2;
        }
      }
label_5:
      Array.ForEach<sbyte>((sbyte[]) A_1, (Action<sbyte>) (A_0_2 => this.Write(A_0_2)));
      return;
label_8:
      Array.ForEach<byte>((byte[]) A_1, (Action<byte>) (A_0_2 => this.Write(A_0_2)));
      return;
label_11:
      Array.ForEach<short>((short[]) A_1, (Action<short>) (A_0_2 => this.Write(A_0_2)));
      return;
label_14:
      if (1 == 0)
        ;
      Array.ForEach<ushort>((ushort[]) A_1, (Action<ushort>) (A_0_2 => this.Write(A_0_2)));
      return;
label_18:
      Array.ForEach<int>((int[]) A_1, (Action<int>) (A_0_2 => this.Write(A_0_2)));
      return;
label_22:
      Array.ForEach<uint>((uint[]) A_1, (Action<uint>) (A_0_2 => this.Write(A_0_2)));
      return;
label_23:
      throw new InvalidOperationException(string.Format("Unsupport type. - {0}", (object) A_0));
    }
  }
}
