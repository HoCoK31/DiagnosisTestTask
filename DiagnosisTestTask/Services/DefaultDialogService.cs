using DiagnosisTestTask.Services.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiagnosisTestTask.Services
{
    public class DefaultDialogService : IDialogService
    {
        public string FilePath { get; set; }

        public bool OpenFileDialog()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Таблицы csv|*.csv|Таблицы Excel|*.xlsx";
            if (openFileDialog.ShowDialog() != true) return false;
            FilePath = openFileDialog.FileName;
            return true;
        }

        public bool SaveFileDialog()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Таблицы csv|*.csv|Таблицы Excel|*.xlsx";
            if (saveFileDialog.ShowDialog() != true) return false;
            FilePath = saveFileDialog.FileName;
            return true;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
