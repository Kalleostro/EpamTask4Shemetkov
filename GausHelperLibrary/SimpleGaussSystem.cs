using System.Net.Sockets;

namespace GausHelperLibrary
{
    public class SimpleGaussSystem : Gauss
    {
        public SimpleGaussSystem(double[,] matrixA, double[] matrixB) : base(matrixA, matrixB)
        {
            
        }
    }
}