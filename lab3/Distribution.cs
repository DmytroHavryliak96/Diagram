using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public static class Distribution
    {
        // Генерація випадкових чисел за експотенціальним розподілом
        public static double[] Exponential(double min, double max, double rate, int count)
        {
            double x;
            double[] array = new double[count];
            int i = 0;
            Random rdn = new Random();
            while (i < count)
            {
               
                x = Math.Log(rdn.NextDouble()) * (-1 / rate) * ((max - min)/5) + min;
                if (x <= max)
                {
                    array[i] = x;
                    i++;
                }

            }

            return array;
        }

        // Генерація випадкових чисел за нормальним розподілом
        public static double[] RandomNormal(double min, double max, int count)
        {
            double x;
            double mean = (max + min) / 2.0;
            double stdev = (mean - min) / 3.000;
            double[] array = new double[count];

            Random rdn = new Random();

            for (int i = 0; i < count; i++)
            {
                
                double u1 = rdn.NextDouble();
                double u2 = rdn.NextDouble();
                double rndNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                    Math.Sin(2.0 * Math.PI * u2);
                x = (rndNormal * stdev) + mean;
                array[i] = x;
            }
            return array;

        }

        // Функція визначення інтервалу
        public static double Interval(double[] arr)
        {
            double h = (arr.Max() - arr.Min()) / (1.0 + 3.322 * Math.Log(arr.Length));
            // Заокруглення інтервалу :
            if ((h - 1) >= 50)
                return Math.Round(h); // до цілих чисел
            else
                return Math.Round(h, 1); // до першого розряду після коми
        }
    }
}
