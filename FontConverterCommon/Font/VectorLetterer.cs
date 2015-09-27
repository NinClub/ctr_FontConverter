// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.VectorLetterer
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using NintendoWare.Font.Win32;
using System;

namespace NintendoWare.Font
{
  public class VectorLetterer : Letterer
  {
    private const int m_na = 17;
    private const int b = 65;
    private bool c;

    public VectorLetterer()
    {
      this.c = false;
    }

    public void SetVectorOption(bool isSoftAA)
    {
      this.c = isSoftAA;
    }

    public override bool LetterChar(Glyph glyph, ushort c)
    {
label_2:
      GLYPHMETRICS A_3 = new GLYPHMETRICS();
      bool flag = this.IsGlyphExists(c);
      int num1 = 3;
      byte[] array = null;
      Letterer.GlyphInfo glyphInfo = null;
      IndexImage indexImage = null;
      int index = 0;
      int num2 = 0;
      ABC[] pabc = null;
      bool charWidth32U = false;
      int A_2 = 0;
      uint num3 = 0;
      uint num4 = 0;
      bool charAbcWidthsU = false;
      int num5 = 0;
      long num6 = 0;
      while (true)
      {
        switch (num1)
        {
          case 0:
            this.a(array, glyphInfo);
            num1 = 12;
            continue;
          case 1:
            pabc = new ABC[1];
            charAbcWidthsU = this.GetCharABCWidthsU(this.DeviceContext, (uint) c, (uint) c, pabc);
            num1 = 7;
            continue;
          case 2:
            if ((int) num4 == -1)
            {
              num1 = 1;
              continue;
            }
            goto case 18;
          case 3:
            if (!flag)
            {
              num1 = 8;
              continue;
            }
            array = new byte[0];
            num1 = 19;
            continue;
          case 4:
            if ((int) num3 == 0)
            {
              num1 = 21;
              continue;
            }
            Array.Resize<byte>(ref array, (int) num3);
            num4 = VectorLetterer.a(this.DeviceContext, (uint) c, A_2, A_3, (int) num3, array, this.IsUnicode);
            num1 = 14;
            continue;
          case 5:
            num1 = 16;
            continue;
          case 6:
            goto label_8;
          case 7:
            if (!charAbcWidthsU)
            {
              num1 = 11;
              continue;
            }
            goto label_37;
          case 8:
            goto label_28;
          case 9:
          case 14:
            num1 = 2;
            continue;
          case 10:
            if (!charWidth32U)
            {
              num1 = 6;
              continue;
            }
            goto label_37;
          case 11:
            int[] pw = new int[1]
            {
              (int) pabc[0].abcB
            };
            charWidth32U = this.GetCharWidth32U(this.DeviceContext, (uint) c, (uint) c, pw);
            num1 = 10;
            continue;
          case 12:
            goto label_41;
          case 13:
            if (index >= array.Length)
            {
              num1 = 18;
              continue;
            }
            array[index] = (byte) 0;
            ++index;
            num1 = 25;
            continue;
          case 15:
            num5 = 5;
            goto label_22;
          case 16:
            num6 = 0L;
            break;
          case 17:
            num1 = num2 > 0 ? 24 : 5;
            continue;
          case 18:
            num2 = GlCm.ROUND_UP((int) A_3.gmBlackBoxX, 4);
            num1 = 17;
            continue;
          case 19:
            num1 = this.Bpp <= 4 ? 15 : 20;
            continue;
          case 20:
            num1 = 23;
            continue;
          case 21:
            num4 = VectorLetterer.a(this.DeviceContext, (uint) c, 0, A_3, 0, (byte[]) null, this.IsUnicode);
            A_3.gmBlackBoxX = 0U;
            A_3.gmBlackBoxY = 0U;
            num1 = 9;
            continue;
          case 22:
            if (this.c)
            {
              num1 = 0;
              continue;
            }
            goto label_41;
          case 23:
            num5 = 6;
            goto label_22;
          case 24:
            num6 = (long) num3 / (long) num2;
            break;
          case 25:
            if (1 == 0)
              goto case 26;
            else
              goto case 26;
          case 26:
            num1 = 13;
            continue;
          default:
            goto label_2;
        }
        int val2 = (int) num6;
        int num7 = Math.Max((int) A_3.gmBlackBoxY, val2);
        glyphInfo = new Letterer.GlyphInfo();
        indexImage = new IndexImage();
        glyphInfo.BmpWidth = num2;
        glyphInfo.BmpHeight = num7;
        glyphInfo.GlyphLeft = A_3.gmptGlyphOrigin.x;
        glyphInfo.CharWidth = (int) A_3.gmCellIncX;
        glyphInfo.GlyphAscent = A_3.gmptGlyphOrigin.y;
        glyphInfo.Black = (byte) ((1 << this.Bpp) - 1);
        glyphInfo.White = (byte) 0;
        num1 = 22;
        continue;
label_22:
        A_2 = num5;
        num3 = VectorLetterer.a(this.DeviceContext, (uint) c, A_2, A_3, 0, (byte[]) null, this.IsUnicode);
        num1 = 4;
        continue;
label_37:
        A_3.gmBlackBoxX = 0U;
        A_3.gmBlackBoxY = 0U;
        A_3.gmCellIncX = (short) ((long) pabc[0].abcA + (long) pabc[0].abcB + (long) pabc[0].abcC);
        A_3.gmCellIncY = (short) 0;
        A_3.gmptGlyphOrigin.x = (int) A_3.gmCellIncX;
        A_3.gmptGlyphOrigin.y = 0;
        index = 0;
        num1 = 26;
      }
label_8:
      return false;
label_28:
      return false;
label_41:
      this.a(indexImage, glyphInfo.BmpWidth, glyphInfo.BmpHeight, array);
      this.SetGlyph(glyph, indexImage, glyphInfo);
      return true;
    }

