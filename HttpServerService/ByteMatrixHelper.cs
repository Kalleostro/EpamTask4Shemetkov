using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HttpServerService
{
    public class ByteMatrixHelper
    {
        /// <summary>
        /// convert a matrix to a byte array
        /// </summary>
        /// <param name="matrix">matrix</param>
        /// <returns>bytes</returns>
        public byte[] MatrixToByteArray(double[,] matrix)
        {
            if(matrix == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, matrix);

            return ms.ToArray();
        }
        /// <summary>
        /// convert a vector to a byte array
        /// </summary>
        /// <param name="vector">vector</param>
        /// <returns>bytes</returns>
        public byte[] VectorToByteArray(double[] vector)
        {
            if(vector == null)
                return null;

            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, vector);

            return ms.ToArray();
        }
        
        /// <summary>
        /// convert a byte array to a matrix
        /// </summary>
        /// <param name="arrBytes">bytes</param>
        /// <returns>matrix</returns>
        public double[,] ByteArrayToMatrix(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            double[,] matrix = (double[,]) binForm.Deserialize(memStream);

            return matrix;
        }
        /// <summary>
        /// convert a byte array to a vector
        /// </summary>
        /// <param name="arrBytes">bytes</param>
        /// <returns>vector</returns>
        public double[] ByteArrayToVector(byte[] arrBytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binForm = new BinaryFormatter();
            memStream.Write(arrBytes, 0, arrBytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            double[] vector = (double[]) binForm.Deserialize(memStream);

            return vector;
        }
    }
}