/*
Number to Text Converter from Coding Challenges
by Silvio Duka

Last modified date: 2018-03-11

Write a program that will convert a decimal number into its text equivalent. 

For Example: 
11: eleven 
193: one hundred ninety three 
1996: one thousand nine hundred ninety six 
*/

using System;
using System.Collections.Generic;

namespace NumberToTextConverter
{
    class Program
    {
        static Dictionary<long, string> dict = new Dictionary<long, string>();

        static void Main(string[] args)
        {
            long number = 901901901; // Insert a number to convert to text (max. 999999999)

            InitDictionary();

            Console.WriteLine($"{number}: {ConvertNumberToText(number)}");
        }

        static string ConvertNumberToText(long number)
        {
            if (number == 0) return "zero";

            long[] n = new long[9];
            long t = 10;
            int i = 0;

            while (number >= t / 10)
            {
                long d = number % t - number % (t / 10);

                if (d >= 1000 & d < 1000000) d = d / 1000;
                if (d >= 1000000 & d < 999000000) d = d / 1000000;

                n[i++] = d;

                t *= 10;
            }

            string result = String.Empty;

            for (int f = 8; f >= 0; f--)
            {
                if (f == 1 && n[1] == 10) { result += GetText(n[1] + n[0]); break; }
                if (f == 4 && n[4] == 10) { result += GetText(n[4] + n[3]) + " " + GetText(1000) + ", "; f--; continue; }
                if (f == 7 && n[7] == 10) { result += GetText(n[7] + n[6]) + " " + GetText(1000000) + ", "; f--; continue; }

                string s = GetText(n[f]);

                if (s == "zero" && result == String.Empty) s = String.Empty;
                if (s == "zero" && (n[5] == 0 || n[4] == 0)) s = String.Empty;
                if (s == "zero" && (n[7] == 0 || n[6] == 0)) s = String.Empty;

                result += s;

                if (f == 6 && n[8] + n[7] + n[6] > 0) result += " " + GetText(1000000) + ", ";
                if (f == 3 && n[5] + n[4] + n[3] > 0) result += " " + GetText(1000) + ", ";
                if (f == 8 && n[8] > 0 && n[7] + n[6] > 0) result += " and ";
                if (f == 5 && n[5] > 0 && n[4] + n[3] > 0) result += " and ";
                if (f == 2 && n[2] > 0 && n[1] + n[0] > 0) result += " and ";
                if (f == 7 && n[7] > 10 && n[6] > 0) result += "-";
                if (f == 4 && n[4] > 10 && n[3] > 0) result += "-";
                if (f == 1 && n[1] > 10 && n[0] > 0) result += "-";
            }

            return result.Trim().Trim(',');
        }

        static string GetText(long key)
        {
            string s;

            dict.TryGetValue(key, out s);

            return s;
        }

        static void InitDictionary()
        {
            dict.Add(0, "zero");
            dict.Add(1, "one");
            dict.Add(2, "two");
            dict.Add(3, "three");
            dict.Add(4, "four");
            dict.Add(5, "five");
            dict.Add(6, "six");
            dict.Add(7, "seven");
            dict.Add(8, "eight");
            dict.Add(9, "nine");
            dict.Add(10, "ten");
            dict.Add(11, "eleven");
            dict.Add(12, "twelve");
            dict.Add(13, "thirteen");
            dict.Add(14, "fourteen");
            dict.Add(15, "fifteen");
            dict.Add(16, "sixteen");
            dict.Add(17, "seventeen");
            dict.Add(18, "eighteen");
            dict.Add(19, "nineteen");
            dict.Add(20, "twenty");
            dict.Add(30, "thirty");
            dict.Add(40, "forty");
            dict.Add(50, "fifty");
            dict.Add(60, "sixty");
            dict.Add(70, "seventy");
            dict.Add(80, "eighty");
            dict.Add(90, "ninety");
            dict.Add(100, "one hundred");
            dict.Add(200, "two hundred");
            dict.Add(300, "three hundred");
            dict.Add(400, "four hundred");
            dict.Add(500, "five hundred");
            dict.Add(600, "six hundred");
            dict.Add(700, "seven hundred");
            dict.Add(800, "eight hundred");
            dict.Add(900, "nine hundred");
            dict.Add(1000, "thousand");
            dict.Add(1000000, "million");
        }
    }
}