    public override void Create(ref LOGFONT logfont)
    {
label_2:
      this.DeviceContext = Gdi.CreateDC("DISPLAY", (string) null, (string) null, (object) null);
      int num = 5;
      while (true)
      {
        switch (num)
        {
          case 0:
            goto label_10;
          case 1:
          case 2:
            goto label_12;
          case 3:
            if (this.c)
            {
              num = 4;
              continue;
            }
            this.SetupFont(ref logfont);
            num = 1;
            continue;
          case 4:
            LOGFONT logFont = new LOGFONT();
            logFont = logfont;
            logFont.lfHeight *= 2;
            this.SetupFont(ref logFont);
            num = 2;
            continue;
          case 5:
            if (this.DeviceContext == IntPtr.Zero)
            {
              if (1 == 0)
                ;
              num = 0;
              continue;
            }
            num = 3;
            continue;
          default:
            goto label_2;
        }
      }
label_10:
      throw GlCm.ErrMsg(ErrorType.Internal, Strings.IDS_ERR_FAIL_CREATEDC);
label_12:
      this.CalcurateParameter();
    }

    protected override void Dispose(bool disposing)
    {
      int num = 1;
      while (true)
      {
        switch (num)
        {
          case 0:
            this.CleanupFont();
            Gdi.DeleteDC(this.DeviceContext);
            num = 4;
            continue;
          case 2:
            num = 3;
            continue;
          case 3:
            if (this.OldFont != IntPtr.Zero)
            {
              if (1 == 0)
                ;
              num = 0;
              continue;
            }
            goto label_6;
          case 4:
            goto label_4;
          default:
            if (this.DeviceContext != IntPtr.Zero)
            {
              num = 2;
              continue;
            }
            goto label_11;
        }
      }
label_4:
      return;
label_11:
      return;
label_6:;
    }

    private static uint a(IntPtr A_0, uint A_1, int A_2, GLYPHMETRICS A_3, int A_4, byte[] A_5, bool A_6)
    {
      MAT2 mat2 = new MAT2(new FIXED((ushort) 0, (short) 1), new FIXED((ushort) 0, (short) 0), new FIXED((ushort) 0, (short) 0), new FIXED((ushort) 0, (short) 1));
      if (!A_6)
        return Gdi.GetGlyphOutlineA(A_0, A_1, A_2, A_3, A_4, A_5, mat2);
      if (1 == 0)
        ;
      return Gdi.GetGlyphOutlineW(A_0, A_1, A_2, A_3, A_4, A_5, mat2);
    }

