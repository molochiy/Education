namespace myString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using myString;

    class Program
    {
        static void Main()
        {
            string a = string.Empty;
            for (int i = 0; i < 50; i++) a += "1";
            System.IO.File.WriteAllText(@"C:\Users\Mykola\Documents\a.txt", a);
            a = string.Empty;
            for (int i = 0; i < 2500; i++) a += "1";
            System.IO.File.WriteAllText(@"C:\Users\Mykola\Documents\b.txt", a);
            /*MyString a = new MyString("A1B1B1B1BAAAAAAAAAA1BAAA");
            MyString b = new MyString("1A");
            Console.WriteLine(a.Find(b)); */
            
            //MyString a = new MyString();
            //MyString b = new MyString();
            //MyString.GetLine("in.txt", a, b);
            //b.GetLine("in2.txt");
            //Console.WriteLine(a);
            //Console.WriteLine(b);
            //Console.WriteLine(a+b);
            //Console.WriteLine(a==b);
            //MyString c = new MyString();
            //c.GetLine();
            //Console.WriteLine(a.Find(c));
            //MyString d = new MyString();
            //d.GetLine();
            //Console.WriteLine(a.Replace(c, d));
            //Console.WriteLine(a.Replace(c, d).Length);
            //MarkovAlgorithmForMyString m = new MarkovAlgorithmForMyString();
            //m.ReadData("in1.txt");
            //MyString ms = new MyString(m.DoingAlgorithm());
            //MyString msForCheck = new MyString("333");
            //Console.WriteLine(ms);
            //Console.ReadLine();
        }
    }
}
