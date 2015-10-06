using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PoohMathParser;

namespace NumMethods
{
    public partial class Form1 : Form
    {
        private int N = 100;
        public Form1()
        {
            InitializeComponent();
        }

        private double funcTrapeze()
        {
            double a = Convert.ToDouble(textBoxA.Text.ToString());
            double b = Convert.ToDouble(textBoxB.Text.ToString());
            double h = (b - a) / N;
            MathExpression expr = new MathExpression(textBoxFunction.Text.ToString());
            double resault = expr.Calculate(a) + expr.Calculate(b);
            for (int i = 0; i < N - 1; i++ )
            {
                a += h;
                resault += 2 * expr.Calculate(a);
            }
            return resault * h / 2.0;
        }

        private double funcLeftRectangle()
        {
            double a = Convert.ToDouble(textBoxA.Text.ToString());
            double b = Convert.ToDouble(textBoxB.Text.ToString());
            double h = (b - a) / N;
            MathExpression expr = new MathExpression(textBoxFunction.Text.ToString());
            double resault = expr.Calculate(a);
            for (int i = 0; i < N - 1; i++)
            {
                a += h;
                resault += expr.Calculate(a);
            }
            return resault * h;
        }

        private double funcRightRectangle()
        {
            double a = Convert.ToDouble(textBoxA.Text.ToString());
            double b = Convert.ToDouble(textBoxB.Text.ToString());
            double h = (b - a) / N;
            MathExpression expr = new MathExpression(textBoxFunction.Text.ToString());
            double resault = expr.Calculate(b);
            for (int i = 0; i < N - 1; i++)
            {
                b -= h;
                resault += expr.Calculate(b);
            }
            return resault * h;
        }

        private double funcMidleRectangle()
        {
            double a = Convert.ToDouble(textBoxA.Text.ToString());
            double b = Convert.ToDouble(textBoxB.Text.ToString());
            double h = (b - a) / N;
            MathExpression expr = new MathExpression(textBoxFunction.Text.ToString());
            a += h;
            double resault = expr.Calculate(a - h/2);
            for (int i = 0; i < N - 1; i++)
            {
                a += h;
                resault += expr.Calculate(a - h/2);
            }
            return resault * h ;
        }

        private double funcSimpson()
        {
            double a = Convert.ToDouble(textBoxA.Text.ToString());
            double b = Convert.ToDouble(textBoxB.Text.ToString());
            double h = (b - a) / N;
            MathExpression expr = new MathExpression(textBoxFunction.Text.ToString());
            double resault = expr.Calculate(a) + expr.Calculate(b);
            for (int i = 0; i < N - 1; i++)
            {
                a += h;
                if (i % 2 == 0)
                {
                    resault += 4 * expr.Calculate(a);
                }
                else
                {
                    resault += 2 * expr.Calculate(a);
                }
            }
            return resault * h / 3.0;
        }

        private double funcThreeEighths()
        {
            double a = Convert.ToDouble(textBoxA.Text.ToString());
            double b = Convert.ToDouble(textBoxB.Text.ToString());
            double h = (b - a) / (3 * N);
            MathExpression expr = new MathExpression(textBoxFunction.Text.ToString());
            double resault = expr.Calculate(a) + expr.Calculate(b);
            for (int i = 1; i < 3 * N; i++)
            {
                a += h;
                if (i % 3 == 0)
                {
                    resault += 2 * expr.Calculate(a);
                }
                else
                {
                    resault += 3 * expr.Calculate(a);
                }
            }
            return resault * h * 3.0 / 8.0;
        }
        
        private double funcGaus()
        {
            double a = Convert.ToDouble(textBoxA.Text.ToString());
            double b = Convert.ToDouble(textBoxB.Text.ToString());
            double h = (b - a) / N;
            double[] coefs = new double[] { 0.478629, 0.236927, 0.568889, 0.236927, 0.478629 };
            double[] points = new double[] { -0.9061800, -0.538469, 0, 0.538469, 0.9061800 };
            MathExpression expr = new MathExpression(textBoxFunction.Text.ToString());
            double resault = 0.0;
            double left = a;
            double right = a + h;
            for (int i = 0; i < N; i++)
            {
                for(int j = 0; j < points.Length; j++)
                {
                    resault += coefs[j] * expr.Calculate((left + right) / 2.0 + (right - left) / 2.0 * points[j]);
                }
                left = right;
                right += h;
            }
            return resault * h / 2.0;
        }

        private double funcChebyshev()
        {
            double a = Convert.ToDouble(textBoxA.Text.ToString());
            double b = Convert.ToDouble(textBoxB.Text.ToString());
            double h = (b - a) / N;            
            double[] points = new double[] { 0.832498, 0.374541, 0, -0.374541, -0.832498 };
            double coef = 2.0 / points.Length;
            MathExpression expr = new MathExpression(textBoxFunction.Text.ToString());
            double resault = 0.0;
            double left = a;
            double right = a + h;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < points.Length; j++)
                {
                    resault += (right - left) / points.Length * expr.Calculate((left + right) / 2.0 + (right - left) / 2.0 * points[j]);
                }
                left = right;
                right += h;
            }
            return resault;
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            MathExpression expr = new MathExpression(textBoxInitialFunction.Text.ToString());
            double a = Convert.ToDouble(textBoxA.Text.ToString());
            double b = Convert.ToDouble(textBoxB.Text.ToString());
            string inital = (expr.Calculate(b) - expr.Calculate(a)).ToString();

