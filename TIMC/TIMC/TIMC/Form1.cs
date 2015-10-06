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

namespace TIMC
{
    public partial class Form1 : Form
    {
        List<Interval> intervals = new List<Interval>();

        public Form1()
        {
            InitializeComponent();
            Read();
            MakeIntervals();
            Calculate();
            midle();
            drawGraph();
            drawHistogram();
            drawFunction();
        }

        public static List<double> data = new List<double>();
        public static List<int> ndata = new List<int>();
        public static List<double> fulldata = new List<double>();

        public void Read()
        {
            StreamReader reader = new StreamReader(@"Data2.txt");
            string s;
            while (!reader.EndOfStream)
            {
                s = reader.ReadLine();
                data.Add(Convert.ToDouble(s));
            }
            reader.Close();
            data.Sort();
            fulldata = new List<double>(data);
            for (int i = 0; i < data.Count - 1; ++i)
            {
                int kk = 1;
                while (data[i] == data[i + 1])
                {
                    data.RemoveAt(i);
                    ++kk;
                }
                ndata.Add(kk);
            }
            ndata.Add(1);
        }

        public void MakeIntervals()
        {
            int k = 7;
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

            this.dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i < data.Count; i++)
            {
                this.dataGridView1.Columns.Add("Item" + i.ToString(), data[i].ToString());
                this.dataGridView1.Rows[0].Cells[i].Value = ndata[i].ToString();
            }

            for (int i = 0; i < intervals.Count; i++)
            {
                this.dataGridView2.Columns.Add("Interval"+i.ToString(), intervals[i].getInterval());
                this.dataGridView2.Rows[0].Cells[i].Value = intervals[i].getCount();
                this.dataGridView2.Columns[i].Width = 120;
            }


            this.dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView2.Enabled = false;
        }

        public void Calculate()
        {
            this.dataGridView3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dataGridView3.Columns.Add("Сharacteristic", "Характеристика");
            this.dataGridView3.Columns[0].Width = 140;

            this.dataGridView3.Columns.Add("Value", "Значення");
            this.dataGridView3.Columns[1].Width = 255;

            for (int i = 0; i < 14; i++ ) this.dataGridView3.Rows.Add();

            this.dataGridView3.Rows[0].Cells[0].Value = "Медіана";
            this.dataGridView3.Rows[1].Cells[0].Value = "Розмах";
            this.dataGridView3.Rows[2].Cells[0].Value = "Квартилі";
            this.dataGridView3.Rows[3].Cells[0].Value = "Децилі";
            this.dataGridView3.Rows[4].Cells[0].Value = "Асиметрія";
            this.dataGridView3.Rows[5].Cells[0].Value = "Ексцес";
            this.dataGridView3.Rows[6].Cells[0].Value = "Середнє вибіркове 1";
            this.dataGridView3.Rows[7].Cells[0].Value = "Варіанса 1";
            this.dataGridView3.Rows[8].Cells[0].Value = "Стандарт 1";
            this.dataGridView3.Rows[9].Cells[0].Value = "Варіація 1";
            this.dataGridView3.Rows[10].Cells[0].Value = "Середнє вибіркове 2";
            this.dataGridView3.Rows[11].Cells[0].Value = "Варіанса 2";
            this.dataGridView3.Rows[12].Cells[0].Value = "Стандарт 2";
            this.dataGridView3.Rows[13].Cells[0].Value = "Варіація 2";
            /***********************************************************/
            this.dataGridView3.Rows[0].Cells[1].Value = median().ToString();
            this.dataGridView3.Rows[1].Cells[1].Value = scope().ToString();
            this.dataGridView3.Rows[2].Cells[1].Value = quartile();
            this.dataGridView3.Rows[3].Cells[1].Value = decile();
            this.dataGridView3.Rows[4].Cells[1].Value = asymmetry().ToString();
            this.dataGridView3.Rows[5].Cells[1].Value = excess().ToString();
            this.dataGridView3.Rows[6].Cells[1].Value = average().ToString();
            this.dataGridView3.Rows[7].Cells[1].Value = variansa().ToString();
            this.dataGridView3.Rows[8].Cells[1].Value = standarta().ToString();
            this.dataGridView3.Rows[9].Cells[1].Value = variation().ToString();
            this.dataGridView3.Rows[10].Cells[1].Value = average2().ToString();
            this.dataGridView3.Rows[11].Cells[1].Value = variansa2().ToString();
            this.dataGridView3.Rows[12].Cells[1].Value = standarta2().ToString();
            this.dataGridView3.Rows[13].Cells[1].Value = variation2().ToString();

        }

