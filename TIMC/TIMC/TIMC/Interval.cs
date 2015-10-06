using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIMC
{
    public struct Interval
    {
        public double X1 { get; set; }
        public double X2 { get; set; }
        public int Count { get; set; }
        public string Name { get { return ToString(); } }
        public Interval(double x1, double x2, int count)
            : this()
        {
            X1 = x1;
            X2 = x2;
            Count = count;
        
        }

        public string getInterval()
        {
            return "[ " + String.Format("{0:0.00}", X1) + " , " + String.Format("{0:0.00}", X2) + " ) ";
        }

        public string getCount()
        {
            return Count.ToString();
        }


        public override string ToString()
        {

            return "[ " + String.Format("{0:0.00}", X1) + " , " + String.Format("{0:0.00}", X2) + " ) - " + Count;
        }
    }
}
