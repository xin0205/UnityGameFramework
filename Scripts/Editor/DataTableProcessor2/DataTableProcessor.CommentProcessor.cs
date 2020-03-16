//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System.IO;

namespace UnityGameFramework.Editor.DataTableTools2
{
    public sealed partial class DataTableProcessor
    {
        private sealed class CommentProcessor : DataProcessor
        {
            public override System.Type Type
            {
                get
                {

                    return null;
                }
            }

            public override ContentType ContentType
            {
                get
                {
                    return ContentType.Comment;
                }
            }

            public override DataType DataType
            {
                get
                {
                    return DataType.System;
                }
            }

            public override string LanguageKeyword
            {
                get
                {
                    return "string";
                }
            }

            public override void WriteOneValueToStream(BinaryWriter stream, string value)
            {
                stream.Write(value);
            }
        }
    }
}
