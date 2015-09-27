// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.ByteOrderBinaryReader
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace NintendoWare.Font
{
  public class ByteOrderBinaryReader : IDisposable
  {
    private readonly byte[] m_ub = new byte[8];
    private readonly BinaryReader m_a;
    private bool c;

    public Stream BaseStream
    {
      get
      {
        return this.m_a.BaseStream;
      }
    }

    public ByteOrderBinaryReader(Stream input, bool isLittleEndian)
    {
      if (input == null)
        throw new ArgumentNullException("input");
      this.m_a = new BinaryReader(input);
      this.c = isLittleEndian;
    }

    public void Dispose()
    {
      this.m_a.Close();
    }

    public byte ReadByte()
    {
      return this.m_a.ReadByte();
    }

    public sbyte ReadSByte()
    {
      return this.m_a.ReadSByte();
    }

    public short ReadInt16()
    {
      return (short) this.ReadUInt16();
    }

    public ushort ReadUInt16()
    {
      if (this.c)
      {
        if (1 == 0)
          ;
        return this.m_a.ReadUInt16();
      }
      this.m_a.Read(this.m_ub, 0, 2);
      return (ushort) ((uint) this.m_ub[0] << 8 | (uint) this.m_ub[1]);
    }

    public int ReadInt32()
    {
      return (int) this.ReadUInt32();
    }

    public uint ReadUInt32()
    {
      if (this.c)
      {
        if (1 == 0)
          ;
        return this.m_a.ReadUInt32();
      }
      this.m_a.Read(this.m_ub, 0, 4);
      return (uint) ((int) this.m_ub[0] << 24 | (int) this.m_ub[1] << 16 | (int) this.m_ub[2] << 8) | (uint) this.m_ub[3];
    }

    public long ReadInt64()
    {
      return (long) this.ReadUInt64();
    }

    public ulong ReadUInt64()
    {
      if (this.c)
        return this.m_a.ReadUInt64();
      if (1 == 0)
        ;
      this.m_a.Read(this.m_ub, 0, 8);
      return (ulong) ((uint) ((int) this.m_ub[4] << 24 | (int) this.m_ub[5] << 16 | (int) this.m_ub[6] << 8) | (uint) this.m_ub[7]) << 32 | (ulong) ((uint) ((int) this.m_ub[0] << 24 | (int) this.m_ub[1] << 16 | (int) this.m_ub[2] << 8) | (uint) this.m_ub[3]);
    }

    public uint Read24Bits()
    {
      this.m_a.Read(this.m_ub, 0, 3);
      if (this.c)
        return (uint) ((int) this.m_ub[2] << 16 | (int) this.m_ub[1] << 8) | (uint) this.m_ub[0];
      if (1 == 0)
        ;
      return (uint) ((int) this.m_ub[0] << 16 | (int) this.m_ub[1] << 8) | (uint) this.m_ub[2];
    }

    public void Read<T>(out T obj)
    {
      obj = (T) this.b(typeof (T));
    }

    public int Read(byte[] buffer)
    {
      return this.m_a.Read(buffer, 0, buffer.Length);
    }

    public int Read(byte[] buffer, int index, int count)
    {
      return this.m_a.Read(buffer, index, count);
    }

    public long Seek(int offset, SeekOrigin origin)
    {
      return this.m_a.BaseStream.Seek((long) offset, origin);
    }

    private object b(Type A_0)
    {
      return this.a((FieldInfo) null, A_0);
    }

    private object a(FieldInfo A_0, Type A_1)
    {
      int num = 1;
      int index1 = 0;
      Array instance = null;
      MarshalAsAttribute marshalAsAttribute = null;
      object obj1 = null;
      FieldInfo[] fields = null;
      int index2 = 0;
      Type elementType = null;
      while (true)
      {
        switch (num)
        {
          case 0:
          case 7:
            num = 3;
            continue;
          case 2:
            if (!elementType.IsPrimitive)
            {
              index1 = 0;
              num = 7;
              continue;
            }
            if (1 == 0)
              ;
            num = 9;
            continue;
          case 3:
            if (index1 >= instance.Length)
            {
              num = 17;
              continue;
            }
            instance.SetValue(this.a((FieldInfo) null, elementType), index1);
            ++index1;
            num = 0;
            continue;
          case 4:
            marshalAsAttribute = (MarshalAsAttribute) Attribute.GetCustomAttribute((MemberInfo) A_0, typeof (MarshalAsAttribute));
            num = 6;
            continue;
          case 5:
            if (UnmanagedType.ByValArray == marshalAsAttribute.Value)
            {
              elementType = A_1.GetElementType();
              instance = Array.CreateInstance(elementType, marshalAsAttribute.SizeConst);
              num = 2;
              continue;
            }
            num = 10;
            continue;
          case 6:
            num = marshalAsAttribute != null ? 5 : 11;
            continue;
          case 8:
            goto label_28;
          case 9:
            this.a(elementType, instance);
            num = 12;
            continue;
          case 10:
            goto label_26;
          case 11:
            goto label_20;
          case 12:
          case 17:
            goto label_22;
          case 13:
            if (!A_1.IsArray)
            {
              obj1 = A_1.InvokeMember((string) null, BindingFlags.CreateInstance, (Binder) null, (object) null, (object[]) null);
              fields = A_1.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
              index2 = 0;
              num = 16;
              continue;
            }
            num = 4;
            continue;
          case 14:
            if (index2 >= fields.Length)
            {
              num = 8;
              continue;
            }
            FieldInfo A_0_1 = fields[index2];
            object obj2 = this.a(A_0_1, A_0_1.FieldType);
            A_0_1.SetValue(obj1, obj2);
            ++index2;
            num = 18;
            continue;
          case 15:
            goto label_25;
          case 16:
          case 18:
            num = 14;
            continue;
          default:
            num = !A_1.IsPrimitive ? 13 : 15;
            continue;
        }
      }
label_20:
      throw new InvalidOperationException("MarshalAs required");
label_22:
      return (object) instance;
label_25:
      return this.a(A_1);
label_26:
      throw new InvalidOperationException("ByValArray only!");
label_28:
      return obj1;
    }

    private object a(Type A_0)
    {
      int num = 10;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_15;
          case 1:
            goto label_11;
          case 2:
            goto label_12;
          case 3:
            num = A_0 != typeof (int) ? 9 : 1;
            continue;
          case 4:
            if (A_0 != typeof (short))
            {
              if (1 == 0)
                ;
              num = 5;
              continue;
            }
            num = 7;
            continue;
          case 5:
            num = A_0 != typeof (ushort) ? 3 : 0;
            continue;
          case 6:
            goto label_10;
          case 7:
            goto label_13;
          case 8:
            goto label_14;
          case 9:
            if (A_0 == typeof (uint))
            {
              num = 2;
              continue;
            }
            goto label_18;
          case 11:
            num = A_0 != typeof (byte) ? 4 : 8;
            continue;
          default:
            num = A_0 != typeof (sbyte) ? 11 : 6;
            continue;
        }
      }
label_10:
      return (object) this.ReadSByte();
label_11:
      return (object) this.ReadInt32();
label_12:
      return (object) this.ReadUInt32();
label_13:
      return (object) this.ReadInt16();
label_14:
      return (object) this.ReadByte();
label_15:
      return (object) this.ReadUInt16();
label_18:
      throw new InvalidOperationException(string.Format("Unsupport type. - {0}", (object) A_0));
    }

    private void a(Type A_0, Array A_1)
    {
      int num = 34;
      int[] numArray1 = null;
      int index1 = 0;
      ushort[] numArray2 = null;
      int index2 = 0;
      byte[] numArray3 = null;
      int index3 = 0;
      uint[] numArray4 = null;
      int index4 = 0;
      short[] numArray5 = null;
      int index5 = 0;
      sbyte[] numArray6 = null;
      int index6 = 0;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_8;
          case 1:
            numArray5 = (short[]) A_1;
            index5 = 0;
            num = 12;
            continue;
          case 2:
            goto label_17;
          case 3:
          case 24:
            num = 4;
            continue;
          case 4:
            if (index1 < numArray1.Length)
            {
              numArray1[index1] = this.ReadInt32();
              ++index1;
              num = 3;
              continue;
            }
            num = 2;
            continue;
          case 5:
            num = A_0 != typeof (byte) ? 21 : 23;
            continue;
          case 6:
            if (index4 < numArray4.Length)
            {
              numArray4[index4] = this.ReadUInt32();
              ++index4;
              num = 22;
              continue;
            }
            num = 0;
            continue;
          case 7:
            numArray4 = (uint[]) A_1;
            index4 = 0;
            num = 10;
            continue;
          case 8:
            num = A_0 != typeof (ushort) ? 11 : 18;
            continue;
          case 9:
            if (index3 >= numArray3.Length)
            {
              num = 16;
              continue;
            }
            numArray3[index3] = this.ReadByte();
            ++index3;
            num = 25;
            continue;
          case 10:
            num = 6;
            continue;
          case 11:
            num = A_0 != typeof (int) ? 28 : 15;
            continue;
          case 12:
          case 19:
            num = 31;
            continue;
          case 13:
          case 26:
            num = 17;
            continue;
          case 14:
            goto label_45;
          case 15:
            numArray1 = (int[]) A_1;
            index1 = 0;
            num = 24;
            continue;
          case 16:
            goto label_23;
          case 17:
            if (index2 < numArray2.Length)
            {
              numArray2[index2] = this.ReadUInt16();
              ++index2;
              num = 26;
              continue;
            }
            num = 30;
            continue;
          case 18:
            numArray2 = (ushort[]) A_1;
            index2 = 0;
            num = 13;
            continue;
          case 20:
            goto label_32;
          case 21:
            num = A_0 != typeof (short) ? 8 : 1;
            continue;
          case 22:
            if (1 == 0)
              goto case 10;
            else
              goto case 10;
          case 23:
            numArray3 = (byte[]) A_1;
            index3 = 0;
            num = 33;
            continue;
          case 25:
          case 33:
            num = 9;
            continue;
          case 27:
          case 35:
            num = 29;
            continue;
          case 28:
            if (A_0 == typeof (uint))
            {
              num = 7;
              continue;
            }
            goto label_46;
          case 29:
            if (index6 >= numArray6.Length)
            {
              num = 14;
              continue;
            }
            numArray6[index6] = this.ReadSByte();
            ++index6;
            num = 35;
            continue;
          case 30:
            goto label_39;
          case 31:
            if (index5 < numArray5.Length)
            {
              numArray5[index5] = this.ReadInt16();
              ++index5;
              num = 19;
              continue;
            }
            num = 20;
            continue;
          case 32:
            numArray6 = (sbyte[]) A_1;
            index6 = 0;
            num = 27;
            continue;
          default:
            num = A_0 != typeof (sbyte) ? 5 : 32;
            continue;
        }
      }
label_23:
      return;
label_32:
      return;
label_39:
      return;
label_8:
      return;
label_17:
      return;
label_45:
      return;
label_46:
      throw new InvalidOperationException(string.Format("Unsupport type. - {0}", (object) A_0));
    }
  }
}
