// Decompiled with JetBrains decompiler
// Type: NintendoWare.Font.Strings
// Assembly: FontConverterCommon, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
// MVID: ADF98CCB-6047-4F8E-B83F-CE8BF4C27920
// Assembly location: F:\Projects\3DS\CTR_SDK\tools\FontConverter\FontConverterCommon.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace NintendoWare.Font
{
  [DebuggerNonUserCode]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
  [CompilerGenerated]
  public class Strings
  {
    private static ResourceManager a;
    private static CultureInfo b;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public static ResourceManager ResourceManager
    {
      get
      {
        int num = 1;
        while (true)
        {
          switch (num)
          {
            case 0:
              goto label_6;
            case 2:
              Strings.a = new ResourceManager("NintendoWare.Font.Strings", typeof (Strings).Assembly);
              num = 0;
              continue;
            default:
              if (1 == 0)
                ;
              if (object.ReferenceEquals((object) Strings.a, (object) null))
              {
                num = 2;
                continue;
              }
              goto label_6;
          }
        }
label_6:
        return Strings.a;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public static CultureInfo Culture
    {
      get
      {
        return Strings.b;
      }
      set
      {
        Strings.b = value;
      }
    }

    public static string DisplayNameCharacterEncoding
    {
      get
      {
        return Strings.ResourceManager.GetString("DisplayNameCharacterEncoding", Strings.b);
      }
    }

    public static string DisplayNameCharacterEncodingOld
    {
      get
      {
        return Strings.ResourceManager.GetString("DisplayNameCharacterEncodingOld", Strings.b);
      }
    }

    public static string ErrorAlternateCharFormat
    {
      get
      {
        return Strings.ResourceManager.GetString("ErrorAlternateCharFormat", Strings.b);
      }
    }

    public static string ErrorNumberRange
    {
      get
      {
        return Strings.ResourceManager.GetString("ErrorNumberRange", Strings.b);
      }
    }

    public static string IDS_DEFAULT_GROUPS
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_DEFAULT_GROUPS", Strings.b);
      }
    }

    public static string IDS_ERR_ALTER_NOT_INCLUDED_LOCAL
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_ALTER_NOT_INCLUDED_LOCAL", Strings.b);
      }
    }

    public static string IDS_ERR_ALTER_NOT_INCLUDED_UNICODE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_ALTER_NOT_INCLUDED_UNICODE", Strings.b);
      }
    }

    public static string IDS_ERR_ALTER_TO_LOCAL
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_ALTER_TO_LOCAL", Strings.b);
      }
    }

    public static string IDS_ERR_ALTER_TO_UNICODE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_ALTER_TO_UNICODE", Strings.b);
      }
    }

    public static string IDS_ERR_BMP_UNSUPPORTED_BPP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_BMP_UNSUPPORTED_BPP", Strings.b);
      }
    }

    public static string IDS_ERR_CANT_OPEN
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_CANT_OPEN", Strings.b);
      }
    }

    public static string IDS_ERR_CANT_READ
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_CANT_READ", Strings.b);
      }
    }

    public static string IDS_ERR_CANT_TELL
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_CANT_TELL", Strings.b);
      }
    }

    public static string IDS_ERR_CANT_WRITE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_CANT_WRITE", Strings.b);
      }
    }

    public static string IDS_ERR_DIRECTORY_NOT_EXISTS
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_DIRECTORY_NOT_EXISTS", Strings.b);
      }
    }

    public static string IDS_ERR_ENCODING_NOT_SELECTED
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_ENCODING_NOT_SELECTED", Strings.b);
      }
    }

    public static string IDS_ERR_FAIL_CREATECOMPATIBLEBITMAP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FAIL_CREATECOMPATIBLEBITMAP", Strings.b);
      }
    }

    public static string IDS_ERR_FAIL_CREATECOMPATIBLEDC
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FAIL_CREATECOMPATIBLEDC", Strings.b);
      }
    }

    public static string IDS_ERR_FAIL_CREATEDC
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FAIL_CREATEDC", Strings.b);
      }
    }

    public static string IDS_ERR_FAIL_CREATEFONT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FAIL_CREATEFONT", Strings.b);
      }
    }

    public static string IDS_ERR_FAIL_GETCURRENTDIRECTORY
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FAIL_GETCURRENTDIRECTORY", Strings.b);
      }
    }

    public static string IDS_ERR_FAIL_GETDIBITS
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FAIL_GETDIBITS", Strings.b);
      }
    }

    public static string IDS_ERR_FAIL_GETTEXTMETRICS
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FAIL_GETTEXTMETRICS", Strings.b);
      }
    }

    public static string IDS_ERR_FAIL_INPUT_IMAGE_DETECTION
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FAIL_INPUT_IMAGE_DETECTION", Strings.b);
      }
    }

    public static string IDS_ERR_FAIL_SAVEDC
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FAIL_SAVEDC", Strings.b);
      }
    }

    public static string IDS_ERR_FAIL_SELECTFONT_NEWFONT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FAIL_SELECTFONT_NEWFONT", Strings.b);
      }
    }

    public static string IDS_ERR_FAIL_SELECTOBJECT_NEWBMP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FAIL_SELECTOBJECT_NEWBMP", Strings.b);
      }
    }

    public static string IDS_ERR_FAIL_SELECTOBJECT_NEWFONT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FAIL_SELECTOBJECT_NEWFONT", Strings.b);
      }
    }

    public static string IDS_ERR_FAIL_SELECTOBJECT_OLDBMP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FAIL_SELECTOBJECT_OLDBMP", Strings.b);
      }
    }

    public static string IDS_ERR_FAIL_SELECTOBJECT_OLDFONT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FAIL_SELECTOBJECT_OLDFONT", Strings.b);
      }
    }

    public static string IDS_ERR_FAIL_TEXTOUT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FAIL_TEXTOUT", Strings.b);
      }
    }

    public static string IDS_ERR_FILE_IS_DIRECTORY
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FILE_IS_DIRECTORY", Strings.b);
      }
    }

    public static string IDS_ERR_FILE_IS_READONLY
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FILE_IS_READONLY", Strings.b);
      }
    }

    public static string IDS_ERR_FILE_NOT_EXISTS
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FILE_NOT_EXISTS", Strings.b);
      }
    }

    public static string IDS_ERR_FILE_NOT_SPECIFIED
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FILE_NOT_SPECIFIED", Strings.b);
      }
    }

    public static string IDS_ERR_FILTER_NOT_EXISTS
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FILTER_NOT_EXISTS", Strings.b);
      }
    }

    public static string IDS_ERR_FIXED_WIDTH_NOT_SPECIFIED
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FIXED_WIDTH_NOT_SPECIFIED", Strings.b);
      }
    }

    public static string IDS_ERR_FONT_NOT_EXISTS
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FONT_NOT_EXISTS", Strings.b);
      }
    }

    public static string IDS_ERR_FONT_NOT_SPECIFIED
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FONT_NOT_SPECIFIED", Strings.b);
      }
    }

    public static string IDS_ERR_FONT_SIZE_NOT_SPECIFIED
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_FONT_SIZE_NOT_SPECIFIED", Strings.b);
      }
    }

    public static string IDS_ERR_GROUP_INDEX
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_GROUP_INDEX", Strings.b);
      }
    }

    public static string IDS_ERR_GROUP_INDEX_DUPLICATE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_GROUP_INDEX_DUPLICATE", Strings.b);
      }
    }

    public static string IDS_ERR_GROUP_NAME_INVALID_CHAR
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_GROUP_NAME_INVALID_CHAR", Strings.b);
      }
    }

    public static string IDS_ERR_GROUP_NOT_SELECTED
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_GROUP_NOT_SELECTED", Strings.b);
      }
    }

    public static string IDS_ERR_GROUP_REQUIRE_NAME
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_GROUP_REQUIRE_NAME", Strings.b);
      }
    }

    public static string IDS_ERR_ILLEGAL_BPP_PAIR
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_ILLEGAL_BPP_PAIR", Strings.b);
      }
    }

    public static string IDS_ERR_ILLEGAL_COLOR_FORMAT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_ILLEGAL_COLOR_FORMAT", Strings.b);
      }
    }

    public static string IDS_ERR_ILLEGAL_FORMAT_SYNTAX
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_ILLEGAL_FORMAT_SYNTAX", Strings.b);
      }
    }

    public static string IDS_ERR_ILLEGAL_HORIZONTAL_INFO
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_ILLEGAL_HORIZONTAL_INFO", Strings.b);
      }
    }

    public static string IDS_ERR_ILLEGAL_HYPHON
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_ILLEGAL_HYPHON", Strings.b);
      }
    }

    public static string IDS_ERR_ILLEGAL_IMAGE_SIZE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_ILLEGAL_IMAGE_SIZE", Strings.b);
      }
    }

    public static string IDS_ERR_ILLEGAL_VERTICAL_INFO
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_ILLEGAL_VERTICAL_INFO", Strings.b);
      }
    }

    public static string IDS_ERR_INVALID_ALTER
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_INVALID_ALTER", Strings.b);
      }
    }

    public static string IDS_ERR_INVALID_BMP_FILE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_INVALID_BMP_FILE", Strings.b);
      }
    }

    public static string IDS_ERR_INVALID_FILTER_FILE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_INVALID_FILTER_FILE", Strings.b);
      }
    }

    public static string IDS_ERR_INVALID_FONT_FILE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_INVALID_FONT_FILE", Strings.b);
      }
    }

    public static string IDS_ERR_INVALID_GROUP_FILE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_INVALID_GROUP_FILE", Strings.b);
      }
    }

    public static string IDS_ERR_INVALID_ORDER_FILE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_INVALID_ORDER_FILE", Strings.b);
      }
    }

    public static string IDS_ERR_INVALID_ORDER_HEIGHT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_INVALID_ORDER_HEIGHT", Strings.b);
      }
    }

    public static string IDS_ERR_INVALID_ORDER_WIDTH
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_INVALID_ORDER_WIDTH", Strings.b);
      }
    }

    public static string IDS_ERR_INVALID_SHEET_SIZE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_INVALID_SHEET_SIZE", Strings.b);
      }
    }

    public static string IDS_ERR_INVALID_SHEET_SIZE_FORMAT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_INVALID_SHEET_SIZE_FORMAT", Strings.b);
      }
    }

    public static string IDS_ERR_INVALID_SHEETPIXELS
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_INVALID_SHEETPIXELS", Strings.b);
      }
    }

    public static string IDS_ERR_INVALID_WIDTH_TYPE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_INVALID_WIDTH_TYPE", Strings.b);
      }
    }

    public static string IDS_ERR_LACK_PARAMETER
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_LACK_PARAMETER", Strings.b);
      }
    }

    public static string IDS_ERR_MULTI_WIDTHLINE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_MULTI_WIDTHLINE", Strings.b);
      }
    }

    public static string IDS_ERR_MULTIPLE_ORDER_LETTER
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_MULTIPLE_ORDER_LETTER", Strings.b);
      }
    }

    public static string IDS_ERR_NO_BASELINE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_NO_BASELINE", Strings.b);
      }
    }

    public static string IDS_ERR_NO_COLOR_FORMAT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_NO_COLOR_FORMAT", Strings.b);
      }
    }

    public static string IDS_ERR_NO_FORMAT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_NO_FORMAT", Strings.b);
      }
    }

    public static string IDS_ERR_NO_GLYPH
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_NO_GLYPH", Strings.b);
      }
    }

    public static string IDS_ERR_NON_MULTIPLY_HEIGHT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_NON_MULTIPLY_HEIGHT", Strings.b);
      }
    }

    public static string IDS_ERR_NON_MULTIPLY_WIDTH
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_NON_MULTIPLY_WIDTH", Strings.b);
      }
    }

    public static string IDS_ERR_ORDER_NOT_SELECTED
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_ORDER_NOT_SELECTED", Strings.b);
      }
    }

    public static string IDS_ERR_OUTOFRANGE_ALPHABPP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_OUTOFRANGE_ALPHABPP", Strings.b);
      }
    }

    public static string IDS_ERR_OUTOFRANGE_COLORBPP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_OUTOFRANGE_COLORBPP", Strings.b);
      }
    }

    public static string IDS_ERR_OUTOFRANGE_DEFAULTLEFTSPACE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_OUTOFRANGE_DEFAULTLEFTSPACE", Strings.b);
      }
    }

    public static string IDS_ERR_OUTOFRANGE_DEFAULTRIGHTSPACE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_OUTOFRANGE_DEFAULTRIGHTSPACE", Strings.b);
      }
    }

    public static string IDS_ERR_OUTOFRANGE_DEFAULTWIDTH
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_OUTOFRANGE_DEFAULTWIDTH", Strings.b);
      }
    }

    public static string IDS_ERR_OUTOFRANGE_LINEHEIGHT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_OUTOFRANGE_LINEHEIGHT", Strings.b);
      }
    }

    public static string IDS_ERR_OUTPUT_FORMAT_NOT_SPECIFIED
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_OUTPUT_FORMAT_NOT_SPECIFIED", Strings.b);
      }
    }

    public static string IDS_ERR_OVER_MEMORY
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_OVER_MEMORY", Strings.b);
      }
    }

    public static string IDS_ERR_OVERMAX_BASELINEPOS
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_OVERMAX_BASELINEPOS", Strings.b);
      }
    }

    public static string IDS_ERR_OVERMAX_FONTHEIGHT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_OVERMAX_FONTHEIGHT", Strings.b);
      }
    }

    public static string IDS_ERR_OVERMAX_GLYPHWIDTH
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_OVERMAX_GLYPHWIDTH", Strings.b);
      }
    }

    public static string IDS_ERR_OVERMAX_MAXCHARWIDTH
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_OVERMAX_MAXCHARWIDTH", Strings.b);
      }
    }

    public static string IDS_ERR_PALEETE_OVER_ENTRY
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_PALEETE_OVER_ENTRY", Strings.b);
      }
    }

    public static string IDS_ERR_PALETTE_NO_ENTRY
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_PALETTE_NO_ENTRY", Strings.b);
      }
    }

    public static string IDS_ERR_REQUIRE_INPUT_FORMAT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_REQUIRE_INPUT_FORMAT", Strings.b);
      }
    }

    public static string IDS_ERR_REQUIRE_OUTPUT_FORMAT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_REQUIRE_OUTPUT_FORMAT", Strings.b);
      }
    }

    public static string IDS_ERR_REQUIRE_PALETTE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_REQUIRE_PALETTE", Strings.b);
      }
    }

    public static string IDS_ERR_SAX_MSG
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_SAX_MSG", Strings.b);
      }
    }

    public static string IDS_ERR_SEEK_FROM_BEGIN
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_SEEK_FROM_BEGIN", Strings.b);
      }
    }

    public static string IDS_ERR_SEEK_FROM_CURRENT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_SEEK_FROM_CURRENT", Strings.b);
      }
    }

    public static string IDS_ERR_SEEK_FROM_END
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_SEEK_FROM_END", Strings.b);
      }
    }

    public static string IDS_ERR_TAG_MUST_BE_IN
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_TAG_MUST_BE_IN", Strings.b);
      }
    }

    public static string IDS_ERR_TGA_OVER_SIZE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_TGA_OVER_SIZE", Strings.b);
      }
    }

    public static string IDS_ERR_TGA_UNSUPPORTED_ALPHA
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_TGA_UNSUPPORTED_ALPHA", Strings.b);
      }
    }

    public static string IDS_ERR_TGA_UNSUPPORTED_BPP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_TGA_UNSUPPORTED_BPP", Strings.b);
      }
    }

    public static string IDS_ERR_TGA_UNSUPPORTED_IMAGE_DESC
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_TGA_UNSUPPORTED_IMAGE_DESC", Strings.b);
      }
    }

    public static string IDS_ERR_TGA_UNSUPPORTED_IMAGE_TYPE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_TGA_UNSUPPORTED_IMAGE_TYPE", Strings.b);
      }
    }

    public static string IDS_ERR_TGA_UNSUPPORTED_PALETTE_ENTRY
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_TGA_UNSUPPORTED_PALETTE_ENTRY", Strings.b);
      }
    }

    public static string IDS_ERR_TOO_FEW_BLOCKS
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_TOO_FEW_BLOCKS", Strings.b);
      }
    }

    public static string IDS_ERR_TYPE0
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_TYPE0", Strings.b);
      }
    }

    public static string IDS_ERR_UNDERMIN_BASELINEPOS
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNDERMIN_BASELINEPOS", Strings.b);
      }
    }

    public static string IDS_ERR_UNDERMIN_CELLHEIGHT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNDERMIN_CELLHEIGHT", Strings.b);
      }
    }

    public static string IDS_ERR_UNDERMIN_CELLWIDTH
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNDERMIN_CELLWIDTH", Strings.b);
      }
    }

    public static string IDS_ERR_UNDERMIN_FIXEDWIDTH
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNDERMIN_FIXEDWIDTH", Strings.b);
      }
    }

    public static string IDS_ERR_UNDERMIN_FONTSIZE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNDERMIN_FONTSIZE", Strings.b);
      }
    }

    public static string IDS_ERR_UNDERMIN_IMAGEHEIGHT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNDERMIN_IMAGEHEIGHT", Strings.b);
      }
    }

    public static string IDS_ERR_UNDERMIN_IMAGEWIDTH
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNDERMIN_IMAGEWIDTH", Strings.b);
      }
    }

    public static string IDS_ERR_UNEXPECTED_HEADER_SIZE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNEXPECTED_HEADER_SIZE", Strings.b);
      }
    }

    public static string IDS_ERR_UNKNONW_COLOR_FORMAT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNKNONW_COLOR_FORMAT", Strings.b);
      }
    }

    public static string IDS_ERR_UNKNONW_OPTION
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNKNONW_OPTION", Strings.b);
      }
    }

    public static string IDS_ERR_UNKNOWN_ENCODING
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNKNOWN_ENCODING", Strings.b);
      }
    }

    public static string IDS_ERR_UNKNOWN_EXCEPTION
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNKNOWN_EXCEPTION", Strings.b);
      }
    }

    public static string IDS_ERR_UNKNOWN_IMAGE_EXT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNKNOWN_IMAGE_EXT", Strings.b);
      }
    }

    public static string IDS_ERR_UNKNOWN_IMAGE_FORMAT_INT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNKNOWN_IMAGE_FORMAT_INT", Strings.b);
      }
    }

    public static string IDS_ERR_UNKNOWN_IMAGE_FORMAT_STR
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNKNOWN_IMAGE_FORMAT_STR", Strings.b);
      }
    }

    public static string IDS_ERR_UNKNOWN_INPUT_FORMAT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNKNOWN_INPUT_FORMAT", Strings.b);
      }
    }

    public static string IDS_ERR_UNKNOWN_OPTION_TYPE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNKNOWN_OPTION_TYPE", Strings.b);
      }
    }

    public static string IDS_ERR_UNKNOWN_OUTPUT_FORMAT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNKNOWN_OUTPUT_FORMAT", Strings.b);
      }
    }

    public static string IDS_ERR_UNKNOWN_WIDTH_TYPE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNKNOWN_WIDTH_TYPE", Strings.b);
      }
    }

    public static string IDS_ERR_UNSUPPORTED_BMP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNSUPPORTED_BMP", Strings.b);
      }
    }

    public static string IDS_ERR_UNSUPPORTED_VERSION
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNSUPPORTED_VERSION", Strings.b);
      }
    }

    public static string IDS_ERR_UNSUPPORTED_VERTICAL_INFO
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_UNSUPPORTED_VERTICAL_INFO", Strings.b);
      }
    }

    public static string IDS_ERR_USE_FILTER_BUT_NO_FILTER
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_USE_FILTER_BUT_NO_FILTER", Strings.b);
      }
    }

    public static string IDS_ERR_VERSION_MISMATCH
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_VERSION_MISMATCH", Strings.b);
      }
    }

    public static string IDS_ERR_WIN32_EXCEPTION
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_WIN32_EXCEPTION", Strings.b);
      }
    }

    public static string IDS_ERR_XERCESC_MSG
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_XERCESC_MSG", Strings.b);
      }
    }

    public static string IDS_ERR_XERCESC_UNKNOWN
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERR_XERCESC_UNKNOWN", Strings.b);
      }
    }

    public static string IDS_ERROR
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERROR", Strings.b);
      }
    }

    public static string IDS_ERROR_HR
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERROR_HR", Strings.b);
      }
    }

    public static string IDS_ERROR_MSG
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERROR_MSG", Strings.b);
      }
    }

    public static string IDS_ERRORTYPE_BMP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERRORTYPE_BMP", Strings.b);
      }
    }

    public static string IDS_ERRORTYPE_CMDLINE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERRORTYPE_CMDLINE", Strings.b);
      }
    }

    public static string IDS_ERRORTYPE_FIO
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERRORTYPE_FIO", Strings.b);
      }
    }

    public static string IDS_ERRORTYPE_FONT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERRORTYPE_FONT", Strings.b);
      }
    }

    public static string IDS_ERRORTYPE_IMAGE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERRORTYPE_IMAGE", Strings.b);
      }
    }

    public static string IDS_ERRORTYPE_INTERNAL
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERRORTYPE_INTERNAL", Strings.b);
      }
    }

    public static string IDS_ERRORTYPE_NULL
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERRORTYPE_NULL", Strings.b);
      }
    }

    public static string IDS_ERRORTYPE_PARAMETER
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERRORTYPE_PARAMETER", Strings.b);
      }
    }

    public static string IDS_ERRORTYPE_TGA
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERRORTYPE_TGA", Strings.b);
      }
    }

    public static string IDS_ERRORTYPE_XML
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_ERRORTYPE_XML", Strings.b);
      }
    }

    public static string IDS_EXEC_BUTTON_CONVERTING
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_EXEC_BUTTON_CONVERTING", Strings.b);
      }
    }

    public static string IDS_EXEC_BUTTON_DEFAULT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_EXEC_BUTTON_DEFAULT", Strings.b);
      }
    }

    public static string IDS_INWIN_FORMAT_I1
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_INWIN_FORMAT_I1", Strings.b);
      }
    }

    public static string IDS_INWIN_FORMAT_I4
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_INWIN_FORMAT_I4", Strings.b);
      }
    }

    public static string IDS_INWIN_FORMAT_I8
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_INWIN_FORMAT_I8", Strings.b);
      }
    }

    public static string IDS_INWIN_WIDTHTYPE_FIXED_WIDTH
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_INWIN_WIDTHTYPE_FIXED_WIDTH", Strings.b);
      }
    }

    public static string IDS_INWIN_WIDTHTYPE_GLYPH_ONLY
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_INWIN_WIDTHTYPE_GLYPH_ONLY", Strings.b);
      }
    }

    public static string IDS_INWIN_WIDTHTYPE_GLYPH_ONLY_KEEPSP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_INWIN_WIDTHTYPE_GLYPH_ONLY_KEEPSP", Strings.b);
      }
    }

    public static string IDS_INWIN_WIDTHTYPE_INCLUDE_MARGIN
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_INWIN_WIDTHTYPE_INCLUDE_MARGIN", Strings.b);
      }
    }

    public static string IDS_LICENSE_WARNING_MSG
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_LICENSE_WARNING_MSG", Strings.b);
      }
    }

    public static string IDS_LICENSE_WARNING_TITLE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_LICENSE_WARNING_TITLE", Strings.b);
      }
    }

    public static string IDS_MSG_OVERWRITE_FILE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_MSG_OVERWRITE_FILE", Strings.b);
      }
    }

    public static string IDS_MSG_OVERWRITE_FILE_TITLE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_MSG_OVERWRITE_FILE_TITLE", Strings.b);
      }
    }

    public static string IDS_NOW_READING
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_NOW_READING", Strings.b);
      }
    }

    public static string IDS_OUTIMAGE_FORMAT_BMP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_OUTIMAGE_FORMAT_BMP", Strings.b);
      }
    }

    public static string IDS_OUTIMAGE_FORMAT_EXT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_OUTIMAGE_FORMAT_EXT", Strings.b);
      }
    }

    public static string IDS_OUTIMAGE_FORMAT_TGA
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_OUTIMAGE_FORMAT_TGA", Strings.b);
      }
    }

    public static string IDS_OUTNITRO_SHEETPIXELS_1024KP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_OUTNITRO_SHEETPIXELS_1024KP", Strings.b);
      }
    }

    public static string IDS_OUTNITRO_SHEETPIXELS_128KP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_OUTNITRO_SHEETPIXELS_128KP", Strings.b);
      }
    }

    public static string IDS_OUTNITRO_SHEETPIXELS_16KP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_OUTNITRO_SHEETPIXELS_16KP", Strings.b);
      }
    }

    public static string IDS_OUTNITRO_SHEETPIXELS_256KP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_OUTNITRO_SHEETPIXELS_256KP", Strings.b);
      }
    }

    public static string IDS_OUTNITRO_SHEETPIXELS_32KP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_OUTNITRO_SHEETPIXELS_32KP", Strings.b);
      }
    }

    public static string IDS_OUTNITRO_SHEETPIXELS_512KP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_OUTNITRO_SHEETPIXELS_512KP", Strings.b);
      }
    }

    public static string IDS_OUTNITRO_SHEETPIXELS_64KP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_OUTNITRO_SHEETPIXELS_64KP", Strings.b);
      }
    }

    public static string IDS_OUTNITRO_SHEETPIXELS_AUTO
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_OUTNITRO_SHEETPIXELS_AUTO", Strings.b);
      }
    }

    public static string IDS_STATUS_CANCELED
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_STATUS_CANCELED", Strings.b);
      }
    }

    public static string IDS_STATUS_ERROR
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_STATUS_ERROR", Strings.b);
      }
    }

    public static string IDS_STATUS_FINISH
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_STATUS_FINISH", Strings.b);
      }
    }

    public static string IDS_STATUS_INITIAL
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_STATUS_INITIAL", Strings.b);
      }
    }

    public static string IDS_STATUS_LOAD_FILTER
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_STATUS_LOAD_FILTER", Strings.b);
      }
    }

    public static string IDS_STATUS_LOAD_ORDER
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_STATUS_LOAD_ORDER", Strings.b);
      }
    }

    public static string IDS_STATUS_PREPAIR
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_STATUS_PREPAIR", Strings.b);
      }
    }

    public static string IDS_STATUS_READ_BMP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_STATUS_READ_BMP", Strings.b);
      }
    }

    public static string IDS_STATUS_READ_NITRO
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_STATUS_READ_NITRO", Strings.b);
      }
    }

    public static string IDS_STATUS_READ_TGA
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_STATUS_READ_TGA", Strings.b);
      }
    }

    public static string IDS_STATUS_READ_WIN
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_STATUS_READ_WIN", Strings.b);
      }
    }

    public static string IDS_STATUS_WRITE_BMP
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_STATUS_WRITE_BMP", Strings.b);
      }
    }

    public static string IDS_STATUS_WRITE_BMP_FILE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_STATUS_WRITE_BMP_FILE", Strings.b);
      }
    }

    public static string IDS_STATUS_WRITE_NITRO
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_STATUS_WRITE_NITRO", Strings.b);
      }
    }

    public static string IDS_STATUS_WRITE_TGA
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_STATUS_WRITE_TGA", Strings.b);
      }
    }

    public static string IDS_STATUS_WRITE_TGA_FILE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_STATUS_WRITE_TGA_FILE", Strings.b);
      }
    }

    public static string IDS_WARN_CANT_REPRESENT_IN_LOCAL
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_WARN_CANT_REPRESENT_IN_LOCAL", Strings.b);
      }
    }

    public static string IDS_WARN_CANT_REPRESETN_IN_UNICODE
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_WARN_CANT_REPRESETN_IN_UNICODE", Strings.b);
      }
    }

    public static string IDS_WARN_FONT_FILTER_MISMATCH
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_WARN_FONT_FILTER_MISMATCH", Strings.b);
      }
    }

    public static string IDS_WARN_MULTIPLE_GLYPHS
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_WARN_MULTIPLE_GLYPHS", Strings.b);
      }
    }

    public static string IDS_WARN_NO_GLYPH_ORDER
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_WARN_NO_GLYPH_ORDER", Strings.b);
      }
    }

    public static string IDS_WARN_NON_WHITE_NULL
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_WARN_NON_WHITE_NULL", Strings.b);
      }
    }

    public static string IDS_WARN_OLD_FORAMT
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_WARN_OLD_FORAMT", Strings.b);
      }
    }

    public static string IDS_WARN_ONE_ALPHA
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_WARN_ONE_ALPHA", Strings.b);
      }
    }

    public static string IDS_WARN_OVER_DRAW_MARGIN
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_WARN_OVER_DRAW_MARGIN", Strings.b);
      }
    }

    public static string IDS_WARN_OVERMAX_LINEFEED
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_WARN_OVERMAX_LINEFEED", Strings.b);
      }
    }

    public static string IDS_WARN_OVERMAX_WARNING
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_WARN_OVERMAX_WARNING", Strings.b);
      }
    }

    public static string IDS_WARN_OW_OH_OB
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_WARN_OW_OH_OB", Strings.b);
      }
    }

    public static string IDS_WARN_OW_OH_OR
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_WARN_OW_OH_OR", Strings.b);
      }
    }

    public static string IDS_WARNING
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_WARNING", Strings.b);
      }
    }

    public static string IDS_WARNING_MSG
    {
      get
      {
        return Strings.ResourceManager.GetString("IDS_WARNING_MSG", Strings.b);
      }
    }

    public static string StrCharacterCode
    {
      get
      {
        return Strings.ResourceManager.GetString("StrCharacterCode", Strings.b);
      }
    }

    public static string StrEncoding
    {
      get
      {
        return Strings.ResourceManager.GetString("StrEncoding", Strings.b);
      }
    }

    public static string UIStringDefault
    {
      get
      {
        return Strings.ResourceManager.GetString("UIStringDefault", Strings.b);
      }
    }

    public static string UsageAlternateCharacter
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageAlternateCharacter", Strings.b);
      }
    }

    public static string UsageAverageWidth
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageAverageWidth", Strings.b);
      }
    }

    public static string UsageBmpFile
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageBmpFile", Strings.b);
      }
    }

    public static string UsageCellBottomMarginWidth
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageCellBottomMarginWidth", Strings.b);
      }
    }

    public static string UsageCellHeight
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageCellHeight", Strings.b);
      }
    }

    public static string UsageCellLeftMarginWidth
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageCellLeftMarginWidth", Strings.b);
      }
    }

    public static string UsageCellRightMarginWidth
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageCellRightMarginWidth", Strings.b);
      }
    }

    public static string UsageCellTopMarginWidth
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageCellTopMarginWidth", Strings.b);
      }
    }

    public static string UsageCellWidth
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageCellWidth", Strings.b);
      }
    }

    public static string UsageCharacterEncoding1
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageCharacterEncoding1", Strings.b);
      }
    }

    public static string UsageCharacterEncoding2
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageCharacterEncoding2", Strings.b);
      }
    }

    public static string UsageCharacterFilterFile
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageCharacterFilterFile", Strings.b);
      }
    }

    public static string UsageCharacterOrderFile
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageCharacterOrderFile", Strings.b);
      }
    }

    public static string UsageDefaultLeftSpace
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageDefaultLeftSpace", Strings.b);
      }
    }

    public static string UsageDefaultRightSpace
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageDefaultRightSpace", Strings.b);
      }
    }

    public static string UsageDefaultWidth
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageDefaultWidth", Strings.b);
      }
    }

    public static string UsageDontDrawGrid
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageDontDrawGrid", Strings.b);
      }
    }

    public static string UsageEnableLinearInterpolation
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageEnableLinearInterpolation", Strings.b);
      }
    }

    public static string UsageFixedWidth
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageFixedWidth", Strings.b);
      }
    }

    public static string UsageFontBinaryFile
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageFontBinaryFile", Strings.b);
      }
    }

    public static string UsageFontName
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageFontName", Strings.b);
      }
    }

    public static string UsageFontSize
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageFontSize", Strings.b);
      }
    }

    public static string UsageGlhphGroupFile
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageGlhphGroupFile", Strings.b);
      }
    }

    public static string UsageGlyphWidth1
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageGlyphWidth1", Strings.b);
      }
    }

    public static string UsageGlyphWidth2
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageGlyphWidth2", Strings.b);
      }
    }

    public static string UsageGridColor
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageGridColor", Strings.b);
      }
    }

    public static string UsageImageFile
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageImageFile", Strings.b);
      }
    }

    public static string UsageImageFileFormat1
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageImageFileFormat1", Strings.b);
      }
    }

    public static string UsageImageFileFormat2
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageImageFileFormat2", Strings.b);
      }
    }

    public static string UsageInputCase
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageInputCase", Strings.b);
      }
    }

    public static string UsageInputFormat
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageInputFormat", Strings.b);
      }
    }

    public static string UsageKPixelUnitSheetSize
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageKPixelUnitSheetSize", Strings.b);
      }
    }

    public static string UsageLinefeed
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageLinefeed", Strings.b);
      }
    }

    public static string UsageMarginColor
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageMarginColor", Strings.b);
      }
    }

    public static string UsageNullCellColor
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageNullCellColor", Strings.b);
      }
    }

    public static string UsageOptionPatterns
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageOptionPatterns", Strings.b);
      }
    }

    public static string UsageOutputFormat
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageOutputFormat", Strings.b);
      }
    }

    public static string UsageTextureFormat1
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageTextureFormat1", Strings.b);
      }
    }

    public static string UsageTextureFormat2
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageTextureFormat2", Strings.b);
      }
    }

    public static string UsageTitile
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageTitile", Strings.b);
      }
    }

    public static string UsageUseSoftAntialias
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageUseSoftAntialias", Strings.b);
      }
    }

    public static string UsageWidthLineColor
    {
      get
      {
        return Strings.ResourceManager.GetString("UsageWidthLineColor", Strings.b);
      }
    }

    internal Strings()
    {
    }
  }
}
