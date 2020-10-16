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
            long numberOfSamples = 1000;
            long hits = 0;

           
            Console.WriteLine(Environment.ProcessorCount);

            //SingleThreads Work//
              Stopwatch single = new Stopwatch();

              single.Start();

              double pi = EstimatePI(numberOfSamples, ref hits);

              string pi_3decimals = pi.ToString("f4");

              single.Stop();
              TimeSpan timeSingle = single.Elapsed;
              Console.WriteLine("time used for single-threading: " + timeSingle.TotalSeconds);
              Console.WriteLine("pi is " + pi_3decimals);


            //MultiThreads Work//
            hits = 0;

            Console.WriteLine("enter a number of multithread that you wish to merge, number should be small, please choose from 0-10 ");
            int.TryParse(Console.ReadLine().Trim(), out int n);

            long nThread = n;

            List<Thread> threads = new List<Thread>();
            double PI=0;
            Stopwatch multi = new Stopwatch();
            multi.Start();

            for (int x = 0; x < nThread; x++)
            {
                Thread t = new Thread(() => PI = EstimatePI(numberOfSamples/nThread,ref hits)/nThread);
                threads.Add(t);
                t.Start();
            }


            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            string PI_3decimals = PI.ToString("f4");

            multi.Stop();

            Console.WriteLine("PI is " + PI_3decimals);

            TimeSpan timeMulti = multi.Elapsed;

            Console.WriteLine("time used for multi-threading: " + timeMulti.TotalSeconds);
            
            
            static double EstimatePI(long numberOfSamples, ref long hits)
            {

                Mutex mut = new Mutex();
                double[,] samples = GenerateSamples(numberOfSamples);

                for (int i = 0; i < numberOfSamples; i++)
                {
                    int r = 1;
                    if (Math.Pow(samples[i, 0], 2) + Math.Pow(samples[i, 1], 2) <= r)
                    {
                        mut.WaitOne();
                        hits++;
                        mut.ReleaseMutex();
                    }

                }

               // Console.WriteLine(hits);

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
