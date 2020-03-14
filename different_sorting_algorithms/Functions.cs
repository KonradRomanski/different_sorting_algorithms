using System;
using System.Collections.Generic;
using System.Text;

namespace different_sorting_algorithms
{
    public class Functions
    {
        public Functions()
        {
            Data = "This is class containing different functions";
        }

        public Functions(string data)
        {
            Data = data;
        }

        public string Data { get; }

        public override string ToString()
        {
            return Data;
        }

        public void Display(int[] data)
        {
            foreach(var item in data)
            {
                Console.Write("{0} ", item.ToString());
            }
        }

        public int[] Rand(int size, int big)
        {
            Random rand = new Random();

            int[] result = new int[size];
            for (int item = 0; item < size; item++)
            {
                result[item] = rand.Next(big);
            }

            return result;
        }
    }
}
