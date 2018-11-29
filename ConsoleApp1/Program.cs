using System;

namespace IdParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var code = "38902220332";
            var actual = IdParser.ValidDate(code);

            Console.WriteLine(actual);

            Console.ReadKey();
        }
    }
}
