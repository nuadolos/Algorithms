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

            foreach (var item in listDefaultSort)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine($"\n\n{(DateTime.Now - nowSort).TotalSeconds}\n");

            Console.ReadKey();
            Console.WriteLine("\n\nБыстрая сортировка\n");

            nowSort = DateTime.Now;

            var enumerable = listQuickSort.QuickSort();
            foreach (var item in enumerable)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine($"\n\n{(DateTime.Now - nowSort).TotalSeconds}\n");
        }
    }
}
