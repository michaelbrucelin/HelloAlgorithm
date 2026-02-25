using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Sort
{
    public class QuickSort
    {
        private static readonly Random random = new Random();

        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            FisherYatesShuffle(array);
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort<T>(T[] array, int lo, int hi) where T : IComparable<T>
        {
            if (hi <= lo) return;
            int j = partition(array, lo, hi);
            Sort(array, lo, j - 1);
            Sort(array, j + 1, hi);
        }


        private static int partition<T>(T[] array, int lo, int hi) where T : IComparable<T>
        {
            // if (lo == hi) return lo;  // 独立执行需要

            int i = lo, j = hi + 1;
            T v = array[lo];
            while (true)
            {
                while (array[++i].CompareTo(v) < 0) if (i == hi) break;
                while (array[--j].CompareTo(v) > 0) ;  // if (j == lo) break;
                if (i >= j) break;
                Swap(array, i, j);
            }
            Swap(array, lo, j);

            return j;
        }

        public static void Quick3way<T>(T[] array) where T : IComparable<T>
        {
            FisherYatesShuffle(array);
            Quick3way(array, 0, array.Length - 1);
        }

        private static void Quick3way<T>(T[] array, int lo, int hi) where T : IComparable<T>
        {
            if (hi <= lo) return;

            int lt = lo, i = lo + 1, gt = hi;
            T v = array[lo];
            while (i <= gt)
            {
                int cmp = array[i].CompareTo(v);
                if (cmp < 0) Swap(array, lt++, i++);
                else if (cmp > 0) Swap(array, i, gt--);
                else i++;
            }
            Quick3way(array, lo, lt - 1);
            Quick3way(array, gt + 1, hi);
        }

        public static void FisherYatesShuffle<T>(T[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            for (int i = array.Length - 1, j; i > 0; i--)
            {
                j = random.Next(0, i + 1);
                Swap(array, i, j);
            }
        }

        private static void Swap<T>(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
