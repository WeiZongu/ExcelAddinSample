using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using ExcelAddInSample.Utils;
using ExcelAddInSample.Com;

namespace ExcelAddInSample.Data
{
    public class Upload
    {
        public string URL { get; } = "http://api.aaa.co.jp/api/ds/put/";
        public string RefererURL { get; } = "http://aaa.co.jp/v2/";
        public string ApiKey { get; } = "abc";
        public string ApiSecret { get; } = "abc";
        public double TimeOut { get; } = 7200;
        public MultipartFormDataContent formData = new MultipartFormDataContent();

        // train:モデル作成、 predict:モデル適用
        public Upload(InputFormData<UploadRequestParam> paras)
        {
            SettingData setting = SettingDataCommand.LoadFile(paras.SettingFile);
            ApiKey = setting.ApiKey;
            ApiSecret = setting.ApiSecret;

            formData.Add(new StringContent(ApiKey), "key");
            formData.Add(new StringContent(ApiSecret), "secret");
            formData.Add(new StringContent(paras.RequestParam.Method), "method");
        }

        public string Request()
        {
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(TimeOut);
            return "OK";
        }
    }

    [DataContract]
    public class UploadResponseData
    {
        public UploadResponseData()
        {
        }
    }

    public static class UploadCommand
    {
        public static UploadResultData UploadCSV(InputFormData<UploadRequestParam> iData)
        {
            Upload upload = new Upload(iData);
            var task = "OK";
            if (task == "NG")
            {
                string msg = "HTTP Response Status Code:500\r\nHTTP Response Status Reason:NG";
                throw new Exception(msg);
            }

            FileInfo file = new FileInfo(iData.RequestParam.FileFullName);

            int mType = MsgBox.ResponseMsgBoxShow("1", "a", null);

            var rsltData = new UploadResultData
            {
                MsgType = mType,
                DsName = "a"
            };

            return rsltData;
        }

    }
    public class UploadRequestParam
    {
        public string Method { get; set; }
        public string FileFullName { get; set; }
        public string ModelID { get; set; }
    }

    public class UploadResultData
    {
        public int MsgType { get; set; }
        public string DsFileName { get; set; }
        public string DsName { get; set; }
    }
}
