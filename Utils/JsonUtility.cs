using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using ExcelAddInSample.Data;

namespace ExcelAddInSample.Utils
{
    public class JsonUtility
    {
        /// <summary>
        /// 任意のオブジェクトを JSON メッセージへシリアライズします。
        /// </summary>
        public static string Serialize(object data, bool isDictionaryFormat = false, Type[] typs = null)
        {
            using (var stream = new MemoryStream())
            {
                var setting = new DataContractJsonSerializerSettings()
                {
                    UseSimpleDictionaryFormat = isDictionaryFormat,
                    KnownTypes = new Type[] { 
                    },
                    EmitTypeInformation = EmitTypeInformation.Never
                };

                var serializer = new DataContractJsonSerializer(data.GetType(), setting);
                serializer.WriteObject(stream, data);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        /// <summary>
        /// Jsonメッセージをオブジェクトへデシリアライズします。
        /// </summary>
        public static T Deserialize<T>(string message, bool isDictionaryFormat = false)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(message)))
            {
                var setting = new DataContractJsonSerializerSettings()
                {
                    UseSimpleDictionaryFormat = isDictionaryFormat,
                    EmitTypeInformation = EmitTypeInformation.Never

                };
                var serializer = new DataContractJsonSerializer(typeof(T), setting);
                return (T)serializer.ReadObject(stream);
            }
        }
    }
}
