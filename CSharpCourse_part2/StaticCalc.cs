using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part2
{
    public static class StaticCalc
    {
        public static double CalcTriangleSquare(double ab, double bc, double ac)
        {
            double p = (ab + bc + ac) / 2;
            
            double square = Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac));
            
            return square;
        }

        public static double CalcTriangleSquare(double b, double h)
        {
            return 0.5 * b * h;
        }

        public static double Average(int[] numbers)
        {
            double sum = 0;

            foreach (var item in numbers)
            {
                sum += item;
            }

            return sum / numbers.Length;
        }

        public static double Average2(params int[] numbers)
        {
            double sum = 0;

            foreach (var item in numbers)
            {
                sum += item;
            }

            return sum / numbers.Length;
        }

        // параметру метода можно присвоить значение по умолчанию, тогда пользователь может его не передавать
        // 1) параметры с значением по умолчанию должны быть в конце параметров
        // 2) нельзя присваивать по умолчанию методы или классы и тп: double ac = Math.Pow(3, 4)
        // только вычисляемые в процессе компиляции (compile time constant): double ac = 10.5
        // 3) не все языки платформы .Net поддерживают параметры по умолчанию
        // 4) изменение значения по умолчанию требует перекомпиляции всего проекта, используещего методы с параметрами по умолчанию
        // иначе может получиться так, что программа использует старое значение по умолчанию, а действует по новой логике
        public static double CalcTriangleSquare(double ab, double ac , int alpha, bool isInRadians = false)
        {
            if (isInRadians)
            {
                double rads = alpha * Math.PI / 180;
                return 0.5 * ab * ac * Math.Sin(rads);
            }
            else
            {
                return 0.5 * ab * ac * Math.Sin(alpha);
            }
        }

        public static bool TryDivide(double divisible, double divisor, out double result)
        {
            result = 0;

            if (divisor == 0)
            {
                return false;
            }

            result = divisible / divisor;
            return true;
        }
    }
}
