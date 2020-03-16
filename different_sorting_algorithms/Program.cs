using System;
using System.Diagnostics;
using System.Threading;

namespace different_sorting_algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            const int cases_quantity = 100;
            const int sorts_quantity = 6;
            const int cases_length = 16;
            const int upper_number_size_border = 30;
            IntArraysGenerator intarraysgenerator = new IntArraysGenerator();
            Sorts sorts = new Sorts();
            Stopwatch stopwatch = new Stopwatch();

            string[] methods = new string[] {"Insertion Sort", "Selection Sort", "Heap Sort", "Counting Sort", "Merge Sort", "Quick Sort", "Shell Sort" }; //names of methods
            int[] numbers = new int[cases_length]; // temporary array of elements to sort
            double[,] test_cases = new double[sorts_quantity, cases_quantity]; //time data
            int[][] test_cases_numbers = new int[cases_quantity][]; //numbers for testing (read from file)
            for (int i = 0; i < cases_quantity; i++) test_cases_numbers[i] = new int[cases_length];
            double time; //temporary variable for time handling
            string data_to_write = ""; //for saving in files
            char question = 'n'; 

            //Creating new data
            //Console.Write("Wanna create new data file? y/n: ");
            //question = (char)Console.Read();

            if (question == 'y')
            {
                intarraysgenerator.Rand(cases_quantity, cases_length, upper_number_size_border);
            }

            //reading data from file into string[]
            string[] cases_file = System.IO.File.ReadAllLines(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\cases.txt");

            //converting string[] into int[]
            for (int i = 0; i < cases_file.Length; i++) test_cases_numbers[i] = Array.ConvertAll(cases_file[i].Split(", "), int.Parse);
            
            stopwatch.Reset();

            sorts.InsertionSort(numbers);
            sorts.SelectionSort(numbers);
            sorts.HeapSort(numbers);


            for (int i = 0; i < cases_quantity; i++)
            {
                Console.Write($">> {i}\nNormal array:   ");
                Console.Write($"{String.Join(" ", test_cases_numbers[i])} ");
                Console.WriteLine();


                test_cases_numbers[i].CopyTo(numbers, 0); // copying data from test_data to numbers
                stopwatch.Start();
                sorts.InsertionSort(numbers);
                stopwatch.Stop();
                Console.Write($"{methods[0]}: ");
                Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                time = stopwatch.Elapsed.TotalMilliseconds;
                Console.Write($"Time elapsed: {time}\n");
                stopwatch.Reset();
                test_cases[0, i] = time;


                test_cases_numbers[i].CopyTo(numbers, 0);
                stopwatch.Start();
                sorts.SelectionSort(numbers);
                stopwatch.Stop();
                Console.Write($"{methods[1]}: ");
                Console.Write($"{String.Join(" ", numbers)} ");
                time = stopwatch.Elapsed.TotalMilliseconds;
                Console.Write($"Time elapsed: {time}\n");
                stopwatch.Reset();
                test_cases[1, i] = time;


                test_cases_numbers[i].CopyTo(numbers, 0);
                stopwatch.Start();
                sorts.HeapSort(numbers);
                stopwatch.Stop();
                Console.Write($"{methods[2]}:      ");
                Console.Write($"{String.Join(" ", numbers)} ");
                time = stopwatch.Elapsed.TotalMilliseconds;
                Console.Write($"Time elapsed: {time}\n");
                stopwatch.Reset();
                test_cases[2, i] = time;


                test_cases_numbers[i].CopyTo(numbers, 0);
                stopwatch.Start();
                sorts.CountingSort(numbers);
                stopwatch.Stop();
                Console.Write($"{methods[3]}:  ");
                Console.Write($"{String.Join(" ", numbers)} ");
                time = stopwatch.Elapsed.TotalMilliseconds;
                Console.Write($"Time elapsed: {time}\n");
                stopwatch.Reset();
                test_cases[3, i] = time;


                //test_cases_numbers[i].CopyTo(numbers, 0);
                //stopwatch.Start();
                //sorts.MergeSort(numbers);
                //stopwatch.Stop();
                //Console.Write($"{methods[4]}:      ");
                //Console.Write($"{String.Join(" ", numbers)} ");
                //time = stopwatch.Elapsed.TotalMilliseconds;
                //Console.Write($"Time elapsed: {time}\n");
                //stopwatch.Reset();
                //test_cases[4, i] = time;


                test_cases_numbers[i].CopyTo(numbers, 0);
                stopwatch.Start();
                sorts.QuickSort(numbers);
                stopwatch.Stop();
                Console.Write($"{methods[5]}:     ");
                Console.Write($"{String.Join(" ", numbers)} ");
                time = stopwatch.Elapsed.TotalMilliseconds;
                Console.Write($"Time elapsed: {time}\n");
                stopwatch.Reset();
                test_cases[4, i] = time;


                test_cases_numbers[i].CopyTo(numbers, 0);
                stopwatch.Start();
                sorts.ShellSort(numbers);
                stopwatch.Stop();
                Console.Write($"{methods[6]}:     ");
                Console.Write($"{String.Join(" ", numbers)} ");
                time = stopwatch.Elapsed.TotalMilliseconds;
                Console.Write($"Time elapsed: {time}\n");
                stopwatch.Reset();
                test_cases[5, i] = time;
            }

            //saving data into file
            for(int i = 0; i < methods.Length; i++)
            {
                if (i < methods.Length - 1) data_to_write += methods[i] + ";";
                else data_to_write += methods[i];
            }
            data_to_write += "\n";

            for (int item = 0; item < cases_quantity; item++)
            {
                for (int j = 0; j < sorts_quantity; j++)
                    {
                        if (j < sorts_quantity) data_to_write += test_cases[j, item ] + ";";
                        else data_to_write += test_cases[j, item];
                    }
                    data_to_write += "\n";
            }

            Console.WriteLine(data_to_write);
            System.IO.File.WriteAllText(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\data.txt", data_to_write);
        }
    }
}
