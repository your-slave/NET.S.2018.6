using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;


namespace NET.S._2018.Karakouski._6
{
    /// <summary>
    /// Impliments buble sort method of sorting jagged array
    /// </summary>
    public static class ArraySort
    {
        /// <summary>
        /// Sort jagged array using bubble sort with selected mode
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="mode">Selects sort mode: 0 for sorting by sum, 1 for by max, 2 by min</param>
        public static void BubbleSortBySums(int[][] arr, byte mode, bool reverseOrder=false)
        {
            int[] temp = new int[0];
            int? comparedValueA;
            int? comparedValueB;

            for(int i=0; i<arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    switch(mode)
                    {
                        case (0):
                            comparedValueA = arr[j]?.Sum();
                            comparedValueB = arr[j + 1].Sum();
                            break;
                        case (1):
                            comparedValueA = arr[j]?.Max();
                            comparedValueB = arr[j + 1].Max();
                            break;
                        case (2):
                            comparedValueA = arr[j]?.Min();
                            comparedValueB = arr[j + 1].Min();
                            break;
                        default:
                            throw new ArgumentException(nameof(mode) + " should be from 0 to 2");
                    }

                    if(!reverseOrder)
                    {
                        if (comparedValueB == null || (comparedValueA > comparedValueB))
                        {
                            Swap(arr[j], arr[j+1], temp);
                        }
                    }
                    else
                    {
                        if (comparedValueB == null || (comparedValueA < comparedValueB))
                        {
                            Swap(arr[j], arr[j + 1], temp);
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Help method for swapping arrays
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="temp"></param>
        private static void Swap(int[] a, int[] b, int[] temp)
        {
            temp = new int[b.Length];
            b.CopyTo(temp, 0);

            b = new int[a.Length];
            a.CopyTo(b, 0);

            a = new int[temp.Length];
            temp.CopyTo(a, 0);
        }

    }
}
