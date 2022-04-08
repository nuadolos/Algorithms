using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.QuickSearch
{
    /// <summary>
    /// Алгоритм Евклида
    /// </summary>
    public class EuclidAlgorithm
    {
        /// <summary>
        /// Возвращает наибольший общий делитель двух целых чисел
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int Nod(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                    a = a - b;
                else
                    b = b - a;
            }

            return a;
        }
    }
}
