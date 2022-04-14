using System;
using System.Collections.Generic;

namespace CSharpCourse_part2
{
    class Program
    {
        static void Main(string[] args)
        {
            //lesson_51_52();
            //lesson_53_54();
            //lesson_56();
            //lesson_58();
            //lesson_60();
            //lesson_61_staticKeyWord();
            //lesson_62_OptionalParametrs();
            //lesson_63_Structure();
            //lesson_65_StructWithRefType();
            //lesson_66_CopySemantic();
            //lesson_67_NullRef();
            //lesson_68_TypeObject();
            //lesson_69_Constructor();
            //lesson_70_ReadOnly_Const();
            //lesson_71_PolymorphismAndInheritance();
            //lesson_72_AbstractMethod();
            //lesson_74_Interfaces();
            //lesson_75_ExtensionMethods();
            //lesson_76_EvilInheritance();
            //lesson_77_Enum();
            //lesson_78_MyStack();
            //lesson_79_MyStackWithGeneric();
            //lesson_80_IEnumerable();
            //lesson_81_YieldKeyWord();
            lesson_82_MemoryManagement();
        }

        static void lesson_51_52()
        {
            Character c = new Character();

            c.Hit(10);
            Console.WriteLine(c.Health);
        }

        static void lesson_53_54()
        {
            Character_53_54 c = new Character_53_54();

            c.Hit(120);
            //Console.WriteLine(c.Health) - "читает" свойство
            //c.Health = -20 - "устанавливает" значение свойства поля (сейчас нет доступа)
            Console.WriteLine(c.Health);
        }

        static void lesson_55()
        {
            Character_55 c = new Character_55();

            c.Hit(20);
            Console.WriteLine(c.Health);
        }

        static void lesson_56()
        {
            Calculator calc =new Calculator();

            Console.WriteLine(calc.CalcTriangleSquare(3, 4, 5));
            Console.WriteLine(calc.CalcTriangleSquare(3, 4));
        }

        static void lesson_58()
        {
            Calculator calc = new Calculator();
            double avg = calc.Average(new int[] { 1, 2, 3, 4 });
            Console.WriteLine(avg);
            calc.Average2(1, 2, 3, 4);
        }

        static void lesson_59()
        {
            // если не понятно, что передаётся в метод, то следует их именовать при вызове
            Calculator.CalcTriangleSquare(ab: 9, ac: 16, alpha: 90, isInRadians: true);
            // так же это позволяет передавать аргументы не в том порядке, в котором изначально задано в методе
            // но тогда следует именовать все аршументы
            Calculator.CalcTriangleSquare(alpha: 90, ab: 9, ac: 16, isInRadians: true);
        }

        static void lesson_60()
        {
            //если таким образом обрабатывать введёные аргументы, то могут возникнуть проблемы
            //например если пользователь ввёл не число
            //Console.WriteLine("Enter a number, please.");
            //int number = int.Parse(Console.ReadLine());
            //Console.WriteLine(number);

            Console.WriteLine("Enter a number, please.");

            string line = Console.ReadLine();

            //модификатор out позволяет в качестве аргумента передавать переменную,
            //в которую будет записан некоторый результат
            //
            //в данном случае сам метод возвращает true - если успешно парсит некоторый аргумент
            //и после чего результат парсинга записывает в ту самую выходную переменную с out
            //а при неуспешности, возвращает false

            //int result;
            //bool wasParsed = int.TryParse(line, out result);
            
            //вообще не обязательно декларировать переменную в отдельной строчке
            bool wasParsed = int.TryParse(line, out int result);

            if (wasParsed)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Failed to parse");
            }

            Calculator calc = new Calculator();
            if (calc.TryDivide(10, 0, out double res))
            {
                Console.WriteLine(res);
            }
            else
            {
                Console.WriteLine("Failed to divide");
            }
        }

