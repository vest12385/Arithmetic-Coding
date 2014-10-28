using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic
{
    /// <summary>
    /// decoding類別
    /// </summary>
    class decoding
    {
        public decoding()   //建構子
        { }
        ~decoding() { } //解構子


        /// <summary>
        ///主要做解碼動作
        /// </summary>
        /// <param name="output"> 編碼完的結果 </param>
        /// <param name="probability"> 紀錄機率跟範圍的字典，以一個cahr當作key </param>
        /// <param name="length"> 這個Alphabet的長度 </param>
        /// <returns> 解碼結果 </returns>
        public string decode(decimal output, Dictionary<char, code> probability, int length)
        {
            string answer = string.Empty;
            int round = 0;
            while (round != length)
            {
                foreach (KeyValuePair<char, code> item in probability)
                {
                    if (item.Value.low <= output && output < item.Value.high)
                    {
                        answer += item.Key;
                        output -= item.Value.low;
                        output /= (item.Value.high - item.Value.low);
                        break;
                    }
                }
                round++;
            }
            return answer;
        }
    }
}
