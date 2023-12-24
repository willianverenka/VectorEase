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
            var vector1List = vector1.ToList(); var vector2List = vector2.ToList();
            double[] newVectorList = new double[2];
            for (int i = 0; i < newVectorList.Length; i++)
            {
                newVectorList[i] = vector1List[i] + vector2List[i];
            }
            return new Vector2D(newVectorList[0], newVectorList[1]);
        }
        public static Vector3D VectorSum(Vector3D vector1, Vector3D vector2)
        {
            var vector1List = vector1.ToList(); var vector2List = vector2.ToList();
            double[] newVectorList = new double[3];
            for(int i = 0; i < newVectorList.Length; i++)
            {
                newVectorList[i] = vector1List[i] + vector2List[i];
            }
            return new Vector3D(newVectorList[0], newVectorList[1], newVectorList[2]);
        }

        public static double DotProduct(Vector2D vector1, Vector2D vector2)
        {
            var vector1List = vector1.ToList(); var vector2List = vector2.ToList();
            double dotProduct = 0;
            for (int i = 0; i < vector1List.Length; i++)
            {
                dotProduct += vector1List[i] * vector2List[i];
            }
            return dotProduct;
        }

        public static double DotProduct(Vector3D vector1, Vector3D vector2)
        {
            var vector1List = vector1.ToList(); var vector2List = vector2.ToList();
            double dotProduct = 0;
            for(int i = 0; i < vector1List.Length; i++)
            {
                dotProduct += vector1List[i] * vector2List[i];
            }
            return dotProduct;
        }
        public static Vector2D CrossProduct(Vector2D vector1, Vector2D vector2)
        {
            return new Vector2D(vector1.A * vector2.A, vector1.B * vector2.B);
        }

        public static Vector3D CrossProduct(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.A * vector2.A, vector1.B * vector2.B, vector1.C * vector2.C);
        }

        public static Vector2D MultiplyVector(double value, Vector2D vector2D)
        {
            return new Vector2D(vector2D.A * value, vector2D.B * value);
        }
        public static Vector3D MultiplyVector(double value, Vector3D vector2D)
        {
            return new Vector3D(vector2D.A * value, vector2D.B * value, vector2D.C * value);
        }

        public static Vector2D OrtographicProjection(Vector2D vector2D, Vector2D projectionDirectionVector2D)
        {
            // (dot product between the main vector and the direction vector / magnitude ** 2) * direction vector
            double dotProduct = DotProduct(vector2D, projectionDirectionVector2D);
            double magnitude = Magnitude(projectionDirectionVector2D);
            double division = dotProduct / Math.Pow(magnitude, 2);
            return MultiplyVector(division, projectionDirectionVector2D);
        }
        public static Vector3D OrtographicProjection(Vector3D vector3D, Vector3D projectionDirectionVector3D)
        {
            // (dot product between the main vector and the direction vector / magnitude ** 2) * direction vector
            double dotProduct = DotProduct(vector3D, projectionDirectionVector3D);
            double magnitude = Magnitude(projectionDirectionVector3D);
            double division = dotProduct / Math.Pow(magnitude, 2);
            return MultiplyVector(division, projectionDirectionVector3D);
        }
    }
}
