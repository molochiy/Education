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

namespace NumericalMethods
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dataGridViewPointers.Columns.Add("Pointers", "X");
            this.dataGridViewPointers.Rows[0].Cells[0].Value = "Y";
            this.dataGridViewPointers.Columns[0].Width = 30;
            this.dataGridViewPointers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewPointers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewPointers.ReadOnly = true;
            this.dataGridViewPointers.Enabled = true;
            this.textBoxY.Enabled = false;
            this.textBoxY.ReadOnly = true;
            this.textBoxPolynomial.Enabled = false;
            this.textBoxPolynomial.ReadOnly = true;
            this.radioButton1.BackColor = Color.Transparent;
            this.radioButton2.BackColor = Color.Transparent;
            this.radioButton3.BackColor = Color.Transparent;
            this.radioButton4.BackColor = Color.Transparent;
            this.radioButton5.BackColor = Color.Transparent;
            this.radioButton1.ForeColor = Color.White;
            this.radioButton2.ForeColor = Color.White;
            this.radioButton3.ForeColor = Color.White;
            this.radioButton4.ForeColor = Color.White;
            this.radioButton5.ForeColor = Color.White;
            this.radioButton2.Text = "Інтерполяційний многочлен Ньютона вперед \nдля нерівновіддалених вузлів інтерполювання";
            this.radioButton3.Text = "Інтерполяційний многочлен Ньютона вперед \nдля рівновіддалених вузлів інтерполювання";
            this.radioButton4.Text = "Інтерполяційний многочлен Ньютона назад \nдля нерівновіддалених вузлів інтерполювання";
            this.radioButton5.Text = "Інтерполяційний многочлен Ньютона назад \nдля рівновіддалених вузлів інтерполювання";
            this.label1.BackColor = Color.Transparent;
            this.label2.BackColor = Color.Transparent;
            this.label3.BackColor = Color.Transparent;
            this.label4.BackColor = Color.Transparent;
            this.label5.BackColor = Color.Transparent;
            this.label6.BackColor = Color.Transparent;
            this.label1.ForeColor = Color.White;
            this.label2.ForeColor = Color.White;
            this.label3.ForeColor = Color.White;
            this.label4.ForeColor = Color.White;
            this.label5.ForeColor = Color.White;
            this.label6.ForeColor = Color.White;
            this.label5.Text = "Точка, в якій потрібно \nзнайти значення многочлена";
        }

        public int amountPointers = 1;
        public List<KeyValuePair<double, double>> pointers = new List<KeyValuePair<double,double>>();
        private void AddPointer_Click(object sender, EventArgs e)
        {
            this.dataGridViewPointers.Columns.Add("Pointers", this.textBoxPointerX.Text);
            this.dataGridViewPointers.Rows[0].Cells[amountPointers].Value = this.textBoxPointerY.Text;
            this.dataGridViewPointers.Columns[amountPointers].Width = 30;
            pointers.Add(new KeyValuePair<double, double>(Convert.ToDouble(this.textBoxPointerX.Text), Convert.ToDouble(this.textBoxPointerY.Text)));
            this.textBoxPointerX.Text = string.Empty;
            this.textBoxPointerY.Text = string.Empty;
            amountPointers++;
        }

        public List<double> multPolynom(List<double> a, List<double> b)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < a.Count + b.Count - 1; i++) result.Add(0.0);
            for (int i = 0; i < a.Count; i++)
            {
                for (int j = 0; j < b.Count; j++)
                    result[i + j] += a[i] * b[j];
            }
            return result;
        }

        public void addPolynom(ref List<double> a, List<double> b)
        {
            if (a.Count > b.Count)
            {
                List<double> result = new List<double>();
                int i = 0;
                while (i < b.Count)
                {
                    result.Add(a[i] + b[i]);
                    i++;
                }
                for (; i < a.Count; i++)
                {
                    result.Add(a[i]);
                }
                a = result;
            }
            else
            {
                if (a.Count < b.Count)
                {
                    List<double> result = new List<double>();
                    int i = 0;
                    while (i < a.Count)
                    {
                        result.Add(a[i] + b[i]);
                        i++;
                    }
                    for (; i < b.Count; i++)
                    {
                        result.Add(b[i]);
                    }
                    a = result;
                }
                else
                {
                    List<double> result = new List<double>();
                    for (int j = 0; j < a.Count; j++)
                    {
                        result.Add(a[j] + b[j]);
                    }
                    a = result;
                }
            }
        }

        public List<double> multPolynomOnScalar(List<double> a, double b)
        {
            List<double> result = new List<double>();
            for (int i = 0; i < a.Count; i++)
            {
                result.Add(a[i] * b);
            }
            return result;
        }

        public List<double> polynomialLagrange(List<double> coeficients)
        {
            coeficients = new List<double>(pointers.Count);
            for (int i = 0; i < pointers.Count; i++)
            {
                int j = 0;
                List<double> tempCoeficients = new List<double>();
                tempCoeficients.Add(1.0);
                double coef = pointers[i].Value;
                while(j < pointers.Count)
                {
                    if (i == j && j == pointers.Count - 1)
                    {
                        break;
                    }
                    else
                    {
                        if (i == j) j++;
                    }
                    List<double> temp2Coeficients = new List<double>();
                    temp2Coeficients.Add(-1.0 * pointers[j].Key);
                    temp2Coeficients.Add(1.0);
                    coef /= (pointers[i].Key - pointers[j].Key);
                    tempCoeficients = multPolynom(tempCoeficients, temp2Coeficients);
                    j++;
                }
                tempCoeficients = multPolynomOnScalar(tempCoeficients, coef);
                addPolynom(ref coeficients, tempCoeficients);
            }
            for (int j = 0; j < coeficients.Count; j++)
            {
                if (Math.Abs(coeficients[j]) < 1e-6) coeficients[j] = 0.0;
            }
            return coeficients;
        }

        public string stringPolynomial(List<double> a)
        {
            int i = 0;
            string temp = string.Empty;
            if (a[i] != 0.0) temp = a[i].ToString();
            i++;
            while(i < a.Count)
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

        public List<List<double>> separatedDifferences()
        {
            List<List<double>> result = new List<List<double>>();
            result.Add(new List<double>());
            for (int i = 0; i < pointers.Count; i++) 
            {
                result[0].Add(pointers[i].Value);
            }
            for (int i = 0; i < pointers.Count - 1; i++)
            {
                result.Add(new List<double>());
                for (int j = 0; j < result[i].Count - 1; j++)
                {
                    result[i+1].Add((result[i][j + 1] - result[i][j]) / (pointers[i + j + 1].Key - pointers[j].Key));
                }
            }
            return result;
        }

        public List<double> polynomialNewtonSDForward(List<double> coeficients)
        {
            coeficients = new List<double>();
            int i = 0;
            List<List<double>> sepDif = new List<List<double>>();
            sepDif = separatedDifferences();
            coeficients.Add(sepDif[i][0]);
            i++;
            while(i < sepDif.Count)
            {
                int j = 0;
                List<double> tempCoeficients = new List<double>();
                tempCoeficients.Add(1.0);
                double coef = sepDif[i][0];
                while (j < i)
                {
                    List<double> temp2Coeficients = new List<double>();
                    temp2Coeficients.Add(-1.0*pointers[j].Key);
                    temp2Coeficients.Add(1.0);
                    tempCoeficients = multPolynom(tempCoeficients, temp2Coeficients);
                    j++;
                }
                tempCoeficients = multPolynomOnScalar(tempCoeficients, coef);
                addPolynom(ref coeficients, tempCoeficients);
                i++;
            }
            for (int j = 0; j < coeficients.Count; j++)
            {
                if (Math.Abs(coeficients[j]) < 1e-6) coeficients[j] = 0.0;
            }
            return coeficients;
        }

        public List<double> polynomialNewtonSDBack(List<double> coeficients)
        {
            coeficients = new List<double>();
            int i = 0;
            List<List<double>> sepDif = new List<List<double>>();
            sepDif = separatedDifferences();
            coeficients.Add(sepDif[i][sepDif[i].Count - 1]);
            i++;
            while (i < sepDif.Count)
            {
                int j = pointers.Count - 1;
                List<double> tempCoeficients = new List<double>();
                tempCoeficients.Add(1.0);
                double coef = sepDif[i][sepDif[i].Count - 1];
                while (j > pointers.Count - i - 1)
                {
                    List<double> temp2Coeficients = new List<double>();
                    temp2Coeficients.Add(-1.0 * pointers[j].Key);
                    temp2Coeficients.Add(1.0);
                    tempCoeficients = multPolynom(tempCoeficients, temp2Coeficients);
                    j--;
                }
                tempCoeficients = multPolynomOnScalar(tempCoeficients, coef);
                addPolynom(ref coeficients, tempCoeficients);
                i++;
            }
            for (int j = 0; j < coeficients.Count; j++)
            {
                if (Math.Abs(coeficients[j]) < 1e-6) coeficients[j] = 0.0;
            }
            return coeficients;
        }

        public List<List<double>> finiteDifferences()
        {
            List<List<double>> result = new List<List<double>>();
            result.Add(new List<double>());
            for (int i = 0; i < pointers.Count; i++)
            {
                result[0].Add(pointers[i].Value);
            }
            for (int i = 0; i < pointers.Count - 1; i++)
            {
                result.Add(new List<double>());
                for (int j = 0; j < result[i].Count - 1; j++)
                {
                    result[i + 1].Add(result[i][j + 1] - result[i][j]);
                }
            }
            return result;
        }

        public long factorial(int a)
        {
            long n = 1;
            for (int i = 2; i <= a; i++) n *= i;
            return n;
        }

        public List<double> polynomialNewtonFDForward(List<double> coeficients)
        {
            coeficients = new List<double>();
            int i = 0;
            List<List<double>> finDif = new List<List<double>>();
            finDif = finiteDifferences();
            coeficients.Add(finDif[i][0]);
            i++;
            double h = pointers[1].Key - pointers[0].Key;
            while (i < finDif.Count)
            {
                int j = 0;
                List<double> tempCoeficients = new List<double>();
                tempCoeficients.Add(1.0);
                double coef = finDif[i][0] / (factorial(i) * Math.Pow(h,i));
                while (j < i)
                {
                    List<double> temp2Coeficients = new List<double>();
                    temp2Coeficients.Add(-1.0 * pointers[j].Key);
                    temp2Coeficients.Add(1.0);
                    tempCoeficients = multPolynom(tempCoeficients, temp2Coeficients);
                    j++;
                }
                tempCoeficients = multPolynomOnScalar(tempCoeficients, coef);
                addPolynom(ref coeficients, tempCoeficients);
                i++;
            }
            for (int j = 0; j < coeficients.Count; j++)
            {
                if (Math.Abs(coeficients[j]) < 1e-6) coeficients[j] = 0.0;
            }
            return coeficients;
        }

        public List<double> polynomialNewtonFDBack(List<double> coeficients)
        {
            coeficients = new List<double>();
            int i = 0;
            List<List<double>> finDif = new List<List<double>>();
            finDif = finiteDifferences();
            coeficients.Add(finDif[i][finDif[i].Count - 1]);
            i++;
            double h = pointers[1].Key - pointers[0].Key;
            while (i < finDif.Count)
            {
                int j = pointers.Count - 1;
                List<double> tempCoeficients = new List<double>();
                tempCoeficients.Add(1.0);
                double coef = finDif[i][finDif[i].Count - 1] / (factorial(i) * Math.Pow(h, i))  ;
                while (j > pointers.Count - i - 1)
                {
                    List<double> temp2Coeficients = new List<double>();
                    temp2Coeficients.Add(-1.0 * pointers[j].Key);
                    temp2Coeficients.Add(1.0);
                    tempCoeficients = multPolynom(tempCoeficients, temp2Coeficients);
                    j--;
                }
                tempCoeficients = multPolynomOnScalar(tempCoeficients, coef);
                addPolynom(ref coeficients, tempCoeficients);
                i++;
            }
            for (int j = 0; j < coeficients.Count; j++)
            {
                if (Math.Abs(coeficients[j]) < 1e-6) coeficients[j] = 0.0;
            }
            return coeficients;
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            this.textBoxPolynomial.Text = string.Empty;
            this.textBoxY.Text = string.Empty;
            this.label3.Text = "L(" + textBoxX.Text + ") = ";
            if (radioButton1.Checked == true)
            {
                List<double> temp = new List<double>();
                temp = polynomialLagrange(temp);
                double value = 0.0;
                for (int i = 0; i < temp.Count; i++)
                {
                    value += Math.Pow(Convert.ToDouble(textBoxX.Text), i) * temp[i];
                }
                textBoxPolynomial.Text = stringPolynomial(temp);
                textBoxY.Text = value.ToString();
            }
            if (radioButton2.Checked == true)
            {
                List<double> temp = new List<double>();
                temp = polynomialNewtonSDForward(temp);
                double value = 0.0;
                for (int i = 0; i < temp.Count; i++)
                {
                    value += Math.Pow(Convert.ToDouble(textBoxX.Text), i) * temp[i];
                }
                textBoxPolynomial.Text = stringPolynomial(temp);
                textBoxY.Text = value.ToString();
            }
            if (radioButton3.Checked == true)
            {
                List<double> temp = new List<double>();
                temp = polynomialNewtonFDForward(temp);
                double value = 0.0;
                for (int i = 0; i < temp.Count; i++)
                {
                    value += Math.Pow(Convert.ToDouble(textBoxX.Text), i) * temp[i];
                }
                textBoxPolynomial.Text = stringPolynomial(temp);
                textBoxY.Text = value.ToString();
            }
            if (radioButton4.Checked == true)
            {
                List<double> temp = new List<double>();
                temp = polynomialNewtonSDBack(temp);
                double value = 0.0;
                for (int i = 0; i < temp.Count; i++)
                {
                    value += Math.Pow(Convert.ToDouble(textBoxX.Text), i) * temp[i];
                }
                textBoxPolynomial.Text = stringPolynomial(temp);
                textBoxY.Text = value.ToString();
            }
            if (radioButton5.Checked == true)
            {
                List<double> temp = new List<double>();
                temp = polynomialNewtonFDBack(temp);
                double value = 0.0;
                for (int i = 0; i < temp.Count; i++)
                {
                    value += Math.Pow(Convert.ToDouble(textBoxX.Text), i) * temp[i];
                }
                textBoxPolynomial.Text = stringPolynomial(temp);
                textBoxY.Text = value.ToString();
            }
        }

        private void ClearPoints_Click(object sender, EventArgs e)
        {
            dataGridViewPointers.Rows.Clear();
            dataGridViewPointers.Columns.Clear();
            this.dataGridViewPointers.Columns.Add("Pointers", "X");
            this.dataGridViewPointers.Rows[0].Cells[0].Value = "Y";
            this.dataGridViewPointers.Columns[0].Width = 30;
            this.dataGridViewPointers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewPointers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewPointers.ReadOnly = true;
            pointers.Clear();
            textBoxX.Text = string.Empty;
            textBoxY.Text = string.Empty;
            textBoxPolynomial.Text = string.Empty;
            amountPointers = 1;
        }
    }
}
