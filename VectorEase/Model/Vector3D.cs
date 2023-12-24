namespace VectorEase.Model
{
    public class Vector3D : Vector2D
    {
        public double C { get; init; }
        public Vector3D(double a, double b, double c) : base(a, b)
        {
            C = c;
        }
        public override double[] ToList()
        {
            return new double[] { A, B, C };
        }
        public override string VectorToString() => $"({A}, {B}, {C})";
    }
}
