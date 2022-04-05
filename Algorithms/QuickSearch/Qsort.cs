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
    }
}
