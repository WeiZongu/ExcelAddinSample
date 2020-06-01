using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelAddInSample.Com
{
    public class Library
    {
        public static Dictionary<string, string> MakeStringDict(List<string> keys, List<string>vals)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            for(int i = 0; i < keys.Count; i++)
            {
                dict.Add(keys[i], vals[i]);
            }

            return dict;
        }

        public static List<List<string>> ChangeCsvFromTxtToList(string data)
        {
            List<List<string>> list = new List<List<string>>();
            List<string> listC = new List<string>();
            string[] lineFeed = { "\r\n", "\r", "\n" };
            string[] aryR = data.Split(lineFeed, StringSplitOptions.None);
            for(int r = 0; r < aryR.Length - 1; r++)
            {
                string[] aryC = aryR[r].Split(',');
                bool isQuart = false;
                for (int c = 0; c < aryC.Length; c++)
                {
                    if (isQuart)
                    {
                        listC[listC.Count - 1] += ", " + aryC[c];
                    }
                    else
                    {
                        listC.Add(aryC[c]);
                    }

                    if (aryC[c].StartsWith("\""))
                    {
                        isQuart = true;
                        if (aryC[c].EndsWith("\""))
                        {
                            isQuart = false;
                        }
                    }
                    else if (aryC[c].EndsWith("\""))
                    {
                        isQuart = false;
                    }
                }
                list.Add(listC);
                listC = new List<string>();
            }

            return list;

        }

        public static bool TaskWating<T>(Task<T> task)
        {
            while (true)
            {
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
                if (task.IsCompleted)
                {
                    return true;
                }
            }
        }

        public static void AllCtrlSwInForm(Form form, bool onOff)
        {
            List<Control> controls = GetAllControls<Control>(form);
            foreach (var ctl in controls)
            {
                ctl.Enabled = onOff;
            }
        }
        public static List<T> GetAllControls<T>(Control top) where T : Control
        {
            List<T> buf = new List<T>();
            foreach (Control ctrl in top.Controls)
            {
                if (ctrl is T) buf.Add((T)ctrl);
                buf.AddRange(GetAllControls<T>(ctrl));
            }
            return buf;
        }
    }
}
