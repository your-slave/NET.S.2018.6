using System;
using System.Linq;


namespace NET.S._2018.Karakouski._6
{
    /// <summary>
    /// StringExtension class containing ToDecimalConverter method converting 10 base number to n base
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Convert 10 base number to n base
        /// </summary>
        /// <param name="source"></param>
        /// <param name="notation"></param>
        /// <returns></returns>
        public static int ToDecimalConverter(this string source, Notation notation)
        {
            source = source.ToUpper();

            if (!source.All(c => notation.Legal6BaseChars.Contains(c)))
            {
                throw new ArgumentException(nameof(source));
            }

            int result = 0;

            for (int i = 0; i < source.Length; i++)
            {
                checked { result += source[i].GetNumeric10BaseRespresentIon() * (int)Math.Pow(notation.NBase, source.Length - 1 - i); }
            }

            return result;
        }

        /// <summary>
        /// Coverts symbolic digit represtntaion to 10 base numeric value
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        private static int GetNumeric10BaseRespresentIon(this char symbol)
        {
            if (Char.IsDigit(symbol))
                return (int)Char.GetNumericValue(symbol);

            switch (symbol)
            {
                case ('A'):
                    {
                        return 10;
                    }
                case ('B'):
                    {
                        return 11;
                    }
                case ('C'):
                    {
                        return 12;
                    }
                case ('D'):
                    {
                        return 13;
                    }
                case ('E'):
                    {
                        return 14;
                    }
                case ('F'):
                    {
                        return 15;
                    }
            }

            throw new ArgumentException();
        }
    }
}
