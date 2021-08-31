using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HttpServerService
{
    public class ByteMatrixHelper
    {
        //convert a matrix to a byte array
        public byte[] MatrixToByteArray(double[,] matrix)
        {
            if(matrix == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, matrix);

            return ms.ToArray();
        }

        //convert a byte array to a matrix
        public double[] ByteArrayToMatrix(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            double[] resultMatrix = (double[]) binForm.Deserialize(memStream);

            return resultMatrix;
        }
    }
}