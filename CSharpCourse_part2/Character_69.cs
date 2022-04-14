using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part2
{
    public class Point2D
    {
        private int x;
        private int y;

        public Point2D(int x, int y)
        {
            //ключевое слово this призвано отличить x-поле класса от x-параметра конструктора
            this.x = x;
            this.y = y;
        }
    }

    class Character_69
    {
        private static int speed = 10;

        //если мы хотим сделать неизменяемое поле, то ставим модификатор const
        //при объявлении константы мы обязаны сразу присвоить значение
        private const int speed_2 = 10;
        //теперь нельзя переприсваивать новое значение
        //нельзя speed_2 = 12; в каком-нибудь методе
        //так же можно использовать модификатор readonly
        private readonly int speed_3 = 10;
        //присвоить этому поле значение можно либо сразу либо ТОЛЬКО в конструкторе
        
        //если полю readonly сразу присвоенно значение и оно используется в точности
        //как константа, то есть разница: const поле - каждый раз при запуске вычисляется
        //а поле readonly - ссылается на ячейку памяти, т.е. при измененении значения
        //такого поля следует ПЕРЕКОМПИЛИРОВАТЬ программу

        public int Health { get; set; } = 100;

        public string Race { get; private set; }

        public Race RaceEnum { get; private set; }
        public int Armor { get; private set; }
        //конструктор - особый метод, вызываемый при создании экземпляра
        //если в классе конструктора нет в классе,
        //значит у класса конструктор по умолчанию, который ничего не делает
        
        //конструктор с аргументами
        public Character_69(string race)
        {
            Race = race;
        }

        //конструктор с перечислениями
        public Character_69(Race race)
        {
            RaceEnum = race;
            Armor = (int)race;
        }

        public Character_69(string race, int armor)
        {
            Race = race;
            Armor = armor;
        }

        public Character_69(string race, int armor, int speed)
        {
            Race = race;
            Armor = armor;
            this.speed_3 = speed;
        }

        //конструктор по умолчанию
        //public Character_69()
        //{

        //}

        public int PrintSpeed()
        {
            return speed;
        }

        public void IncreaseSpeed()
        {
            speed += 10;
        }

        public void Hit(int damage)
        {
            Health -= damage;
        }

    }
}
