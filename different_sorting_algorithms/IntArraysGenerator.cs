﻿using System;
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
            string data_to_file = "";
            var times = 0;

            data_to_file += "0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14\n";

            for (int i = 1; i < (int)(Math.Ceiling(0.18*number_of_cases)); i++)
            {
                data_to_file += string.Join(", ", Increasing(array_length, upper_border)) + "\n";
                times++;
            }
            
           for (int i = 0; i < (int)(Math.Ceiling(0.18 * number_of_cases)); i++)
            {
                data_to_file += string.Join(", ", Decreasing(array_length, upper_border)) + "\n";
                times++;
            }

            for (int i = 0; i < (int)(Math.Ceiling(0.1 * number_of_cases)); i++)
            {
                data_to_file += string.Join(", ", Constant(array_length, upper_border)) + "\n";
                times++;
            }
            
            for (int i = 0; i < (int)(Math.Ceiling(0.18 * number_of_cases)); i++)
            {
                data_to_file += string.Join(", ", Hillock(array_length, upper_border)) + "\n";
                times++;
            }
            
            for (int i = 0; i < (int)(Math.Ceiling(0.18 * number_of_cases)); i++)
            {
                data_to_file += string.Join(", ", Dale(array_length, upper_border)) + "\n";
                times++;
            }

            while (times < number_of_cases - 1)
            {
                data_to_file += string.Join(", ", FullyRand(array_length, upper_border)) + "\n";
                times++;
            }

            System.IO.File.WriteAllText(@"C:\Users\konra\source\repos\AISD\different_sorting_algorithms\cases.txt", data_to_file);
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
            int[] temporary = new int[array_length];

            for (int item = 0; item < array_length; item++)
            {
                result[item] = rand.Next(upper_border);
                temporary[item] = rand.Next(upper_border);
            }
            Array.Sort(result);
            Array.Sort(temporary);
            Array.Reverse(temporary);

            for (int item = array_length/2; item < array_length; item++)
            {
                result[item] = temporary[item];
            }

            return result;
        }


        private int[] Dale(int array_length, int upper_border)
        {
            int[] result = new int[array_length];
            int[] temporary = new int[array_length];

            for (int item = 0; item < array_length; item++)
            {
                result[item] = rand.Next(upper_border);
                temporary[item] = rand.Next(upper_border);
            }
            Array.Sort(result);
            Array.Sort(temporary);
            Array.Reverse(result);

            for (int item = array_length/2; item < array_length; item++)
            {
                result[item] = temporary[item];
            }

            return result;
        }
    }
}