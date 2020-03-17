//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2020 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using GameFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace UnityGameFramework.Editor.DataTableTools2
{
    public sealed partial class DataTableProcessor
    {
        public static class DataProcessorUtility
        {
            private static readonly IDictionary<string, DataProcessor> s_DataProcessors = new SortedDictionary<string, DataProcessor>();

            private static readonly string[] DataProcessorAssemblyNames =
            {
    #if UNITY_2017_3_OR_NEWER
                "UnityGameFramework.Editor",
    #endif
                "GameMain.Editor"
            };

            static DataProcessorUtility()
            {
                System.Type dataProcessorBaseType = typeof(DataProcessor);
               
                System.Type[] types = Utility.Assembly.GetTypes(DataProcessorAssemblyNames);
                for (int i = 0; i < types.Length; i++)
                {
                    if (!types[i].IsClass || types[i].IsAbstract)
                    {
                        continue;
                    }

                    if (dataProcessorBaseType.IsAssignableFrom(types[i]))
                    {
                        DataProcessor dataProcessor = (DataProcessor)Activator.CreateInstance(types[i]);

                        if (dataProcessor.ContentType == ContentType.Value)
                        {
                            s_DataProcessors.Add(dataProcessor.LanguageKeyword.ToLower(), dataProcessor);

                            dataProcessor = (DataProcessor)Activator.CreateInstance(types[i]);

                            dataProcessor.IsList = true;
                            s_DataProcessors.Add(Const.ListTypePrefix + dataProcessor.LanguageKeyword.ToLower(), dataProcessor);
                        }
                        else if (dataProcessor.ContentType == ContentType.ID)
                        {
                            s_DataProcessors.Add(Const.IDSign, dataProcessor);

                        }
                        else if (dataProcessor.ContentType == ContentType.Comment)
                        {
                            s_DataProcessors.Add(Const.CommentSign, dataProcessor);
                            s_DataProcessors.Add("", dataProcessor);

                        }

                    }
                }
            }


            public static DataProcessor GetDataProcessor(string type)
            {
                if (type == null)
                {
                    type = string.Empty;
                }

                DataProcessor dataProcessor = null;
                if (s_DataProcessors.TryGetValue(type.ToLower(), out dataProcessor))
                {
                    return dataProcessor;
                }

                throw new GameFrameworkException(Utility.Text.Format("Not supported data processor type '{0}'.", type));
            }
        }
    }
}
