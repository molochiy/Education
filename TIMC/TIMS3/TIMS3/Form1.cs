using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TIMC3
{
    public partial class Form1 : Form
    {
        public List<Interval> intervals = new List<Interval>();
        public static List<double> data = new List<double>();
        public static List<int> ndata = new List<int>();
        public static List<double> fulldata = new List<double>();

        const double Tkr1 = 2.701;
        const double sigma0 = 2.0;

        public Form1()
        {
            InitializeComponent();
            Read();
            MakeIntervals();
            midle();
            drawHistogram();
            Calculate();
        }

        public void Read()
        {
            StreamReader reader = new StreamReader(@"data.txt");
            string s;
            while (!reader.EndOfStream)
            {
                s = reader.ReadLine();
                data.Add(Convert.ToDouble(s));
            }
            reader.Close();
            data.Sort();
            fulldata = new List<double>(data);
            int kk = 1;
            for (int i = 0; i < data.Count - 1; ++i)
            {
                kk = 1;
                while (data[i] == data[i + 1])
                {
                    data.RemoveAt(i);
                    ++kk;
                }
                ndata.Add(kk);
            }
            if (data[data.Count - 1] == data[data.Count - 2]) kk++;
            ndata.Add(kk);

            this.dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i < data.Count; i++)
            {
                this.dataGridView1.Columns.Add("Item" + i.ToString(), data[i].ToString());
                this.dataGridView1.Rows[0].Cells[i].Value = ndata[i].ToString();
            }
        }
        
        public void MakeIntervals()
        {
            int k = 6;
            double step = (fulldata[fulldata.Count - 1] - fulldata[0]) / k;
            double x1 = fulldata[0];
            double x2 = x1 + step;
            int j = 0;

            while (k-- != 0)
            {
                int count = 0;
                for (; j < fulldata.Count && fulldata[j] <= x2; j++, count++)
                { }
                intervals.Add(new Interval(x1, x2, count));
                x1 = x2;
                x2 = x1 + step;
            }

            for (int i = 0; i < intervals.Count; i++)
            {
                this.dataGridView2.Columns.Add("Interval" + i.ToString(), intervals[i].getInterval());
                this.dataGridView2.Rows[0].Cells[i].Value = intervals[i].getCount();
                this.dataGridView2.Columns[i].Width = 120;
            }

            this.dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView2.Enabled = false;
        }
        public static List<double> midleIntervals = new List<double>();

        public void midle()
        {
            for (int i = 0; i < intervals.Count; i++) midleIntervals.Add((intervals[i].X1 + intervals[i].X2) / 2.0);
        }

        public void drawHistogram()
        {
            this.Histogram.Series["Кількість на інтервалі"]["PixelPointWidth"] = "48";
            for (int i = 0; i < intervals.Count; i++) this.Histogram.Series["Кількість на інтервалі"].Points.AddXY(Math.Round(intervals[i].X1, 2).ToString()+" - " +Math.Round(intervals[i].X2, 2).ToString(), intervals[i].Count);
        }

        public double average()
        {
            double summ = 0.0;
            for (int i = 0; i < fulldata.Count; i++) summ += fulldata[i];
            return summ / fulldata.Count;
        }

        public double variansa()
        {
            double summ = 0.0;
            for (int i = 0; i < fulldata.Count; i++) summ += Math.Pow(fulldata[i] - average(), 2);
            return summ / (fulldata.Count - 1);
        }

        public double dispersion()
        {
            double summ = 0.0;
            for (int i = 0; i < fulldata.Count; i++) summ += Math.Pow(fulldata[i] - average(), 2);
            return summ / fulldata.Count;
        }

        public double standarta()
        {
            return Math.Sqrt(variansa());
        }

        public KeyValuePair<double, double> intervalForAverage()
        {
            return new KeyValuePair<double, double>(average() - (standarta() * Tkr1) / Math.Sqrt(fulldata.Count), average() + (standarta() * Tkr1) / Math.Sqrt(fulldata.Count));
        }

        public KeyValuePair<double, double> intervalForDispersion(double a, double b)
        {
            return new KeyValuePair<double, double>((variansa() * 39 ) / a, (variansa() * 39 ) / b);
        }

        public void Calculate()
        {
            this.dataGridView3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dataGridView3.Columns.Add("Сharacteristic", "Характеристика");
            this.dataGridView3.Columns[0].Width = 140;

            this.dataGridView3.Columns.Add("Value", "Значення");
            this.dataGridView3.Columns[1].Width = 255;

            for (int i = 0; i < 3; i++) this.dataGridView3.Rows.Add();

            this.dataGridView3.Rows[0].Cells[0].Value = "Середнє вибіркове";
            this.dataGridView3.Rows[1].Cells[0].Value = "Вибіркова дисперсія";
            this.dataGridView3.Rows[2].Cells[0].Value = "Варіанса";
            this.dataGridView3.Rows[3].Cells[0].Value = "Стандарт";
            /***********************************************************/
            this.dataGridView3.Rows[0].Cells[1].Value = average().ToString();
            this.dataGridView3.Rows[1].Cells[1].Value = dispersion().ToString();
            this.dataGridView3.Rows[2].Cells[1].Value = variansa().ToString();
            this.dataGridView3.Rows[3].Cells[1].Value = standarta().ToString();

            label1.Text = "Інтервал довіри для математичного сподівання (" + Math.Round(intervalForAverage().Key, 4).ToString() + "; " + Math.Round(intervalForAverage().Value, 4).ToString() + ").";
            label2.Text = "Інтервал довіри для дисперсії (" + Math.Round(intervalForDispersion(65.47557090, 19.99586787).Key, 4).ToString() + "; " + Math.Round(intervalForDispersion(65.47557090, 19.99586787).Value, 4).ToString() + ").";

            if (Math.Abs(Temp1()) > Tkr1)
            {
                label3.Text = "|T[емпіричне]| > T[критичне], " + Math.Abs(Math.Round(Temp1(), 4)).ToString() + ">" + Tkr1.ToString() + ", отже гіпотезу про рівність середньої напруги \nна вході в вузол приладу номінальному значенню а = 8,5 не приймаємо.";
            }
            else
            {
                label3.Text = "|T[емпіричне]| < T[критичне], " + Math.Abs(Math.Round(Temp1(), 4)).ToString() + "<" + Tkr1.ToString() + ", отже гіпотезу про рівність середньої напруги \nна вході в вузол приладу номінальному значенню а = 8,5 приймаємо.";
            }

            if (58.12005973 / 39 < variansa() / (sigma0 * sigma0) || 23.65432456 / 39 > variansa() / (sigma0 * sigma0))
            {
                label4.Text = "Гіпотезу про те, що дисперсія напруги на вході в вузол \nелектроприладу не перевищує заданого значення sigma0 = 2 не приймаємо.";
            }
            else
            {
                label4.Text = "Гіпотезу про те, що дисперсія напруги на вході в вузол \nелектроприладу не перевищує заданого значення sigma0 = 2 приймаємо.";
            }

            //if (intervalForDispersion(58.12005973, 23.65432456).Key > sigma0 * sigma0 || intervalForDispersion(58.12005973, 23.65432456).Value > sigma0 * sigma0)
            //{
            //    label4.Text = "Інтервал довіри (" + Math.Round(intervalForDispersion(58.12005973, 23.65432456).Key, 4).ToString() + "; " + Math.Round(intervalForDispersion(58.12005973, 23.65432456).Value, 4).ToString() + "). " + "Гіпотезу про те, що дисперсія напруги на вході в вузол \nелектроприладу не перевищує заданого значення sigma0 = 2 не приймаємо.";
            //}
            //else
            //{
            //    label4.Text = "Інтервал довіри (" + Math.Round(intervalForDispersion(58.12005973, 23.65432456).Key, 4).ToString() + "; " + Math.Round(intervalForDispersion(58.12005973, 23.65432456).Value, 4).ToString() + "). " + "Гіпотезу про те, що дисперсія напруги на вході в вузол \nелектроприладу не перевищує заданого значення sigma0 = 2 приймаємо.";
            //}
        }
        
        public double Temp1()
        {
            double a = 8.5;
            return (average() - a) * Math.Sqrt(fulldata.Count) / standarta();
        }
    }
}
