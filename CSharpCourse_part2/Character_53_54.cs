using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part2
{
    class Character_53_54
    {
        private int health = 100;

        // для обеспечения безопасности и избежания неконтролируемого доступа к полям объекта
        // следует "оборачивать" их в свойства (гетеры, сетеры). В данном примере это будет
        // контролировать поле здоровье(health) и не позволять извне класса устанавливать
        // значение поля. 
        public int Health
        {
            get
            {
                return health;
            }
            private set
            {
                //value - невидимый входной аргумент свойства
                health = value;
            }
        }

        //с точки зрения компилятора, свойста - это просто 2 метода 
        //public int GetHealth()
        //{
        //    return health;
        //}
        //private void SetHealth(int value)
        //{
        //    health = value;
        //}

        public void Hit(int damage)
        {
            if (damage > health)
            {
                damage = health;
            }

            //health -= damage;
            //то же самое
            Health -= damage;
        }
    }
}