    private void a(IndexImage A_0, int A_1, int A_2, byte[] A_3)
    {
      int num1 = 23;
      int num2 = 0;
      int index1 = 0;
      int num3 = 0;
      int num4 = 0;
      int x1 = 0;
      int y1 = 0;
      int x2 = 0;
      int index2 = 0;
      int num5 = 0;
      int y2 = 0;
      int num6 = 0;
      int num7 = 0;
      while (true)
      {
        switch (num1)
        {
          case 0:
          case 11:
            num1 = 21;
            continue;
          case 1:
            goto label_19;
          case 2:
            if (y2 < A_2)
            {
              x2 = 0;
              num1 = 11;
              continue;
            }
            num1 = 17;
            continue;
          case 3:
          case 12:
            num1 = 2;
            continue;
          case 4:
            num1 = 7;
            continue;
          case 5:
            index2 = 0;
            num2 = (1 << this.Bpp) - 1;
            num1 = 22;
            continue;
          case 6:
            num6 = 17 / (num2 * 2);
            goto label_18;
          case 7:
            num6 = 0;
            goto label_18;
          case 8:
            num7 = 17 / (num4 * 2);
            break;
          case 9:
          case 18:
            num1 = 20;
            continue;
          case 10:
            ++y2;
            num1 = 12;
            continue;
          case 13:
            if (y1 < A_2)
            {
              x1 = 0;
              num1 = 18;
              continue;
            }
            num1 = 1;
            continue;
          case 14:
            num7 = 0;
            break;
          case 15:
            if (1 == 0)
              ;
            num1 = 14;
            continue;
          case 16:
            num1 = num4 > 0 ? 8 : 15;
            continue;
          case 17:
            goto label_35;
          case 19:
          case 24:
            num1 = 13;
            continue;
          case 20:
            if (x1 < A_1)
            {
              uint c = (uint) (((int) A_3[index1] + num3) * num4 / 64);
              byte a = (byte) ((ulong) (c * (uint) byte.MaxValue) / (ulong) num4);
              A_0.SetColorAlpha(x1, y1, c, a);
              ++index1;
              ++x1;
              num1 = 9;
              continue;
            }
            num1 = 25;
            continue;
          case 21:
            if (x2 < A_1)
            {
              uint c = (uint) (((int) A_3[index2] + num5) * num2 / 16);
              byte a = (byte) ((ulong) (c * (uint) byte.MaxValue) / (ulong) num2);
              A_0.SetColorAlpha(x2, y2, c, a);
              ++index2;
              ++x2;
              num1 = 0;
              continue;
            }
            num1 = 10;
            continue;
          case 22:
            num1 = num2 > 0 ? 6 : 4;
            continue;
          case 25:
            ++y1;
            num1 = 19;
            continue;
          default:
            if (this.Bpp <= 4)
            {
              num1 = 5;
              continue;
            }
            index1 = 0;
            num4 = (1 << this.Bpp) - 1;
            num1 = 16;
            continue;
        }
        num3 = num7;
        A_0.Create(A_1, A_2, 8);
        A_0.SetGrayScaleTable(this.Bpp);
        y1 = 0;
        num1 = 24;
        continue;
label_18:
        num5 = num6;
        A_0.Create(A_1, A_2, 8);
        A_0.SetGrayScaleTable(this.Bpp);
        y2 = 0;
        num1 = 3;
      }
label_35:
      return;
label_19:;
    }

