using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Greedy
{
    /// <summary>
    /// Жадный алгоритм
    /// </summary>
    public class GreedyAlgorithmExample
    {
        /// <summary>
        /// Пример работы жадного алгоритма
        /// </summary>
        public static void AlgorithmExample()
        {
            // Список штатов
            // Метод Distinct удаляет дубликаты из списка (создает множество)
            var statesNeeded = new[] { "mt", "wa", "or", "id", "nv", "ut", "ca", "az"}.Distinct();

            // Хеш-таблица для хранения радиостанций с их обслуживаниям в некоторых штатах
            Dictionary<string, IEnumerable<string>> stations = new Dictionary<string, IEnumerable<string>>()
            {
                ["kone"] = new[] {"id", "nv", "ut"},
                ["ktwo"] = new[] {"wa", "id", "mt"},
                ["kthree"] = new[] {"or", "nv", "ca"},
                ["kfour"] = new[] {"nv", "ut"},
                ["kfive"] = new[] {"ca", "az"}
            };

            IEnumerable<string> finalStations = GreedyAlgorithm(statesNeeded, stations);

            PrintResult(finalStations);
        }

        /// <summary>
        /// Вычисляет оптимальное решение для некоторой задачи
        /// </summary>
        /// <param name="statesNeeded"></param>
        /// <param name="stations"></param>
        /// <returns></returns>
        static List<string> GreedyAlgorithm(IEnumerable<string> statesNeeded, Dictionary<string, IEnumerable<string>> stations)
        {
            List<string> finalStations = new List<string>();

            while (statesNeeded.Count() > 0)
            {
                string bestStation = string.Empty;
                IEnumerable<string> statesCovered = new List<string>();

                foreach (var item in stations)
                {
                    // Возвращает пересечение (&) двух списков
                    var covered = statesNeeded.Intersect(item.Value);

                    // Если охват радиостанцией больше, чем предыдущий,
                    // то она подходит для оптимального решения
                    if (covered.Count() > statesCovered.Count())
                    {
                        bestStation = item.Key;
                        statesCovered = covered;
                    }
                }
                
                // Очистка штатов, обслуживающиеся радиостанцией, из основного списка штатов 
                statesNeeded = statesNeeded.Except(statesCovered);

                finalStations.Add(bestStation);
            }

            // Возвращает оптимальное решение
            return finalStations;
        }

        /// <summary>
        /// Выводит результат на экран
        /// </summary>
        /// <param name="finalStations"></param>
        static void PrintResult(IEnumerable<string> finalStations)
        {
            Console.WriteLine("Оптимальное решение\n");

            foreach (var item in finalStations)
            {
                Console.Write(item + " ");
            }
        }
    }
}
