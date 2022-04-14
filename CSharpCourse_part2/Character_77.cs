using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part2
{
    class Character_77
    {
        private readonly int speed = 10;

        public int Health { get; set; } = 100;

        public Race Race { get; private set; }

        public int Armor { get; private set; }
        
        //конструктор с перечислениями
        public Character_77(Race race)
        {
            Race = race;

            /*
             * Вообще использование перечислений так же позволяет
             * делать вот так, приведя объект типа enum можем получить число
             * которое в нашем случае например является количеством брони
             */
            Armor = (int)race;

            //что заменит вот такой кусок кода
            switch(race)
            {
                case Race.Elf:
                    Armor = 30;
                    break;
                case Race.Ork:
                    Armor = 40;
                    break;
                case Race.Terrain:
                    Armor = 20;
                    break;
                default:
                    throw new ArgumentException("Unknown race");
            }

            //или такой кусок кода
            if (race == Race.Elf)
            {
                Armor = 30;
            }
            else if (race == Race.Ork)
            {
                Armor = 40;
            }
            else if (race == Race.Terrain)
            {
                Armor = 20;
            }
            else
            {
                throw new ArgumentException("Unknown race");
            }
        }

        public Character_77(Race race, int armor)
        {
            Race = race;
            Armor = armor;
        }

        public Character_77(Race race, int armor, int speed)
        {
            Race = race;
            Armor = armor;
            this.speed = speed;
        }

        public int PrintSpeed()
        {
            return speed;
        }

        public void Hit(int damage)
        {
            Health -= damage;
        }

    }
}
