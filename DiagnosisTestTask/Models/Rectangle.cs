using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DiagnosisTestTask.Models
{
    public struct Rectangle
    {
        private double x;
        private double y;
        private double width;
        private double height;

        public double X => x;
        public double Y => y;
        public double Width => width;
        public double Height => height;

        public Rectangle(double x, double y, double width, double height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }
}
