//------------------------------------------------------------
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
        public abstract class GenericDataProcessor<T> : DataProcessor
        {
            public override System.Type Type
            {
                get
                {
                    return typeof(T);
                }

            }

            public override ContentType ContentType
            {
                get
                {
                    return ContentType.Value;
                }
            }

            public abstract T Parse(string value);

        }
    }
}
