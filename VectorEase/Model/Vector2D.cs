namespace VectorEase.Model
{
    public class Vector2D : Vector
    {
        public Vector2D(double a, double b) : base(a, b)
        {
        }
        public override double[] ToList()
        {
            return new double[] { A, B };
        }
        public override string ToString() => $"({A}, {B})";
        public override double GetComponent(int input)
        {
            switch (input)
            {
                case 0: 
                    return A;
                case 1: 
                    return B;
                default: 
                    throw new ArgumentException("Invalid component for Vector2D.");
            }
        }
    }
}
