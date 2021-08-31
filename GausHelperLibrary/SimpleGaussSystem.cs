using System.Net.Sockets;

namespace GausHelperLibrary
{
    public class SimpleGaussSystem : Gauss
    {
        public SimpleGaussSystem(double[,] matrixA, double[] matrixB) : base(matrixA, matrixB)
        {
            
        }
        public override double[] Solve(double[,] extendedMatrix)
        {
            var solution = new double[size];
            var tempMatrix = extendedMatrix;

            //zeroing left bottom stack
            for (var i = 1; i < size; i++)
            {
                for (var j = i; j < size; j++)
                {
                    var k = tempMatrix[j, i - 1] / tempMatrix[i - 1, i - 1];
                    for (var p = 0; p <= size; p++)
                    {
                        tempMatrix[j, p] -= tempMatrix[i - 1, p] * k;
                    }
                }
            }

            //getting solutions
            for (var i = size - 1; i >= 0; i--)
            {
                solution[i] = tempMatrix[i, size] / tempMatrix[i, i];
                for (var j = size - 1; j > i; j--)
                {
                    solution[i] -= tempMatrix[i, j] * solution[j] / tempMatrix[i, i];
                }
            }

            return solution;
        }
    }
}