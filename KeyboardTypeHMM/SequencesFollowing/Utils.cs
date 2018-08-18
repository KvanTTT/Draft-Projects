using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequencesFollowing
{
    public static class Utils
    {
        public static double[,] Log(double[,] value)
        {
            int rows = value.GetLength(0);
            int cols = value.GetLength(1);

            double[,] r = new double[rows, cols];
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    r[i, j] = Math.Log(value[i, j]);
            return r;
        }

        public static double[] Log(double[] value)
        {
            double[] result = new double[value.Length];
            for (int i = 0; i < value.Length; i++)
                result[i] = Math.Log(value[i]);
            return result;
        }

        public static string MatrixToString(double[] matrix)
        {
            var result = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                result.Append(result[i]);
                if (i != result.Length - 1)
                    result.Append(" ");
            }
            return result.ToString();
        }

        public static string MatrixToString(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            var result = new StringBuilder();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result.Append(matrix[i, j]);
                    if (j != cols - 1)
                        result.Append(" ");
                }
                if (i != rows - 1)
                    result.Append(Environment.NewLine);
            }

            return result.ToString();
        }
    }
}
