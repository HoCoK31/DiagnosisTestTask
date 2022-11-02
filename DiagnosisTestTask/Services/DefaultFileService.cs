using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using DiagnosisTestTask.ExcelFiles;
using DiagnosisTestTask.ExcelFiles.Interfaces;
using DiagnosisTestTask.Models;
using DiagnosisTestTask.Services.Interfaces;

namespace DiagnosisTestTask.Services
{
    public class DefaultFileService : IFileService
    {
        public List<DiagnosisObject> Open(string filename)
        {
            List<DiagnosisObject> diagnosisObjects = new List<DiagnosisObject>();


            IExcelFile file;

            if (filename.EndsWith(".csv"))
            {
                file = new Csv();
            }
            else if (filename.EndsWith(".xlsx"))
            {
                file = new Xlsx();
            }
            else
            {
                throw new Exception("Неподходящее расширение файла!");
            }

            file.FileOpen(filename);

            try
            {
                foreach (var row in file.Rows.Skip(1))
                {
                    diagnosisObjects.Add(new DiagnosisObject(
                        row[0],
                        double.Parse(row[1]),
                        double.Parse(row[2]),
                        double.Parse(row[3]),
                        double.Parse(row[4]),
                        row[5] == "yes"));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Неверный формат данных! Проверьте файл");
            }


            return diagnosisObjects;
        }

        public void Save(string filename, List<DiagnosisObject> diagnosisObjects)
        {
            var culture = CultureInfo.InvariantCulture;
            IExcelFile file;
            if (filename.EndsWith(".csv"))
            {
                file = new Csv();
                culture = CultureInfo.CurrentCulture;
            }
            else if (filename.EndsWith(".xlsx"))
            {
                file = new Xlsx();
            }
            else
                throw new Exception("Неподдерживаемый формат файла! Укажите поддерживаемое расширение явно.");

            file.AddRow(new List<string>()
            {
                "Name",
                "Distance",
                "Angle",
                "Width",
                "Height",
                "IsDefect"
            });

            foreach (var diagnosisObject in diagnosisObjects)
            {
                file.AddRow(new List<string>()
                {
                    diagnosisObject.Name,
                    diagnosisObject.Distance.ToString(culture),
                    diagnosisObject.Angle.ToString(culture),
                    diagnosisObject.Width.ToString(culture),
                    diagnosisObject.Height.ToString(culture),
                    diagnosisObject.IsDefect ? "yes" : "no"
                });
            }

            file.FileSave(filename);
        }
    }
}
