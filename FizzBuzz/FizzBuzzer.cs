using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FizzBuzz
{
    public class FizzBuzzer : IEnumerable<String>
    {
        private List<String> values;

        public FizzBuzzer(int limit)
        {
            values = GetValues(limit);
        }

        private List<String> GetValues(int limit)
        {
            List<String> vals = new List<string>();

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

                vals.Add(result);
            }

            return vals;
        }

        public IEnumerator GetEnumerator()
        {
            return values.GetEnumerator();
        }

        IEnumerator<String> IEnumerable<String>.GetEnumerator()
        {
            foreach (String str in values)
            {
                yield return str;
            }
        }
    }
}
