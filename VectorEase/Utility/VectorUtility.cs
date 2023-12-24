namespace VectorEase.Utility
{
    public static class VectorUtility
    {
        public static double CalculateDeterminant(double[,] matrix)
        {
            if (matrix.GetLength(0) == 2 && matrix.GetLength(1) == 2)
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            if (matrix.GetLength(0) == 3 && matrix.GetLength(1) == 3)
            {
                return matrix[0, 0] * matrix[1, 1] * matrix[2, 2] +
                       matrix[0, 1] * matrix[1, 2] * matrix[2, 0] +
                       matrix[0, 2] * matrix[1, 0] * matrix[2, 1] -
                       (
                           matrix[0, 2] * matrix[1, 1] * matrix[0, 2] +
                           matrix[0, 0] * matrix[1, 2] * matrix[2, 1] +
                           matrix[0, 1] * matrix[1, 0] * matrix[2, 2]
                       );
            }
            throw new ArgumentException("Invalid matrix format.");
        }
    }
}
