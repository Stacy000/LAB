using System;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {

            int ARRAY_SIZE = 10;
            int[] arraySingleThread = new int[ARRAY_SIZE];
            int[] arrayMultiThread = new int[ARRAY_SIZE];
            

            // TODO : Use the "Random" class in a for loop to initialize an array
            var rand = new Random();

            for (int k = 0; k < ARRAY_SIZE; k++)
            {
                arraySingleThread[k] = rand.Next(1000);
            }

            // copy array by value.. You can also use array.copy()
            Array.Copy(arraySingleThread, 0, arrayMultiThread, 0, arraySingleThread.Length);
            Console.WriteLine("enter a number of multithread that you wish to merge");
            int.TryParse(Console.ReadLine().Trim(), out int n);

            List<int> multi = new List<int>();

            for(int u = 0; u < arrayMultiThread.Length; u++)
            {
                multi.Add(arrayMultiThread[u]);
            }



            /*foreach (int num in multi)
            {
                Console.Write("," + num);
            }
            */


            List<Thread> threads = new List<Thread>();
            int chunkSize = multi.Count / n;
            
              int i = 0;
              int j = 0;
            Stopwatch clock_multi = new Stopwatch();


            //能整除时
            clock_multi.Start();
            while (i < n && j < multi.Count)
              {
                List<int> subList = multi.GetRange(j, chunkSize);
                //Console.WriteLine(subList.Count);
                int[]subArray=subList.ToArray();
                PrintArray(subArray);
                
                Thread t = new Thread(() => MergeSort(subArray));

                t.Start();
                threads.Add(t);
                j = j + chunkSize;
                i++;
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            clock_multi.Stop();

            TimeSpan timeMulti = clock_multi.Elapsed;

            Console.WriteLine(timeMulti);



            /*TODO : Use the  "Stopwatch" class to measure the duration of time that
               it takes to sort an array using one-thread merge sort and
               multi-thead merge sort
            */


            //TODO :start the stopwatch

            Stopwatch single = new Stopwatch();

            single.Start();

            MergeSort(arraySingleThread);

            //TODO :Stop the stopwatch

            single.Stop();

            // Get the elapsed time as a TimeSpan value.
            TimeSpan timeSingle = single.Elapsed;

            //Console.WriteLine(timeSingle);
            //PrintArray(arraySingleThread);
            IsSorted(arraySingleThread);

            //TODO: Multi Threading Merge Sort

          /*  

            MergeSort(arrayMultiThread);

            multi.Stop();

            

            */



            /*********************** Methods **********************
             *****************************************************/
            /*
            implement Merge method. This method takes two sorted array and
            and constructs a sorted array in the size of combined arrays
            */

            static int[] Merge(int[] LA, int[] RA, int[] A)
            {

                int i = 0;
                int j = 0;
                int k = 0;
                while (i < LA.Length || j < RA.Length)
                {
                    if (i < LA.Length && j < RA.Length)
                    {
                        if (LA[i] <= RA[j])
                        {
                            A[k] = LA[i];
                            i++;
                            k++;
                        }

                        else
                        {
                            A[k] = RA[j];
                            j++;
                            k++;

                        }

                    }
                    else if (i < LA.Length)
                    {
                        A[k] = LA[i];
                        i++;
                        k++;
                    }
                    else if (j < RA.Length)
                    {
                        A[k] = RA[j];
                        j++;
                        k++;

                    }
                }

                return A;
            }



            /*
            implement MergeSort method: takes an integer array by reference
            and makes some recursive calls to intself and then sorts the array
            */
            static int[] MergeSort(int[] A)
            {
                // TODO :implement
                int array_length = A.Length;
                
                if (array_length < 2)
                {
                    return A;
                }

                int mid = array_length / 2;
                int[] left = new int[mid];
                int[] right = new int[array_length - mid];
                for (int i = 0; i <= mid - 1; i++)
                {
                    left[i] = A[i];
                }

                for(int j = mid; j <= array_length - 1; j++)
                {
                    right[j - mid] = A[j];
                }
                MergeSort(left);
                MergeSort(right);
                Merge(left, right, A);

                return A;

            }


            // a helper function to print your array
            static void PrintArray(int[] myArray)
            {
                Console.Write("[");
                for (int i = 0; i < myArray.Length; i++)
                {
                    Console.Write("{0} ", myArray[i]);

                }
                Console.Write("]");
                Console.WriteLine();

            }

            // a helper function to confirm your array is sorted
            // returns boolean True if the array is sorted
            static bool IsSorted(int[] a)
            {
                int j = a.Length - 1;
                if (j < 1) return true;
                int ai = a[0], i = 1;
                while (i <= j && ai <= (ai = a[i])) i++;
                return i > j;
            }


        }


    }
}
