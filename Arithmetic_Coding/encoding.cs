using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic
{
    class encoding
    {
        private Dictionary<char, code> probability = new Dictionary<char, code>();
        public encoding(string word)
        {
            calculateProbability(word);
        }
        public Dictionary<char, code> getProbability
        {
            get { return probability; }
        }
        ~encoding() { }
        private void calculateProbability(string word)
        {
            List<char> wordChar = word.ToList();
            wordChar.Sort();
            foreach (char ecahWord in wordChar)
            {
                code dd = new code();
                if (probability.ContainsKey(ecahWord))
                {
                    probability[ecahWord].prob += 1;
                }
                else
                {
                    probability.Add(ecahWord, dd);
                }
            }
            handleProbability(wordChar);
        }
        private void handleProbability(List<char> wordChar)
        {
            int AllWord = wordChar.Count;
            wordChar = wordChar.Distinct().ToList();
            decimal limit = 0m;
            foreach (char ecahWord in wordChar)
            {
                if (probability.ContainsKey(ecahWord))
                {
                    probability[ecahWord].prob /= AllWord;
                    probability[ecahWord].low = limit;
                    probability[ecahWord].high = limit + probability[ecahWord].prob;
                    limit = limit + probability[ecahWord].prob;
                }
            }
        }
        public decimal encoder(string word)
        {
            decimal low = 0;
            decimal high = 1;
            decimal range = high - low;
            decimal output = 0;
            for (int i = 0; i < word.Count(); i++)
            {
                Console.WriteLine("Now is {0} ( {0}'s Rang is {1,7:G5} ~ {2,7:G5} ), Entirety range is {3,7:G5}", word[i], probability[word[i]].low, probability[word[i]].high, Math.Round(range, 7));
                high = low + (range * probability[word[i]].high);
                Console.WriteLine("Hight = low + ( {0,7:G5} * {1,7:G5} ) = {2,7:G5} ", Math.Round(range, 7), probability[word[i]].high, Math.Round(high, 7));
                low = low + (range * probability[word[i]].low);
                Console.WriteLine("Low = low + ( {0,7:G5} * {1,7:G5} ) = {2,7:G5} ", Math.Round(range, 7), probability[word[i]].low, Math.Round(low, 7));
                range = high - low;
                output = low;
                Console.WriteLine("Outout = {0}", output);
            }
            return output;
        }
    }
    class code
    {
        public decimal low = 0;
        public decimal high = 1;
        public decimal prob = 1;
    }
}