    private void a(byte[] A_0, Letterer.GlyphInfo A_1)
    {
label_2:
      bool flag1 = A_1.GlyphAscent % 2 != 0;
      bool flag2 = (A_1.BmpHeight - A_1.GlyphAscent) % 2 != 0;
      int bmpWidth1 = A_1.BmpWidth;
      int num1 = 4;
      int num2 = 0;
      int index = 0;
      int num3 = 0;
      int bmpWidth2 = 0;
      bool flag3 = false;
      int bmpHeight = 0;
      int num4 = 0;
      int num5 = 0;
      int num6 = 0;
      while (true)
      {
        switch (num1)
        {
          case 0:
            goto label_53;
          case 1:
            if (num5 + 1 >= bmpHeight)
            {
              num1 = 37;
              continue;
            }
            goto case 26;
          case 2:
            num1 = 31;
            continue;
          case 3:
            num1 = 24;
            continue;
          case 4:
            if (flag1)
            {
              num1 = 9;
              continue;
            }
            goto case 28;
          case 5:
            if (num3 >= bmpWidth2)
            {
              num1 = 6;
              continue;
            }
            num2 = 0;
            num1 = 23;
            continue;
          case 6:
            index += bmpWidth1 * 2 - bmpWidth2 * 2;
            ++num5;
            num1 = 20;
            continue;
          case 7:
            num2 += (int) A_0[index + bmpWidth1 + 1];
            num1 = 12;
            continue;
          case 8:
            if (num5 >= bmpHeight)
            {
              num1 = 0;
              continue;
            }
            num3 = 0;
            num1 = 11;
            continue;
          case 9:
            num1 = 33;
            continue;
          case 10:
            flag3 = bmpWidth1 % 2 != 0;
            bmpWidth2 = A_1.BmpWidth;
            bmpHeight = A_1.BmpHeight;
            num1 = 16;
            continue;
          case 11:
          case 34:
            num1 = 5;
            continue;
          case 12:
            A_0[num4++] = (byte) ((num2 + 2) / 4);
            index += 2;
            ++num3;
            num1 = 34;
            continue;
          case 13:
            num2 += (int) A_0[index];
            num1 = 29;
            continue;
          case 14:
            num1 = 1;
            continue;
          case 15:
            if (!flag1)
            {
              num1 = 13;
              continue;
            }
            goto case 14;
          case 16:
            num1 = flag1 ? 21 : 30;
            continue;
          case 17:
            if (A_1.BmpWidth != 0)
            {
              num1 = 2;
              continue;
            }
            goto label_59;
          case 18:
            if (!flag3)
            {
              num1 = 27;
              continue;
            }
            goto case 14;
          case 19:
            if (num3 + 1 >= bmpWidth2)
            {
              num1 = 3;
              continue;
            }
            goto case 7;
          case 20:
          case 32:
            num1 = 8;
            continue;
          case 21:
            num6 = bmpWidth1;
            break;
          case 22:
            ++A_1.BmpHeight;
            num1 = 28;
            continue;
          case 23:
            if (num5 == 0)
            {
              num1 = 38;
              continue;
            }
            goto case 13;
          case 24:
            if (!flag3)
            {
              num1 = 7;
              continue;
            }
            goto case 12;
          case 25:
            if (1 == 0)
              ;
            if (!flag2)
            {
              num1 = 26;
              continue;
            }
            goto case 12;
          case 26:
            num2 += (int) A_0[index + bmpWidth1];
            num1 = 19;
            continue;
          case 27:
            num2 += (int) A_0[index + 1];
            num1 = 14;
            continue;
          case 28:
            A_1.BmpWidth = (A_1.BmpWidth + 1) / 2;
            A_1.BmpHeight = (A_1.BmpHeight + 1) / 2;
            A_1.GlyphLeft = A_1.GlyphLeft / 2;
            A_1.CharWidth = (A_1.CharWidth + 1) / 2;
            A_1.GlyphAscent = (A_1.GlyphAscent + 1) / 2;
            num1 = 17;
            continue;
          case 29:
            if (num3 + 1 >= bmpWidth2)
            {
              num1 = 35;
              continue;
            }
            goto case 27;
          case 30:
            num1 = 36;
            continue;
          case 31:
            if (A_1.BmpHeight != 0)
            {
              num1 = 10;
              continue;
            }
            goto label_55;
          case 33:
            if (flag2)
            {
              num1 = 22;
              continue;
            }
            goto case 28;
          case 35:
            num1 = 18;
            continue;
          case 36:
            num6 = 0;
            break;
          case 37:
            num1 = 25;
            continue;
          case 38:
            num1 = 15;
            continue;
          default:
            goto label_2;
        }
        index = -num6;
        num4 = 0;
        num5 = 0;
        num1 = 32;
      }
label_53:
      return;
label_59:
      return;
label_55:;
    }
  }
}
