using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic_Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input encode word:");
            string word = Console.ReadLine();       //讀入Alphabet
            Arithmetic.encoding EnCoding = new Arithmetic.encoding(word);
            decimal output = EnCoding.encoder(word);    //將編碼結果輸出
            Arithmetic.decoding DeCoding = new Arithmetic.decoding();
            string input = DeCoding.decode(output, EnCoding.getProbability, word.Count());    //將解碼碼結果輸出
            Console.WriteLine("Origin Input: {0}", word);
            Console.WriteLine("Decoder Input : {0}", input);
            Console.Read();
        }
    }
}
