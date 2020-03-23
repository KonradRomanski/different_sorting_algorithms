using System;
using System.Collections.Generic;
using System.Text;

namespace different_sorting_algorithms
{
    public class IntArraysGenerator
    {
        public IntArraysGenerator()
        {
            Data = "This is class containing methods of randomized digits generation";
        }

        public IntArraysGenerator(string data)
        {
            Data = data;
        }

        public string Data { get; }

        public override string ToString()
        {
            return Data;
        }

        private Random rand = new Random();

        public void Rand(int number_of_cases, int array_length, int upper_border)
        {
            const int add = 500;
            string data_to_file = "";

            //data_to_file += "0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14\n";

            for (int i = 0; i < number_of_cases; i++)
            {
                data_to_file += string.Join(", ", Increasing(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Increasing(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Increasing(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Increasing(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Increasing(array_length + add * i, upper_border)) + "\n";
            }
            System.IO.File.WriteAllText(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\cases_2_Increasing.txt", data_to_file);
            data_to_file = "";

            for (int i = 0; i < number_of_cases; i++)
            {
                data_to_file += string.Join(", ", Decreasing(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Decreasing(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Decreasing(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Decreasing(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Decreasing(array_length + add * i, upper_border)) + "\n";
            }
            System.IO.File.WriteAllText(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\cases_3_Decreasing.txt", data_to_file);
            data_to_file = "";


            for (int i = 0; i < number_of_cases; i++)
            {
                data_to_file += string.Join(", ", Constant(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Constant(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Constant(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Constant(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Constant(array_length + add * i, upper_border)) + "\n";
            }
            System.IO.File.WriteAllText(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\cases_4_Constant.txt", data_to_file);
            data_to_file = "";


            for (int i = 0; i < number_of_cases; i++)
            {
                data_to_file += string.Join(", ", Hillock(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Hillock(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Hillock(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Hillock(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Hillock(array_length + add * i, upper_border)) + "\n";
            }
            System.IO.File.WriteAllText(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\cases_Hillock.txt", data_to_file);
            data_to_file = "";


            for (int i = 0; i < number_of_cases; i++)
            {
                data_to_file += string.Join(", ", Dale(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Dale(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Dale(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Dale(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", Dale(array_length + add * i, upper_border)) + "\n";
            }
            System.IO.File.WriteAllText(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\cases_5_Dale.txt", data_to_file);
            data_to_file = "";


            for (int i = 0;  i < number_of_cases; i++)
            {
                data_to_file += string.Join(", ", FullyRand(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", FullyRand(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", FullyRand(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", FullyRand(array_length + add * i, upper_border)) + "\n";
                data_to_file += string.Join(", ", FullyRand(array_length + add * i, upper_border)) + "\n";
            }
            System.IO.File.WriteAllText(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\cases_1_FullyRand.txt", data_to_file);

        }


        private int[] FullyRand(int array_length, int upper_border)
        {
            int[] result = new int[array_length];
            for (int item = 0; item < array_length; item++)
            {
                result[item] = rand.Next(upper_border);
            }
            return result;
        }


        private int[] Increasing(int array_length, int upper_border)
        {
            int[] result = new int[array_length];
            for (int item = 0; item < array_length; item++)
            {
                result[item] = rand.Next(upper_border);
            }
            Array.Sort(result);
            return result;
        }
        

        private int[] Decreasing(int array_length, int upper_border)
        {
            int[] result = new int[array_length];
            for (int item = 0; item < array_length; item++)
            {
                result[item] = rand.Next(upper_border);
            }
            Array.Sort(result);
            Array.Reverse(result);
            return result;
        }


        private int[] Constant(int array_length, int upper_border)
        {
            int[] result = new int[array_length];

            int value = rand.Next(upper_border);
            for (int item = 0; item < array_length; item++)
            {
                result[item] = value;
            }
            Array.Sort(result);
            Array.Reverse(result);
            return result;
        }


        private int[] Hillock(int array_length, int upper_border)
        {
            int[] result = new int[array_length];
            int temp1 = (int)Math.Floor(array_length / 2.0);
            int temp2 = (int)Math.Ceiling(array_length / 2.0);
            int[] temporary1 = new int[temp1];
            int[] temporary2 = new int[temp2];

            for (int item = 0; item < array_length; item++) result[item] = 5555;
            for (int item = 0; item < temp1; item++) temporary1[item] = rand.Next(upper_border);
            for (int item = 0; item < temp2; item++) temporary2[item] = rand.Next(upper_border);

            Array.Sort(temporary1);
            Array.Sort(temporary2);
            Array.Reverse(temporary2);

            for (int item = 0; item < temp1; item++) result[item] = temporary1[item];
            for (int item = temp2; item < array_length; item++) result[item] = temporary2[item - temp2];

            return result;
        }



        private int[] Dale(int array_length, int upper_border)
        {
            int[] result = new int[array_length];
            int temp1 = (int)Math.Floor(array_length / 2.0);
            int temp2 = (int)Math.Ceiling(array_length / 2.0);
            int[] temporary1 = new int[temp1];
            int[] temporary2 = new int[temp2];

            for (int item = 0; item < array_length; item++) result[item] = 5555;
            for (int item = 0; item < temp1; item++) temporary1[item] = rand.Next(upper_border);
            for (int item = 0; item < temp2; item++) temporary2[item] = rand.Next(upper_border);

            Array.Sort(temporary1);
            Array.Sort(temporary2);
            Array.Reverse(temporary1);

            for (int item = 0; item < temp1; item++) result[item] = temporary1[item];
            for (int item = temp2; item < array_length; item++) result[item] = temporary2[item - temp2];
            
            return result;
        }
    }
}
