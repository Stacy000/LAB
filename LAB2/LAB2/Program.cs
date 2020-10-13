using System;
using System.Threading;
using System.Diagnostics;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {

            int ARRAY_SIZE = 1000;
            int[] arraySingleThread = new int[ARRAY_SIZE];


            // TODO : Use the "Random" class in a for loop to initialize an array
            var rand = new Random();

            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                arraySingleThread[i] = rand.Next(1000);
            }

            // copy array by value.. You can also use array.copy()
            int[] arrayMultiThread = arraySingleThread.Slice(0, arraySingleThread.Length);

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

            Console.WriteLine(timeSingle);

            //TODO: Multi Threading Merge Sort

            Stopwatch multi = new Stopwatch();

            multi.Start();

            MergeSort(arrayMultiThread);

            multi.Stop();

            TimeSpan timeMulti = multi.Elapsed;

            Console.WriteLine(timeMulti);





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
