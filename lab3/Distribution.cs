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
        public static double[] Exponential(double min, double max, double rate, int count)
        {
            double x;
            double[] array = new double[count];
            Random rdn = new Random();
            for(int i = 0; i < count; i++)
            {

                x = Math.Log(rdn.NextDouble()) * (-1 / rate) * (max - min) + min;
                array[i] = x;
             
            }
    
            return array;
        }

        public static double[] Normal(double min, double max, int count)
        {
            double x;
            double mean = (max + min) / 2.0;
            double stdev = (mean - min) / 3.000;
            double[] array = new double[count];
            Random rdn = new Random();
            for (int i = 0; i < count; i++)
            {
                x = (rdn.NextDouble() * stdev) + mean;
                array[i] = x;             
            }
            return array;
                
        }
    }
}
