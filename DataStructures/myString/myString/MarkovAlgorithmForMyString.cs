using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myString
{
    /// <summary>
    /// Markov Algorithm For my String
    /// </summary>
    public class MarkovAlgorithmForMyString
    {
        /// <summary>
        /// list substitutions
        /// </summary>
        private List<KeyValuePair<MyString, MyString>> substitutions;

        /// <summary>
        /// line in which will perform substitutions
        /// </summary>
        private MyString line;

        /// <summary>
        /// max count performed substitutions
        /// </summary>
        const int N = (int)1e6;

        /// <summary>
        /// default constructor
        /// </summary>
        public MarkovAlgorithmForMyString()
        {
            this.substitutions = new List<KeyValuePair<MyString, MyString>>();
            this.line = new MyString();
        }

        /// <summary>
        /// constructor with parameters
        /// </summary>
        /// <param name="someSubstitutions">list substitutions</param>
        /// <param name="someLine">line</param>
        public MarkovAlgorithmForMyString(List<KeyValuePair<MyString, MyString>> someSubstitutions, MyString someLine)
        {
            for (int i = 0; i < someSubstitutions.Count; i++)
            {
                this.substitutions.Add(someSubstitutions[i]);
            }
            this.line = new MyString(someLine);
        }

        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="someMarkovAlgorithmForString">variable of type MarkovAlgorithmForMyString</param>
        public MarkovAlgorithmForMyString(MarkovAlgorithmForMyString someMarkovAlgorithmForMyString)
        {
            for (int i = 0; i < someMarkovAlgorithmForMyString.substitutions.Count; i++)
            {
                this.substitutions.Add(someMarkovAlgorithmForMyString.substitutions[i]);
            }
            this.line = new MyString(someMarkovAlgorithmForMyString.line);
        }

        /// <summary>
        /// Markov algorithm performs
        /// </summary>
        /// <returns></returns>
        public MyString DoingAlgorithm()
        {
            int i = 0;
            int countPerformedSubstitutions = 0;
            MyString resultLine = new MyString(line);
            while(i < substitutions.Count)
            {
                if(resultLine.Find(substitutions[i].Key) != -1)
                {
                    resultLine = resultLine.Replace(substitutions[i].Key, substitutions[i].Value);
                    i = 0;
                    if (countPerformedSubstitutions < N)
                    {
                        countPerformedSubstitutions++;
                    }
                    else
                    {
                        throw new InvalidOperationException("Substitutions performed too long.");
                    }
                }
                else
                {
                    i++;
                }
            }
            return resultLine;
        }

        /// <summary>
        /// read data from file
        /// </summary>
        /// <param name="path">path to file</param>
        public void ReadData(string path)
        {
            string readLine = string.Empty;
            System.IO.StreamReader file = new System.IO.StreamReader(@path);
            if ((readLine = file.ReadLine()) == null)
            {
                throw new ArgumentNullException("File empty or not exist");
            }
            this.line = new MyString(readLine);
            while ((readLine = file.ReadLine()) != null)
            {
                this.substitutions.Add(new KeyValuePair<MyString, MyString>(new MyString(readLine.Split(' ')[0]), new MyString(readLine.Split(' ')[1])));
            }
        }
    }
}
