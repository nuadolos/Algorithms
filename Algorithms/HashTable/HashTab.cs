using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.HashTable
{
    public class HashTab
    {
        /// <summary>
        /// Максимальная длина ключевого поля
        /// </summary>
        private readonly byte _maxSize = 255;

        /// <summary>
        /// Коллекция хранимых данных
        /// </summary>
        /// <remarks>
        /// Представляет собой словарь, ключ которого представляет собой
        /// хеш ключа хранимых данных
        /// </remarks>
        private Dictionary<int, List<Item>> _items;

        /// <summary>
        /// Коллекция хранимых данных в хеш-таблице в виде пар Хеш-Значения
        /// </summary>
        public IReadOnlyCollection<KeyValuePair<int, List<Item>>>? Items
            => _items?.ToList()?.AsReadOnly();

        /// <summary>
        /// Инициализирует хеш-таблицу
        /// с максимальным кол-вом элементов
        /// </summary>
        public HashTab()
        {
            _items = new Dictionary<int, List<Item>>(_maxSize);
        }

        /// <summary>
        /// Вставка данных в хеш-таблицу
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Insert(string key, string value)
        {
            // Проверка ключа 
            Validation(key, value);

            // Создание объекта Item
            var item = new Item(key, value);

            // Определение хеша ключа
            var hash = GetHash(key);

            // Создание листа, хранящий ключ-значение
            List<Item> hashTableItem;

            // Проверка существования хеша в коллекции _items
            if (_items.ContainsKey(hash))
            {
                // Добавление в существующую коллекцию новый объект

                hashTableItem = _items[hash];

                var oldElementWithKey = hashTableItem.SingleOrDefault(i => i.Key == item.Key);

                // Ошибка при дублировании ключей в коллекции 
                if (oldElementWithKey != null)
                    throw new ArgumentException(
                        $"Хеш-таблица уже содержит элемент с ключем {key}. " +
                        $"Ключ должен быть уникален.", nameof(key));

                _items[hash].Add(item);
            }
            else
            {
                // Создание новой коллекции с объектом

                hashTableItem = new List<Item> { item };

                _items.Add(hash, hashTableItem);
            }
        }

        /// <summary>
        /// Удаление данных из хеш-таблицы по ключу
        /// </summary>
        /// <param name="key"></param>
        public void Delete(string key)
        {
            // Проверка ключа 
            Validation(key);

            // Определение хеша ключа
            var hash = GetHash(key);

            // Если ключ не существует, возвращает void
            if (!_items.ContainsKey(hash)) 
                return;

            var hashTableItem = _items[hash];

            // Нахождение объекта Item из коллекции по ключу
            var item = hashTableItem.SingleOrDefault(i => i.Key == key);

            // Если объект существует, удаляет данные о нем
            if (item != null)
                hashTableItem.Remove(item);
        }

        /// <summary>
        /// Поиск значения по ключу
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string? Search(string key)
        {
            // Проверка ключа 
            Validation(key);

            // Определение хеша ключа
            var hash = GetHash(key);

            // Если ключ не существует, возвращает null
            if (!_items.ContainsKey(hash))
                return null;

            var hashTableItem = _items[hash];

            //Возвращает значение объекта Item из коллекции по ключу
            return hashTableItem?.SingleOrDefault(i => i.Key == key)?.Value;
        }
        
        /// <summary>
        /// Хеш-функция, возвращающая длину строки
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int GetHash(string value) => value.Length;

        #region Проверка значений введенных значений

        /// <summary>
        /// Проверяет пользовательские значения на наличие ошибок.
        /// </summary>
        /// <param name="key"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        private void Validation(string key)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (key.Length > _maxSize)
                throw new ArgumentException(
                    $"Максимальная длина ключа составляет {_maxSize} символов.", nameof(key));
        }

        /// <summary>
        /// Проверяет пользовательские значения на наличие ошибок.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        private void Validation(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (key.Length > _maxSize)
                throw new ArgumentException(
                    $"Максимальная длина ключа составляет {_maxSize} символов.", nameof(key));

            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
        }

        #endregion
    }
}
