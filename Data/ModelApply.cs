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
    public class ModeleApply
    {
        public string URL { get; } = "http://api.aaa.co.jp/api/???";
        public string RefererURL { get; } = "http://aaa.co.jp/v2/";
        public string ApiKey { get; } = "abc";
        public string ApiSecret { get; } = "abc";
        public ModelApplyRequestData modelApplyReqData = new ModelApplyRequestData();
        public StringContent jsonContent;
        public double TimeOut { get; } = 7200;

        public ModeleApply(InputFormData<ModelApplyRequestRaram> iData)
        {
            SettingData setting = SettingDataCommand.LoadFile(iData.SettingFile);
            ApiKey = setting.ApiKey;
            ApiSecret = setting.ApiSecret;

            modelApplyReqData.Key = ApiKey;
            modelApplyReqData.Secret = ApiSecret;
            modelApplyReqData.WaitTime = (int)TimeOut;
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
    public class ModelApplyRequestData
    {
        public ModelApplyRequestData()
        {
            Param = new ModelApplyParam();
        }

        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "secret")]
        public string Secret { get; set; }

        [DataMember(Name = "wait_time")]
        public int WaitTime { get; set; } = 7200;

        [DataMember(Name = "param")]
        public ModelApplyParam Param { get; set; }
    }

    [DataContract]
    public class ModelApplyParam
    {
    }

    [DataContract]
    public class ModelApplyResponseData
    {
        public ModelApplyResponseData()
        {
            MessageArgs = new List<string>();
            Result = new ModelApplyResponseResultData();
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
        public ModelApplyResponseResultData Result { get; set; }
    }

    [DataContract]
    public class ModelApplyResponseResultData
    {
        [DataMember(Name = "model_id")]
        public string ModelID { get; set; }

        [DataMember(Name = "result_file")]
        public string ResultFile { get; set; }
    }

    public class ModelApplyCommand
    {
        public static ModelApplyResultData ModelApplied(InputFormData<ModelApplyRequestRaram> reqRaram)
        {
            ModeleApply create = new ModeleApply(reqRaram);
            var task = "OK";
            if (task == "NG")
            {
                string msg = "HTTP Response Status Code:500\r\nHTTP Response Status Reason:NG";
                throw new Exception(msg);
            }

            int mType = MsgBox.ResponseMsgBoxShow("1", "OK", null);
            var rsltData = new ModelApplyResultData
            {
                MsgType = mType
            };

            return rsltData;
        }
    }

    public class ModelApplyRequestRaram
    {
        public string ModelID { get; set; }
        public string DsName { get; set; }
        public string SettingFilePath { get; set; }
    }

    public class ModelApplyResultData
    {
        public int MsgType { get; set; }
        public string ResultFileLink { get; set; }
    }
}
