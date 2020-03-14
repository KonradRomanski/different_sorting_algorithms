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
            const int cases_length = 15;
            const int upper_number_size_border = 30;
            Functions functions = new Functions();
            Sorts sorts = new Sorts();
            Stopwatch stopwatch = new Stopwatch();

            string[] methods = new string[] {"Insertion Sort", "Selection Sort", "Heap Sort" }; //names of methods
            int[] numbers = functions.Rand(cases_length, upper_number_size_border); // temporary array of elements to sort
            double[,] test_cases = new double[sorts_quantity, cases_quantity]; //time data
            int[][] test_cases_numbers = new int[cases_quantity][]; //numbers for testing (read from file)
            for (int i = 0; i < cases_quantity; i++) test_cases_numbers[i] = new int[cases_length];
            double time; //temporary variable for time handling
            string data_to_write = ""; //for saving in files
            char question = 'n'; 

            //START of creating new data
            Console.Write("Wanna create new data file? y/n: ");
            question = (char)Console.Read();

            if (question == 'y')
            {
                
                data_to_write += "0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14\n";
                data_to_write += "14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0\n";

                for (int i = 2; i < cases_quantity; i++)
                {
                    numbers = functions.Rand(cases_length, upper_number_size_border);
                    data_to_write += string.Join(", ", numbers) + "\n";
                }
                //saving data_to_write into file
                System.IO.File.WriteAllText(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\cases.txt", data_to_write);
                data_to_write = "";
                Array.Clear(numbers, 0, numbers.Length);
            }

            //END of creating new test data

            //reading data from file into string[]
            string[] cases_file = System.IO.File.ReadAllLines(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\cases.txt");

            //converting string[] into int[]
            for (int i = 0; i < cases_file.Length; i++) test_cases_numbers[i] = Array.ConvertAll(cases_file[i].Split(", "), int.Parse);



            for (int i = 0; i < cases_quantity; i++)
            {
                Console.Write($"{i}\nNormal array:   ");
                functions.Display(test_cases_numbers[i]);
                Console.WriteLine();


                test_cases_numbers[i].CopyTo(numbers, 0); // copying data from test_data to numbers
                stopwatch.Start();
                sorts.InsertionSort(numbers);
                stopwatch.Stop();
                Console.Write($"{methods[0]}: ");
                functions.Display(numbers);
                time = stopwatch.Elapsed.TotalMilliseconds;
                Console.Write($"Time elapsed: {time}\n");
                stopwatch.Reset();
                test_cases[0, i] = time;


                test_cases_numbers[i].CopyTo(numbers, 0);
                stopwatch.Start();
                sorts.SelectionSort(numbers);
                stopwatch.Stop();
                Console.Write($"{methods[1]}: ");
                functions.Display(numbers);
                time = stopwatch.Elapsed.TotalMilliseconds;
                Console.Write($"Time elapsed: {time}\n");
                stopwatch.Reset();
                test_cases[1, i] = time;


                test_cases_numbers[i].CopyTo(numbers, 0);
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

            //saving data into file
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
