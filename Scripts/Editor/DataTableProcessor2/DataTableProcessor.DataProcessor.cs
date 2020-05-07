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
        public abstract class DataProcessor
        {
            public bool IsList;

            public abstract System.Type Type
            {
                get;
            }

            public abstract string LanguageKeyword
            {
                get;
            }

            public abstract DataType DataType
            {
                get;
            }

            public abstract ContentType ContentType
            {
                get;
            }

            public abstract void WriteOneValueToStream(BinaryWriter stream, string value);

            public void WriteToStream(BinaryWriter stream, string value)
            {
                if (IsList)
                {
                    string[] values = value.Split(Const.ListSeparator);

                    stream.Write(values.Length);

                    foreach (string val in values)
                    {
                        WriteOneValueToStream(stream, val);
                    }

                }
                else
                {
                    WriteOneValueToStream(stream, value);
                }

            }


        }
    }
}
