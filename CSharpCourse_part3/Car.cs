using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part3
{
    internal class Car
    {
        int speed = 0;
        //создаём делегат, который должен описывать некую сигнатуру
        public delegate void TooFast(int currentSpeed);

        //если бы в методе HandleOnTooFast() были параметры:
        //private static void HandleOnTooFast(int number)
        //то и делегат должен иметь такую же сигнатуру:
        //public delegate void TooFast(int number)
        //и соответственно при вызове должно быть например:
        //tooFast(80) 

        //инициализируем делегат
        //в эту переменную будет записан метод HandleOnTooFast
        private TooFast tooFast; //здесь хранится ссылка на метод

        public void Start()
        {
            speed = 10;
        }

        public void Accelerate()
        {
            speed += 10;

            if (speed > 80)
            {
                //вызов обработчика HandleOnTooFast() 
                tooFast(speed);
            }
        }

        public void Stop()
        {
            speed = 0;
        }
        //даём возможность верхнему уровню подписаться на событие
        //можно через конструктор, можно через метод(как ниже)
        public void RegisterOnTooFast(TooFast tooFast)
        {
            this.tooFast = tooFast;
        }
    }
}
