namespace VectorEase.Model
{
    public class Vector3D : Vector
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
        public override string ToString() => $"({A}, {B}, {C})";
        public override double GetComponent(int input)
        {
            switch (input)
            {
                case 0:
                    return A;
                case 1: 
                    return B;
                case 2:
                    return C;
                default:
                    throw new ArgumentException("Invalid component for Vector3D.");
            }
        }
    }
}
