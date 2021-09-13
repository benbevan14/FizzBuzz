using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FizzBuzz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fizzBuzzer = new FizzBuzzer(500);

            foreach (var value in fizzBuzzer)
            {
                Console.WriteLine(value);
            }

            Console.ReadLine();
        }
    }
}
