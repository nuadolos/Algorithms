using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BinarySearch
{
    /// <summary>
    /// Использование алгоритма "Бинарный поиск"
    /// </summary>
    public class BinarySearchExample
    {
        /// <summary>
        /// Пример выполнения нахождения пользовательского значения
        /// </summary>
        public static void SearchElementExample()
        {
            int[] randomArray = FuncArray.Create(100);

            Array.Sort(randomArray); // Важно, чтобы массив был отсортирован
                                     // иначе бинарный поиск не будет работать

            do
            {
                FuncArray.Print(randomArray);

                int steps = 0;
                int findNum = int.Parse(Console.ReadLine() ?? "0");
                int searchNumber = BinarySearchArrayElement(randomArray, findNum, out steps);

                if (searchNumber != -1)
                    Console.WriteLine($"\nЧисло {findNum} имеет индекс {searchNumber} " +
                        $"в массиве \"{nameof(randomArray)}\".\nКол-во шагов: {steps}");
                else
                    Console.WriteLine($"\nЧисло {findNum} не существует " +
                        $"в массиве \"{nameof(randomArray)}\". Кол-во шагов: {steps}");

                Console.WriteLine("\n***Для выхода нажмите ESC***");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    break;
                
                Console.Clear();
            } 
            while (true);
        }

        /// <summary>
        /// Сокращение области нахождения указанного элемента.
        /// Формула времени выполнения: O(log₂ n).
        /// Условие выполнения данного алгоритма является отсортированный массив.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="findElement"></param>
        /// <param name="steps"></param>
        /// <returns></returns>
        static int BinarySearchArrayElement(int[] array, int findElement, out int steps)
        {
            steps = 0;

            int start = 0;
            int last = array.Length - 1;

            while (start <= last)
            {
                steps++;

                int mid = (start + last) / 2;

                if (array[mid] == findElement)
                    return mid;
                else if (array[mid] > findElement)
                    last = mid - 1;
                else
                    start = mid + 1;
            }

            return -1;
        }
    }
}
