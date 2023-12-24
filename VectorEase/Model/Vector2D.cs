namespace VectorEase.Model
{
    public class Vector2D : IVector
    {
        public double A { get; init; }
        public double B { get; init; }
        public Vector2D(double a, double b)
        {
            A = a; B = b;
        }
        public virtual double[] ToList()
        {
            return new double[] { A, B };
        }
        public virtual string VectorToString() => $"({A}, {B})";
    }
}
