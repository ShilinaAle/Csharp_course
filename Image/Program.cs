using System;
using System.Collections.Generic;

namespace Image
{
    //Median filter of a photo specified as a matrix
    class Program
    {
        static void Main(string[] args)
        {
            //double[,] original = new double[3, 3] { { 1, 1, 1 }, { 2, 2, 2 }, { 3, 3, 3 } };
            double[,] original = new double[1, 3] { { 1, 2, 1 } };
            Print(original); ;
            Print(Filter(original));

        }
        static void Print(double[,] matr)
        {
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    Console.Write(matr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-----");
        }
        static double[,] Filter(double[,] matr)
        {
            double[,] newMatr = new double[matr.GetLength(0), matr.GetLength(1)];
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    newMatr[i, j] = Window(matr, i, j);
                }
                Console.WriteLine();
            }
            return newMatr;
        }
        static double Window(double[,] matr, int i, int j)
        {
            //list of pixel values
            List<double> values = new List<double>();
            for (int newi = i - 1; newi <= i + 1; newi++)
            {
                for (int newj = j - 1; newj <= j + 1; newj++)
                {
                    //check edge cases
                    if (newi >= 0 && newi < matr.GetLength(0) &&
                        newj >= 0 && newj < matr.GetLength(1))
                    {
                        values.Add(matr[newi, newj]);
                    }
                }
            }
            //finding the median
            values.Sort();
            if (values.Count % 2 == 0)
                return (values[values.Count / 2 - 1] + values[values.Count / 2]) / 2.0;
            return values[values.Count / 2];
        }
    }
}
