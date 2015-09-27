// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.BinaryFile
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;
using System.IO;
using System.Security;

namespace NintendoWare.Font
{
  public class BinaryFile : FileStream
  {
    protected readonly string FilePath;

    public override long Position
    {
      get
      {
        try
        {
          if (1 == 0)
            ;
          return base.Position;
        }
        catch (IOException ex)
        {
          throw GlCm.ErrMsg(ErrorType.Fio, Strings.IDS_ERR_CANT_TELL, (object) this.FilePath);
        }
      }
      set
      {
        try
        {
          base.Position = value;
        }
        catch (IOException ex)
        {
          throw GlCm.ErrMsg(ErrorType.Fio, Strings.IDS_ERR_CANT_TELL, (object) this.FilePath);
        }
        if (1 != 0)
          ;
      }
    }

    protected BinaryFile(string fname, FileMode create, FileAccess access, FileShare share)
      : base(fname, create, access, share)
    {
      this.FilePath = fname;
    }

    public static BinaryFile Open(string fname, FileMode create, FileAccess access)
    {
      BinaryFile binaryFile;
      try
      {
        binaryFile = new BinaryFile(fname, create, access, FileShare.ReadWrite | FileShare.Delete);
        goto label_5;
      }
      catch (UnauthorizedAccessException ex)
      {
      }
      catch (SecurityException ex)
      {
      }
      catch (IOException ex)
      {
      }
      throw GlCm.ErrMsg(ErrorType.Fio, Strings.IDS_ERR_CANT_OPEN, (object) fname);
label_5:
      if (1 == 0)
        ;
      return binaryFile;
    }

    public string GetFileName()
    {
      return this.FilePath;
    }

    public override int Read(byte[] buf, int offset, int len)
    {
      try
      {
        return base.Read(buf, offset, len);
      }
      catch (IOException ex)
      {
      }
      if (1 == 0)
        ;
      throw GlCm.ErrMsg(ErrorType.Fio, Strings.IDS_ERR_CANT_READ, (object) this.FilePath);
    }

    public override void Write(byte[] buf, int offset, int len)
    {
      try
      {
        int num = 1;
        while (true)
        {
          switch (num)
          {
            case 0:
              base.Write(buf, offset, len);
              num = 2;
              continue;
            case 2:
              num = 3;
              continue;
            case 3:
              goto label_7;
            default:
              if (1 == 0)
                ;
              if (len > 0)
              {
                num = 0;
                continue;
              }
              goto case 2;
          }
        }
label_7:;
      }
      catch (IOException ex)
      {
        throw GlCm.ErrMsg(ErrorType.Fio, Strings.IDS_ERR_CANT_WRITE, (object) this.FilePath);
      }
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
      long num;
      try
      {
        num = base.Seek(offset, origin);
      }
      catch (IOException ex)
      {
        throw GlCm.ErrMsg(ErrorType.Fio, Strings.IDS_ERR_SEEK_FROM_BEGIN, (object) this.FilePath);
      }
      if (1 == 0)
        ;
      return num;
    }
  }
}
