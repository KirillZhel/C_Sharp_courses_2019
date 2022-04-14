using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part2
{
    //структура - типы значений, а классы - ссылочные типы

    public struct EvilStruct
    {
        public int X;
        public int Y;

        //структура содержит ссылочный тип (экземпляр типа PointRef)
        public PointRef pointRef;
    }

    public struct PointVal
    {
        public int X;
        public int Y;

        public void LogValues()
        {
            Console.WriteLine($"X = {X}; Y = {Y}");
        }
    }

    public class PointRef
    {
        public int X;
        public int Y;

        public void LogValues()
        {
            Console.WriteLine($"X = {X}; Y = {Y}");
        }
    }
}
