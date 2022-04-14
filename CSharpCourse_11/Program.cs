using CSharpCourse_part2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CSharpCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            //пример для урока 52
            Character c = new Character();

            c.Hit(20);
            Console.WriteLine(c.Health);

            //JaggedArray_lesson_48();
            //lesson_43();
            //BreakContinuelesson_36();
            //Console.Read();
            
        }

        static void lesson_49()
        {
                                                //тип массива(System.Int32)
                                                //            количество элементов(4)
                                                //                         индекс первого элемента(1)
            Array myArray = Array.CreateInstance(typeof(int), new[] { 4 }, new[] { 1 });
            //массивы с "нестандартной" индексацией не с нуля работают гораздо медленее

            myArray.SetValue(2019, 1); //установка значения(2019) в элемент с индексом 1
            myArray.SetValue(2020, 2); //установка значения(2020) в элемент с индексом 2
            myArray.SetValue(2021, 3); //установка значения(2021) в элемент с индексом 3
            myArray.SetValue(2022, 4); //установка значения(2022) в элемент с индексом 4(в обычном массиве это вызвало бы исключение)

            Console.WriteLine($"Starting index: {myArray.GetLowerBound(0)}");
            Console.WriteLine($"Endin index: {myArray.GetUpperBound(0)}");

            for (int i = myArray.GetLowerBound(0); i <= myArray.GetUpperBound(0); i++)
            {
                Console.WriteLine($"{myArray.GetValue(i)} at index {i}");
            }

            Console.WriteLine();
            //то же самое, что и цикл выше
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine($"{myArray.GetValue(i)} at index {i}");
            }
        }

        static void JaggedArray_lesson_48()
        {
            int[][] jaggedArray = new int[4][];
            jaggedArray[0] = new int[1];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[2];
            jaggedArray[3] = new int[4];

            Console.WriteLine("Enter the number for a jagged array");

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    string st = Console.ReadLine();
                    jaggedArray[i][j] = int.Parse(st);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Printing the Elements");

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void MultiDimArray_lesson_47()
        {
            // 1 2 3 4

            // 1 2 3
            // 4 5 6
            // 7 8 9

            int[,] r1 = new int[2, 3] { { 1,2,3},
                                        { 4,5,6 } }; //2 строчки и 3 столбца
            int[,] r2 = { { 1,2,3},
                          { 4,5,6 } };

            //метод GetLength - в качестве параметра требует измерение массива
            for (int i = 0; i < r2.GetLength(0); i++)
            {
                for (int j = 0; j < r2.GetLength(1); j++)
                {
                    Console.WriteLine($"{r2[i,j]}");
                }
            }

            
        }

        static void StackQueue_lesson_46()
        {
            //Stack:
            //LIFO
            //Push - add item to the top
            //Pop - remove the top item
            //Peek - get the top item without removing

            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Console.WriteLine($"Should print out 4: {stack.Peek()}");

            stack.Pop();//не только удаляет элемент но и возвращает его в себе

            Console.WriteLine($"Should print out 3: {stack.Peek()}");

            Console.WriteLine("iterate over the stack.");
            foreach (var cur in stack)
            {
                Console.WriteLine(cur);
            }

            //Queue:
            //FIFO
            //Enqueue - add an item to the end of the queue
            //Dequeue - remove an item at the from of the queue
            //Peek - get item at the front of the queue without removing

            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Console.WriteLine($"Should print out 1: {queue.Peek()}");

            queue.Dequeue();//не просто удаляет, но и возвращает его в себе

            Console.WriteLine($"Should print out 2: {queue.Peek()}");

            foreach (var cur in queue)
            {
                Console.WriteLine(cur);
            }
        }

        static void Dictionary_lesson_45()
        {
            var people = new Dictionary<int, string>();//тип ключа, значение
            //поиск значения по ключу очень быстро работает
            //но поиск по значению работает медленнее (как поиск по массиву)

            people.Add(1, "John");
            people.Add(2, "Bob");
            people.Add(3, "Alice");
            //НЕЛЬЗЯ добавлять элементы в словарь с одинаковыми КЛЮЧАМИ


            people = new Dictionary<int, string>()
            {
                {1,"John" },
                {2,"Bob" },
                {3,"Alice" }
            };

            if (people.TryAdd(2, "Elias")) //true - не нашёл элемент с таким ключом и добавил
                                           //false - нашёл элемент с таким ключом и не добавил 
            {
                Console.WriteLine("элемент с таким ключом добавлен");
            }
            else
            {
                Console.WriteLine("элемент с таким ключом уже существует");
            }

            if (people.TryGetValue(2, out string val)) //если находит какое то значение по ключу 2,
                                                       //то возвращает true и записывает это значение в переменную val
            {
                Console.WriteLine($"Key 2, Val = {val}");
            }
            else
            {
                Console.WriteLine("Failed to get");
            }

            string name = people[1]; //это НЕ индекс, это КЛЮЧ
            Console.WriteLine(name);

            Console.WriteLine("iterting over keys");
            var keys = people.Keys;
            Dictionary<int, string>.KeyCollection keys2 = people.Keys; // то же самое

            foreach (var item in keys)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("iterating over values");
            Dictionary<int, string>.ValueCollection values = people.Values;
            foreach (var item in values)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("iterating over key-value pairs");
            foreach (KeyValuePair<int, string> pair in people)
            {
                Console.WriteLine($" Key: {pair.Key}. Value: {pair.Value}");
            }
            Console.WriteLine();

            Console.WriteLine($"Count = {people.Count}");

            bool containsKey = people.ContainsKey(2); //поис по КЛЮЧУ
            bool containsValue = people.ContainsValue("John"); //поис по ЗНАЧЕНИЮ

            people.Remove(1); //удаляет элемент по ключу и возвращает в себе true(нашёл и удалил) или false(не нашёл и не удалил)

            people.Clear(); //"очистка" словаря

        }

        static void List_lesson_44()
        {
            var intList = new List<int> { 1, 4, 2, 7, 5, 9, 12 };
            // List по сути своей массив определённой длинны и при исчерпании места
            // он создаёт новый массив в два раза больше и перекидывает туда элементы

            intList.Add(7); //добавление в список элемента со значением 7

            int[] intArray = { 1, 2, 3 };

            intList.AddRange(intArray); //добавление сразу всех эллементов в список из массива intArray

            if (intList.Remove(1)) //удаляет первое встреченное вхождение значения 1 и в себе возвращает true(нашёл и удалил) либо false(обратная ситуация)
            {
                //do something
            }
            else
            {

            }

            intList.RemoveAt(0); //удалить элемент по индексу 0

            intList.Reverse(); //"переворачивает" список

            bool contains = intList.Contains(3); //содержит ли элемент 3

            int min = intList.Min();
            int max = intList.Max();

            Console.WriteLine($"Min = {min}, Max = {max}");

            int indexOf = intList.IndexOf(2); //индекс первой встречи 2
            int lastIndexOf = intList.LastIndexOf(2); //индекс последней встречи 2

            for (int i = 0; i < intList.Count; i++)
            {
                Console.WriteLine($"{intList[i]} ");
            }

            Console.WriteLine();

            foreach (var item in intList)
            {
                Console.WriteLine($"{item} ");
            }
        }

        static void ArrayType_lesson_43()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int index = Array.BinarySearch(numbers, 7); //бинарный поиск в УПОРЯДОЧЕННОМ массиве
            //берёт число по середине массива, если оно меньше искомого, то берёт всё что дальше
            //если больше, то берёт всё что до. И так шаг за шагом отсекает по половине,
            //пока не найдёт искомый элемент и не выдаст индекс этого элемента
            //РАБОТАЕТ БЫСТРО, ЧТО ПОЛЕЗНО

            int[] copy = new int[10];
            Array.Copy(numbers, copy, numbers.Length);//откуда копировать, куда копировать, сколько копировать

            int[] anotherCopy = new int[10];
            copy.CopyTo(anotherCopy, 0); //копирование из copy в anotherCopy начиная с позиции 0

            Array.Reverse(copy); //"разворачивает" массив

            Array.Sort(copy);//сортировка по возрастанию

            Array.Clear(copy, 0, copy.Length);//"очистка" (приравнивание элементов массива нулю)

            int[] a1;
            a1 = new int[10];

            int[] a2 = new int[5];

            int[] a3 = new int[5] { 1, 3, -2, 5, 10 };

            int[] a4 = { 1, 3, 2, 4, 5 };

            Array myArray = new int[5]; //все массивы по сути своей являются объектом класса Array

            Array myArray2 = Array.CreateInstance(typeof(int), 5); //то же самое, что и в строке выше

            myArray2.SetValue(12, 0); //установка значения 12 по индексу 0

            Console.WriteLine(myArray2.GetValue(0)); //вывод значения myArray2[0], так как просто написать "myArray2[0]" нельзя, нет индексированного доступа
        }

        static void Debugging_lesson_38()
        {
            /*
             * F9 - установка точки останова в текущей строке
             * F10 - шаг в отладке с обходом
             * F11 - шаг в отладке с заходом
             * F5 - перемещение по точкам останова
             */
            Console.WriteLine("Enter the length of side AB:");
            double ab = GetDouble();

            Console.WriteLine("Enter the length of side BC:");
            double bc = GetDouble();

            Console.Write("Enter the length of side CA:");
            double ca = GetDouble();

            //предположим сделали ошибку в формуле полупериметра
            double p = (ab + bc + ca) / 2;

            double square = Math.Sqrt(p * (p - ab) * (p - bc) * (p - ca));

            Console.WriteLine($"Square of the triangle equals {square}");
        }

        static double GetDouble()
        {
            return double.Parse(Console.ReadLine());
        }

        static void SwitchCase_lesson_37()
        {
            int month = int.Parse(Console.ReadLine());
            string season = string.Empty;

            switch (month)
            {
                case 1:
                case 2:
                case 12:
                    season = "winter";
                    break;
                case 3:
                case 4:
                case 5:
                    season = "spring";
                    break;
                case 6:
                case 7:
                case 8:
                    season = "summer";
                    break;
                case 9:
                case 10:
                case 11:
                    season = "autumn";
                    break;
                default:
                    throw new ArgumentException("unexpected number of month");
            }

            Console.WriteLine(season);

            int weddingYears = int.Parse(Console.ReadLine());

            string name = string.Empty;

            switch (weddingYears)
            {
                case 5:
                    name = "деревянная свадьба";
                    break;
                case 10:
                    name = "оловянная свадьба";
                    break;
                case 15:
                    name = "хрустальная свадьба";
                    break;
                case 20:
                    name = "фарфоровая свадьба";
                    break;
                case 25:
                    name = "серебрянная свадьба";
                    break;
                case 30:
                    name = "Жемчужная свадьба";
                    break;
                default:
                    name = "не юбилей или не знаем";
                    break;
            }

            Console.WriteLine(name);
        }

        static void BreakContinuelesson_36()
        {

            int[] num = { 0, 3, 2, 1, 5, 4, 6, 7, 8, 9 };
            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };

            foreach (int item in num)
            {
                if (item % 2 != 0)
                {
                    continue;
                }
                Console.WriteLine(item);
            }

            for (int i = 0; i < num.Length; i++)
            {
                Console.WriteLine($"Number = {num[i]}");

                for (int j = 0; j < letters.Length; j++)
                {
                    if (num[i] == j)
                    {
                        break;
                    }
                    Console.Write($" {letters[j]} ");
                }
                Console.WriteLine();
            }

            int[] numbers = { 1, -2, 4, -7, 5, 3, 2, -1, -3, 2, 7, -1, -3, 1, 7 };

            int counter = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (counter == 3)
                {
                    break;
                }

                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int atI = numbers[i];
                    int atJ = numbers[j];
                    if (atI + atJ == 0)
                    {
                        Console.WriteLine($"Pair ({atI};{atJ}). Indexes ({i};{j})");
                        counter++;
                    }

                    if (counter == 3)
                    {
                        break;
                    }
                }
            }
        }

        static void WhileDoWhile_lesson_35()
        {
            int age = 0;

            while (age < 18)
            {
                Console.WriteLine("First while loop");
                Console.WriteLine("What is your age?");
                age = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Good!");

            do
            {
                Console.WriteLine("Do\\While");
                Console.WriteLine("What is your age?");
                age = int.Parse(Console.ReadLine());
            }
            while (age < 18);

            int[] numbers = { 1, 2, 3, 4, 5 };
            int i = 0;

            while (i < numbers.Length)
            {
                Console.WriteLine(numbers[i] + " ");
                i++;
            }
        }

        static void NestedFor_lesson_34()
        {
            int[] numbers = { 1, -2, 4, -7, 5, 3, 2, -1, -3, 2, 7, -1, -3, 1, 7 };

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int atI = numbers[i];
                    int atJ = numbers[j];
                    if (atI + atJ == 0)
                    {
                        Console.WriteLine($"Pair ({atI};{atJ}). Indexes ({i};{j})");
                    }
                }
            }


            for (int i = 0; i < numbers.Length - 2; i++)
            {
                for (int j = i + 1; j < numbers.Length - 1; j++)
                {
                    for (int k = j + 1; k < numbers.Length; k++)
                    {
                        int atI = numbers[i];
                        int atJ = numbers[j];
                        int atK = numbers[k];

                        if (atI + atJ + atK == 0)
                        {
                            Console.WriteLine($"Triplets ({atI};{atJ};{atK}). Indexes ({i};{j};{k})");
                        }
                    }
                }
            }
        }

        static void ForForeach_lesson_33()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Console.Write(numbers[i] + " ");
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    Console.Write(numbers[i] + " ");
                }
            }

            foreach (int item in numbers)
            {
                Console.WriteLine(item + " ");
            }


        }

        static void ifElse_lesson_31()
        {
            double bmi = 24.5;

            bool isNormal = (bmi >= 18.5) && (bmi < 25);

            if (isNormal)
            {
                Console.WriteLine("You are fat");
            }
            else
            {
                Console.WriteLine("anyway, you are fat");
            }

            if (true)
            {

            }
            else if (true)
            {

            }
            else
            {

            }

            int age = 19;
            //тернарный оператор
            string description = age >= 18 ? "yaa" : "oh, no";
        }

        static void DateTime_lesson_27()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine(now.ToString());

            Console.WriteLine($"It's {now.Date}, {now.Hour}:{now.Minute}");

            DateTime dt = new DateTime(2016, 2, 28);
            Console.WriteLine(dt);

            DateTime newDt = dt.AddDays(1);
            Console.WriteLine(newDt);

            TimeSpan ts = now - dt;
            ts = now.Subtract(dt); //тоже самое
            Console.WriteLine(ts.Days);
        }

        static void Array_lesson_26()
        {
            int[] a1;
            a1 = new int[10];

            int[] a2 = new int[5];

            int[] a3 = new int[5] { 1, 3, -2, 5, 10 };

            int[] a4 = { 1, 3, 2, 4, 5 };

            Console.WriteLine(a4[0]); // 1
            int number = a4[4];
            Console.WriteLine(number);

            a4[4] = 6;
            Console.WriteLine(a4[4]);

            Console.WriteLine(a4.Length);
            Console.WriteLine(a4[a4.Length - 1]);

            string s1 = "abcdefgh";
            char first = s1[0];
            char last = s1[s1.Length - 1];
            Console.WriteLine(first);
            Console.WriteLine(last);

            //s1[0] = 'z'; невозможно
        }

        static void Math_lesson_25()
        {
            double e = Math.E;
            double pi = Math.PI;

            Console.WriteLine(Math.Pow(2, 3)); // 8
            Console.WriteLine(Math.Sqrt(9)); // 3

            Console.WriteLine(Math.Round(1.7)); // 2
            Console.WriteLine(Math.Round(1.4)); // 1
            Console.WriteLine(Math.Round(1.5)); // 2


            Console.WriteLine(Math.Round(2.5)); // 2
            Console.WriteLine(Math.Round(2.5, MidpointRounding.AwayFromZero)); // 3
            Console.WriteLine(Math.Round(2.5, MidpointRounding.ToEven)); // 2
        }

        static void Comments_lesson_24()
        {
            //a single-line comment

            /*
             * 
             * multi-line cooment
             * line
             * line
             * line
             * 
             */

            //describe hows and whys, but not describe what hapening

            int a = 1;

            // increment a by 1 - bad comment, this code is self-evident

            // we need to tweak the index to match the expected outcome
            a++;
        }

        static void CastingAndPArsing_lesson_23()
        {
            byte b = 3; //0000_0011
            int i = b; //0000_0000_0000_0000_0000_0000_0000_0011
            long l = i; //0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0000_0011

            float f = i; //3.0

            Console.WriteLine(f);
            //b = i; компилятор не даст так сделать 
            b = (byte)i;//нужно явно указать тип, к которому приводим
            Console.WriteLine(b);

            i = (int)f;
            Console.WriteLine(i);

            i = int.MaxValue;
            Console.WriteLine(i);
            b = (byte)i;
            Console.WriteLine(b);

            f = 3.1f;
            i = (int)f;
            Console.WriteLine(i);

            string str = "1";
            i = int.Parse(str);
            Console.WriteLine(i);

            int x = 5;
            int result = x / 2;
            Console.WriteLine(result); // 2
            double result2 = x / 2; //2
            result2 = (double)x / 2; //2.5
        }

        static void ConsoleVassics_lesson_22()
        {
            Console.WriteLine("Hi, please tell me your name");

            string name = Console.ReadLine();
            Console.WriteLine($"Your name is {name}");


            Console.WriteLine("Hi, please tell me your age");
            string input = Console.ReadLine();
            int age = int.Parse(input);

            string sentence = $"Your age is {age}";
            Console.WriteLine(sentence); ;

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.Write("New Style ");
            Console.Write("New Style\n");
        }

        static void ComparingString_lesson_21()
        {
            string str1 = "abcde";
            string str2 = "abcde";

            bool areEqual = str1 == str2;

            Console.WriteLine(areEqual);//true

            areEqual = string.Equals(str1, str2, StringComparison.Ordinal);
            // то же самое, что и ==

            string s1 = "Strasse";
            string s2 = "Straße";

            areEqual = string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase);
            //сравнивает не смотря на большие или маленькие буквы
            areEqual = string.Equals(s1, s2, StringComparison.Ordinal);
            //сравнивает байтовую репрезентацию символов
            Console.WriteLine(areEqual);
            areEqual = string.Equals(s1, s2, StringComparison.InvariantCulture);
            //сравнивает с учётом лигвинстических правил и символ ß -> ss 
            Console.WriteLine(areEqual);
            areEqual = string.Equals(s1, s2, StringComparison.CurrentCulture);
            //сравнивает с учётом лигвинстических правил и символ ß -> ss
            //но повезло, так как ориентируется на культурные настройки компа
            Console.WriteLine(areEqual);

        }

        static void StringFormat_lesson_20()
        {
            string name = "John";
            int age = 30;
            string str1 = string.Format("My name is {0} and I'm {1}", name, age);
            string str3 = $"My name is {name} and I'm {age}";
            //string str2 = "My name is " + name + "and I'm" + age;

            string str4 = "My name is \nJohn";
            string str5 = "I'm \t30";

            str4 = $"My name is {Environment.NewLine} John";
            //если приложение кроссплатформенное, то лучше использовать
            //Environment.NewLine

            string str6 = "I'm John and I'm \"good\" programmer";
            string str7 = "C:\\tmp\\test_file.txt";
            string str8 = @"C:\tmp\test_file.txt";

            int answer = 42;
            string result1 = string.Format("{0:d}", answer);
            string result2 = string.Format("{0:d4}", answer);

            Console.WriteLine(str1);
            Console.WriteLine(result1);
            Console.WriteLine(result2);
            double answer42 = 42.08;

            result1 = string.Format("{0:f}", answer42);
            result2 = string.Format("{0:f1}", answer42);

            Console.WriteLine(result1);
            Console.WriteLine(result2);

            Console.OutputEncoding = Encoding.UTF8;
            double money = 12.08;
            string result3 = string.Format("{0:C}", money);
            string result4 = string.Format("{0:C2}", money);

            string result5 = $"{money:C2}";

            Console.WriteLine(money.ToString("C2"));
            Console.WriteLine(result4);

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Console.WriteLine(money.ToString("C2"));
        }

        static void StringBuilder_lesson_19()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("My ");
            sb.Append("name ");
            sb.Append("is");
            sb.Append("John");
            sb.AppendLine("!");
            sb.AppendLine("Hello!");
            //при сложении тысяч строк значительно быстрее других методов
            string str = sb.ToString();
            Console.WriteLine(str);
        }

        static void StringModification_lesson_18()
        {
            string nameConcat = string.Concat("My ", "name ", "is ", "John");
            nameConcat = string.Join(" ", "My", "name", "is", "John");
            nameConcat = "My" + "name " + "is " + "John";
            //первым параметром выступает некоторый разделитель, например пробел " "

            nameConcat = nameConcat.Insert(0, "By the way, ");

            nameConcat = nameConcat.Remove(0, "By the way, ".Length);

            string replaced = nameConcat.Replace('n', 'z');

            string data = "12;28;34;25;64";
            string[] splitData = data.Split(';');
            string first = splitData[0];

            char[] chars = nameConcat.ToCharArray();
            Console.WriteLine(chars[1]);
            Console.WriteLine(nameConcat[1]);

            string lower = nameConcat.ToLower();
            string upper = nameConcat.ToUpper();

            string john = "   My name is John ";
            Console.WriteLine(john.Trim());
        }

        static void StringEmptiness_lesson_17()
        {
            string empty = "";
            //string empty = string.Empty - то же самое, что и ""
            string whiteSpaced = " ";
            string notEmpty = " b";
            string nullString = null;
            //при работе с строкой в которой ничего нет(null),
            //т.е. при вызове методов вроде nullString.Contains('a')
            //будет вызвано исключение

            bool isNullOrEmpty;
            Console.WriteLine("IsNullOrEmpty");
            isNullOrEmpty = string.IsNullOrEmpty(empty);
            Console.WriteLine(isNullOrEmpty);

            isNullOrEmpty = string.IsNullOrEmpty(whiteSpaced);
            Console.WriteLine(isNullOrEmpty);
            isNullOrEmpty = string.IsNullOrEmpty(notEmpty);
            Console.WriteLine(isNullOrEmpty);
            isNullOrEmpty = string.IsNullOrEmpty(nullString);
            Console.WriteLine(isNullOrEmpty);
            Console.WriteLine();

            bool isNullOrWhiteSpaced;
            Console.WriteLine("IsNullOrWhiteSpaced");
            isNullOrWhiteSpaced = string.IsNullOrWhiteSpace(empty);
            Console.WriteLine(isNullOrWhiteSpaced);

            isNullOrWhiteSpaced = string.IsNullOrWhiteSpace(whiteSpaced);
            Console.WriteLine(isNullOrWhiteSpaced);
            isNullOrWhiteSpaced = string.IsNullOrWhiteSpace(notEmpty);
            Console.WriteLine(isNullOrWhiteSpaced);
            isNullOrWhiteSpaced = string.IsNullOrWhiteSpace(nullString);
            Console.WriteLine(isNullOrWhiteSpaced);

        }

        static void String_lesson_16()
        {
            string name = "abracadabra";

            bool containsAbra = name.Contains("abra"); //содержит ли "abra" в себе - true
            bool endsWithAbra = name.EndsWith("abr"); // true
            bool starsWithAbra = name.StartsWith("abr"); // false

            int indexOfA = name.IndexOf('a', 1); //3
            int lastIndexOfR = name.LastIndexOf('r');

            int length = name.Length;

            string substrFrom5 = name.Substring(5); //adabra
            string substrFrom0To3 = name.Substring(0, 3); //с нулевого символа взять 3 символа - abr
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
