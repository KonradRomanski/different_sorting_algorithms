using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace different_sorting_algorithms
{
    class Parts
    {
        public void Part1()
        {
            const int cases_quantity = 20;
            const int cases_length = 10;
            const int upper_number_size_border = 100;
            IntArraysGenerator intarraysgenerator = new IntArraysGenerator();
            Sorts sorts = new Sorts();
            Stopwatch stopwatch = new Stopwatch();

            string[] methods = new string[] { "Insertion Sort", "Selection Sort", "Heap Sort", "Counting Sort", "Merge Sort", "Quick Sort", "Shell Sort" }; //names of methods
            int[] numbers = new int[cases_length]; // temporary array of elements to sort
            double[,] test_cases = new double[5, cases_quantity]; //time data

            int[][][] test_cases_numbers = new int[6][][]; //numbers for testing (read from file)
            for (int i = 0; i < 6; i++) test_cases_numbers[i] = new int[cases_quantity * 5][];
            for (int i = 0; i < 6; i++) for (int j = 0; j < cases_quantity * 5; j++) test_cases_numbers[i][j] = new int[cases_length];

            double time; //temporary variable for time handling
            string data_to_write = ""; //for saving in files
            char question = 'n';

            //Creating new data
            Console.Write("Wanna create new data file? y/n: ");
            question = (char)Console.Read();

            if (question == 'y')
            {
                intarraysgenerator.Rand(cases_quantity, cases_length, upper_number_size_border);
            }

            //reading data from file into string[]
            string[] cases_file = System.IO.File.ReadAllLines(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\cases_1_FullyRand.txt");

            //converting string[] into int[]
            for (int i = 0; i < cases_file.Length; i++) test_cases_numbers[0][i] = Array.ConvertAll(cases_file[i].Split(", "), int.Parse);

            cases_file = System.IO.File.ReadAllLines(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\cases_2_Increasing.txt");
            for (int i = 0; i < cases_file.Length; i++) test_cases_numbers[1][i] = Array.ConvertAll(cases_file[i].Split(", "), int.Parse);

            cases_file = System.IO.File.ReadAllLines(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\cases_3_Decreasing.txt");
            for (int i = 0; i < cases_file.Length; i++) test_cases_numbers[2][i] = Array.ConvertAll(cases_file[i].Split(", "), int.Parse);

            cases_file = System.IO.File.ReadAllLines(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\cases_4_Constant.txt");
            for (int i = 0; i < cases_file.Length; i++) test_cases_numbers[3][i] = Array.ConvertAll(cases_file[i].Split(", "), int.Parse);

            cases_file = System.IO.File.ReadAllLines(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\cases_5_Dale.txt");
            for (int i = 0; i < cases_file.Length; i++) test_cases_numbers[4][i] = Array.ConvertAll(cases_file[i].Split(", "), int.Parse);

            cases_file = System.IO.File.ReadAllLines(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\cases_Hillock.txt");
            for (int i = 0; i < cases_file.Length; i++) test_cases_numbers[5][i] = Array.ConvertAll(cases_file[i].Split(", "), int.Parse);

            Console.Write(test_cases_numbers);

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < cases_quantity * 5; j++)
                {
                    Console.Write(String.Join(" ", test_cases_numbers[i][j]));
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            stopwatch.Reset();

            sorts.InsertionSort(numbers);
            sorts.SelectionSort(numbers);
            sorts.HeapSort(numbers);
            sorts.CountingSort(numbers);
            sorts.MergeSort(numbers);
            sorts.QuickSort(numbers);
            sorts.ShellSort(numbers);

            //Console.Write($">> {i}\nNormal array:   ");
            //Console.Write($"{String.Join(" ", test_cases_numbers[0][i])} ");
            //Console.WriteLine();

            //Insertion Sort
            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[0][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[0][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.InsertionSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[0]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[0, i / 5] = time_sum;
            }

            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[1][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[1][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.InsertionSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[0]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[1, i / 5] = time_sum;
            }

            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[2][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[2][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.InsertionSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[0]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[2, i / 5] = time_sum;
            }

            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[3][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[3][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.InsertionSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[0]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[3, i / 5] = time_sum;
            }

            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[4][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[4][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.InsertionSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[0]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[4, i / 5] = time_sum;
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < cases_quantity; j++)
                {
                    Console.Write($"{test_cases[i, j]} ");
                }
                Console.WriteLine();
            }
            data_to_write = "";
            //saving data into file
            data_to_write += "FullyRand;Increasing;Decreasing;Constant;Dale;\n";

            for (int item = 0; item < cases_quantity; item++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j < 5) data_to_write += test_cases[j, item] + ";";
                    else data_to_write += test_cases[j, item];
                }
                data_to_write += "\n";
            }

            Console.WriteLine(data_to_write);
            System.IO.File.WriteAllText(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\data_InsertionSort.txt", data_to_write);



            //SelectionSort
            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[0][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[0][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.SelectionSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[1]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[0, i / 5] = time_sum;
            }

            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[1][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[1][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.SelectionSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[1]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[1, i / 5] = time_sum;
            }

            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[2][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[2][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.SelectionSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[1]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[2, i / 5] = time_sum;
            }

            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[3][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[3][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.SelectionSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[1]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[3, i / 5] = time_sum;
            }

            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[4][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[4][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.SelectionSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[1]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[4, i / 5] = time_sum;
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < cases_quantity; j++)
                {
                    Console.Write($"{test_cases[i, j]} ");
                }
                Console.WriteLine();
            }
            data_to_write = "";
            //saving data into file
            data_to_write += "FullyRand;Increasing;Decreasing;Constant;Dale;\n";

            for (int item = 0; item < cases_quantity; item++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j < 5) data_to_write += test_cases[j, item] + ";";
                    else data_to_write += test_cases[j, item];
                }
                data_to_write += "\n";
            }

            Console.WriteLine(data_to_write);
            System.IO.File.WriteAllText(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\data_SelectionSort.txt", data_to_write);



            //HeapSort
            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[0][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[0][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.HeapSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[2]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[0, i / 5] = time_sum;
            }

            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[1][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[1][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.HeapSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[2]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[1, i / 5] = time_sum;
            }

            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[2][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[2][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.HeapSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[2]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[2, i / 5] = time_sum;
            }

            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[3][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[3][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.HeapSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[2]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[3, i / 5] = time_sum;
            }

            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[4][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[4][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.HeapSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[2]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[4, i / 5] = time_sum;
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < cases_quantity; j++)
                {
                    Console.Write($"{test_cases[i, j]} ");
                }
                Console.WriteLine();
            }
            data_to_write = "";
            //saving data into file
            data_to_write += "FullyRand;Increasing;Decreasing;Constant;Dale;\n";

            for (int item = 0; item < cases_quantity; item++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j < 5) data_to_write += test_cases[j, item] + ";";
                    else data_to_write += test_cases[j, item];
                }
                data_to_write += "\n";
            }

            Console.WriteLine(data_to_write);
            System.IO.File.WriteAllText(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\data_HeapSort.txt", data_to_write);


            //MergeSort
            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[0][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[0][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.MergeSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[4]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[0, i / 5] = time_sum;
            }

            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[1][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[1][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.MergeSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[4]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[1, i / 5] = time_sum;
            }

            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[2][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[2][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.MergeSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[4]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[2, i / 5] = time_sum;
            }

            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[3][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[3][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.MergeSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[4]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[3, i / 5] = time_sum;
            }

            for (int i = 0; i < cases_quantity * 5; i += 5)
            {
                double time_sum = 0;
                numbers = new int[test_cases_numbers[4][i].Length]; // temporary array of elements to sort


                for (int j = 0; j < 5; j++)
                {
                    test_cases_numbers[4][i + j].CopyTo(numbers, 0); // copying data from test_data to numbers
                    stopwatch.Start();
                    sorts.MergeSort(numbers);
                    stopwatch.Stop();

                    Console.Write($"{methods[4]}: ");
                    Console.Write($"{String.Join(" ", numbers)} "); // displaying int[]
                    time = stopwatch.Elapsed.TotalMilliseconds;
                    Console.Write($"Time elapsed: {time}\n");
                    stopwatch.Reset();
                    time_sum += time;
                }

                time_sum /= 5;
                test_cases[4, i / 5] = time_sum;
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < cases_quantity; j++)
                {
                    Console.Write($"{test_cases[i, j]} ");
                }
                Console.WriteLine();
            }
            data_to_write = "";
            //saving data into file
            data_to_write += "FullyRand;Increasing;Decreasing;Constant;Dale;\n";

            for (int item = 0; item < cases_quantity; item++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (j < 5) data_to_write += test_cases[j, item] + ";";
                    else data_to_write += test_cases[j, item];
                }
                data_to_write += "\n";
            }

            Console.WriteLine(data_to_write);
            System.IO.File.WriteAllText(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\data_MergeSort.txt", data_to_write);
        }
    }
}
