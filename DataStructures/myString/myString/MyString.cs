namespace myString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

   public class MyString
    {
        /// <summary>
        /// array symbols
        /// </summary>
        private char[] mystring;
        
        /// <summary>
        /// default constructor
        /// </summary>
        public MyString()
        {
            this.mystring = null;
        }

        /// <summary>
        /// constructor with parameters
        /// </summary>
        /// <param name="newMyString">array of symbols</param>
        public MyString(char[] newMyString)
        {
            if (this.mystring != null)
            {
                Array.Clear(this.mystring, 0, this.mystring.Length);
            }
            this.mystring = new char[newMyString.Length];
            for (int i = 0; i < newMyString.Length; i++)
            {
                this.mystring[i] = newMyString[i];
            }
        }

        /// <summary>
        /// constructor with parameters
        /// </summary>
        /// <param name="reader">string</param>
        public MyString(string reader)
        {
            if (this.mystring != null)
            {
                Array.Clear(this.mystring, 0, this.mystring.Length);
            }
            this.mystring = new char[reader.Length];
            int index = 0;
            foreach (char symbol in reader)
            {
                this.mystring[index] = symbol;
                index++;
            }
        }

       /// <summary>
       /// copy constructor
       /// </summary>
       /// <param name="newMyString">variable of type MyString</param>
        public MyString(MyString newMyString)
        {
            if (this.mystring != null)
            {
                Array.Clear(this.mystring, 0, this.mystring.Length);
            }
            this.mystring = new char[newMyString.mystring.Length];
            for (int i = 0; i < newMyString.mystring.Length; i++)
            {
                this.mystring[i] = newMyString.mystring[i];
            }
        }
        
        /// <summary>
        /// get length of string
        /// </summary>
        public int Length
        {
            get
            {
                return this.mystring.Length;
            }
        }
        
        /// <summary>
        /// operator +(concatenation) two strings
        /// </summary>
        /// <param name="firstMyString">first string</param>
        /// <param name="secondMyString">second string</param>
        /// <returns>concatenation two strings</returns>
        public static MyString operator +(MyString firstMyString, MyString secondMyString)
        {
            char[] resultArray = new char[firstMyString.mystring.Length + secondMyString.mystring.Length];
            int index = 0;
            foreach(char symbol in firstMyString.mystring)
            {
                resultArray[index] = symbol;
                index++;
            };
            foreach (char symbol in secondMyString.mystring)
            {
                resultArray[index] = symbol;
                index++;
            };
            return new MyString(resultArray);
        }
        
        /// <summary>
        /// operator == of two strings
        /// </summary>
        /// <param name="firstMyString">first string</param>
        /// <param name="secondMyString">second string</param>
        /// <returns>true if strings are equel, false otherwise</returns>
        public static bool operator ==(MyString firstMyString, MyString secondMyString)
        {
            if (firstMyString.mystring.Length != secondMyString.mystring.Length)
            {
                return false;
            }
            int index = 0;
            while (index < firstMyString.mystring.Length)
            {
                if (firstMyString.mystring[index] != secondMyString.mystring[index])
                {
                    return false;
                }
                index++;
            }
            return true;
        }

        /// <summary>
        /// operator != of two strings
        /// </summary>
        /// <param name="firstMyString">first string</param>
        /// <param name="secondMyString">second string</param>
        /// <returns>true if strings are not equel, false otherwise</returns>
        public static bool operator !=(MyString firstMyString, MyString secondMyString)
        {
            if (firstMyString == secondMyString)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        /// <summary>
        /// get and set symbol on position
        /// </summary>
        /// <param name="index">position</param>
        /// <returns>symbol on position</returns>
        public char this [int index]
        {
            get
            {
                if (index < this.mystring.Length)
                {
                    return this.mystring[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }

            set
            {
                if (index < this.mystring.Length)
                {
                    if(value.GetType() == typeof(char))
                    {
                        this.mystring[index] = value;
                    }
                    else
                    {
                        throw new ArgumentException("Value isn't type char");
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
        }

        /// <summary>
        /// find substring in string
        /// </summary>
        /// <param name="subString">substring that need find</param>
        /// <returns>-1 if didn't find, position from that begin substring in string otherwise</returns>
        public int Find(MyString subString)
        {
            int position = -1;
            for (int i = 0; i <= this.mystring.Length - subString.mystring.Length; i++)
            {
                if (this.mystring[i] == subString.mystring[0])
                {
                    bool ok = true;
                    for (int j = 0; j < subString.mystring.Length; j++)
                    {
                        if (subString.mystring[j] != this.mystring[i + j])
                        {
                            ok = false;
                        }
                    }
                    if (ok)
                    {
                        position = i;
                        break;
                    }
                }
            }
            /*/// index elements of subString
            int j = 1;

            /// index elements of string
            int i = 0;

            int position = -1;

            bool flag = false;
            while(i <= this.mystring.Length - subString.mystring.Length && !flag)
            {
                if (this.mystring[i] == subString.mystring[0])
                {
                    position = i;
                    flag = true;
                    i++;
                    while (j < subString.mystring.Length && flag)
                    {
                        if (this.mystring[i] == subString.mystring[j])
                        {
                            i++;
                            j++;
                        }
                        else
                        {
                            j = 1;
                            flag = false;
                            position = -1;
                        }
                    }
                }
                else
                {
                    i++;
                }
            }*/
            return position;
        }

        /// <summary>
        /// replace substring1 into substring2
        /// </summary>
        /// <param name="subString1">substring that will be replaced</param>
        /// <param name="subString2">substring that will be inserted</param>
        /// <returns>string after replacing</returns>
        public MyString Replace(MyString subString1, MyString subString2)
        {
            char[] resultAfterReplace = new char[this.mystring.Length - subString1.mystring.Length + subString2.mystring.Length];
            int findPosition = this.Find(subString1);
            if ( findPosition == -1)
            {
                throw new ArgumentException("Specified substring not exist");
            }
            else
            {
                int index = 0;
                for (int i = 0; i < findPosition; i++)
                {
                    resultAfterReplace[index] = this.mystring[i];
                    index++;
                }
                for (int i = 0; i < subString2.mystring.Length; i++)
                {
                    resultAfterReplace[index] = subString2.mystring[i];
                    index++;
                }
                for (int i = findPosition + subString1.mystring.Length; i < this.mystring.Length; i++)
                {
                    resultAfterReplace[index] = this.mystring[i];
                    index++;
                }
            }
            return new MyString(resultAfterReplace);
        }
        
        /// <summary>
        /// read line from console
        /// </summary>
        public void GetLine()
        {
            string reader = Console.ReadLine();
            char[] resultArray = new char[reader.Length];
            int index = 0;
            foreach (char symbol in reader)
            {
                resultArray[index] = symbol;
                index++;
            }
            if (this.mystring != null)
            {
                Array.Clear(this.mystring, 0, this.mystring.Length);
            }
            this.mystring = new char[resultArray.Length];
            this.mystring = resultArray;
        }

        /// <summary>
        /// read line from file
        /// </summary>
        /// <param name="path">path to file</param>
        public void GetLine(string path)
        {
            string readLine = string.Empty;
            System.IO.StreamReader file = new System.IO.StreamReader(@path);
            if ((readLine = file.ReadLine()) == null)
            {
                throw new ArgumentNullException("File empty or not exist");
            }
            char[] resultArray = new char[readLine.Length];
            int index = 0;
            foreach (char symbol in readLine)
            {
                resultArray[index] = symbol;
                index++;
            }
            if (this.mystring != null)
            {
                Array.Clear(this.mystring, 0, this.mystring.Length);
            }
            this.mystring = new char[resultArray.Length];
            this.mystring = resultArray;
        }

        /// <summary>
        /// overriding method ToString
        /// </summary>
        /// <returns>MyStrind in type String</returns>
        public override string ToString()
        {
            string result = string.Empty;
            foreach (char symbol in this.mystring)
            {
                result += symbol;
            }
            return result;
        }
    }
}
