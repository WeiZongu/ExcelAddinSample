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
    public class SettingData
    {
        [DataMember]
        public string ApiKey { get; set; }

        [DataMember]
        public string ApiSecret { get; set; }
    }

    public class SettingDataCommand
    {
        public static SettingData LoadFile(FileInfo file)
        {
            SettingData setting = new SettingData();
            if (file.Exists)
            {
                string data = TextUtility.ReadTXT(file.FullName, Encoding.GetEncoding("utf-8"));
                setting = JsonUtility.Deserialize<SettingData>(data);
            }

            return setting;

        }

        public static void UpdateFile(FileInfo file, SettingData data)
        {
            string json = JsonUtility.Serialize(data);
            TextUtility.WriteTXT(file.FullName, json, Encoding.GetEncoding("utf-8"));
        }
    }
}
