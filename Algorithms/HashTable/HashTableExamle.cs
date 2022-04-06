using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.HashTable
{
    /// <summary>
    /// Хеш-таблица
    /// </summary>
    public class HashTableExamle
    {
        /// <summary>
        /// Пример собственной хеш-таблицы
        /// </summary>
        public static void HashTableItemsExample()
        {
            HashTab hashTable = new HashTab();

            hashTable.Insert("Лучик солнца", "Задумываясь каждый день о смысле жизни," +
                " невозможно целостно достичь своих заветных целей");

            hashTable.Insert("Любовное прощание", "Как стали так далеко мы с тобой" +
                " от правды, что не знает горечи и разлуки");

            hashTable.Insert("Лишь ты одна", "Прости меня, дурака," +
                " сомневающегося в твоей изящной улыбке");

            PrintHashTable(hashTable);

            Console.ReadKey();
            Console.Clear();

            hashTable.Delete("Лучик солнца");
            hashTable.Insert("Утомление", "Учиться - неотъемленный навык," +
                " но не забывай, мой друг, выспаться перед этим");

            PrintHashTable(hashTable);

            Console.ReadKey();
            Console.Clear();

            string? text = hashTable.Search("Утомление");
            Console.WriteLine($"Один мудрый человек сказал: {text}");
        }

        /// <summary>
        /// Показ хранимых данных в хеш-таблице
        /// </summary>
        /// <param name="hashTable"></param>
        static void PrintHashTable(HashTab hashTable)
        {
            foreach (var item in hashTable.Items)
            {
                Console.WriteLine(item.Key);

                foreach (var value in item.Value)
                {
                    Console.WriteLine($"\t«{value.Key}» - “{value.Value}”");
                }
            }
        }
    }
}
