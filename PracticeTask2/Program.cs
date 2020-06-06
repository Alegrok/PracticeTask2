using System;
using System.Text.RegularExpressions;

namespace PracticeTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Паттерны основных выражений
            string pattern1 = @"^((\-{0,1}\d+)\-(\-{0,1}\d+)\=(\-{0,1}\d+))$"; //для -
            string pattern2 = @"^((\-{0,1}\d+)\+(\-{0,1}\d+)\=(\-{0,1}\d+))$"; //для +
            string pattern3 = @"^((\-{0,1}\d+)\*(\-{0,1}\d+)\=(\-{0,1}\d+))$"; //для *
            string pattern4 = @"^((\-{0,1}\d+)\/(\-{0,1}\d+)\=(\-{0,1}\d+))$"; //для /
            
            // Считываем выражение
            string read = Console.ReadLine();

            if (read == null) // Если выражение пустое, 
            {
                Console.WriteLine("ERROR");
                return;
            }

            Match m;  // Массив данных, хранящий числа операций
            int sign; // Знак операции в выражении

            // Сравниваем строку с паттернами
            if (Regex.IsMatch(read, pattern2, RegexOptions.IgnoreCase)) 
            {
                // Для суммы
                m = Regex.Match(read, pattern2, RegexOptions.IgnoreCase);
                sign = 1;
            }
            else if (Regex.IsMatch(read, pattern3, RegexOptions.IgnoreCase))
            {
                // Для умножения
                m = Regex.Match(read, pattern3, RegexOptions.IgnoreCase);
                sign = 2;
            }
            else if (Regex.IsMatch(read, pattern4, RegexOptions.IgnoreCase))
            {
                // Для деления
                m = Regex.Match(read, pattern4, RegexOptions.IgnoreCase);
                sign = 3;
            }
            else if (Regex.IsMatch(read, pattern1, RegexOptions.IgnoreCase))
            {
                // Для разности
                m = Regex.Match(read, pattern1, RegexOptions.IgnoreCase);
                sign = 4;
            }
            else
            {
                // Для некорректных выражений
                Console.WriteLine("ERROR");
                return;
            }

            // Получаем 3 числа в выражении
            double num1 = double.Parse(m.Groups[2].Value);
            double num2 = double.Parse(m.Groups[3].Value);
            double num3 = double.Parse(m.Groups[4].Value);

            // Проверка деления на 0
            if (num2 == 0 && sign == 3)
            {
                Console.WriteLine("NO");
                return;
            }
            // Если тождество выполняется, то результат YES, иначе NO
            if (sign == 1) Console.WriteLine(num1 + num2 == num3 ? "YES" : "NO"); // Для +
            if (sign == 2) Console.WriteLine(num1 * num2 == num3 ? "YES" : "NO"); // Для *
            if (sign == 3) Console.WriteLine(num3 * num2 == num1 ? "YES" : "NO"); // Для /
            if (sign == 4) Console.WriteLine(num1 - num2 == num3 ? "YES" : "NO"); // Для -
        }
    }
}
