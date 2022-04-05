using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms;

namespace Algorithms.Recursion
{
    /// <summary>
    /// Рекурсия
    /// </summary>
    public class RecursionExample
    {
        /// <summary>
        /// Пример работы рекурсии
        /// </summary>
        public static void RecursiveMethodsExample()
        {
            int[] recursiveArray = FuncArray.Create(100);
            FuncArray.Print(recursiveArray);

            int max = Max(recursiveArray);
            int count = Count(recursiveArray);
            int sum = Sum(recursiveArray);

            Console.WriteLine($"\n\n\tРекурсивные методы\n\n" +
                $"Максимальный: {max}\nКол-во: {count}\nСумма: {sum}");
        }

        #region Рекурсия для нахождения наибольшего элемента

            static int Max(int[] array)
        {
            if (array.Length != 0)
            {
                int max = array[0];
                FuncArray.RemoveAt(ref array, 0);

                int tempMax = Max(array);
                if (max < tempMax) 
                    max = tempMax;

                return max;
            }

            return int.MinValue;
        }

        #endregion

        #region Рекурсия для подсчета кол-ва элементов

        static int Count(int[] array)
        {
            int count = 0;

            if (array.Length != 0)
            {
                FuncArray.RemoveAt(ref array, 0);
                count += Count(array) + 1;
            }

            return count;
        }

        #endregion

        #region Рекурсия для подсчета суммы элементов

        static int Sum(int[] array)
        {
            int sum = 0;

            if (array.Length != 0)
            {
                sum = array[0];
                FuncArray.RemoveAt(ref array, 0);
                sum += Sum(array);
            }

            return sum;
        }

        #endregion
    }
}