        static void lesson_61_staticKeyWord()
        {
            // так как все методы в классе StaticCalc статические, то
            // не нужно создавать экземпляр класса
            double result = StaticCalc.Average2(1, 2, 3);
            Console.WriteLine(result);
            // так же статическими помимо методов могут быть свойства, поля, классы
            // нельзя создавать экземпляр статического класса
            // класс стоит делать статическим только тогда, когда все его члены статические
            // статические поля/свойства "распространяются" между всеми его членами

            // в классе Character объявлено статическое поле speed
            Character c1 = new Character();
            Character c2 = new Character();

            Console.WriteLine($"c1.speed = {c1.PrintSpeed()}.\nc2.speed = {c2.PrintSpeed()}.");
            c1.IncreaseSpeed();
            Console.WriteLine($"c1.speed = {c1.PrintSpeed()}.\nc2.speed = {c2.PrintSpeed()}.");
        }

        static void lesson_62_OptionalParametrs()
        {
            // параметру метода можно присвоить значение по умолчанию, тогда пользователь может его не передавать
            // параметры с значением по умолчанию должны быть в конце параметров

            StaticCalc.CalcTriangleSquare(10, 20, 30);
            StaticCalc.CalcTriangleSquare(10, 20, 2, true);
        }

        static void lesson_63_Structure()
        {
            PointVal a; //тоже самое, что PointVal a = new PointVal();
            a.X = 3;
            a.Y = 5;

            PointVal b = a;
            //b.X = 7;
            b.Y = 10;

            a.LogValues();
            b.LogValues();
            Console.WriteLine("After structs");

            PointRef c = new PointRef();
            c.X = 3;
            c.Y = 5;

            PointRef d = c;

            d.X = 7;
            d.Y = 10;

            c.LogValues();
            d.LogValues();
            Console.WriteLine(d.ToString());

        }

        private static void lesson_65_StructWithRefType()
        {
            EvilStruct es1 = new EvilStruct();
            es1.pointRef = new PointRef() { X = 1, Y = 2 }; //так можно инициализировать не только поля, но и свойства
            //та же самая инициализация полей экземпляра es1.pointRef
            //es1.pointRef.X = 1;
            //es1.pointRef.Y = 2;

            EvilStruct es2 = es1;
            
            Console.WriteLine($"es1.pointRef.X = {es1.pointRef.X}, es1.pointRef.Y = {es1.pointRef.Y}");
            Console.WriteLine($"es2.pointRef.X = {es2.pointRef.X}, es2.pointRef.Y = {es2.pointRef.Y}");

            es2.pointRef.X = 42;
            es2.pointRef.Y = 43;

            Console.WriteLine($"es1.pointRef.X = {es1.pointRef.X}, es1.pointRef.Y = {es1.pointRef.Y}");
            Console.WriteLine($"es2.pointRef.X = {es2.pointRef.X}, es2.pointRef.Y = {es2.pointRef.Y}");

            //если в структуре есть ссылочный тип, то при коппировании структур
            //копируется именно ссылка на этот ссылочный тип в структуре
            //из за чего две структуры будут ссылаться на один и тот же экземпляр
            //у es1 и es2 одинаковые ССЫЛКИ на экземпляр класса PointRef
            //поэтому при изменении параметров pointRef в es2 изменяются параметры
            // pointRef в es1. Это один и тот же экземпляр pointRef
        }

        private static void lesson_66_CopySemantic()
        {
            List<int> list = new List<int>();
            //аргумент list - это ссылка на list в куче
            //благодаря чему это позволяет применять методы вроде AddNumbers
            //без "выходных" данных (с ключевым словом out например)
            AddNumbers(list);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            int a = 1;
            int b = 2;
            Swap(a, b);
            //a и b - это не ссылки, это сами значения
            //поэтому в вызываемом методе копируются не ссылки на a и b
            //а сами значения и никаким образом это не влияет на внешние a и b
            Console.WriteLine($"a = {a}, b = {b}");
            //это возможно "исправить" блягодаря блягодаря ключевому слову ref\
            //в самом методе и при вызове его
            SwapRef(ref a, ref b);
            Console.WriteLine($"a = {a}, b = {b}");
            //редкий функционал, так как обычно работают с сылочными типами вроде классов
        }

