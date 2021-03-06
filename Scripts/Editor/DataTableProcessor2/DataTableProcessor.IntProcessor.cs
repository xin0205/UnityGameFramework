﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System;
using System.IO;

namespace UnityGameFramework.Editor.DataTableTools2
{
    public sealed partial class DataTableProcessor
    {
        private sealed class IntProcessor : GenericDataProcessor<int>
        {
            public override string LanguageKeyword
            {
                get
                {
                    return "int";
                }
            }

            public override DataType DataType
            {
                get
                {
                    return DataType.System;
                }
            }

            public override int Parse(string value)
            {
                return int.Parse(value);
            }

            public override void WriteOneValueToStream(BinaryWriter stream, string value)
            {
                stream.Write(Parse(value));

            }
        }
    }
}
