using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.QuickSearch
{
    /// <summary>
    /// Алгоритм "Быстрая сортировка"
    /// </summary>
    public class QuickSearchExample
    {
        /// <summary>
        /// Пример работы алгоритма "Быстрая сортировка".
        /// Также происходит сравнение времени выполнения
        /// встроенного метода Sort и написанного метода QuickSort
        /// </summary>
        public static void QSortExample()
        {
            Random random = new Random();
            List<int> listDefaultSort = new List<int>();

            for (int i = 0; i < 1000; i++)
                listDefaultSort.Add(random.Next(-999, 1000));

            Console.WriteLine("\nОбычная сортировка\n");

            List<int> listQuickSort = listDefaultSort.ToList();

            DateTime nowSort = DateTime.Now;

            listDefaultSort.Sort();
            Console.WriteLine($"\n\n{(DateTime.Now - nowSort).TotalSeconds}\n");

            foreach (var item in listDefaultSort)
            {
                Console.Write(item + " ");
            }

            Console.ReadKey();
            Console.WriteLine("\n\nБыстрая сортировка\n");

            nowSort = DateTime.Now;

            var enumerable = listQuickSort.QuickSort();
            Console.WriteLine($"\n\n{(DateTime.Now - nowSort).TotalSeconds}\n");

            foreach (var item in enumerable)
            {
                Console.Write(item + " ");
            }
        }

        /// <summary>
        /// Метод сравнения времени выполнения
        /// стандартной сортировки Sort класса Array и быстрой сортировки QuickSort
        /// </summary>
        public static void QSortArrayExample()
        {
            Random random = new Random();
            int[] arrayDefaultSort = new int[10000];

            for (int i = 0; i < arrayDefaultSort.Length; i++)
                arrayDefaultSort[i] = (random.Next(-999, 1000));

            Console.WriteLine("\nОбычная сортировка\n");

            int[] arrayQuickSort = arrayDefaultSort.ToArray();

            DateTime nowSort = DateTime.Now;

            Array.Sort(arrayDefaultSort);
            Console.WriteLine($"\n\n{(DateTime.Now - nowSort).TotalSeconds}\n");

            foreach (var item in arrayDefaultSort)
            {
                Console.Write(item + " ");
            }

            Console.ReadKey();
            Console.WriteLine("\n\nБыстрая сортировка\n");

            nowSort = DateTime.Now;

            int[] testArray = Qsort.QuickSortArray(arrayQuickSort, 0, arrayQuickSort.Length - 1);
            Console.WriteLine($"\n\n{(DateTime.Now - nowSort).TotalSeconds}\n");

            foreach (var item in testArray)
            {
                Console.Write(item + " ");
            }
        }

        /// <summary>
        /// Метод сравнения времени выполнения
        /// стандартной сортировки Sort объекта List<int> 
        /// и быстрой сортировки QuickSort массива int[]
        /// </summary>
        public static void ListSortVsArrayQSort()
        {
            Random random = new Random();
            List<int> listDefaultSort = new List<int>();

            for (int i = 0; i < 10000; i++)
                listDefaultSort.Add(random.Next(-999, 1000));

            Console.WriteLine("\nОбычная сортировка\n");

            int[] arrayQuickSort = listDefaultSort.ToArray();

            DateTime nowSort = DateTime.Now;

            listDefaultSort.Sort();
            Console.WriteLine($"\n\n{(DateTime.Now - nowSort).TotalSeconds}\n");

            foreach (var item in listDefaultSort)
            {
                Console.Write(item + " ");
            }

            Console.ReadKey();
            Console.WriteLine("\n\nБыстрая сортировка\n");

            nowSort = DateTime.Now;

            int[] testArray = Qsort.QuickSortArray(arrayQuickSort, 0, arrayQuickSort.Length - 1);
            Console.WriteLine($"\n\n{(DateTime.Now - nowSort).TotalSeconds}\n");

            foreach (var item in testArray)
            {
                Console.Write(item + " ");
            }
        }
    }
}
