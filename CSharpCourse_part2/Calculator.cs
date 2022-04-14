using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part2
{
    public class Calculator
    {
        //public double CalcTriangleSquareByFormulaGerona(double ab, double bc, double ac)
        public double CalcTriangleSquare(double ab, double bc, double ac)
        {
            double p = (ab + bc + ac) / 2;
            
            double square = Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac));
            
            return square;
        }

        //public double CalcTriangleSquareByHeightAndBase(double b, double h)
        public double CalcTriangleSquare(double b, double h) // - сигнатура
        {
            return 0.5 * b * h;
        }

        //если сигнатура у методов отличается (например отличается количество аргументов)
        //то они имеют право иметь одинаковые имена
        //но если отличия только в возвращаемом типе, то компилятор не допустит такой перегрузке
        //но если у методов одинаковое кол-во аргументов и возвразаемый тип, но у аргументов отличаются типы, то компилятор это поймёт:
        //
        /*
         * public double CalcSquareOfTriangle(double ac, double ab, double bc) <-> public double CalcSquareOfTriangle(double ac, double ab, int angle) - хорошо
         * public double CalcSquareOfTriangle(double ac, double ab, double bc) <-> public float CalcSquareOfTriangle(double ac, double ab, double bc) - плохо
         */

        public double Average(int[] numbers)
        {
            double sum = 0;

            foreach (var item in numbers)
            {
                sum += item;
            }

            return sum / numbers.Length;
        }

        // ключевое слово params позволяет передать в качестве аргументов метода
        // набор элементов, а не массив целиком
        //
        // аргумент с модификатором params должен быть последним в списке
        //
        // если помимо какого-то массива предполагается передать ещё какие-либо 
        // аргументы, то лечше не использовать params
        public double Average2(params int[] numbers)
        {
            double sum = 0;

            foreach (var item in numbers)
            {
                sum += item;
            }

            return sum / numbers.Length;
        }

        public static double CalcTriangleSquare(double ab, double ac, int alpha, bool isInRadians = false)
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

        //аргументов с модификатором out может быть несколько
        //они обязательно должны идти последними(?)
        public bool TryDivide(double divisible, double divisor, out double result)
        {
            result = 0; //следует изначально присвоить в out параметр некоторый результат

            if (divisor == 0)
            {
                return false;
            }

            result = divisible / divisor;
            return true;
        }
    }
}
