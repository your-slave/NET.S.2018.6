using System;
using System.Text;

namespace NET.S._2018.Karakouski._6
{
    public class Polynomial
    {
        public int[] Conficents { get; }

        public Polynomial(params int[] conficents)
        {
            Conficents = new int[conficents.Length];

            for (int i = 0; i < conficents.Length; i++)
            {
                Conficents[i] = conficents[i];
            }
        }

        public double Calculate(double agrgumnet)
        {
            double result = 0;

            for (int i = 0; i < Conficents.Length; i++)
            {
                if (Conficents[i] != 0)
                    result += Conficents[i] * Math.Pow(agrgumnet, i);
            }

            return result;
        }

        public static Polynomial operator +(Polynomial a, Polynomial b)
        {

            int[] resulConficents;
            Polynomial result = new Polynomial();

            Polynomial smallerPolynomial;
            int minNumberOfConficents;

            if (a.Conficents.Length > b.Conficents.Length)
            {
                smallerPolynomial = b;
                minNumberOfConficents = b.Conficents.Length;
                resulConficents = new int[a.Conficents.Length];
            }             
            else
            {
                smallerPolynomial = a;
                minNumberOfConficents = a.Conficents.Length;
                resulConficents = new int[a.Conficents.Length];
            }

            for (int i = 0; i < minNumberOfConficents; i++)
            {
                resulConficents[i] += smallerPolynomial.Conficents[i];
            }

            return new Polynomial(resulConficents);
        }

        public static Polynomial operator -(Polynomial a, Polynomial b)
        {

            int[] resulConficents;
            Polynomial result = new Polynomial();

            Polynomial smallerPolynomial;
            int minNumberOfConficents;

            if (a.Conficents.Length > b.Conficents.Length)
            {
                smallerPolynomial = b;
                minNumberOfConficents = b.Conficents.Length;
                resulConficents = new int[a.Conficents.Length];
            }
            else
            {
                smallerPolynomial = a;
                minNumberOfConficents = a.Conficents.Length;
                resulConficents = new int[a.Conficents.Length];
            }

            for (int i = 0; i < minNumberOfConficents; i++)
            {
                resulConficents[i] -= smallerPolynomial.Conficents[i];
            }

            return new Polynomial(resulConficents);
        }


        public static Polynomial operator *(Polynomial a, Polynomial b)
        {
            int[] resulConficents = new int[a.Conficents.Length + b.Conficents.Length];
            Polynomial result = new Polynomial();

            for (int i = 0; i < a.Conficents.Length; i++)
            {
                for (int j = 0; j < b.Conficents.Length; j++)
                {

                    resulConficents[i + j] += (a.Conficents[i] * b.Conficents[j]);
                }
            }

            return new Polynomial(resulConficents);
        }

        public override bool Equals(object obj)
        {
            var comparedPolynomial = obj as Polynomial;

            if (comparedPolynomial == null || (Conficents.Length != comparedPolynomial.Conficents.Length))
            {
                return false;
            }

            else
            {
                for (int i = 0; i < Conficents.Length; i++)
                {
                    if (Conficents[i] != comparedPolynomial.Conficents[i])
                        return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return Conficents.GetHashCode();
        }

        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Conficents.Length; i++)
            {
                if (Conficents[i] != 0)
                    if (sb.Length != 0)
                        sb.Append("+");
                    sb.Append(Conficents[i] + "x^" + i);
            }

            return sb.ToString();
        }

    }
}
