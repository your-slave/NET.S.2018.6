using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NET.S._2018.Karakouski._6
{
    /// <summary>
    /// NumberRepresentationConverter impliments DoubleToBinaryString method converting double to its iee-754 string represntatiom
    /// </summary>
    public static class NumberRepresentationConverter
    {
        private const int BITS_IN_BYTE = 8;

        /// <summary>
        /// Converts double to its iee-754 string represntatiom
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string DoubleToBinaryString(this double number)
        {
            StringBuilder result = new StringBuilder();
            long reminderOF2;

            DoubleToLongStruct doubleToLongStruct = new DoubleToLongStruct();
            doubleToLongStruct.Double64Bits = number;
            long longNumber = doubleToLongStruct.Long64Bits;    

            while (longNumber > 0)
            {
                reminderOF2 = longNumber % 2;
                number /= 2;
                result.Append(reminderOF2.ToString());
            }

            return result.ToString();
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongStruct
        {
            [FieldOffset(0)]
            private readonly long long64bits;

            [FieldOffset(0)]
            private double double64bits;

            public double Double64Bits { set { double64bits = value; } }
            public long Long64Bits { get { return Long64Bits; } }
        }
    }
}
