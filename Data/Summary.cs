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
using System.IO;

namespace ExcelAddInSample.Data
{
    public class Summary
    {
        public string URL { get; } = "http://api.aaa.co.jp/api/???/";
        public string RefererURL { get; } = "http://aaa.co.jp/v2/";
        public string ApiKey { get; } = "abc";
        public string ApiSecret { get; } = "abc";
        public double TimeOut { get; } = 7200;
        public SummaryRequestData summaryReqData = new SummaryRequestData();
        public StringContent jsonContent;

        public Summary(InputFormData<SummaryRequestParam> paras)
        {
            SettingData setting = SettingDataCommand.LoadFile(paras.SettingFile);
            ApiKey = setting.ApiKey;
            ApiSecret = setting.ApiSecret;

            summaryReqData.Key = ApiKey;
            summaryReqData.Secret = ApiSecret;
            summaryReqData.WaitTime = (int)TimeOut;
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
    public class SummaryRequestData
    {
        public SummaryRequestData()
        {
            Param = new SummaryParam();
        }

        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "secret")]
        public string Secret { get; set; }

        [DataMember(Name = "wait_time")]
        public int WaitTime { get; set; } = 7200;

        [DataMember(Name = "param")]
        public SummaryParam Param { get; set; }
    }

    [DataContract]
    public class SummaryParam
    {
        public SummaryParam()
        {
        }
    }

    [DataContract]
    public class SummaryResponseData
    {
        public SummaryResponseData()
        {
            MessageArgs = new List<string>();
            Result = new SummaryResponseResultData();
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
        public SummaryResponseResultData Result { get; set; }
    }

    [DataContract]
    public class SummaryResponseResultData
    {
        public SummaryResponseResultData()
        {
        }
    }

    public class SummaryCommand
    {
        public static SummaryResultData Collection(InputFormData<SummaryRequestParam> paras)
        {
            Summary summary = new Summary(paras);
            string json = "json";
            var task = summary.Request(json);
            if (task == "NG")
            {
                string msg = "HTTP Response Status Code:500\r\nHTTP Response Status Reason:NG";
                throw new Exception(msg);
            }

            int mType = MsgBox.ResponseMsgBoxShow("1", "OK", null);

            SummaryResultData rsltData = new SummaryResultData
            {
                MsgType = mType,
                Purpose = paras.RequestParam.Purpose
            };

            return rsltData;

        }
    }

    public class SummaryResultData
    {
        public int MsgType { get; set; }
        public string Purpose { get; set; }
        public SummaryResponseData Data { get; set; }
        public string ModelName { get; set; }
        public string ModelID { get; set; }
    }

    public class SummaryRequestParam
    {
        public string ModelID { get; set; }
        public string Purpose { get; set; }
        public string Yname { get; set; }
        public Dictionary<string, string> ParamDict = new Dictionary<string, string>();
        public int IgnoreCheckY { get; set; }
    }
}
