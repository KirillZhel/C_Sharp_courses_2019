using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part2
{
    class Character_55
    {
        // в случае когда свойство у нас просто устанавливает и показывает значение поля
        // его можно преобразовать в авто-свойство
        //
        //private int health = 100;
        //
        //public int Health
        //{
        //    get
        //    {
        //        return health;
        //    }
        //    private set
        //    {
        //        health = value;
        //    }
        //}

        public int Health { get; private set; } = 100;

        public void Hit(int damage)
        {
            if (damage > Health)
            {
                damage = Health;
            }

            Health -= damage;
        }
    }
}
