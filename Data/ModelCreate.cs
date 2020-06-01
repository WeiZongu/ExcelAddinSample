using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using ExcelAddInSample.Utils;
using ExcelAddInSample.Com;

namespace ExcelAddInSample.Data
{
    public class ModeleCreate
    {
        public string URL { get; } = "http://api.aaa.co.jp/api/???/";
        public string RefererURL { get; } = "http://aaa.co.jp/v2/";
        public string ApiKey { get; } = "abc";
        public string ApiSecret { get; } = "abc";
        public ModelCreateRequestData modelCreateReqData = new ModelCreateRequestData();
        public StringContent jsonContent;
        public double TimeOut { get; } = 7200;

        public ModeleCreate(InputFormData<ModelCreateRequestRaram> iData)
        {
            SettingData setting = SettingDataCommand.LoadFile(iData.SettingFile);
            ApiKey = setting.ApiKey;
            ApiSecret = setting.ApiSecret;

            modelCreateReqData.Key = ApiKey;
            modelCreateReqData.Secret = ApiSecret;
            modelCreateReqData.WaitTime = (int)TimeOut;

        }

        public string Request(string json)
        {
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(TimeOut);
            jsonContent = new StringContent(json, Encoding.GetEncoding("utf-8"), @"application/json");
            return "OK";
        }
    }

    [DataContract]
    public class ModelCreateRequestData
    {
        public ModelCreateRequestData()
        {
            Param = new ModelCreateParam();
        }

        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "secret")]
        public string Secret { get; set; }

        [DataMember(Name = "wait_time")]
        public int WaitTime { get; set; } = 7200;

        [DataMember(Name = "param")]
        public ModelCreateParam Param { get; set; }
    }

    [DataContract]
    public class ModelCreateParam
    {
        public ModelCreateParam()
        {
        }
    }

    [DataContract]
    public class ModelCreateResponseData
    {
        public ModelCreateResponseData()
        {
            MessageArgs = new List<string>();
            Result = new ModelCreateResponseResultData();
        }

        [DataMember(Name = "task_id")]
        public string TaskId { get; set; }

        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "message_args")]
        public List<string> MessageArgs { get; set; }

        [DataMember(Name = "result")]
        public ModelCreateResponseResultData Result { get; set; }
    }

    [DataContract]
    public class ModelCreateResponseDataSub
    {
        public ModelCreateResponseDataSub()
        {
            MessageArgs = new List<string>();
            Result = new ModelCreateResponseResultDataSub();
        }

        [DataMember(Name = "task_id")]
        public string TaskId { get; set; }

        [DataMember(Name = "code")]
        public string Code { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "message_args")]
        public List<string> MessageArgs { get; set; }

        [DataMember(Name = "result")]
        public ModelCreateResponseResultDataSub Result { get; set; }
    }

    [DataContract]
    public class ModelCreateResponseResultData
    {
        public ModelCreateResponseResultData()
        {
        }
    }

    [DataContract]
    public class ModelCreateResponseResultDataSub
    {
        public ModelCreateResponseResultDataSub()
        {
        }
    }

    public class ModelCreateCommand
    {
        public static ModelCreateResultData ModelCreate(InputFormData<ModelCreateRequestRaram> paras)
        {
            ModeleCreate create = new ModeleCreate(paras);
            string json = JsonUtility.Serialize(create.modelCreateReqData, true);
            var task = create.Request(json);

            if (task == "NG")
            {
                string msg = "HTTP Response Status Code:500\r\nHTTP Response Status Reason:NG";
                throw new Exception(msg);
            }

            int mType = MsgBox.ResponseMsgBoxShow("1", "OK", null);

            var rsltData = new ModelCreateResultData()
            {
                MsgType = mType,
            };

            return rsltData;
        }
    }

    public class ModelCreateRequestRaram
    {
        public string ModelName { get; set; }
        public string ModelID { get; set; }
        public Dictionary<string, string> ParamDict = new Dictionary<string, string>();
        public string Yname { get; set; }
        public List<string> ExCludeList = new List<string>();
        public string Purpose { get; set; }
    }

    public class ModelCreateResultData
    {
        public int MsgType { get; set; }
        public ModelCreateResponseData Data { get; set; }
        public ModelCreateResponseDataSub SubData { get; set; }
    }
}
