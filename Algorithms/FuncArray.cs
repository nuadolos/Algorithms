using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// Дополнительные функции для массива
    /// </summary>
    static class FuncArray
    {
        /// <summary>
        /// Удаление ячейки массива по указанному индексу
        /// </summary>
        /// <param name="tempArray"></param>
        /// <param name="index"></param>
        public static void RemoveAt(ref int[] tempArray, int index)
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

        /// <summary>
        /// Создание массива с указанным размером и случайными числами
        /// </summary>
        /// <param name="count"></param>
        public static int[] Create(int count)
        {
            Random rnd = new Random();

            int[] array = new int[count];

            for (int i = 0; i < array.Length; i++)
                array[i] = rnd.Next(-99, 100);

            return array;
        }

        /// <summary>
        /// Вывод указанного массива на экран
        /// </summary>
        /// <param name="array"></param>
        public static void Print(int[] array)
        {
            foreach (int num in array)
                Console.Write(num + " ");

            Console.WriteLine("\n\n");
        }
    }
}
