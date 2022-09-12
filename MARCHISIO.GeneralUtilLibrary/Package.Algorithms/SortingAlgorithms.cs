using System;
using System.Collections.Generic;
using System.Linq;

namespace Marchisio.GeneralUtilsLibrary
{
    public static class SortingAlgorithms
    {

        private static void swap<T>(ref T firstElement, ref T secondElement)
        {
            T cpy = firstElement;
            firstElement = secondElement;
            secondElement = cpy;
        }


        public static void bubbleSortAscending<T>(T[] list) where T : IComparable
        {
            bool scambio = true;
            while (scambio)
            {
                scambio = false;
                for (int i = 0; i < list.Length - 1; i++)
                {
                    if (list[i].CompareTo(list[i + 1]) > 0)
                    {
                        swap(ref list[i], ref list[i + 1]);
                        scambio = true;
                    }
                }
            }
        }

        
        public static void bubbleSortDescending<T>(T[] list) where T : IComparable
        {
            bool scambio = true;
            while (scambio)
            {
                scambio = false;
                for (int i = 0; i < list.Length - 1; i++)
                {
                    if (list[i].CompareTo(list[i + 1]) < 0)
                    {
                        swap(ref list[i], ref list[i + 1]);
                        scambio = true;
                    }
                }
            }
        }

        public static IEnumerable<T> bubbleSortAscending<T>(IEnumerable<T> enumerable) where T : IComparable
        {
            var list = enumerable.ToArray();
            bool scambio = true;
            while (scambio)
            {
                scambio = false;
                for (int i = 0; i < list.Length - 1; i++)
                {
                    if (list[i].CompareTo(list[i + 1]) > 0)
                    {
                        swap(ref list[i], ref list[i + 1]);
                        scambio = true;
                    }
                }
            }
            return list;
        }


        public static IEnumerable<T> bubbleSortDescending<T>(IEnumerable<T> enumerable) where T : IComparable
        {
            var list = enumerable.ToArray();
            bool scambio = true;
            while (scambio)
            {
                scambio = false;
                for (int i = 0; i < list.Length - 1; i++)
                {
                    if (list[i].CompareTo(list[i + 1]) < 0)
                    {
                        swap(ref list[i], ref list[i + 1]);
                        scambio = true;
                    }
                }
            }
            return list;
        }

    }
}

