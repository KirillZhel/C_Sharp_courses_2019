using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part3
{
    internal class CarListDelegat
    {
        int speed = 0;

        /*
        public delegate void TooFast(int currentSpeed);
        */

        //важно что поле tooFast имеет параметр доступа private
        //что бы никто не смог перезаписать список делегатов

        /*
        private TooFast tooFast;
        */

        //Для упрощения, что бы не надо было объявлять
        //public delegate void TooFast(int currentSpeed);
        //private TooFast tooFast;
        //методы:
        //public void RegisterOnTooFast(TooFast tooFast)
        //public void UnregisterOnTooFast(TooFast tooFast)
        //придуманы event


        /*
         * в библиотеках есть куча уже готовых делегатов
         * и собственные делегаты можно не объявлять
         * а вызвать уже готовый
         * 
         * public delegate void TooFast(int currentSpeed);
         * 
         * public event TooFast TooFastDriving;
        */

        
        public event Action<int> TooFastDriving;
        // int в <> - это тоже самое что параметр int currentSpeed у TooFast(int currentSpeed)
        // есть делегат Func<> который принимает параметры и имеет выходной параметр


        /*
         * для делегата Action доступны перезагрузки до 16 параметров
         *  
         * public event Action<int, int, int> LALA;
         */
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
                    TooFastDriving(speed);
                    //важно проверить на null, а то будет exception
                    //обычный делегат не будет вызывать exception
                }
                //tooFast(speed);
            }
        }

        public void Stop()
        {
            speed = 0;
        }

        /*
         * не нужны при использовании event
         * 
        public void RegisterOnTooFast(TooFast tooFast)
        {
            //+= позволяет добавить несколько методов в делегат tooFast
            //список методов будет вызываться поочереди
            this.tooFast += tooFast;
        }

        //метод, который позволяет отсоединять методы от делегата
        public void UnregisterOnTooFast(TooFast tooFast)
        {
            this.tooFast -= tooFast;
        }
        */
    }
}
