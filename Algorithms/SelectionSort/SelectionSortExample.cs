using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms;

namespace Algorithms.SelectionSort
{
    /// <summary>
    /// Использование алгоритма "Сортировка выбором"
    /// </summary>
    public class SelectionSortExample
    {
        /// <summary>
        /// Пример выполнения сортировки
        /// </summary>
        public static void SortingArrayExample()
        {
            FuncArray.Print(FuncArray.Create(100));
        }

        /// <summary>
        /// Сортировка указанного массива
        /// </summary>
        /// <param name="tempArray"></param>
        /// <returns></returns>
        static int[] SelectionSort(int[] tempArray)
        {
            int[] newArray = new int[tempArray.Length];

            for (int i = 0; i < newArray.Length; i++)
            {
                int element = NextElement(tempArray, false);
                newArray[i] = tempArray[element];
                FuncArray.RemoveAt(ref tempArray, element);
            }

            return newArray;
        }

        /// <summary>
        /// Поиск следующего элемента по условию сортировки
        /// </summary>
        /// <param name="tempArray"></param>
        /// <param name="reverse"></param>
        /// <returns></returns>
        static int NextElement(int[] tempArray, bool reverse)
        {
            int findElement, findIndex;

            if (!reverse)
            {
                findElement = tempArray[0];
                findIndex = 0;

                for (int i = 0; i < tempArray.Length; i++)
                {
                    if (tempArray[i] < findElement)
                    {
                        findElement = tempArray[i];
                        findIndex = i;
                    }
                }
            }
            else
            {
                findElement = tempArray[tempArray.Length - 1];
                findIndex = tempArray.Length - 1;

                for (int i = 0; i < tempArray.Length; i++)
                {
                    if (tempArray[i] > findElement)
                    {
                        findElement = tempArray[i];
                        findIndex = i;
                    }
                }
            }

            return findIndex;
        }
    }
}
