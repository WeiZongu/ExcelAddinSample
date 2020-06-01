using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExcelAddInSample.Utils
{
    static class TextUtility
    {
        static public List<List<object>> ReadCSV(string path, Encoding enc)
        {
            List<List<object>> list = new List<List<object>>();
            using (StreamReader sr = new StreamReader(path, enc))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    List<object> cols = new List<object>();
                    foreach (var val in line.Split(','))
                    {
                        cols.Add(val);
                    }
                    list.Add(cols);
                }
            }
            return list;
        }

        static public void WriteCSV(List<List<object>> list, string path, Encoding enc)
        {
            using (StreamWriter sw = new StreamWriter(path, false, enc))
            {
                for (int row = 0; row < list.Count; row++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int col = 0; col < list[row].Count; col++)
                    {
                        sb.Append("\"").Append(list[row][col]).Append("\",");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    sw.WriteLine(sb);
                }
                sw.Close();
            }
        }

        static public string ReadTXT(string fileFullPath, Encoding enc)
        {
            string data = "";
            using (StreamReader sr = new StreamReader(fileFullPath, enc))
            {
                data = sr.ReadToEnd();
                sr.Close();
            }
            return data;
        }

        static public void WriteTXT(string fileFullPath, string data, Encoding enc)
        {
            using (StreamWriter sw = new StreamWriter(fileFullPath, false, enc))
            {
                sw.Write(data);
                sw.Close();
            }
        }
    }
}
