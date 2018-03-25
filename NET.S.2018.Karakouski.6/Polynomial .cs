using System;
using System.Text;

namespace NET.S._2018.Karakouski._6
{
    /// <summary>
    /// Represents po;ynomial with underlting structure as array
    /// </summary>
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
        /// <summary>
        /// Caluclates polynomial on given variable
        /// </summary>
        /// <param name="agrgumnet"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Override + operator for addition of polynomials
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Override - operator for substructing of polynomials
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Override * operator for multiplying of polynomials
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Override == operator for comparsion of polynomials
        /// </summary>
        /// <param name="polynomialA"></param>
        /// <param name="polynomialB"></param>
        /// <returns></returns>
        public static bool operator ==(Polynomial polynomialA, Polynomial polynomialB)
        {
            if (polynomialA == null ^ polynomialB == null)
                return false;

            if (polynomialA == null & polynomialB == null)
                return true;

            if (polynomialA.Conficents.Length != polynomialB.Conficents.Length)
            {
                return false;
            }

            else
            {
                for (int i = 0; i < polynomialB.Conficents.Length; i++)
                {
                    if (polynomialA.Conficents[i] != polynomialB.Conficents[i])
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Override != operator for comparsion of polynomials
        /// </summary>
        /// <param name="polynomialA"></param>
        /// <param name="polynomialB"></param>
        /// <returns></returns>
        public static bool operator !=(Polynomial polynomialA, Polynomial polynomialB)
        {

            if (polynomialA == null ^ polynomialB == null)
                return true;

            if (polynomialA == null & polynomialB == null)
                return false;

            if (polynomialA.Conficents.Length != polynomialB.Conficents.Length)
            {
                return true;
            }

            else
            {
                for (int i = 0; i < polynomialB.Conficents.Length; i++)
                {
                    if (polynomialA.Conficents[i] != polynomialB.Conficents[i])
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Overrides Equals method for comparing polynomials
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var comparedPolynomial = obj as Polynomial;

            if (this == null ^ comparedPolynomial == null)
                return false;

            if (this == null & comparedPolynomial == null)
                return true;

            if (Conficents.Length != comparedPolynomial.Conficents.Length)
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

        /// <summary>
        /// Overrides GetHashCode method for polynomial
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Conficents.GetHashCode();
        }

        /// <summary>
        /// Overrides ToString method for polynomial
        /// </summary>
        /// <returns></returns>
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
