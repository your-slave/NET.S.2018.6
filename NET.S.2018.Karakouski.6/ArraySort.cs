using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Karakouski._6
{
    public static class ArraySort
    {
        /// <summary>
        /// Sort jagged array using bubble sort with selected mode
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="mode">Selects sort mode: 0 for sorting by sum, 1 for by max, 2 by min</param>
        public static void BubbleSortBySums(int[][] arr, byte mode)
        {
            int[] temp;
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
                            throw new ArgumentException(nameof(mode));
                    }

                    if (comparedValueB == null || (comparedValueA > comparedValueB))
                    {
                        temp = arr[j + 1].DeepClone();
                        arr[j + 1] = arr[j].DeepClone();
                        arr[j] = temp.DeepClone();
                    }
                }
            }
        }

        public static T DeepClone<T>(this T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }

    }
}
