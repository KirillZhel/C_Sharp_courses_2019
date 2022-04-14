using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part2
{
    public class BankTerminal
    {
        protected string id; //изолирован от внешнего мира, но виден в наследниках

        public BankTerminal(string id)
        {
            this.id = id;
        }

        public virtual void Connect()
        {
            //virtual позволяет перегружать методы в наследниках
            Console.WriteLine("General Connecting Protocol...");
        }

        public void DisCon()
        {
            Console.WriteLine("Terminal is disconnected");
        }
    }

    public class ModelXTerminal : BankTerminal
    {
        public ModelXTerminal(string id) : base(id)
        {
            //base.id = id; - вместо этого можно просто реализацию конструктора наследовать
            //от конструктора класса-родителя
        }

        public override void Connect()
        {
            base.Connect(); //использует реализацию метода из класса-родителя
            Console.WriteLine("Additional actions for Model X");
        }
    }

    public class ModelYTerminal : BankTerminal
    {
        public ModelYTerminal(string id) : base(id)
        {
            //base.id = id; - вместо этого можно просто реализацию конструктора наследовать
            //от конструктора класса-родителя
        }

        public override void Connect()
        {
            //хотя мы не используем базовую реализацию метода Connect() класса-родителя
            //всё равно метод дочернего класса с таким именем должен быть override
            Console.WriteLine("Actions for Model Y");
        }

        public void DisConnect()
        {
            Console.WriteLine("Model Y is Disconnected");
        }
    }
}
