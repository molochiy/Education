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

namespace methods
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label5.Visible = false;
            label6.Visible = false;
            textBoxRoot.Visible = false;
            textBoxAmountIteration.Visible = false;
            textBoxAmountIteration.Enabled = false;
            textBoxRoot.Enabled = false;
        }

        public double GetValue(MathExpression function, double x)
        {
            return function.Calculate(x);
        }

        /**************************************************************************************/

        public Tuple<double, int> methodIterations(MathExpression function, MathExpression derivative, double epsilon, double left, double right)
        {
            int counter = 0;
            double x0 = left;
            double result = x0;
            double lambda = 2.0 / GetValue(derivative, left);
            for (double i = left; i <= right; i += 0.001)
            {
                lambda = Math.Max(lambda, 2.0 / (GetValue(derivative, i)));
            }
            do
            {
                x0 = result;
                result = x0 - lambda * GetValue(function, x0);
                counter++;
            } while (Math.Abs(x0 - result) > epsilon);









            if (double.IsNaN(result))
            {
                counter = 0;
                x0 = left;
                result = x0;
                lambda = 2 / Math.Max(GetValue(derivative, left), GetValue(derivative, right));
                do
                {
                    x0 = result;
                    result = x0 - lambda * GetValue(function, x0);
                    counter++;
                } while (Math.Abs(x0 - result) > epsilon);
            }

            return new Tuple<double, int>(result, counter);
        }

        /***************************************************************/

        public Tuple<double, int> methodChords(MathExpression function, MathExpression secondDerivative, double epsilon, double left, double right)
        {
            int counter = 0;
            double x0, result, c;

            if (GetValue(function, left) * GetValue(secondDerivative, left) > 0)
            {
                c = left;
                result = right;
            }
            else
            {
                c = right;
                result = left;
            }

            do
            {
                x0 = result;
                result = x0 - ((x0 - c) * GetValue(function, x0)) / (GetValue(function, x0) - GetValue(function, c));
                counter++;
            } while (Math.Abs(result - x0) > epsilon);
            return new Tuple<double, int>(result, counter);
        }

        /****************************************************************************/

        public Tuple<double, int> methodTangents(MathExpression function, MathExpression derivative, MathExpression secondDerivative, double epsilon, double left, double right)
        {
            double x0;
            int counter = 0;
            if ( (GetValue(derivative,(left+right)/2) > 0) && (GetValue(function, left) * GetValue(secondDerivative, left) < 0))
            {
                x0 = right;
            }
            else
            {
                x0 = left;
            }
           

            double result = x0;
            do
            {
                x0 = result;
                result = x0 - GetValue(function, x0) / GetValue(derivative, x0);
                counter++;
            } while (Math.Abs(x0 - result) > epsilon);
            return new Tuple<double, int>(result, counter);
        }

        /**************************************************************************/

        public Tuple<double, int> methodCombined(MathExpression function, MathExpression derivative, MathExpression secondDerivative, double epsilon, double left, double right)
        {
            int counter = 0;
            double x0;
            if (GetValue(function, left) * GetValue(secondDerivative, left) > 0)
            {
                x0 = left;
            }
            else
            {
                x0 = right;
            }
            if (GetValue(derivative, x0) * GetValue(secondDerivative, x0) > 0)
            {
                while (!(Math.Abs(left - right) < epsilon))
                {
                    left = left - (GetValue(function, left) * (right - left)) / (GetValue(function, right) - GetValue(function, left));
                    right = right - GetValue(function, right) / GetValue(derivative, right);
                    counter++;
                }
            }
            else
            {
                while (!(Math.Abs(left - right) < epsilon))
                {
                    left = left - GetValue(function, left) / GetValue(derivative, left);
                    right = right - (GetValue(function, right) * (right - left)) / (GetValue(function, right) - GetValue(function, left));
                    counter++;
                }
            }

            return new Tuple<double, int>((left + right) / 2, counter);
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            MathExpression function = new MathExpression(textBoxFunction.Text);
            MathExpression derivative = new MathExpression(textBoxFunction2.Text);
            MathExpression secondDerivative = new MathExpression(textBoxFunction3.Text);
            double left = Convert.ToDouble(textBoxLeftLimit.Text);
            double right = Convert.ToDouble(textBoxRightLimit.Text);
            double epsilon = Convert.ToDouble(textBoxAccuracy.Text);
            Tuple<double, int> result = new Tuple<double,int>(0.0,0);
            if (radioButtonIterations.Checked == true) result = methodIterations(function, derivative, epsilon, left, right);
            if (radioButtonChords.Checked == true) result = methodChords(function, secondDerivative, epsilon, left, right);
            if (radioButtonTangents.Checked == true) result = methodTangents(function, derivative, secondDerivative, epsilon, left, right);
            if (radioButtonCombined.Checked == true) result = methodCombined(function, derivative, secondDerivative, epsilon, left, right);
            label5.Visible = true;
            label6.Visible = true;
            textBoxRoot.Visible = true;
            textBoxAmountIteration.Visible = true;
            textBoxRoot.Text = result.Item1.ToString();
            textBoxAmountIteration.Text = result.Item2.ToString();
        }

    }
}
