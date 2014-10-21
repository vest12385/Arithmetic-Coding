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
            string word = Console.ReadLine();
            Arithmetic.encoding EnCoding = new Arithmetic.encoding(word);
            decimal output = EnCoding.encoder(word);
            Arithmetic.decoding DeCoding = new Arithmetic.decoding();
            string input = DeCoding.decode(output, EnCoding.getProbability, word.Count());
            Console.Read();
        }
    }
}
