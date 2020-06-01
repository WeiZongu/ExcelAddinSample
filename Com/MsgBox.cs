using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelAddInSample.Com
{
    public class MsgBox
    {
        public static int MsgBoxShowInfo(string msg)
        {
            MessageBox.Show(msg, "ExcelAddInSample", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return 0;
        }

        public static int MsgBoxShowWarning(string msg)
        {
            MessageBox.Show(msg, "ExcelAddInSample", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return 1;
        }

        public static int MsgBoxShowErr(string msg)
        {
            MessageBox.Show(msg, "ExcelAddInSample", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return 2;
        }

        public static int ResponseMsgBoxShow(string code, string msg, List<string> subMsgs)
        {
            string str = String.Format("Response Code:{0}\r\nMessage:{1}", code, msg);
            if (subMsgs != null)
            {
                foreach (var subMsg in subMsgs)
                {
                    str = str + String.Format("\r\nSubMessage:{0}", subMsg);
                }
            }

            int mType = 0;
            long.TryParse(code, out long lCode);
            if (lCode == 1)
            {
                mType = 0;
            }
            else if ((lCode > 1) && (lCode < 9000))
            {
                mType = MsgBoxShowWarning(str);
            }
            else if (lCode >= 9000)
            {
                mType = MsgBoxShowErr(str);
            }
            else
            {
                mType = MsgBoxShowErr(str);
            }

            return mType;
        }
    }
}
