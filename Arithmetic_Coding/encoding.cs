using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic
{
    /// <summary>
    /// 編碼類別
    /// </summary>
    class encoding
    {
        private Dictionary<char, code> probability = new Dictionary<char, code>();  //字典，紀錄機率跟範圍，以一個Char為Key
        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="word"> alphabet </param>
        public encoding(string word)
        {
            calculateProbability(word);
        }
        /// <summary>
        /// 取出字典
        /// </summary>
        public Dictionary<char, code> getProbability
        {
            get { return probability; }
        }
        ~encoding() { }  //解構子
        /// <summary>
        /// 計算每一個character出現次數
        /// 若第一次出現則放入字典
        /// 若有出現過將該字對應到的類別(code)裡的prob(機率)加一
        /// </summary>
        /// <param name="word">alphabet</param>
        private void calculateProbability(string word)
        {
            List<char> wordChar = word.ToList();    //轉成字元陣列
            wordChar.Sort();    //排序
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
        /// <summary>
        /// 計算機率跟範圍
        /// </summary>
        /// <param name="wordChar"> alphabet </param>
        /// <param name="AllWord"> 總共有多少個字元 </param>
        /// <param name="limit"> 計算目前到哪個下邊界 </param>
        /// <param name="probability[ecahWord].prob"> 以ecahWord為key 所對應到的 機率 </param>
        /// <param name="probability[ecahWord].low"> 以ecahWord為key 所對應到的 下邊界 </param>
        /// <param name="probability[ecahWord].high"> 以ecahWord為key 所對應到的 上邊界 </param>
        private void handleProbability(List<char> wordChar)
        {
            int AllWord = wordChar.Count; 
            wordChar = wordChar.Distinct().ToList();    //去除重複，看有哪幾種字元
            decimal limit = 0m;
            foreach (char ecahWord in wordChar)
            {
                if (probability.ContainsKey(ecahWord))
                {
                    probability[ecahWord].prob /= AllWord;
                    probability[ecahWord].low = Math.Round(limit, 7 );
                    probability[ecahWord].high = Math.Round(limit + probability[ecahWord].prob, 7);
                    limit = limit + probability[ecahWord].prob;
                }
            }
        }
        /// <summary>
        /// 主要編碼部分，完全依課本演算法做
        /// </summary>
        /// <param name="word">alphabet</param>
        /// <returns>編碼結果</returns>
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
                Console.WriteLine("Outout = {0}\r\n", output);
            }
            return output;
        }
    }
    /// <summary>
    /// code 類別 prob 為機率, low 為 下邊界, high 為 上邊界
    /// </summary>
    class code
    {
        public decimal low = 0;
        public decimal high = 1;
        public decimal prob = 1;
    }
}
