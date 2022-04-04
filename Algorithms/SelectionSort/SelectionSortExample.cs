using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Random rnd = new Random();
            int[] randomArray = new int[10];

            for (int i = 0; i < randomArray.Length; i++)
                randomArray[i] = rnd.Next(100);

            foreach (int el in SelectionSort(randomArray))
            {
                Console.Write(el + " ");
            }
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
                RemoveAt(ref tempArray, element);
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

        /// <summary>
        /// Удаление ячейки массива по указанному индексу
        /// </summary>
        /// <param name="tempArray"></param>
        /// <param name="index"></param>
        static void RemoveAt(ref int[] tempArray, int index)
        {
            int[] newArray = new int[tempArray.Length - 1];
            int nextElement = 0;

            for (int i = 0; i < newArray.Length; i++)
            {
                if (i == index) 
                    nextElement++;

                newArray[i] = tempArray[i + nextElement];
            }

            tempArray = newArray;
        }
    }
}
