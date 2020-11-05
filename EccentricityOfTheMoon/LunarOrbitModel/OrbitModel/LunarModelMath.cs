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

        public static double[] VectorMultiply(double[] A, double[] B)
        {
            // Compute the vector subtraction of arrays A & B
            Debug.Assert(A.Length == B.Length);
            double[] C = new double[A.Length];
            for (int i = 0; i < A.Length; i++)
                C[i] += A[i] * B[i];
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
                if (A[i] == 0.0) 
                    { C[i] = 0.0; }
                else 
                    { C[i] = Math.Pow(A[i], b); }
            return C;
        }

        public static double[] VectorAbs(double[] A)
        {
            // Compute the Element-wise absolute value of A
            double[] B = new double[A.Length];
            for (int i = 0; i < A.Length; i++)
            {
                B[i] = Math.Abs(A[i]);
            }
            return B;
        }

    }

    public static class Physics
    {

        public static double[] ComputeAcceleration (Body A, Body B)
        {
            // Compute Acceleration of Body A due to Body B
            double G = 6.67e-11;
            double k = G * B.mass;
            double[] _dr = LinearAlgebra.VectorSubtract(A.Position, B.Position);
            double[] _r = LinearAlgebra.VectorMultiply(
                LinearAlgebra.VectorAbs(_dr), LinearAlgebra.VectorExp(_dr, -3));
            return LinearAlgebra.VectorScale(_r, k);
        }


    }
}
