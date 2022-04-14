using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part2
{
    public class Character
    //по умолчанию имеет модификатор internal
    //поэтому пока не доступен в другом namespace
    //класс может быть только либо internal, либо public
    {
        private static int speed = 10;

        public int PrintSpeed()
        {
            return speed;
        }

        public void IncreaseSpeed()
        {
            speed += 10;
        }

        public int Health = 100;

        public void Hit(int damage)
        {
            Health -= damage;
        }

        //по умолчанию члены класса (поля, методы и тд)
        //имеют модификатор private

        /* Уровни доступа:
         * public - можем получить доступ к членам везде, даже в другом namespace (сборке)
         *      для того, что бы получить доступ к классам из другого namespace, то следует 
         *      в зависимостях namespace-реципиента добавить ссылку на проект-донор(поставить галочку)
         *      и у класса поставить другой модификатор доступа
         *      !нельзя ссылаться на namespace, если у них разные целевые рабочие среды (.NET 5 у одного,
         *      а у второго .NET 3.1)
         * 
         * internal - как public, но доступ из другой namespace недоступен
         * protected - член класса доступен только внутри класса и в его наследниках
         * private - член класса доступен только внутри класса 
         */
    }
}
