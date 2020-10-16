using System;
using System.Collections;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
namespace MergeSort
{
    class Program
    {
        static void Main()
        {

            int ARRAY_SIZE = 100000000;
            int[] arraySingleThread = new int[ARRAY_SIZE];
            int[] arrayMultiThread = new int[ARRAY_SIZE];
            List<int> multi = new List<int>();
            List<Thread> threads = new List<Thread>();

            Random rand = new Random();

            for (int k = 0; k < ARRAY_SIZE; k++)
            {
                arraySingleThread[k] = rand.Next(1000);
            }

           // Console.Write("we will merge sort numbers ："); 
           // PrintArray(arraySingleThread);

            
            //make the arrayMultiThread same as arraySingle for futhur implementation and comparison
            Array.Copy(arraySingleThread, 0, arrayMultiThread, 0, arraySingleThread.Length);

            
            //tell the program a number of multi-Thread to be separated.
            Console.WriteLine("enter a number of multithread that you wish to merge");
            int.TryParse(Console.ReadLine().Trim(), out int n);

            
            for(int u = 0; u < arrayMultiThread.Length; u++)
            {
                
                multi.Add(arrayMultiThread[u]);
            }




            //*****Working on multi thread*****//

            int chunkSize = multi.Count / n;
             
            int j = 0;

            List<int[]> subList = new List<int[]>();

           // int[] subArray = new int[] { };

            Mutex mut = new Mutex();

            Stopwatch clock_multi = new Stopwatch();
          
            
            clock_multi.Start();

            while (j < multi.Count)
            {
                int [] subArray = subArrays(j, chunkSize, arrayMultiThread); //call the subarray function and store the range into subArray.

                //the next sub-array will start with index j+chunkSize
                j = j + chunkSize;

               
                Thread t1 = new Thread(() =>
                {
                    
                    MergeSort(subArray);//mergesort the sub-array


                }); 


                //add the sorted subarrays into a list array
                subList.Add(subArray);
                
                t1.Start();

                
                threads.Add(t1);
                
            }

            foreach (Thread thread in threads)
            {
                thread.Join(); //to make sure the threads are processing in order.


            }

            //PrintArray(subList[0]);
            //PrintArray(subList[1]);

            while (subList.Count != 1)
            {

                int[] temp = new int[] { };
                var myList = new List<int>();

                myList.AddRange(subList[subList.Count - 1]);
                myList.AddRange(subList[subList.Count - 2]);

                temp = myList.ToArray();

                Merge(subList[subList.Count - 1], subList[subList.Count - 2], temp);

                subList.RemoveAt(subList.Count - 1);
                subList.RemoveAt(subList.Count - 1);
                subList.Add(temp);

            }


            arrayMultiThread = subList[0];

         // PrintArray(arrayMultiThread);

            clock_multi.Stop();

            TimeSpan timeMulti = clock_multi.Elapsed;

            Console.WriteLine("the execution time for multi thread is" + timeMulti);
           

            bool A = IsSorted(arrayMultiThread);

            Console.WriteLine(A);

            //*****Working on single thread*****//

            Stopwatch single = new Stopwatch();

            single.Start();

            MergeSort(arraySingleThread);

            single.Stop();

            TimeSpan timeSingle = single.Elapsed;

            Console.WriteLine("the execution time for single thread is" + timeSingle);

          //  PrintArray(arraySingleThread);

            bool B=IsSorted(arraySingleThread);

            Console.WriteLine(B);



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

            //a function which takes the array that we are working on, the starting index j,
            //and the size of the sub-array as input paramters, and returns a sub-array starting
            //with index j of size chunkSize of the arrayMultiThread.
            static int[] subArrays(int j, int chunkSize, int[] arrayMultiThread)
            {
                
                List<int> multi = new List<int>();

                for (int u = 0; u < arrayMultiThread.Length; u++)
                {
                    multi.Add(arrayMultiThread[u]);
                }

                List<int> subList = new List<int>();

                int[] subArray = new int[] { };

                if (multi.Count - j < chunkSize)
                {
                    subList = multi.GetRange(j, multi.Count - j);

                    subArray = subList.ToArray();

                }

                else
                {
                    subList = multi.GetRange(j, chunkSize);
                    //Console.WriteLine(j);
                    subArray = subList.ToArray();
                }

                return subArray;
            }


            


        }


    }
}
