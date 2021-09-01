using System;

namespace GausHelperLibrary
{
    public abstract class Gauss
    {
        public int size { get; set; }
        public double[,] ExtendedMatrix { get; set; }
        public double[] X { get; set; }
        public Gauss()
        {
        }
        public abstract double[] Solve(double[,] matrix);
        public void FillExtendedMatrix(double[,] matrixA, double[] matrixB)
        {
            ExtendedMatrix = new double[matrixA.GetLength(0),
                matrixA.GetLength(1) + 1];
            size = matrixA.GetLength(0);
            for (var i = 0; i < matrixA.GetLength(0); i++ )
                for (var j = 0; j < matrixA.GetLength(1); j++)
                    ExtendedMatrix[i, j] = matrixA[i, j];
            for (var j = 0; j < matrixA.GetLength(0); j++)
                ExtendedMatrix[j, matrixA.GetLength(1)] = matrixB[j];
        }
    }
}