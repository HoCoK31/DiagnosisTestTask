using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiagnosisTestTask.Models;

namespace DiagnosisTestTask.Services.Interfaces
{
    public interface IFileService
    {
        List<DiagnosisObject> Open(string filename);
        void Save(string filename, List<DiagnosisObject> phonesList);
    }
}
