using System;

namespace CSharpCourse_11
{
    class Program
    {
        static void Main(string[] args)
        {
            //проба пера в github
            //вторая отправка для теста
        }

        static void Variables_lesson_10()
        {
            int x = -1;

            int y; //по умолчанию равно 0
            y = 2;

            Int32 x1 = -1; //то же самое что int...

            //uint z = -1; //будет ошибка так как тип uint является только положительным

            float f = 1.1f; //обязательно писать в конце букву "f" у числа, так это тип float

            double d = 2.3; //а вот здесь не надо ничего после числа, так как по умолчанию всё есть

            int x2 = 0;
            int x3 = new int(); //то же самое что и int x2 = 0 
            //new - оператор для создания экземпляров типов
            //скобочки после int обязательны - это вызов конструктора

            var a = 1; //заводим переменную без указания типа
            //компилятор сам выводит для переменной a его тип при компиляции
            // по умолчанию будет тип int, можно наводить мышкой и проверить

            var b = 1.2; //это уже double

            //var следует использовать когда имя типа длинное вроде:
            //Dictionary<int, string> dict = new Dictionary<int, string>();
            //var dict = new Dictionary<int, string>(); // гораздо короче

            //var v; //просто так нельзя НЕ присваивать переменой какое либо значение

            decimal money = 3.0m; //так же как у типа float, нужно после числа писать буковку m

            char character = 'A';
            char @char = 'B'; //собаку перед именем переменной в тех случаях 
            //когда имя переменной совпадает с именем типа по правилам именования
            string name = "John";
            string name1 = ""; //в переменную типа string можно поместить пустую строчку

            bool canDrive = true;
            bool canDraw = false;

            object obj1 = 1;
            object obj2 = "obj2";
            //тип object используется крайне редко

            Console.WriteLine(1);
            //вбить cw, после чего дважды нажать tab
            Console.WriteLine(a);
            Console.WriteLine(name);
        }

        static void Literals_lesson_11()
        {
            int x = 0b11; //запись числа в двоичном коде, впереди обязательно ставить 0b
            int y = 0b1001;
            int k = 0b10001001;
            int m = 0b1000_1001; //можно разделять на блоки

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(k);
            Console.WriteLine(m);

            x = 0x1F; //для 16-ричного впереди 0x
            y = 0xFF0D;
            k = 0x1FAB30EF;
            m = 0x1FAB_30EF;

            Console.WriteLine(); //просто для отделения строчек

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(k);
            Console.WriteLine(m);

            Console.WriteLine();

            Console.WriteLine(4.5e2); // то же самое что 4.5 * 10^2
            Console.WriteLine(3.1e-1); // то же самое что 3.1 * 10^(-1)

            Console.WriteLine();

            Console.WriteLine('\x78'); //символ из ASCII таблицы  
            Console.WriteLine('\x5A'); //перед вводом кода символа в 16-ричной системе вставить \x

            Console.WriteLine('\u0420'); //символ из UNICODE
            Console.WriteLine('\u0421'); //в начале \u
        }

        static void VariablesScoup()
        {
            var a = 1;
            {
                var b = 2;
                {
                    var c = 3;

                    Console.WriteLine(a);
                    Console.WriteLine(b);
                    Console.WriteLine(c);
                }

                Console.WriteLine(a);
                Console.WriteLine(b);
                //Console.WriteLine(c); //компилятор не видит переменную c
                //так как она во внутренней области видимости
            }

            Console.WriteLine(a);
            //Console.WriteLine(b);
            //Console.WriteLine(c);
        }

        static void OverFlow()
        {
            checked //ключевое слово, которое при переполнении будет выдавать ошибку
                    //так же можно включить в свойствах проекта автоматическую проверку, и тогда блок checked бужет не нужен
                    //но этого лучше не делать
            {
                uint x = uint.MaxValue; //присваиваем x максимальное значение для типа uint

                Console.WriteLine(x);

                x = x + 1; // получим 0, результат переполнения

                Console.WriteLine(x);

                x = x - 1; //получим опять максимальное значение

                Console.WriteLine(x);
            }
        }
    }
}