        static void AddNumbers(List<int> numbers)
        {
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
        }

        static void Swap(int a, int b)
        {
            Console.WriteLine($"Original a = {a}, b = {b}");

            int tmp = a;
            a = b;
            b = tmp;

            Console.WriteLine($"Swapped a = {a}, b = {b}");
        }

        static void SwapRef(ref int a, ref int b)
        {
            Console.WriteLine($"Original a = {a}, b = {b}");

            int tmp = a;
            a = b;
            b = tmp;

            Console.WriteLine($"Swapped a = {a}, b = {b}");
        }

        private static void lesson_67_NullRef()
        {
            PointVal pv;
            //Console.WriteLine(pv.X);
            //по умолчанию у струкур выделяется кусок памяти для них и они никогда не null

            //можно присвоить null с помощью ?
            PointVal? pv2 = null;
            
            if (pv2.HasValue)
            {
                Console.WriteLine(pv2.Value.X);
                PointVal pv3 = pv2.Value;
                Console.WriteLine(pv3.X);
            }
            else
            {
                //
            }

            //иначе можно вот так без if(...HasValue)
            PointVal pv4 = pv2.GetValueOrDefault();
            //если pv4 не null то мы будем работать с обычным экземпляром структуры
            //если pv4 null, то будет создан экземпляр c параметрами по умолчанию
            //это удобно в случае работы с БД например

            PointRef c = null;
            //по умолчпнию(без вызова конструктора new...) ссылочные типы указывают на null
            Console.WriteLine(c.X); //NullReferenceException
        }

        private static void lesson_68_TypeObject()
        {
            int x = 1;
            object obj = x; //- boxing - значение инта(Value Type) переносится из стека в кучу(Reference Type)

            int y = (int)obj;// - unboxing - обратно из Reference Type в Value Type

            double pi = 3.14;
            object obj1 = pi;

            int number = (int)obj1; //InvalidCastException
            int number2 = (int)(double)obj1;
            Console.WriteLine(number);
            //проблема в том, что не знаем что могли запихнуть в object
            //что приводит к ошибкам            
        }

        static void Do(object obj)
        {
            bool isPointRef = obj is PointRef;//точно знаем что это PointRef или не он
            if (isPointRef)
            {
                PointRef pr = (PointRef)obj;
                Console.WriteLine(pr.X);
            }
            else
            {
                //do something
                //throw например
            }

            //чаще используется as
            PointRef pr1 = obj as PointRef;//если возможен unboxing(casting), то он происходит
            //иначе pr1 будет содержать null
            if (pr1 != null)
            {
                Console.WriteLine(pr1.X);
            }
            else
            {
                //чаще всего либо нет else
                //либо выкидывает исключение
            }
        }

        private static void lesson_69_Constructor()
        {
            //вызов конструктора с параметрами
            //значит класс защищён от создания экземпляров класса без параметров
            //конструкторы призваны защищать начальное состояние объектов
            Character_69 c = new Character_69("Elf");
            Console.WriteLine(c.Race);

            //в конструкторе структур надо либо оставлять его не явным (не объявлять его)
            //иначе при наличии явного конструктора надо объявлять ВСЕ поля
        }

        private static void lesson_70_ReadOnly_Const()
        {
            // вызов конструктора с параметрами, один из которых
            // объявлен с модификатором readonly
            Character_69 c = new Character_69("Ork", 15, 15);
            Console.WriteLine(c.Race);

            //в случае, если мы не хотим допуспить изменение поля с самодельными типами данных (класс, структура)
            //т.е. которые требуют использование = new CustomClass();, то следует использовать readonly
            //const нельзя использовать
        }

