using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using ExcelAddInSample.Utils;
using System.Windows.Forms;

namespace ExcelAddInSample.Com
{
    static class XlsOperation
    {
        static public List<List<object>> SelectRangeToList(Excel.Range range, Dictionary<object, object>titleDict, Excel.Worksheet activeSh)
        {
            List<List<object>> list = new List<List<object>>();
            string adr = range.Address[ReferenceStyle: Excel.XlReferenceStyle.xlR1C1];
            string sRow = "";
            string eRow = "";
            string sCol = "";
            string eCol = "";
            if (adr.Contains(":"))
            {
                string[] adrs = adr.Split(':');
                if (!adrs[0].Contains("R") && adrs[0].Contains("C"))
                {
                    sCol = adrs[0].Substring(adrs[0].IndexOf("C") + 1);
                    eCol = adrs[1].Substring(adrs[1].IndexOf("C") + 1);

                }
                else if (adrs[0].Contains("R") && !adrs[0].Contains("C"))
                {
                    sRow = adrs[0].Substring(adrs[0].IndexOf("R") + 1);
                    eRow = adrs[1].Substring(adrs[1].IndexOf("R") + 1);
                }
                else
                {
                    sRow = adrs[0].Substring(adrs[0].IndexOf("R") + 1, adrs[0].IndexOf("C") - 1 - adrs[0].IndexOf("R"));
                    eRow = adrs[1].Substring(adrs[1].IndexOf("R") + 1, adrs[1].IndexOf("C") - 1 - adrs[1].IndexOf("R"));
                    sCol = adrs[0].Substring(adrs[0].IndexOf("C") + 1);
                    eCol = adrs[1].Substring(adrs[1].IndexOf("C") + 1);
                }
            }
            else
            {
                sRow = adr.Substring(adr.IndexOf("R") + 1, adr.IndexOf("C") - 1 - adr.IndexOf("R"));
                sCol = adr.Substring(adr.IndexOf("C") + 1);
                eCol = sCol;
                eRow = sRow;
            }
            if (!int.TryParse(sRow, out int isRow))
            {
                isRow = activeSh.UsedRange.Row;
            }
            if (!int.TryParse(eRow, out int ieRow))
            {
                ieRow = activeSh.UsedRange.Rows.Count;
            }
            int maxUsedRow = activeSh.UsedRange.Rows.Count + (activeSh.UsedRange.Row - 1);
            if (ieRow > maxUsedRow)
            {
                ieRow = maxUsedRow;
            }
            if (!int.TryParse(sCol, out int isCol))
            {
                isCol = 1;
            }
            int minUsedCol = activeSh.UsedRange.Column;
            if (!int.TryParse(eCol, out int ieCol))
            {
                ieCol = activeSh.UsedRange.Columns.Count;
            }
            int maxUsedCol = activeSh.UsedRange.Columns.Count + (activeSh.UsedRange.Column - 1);
            if (ieCol > maxUsedCol)
            {
                ieCol = maxUsedCol;
            }

            if (!IsSelectedRangeExistInTitle(range, titleDict))
            {
                List<object> title = new List<object>();

                int startCol = isCol;
                if (minUsedCol >= isCol)
                {
                    startCol = minUsedCol;
                }

                for (int i = startCol; i <= ieCol; i++)
                {
                    if (!titleDict.TryGetValue(i, out object val))
                    {
                        throw new Exception(String.Format("項目名が見つかりません。\r\nCol = {0}", i));
                    }
                    title.Add(val);
                }

                list.Add(title);
            }

            int nullRowCount = 0;
            for (int row = 1; row <= range.Rows.Count; row++)
            {
                List<object> cols = new List<object>();
                int nullColCount = 0;
                for (int col = 1; col <= range.Columns.Count; col++)
                {
                    if (titleDict.TryGetValue(isCol + col - 1, out object val))
                    {
                        nullColCount = 0;
                        cols.Add(range[row, col].Value);

                        if (cols[cols.Count - 1] != null)
                        {
                            if (cols[cols.Count - 1].ToString().Contains("\""))
                            {
                                string sub = cols[cols.Count - 1].ToString();
                                sub = sub.Replace("\"", "\"\"");
                                cols[cols.Count - 1] = sub;
                            }
                        }
                        else
                        {
                            if (col < minUsedCol)
                            {
                                cols.RemoveAt(col - 1);
                            }
                        }
                    }
                    else
                    {
                        nullColCount++;
                        if (nullColCount > 10)
                        {
                            break;
                        }
                    }
                }

                bool isNonData = true;
                for (int s = 0; s < cols.Count; s++)
                {
                    if (cols[s] != null)
                    {
                        isNonData = false;
                        nullRowCount = 0;
                        break;
                    }
                }

                if (isNonData)
                {
                    nullRowCount++;
                    if (nullRowCount > 10)
                    {
                        break;
                    }
                }
                else
                {
                    list.Add(cols);
                }
            }
            return list;

        }

        static public List<List<object>> ListObjectToList(Excel.Range range)
        {
            List<List<object>> list = new List<List<object>>();
            Excel.ListObject lstObj = range.ListObject;

            for (int row = 1; row <= lstObj.Range.Rows.Count; row++)
            {
                List<object> cols = new List<object>();
                for (int col = 1; col <= lstObj.Range.Columns.Count; col++)
                {
                    cols.Add(lstObj.Range[row, col].Value);
                }

                list.Add(cols);
            }
            return list;

        }

