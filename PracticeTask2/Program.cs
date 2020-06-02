using System;
using System.Text.RegularExpressions;

namespace PracticeTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern1 = @"^((\-{0,1}\d+)\-(\-{0,1}\d+)\=(\-{0,1}\d+))$"; //для -
            string pattern2 = @"^((\-{0,1}\d+)\+(\-{0,1}\d+)\=(\-{0,1}\d+))$"; //для +
            string pattern3 = @"^((\-{0,1}\d+)\*(\-{0,1}\d+)\=(\-{0,1}\d+))$"; //для *
            string pattern4 = @"^((\-{0,1}\d+)\/(\-{0,1}\d+)\=(\-{0,1}\d+))$"; //для /
            string read = Console.ReadLine();

            if (read == null)
            {
                Console.WriteLine("ERROR");
                return;
            }

            Match m;
            int sign;

            if (Regex.IsMatch(read, pattern2, RegexOptions.IgnoreCase))
            {
                m = Regex.Match(read, pattern2, RegexOptions.IgnoreCase);
                sign = 1;
            }
            else
            if (Regex.IsMatch(read, pattern3, RegexOptions.IgnoreCase))
            {
                m = Regex.Match(read, pattern3, RegexOptions.IgnoreCase);
                sign = 2;
            }
            else
            if (Regex.IsMatch(read, pattern4, RegexOptions.IgnoreCase))
            {
                m = Regex.Match(read, pattern4, RegexOptions.IgnoreCase);
                sign = 3;
            }
            else
            if (Regex.IsMatch(read, pattern1, RegexOptions.IgnoreCase))
            {
                m = Regex.Match(read, pattern1, RegexOptions.IgnoreCase);
                sign = 4;
            }
            else
            {
                Console.WriteLine("ERROR");
                return;
            }

            double num1 = double.Parse(m.Groups[2].Value);
            double num2 = double.Parse(m.Groups[3].Value);
            double num3 = double.Parse(m.Groups[4].Value);

            if (num2 == 0 && sign == 3)
            {
                Console.WriteLine("NO");
                return;
            }
            if (sign == 1) Console.WriteLine(num1 + num2 == num3 ? "YES" : "NO");
            if (sign == 2) Console.WriteLine(num1 * num2 == num3 ? "YES" : "NO");
            if (sign == 3) Console.WriteLine(num3 * num2 == num1 ? "YES" : "NO");
            if (sign == 4) Console.WriteLine(num1 - num2 == num3 ? "YES" : "NO");
        }
    }
}