        private static void lesson_71_PolymorphismAndInheritance()
        {
            ModelXTerminal terminal = new ModelXTerminal("123");
            terminal.Connect();
            Console.WriteLine();

            ModelYTerminal terminal_Y = new ModelYTerminal("456");
            terminal_Y.Connect();
            terminal_Y.DisConnect();
            Console.WriteLine();
            
            //если я изначально задаю экземпляру класса тип родительского класса
            //но при этом выделяю память под дочерний
            //то я могу вызывыть методы только родительского класса
            //но при этом, если в дочернем есть перегруженный метод
            //то будет вызываться ЕГО реализация, а не реализация из родительского класса
            BankTerminal terminal_BaseY = new ModelYTerminal("678");
            terminal_BaseY.Connect();
            terminal_BaseY.DisCon();
            Console.WriteLine();

        }

        private static void lesson_72_AbstractMethod()
        {
            //нельзя создавать экземпляр абстрактного класса
            //Shape shape = new Shape();

            //здесь мы не создаём экземпляр Shape, а только массив для фигур
            Shape[] shapes = new Shape[2];
            shapes[0] = new Triangle(10, 20, 30);
            shapes[1] = new Rectangle(5, 10);

            foreach (Shape shape in shapes)
            {
                shape.Draw();
                Console.WriteLine(shape.Perimeter());
            }

            Triangle triangle = new Triangle(10, 20, 30);
            Rectangle rectangle = new Rectangle(10, 20);
            Shape shape1 = new Triangle(20, 30, 40);
            Console.WriteLine();
            Do(triangle);
        }

        static void Do(Shape shape)
        {
            //благодаяря полиморфизму, нам не надо создавать
            //много подпрограмм под каждый тип фигур
            shape.Draw();
        }

        private static void lesson_74_Interfaces()
        {
            IBaseCollection collection = new BaseList(4);
            collection.Add(1);

            ITestInterface1 test1 = new TestClass();
            test1.TestMethod();
            ITestInterface2 test2 = new TestClass();
            test2.TestMethod();
            TestClass test3 = new TestClass();
            //test3.TestMethod();
        }
        private static void lesson_75_ExtensionMethods()
        {
            List<object> list = new List<object>() { 1, 2, 3 };
            IBaseCollection collection = new BaseList(4);
            collection.Add(2);
            collection.AddRange(list);
            //в качестве параметров метода AddRange выступает список из object
            //далее будет реализовано stack и queue с использованием generic
        }

        private static void lesson_76_EvilInheritance()
        {
            Rect rect = new Rect { Height = 2, Width = 5 };
            int rectArea = AreaCalculater.CalcSquare(rect);
            
            Console.WriteLine($"Rect area = {rectArea}");
            
            Rect square = new Square { Height = 2, Width = 10 }; //создали экземпляр "квадрата" с разными сторонами
            int squareArea = AreaCalculater.CalcSquare(square); //получим неправильную площадь
            //проблема представителей(?)
            //не всегда можно нормально отобразить реальный мир на объектно-ориентированную парадигму
            Console.WriteLine($"Square area = {squareArea}");
            
            Console.WriteLine();

            //проблема решается за счёт создания интерфейса
            IShape shape = new Rect { Height = 2, Width = 5 };
            IShape square1 = new Square2 { SideLength = 10 };

            Console.WriteLine($"Shape area = {shape.CalcSquare()}");
            Console.WriteLine($"Square1 area = {square1.CalcSquare()}");
        }

        private static void lesson_77_Enum()
        {
            //Перечисления помогут защитить свойства объекта
            //например
            Character_69 character123 = new Character_69("123");
            Character_69 characterNull = new Character_69(null);
            //В таких случаях будет странно, что персонаж имеет расу 123
            //или вообще не иметь расу

            //правильнее было бы сделать так
            Character_77 characterEnum = new Character_77(Race.Elf);
            //перечисления позволяют так же серьёзно сократить код
            //заменив грамоздкие switch или if/elseif одной строкой
        }

