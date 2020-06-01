using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using ExcelAddInSample.Utils;

namespace ExcelAddInSample.Data
{
    [DataContract]
    public class DataSource
    {
        public DataSource()
        {
            DataSources = new Dictionary<string, string>();
        }

        [DataMember]
        public Dictionary<string, string> DataSources { get; set; }
    }

    public class DataSourceCommand
    {
        public static DataSource LoadFile(FileInfo file)
        {
            DataSource dict = new DataSource();
            if (file.Exists)
            {
                string data = TextUtility.ReadTXT(file.FullName, Encoding.GetEncoding("utf-8"));
                dict = JsonUtility.Deserialize<DataSource>(data);
            }

            return dict;

        }

        public static void UpdateFile(FileInfo file, string key, string val)
        {
            DataSource dict = LoadFile(file);

            if (!String.IsNullOrEmpty(Path.GetExtension(key)))
            {
                key = Path.GetFileNameWithoutExtension(key);
            }

            if (!dict.DataSources.ContainsKey(key))
            {
                dict.DataSources.Add(key, val);
            }
            string json = JsonUtility.Serialize(dict);
            TextUtility.WriteTXT(file.FullName, json, Encoding.GetEncoding("utf-8"));
        }
    }
}
