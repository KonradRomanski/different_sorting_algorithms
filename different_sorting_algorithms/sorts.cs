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

        

        public void MergeSort()
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
            int x = numbers[(left + right) / 2];
            int i = left;
            int j = right;
            do
            {

                while (numbers[i] < x) i++;
                while (numbers[j] > x) j--;
                if (i <= j) 
                { 
                    (numbers[i], numbers[j]) = (numbers[j], numbers[i]);
                    i++;
                    j--; 
                }

            } while (i <= j);

            if (left < j) QuickSortMain(numbers, left, j);
            if (i < right) QuickSortMain(numbers, i, right);
        }


        public void CountingSort(int[] numbers)
        {
            int k = 0;
            for (int i = 0; i < numbers.Length; i++) if (numbers[i] > k) k = numbers[i];

            int[] C = new int[k + 2];
            int[] B = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++) C[numbers[i]]++;

            for (int i = 1; i < numbers.Length; i++) C[i] += C[i - 1];

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                B[C[numbers[i]]] = numbers[i];
                C[numbers[i]]--;
            }

        }

        //        COUNTING-SORT(A)
        // 1  k ‹ 0
        // 2  for i ‹ 1 to length[A]
        // 3     do if A[i] > k
        // 4         then k ‹ A[i]
        // 5  new C(k)
        // 6  new B(length[A])
        // 7  for i ‹ 1 to length[A]
        // 8     do C[A[i]] ‹ C[A[i]] + 1
        // 9  for j ‹ 2 to k
        //10     do C[j] ‹ C[j] + C[j - 1]
        //11  for i ‹ length[A] downto 1
        //12     do B[C[A[i]]] ‹ A[i]
        //13        C[A[i]] ‹ C[A[i]] - 1
        //14  return B

        public void ShellSort()
        {

        }


//        SHELL-SORT(A)
// 1  t ‹ (lg length[A])
// 2  for s ‹ t - 1 downto 0
// 3     do h ‹ 2 ^ s
// 4        for j ‹ h + 1 to length[A]
// 5           do key ‹ A[j]
// 6              i ‹ j - h
// 7              while (i > 0) i(A[i] > key)
// 8                 do A[i + h] ‹ A[i]
// 9                    i ‹ i - h
//10              A[i + h] ‹ key
//11  return A

    }

}
