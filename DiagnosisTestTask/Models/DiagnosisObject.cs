using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosisTestTask.Models
{
    public class DiagnosisObject
    {
        public string Name { get; set; }
        public double Distance { get; set; }
        public double Angle { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public bool IsDefect { get; set; }

        public DiagnosisObject(string name, double distance, double angle, double width, double height, bool isDefect)
        {
            Name = name;
            Distance = distance;
            Angle = angle;
            Width = width;
            Height = height;
            IsDefect = isDefect;
        }
    }
}
