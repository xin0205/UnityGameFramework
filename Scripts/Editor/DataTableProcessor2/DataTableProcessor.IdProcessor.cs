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
        private sealed class IdProcessor : DataProcessor
        {
            public override System.Type Type
            {
                get
                {

                    return typeof(int);
                }
            }

            public override ContentType ContentType
            {
                get
                {
                    return ContentType.ID;
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
                    return "int";
                }
            }

            public override void WriteOneValueToStream(BinaryWriter stream, string value)
            {
                stream.Write(int.Parse(value));
            }
        }
    }
}
