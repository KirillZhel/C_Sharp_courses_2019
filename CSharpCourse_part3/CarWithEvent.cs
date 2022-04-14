using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part3
{
    public class CarArgs : EventArgs
    {
        public CarArgs(int currentSpeed)
        {
            CurrentSpeed = currentSpeed;
        }

        public int CurrentSpeed { get; }
    }


    internal class CarWithEvent
    {
        int speed = 0;

        //public event Action<object, int> TooFastDriving;
        /*
         * public event EventHandler<int> TooFastDriving;
         */
        //EventHandler<int> аналогичен Action<object, int>
        //и помимо параметра типа int имеет уже готовый 
        //параметр типа object для передачи ссылки на текущий
        //объект класса, который был подписан на событие

        //в идеале надо создавать отдельный класс со списком аргументов и передавать его
        //это обеспечивает защищённость
        public event EventHandler<CarArgs> TooFastDriving;

        public void Start()
        {
            speed = 10;
        }

        public void Accelerate()
        {
            speed += 10;

            if (speed > 80)
            {
                if (TooFastDriving != null)
                {
                    //соответственно так же изменяется и сигнатура вызова метода
                    TooFastDriving(this, new CarArgs(speed));
                    //TooFastDriving(this, speed);
                }
            }
        }

        public void Stop()
        {
            speed = 0;
        }
    }
}
