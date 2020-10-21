using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OrbitModel
{
    public static class LinearAlgebra
    {
        public static double DotProduct (double[] A, double[] B)
        {
            // Compute the dot produce between arrays A & B
            Debug.Assert(A.Length == B.Length);
            double _sum = 0.0;
            for (int i = 0; i < A.Length; i++)
                _sum += A[i] * B[i];
            return _sum;
        }

        public static double[] VectorAdd (double[] A, double[] B)
        {
            // Compute the vector addition of arrays A & B
            Debug.Assert(A.Length == B.Length);
            double[] C = new double[A.Length];
            for (int i = 0; i < A.Length; i++)
                C[i] += A[i] + B[i];
            return C;
        }

        public static double[] VectorSubtract(double[] A, double[] B)
        {
            // Compute the vector subtraction of arrays A & B
            Debug.Assert(A.Length == B.Length);
            double[] C = new double[A.Length];
            for (int i = 0; i < A.Length; i++)
                C[i] += A[i] - B[i];
            return C;
        }

        public static double[] VectorScale (double[] A, double b)
        {
            // Compute scale vector A by length B
            double[] Ab = new double[A.Length];
            for (int i = 0; i < A.Length; i++)
                Ab[i] += A[i]*b;
            return Ab;
        }

        public static double[] VectorExp(double[] A, double b)
        {
            // Raise elements in A to the power of b
            double[] C = new double[A.Length];
            for (int i = 0; i < A.Length; i++)
                C[i] = Math.Pow(A[i], b);
            return C;
        }
    }
}