        private static void lesson_78_MyStack()
        {

            MyStack ms = new MyStack();
            ms.Push(1);
            ms.Push(2);
            ms.Push(3);

            //Такая реализация стека через object позволяет добавлять в стек
            //всё что угодно, что может вызвать проблему, например, при суммирование
            //элементов стека

            /*
             * while(ms.Count != 0)
             * {
             *    Console.WriteLine((int)ms.Pop());
             * }
             */

            ms.Push("abra");
            ms.Push(false);
            ms.Push('a');
            ms.Push(0.3);

            Console.WriteLine(ms.Peek());
            ms.Pop();

            Console.WriteLine(ms.Peek());

            ms.Push(4);
            ms.Push(5);
            ms.Push(6);

            Console.WriteLine(ms.Peek());
        }

        private static void lesson_79_MyStackWithGeneric()
        {
            MyGenericStack<int> ms = new MyGenericStack<int>();
            //хотя всегда можно 
            // MyGenericStack<object> ms = new MyGenericStack<object>();
            //и отстрелить себе ногу
            ms.Push(1);
            ms.Push(2);
            ms.Push(3);
            
            //теперь компилятор не позволяет использовать типы данных вроде bool
            //string или double (char он спокойно переводит в int)
            //ms.Push("abra");
            //ms.Push(false);
            ms.Push('a');
            //ms.Push(0.3);

            //управление типом происходит при компиляции, а не в run-time(работе программы)
            //что позволяет заранее быть уверенным, что что-то пойдёт не так из за промаха
            //в типе данных

            Console.WriteLine(ms.Peek());
            ms.Pop();

            Console.WriteLine(ms.Peek());

            ms.Push(4);
            ms.Push(5);
            ms.Push(6);

            Console.WriteLine(ms.Peek());
        }

        private static void lesson_80_IEnumerable()
        {
            MyEnumerableStack<int> ms = new MyEnumerableStack<int>();

            ms.Push(1);
            ms.Push(2);
            ms.Push(3);
            ms.Push(4);
            ms.Push(5);
            ms.Push(6);

            //foreach в неявном виде использует методы MoveNext и тп
            foreach (var item in ms)
            {
                Console.WriteLine(item);
            }
        }

        private static void lesson_81_YieldKeyWord()
        {
            MyNewEnumerableStack<int> ms = new MyNewEnumerableStack<int>();

            ms.Push(1);
            ms.Push(2);
            ms.Push(3);
            ms.Push(4);
            ms.Push(5);
            ms.Push(6);

            //foreach в неявном виде использует методы MoveNext и тп
            foreach (var item in ms)
            {
                Console.WriteLine(item);
            }
        }

        private static void lesson_82_MemoryManagement()
        {
            /*
             * в 99% случаев мы реализуем интерфейс IDisposable
             * в таком случае нам надо просто реализовать метод Dispose()
             * 
             * public void Dispose()
             * {
             *     managedResource?.Dispose();
             * }
             * 
             * и когда нам не нужет объект, то мы вызываем этот метод, который
             * явно очищает оперативную память от него
             * этот метод используется при использовании управляемых ресурсов
             * 
             * ЗАМЕТКА: ключевой символ ? при компиляции порождает следующую конструкцию
             * 
             * if(managedResource != null)
             * {
             *     managedResource.Dispose();
             * }
             * 
             * при использовании объектов, которые используеют неуправляемые объекты
             * (вроде конекшена к БД), то следует реализовать метод финализатор и деструктор класса
             * 
             * !ВАЖНО!
             * Очень не рекомендуется совмещать в одном классе управляемые и неуправляемые ресурсы
             * что влечёт за собой усложнение кода
             * 
             * Интерфейс IDisposable реализуется только в том случае, когда в классе присутствует тип
             * который это требует(в нём присутствуют типы напрямую не управляемые, либо типы, которые 
             * являются "обёртками" таких типов (например managedResource)), большинство типов такими не являются
             */
        }
    }
}
