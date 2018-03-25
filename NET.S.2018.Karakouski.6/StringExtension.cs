using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Karakouski._6
{
    class StringExtension
    {
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
                checked { result += source[i].GetNumeric10BaseRespresentIon() * (int)Math.Pow(nBase, number.Length - 1 - i); }
            }

            return result;
        }

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
