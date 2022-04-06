using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.BreadthFirstSearch
{
    /// <summary>
    /// Алгоритм "Поиск в ширину"
    /// </summary>
    public class BreadthFirstSearchExample
    {
        /// <summary>
        /// Пример работы алгортима "Поиск в ширину"
        /// </summary>
        public static void SearchExample()
        {
            Console.Write("Кто является роботом?\t");
            string computer = Console.ReadLine();

            string[]? nameArray = null;

            Console.Write("Желаете вывести заполнить повторно очередь?\t");
            if (Console.ReadLine().ToLower() == "да")
            {
                nameArray = new string[] { "Павел", "Настя", "Дарья", "Артем", "Дмитрий" };
            }

            bool isRobot = QueueSearch(computer, nameArray);

            if (isRobot)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"\n\nСреди посетителей {(isRobot ? "есть" : "нет")} робота.");
        }

        /// <summary>
        /// Демонстрация простой работы алгоритма "Поиск в ширину"
        /// </summary>
        /// <param name="name"></param>
        /// <param name="moreNameArray"></param>
        /// <returns></returns>
        static bool QueueSearch(string name, string[]? moreNameArray = null)
        {
            string[] nameArray = new string[] { "Юля", "Владимир", "Анна", "Полина",
                "Гриша", "Максим", "Павел", "Матвей", "Татьяна"};

            // Инициализация очереди для поиска пользовательского имени
            Queue<string> search = new Queue<string>();

            // Заполнение очереди именами
            Console.WriteLine("\n\n***Первый поток посетителей***\n");
            foreach (string item in nameArray)
            {
                search.Enqueue(item);
                Console.Write(item + " ");
            }

            // Список проверенных имен
            List<string> checkedNames = new List<string>();

            // Пока очередь не закончится, продолжается цикл
            while (search.Count > 0)
            {
                // Возвращает и удаляет из очереди значение
                string person = search.Dequeue();

                // Проверяет, прошло ли уже значение очередь
                if (checkedNames.Contains(person)) continue;
                
                if (person.ToLower() == name.ToLower())
                    return true;
                else
                {
                    // Заполняет очередь порцией имен
                    if (moreNameArray != null && person.Equals(moreNameArray[0]))
                    {
                        Console.WriteLine("\n\n***Второй поток посетителей***\n");
                        foreach (var item in moreNameArray)
                        {
                            search.Enqueue(item);
                            Console.Write(item + " ");
                        }    
                    }

                    // Добавляет имя к проверенным
                    checkedNames.Add(person);
                }
            }

            // При неудачном поиске возвращает false
            return false;
        }
    }
}