            if (radioButtonLeftRectangle.Checked)
            {
                int iteration = 1;
                N = 4;
                double I1 = funcLeftRectangle();
                N *= 2;
                double I2 = funcLeftRectangle();
                double EPS = Convert.ToDouble(textBoxE.Text.ToString());
                while (Math.Abs(I1 - I2) > EPS)
                {
                    iteration++;
                    I1 = I2;
                    N *= 2;
                    I2 = funcLeftRectangle();
                }
                textBoxIntegral.Text = I1.ToString();
                textBoxInitial.Text = inital;
                textBoxIterations.Text = iteration.ToString();
            }

            /***********************************************************************************/

            if (radioButtonRightRectangle.Checked)
            {
                int iteration = 1;
                N = 4;
                double I1 = funcRightRectangle();
                N *= 2;
                double I2 = funcRightRectangle();
                double EPS = Convert.ToDouble(textBoxE.Text.ToString());
                while (Math.Abs(I1 - I2) > EPS)
                {
                    iteration++;
                    I1 = I2;
                    N *= 2;
                    I2 = funcRightRectangle();
                }
                textBoxIntegral.Text = I1.ToString();
                textBoxInitial.Text = inital;
                textBoxIterations.Text = iteration.ToString();
            }

            /***********************************************************************************/

            if (radioButtonMidleRectangle.Checked)
            {
                int iteration = 1;
                N = 4;
                double I1 = funcMidleRectangle();
                N *= 2;
                double I2 = funcMidleRectangle();
                double EPS = Convert.ToDouble(textBoxE.Text.ToString());
                while (Math.Abs(I1 - I2) > EPS)
                {
                    iteration++;
                    I1 = I2;
                    N *= 2;
                    I2 = funcMidleRectangle();
                }
                textBoxIntegral.Text = I1.ToString();
                textBoxInitial.Text = inital;
                textBoxIterations.Text = iteration.ToString();
            }

            /***********************************************************************************/

            if (radioButtonTrapeze.Checked)
            {
                int iteration = 1;
                N = 4;
                double I1 = funcTrapeze();
                N *= 2;
                double I2 = funcTrapeze();
                double EPS = Convert.ToDouble(textBoxE.Text.ToString());
                while (Math.Abs(I1 - I2) > EPS)
                {
                    iteration++;
                    I1 = I2;
                    N *= 2;
                    I2 = funcTrapeze();
                }
                textBoxIntegral.Text = I1.ToString();
                textBoxInitial.Text = inital;
                textBoxIterations.Text = iteration.ToString();
            }

            /***********************************************************************************/

            if (radioButtonSimpson.Checked)
            {
                int iteration = 1;
                N = 4;
                double I1 = funcSimpson();
                N *= 2;
                double I2 = funcSimpson();
                double EPS = Convert.ToDouble(textBoxE.Text.ToString());
                while (Math.Abs(I1 - I2) > EPS)
                {
                    iteration++;
                    I1 = I2;
                    N *= 2;
                    I2 = funcSimpson();
                }
                textBoxIntegral.Text = I1.ToString();
                textBoxInitial.Text = inital;
                textBoxIterations.Text = iteration.ToString();
            }

            /***********************************************************************************/

            if (radioButtonThreeEighths.Checked)
            {
                int iteration = 1;
                N = 4;
                double I1 = funcThreeEighths();
                N *= 2;
                double I2 = funcThreeEighths();
                double EPS = Convert.ToDouble(textBoxE.Text.ToString());
                while (Math.Abs(I1 - I2) > EPS)
                {
                    iteration++;
                    I1 = I2;
                    N *= 2;
                    I2 = funcThreeEighths();
                }
                textBoxIntegral.Text = I1.ToString();
                textBoxInitial.Text = inital;
                textBoxIterations.Text = iteration.ToString();
            }

            /***********************************************************************************/

            if (radioButtonGaus.Checked)
            {
                int iteration = 1;
                N = 4;
                double I1 = funcGaus();
                N *= 2;
                double I2 = funcGaus();
                double EPS = Convert.ToDouble(textBoxE.Text.ToString());
                while (Math.Abs(I1 - I2) > EPS)
                {
                    iteration++;
                    I1 = I2;
                    N *= 2;
                    I2 = funcGaus();
                }
                textBoxIntegral.Text = I1.ToString();
                textBoxInitial.Text = inital;
                textBoxIterations.Text = iteration.ToString();
            }

            /***********************************************************************************/

            if (radioButtonChebyshev.Checked)
            {
                int iteration = 1;
                N = 4;
                double I1 = funcChebyshev();
                N *= 2;
                double I2 = funcChebyshev();
                double EPS = Convert.ToDouble(textBoxE.Text.ToString());
                while (Math.Abs(I1 - I2) > EPS)
                {
                    iteration++;
                    I1 = I2;
                    N *= 2;
                    I2 = funcChebyshev();
                }
                textBoxIntegral.Text = I1.ToString();
                textBoxInitial.Text = inital;
                textBoxIterations.Text = iteration.ToString();
            }
        }
    }
}
