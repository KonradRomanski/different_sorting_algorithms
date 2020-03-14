using System;
using System.Collections.Generic;
using System.Text;

namespace different_sorting_algorithms
{
    public class Sorts
    {
        public Sorts()
        {
            Data = "This is class containing sorts algorithms";
        }

        public Sorts(string data)
        {
            Data = data;
        }

        public string Data { get; }

        public override string ToString()
        {
            return Data;
        }

        public void InsertionSort(int[] numbers)
        {
            for (int j = 1; j < numbers.Length; j++)
            {
                int key = numbers[j];
                int i = j - 1;

                while(i >= 0 && numbers[i] > key)
                {
                    numbers[i + 1] = numbers[i];
                    i--;
                }

                numbers[i + 1] = key;
            }
        }


        public void SelectionSort(int[] numbers)
        {

            for (int j = numbers.Length - 1; j >= 1; j--)
            {

                int max = j;

                for(int i = j-1; i >= 0; i--)
                {
                    if(numbers[i] > numbers[max])
                        max = i;
                }
                (numbers[j], numbers[max]) = (numbers[max], numbers[j]);

            }
        }


        private void Heapify(int[] numbers, int i, int heapsize)
        {
            int largest = i;
            int l = (2 * i) + 1;
            int r = (2 * i) + 2;
            if (l < heapsize && numbers[l] > numbers[i])
                largest = l;
            else
                largest = i;
            if (r < heapsize && numbers[r] > numbers[largest])
                largest = r;
            if (largest != i)
            {
                (numbers[i], numbers[largest]) = (numbers[largest], numbers[i]);
                Heapify(numbers, largest, heapsize);
            }

        }


        private void BuildHeap(int[] numbers)
        {
            int heapsize = numbers.Length;
            for(int i = heapsize / 2 - 1; i >= 0; i--)
            {
                Heapify(numbers, i, heapsize);
            }
        }


        public void HeapSort(int[] numbers)
        {
            BuildHeap(numbers);
            int heapsize = numbers.Length;
            for(int i = heapsize - 1; i >= 0; i--)
            {
                (numbers[0], numbers[i]) = (numbers[i], numbers[0]);
                heapsize--;
                Heapify(numbers, 0, heapsize);
            }
        }
    }

}