        static public bool IsSelectedRangeExistInTitle(Excel.Range range, Dictionary<object, object> titleDict)
        {
            for (int r = 1; r <= range.Rows.Count; r++)
            {
                int nullColCount = 0;
                for (int c = 1; c <= range.Columns.Count; c++)
                {
                    if (range[r, c].Value != null)
                    {
                        if (titleDict.ContainsValue(range[r, c].Value.ToString()))
                        {
                            return true;
                        }
                    }
                    if (nullColCount > 10)
                    {
                        break;
                    }
                    nullColCount++;
                }

                if (r > 10)
                {
                    break;
                }
            }
            return false;
        }

        static public Dictionary<object, object> GetTitleDict(Excel.Worksheet sh, bool rev = false)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            int titleRow = GetStartRow(sh);
            for (int i = GetStartColumn(sh); i <= sh.Columns.Count; i++)
            {
                if (sh.Cells[titleRow, i].Value != null)
                {
                    if (!rev)
                    {
                        dict.Add(i, sh.Cells[titleRow, i].Value);
                    }
                    else
                    {
                        dict.Add(sh.Cells[titleRow, i].Value, i);
                    }
                }
                else
                {
                    break;
                }
            }

            return dict;
        }

        static public int GetStartRow(Excel.Worksheet sh)
        {
            int titleRow = 1;
            if (sh.Cells[titleRow, 2].Value == null)
            {
                string str = sh.Cells[titleRow, 1].Value;
                if (!String.IsNullOrEmpty(str) && !String.IsNullOrWhiteSpace(str) && !str.StartsWith("■"))
                {
                    return titleRow;
                }

                titleRow = 2;
                for (int t = titleRow; t <= sh.Rows.Count; t++)
                {
                    if (sh.Cells[t, 2].Value != null)
                    {
                        break;
                    }

                    if (sh.Cells[t, 1].Value != null)
                    {
                        break;
                    }

                    titleRow++;

                    if (titleRow > 10)
                    {
                        throw new Exception("開始行が見つかりません。");
                    }
                }
            }

            return titleRow;
        }

        static public int GetStartColumn(Excel.Worksheet sh)
        {
            int titleCol = 1;
            int titleRow = GetStartRow(sh);
            if (sh.Cells[titleRow, titleCol].Value == null)
            {
                titleCol = 2;
                for (int t = titleCol; t <= sh.Columns.Count; t++)
                {
                    if (sh.Cells[titleRow, t].Value != null)
                    {
                        break;
                    }
                    titleCol++;
                }
            }

            return titleCol;
        }

        static public string MakeSelectedRangeTempFile(string activeFullPath, Excel.Range selectedRange, Dictionary<object, object> dict, Excel.Worksheet activeSh)
        {
            string OpenFileFullName = Path.Combine(Path.GetDirectoryName(activeFullPath),
                Path.GetFileNameWithoutExtension(activeFullPath) + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv");

            List<List<object>> data;
            if (selectedRange.ListObject == null)
            {
                data = SelectRangeToList(selectedRange, dict, activeSh);
            }
            else
            {
                data = ListObjectToList(selectedRange);
            }

            TextUtility.WriteCSV(data, OpenFileFullName, Encoding.GetEncoding("shift-jis"));

            return OpenFileFullName;
        }

        static public void SetChartRange(string chartName, Excel.Range range, Excel.ChartObjects chObjs)
        {
            foreach (Excel.ChartObject chObj in chObjs)
            {
                if (chObj.Name.Equals(chartName))
                {
                    chObj.Chart.SetSourceData(range);
                    return;
                }
            }
        }
        static public void DeleteChart(string chartName, Excel.ChartObjects chObjs)
        {
            foreach (Excel.ChartObject chObj in chObjs)
            {
                if (chObj.Name.Equals(chartName))
                {
                    chObj.Delete();
                    return;
                }
            }
        }

        static public void SetChartDataColor(string chartName, object[,] datas, Excel.ChartObjects chObjs, int colIdx)
        {
            foreach (Excel.ChartObject chObj in chObjs)
            {
                if (chObj.Name.Equals(chartName))
                {
                    Excel.Series oSeries = chObj.Chart.SeriesCollection(1);
                    for (int i = 1; i <= datas.GetLength(0); i++)
                    {
                        object oVal = datas.GetValue(i, colIdx);
                        double val = Convert.ToDouble(oVal);
                        Excel.Point oPoint = oSeries.Points(i);
                        if (val >= 1)
                        {
                            oPoint.Format.Fill.ForeColor.RGB = 0x0000FF;
                        }
                        else if ((val < 1) && (val >= 0.5))
                        {
                            oPoint.Format.Fill.ForeColor.RGB = 0xCC99FF;
                        }
                    }
                    return;
                }
            }
        }

        static public bool CheckTopLeftNonData(Excel.Range range)
        {
            if (range[1, 1].Value == null)
            {
                return true;
            }

            string strA1 = range[1, 1].Value.ToString();
            if (strA1.StartsWith("■"))
            {
                return true;
            }

            return false;
        }
    }
}
