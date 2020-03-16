using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGameFramework.Editor.DataTableTools2
{
    public enum DataType
    {
        System,
        Enum,
        Unity,
    }

    public enum ContentType
    {
        ID,
        Comment,
        Value,

    }

    public static class Const
    {
        public const string CommentSign = "#";
        public const string IDSign = "id";
        public const string ListRegexStr = @"^s_(?<type>.+)$";
        public const string ListTypePrefix = "s_";
        public const char ListSeparator = ';';
        public const char ValueSeparator = ',';
        public static readonly char[] DataSplitSeparators = new char[] { '\t' };
        public static readonly char[] DataTrimSeparators = new char[] { '\"' };
    }
}

