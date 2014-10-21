using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic
{
    class decoding
    {
        public decoding()
        { }
        ~decoding() { }
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
            Console.WriteLine("Input : {0}", answer);
            return answer;
        }
    }
}
