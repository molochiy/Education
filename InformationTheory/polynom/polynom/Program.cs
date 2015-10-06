using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polynom
{
    class Program
    {
        static void Deconv(double[] dividend, double[] divisor, out double[] quotient, out double[] remainder)
        {
            remainder = (double[])dividend.Clone();
            quotient = new double[remainder.Length - divisor.Length + 1];
            while (remainder.Length >= divisor.Length)
            {
                double coef = remainder[remainder.Length - 1];
                double[] temp = new double[remainder.Length];
                for (int i = divisor.Length - 1; i >= 0; i--)
                {
                    temp[i + remainder.Length - divisor.Length] = divisor[i]*coef;
                }
                quotient[remainder.Length - divisor.Length] = coef;

                for (int i = 0; i < remainder.Length; i++)
                {
                    remainder[i] -= temp[i];
                }

                while (remainder[remainder.Length - 1] == 0.0)
                {
                    Array.Resize<double>(ref remainder, remainder.Length -1);
                }
            }
        }

        static string stringPolynomial(List<double> a)
        {
            int i = 0;
            string temp = string.Empty;
            if (a[i] != 0.0) temp = a[i].ToString();
            i++;
            while (i < a.Count)
            {
                if (a[i] == 0.0) i++;
                while (i < a.Count && a[i] == 0.0)
                {
                    i++;
                }
                if (!(i < a.Count)) break;
                if (a[i] > 0.0 && temp != string.Empty) temp += '+';
                if (a[i] == -1.0)
                {
                    temp += "-";
                }
                else
                {
                    if (a[i] != 1.0)
                    {
                        temp += a[i].ToString();
                    }
                }
                if (i == 1) temp += "x";
                else temp += "x^" + i.ToString();
                i++;
            }
            return temp;
        }

        static void Main()
        {
            double[] dividend = {0,0,0,0,0, 1,1,1,0,0, 0,0,0,0,0, 0,0,1,1,1};
            double[] divisor = {1,0,1,0,0, 1};
            double[] quotient;
            double[] remainder;

            Deconv(dividend, divisor, out quotient, out remainder);

            List<double> a = new List<double>(dividend);
            List<double> b = new List<double>(divisor);
            List<double> c = new List<double>(quotient);
            List<double> d = new List<double>(remainder);

            Console.WriteLine(stringPolynomial(a));
            Console.WriteLine(stringPolynomial(b));
            Console.WriteLine(stringPolynomial(c));
            Console.WriteLine(stringPolynomial(d));
            Console.ReadLine();
        }
    }
}
