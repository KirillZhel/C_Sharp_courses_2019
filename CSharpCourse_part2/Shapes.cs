using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part2
{
    //ключевое слово abstract Обязывает класс наследник 
    //переопределять абстрактные методы
    public abstract class Shape
    {
        //нельзя создать экземпляр абстрактного класса
        public Shape()
        {
            Console.WriteLine("Shape Created");
        }

        //абстрактные методы не имеют реализации в родительском классе
        public abstract void Draw();

        //абстрактрные методы могут существовать только в абстрактном классе
        public abstract double Area();

        public abstract double Perimeter();
        
        //ничто не мешает в абстрактном классе создавать НЕабстрактные методы
    }

    public class Triangle : Shape
    {
        private readonly double ab;
        private readonly double bc;
        private readonly double ac;

        //всегда (если конструктор класса без параметров) в конструкторе наследника
        //присутствует вызов базового конструктора так, будто присутствует
        //ключевое слово : base(). А если всё же параметры есть в базовом
        //конструкторе, то уже наследование базового конструктора должно быть явным
        // то мы должны написать
        // public Triangle(double ab, double bc, double ac) : base(...)
        public Triangle(double ab, double bc, double ac)
        {
            this.ab = ab;
            this.bc = bc;
            this.ac = ac;

            Console.WriteLine("Triangle Created");
        }

        public override double Area()
        {
            double p = (ab + bc + ac) / 2;
            return Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac));
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing Triangle");
        }

        public override double Perimeter()
        {
            return ab + bc + ac;
        }
    }

    public class Rectangle : Shape
    {
        private readonly double width;
        private readonly double height;

        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;

            Console.WriteLine("Rectangle Created");
        }

        public override double Area()
        {
            return width * height;
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing Rectangle");
        }

        public override double Perimeter()
        {
            return 2 * width + 2 * height;
        }
    }
}
