[Оглавление](../../../#readme) > Глава 9. Динамическое программирование

# Глава 9. Динамическое программирование

## Задача о рюкзаке

Мы уже знаем несколько способов решения задачи о рюкзаке:

* Простое - Перебор всех возможных множеств предметов - O(2<sup>n</sup>).
* Приближенное - Неоптимальное решение с помощью жадного алгоритма (берем самое дорогое, что влезает).

Есть еще одно, самое оптимальное - динамическое программирование.

Оно основано на рассмотрении не только конечного случая (целый рюкзак, но и подслучаев - рюкзаки меньшего размера).

[Демонстрация задачи "Рюкзак", "Самая длинная общая подстрока (и подпоследовательность)"](./DynamicProgrammingExample.cs)

Необходимо раскомментировать следующий код в Program.cs:

```
Algorithms.Dynamic.DynamicProgrammingExample.AlgoritmExample();
```

***

## Резюме

* Динамическое программирование применяется для оптимизации какой-либо характеристики при заданных ограничениях. В задаче о рюкзаке требуется максимизи­ ровать стоимость отобранных предметов с ограничениями по емкости рюкзака.
* Динамическое программирование работает только в ситуациях, в кото­рых задача может быть разбита на автономные подзадачи, не зависящие друг от друга.

Несколько общих рекомендаций:

* в каждом решении из области динамического программирования стро­ится таблица;
* значения ячеек таблицы обычно соответствуют оптимизируемой ха­рактеристике. Для задачи о рюкзаке значения представляли общую стоимость товаров;
* каждая ячейка представляет подзадачу, поэтому вы должны подумать о том, как разбить задачу на подзадачи. Это поможет вам определиться с осями.

Шпаргалка:

* Динамическое программирование применяется при оптимизации не­которой характеристики.
* Динамическое программирование работает только в ситуациях, в кото­рых задача может быть разбита на автономные подзадачи.
* В каждом решении из области динамического программирования стро­ится таблица.
* Значения ячеек таблицы обычно соответствуют оптимизируемой харак­ теристике.
* Каждая ячейка представляет подзадачу, поэтому вы должны подумать о том, как разбить задачу на подзадачи.
* Не существует единой формулы для вычисления решений методом ди­намического программирования.