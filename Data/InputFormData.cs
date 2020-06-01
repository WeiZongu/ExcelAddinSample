using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelAddInSample.Data
{
    public class InputFormData<T>
    {
        public FileInfo SettingFile { get; set; }
        public T RequestParam { get; set; }
        public FileInfo ModelIdFile { get; set; }
        public Excel.Worksheet ActiveSh { get; set; }
        public string BookPath { get; set; }
    }
}
