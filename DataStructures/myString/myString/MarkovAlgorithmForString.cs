using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myString
{
    /// <summary>
    /// Markov Algorithm For Standart String
    /// </summary>
    public class MarkovAlgorithmForString
    {
        /// <summary>
        /// list substitutions
        /// </summary>
        private List<KeyValuePair<string, string>> substitutions;

        /// <summary>
        /// line in which will perform substitutions
        /// </summary>
        private string line;

        /// <summary>
        /// max count performed substitutions
        /// </summary>
        const int N = (int)1e6;

        /// <summary>
        /// default constructor
        /// </summary>
        public MarkovAlgorithmForString()
        {
            this.substitutions = new List<KeyValuePair<string, string>>();
            this.line = string.Empty;
        }

        /// <summary>
        /// constructor with parameters
        /// </summary>
        /// <param name="someSubstitutions">list substitutions</param>
        /// <param name="someLine">line</param>
        public MarkovAlgorithmForString(List<KeyValuePair<string, string>> someSubstitutions, string someLine)
        {
            for (int i = 0; i < someSubstitutions.Count; i++)
            {
                this.substitutions.Add(someSubstitutions[i]);
            }
            this.line = someLine;
        }

        /// <summary>
        /// copy constructor
        /// </summary>
        /// <param name="someMarkovAlgorithmForString">variable of type MarkovAlgorithmForString</param>
        public MarkovAlgorithmForString(MarkovAlgorithmForString someMarkovAlgorithmForString)
        {
            for (int i = 0; i < someMarkovAlgorithmForString.substitutions.Count; i++)
            {
                this.substitutions.Add(someMarkovAlgorithmForString.substitutions[i]);
            }
            this.line = someMarkovAlgorithmForString.line;
        }

        /// <summary>
        /// Markov algorithm performs
        /// </summary>
        /// <returns></returns>
        public string DoingAlgorithm()
        {
            int i = 0;
            int countPerformedSubstitutions = 0;
            string resultLine = line;
            while(i < substitutions.Count)
            {
                int index = resultLine.IndexOf(substitutions[i].Key);
                if( index != -1)
                {
                    resultLine = resultLine.Remove(index, substitutions[i].Key.Length);
                    resultLine = resultLine.Insert(index, substitutions[i].Value);
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
            this.line = readLine;
            while ((readLine = file.ReadLine()) != null)
            {
                this.substitutions.Add(new KeyValuePair<string, string>(readLine.Split(' ')[0], readLine.Split(' ')[1]));
            }
        }
    }
}
