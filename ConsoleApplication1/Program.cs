using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
             //double[] arr = Exponential(0, 8, 1.0, 100000);
             //Array.Sort(arr);
            /*for(int i = 0; i < arr.Length; i++)
               if (i % 10000 == 0)
                   Console.Write("{0:0.00} ", arr[i]);*/
           /* double h = Interval(arr);
            Console.WriteLine(h  +  " " + arr.Max() + " " + Numbers(h, arr));*/

            double[] arr = RandomNormal(0, 8, 1000000);
            Array.Sort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 10000 == 0)
                    Console.Write("{0:0.00} ", arr[i]);
            }
            Console.WriteLine();
            double h = Interval(arr);
            Console.WriteLine(h + " " + arr.Max() + " " + Numbers(h, arr));
            Console.ReadKey();
        }

        public static double[] Exponential(double min, double max, double rate, int count)
        {
            double x;
            double[] array = new double[count];
            int i = 0;
            while(i < count)
            {
                Random rdn = new Random();
                x = Math.Log(rdn.NextDouble()) * (-1 / rate) * (max - min) + min;
                if (x <= max)
                {
                    array[i] = x;
                    i++;
                }    
             
            }
    
            return array;
        }

        public static double[] RandomNormal(double min, double max, int count)
        {
            double x;
            double mean = (max + min) / 2.0;
            double stdev = (mean - min) / 3.000;
            double[] array = new double[count];
              
            for (int i = 0; i < count; i++)
            {
                Random rdn = new Random();
                double u1 = rdn.NextDouble();
                double u2 = rdn.NextDouble();
                double rndNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                    Math.Sin(2.0 * Math.PI * u2);
                x = (rndNormal * stdev) + mean;
                array[i] = x;             
            }
            return array;
                
        }
        
        public static double Interval(double[] arr)
        {
            return (arr.Max() - arr.Min()) / (1 + 3.322 * Math.Log(arr.Length));
            
        }

        public static int Numbers(double h, double[] arr)
        {
            return (int)((arr.Max() - arr.Min()) / h);
        }
    }
}
