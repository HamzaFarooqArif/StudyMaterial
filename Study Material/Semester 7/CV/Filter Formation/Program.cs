using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaussian
{
    class Program
    {
        public static double gaussian(int x, int y, double sigma)
        {
            double result = (1 / (2 * Math.PI * sigma * sigma)) *Math.Pow(Math.E, -((x*x + y*y)/2*sigma*sigma));
            return result;
        }

        public static bool isInteger(double val, int decimalPlaces)
        {
            string valueStr = val.ToString();
            string nextValueStr = valueStr.Split('.')[1];
            for(int i = 0; i < decimalPlaces; i++)
            {
                if (nextValueStr[i] != '0') return false;
            }
            return true;
        }
        public static double[,] isIntegerArray(double [,] array, int length, int decimalPlaces)
        {
            double[,] result = { { 0 }, { 0} };
            for(int y = 0; y < length; y++)
            {
                for(int x = 0; x< length; x++)
                {
                    if (!isInteger(array[x, y], decimalPlaces)) return result;
                }
            }
            return array;
        }

        public static double sumOfElements(double[,] array)
        {
            double sum = 0;
            for(int i = 0; i < array.GetLength(1); i++)
            {
                for(int j = 0; j < array.GetLength(0); j++)
                {
                    sum += array[i, j];
                }
            }
            return sum;
        }
        public static double[,] MultiplyMatrix(double[,] A, double[,] B)
        {
            int rA = A.GetLength(0);
            int cA = A.GetLength(1);
            int rB = B.GetLength(0);
            int cB = B.GetLength(1);
            double temp = 0;
            double[,] kHasil = new double[rA, cB];
            if (cA != rB)
            {
                Console.WriteLine("matrik can't be multiplied !!");
            }
            else
            {
                for (int i = 0; i < rA; i++)
                {
                    for (int j = 0; j < cB; j++)
                    {
                        temp = 0;
                        for (int k = 0; k < cA; k++)
                        {
                            temp += A[i, k] * B[k, j];
                        }
                        kHasil[i, j] = temp;
                    }
                }
            }
            return kHasil;
        }
        public static void printMatrix(double[,] array)

        {
            for(int i = 0; i < array.GetLength(1); i++)
            {
                for(int j = 0; j < array.GetLength(0); j++)
                {
                    Console.Write(array[j, i] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            double[,] array1 = { { 1, 2, 5.3138, 2, 1 } };//, 2, 1} };
            double[,] array2 = { { array1[0, 0] }, { array1[0, 1] }, { array1[0, 2] }, { array1[0, 3] }, { array1[0, 4] } };//, { array1[0, 5] } }, { array1[0, 6] } };
            double[,] array3 = MultiplyMatrix(array2, array1);
            printMatrix(array3);
            Console.WriteLine();
            Console.WriteLine(sumOfElements(array3));
            Console.Read();
        }
    }
}
