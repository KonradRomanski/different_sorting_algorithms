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
            for (int i = 1; i < numbers.Length; i++)
            {
                int key = numbers[i];
                int j = i - 1;

                while (j >= 0 && numbers[j] > key)
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }

                numbers[j + 1] = key;
            }
        }


        public void SelectionSort(int[] numbers)
        {

            for (int j = numbers.Length - 1; j >= 1; j--)
            {

                int max = j;

                for (int i = j - 1; i >= 0; i--)
                {
                    if (numbers[i] > numbers[max])
                        max = i;
                }
                (numbers[j], numbers[max]) = (numbers[max], numbers[j]);

            }
        }


        public void HeapSort(int[] numbers)
        {
            BuildHeap(numbers);
            int heapsize = numbers.Length;
            for (int i = heapsize - 1; i >= 0; i--)
            {
                (numbers[0], numbers[i]) = (numbers[i], numbers[0]);
                heapsize--;
                Heapify(numbers, 0, heapsize);
            }
        }


        private void BuildHeap(int[] numbers)
        {
            int heapsize = numbers.Length;
            for (int i = heapsize / 2 - 1; i >= 0; i--) Heapify(numbers, i, heapsize);
        }


        private void Heapify(int[] numbers, int i, int heapsize)
        {
            int largest = i;
            int l = (2 * i) + 1;
            int r = (2 * i) + 2;
            if (l < heapsize && numbers[l] > numbers[i]) largest = l;

            if (r < heapsize && numbers[r] > numbers[largest]) largest = r;

            if (largest != i)
            {
                (numbers[i], numbers[largest]) = (numbers[largest], numbers[i]);
                Heapify(numbers, largest, heapsize);
            }

        }



        public void MergeSort(int[] numbers)
        {
            int[] B = new int[numbers.Length];
            MergeSortMain(numbers, 0, numbers.Length - 1);
        }


        //private void MergeSortMain(int[] numbers, int left, int right, int[] B)
        //{
        //    int m = left + (right - left) / 2;

        //    if (left < right) MergeSortMain(numbers, left, m, B);
        //    if (left < right) MergeSortMain(numbers, m + 1, right, B);

        //    int i = left;
        //    int j = m;

        //    for (int k = 0; k < right; k++)
        //    {
        //        if ((i <= m && j <= right) || ((i <= m && j <= right) && numbers[i] <= numbers[j]))
        //        {
        //            B[k] = numbers[i];
        //            i++;
        //        }
        //        else
        //        {
        //            B[k] = numbers[j];
        //            j++;
        //        }

        //    }

        //    for (int k = 0; k < right; k++) numbers[k] = B[k];
        //}


        private void MergeSortMain(int[] numbers, int left, int right)
        {
            if (left < right)
            {
                int m = left + (right - left) / 2;

                MergeSortMain(numbers, left, m);
                MergeSortMain(numbers, m + 1, right);

                Merge(numbers, left, m, right);
            }
        }

        private void Merge(int[] numbers, int left, int m, int right)
        {
            int i, j, k;
            int n1 = m - left + 1;
            int n2 = right - m;
            int[] L = new int[n1];
            int[] R = new int[n2];

            for (i = 0; i < n1; i++) L[i] = numbers[left + i];
            for (j = 0; j < n2; j++) R[j] = numbers[m + 1 + j];

            i = 0;
            j = 0;
            k = left;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    numbers[k] = L[i];
                    i++;
                }
                else
                {
                    numbers[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                numbers[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                numbers[k] = R[j];
                j++;
                k++;
            }
        }


        //public void QuickSort(int[] numbers)
        //{
        //    QuickSortMain(numbers, 0, numbers.Length - 1);
        //}


        //private void QuickSortMain(int[] numbers, int p, int r)
        //{
        //    if (p < r)
        //    {
        //        int q = Partition(numbers, p, r);
        //        QuickSortMain(numbers, p, q - 1);
        //        QuickSortMain(numbers, q + 1, r);
        //    }
        //}


        //private int Partition(int[] numbers, int p, int r)
        //{
        //    int x = numbers[(p + r) / 2];
        //    int i = p;
        //    int j = r;
        //    while (true)
        //    {
        //        while (numbers[i] > x) i++;
        //        while (numbers[j] < x) j--;
        //        if (i < j)
        //        {
        //            (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
        //        }
        //        else return j;
        //    }
        //}



        public void QuickSort(int[] numbers, int p)
        {
            QuickSortMain(numbers, 0, numbers.Length - 1, p);
        }


        private void QuickSortMain(int[] numbers, int left, int right, int p)
        {
            if (left < right)
            {
                int pivot = Partition(numbers, left, right, p);
                QuickSortMain(numbers, left, pivot - 1, p);
                QuickSortMain(numbers, pivot + 1, right, p);
            }
        }


        private int Partition(int[] numbers, int left, int right, int p)
        {
            Random rand = new Random();
            int pivot = 0;

            switch (p)
            {
                case 0:
                    {
                        pivot = numbers[right];
                        break;
                    }
                case 1:
                    {
                        pivot = numbers[((right + left) / 2)];
                        break;
                    }
                case 2:
                    {
                        pivot = rand.Next(right);
                        break;
                    }
            }


            //int pivot = numbers[(right + left) / 2]
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (numbers[j] <= pivot)
                {
                    i++;
                    (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
                }
            }

            (numbers[i + 1], numbers[right]) = (numbers[right], numbers[i + 1]);

            return i + 1;
        }


        public void CountingSort(int[] numbers)
        {
            int k = 0;
            for (int i = 0; i < numbers.Length; i++) if (numbers[i] > k) k = numbers[i];

            int[] C = new int[k + 1];
            int[] B = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++) C[numbers[i]]++;

            for (int i = 1; i < C.Length; i++) C[i] += C[i - 1];

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                B[C[numbers[i]] - 1] = numbers[i];
                C[numbers[i]]--;
            }

            for (int i = 0; i < numbers.Length; i++) numbers[i] = B[i];

        }


        public void ShellSort(int[] numbers)
        {
            int array_size = numbers.Length;

            for (int gap = array_size / 2; gap > 0; gap /= 2)
            {

                for (int i = gap; i < array_size; i++)
                {

                    int key = numbers[i];

                    //int j;
                    //for (j = i; j >= gap && numbers[j - gap] > key; j -= gap) numbers[j] = numbers[j - gap];

                    int j = i - gap;
                    while (j >= 0 && numbers[j] > key)
                    {
                        numbers[j + gap] = numbers[j];
                        j -= gap;
                    }

                    numbers[j + gap] = key;
                    //numbers[j] = key;
                }
            }


        }

    }

}
