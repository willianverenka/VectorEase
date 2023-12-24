using VectorEase.Model;

namespace VectorEase.Validate
{
    public class Operation
    {
        public bool IsValid { get; init; }
        public Type? VectorType { get; init; }
        public int Length { get; init; }
        public Operation(double[] vectorList1, double[] vectorList2)
        {
            IsValid = HasSameSize(vectorList1, vectorList2);
            VectorType = IsValid ? GetVectorType(vectorList1) : null;
            Length = vectorList1.Length;
        }
        public Operation(double[] vectorList1, double[] vectorList2, double[] vectorList3)
        {
            IsValid = HasSameSize(vectorList1, vectorList2, vectorList3);
            VectorType = IsValid ? GetVectorType(vectorList1) : null;
        }

        private Type GetVectorType(double[] vectorList)
        {
            return vectorList.Length == 2 ? typeof(Vector2D) : typeof(Vector3D);
        }
        private bool HasSameSize(double[] vectorList1, double[] vectorList2)
        {
            return vectorList1.Length == vectorList2.Length;
        }
        private bool HasSameSize(double[] vectorList1, double[] vectorList2, double[] vectorList3)
        {
            return vectorList1.Length == vectorList2.Length && vectorList2.Length == vectorList3.Length;
        }
    }
}
