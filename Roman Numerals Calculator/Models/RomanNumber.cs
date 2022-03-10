using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumCalculator.Models
{
    public class RomanNumber : ICloneable, IComparable
    {

        private ushort number;
        private static int[] values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private static string[] roman = new string[]
            { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        public RomanNumber(ushort n)
        {
            if (n <= 0) throw new RomanNumberException($"Число {n} меньше либо равно 0");
            else this.number = n;
        }

        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            int res = n1.number + n2.number;
            if (res <= 0) throw new RomanNumberException("Не удалось сложить  числа!");
            else
            {
                return new RomanNumber((ushort)res);

            }
        }

        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            int res = n1.number - n2.number;
            if (res <= 0) throw new RomanNumberException("Результат вычитания меньше или равен 0");
            else
            {
                return new RomanNumber((ushort)res);

            }
        }

        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            int res = n1.number * n2.number;
            if (res <= 0) throw new RomanNumberException("Не удалось умножить числа");
            else
            {
                return new RomanNumber((ushort)res);

            }
        }

        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {

            if (n2.number == 0) throw new RomanNumberException("Не удалось разделить числа");
            else
            {
                int res = n1.number / n2.number;
                if (res == 0) throw new RomanNumberException("Не удалось разделить числа");
                else
                {
                    return new RomanNumber((ushort)res);

                }
            }
        }

        public override string ToString()
        {
            int tmp = number;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 13; i++)
            {
                while (tmp >= values[i])
                {
                    tmp -= (ushort)values[i];
                    result.Append(roman[i]);
                }
            }
            if (result.ToString() == "")
                throw new RomanNumberException("Перевод числа в Римские цифры невозможен");
            else
                return result.ToString();

        }

        public object Clone()
        {
            return new RomanNumber(number);
        }

        public int CompareTo(object obj)
        {
            if (obj is RomanNumber roman)
                return number.CompareTo(roman.number);
            else
                throw new RomanNumberException("object is not a RomanNumber");
        }

    }

}
