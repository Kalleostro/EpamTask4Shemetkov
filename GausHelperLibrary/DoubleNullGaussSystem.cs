namespace GausHelperLibrary
{
    public class DoubleNullGaussSystem : Gauss
    {
        public override double[] Solve(double[,] extendedMatrix)
        {
            var solution = new double[size];

            var tempMatrix = new double[size, size + 1];

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size + 1; j++)
                {
                    tempMatrix[i, j] = extendedMatrix[i, j];
                }
            }

            //zeroing left bottom stack
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size + 1; j++)
                {
                    tempMatrix[i, j] /= extendedMatrix[i, i];
                }
                for (var j = i + 1; j < size; j++)
                {
                    var k = tempMatrix[j, i] / tempMatrix[i, i];
                    for (var p = 0; p < size + 1; p++)
                    {
                        tempMatrix[j, p] -= tempMatrix[i, p] * k;
                    }
                }
                for (var j = 0; j < size; j++)
                {
                    for (var p = 0; p < size + 1; p++)
                    {
                        extendedMatrix[j, p] = tempMatrix[j, p];
                    }
                }
            }

            //zeroing top right stack
            for (var i = size - 1; i > -1; i--)
            {
                for (var j = size; j > -1; j--)
                {
                    tempMatrix[i, j] /= extendedMatrix[i, i];
                }

                for (var j = i - 1; j > -1; j--)
                {
                    var k = tempMatrix[j, i] / tempMatrix[i, i];
                    for (var p = size; p > -1; p--)
                    {
                        tempMatrix[j, p] -= tempMatrix[i, p] * k;
                    }
                }
            }
            
            for (var i = 0; i < size; i++)
            {
                solution[i] = tempMatrix[i, size];
            }

            return solution;
        }
    }
}