        public double median()
        {
            return (fulldata[49] + fulldata[50]) / 2;
        }

        public double scope()
        {
            return fulldata[fulldata.Count - 1] - fulldata[0];
        }

        public string quartile()
        {
            return fulldata[24].ToString() + ", " + fulldata[49].ToString() + ", " + fulldata[74].ToString() + ", " + fulldata[99].ToString();
        }

        public string decile()
        {
            string result = fulldata[9].ToString();
            for (int i = 10; i < fulldata.Count; i++) if ((i + 1) % 10 == 0) result += ", " + fulldata[i].ToString();
            return result;
        }

        public double average()
        {
            double summ = 0.0;
            for (int i = 0; i < fulldata.Count; i++) summ += fulldata[i];
            return summ / fulldata.Count;
        }

        public double moment2()
        {
            double summ = 0.0;
            for (int i = 0; i < fulldata.Count; i++) summ += Math.Pow(fulldata[i] - average(), 2);
            return summ / fulldata.Count;
        }

        public double moment3()
        {
            double summ = 0.0;
            for (int i = 0; i < fulldata.Count; i++) summ += Math.Pow(fulldata[i] - average(), 3);
            return summ / fulldata.Count;
        }

        public double moment4()
        {
            double summ = 0.0;
            for (int i = 0; i < fulldata.Count; i++) summ += Math.Pow(fulldata[i] - average(), 4);
            return summ / fulldata.Count;
        }

        public double asymmetry()
        {
            return moment3() / Math.Pow(moment2(), 1.5);
        }

        public double excess()
        {
            return moment4() / Math.Pow(moment2(), 2) - 3;
        }

        public double average2()
        {
            double summ = 0.0;
            for (int i = 0; i < intervals.Count; i++) summ += ((intervals[i].X2 + intervals[i].X1) / 2) * intervals[i].Count;
            return summ / fulldata.Count;
        }

        public double variansa()
        {
            double summ = 0.0;
            for (int i = 0; i < fulldata.Count; i++) summ += Math.Pow(fulldata[i] - average(), 2);
            return summ / (fulldata.Count - 1);
        }

        public double variansa2()
        {
            double summ = 0.0;
            for (int i = 0; i < intervals.Count; i++) summ += Math.Pow(((intervals[i].X2 + intervals[i].X1) / 2) - average2(), 2);
            return summ / (fulldata.Count - 1);
        }

        public double standarta()
        {
            return Math.Sqrt(variansa());
        }

        public double standarta2()
        {
            return Math.Sqrt(variansa2());
        }

        public double variation()
        {
            return standarta() / average();
        }

        public double variation2()
        {
            return standarta2() / average2();
        }

        public void drawGraph()
        {
            for (int i = 0; i < data.Count; i++ ) this.Graph.Series["Series1"].Points.AddXY(Math.Round(data[i],2), ndata[i]);
        }

        public static List<double> midleIntervals = new List<double>();

        public void midle()
        {
            for (int i = 0; i < intervals.Count; i++) midleIntervals.Add((intervals[i].X1 + intervals[i].X2) / 2.0);
            for (int i = 0; i < midleIntervals.Count; i++) Console.WriteLine(midleIntervals[i]);
        }

        public void drawHistogram()
        {
            for (int i = 0; i < midleIntervals.Count; i++) this.Histogram.Series["Series1"].Points.AddXY(Math.Round(midleIntervals[i],2), intervals[i].Count);
        }

        public void drawFunction()
        {
            double summ = 0.0;
            this.Function.Series["Series1"].Points.AddXY(Math.Round(data[0],2), summ);
            for (int i = 1; i < data.Count; i++)
            {
                summ += ndata[i - 1];
                this.Function.Series["Series1"].Points.AddXY(Math.Round(data[i],2),summ / fulldata.Count);
            }
            summ += ndata[data.Count - 1];
            this.Function.Series["Series1"].Points.AddXY(Math.Round(data[fulldata.Count - 1] + 100,2), summ / fulldata.Count);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Graph.Visible = false;
            Histogram.Visible = false;
            Function.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Graph.Visible = true;
            Histogram.Visible = false;
            Function.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Graph.Visible = false;
            Histogram.Visible = true;
            Function.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Graph.Visible = false;
            Histogram.Visible = false;
            Function.Visible = true;
        }
    }
}
