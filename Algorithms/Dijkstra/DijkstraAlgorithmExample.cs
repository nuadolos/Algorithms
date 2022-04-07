using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Dijkstra
{
    /// <summary>
    /// Алгоритм "Дейкстры"
    /// </summary>
    public class DijkstraAlgorithmExample
    {
        /// <summary>
        /// Пример работы алгоритма "Дейкстры"
        /// </summary>
        public static void AlgorithmExample()
        {
            // Хеш-таблица для хранения узла (ключа) и ребра с его весом (значение)
            Dictionary<string, Dictionary<string, int>> graph = new Dictionary<string, Dictionary<string, int>>()
            {
                ["start"] = new Dictionary<string, int>() { ["a"] = 6, ["b"] = 2 },

                ["a"] = new Dictionary<string, int>() { ["end"] = 1 },

                ["b"] = new Dictionary<string, int>() { ["a"] = 3, ["end"] = 5 },

                ["end"] = new Dictionary<string, int>()
            };

            // Хеш-таблица для хранения стоимость кратчайшего пути
            Dictionary<string, int> costs = new Dictionary<string, int>()
            {
                ["a"] = 6,
                ["b"] = 2,
                ["end"] = int.MaxValue
            };

            // Хеш-таблица для хранения кратчайшего пути: узел и его родитель
            Dictionary<string, string> parents = new Dictionary<string, string>()
            {
                ["a"] = "start",
                ["b"] = "start",
                ["end"] = string.Empty
            };

            DijkstraAlgorithm(graph, costs, parents);

            PrintResult(graph, costs, parents);
        }

        /// <summary>
        /// Вычисляет кратчайший путь с кратчайшим весом
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="costs"></param>
        /// <param name="parents"></param>
        static void DijkstraAlgorithm(Dictionary<string, Dictionary<string, int>> graph, Dictionary<string, int> costs, Dictionary<string, string> parents)
        {
            List<string> processed = new List<string>();

            string node = FindLowestCostNode(costs, processed);

            while(node != string.Empty)
            {
                // Вес нынешнего узла
                int cost = costs[node];

                // Ребра нынешнего узла
                var neighbors = graph[node];

                foreach (string n in neighbors.Keys)
                {
                    // Прибавление к кратчайшему путю вес
                    int newCost = cost + neighbors[n];

                    // Если новый кратчайший вес меньше нынешнего,
                    // то записывает новое значение и нового родителя
                    if (costs[n] > newCost)
                    {
                        costs[n] = newCost;
                        parents[n] = node;
                    }
                }

                // Добавление узла в список проверенных
                processed.Add(node);

                // Нахождение непроверенного узла с наименьшим весом
                node = FindLowestCostNode(costs, processed);
            }
        }

        /// <summary>
        /// Находит наименьший вес еще непроверенного узла
        /// </summary>
        /// <param name="costs"></param>
        /// <param name="processed"></param>
        /// <returns></returns>
        static string FindLowestCostNode(Dictionary<string, int> costs, List<string> processed)
        {
            int lowestCost = int.MaxValue;
            string lowestCostNode = string.Empty;

            foreach (string node in costs.Keys)
            {
                int cost = costs[node];

                if (cost < lowestCost && !processed.Contains(node))
                {
                    lowestCost = cost;
                    lowestCostNode = node;
                }
            }

            return lowestCostNode;
        }

        /// <summary>
        /// Выводит результат работы алгоритма на экран
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="costs"></param>
        /// <param name="parents"></param>
        static void PrintResult(Dictionary<string, Dictionary<string, int>> graph, Dictionary<string, int> costs, Dictionary<string, string> parents)
        {
            Console.WriteLine("Граф\n");

            foreach (var node in graph.Keys)
            {
                Console.WriteLine($"Узел: {node}");

                foreach (var item in graph[node])
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.WriteLine("\n\nКратчайшая стоимость\n");

            foreach (var item in costs)
            {
                Console.WriteLine($"\t{item.Key} - {item.Value}");
            }

            Console.WriteLine("\n\nРодители\n");

            foreach (var item in parents)
            {
                Console.WriteLine($"\t{item.Key} - {item.Value}");
            }
        }
    }
}
