using System;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;

namespace pi
{
    class Program
    {
        static void Main(string[] args)
        {
            long numberOfSamples = 10000;
            long hits=0;
            

            Console.WriteLine(Environment.ProcessorCount);

            /*SingleThreads Work*/
            Stopwatch single = new Stopwatch();

            single.Start();

            double pi = EstimatePI(numberOfSamples, ref hits);

            string pi_3decimals = pi.ToString("f4");

            single.Stop();
            TimeSpan timeSingle = single.Elapsed;
            Console.WriteLine(timeSingle);
            Console.WriteLine("pi is " + pi_3decimals);


           
            



            static double EstimatePI(long numberOfSamples, ref long hits)
            {

                //Mutex mut = new Mutex();
                double[,] samples = GenerateSamples(numberOfSamples);

                for (int i = 0; i < numberOfSamples; i++)
                {
                    int r = 1;
                    if (Math.Pow(samples[i, 0], 2) + Math.Pow(samples[i, 1], 2) <= r)
                    {
                       // mut.WaitOne();
                        hits++;
                       // mut.ReleaseMutex();
                    }

                }

                double pi = hits * 4.00000 / numberOfSamples; 

                return pi;
            }


            static double[,] GenerateSamples(long numberOfSamples)
            {

                double[,] samples = new double[numberOfSamples, 2];
                var rand = new Random();

                for (int i = 0; i < numberOfSamples; i++)
                {
                    samples[i, 0] = (double)rand.Next(-1000000, 1000000) / 1000000;
                    samples[i, 1] = (double)rand.Next(-1000000, 1000000) / 1000000;

                }

                return samples;
                 

            }

            
        }
    }
}
