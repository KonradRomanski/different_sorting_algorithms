using System;
using System.Diagnostics;
using System.Threading;

namespace different_sorting_algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            const int cases_quantity = 10;
            const int sorts_quantity = 3;
            Functions functions = new Functions();
            Sorts sorts = new Sorts();
            Stopwatch stopwatch = new Stopwatch();

            //Console.WriteLine(s);
            string[] methods = new string[] {"Insertion Sort", "Selection Sort", "Heap Sort" };
            int[] test_data = functions.Rand(15, 30);
            int[] numbers = new int[test_data.Length];
            double[,] test_cases = new double[sorts_quantity, cases_quantity];
            string[] test_cases_names = new string[cases_quantity];
            double time;
            var data_to_write = "";


            for (int i = 0; i < cases_quantity; i++)
            {
                if (i == 0)
                {
                    test_data = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
                }
                else if (i == 1)
                {
                    test_data = new int[] { 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
                }
                else
                {
                    test_data = functions.Rand(15, 30);
                }
                test_cases_names[i] = string.Join(", ", test_data);
                //Console.WriteLine($"DATA: {string.Join(", ", test_data)} ");

                Console.Write($"{i}\nNormal array:   ");
                functions.Display(test_data);
                Console.WriteLine();

                Array.Copy(test_data, 0, numbers, 0, test_data.Length);
                stopwatch.Start();
                sorts.InsertionSort(numbers);
                stopwatch.Stop();
                Console.Write($"{methods[0]}: ");
                functions.Display(numbers);
                time = stopwatch.Elapsed.TotalMilliseconds;
                Console.Write($"Time elapsed: {time}\n");
                stopwatch.Reset();
                test_cases[0, i] = time;


                Array.Copy(test_data, 0, numbers, 0, test_data.Length);
                stopwatch.Start();
                sorts.SelectionSort(numbers);
                stopwatch.Stop();
                Console.Write($"{methods[1]}: ");
                functions.Display(numbers);
                time = stopwatch.Elapsed.TotalMilliseconds;
                Console.Write($"Time elapsed: {time}\n");
                stopwatch.Reset();
                test_cases[1, i] = time;

                Array.Copy(test_data, 0, numbers, 0, test_data.Length);
                stopwatch.Start();
                sorts.HeapSort(numbers);
                stopwatch.Stop();
                Console.Write($"{methods[2]}:      ");
                functions.Display(numbers);
                time = stopwatch.Elapsed.TotalMilliseconds;
                Console.Write($"Time elapsed: {time}\n");
                stopwatch.Reset();
                test_cases[2, i] = time;
            }
            foreach(var i in test_cases_names)
                Console.WriteLine($"{i}");

            //for (int item = 0; item < 2; item++)
            //{
            //    data_to_write += methods[item] + ";";
            //    for (int j = 0; j < cases_quantity; j++)
            //    {
            //        data_to_write += test_cases[item, j] +";";
            //        //Console.Write($"{test_cases[item, j]} ");
            //    }
            //    data_to_write += "\n";
            //    //Console.WriteLine();
            //}

            data_to_write = ";";
            for(int i = 0; i < methods.Length; i++)
            {
                if (i < methods.Length - 1)
                    data_to_write += methods[i] + ";";
                else
                    data_to_write += methods[i];
            }
            data_to_write += "\n";

            for (int item = 0; item < cases_quantity; item++)
            {


                for (int j = 0; j < sorts_quantity + 1; j++)
                    {
                        if (j == 0)
                        {
                        data_to_write += test_cases_names[item] + ";";
                        }
                        else
                        {
                            if (j < sorts_quantity)
                                data_to_write += test_cases[j - 1, item ] + ";";
                            else
                                data_to_write += test_cases[j - 1, item];
                        }
                    }
                    data_to_write += "\n";

            }

            Console.WriteLine(data_to_write);
            System.IO.File.WriteAllText(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\data.txt", data_to_write);


            //Console.Write("Normal array:   ");
            //functions.Display(test_data);
        
        }
    }
}
