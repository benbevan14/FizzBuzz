using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FizzBuzz
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("How many numbers would you like to output?");
            int limit = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 1; i <= limit; i++)
            {
                String result = "";

                // If i is divisible by 3, 5, or 7 then append Fizz, Buzz or Bang to the result string
                if (i % 3 == 0)
                {
                    result += "Fizz";
                }
                if (i % 5 == 0)
                {
                    result += "Buzz";
                }
                if (i % 7 == 0)
                {
                    result += "Bang";
                }

                // If i is divisible by 13, print Fezz instead of that number.
                // Fezz goes immediately before the first capital B
                if (i % 13 == 0)
                {
                    // Fezz only doesn't go at the start when i is also divisible by 3
                    if (i % 3 == 0)
                    {
                        result = Regex.Replace(result, "Fizz", "FizzFezz");
                    }
                    else
                    {
                        result = "Fezz" + result;
                    }
                }

                // If i is divisible by 11 then replace everything with Bong, unless Fezz before it
                if (i % 11 == 0)
                {
                    if (i % 13 == 0)
                    {
                        result = "FezzBong";
                    }
                    else
                    {
                        result = "Bong";
                    }
                }

                if (i % 17 == 0)
                {
                    // Split the string by capital letters and reverse the resulting list
                    List<String> parts = new List<String>(Regex.Split(result, @"(?<!^)(?=[A-Z])"));
                    parts.Reverse();
                    result = String.Join("", parts);
                }

                // If result is empty then we just want to print the number
                if (result.Length == 0)
                {
                    result = i.ToString();
                }

                Console.WriteLine(result);
            }
            Console.ReadLine();
        }
    }
}
