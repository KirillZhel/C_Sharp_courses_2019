using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part3
{
    public class Character_84
    {
        private readonly int speed = 10;

        public int Health { get; set; } = 100;

        public Race Race { get; private set; }
        public string Name { get; private set; }
        public int Armor { get; private set; }


        public Character_84(Race race, int armor)
        {
            Race = race;
            Armor = armor;
        }

        public Character_84(Race race, int armor, int speed)
        {
            Race = race;
            Armor = armor;
            this.speed = speed;
        }

        public Character_84(string name, int armor)
        {
            //проброс исключений
            //исключение, при котором не предполагается приравнивание переменной null
            if(name == null)
                throw new ArgumentNullException("name arg can't be null");


            //исключение при котором параметру задаётся неправильное значение
            if (armor < 0 || armor > 100)
                throw new ArgumentException("armor can't be less than 0 or greater then 100");

            Name = name;
            Armor = armor;
        }

        public int PrintSpeed()
        {
            return speed;
        }

        public void Hit(int damage)
        {
            if (Health == 0)
            {
                //исключение при котором вызвали метод,
                //который не предполагается вызывать в таком состоянии
                throw new InvalidOperationException("Can't hit a dead character.");
            }

            if (damage > Health)
            {
                throw new ArgumentException("damage can't be greater than current Health");
            }
            //if (damage > Health)
            //{
            //    damage = Health;
            //}
            Health -= damage;
        }
    }
}
