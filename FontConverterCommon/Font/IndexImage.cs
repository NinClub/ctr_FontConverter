// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.IndexImage
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System;

namespace NintendoWare.Font
{
  public class IndexImage : ImageBase
  {
    private IntColor[] a;
    private int b;

    public override bool IsIndexed
    {
      get
      {
        return true;
      }
    }

    public IndexImage()
    {
      this.b = 0;
    }

    public override ImageBase NewSameType()
    {
      return (ImageBase) new IndexImage();
    }

    public void SetGrayScaleTable(int bpp)
    {
      int num1 = 6;
      int num2 = 0;
      int index = 0;
      IntColor[] table = null;
      while (true)
      {
        switch (num1)
        {
          case 0:
            if (1 == 0)
              ;
            bpp = this.Bpp;
            num1 = 2;
            continue;
          case 1:
          case 5:
            num1 = 3;
            continue;
          case 2:
            num2 = 1 << bpp;
            table = new IntColor[num2];
            index = 0;
            num1 = 5;
            continue;
          case 3:
            if (index < num2)
            {
              byte num3 = (byte) ((num2 - index - 1) * (int) byte.MaxValue / (num2 - 1));
              table[index] = GlCm.BMP_RGB(num3, num3, num3);
              ++index;
              num1 = 1;
              continue;
            }
            num1 = 4;
            continue;
          case 4:
            goto label_11;
          default:
            if (bpp == 0)
            {
              num1 = 0;
              continue;
            }
            goto case 2;
        }
      }
label_11:
      this.SetColorTable(table, num2);
    }

    public void SetColorTable(IntColor[] table, int num)
    {
      if (1 == 0)
        ;
      Array.Resize<IntColor>(ref this.a, num);
      Array.Copy((Array) table, (Array) this.a, num);
      this.b = num;
    }

    public IntColor[] GetColorTable()
    {
      return this.a;
    }

    public int GetColorTableEntryNum()
    {
      return this.b;
    }

    public override uint GetRGB(int x, int y)
    {
      if (1 == 0)
        ;
      return (uint) this.a[/*(IntPtr) */this.GetColor(x, y)];
    }

    public override void Extract(ImageBase image, int x, int y, int width, int height)
    {
      if (1 == 0)
        ;
      base.Extract(image, x, y, width, height);
      ((IndexImage) image).SetColorTable(this.GetColorTable(), this.GetColorTableEntryNum());
    }
  }
}
