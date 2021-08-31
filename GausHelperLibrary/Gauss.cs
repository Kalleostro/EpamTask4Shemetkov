using System;

namespace GausHelperLibrary
{
    public abstract class Gauss
    {
        public double[,] ExtendedMatrix { get; set; }
        public double[] X { get; set; }
        public Gauss(double[,] matrixA, double[] matrixB)
        {
            ExtendedMatrix = new double[matrixA.GetLength(0) + matrixB.GetLength(0),
                matrixA.GetLength(1) + matrixB.GetLength(1)];
            
        }

        public void FillExtendedMatrix(double[,] matrixA, double[] matrixB)
        {
            
        }
    }
}