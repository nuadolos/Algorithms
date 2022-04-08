using Algorithms.QuickSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Algorithms.Dynamic
{
    /// <summary>
    /// Динамическое программирование
    /// </summary>
    public class DynamicProgrammingExample
    {
        /// <summary>
        /// Пример работы динамического программирования
        /// </summary>
        public static void AlgoritmExample()
        {
            List<Steal> items = new List<Steal>()
            {
                new Steal("Ноутбук", 3, 2000),
                new Steal("Магнитафон", 4, 3000),
                new Steal("Гитара", 1, 1500)
            };

            int knapsack = TaskKnapsack(items, 4);
            Console.WriteLine($"Ответ на задачу \"Рюкзак\": {knapsack}\n");

            int substring1 = TaskSubstring("fish", "hish");
            int substring2 = TaskSubstring("vista", "hish");

            Console.WriteLine($"Общая подстрока слова fish в hish: {substring1}");
            Console.WriteLine($"Общая подстрока слова vista в hish: {substring2}\n");

            int subsequence1 = TaskSubsequence("fort", "fosh");
            int subsequence2 = TaskSubsequence("fish", "fosh");

            Console.WriteLine($"Общая подпоследовательность для слов fort и fosh: {subsequence1}");
            Console.WriteLine($"Общая подпоследовательность для слов fish и fosh: {subsequence2}");
        }

        /// <summary>
        /// Реализация задания "Рюкзак"
        /// </summary>
        /// <param name="items"></param>
        /// <param name="maxCapacity"></param>
        /// <returns></returns>
        static int TaskKnapsack(List<Steal> items, int maxCapacity)
        {
            // Имитация таблицы (Строки - предметы, Столбцы - размер рюкзака)
            // Прибавление единицы необходимо для прибавления нуля к сумме украденных вещей
            // т.е. если остается пустое место, которое можно заполнить,
            // то j - tempItem.Weight найдет ту самую ячейку
            // с необходимой добавочной ценой другого предмета
            // Пример 1: Ячейка [3, 4] = 1500 + 2000[2, 3]
            // Пример 2: Ячейка [2, 3] = 2000 + 0[1, 0]
            int[,] table = new int[items.Count + 1, maxCapacity + 1];

            for (int i = 0; i <= items.Count; i++)
            {
                for (int j = 0; j <= maxCapacity; j++)
                {
                    // Заполнить нулями все ячейки с индексом 0
                    if (i == 0 || j == 0)
                        table[i, j] = 0;
                    // В случае если вес предмета совпадает с весом рюкзака
                    // то необходимо произвести суммирование рассматриваемого предмета и возможного другого предмета
                    // и выявить, какая ячейка больше: только что посчитынная или находящаяся выше нее
                    else if (items[i - 1].Weight <= j)
                    {
                        var tempItem = items[i - 1];

                        table[i, j] = Math.Max(tempItem.Price + table[i - 1, j - tempItem.Weight], table[i - 1, j]);
                    }
                    // Если вес больше, чем размер рюкзака,
                    // то берется значение, находящаяся над искомой ячейкой
                    else
                        table[i, j] = table[i - 1, j];
                }
            }

            // Возвращает конечного результата в виде украденной суммы
            return table[items.Count, maxCapacity];
        }

        /// <summary>
        /// Задача "Самая длинная общая подстрока"
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        static int TaskSubstring(string row, string column)
        {
            int[,] table = new int[row.Length + 1, column.Length + 1];
            int max = 0;

            for (int i = 0; i <= row.Length; i++)
            {
                for (int j = 0; j <= column.Length; j++)
                {
                    // Заполнить нулями все ячейки с индексом 0
                    if (i == 0 || j == 0)
                        table[i, j] = 0;
                    // В случае если символы строки равны,
                    // то прибавить к прошлой ячейке по диагонали единицу
                    else if (row[i - 1] == column[j - 1])
                    {
                        table[i, j] = table[i - 1, j - 1] + 1;

                        if (table[i, j] > max)
                            max = table[i, j];
                    }
                    else
                        table[i, j] = 0;
                }
            }

            // Возвращает длину общей подстроки
            return max;
        }

        /// <summary>
        /// Задача "Самая длинная общая подпоследовательность"
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        static int TaskSubsequence(string row, string column)
        {
            int[,] table = new int[row.Length + 1, column.Length + 1];

            for (int i = 0; i <= row.Length; i++)
            {
                for (int j = 0; j <= column.Length; j++)
                {
                    // Заполнить нулями все ячейки с индексом 0
                    if (i == 0 || j == 0)
                        table[i, j] = 0;
                    // В случае если символы строки равны,
                    // то прибавить к прошлой ячейке по горизонтали единицу
                    else if (row[i - 1] == column[j - 1])
                        table[i, j] = table[i, j - 1] + 1;
                    // Если же символы не равны,
                    // то заполняет ячейку прошлой ячейкой
                    // либо по горизонтали, либо по вертикали, чье значение больше
                    else
                        table[i, j] = Math.Max(table[i - 1, j], table[i, j - 1]);
                }
            }

            // Возвращает длину общей подстроки
            return table[row.Length, column.Length];
        }
    }
}
