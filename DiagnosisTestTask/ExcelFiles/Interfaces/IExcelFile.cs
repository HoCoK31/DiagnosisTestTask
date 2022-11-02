using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosisTestTask.ExcelFiles.Interfaces
{
    public interface IExcelFile
    {
        public List<List<string>> Rows { get; set; }
        public void FileOpen(string path);
        public void FileSave(string path);
        public void AddRow(List<string> cells);
    }
}
