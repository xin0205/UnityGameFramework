//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System.IO;
using UnityEngine;

namespace UnityGameFramework.Editor.DataTableTools2
{
    public sealed partial class DataTableProcessor
    {
        private sealed class Vector2Processor : GenericDataProcessor<Vector2>
        {
            public override string LanguageKeyword
            {
                get
                {
                    return "Vector2";
                }
            }

            public override DataType DataType
            {
                get
                {
                    return DataType.Unity;
                }
            }

            public override Vector2 Parse(string value)
            {
                string[] splitValue = value.Split(',');
                return new Vector2(float.Parse(splitValue[0]), float.Parse(splitValue[1]));
            }

            public override void WriteOneValueToStream(BinaryWriter stream, string value)
            {
                Vector2 vector2 = Parse(value);
                stream.Write(vector2.x);
                stream.Write(vector2.y);
            }
        }
    }
}
