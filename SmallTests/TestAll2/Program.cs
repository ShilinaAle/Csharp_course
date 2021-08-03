using System;
using System.Collections.Generic;

namespace TestAll2
{
    class Program
    {
        //counting higher-order digits in a number
        static void Main(string[] args)
        {
            //PrintNumbers(GetBenfordStatistics("1"));
           // PrintNumbers(GetBenfordStatistics("abc"));
            PrintNumbers(GetBenfordStatistics("123 456 789"));
            PrintNumbers(GetBenfordStatistics("abc 123 def 356 gf 0 i"));
        }

        public static int[] GetBenfordStatistics(string text)
        {
            var statistics = new int[10];
            for (int i = 0; i < text.Length; i++)
            {
                if (i < 1)
                { 
                    if (char.IsDigit(text[i])) 
                        statistics[text[i] - '0']++; 
                }
                else if (char.IsDigit(text[i]) && !char.IsDigit(text[i - 1])) 
                    statistics[text[i] - '0']++;
            }
            return statistics;
        }

        public static void PrintNumbers(int[] a)
        {
            foreach (int i in a)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
