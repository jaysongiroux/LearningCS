using System;
using System.Diagnostics;
using System.Threading;
/*
 Implementing searching algorthms
 Author: Jason
 Date: May 9, 2020
 */

namespace LearningNewLanguages
{
    class Program
    {
       
        //easy print function
        private static void print(string value)
        {
            System.Console.WriteLine(value);
        }

        public static int input()
        {
            int age = Convert.ToInt32(Console.ReadLine());
            return age;
        }

        private static void printArray(int[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                System.Console.WriteLine(arr[i]);
            }
        }

        // generate the array to be searched
        //https://www.geeksforgeeks.org/shuffle-a-given-array-using-fisher-yates-shuffle-algorithm/
        public static int[] randomize(int[] arr2)
        {
            int n = arr2.Length;
            int[] arr = arr2;
            // Creating a object 
            // for Random class 
            Random r = new Random();

            // Start from the last element and 
            // swap one by one. We don't need to 
            // run for the first element  
            // that's why i > 0 
            for (int i = n - 1; i > 0; i--)
            {

                // Pick a random index 
                // from 0 to i 
                int j = r.Next(0, i + 1);

                // Swap arr[i] with the 
                // element at random index 
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }


            // Prints the random array 
/*            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }*/
            return arr;            
        }

        // creates an array from 0 to size in order
        public static long[] genArray(int min, long max)
        {
            long[] arr = new long[max];
            for(int i = min; i<max; i++)
            {
                arr[i] = i;
            }

            //printArray(arr);
            return arr; 
        }

        public static long linearSearch(long[] arr, int searchFor)
        {
            long counter = 0;
            for(int i = 0; i<arr.Length;i++)
            {
                if (arr[i] == searchFor)
                {
                    string message = "Linear - Found in position: " + counter + " In: " + counter + " Comparisons";
                    print(message);
                    return counter;
                }
                counter++;
            }
            print("Linear - Cound not Find Search For");
            Console.Write(searchFor);
            return 0;
        }


        public static long binarySearch(long[] arr, int searchFor)
        {
            long r = arr.Length - 1;
            long l = 0;
            long counter = 0; 
            
            if(searchFor > arr.Length)
            {
                print("serach for is greater than the length of the array");
                return 0;
            }

            while(l <=r)
            {
                long mid = l + (r - l) / 2;
                //Console.WriteLine("["+counter+"] Comparing: " + arr[mid] + " and " + searchFor);
                if(arr[mid] == searchFor)
                {
                    string message = "Binary - Found in position: " + searchFor + " In " + counter + " Comparisons";
                    print(message);
                    //return position of found number
                    return counter;
                }

                else if(arr[mid] < searchFor)
                {
                    
                    
                    l = mid + 1;
                }

                else
                {
                    r = mid - 1;
                }
                counter++;
            }

            //printArray(arr);
            print("Binary - Cound not Find Search For");
            Console.Write(searchFor);
            return 0; 
        }

        //used for printing for sorted array from quick sort
        static void printArray(int[] arr, int n)
        {
            for (int i = 0; i < n; ++i)
            { 
                Console.Write(arr[i]);
            }
        }

        static void Main()
        {
            Stopwatch stopWatch = new Stopwatch();

            //define global params
            //Max and Size need to be the same value
            int Min = 0;
            long Max = 1000000000;
            long size = 1000000000;

            print("Loading...");
            long[] sorted = Program.genArray(Min, Max);


            //define searchfor globally
            Program.print("Search For: ");

            int searchFor = Program.input();


            stopWatch.Start();
            long foundBin = Program.binarySearch(sorted,searchFor);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("Linear - RunTime " + elapsedTime);


            stopWatch.Start();
            long foundLin = Program.linearSearch(sorted, searchFor);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("Linear - RunTime " + elapsedTime);


        }
        
    }
}
