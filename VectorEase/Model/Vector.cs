using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorEase.Model
{
    public abstract class Vector
    {
        public double A { get; init; }
        public double B { get; init; }
        protected Vector(double a, double b)
        {
            A = a;
            B = b;
        }
        public abstract override string ToString();
        public abstract double[] ToList();
        public abstract double GetComponent(int input);
    }
}
