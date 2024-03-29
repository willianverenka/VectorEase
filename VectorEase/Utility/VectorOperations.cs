﻿using VectorEase.Model;

namespace VectorEase.Utility
{
    public static class VectorOperations
    {
        public static double Magnitude(Vector2D vector)
        {
            var componentList = vector.ToList();
            return Math.Sqrt(componentList.Select(x => Math.Pow(x, 2)).Sum());
        }

        public static double Magnitude(Vector3D vector)
        {
            var componentList = vector.ToList();
            return Math.Sqrt(componentList.Select(x => Math.Pow(x, 2)).Sum());
        }

        public static Vector2D VectorSum(Vector2D vector1, Vector2D vector2)
        {
            var vector1List = vector1.ToList();
            var vector2List = vector2.ToList();
            double[] newVectorList = new double[2];
            for (int i = 0; i < newVectorList.Length; i++)
            {
                newVectorList[i] = vector1List[i] + vector2List[i];
            }

            return new Vector2D(newVectorList[0], newVectorList[1]);
        }

        public static Vector3D VectorSum(Vector3D vector1, Vector3D vector2)
        {
            var vector1List = vector1.ToList();
            var vector2List = vector2.ToList();
            double[] newVectorList = new double[3];
            for (int i = 0; i < newVectorList.Length; i++)
            {
                newVectorList[i] = vector1List[i] + vector2List[i];
            }

            return new Vector3D(newVectorList[0], newVectorList[1], newVectorList[2]);
        }

        public static double DotProduct(Vector2D vector1, Vector2D vector2)
        {
            var vector1List = vector1.ToList();
            var vector2List = vector2.ToList();
            double dotProduct = 0;
            for (int i = 0; i < vector1List.Length; i++)
            {
                dotProduct += vector1List[i] * vector2List[i];
            }

            return dotProduct;
        }

        public static double DotProduct(Vector3D vector1, Vector3D vector2)
        {
            var vector1List = vector1.ToList();
            var vector2List = vector2.ToList();
            double dotProduct = 0;
            for (int i = 0; i < vector1List.Length; i++)
            {
                dotProduct += vector1List[i] * vector2List[i];
            }

            return dotProduct;
        }

        public static Vector3D CrossProduct(Vector3D vector1, Vector3D vector2)
        {
            var v1List = vector1.ToList();
            var v2List = vector2.ToList();
            var matrix = new double[2, 3]
            {
                { v1List[0], v1List[1], v1List[2] },
                { v2List[0], v2List[1], v2List[2] }
            };
            double i = matrix[0, 1] * matrix[1, 2] - matrix[0, 2] * matrix[1, 1];
            double j = matrix[0, 2] * matrix[1, 0] - matrix[0, 0] * matrix[1, 2];
            double k = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            return new Vector3D(i, j, k);
        }

        public static Vector2D MultiplyVector(double value, Vector2D vector2D)
        {
            return new Vector2D(vector2D.A * value, vector2D.B * value);
        }

        public static Vector3D MultiplyVector(double value, Vector3D vector2D)
        {
            return new Vector3D(vector2D.A * value, vector2D.B * value, vector2D.C * value);
        }

        public static Vector3D OrthographicProjection(Vector3D vector3D, Vector3D projectionDirectionVector3D)
        {
            // (dot product between the main vector and the direction vector / magnitude ** 2) * direction vector
            double dotProduct = DotProduct(vector3D, projectionDirectionVector3D);
            double magnitude = Magnitude(projectionDirectionVector3D);
            double division = dotProduct / Math.Pow(magnitude, 2);
            return MultiplyVector(division, projectionDirectionVector3D);
        }

        public static double Distance(Vector2D v1, Vector2D v2)
        {
            var v1List = v1.ToList();
            var v2List = v2.ToList();
            return Math.Sqrt(v1List.Zip(v2List, (a, b) => Math.Pow(a - b, 2)).Sum());
        }

        public static double Distance(Vector3D v1, Vector3D v2)
        {
            var v1List = v1.ToList();
            var v2List = v2.ToList();
            return Math.Sqrt(v1List.Zip(v2List, (a, b) => Math.Pow(a - b, 2)).Sum());
        }

        public static double Area(Vector2D v1, Vector2D v2)
        {
            var matrix = BuildMatrix(v1.ToList(), v2.ToList());
            return Math.Abs(MatrixUtility.CalculateDeterminant(matrix));
        }

        public static double Volume(Vector3D v1, Vector3D v2, Vector3D v3)
        {
            var matrix = BuildMatrix(v1.ToList(), v2.ToList(), v3.ToList());
            return Math.Abs(MatrixUtility.CalculateDeterminant(matrix));
        }
        private static double[,] BuildMatrix(double[] v1List, double[] v2List)
        {
            int length = Math.Min(v1List.Length, v2List.Length); // Use the smaller length to avoid out-of-bounds errors
            var matrix = new double[length, 2];
            for(int i = 0; i < length; i++)
            {
                matrix[i, 0] = v1List[i];
                matrix[i, 1] = v2List[i];
            }
            return matrix;
        }
        private static double[,] BuildMatrix(double[] v1List, double[] v2List, double[] v3List)
        {
            int length = Math.Min(Math.Min(v1List.Length, v2List.Length), v3List.Length);
            var matrix = new double[length, 3];

            for(int i = 0; i < length; i++)
            {
                matrix[i, 0] = v1List[i];
                matrix[i, 1] = v2List[i];
                matrix[i, 2] = v3List[i];
            }

            return matrix;
        }
    } 

}
