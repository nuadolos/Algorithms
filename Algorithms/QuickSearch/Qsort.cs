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
    static public class Qsort
    {
        /// <summary>
        /// Метод, возвращающий отсортированный список по возрастанию
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<T> QuickSort<T>(this IEnumerable<T> list) where T : IComparable<T>
        {
            // Проверка на пустой список
            if (!list.Any())
                return Enumerable.Empty<T>();

            // Находит значение первого элемента
            // Переменная является опорным элементом
            var pivot = list.First();

            // С помощью рекурсии перебирает значения меньше pivot
            // и возвращает список элементов, чьи значения меньше pivot
            var less = list.Skip(1).Where(item => item.CompareTo(pivot) <= 0).QuickSort();

            // С помощью рекурсии перебирает значения больше pivot
            // и возвращает список элементов, чьи значения больше pivot
            var greater = list.Skip(1).Where(item => item.CompareTo(pivot) > 0).QuickSort();

            // Совмещение всех списков воедино
            return less.Concat(new [] {pivot}.Concat(greater));
        }

        /// <summary>
        /// Тот же метод QuickSort, только сокращен до одной строки
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IEnumerable<T> ShortQuickSort<T>(this IEnumerable<T> list) where T : IComparable<T>
        {
            return !list.Any() ? Enumerable.Empty<T>() : list.Skip(1)
                .Where(item => item.CompareTo(list.First()) <= 0)
                .Concat(new[] { list.First() })
                .Concat(list.Skip(1)
                    .Where(item => item.CompareTo(list.First()) > 0))
                .ShortQuickSort();
        }

        /// <summary>
        /// Метод, совершающий сортировку по возрастанию
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        static int Partition(int[] array, int start, int end)
        {
            // Запоминает элемент после младшего в массиве
            int marker = start;

            for (int i = start; i <= end; i++)
            {
                if (array[i] <= array[end])
                {
                    int temp = array[marker];
                    array[marker] = array[i];
                    array[i] = temp;
                    marker++;
                }
            }
            
            // Возвращает индекс элемента до опорного
            return marker == 0 ? 1 : --marker;
        }

        /// <summary>
        /// Метод, возвращающий массив, отсортированный по возрастанию
        /// </summary>
        /// <param name="array"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int[] QuickSortArray(int[] array, int start, int end)
        {
            if (start >= end)
                return array;

            // Опорный элемент
            int pivot = Partition(array, start, end);

            // Сортирует элементы в массиве до опорного
            // т.е. все значения элементов меньше или равны значению опорного 
            QuickSortArray(array, start, pivot - 1);

            // Сортирует элементы в массиве, начиная с опорного
            // т.е. все значения элементов больше значения опорного 
            QuickSortArray(array, pivot + 1, end);

            // Возвращает отсортированный массив
            return array;
        }
    }
}
