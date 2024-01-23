namespace VectorEase.Utility
{
    public static class MatrixUtility
    {
        public static double CalculateDeterminant(double[,] matrix)
        {
            int rows = matrix.GetLength(0), cols = matrix.GetLength(1);
            bool isSquareMatrix = rows == cols;
            if (!isSquareMatrix)
            {
                throw new ArgumentException("Invalid matrix format.");
            }
            var handler = new DeterminantHandler(matrix);
            return handler.GetDeterminant();
        }
        private class DeterminantHandler
        {
            private readonly Dictionary<int, Func<double>> _determinantMethods;
            private readonly double[,] _matrix;
            private readonly int _size;
            public DeterminantHandler(double[,] matrix)
            {
                _matrix = matrix;
                _size = matrix.GetLength(0);
                _determinantMethods = new Dictionary<int, Func<double>>()
                {
                    { 2, GetTwoByTwoDeterminant },
                    { 3, GetThreeByThreeDeterminant }
                };
            }
            private double GetTwoByTwoDeterminant()
            {
                return _matrix[0, 0] * _matrix[1, 1] - _matrix[0, 1] * _matrix[1, 0];
            }

            private double GetThreeByThreeDeterminant()
            {
                return _matrix[0, 0] * _matrix[1, 1] * _matrix[2, 2] +
                       _matrix[0, 1] * _matrix[1, 2] * _matrix[2, 0] +
                       _matrix[0, 2] * _matrix[1, 0] * _matrix[2, 1] -
                       (_matrix[0, 2] * _matrix[1, 1] * _matrix[0, 2] +
                        _matrix[0, 0] * _matrix[1, 2] * _matrix[2, 1] +
                        _matrix[0, 1] * _matrix[1, 0] * _matrix[2, 2]);
            }

            public double GetDeterminant()
            {
                bool invalidSize = !_determinantMethods.ContainsKey(_size);
                if (invalidSize)
                    throw new ArgumentException("The matrix must be 2x2 or 3x3.");
                return _determinantMethods[_size]();
            } 
        }
    }
}
