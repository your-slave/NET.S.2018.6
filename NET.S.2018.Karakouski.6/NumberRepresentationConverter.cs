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
        static string zeroMantissa = "0000000000000000000000000000000000000000000000000000";//52 bits
        static string zeroExponenta = "00000000000";//11 bits
        static string onesExponenta = "11111111111";//11 bits

        /// <summary>
        /// Converts double to its iee-754 string represntatiom
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string DoubleToBinaryString(this double number)
        {
            StringBuilder result = new StringBuilder();

            switch (number)
            {
                case (Double.NegativeInfinity):
                    {
                        return result.Append('1').Append(onesExponenta).Append(zeroMantissa).ToString();
                    }
                case (Double.PositiveInfinity):
                    {
                        return result.Append('0').Append(onesExponenta).Append(zeroMantissa).ToString();
                    }
                case (-0.0):
                    {
                        return result.Append('1').Append(zeroExponenta).Append(zeroMantissa).ToString();
                    }
                case (Double.NaN):
                    {
                        return result.Append('1').Append(onesExponenta).Append('1').Append(zeroMantissa.Remove(0, 1)).ToString();
                    }
                    //case (0.0): //multimple cases with zero?..
                    //    {
                    //        return result.Append('0').Append(zeroExponenta).Append(zeroMantisa).ToString();
                    //    }

            }

            if (number == -0.0)
                return result.Append('0').Append(zeroExponenta).Append(zeroMantissa).ToString();

            if (number > 0)
                result.Append('0');
            else
                result.Append('1');

            number = Math.Abs(number);

            int intExponent = (int)Math.Log(number, 2);
            intExponent += 1023;

            double doubleMantissa = number / intExponent;

            StringBuilder mantissa = new StringBuilder();
            StringBuilder exponent = new StringBuilder();

            while (intExponent > 0)
            {
                exponent.Insert(0, intExponent % 2);
                intExponent /= 2;
            }

            int count = 0;
            while (((doubleMantissa % 1) != 0) || count < 52)
            {
                doubleMantissa *= 2;
                mantissa.Append(((int)(doubleMantissa)));
                doubleMantissa %= 1;
                count++;
            }

            FillTheRestWithZeroes(mantissa, 51);

            result.Append(exponent);
            result.Append(mantissa);

            return result.ToString();
        }

        /// <summary>
        /// Fills number with zeroes up to required size
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="size"></param>
        private static void FillTheRestWithZeroes(StringBuilder sb, int size)
        {
            if (sb.Length < size)
            {
                for (int i = 0; i < size - sb.Length; i++)
                {
                    sb.Append('0');
                }
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongStruct
        {
            [FieldOffset(0)]
            private readonly long long64bits;

            [FieldOffset(0)]
            private double double64bits;
        }
    }
}
