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
            MergeSortMain(numbers, 0, numbers.Length - 1, B);
        }


        private void MergeSortMain(int[] numbers, int l, int r, int[] B)
        {

        }


        //        MERGE-SORT-MAIN(A)
        // 1  new B(length[A])
        // 2  MERGE-SORT(A, 1, length[A], B)
        // 3  return A
        //MERGE-SORT(A, l, r, B)
        // 1  m = (l + r) / 2
        // 2  if (m - l) > 0
        // 3   then MERGE-SORT(A, l, m, B)
        // 4  if (r - m) > 1
        // 5   then MERGE-SORT(A, m + 1, r, B)
        // 6  i = l
        // 7  j = m + 1
        // 8  for k = l to r
        // 9     do if ((i <= m) i(j > r)) lub(((i <= m) i(j <= r)) i(A[i] <= A[j]))
        //10         then B[k] = A[i]
        //11              i = i + 1
        //12         else B[k] = A[j]
        //13              j = j + 1
        //14  for k = l to r
        //15     do A[k] = B[k]



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



        public void QuickSort(int[] numbers)
        {
            QuickSortMain(numbers, 0, numbers.Length - 1);
        }


        private void QuickSortMain(int[] numbers, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(numbers, left, right);
                QuickSortMain(numbers, left, pivot - 1);
                QuickSortMain(numbers, pivot + 1, right);
            }
        }


        private int Partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[right];
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
