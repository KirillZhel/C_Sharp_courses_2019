using System;
using System.Text;
using System.Timers;

namespace CSharpCourse_part3
{
    class Program
    {
        static void Main(string[] args)
        {
            //lesson_83_Exceptions();
            //lesson_84_ThrowExeption();
            //lesson_85_FileStream();
            //lesson_86_File();
            //lesson_91_Delegation();
            //lesson_92_ListDelegat_part_1();
            //lesson_92_ListDelegat_part_2();
        }

        

        void lesson_83_Exceptions()
        {
            FileStream file = null;
            try
            {
                file = File.Open("temp.txt", FileMode.Open);
            }
            //чаще обрабатывают группы исключений
            //в данном случае не обрабатывают к примеру исключение 
            //FileNotFoundException
            //так как это исключение - наследник IOException
            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            //блок finally гарантирует отработку кода в нём в любом случае
            finally
            {
                if (file != null)
                    file.Dispose();
            }

            //для всех исключений базовым типом является Exception
            Console.WriteLine("Please input a number");
            string result = Console.ReadLine();

            int number = 0;
            try
            {
                number = int.Parse(result);
            }
            catch (OverflowException ex)
            {

            }
            //поймаем отдельный тип исключения
            catch (FormatException ex)
            {
                Console.WriteLine("A format exception has occured.");
                Console.WriteLine("Information is below:");
                Console.WriteLine(ex.ToString());
            }
            //поймаем все абсолютно исключения, которые мы не поймали ранее
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine(number);
        }

        void lesson_84_ThrowExeption()
        {
            //теперб в классе Character_84 есть проброс исключений
            //в конструкторе Character_84(string name, int armor) и в методе Hit(int damage)
            Character_84 character = new Character_84("Elf", 50);
            character.Hit(40);

            //так же можно создавать свои нестандартные исключения
            //проброс и обработка таких исключений происходит абсолютно также
            CreditCardWithDrawException ex = null;
        }

        void lesson_85_FileStream()
        {
            //ШОРТКАТЫ:

            //прочитать все строки из файла и получить массив строк
            string[] allLines = File.ReadAllLines("test.txt");
            //прочитать все строки и получить единую строку
            string allText = File.ReadAllText("test.txt");
            //получить коллекуцию из прочитанных строк
            IEnumerable<string> lines = File.ReadAllLines("test.txt");

            //запись в файл текста
            File.WriteAllText("test_2.txt", "My name is John");
            //запись в файл массива строк
            File.WriteAllLines("test_3.txt", new string[] { "My name", "is John" });
            //запись в файл побайтово
            File.WriteAllBytes("test_4.txt", new byte[] { 72, 101, 108, 108, 111 });

            allText = File.ReadAllText("test_2.txt");
            Console.WriteLine(allText);

            allLines = File.ReadAllLines("test_3.txt");
            Console.WriteLine(allLines[0]);
            Console.WriteLine(allLines[1]);
            foreach (var item in allLines)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            byte[] bytes = File.ReadAllBytes("test_4.txt");
            Console.WriteLine(Encoding.ASCII.GetString(bytes));
            foreach (var item in bytes)
            {
                Console.Write((char)item);
            }
            Console.WriteLine();

            //-----------------------------------------------------------------------------------

            Console.ReadLine();

            Stream fs = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //Stream - базовый класс, от которого много наследников
            //FileMode:
            //Append - открывает файл и помещает курсор в конец файла
            //Create - создание нового файла(если есть файл с таким именем, то он будет перезатёрт)
            //CreateNew - создаёт файл, а в случае, если такой файл уже имеется, то выбросит исключение
            //Open - открывает файл и если нет такого файла, то выбрасывает исключение
            //OpenOrCreate - открывает файл или создаёт его
            //Truncate - открывает файл и всё в нём стирает

            //FileAccess:
            //Read - собираемся только читать
            //ReadWrite - читаем и записываем
            //Write - только записываем

            try
            {
                string str = "Hello, World!";
                //сконвертируем строку в поток байтов
                byte[] strInBytes = Encoding.ASCII.GetBytes(str);

                if (fs.CanWrite)
                {
                    fs.Write(strInBytes, 0, strInBytes.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                //вызов Close() предпочтительнее чем Dispose()
                fs.Close();
            }

            //абсолютно всё то же самое, что и выше, только теперь открываем стрим для чтения
            //т.е. при компиляции преобразуется в:
            //
            //Stream readingStream = null;
            //try
            //{
            //    readingStream = new FileStream("test.txt", FileMode.Open, FileAccess.Read);
            //}
            //finally
            //{
            //    readingStream.Dispose();
            //}
            //
            //только нет catch, исключение летит куда-то дальше, пока не поймает нужный catch(?)


            Console.WriteLine("now reading");
            using (Stream readingStream = new FileStream("test.txt", FileMode.Open, FileAccess.Read))
            {
                //объявим буффер для байтов
                byte[] temp = new byte[readingStream.Length];
                ASCIIEncoding encoding = new ASCIIEncoding();


                //код ниже позволяет прочитать файл практически любой длинны (не более int.MaxValue)
                int bytesToRead = (int)readingStream.Length;
                int bytesRead = 0;
                //while((bytesRead = readingStream.Read(temp, 0, temp.Length)) > 0)
                while (bytesToRead > 0)
                {
                    //считаем количество байт, которые прочитали
                    int n = readingStream.Read(temp, bytesRead, bytesToRead);

                    if (n == 0)
                    {
                        break;
                    }

                    bytesRead += n;
                    bytesToRead -= n;

                    //string str = encoding.GetString(temp, 0, len);
                    string str = Encoding.ASCII.GetString(temp, 0, temp.Length);

                    Console.WriteLine(str);
                }
            }
        }

        void lesson_86_File()
        {
            //когда производим какие либо манипуляции с
            //внешнимим системами, такие операции надо
            //оборачивать в try-catch

            try
            {
                DirFileDemo();
            }
            catch (Exception ex)
            {

            }

        }

        static void DirFileDemo()
        {
            //КОПИРОВАНИЕ
            //        файл для копирования
            //                    копия файла
            //                                     переписать или не переписывать
            //                                     файл в случае существования test_copy.txt
            File.Copy("test.txt", "test_copy.txt", overwrite: true);

            //ПЕРЕИМЕНОВАНИЕ(?) скорее перемещение файла
            //text_copy.txt -> text_copy_renamed.txt
            //если вторым параметром не указывать путь, то файл не будет перемещён из изначальной папки(?)

            File.Move("text_copy.txt", "text_copy_renamed.txt");

            //УДАЛЕНИЕ
            File.Delete("test_copy.txt");

            //File.Exists - проверяет наличие файла
            //всё равно НАДО ОБОРАЧИВАТЬ В try-catch
            //мало ли что может случиться
            if (File.Exists("test.txt"))
            {
                File.AppendAllText("text.txt", "bla"); // - добавление 
            }

            //ПЕРЕЗАПИСЬ файла данными другого файла
            //          источник данных
            //                          файл, в который производится запись
            //                                       файл, в который будут сохранены
            //                                       данные из перезаписанного файла
            File.Replace("test_2.txt", "test_3.txt", "test_backup.txt");

            //------------------------------------------------------------------------
            //проверка существования папки
            bool existsDir = Directory.Exists(@"E:\Обучение");
            Console.WriteLine(existsDir);
            if (existsDir)
            {
                //получаем список элементов, которые хранятся в папке
                //второй аргумент позволяет получить список файлов формата .txt
                //SearchOption - утсанавдивает область поиска: AllDirectories - во всех директориях включая вложенные
                var files = Directory.EnumerateFiles(@"E:\Обучение", "*.txt", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }

            }

            //Directory.Delete(); - удаление директории

            //--------------------------------------------------------------------------
            //Манипулирование путями
            //Path.GetFullPath(); - получить полный путь
            //Path.Combine(@"C:\tmp", "\\bla", "file.txt"); - получить полный путь из нескольких кусков
        }


        static Car car_0;

        static void lesson_91_Delegation()
        {
            car_0 = new Car();
            //вызывая метод RegisterOnTooFast(), передаём метод HandleOnTooFast,
            //который будет записан в переменную tooFast,
            //после чего мы вызываем этот метод при speed > 80
            car_0.RegisterOnTooFast(HandleOnTooFast);
            car_0.Start();
            for (int i = 0; i < 10; i++)
            {
                car_0.Accelerate();
            }
            //нужно уведомление с уровня класса Car о том, что к примеру параметр
            //speed слишком большой и хватит его вызывать (например при превышении
            //скорости до 110 надо вызвать метод Stop()(остановить машину))

            //ключевое слово delegate используется для обработки внешним кодом события
            //нижнего уровня
        }

        //обработчик события
        private static void HandleOnTooFast(int speed)
        {
            Console.WriteLine($"Oh, I got it, calling stop! Current speed = {speed}");
            car_0.Stop();
        }

        static CarListDelegat car_1;
        private static void lesson_92_ListDelegat_part_1()
        {
            car_1 = new CarListDelegat();
            
            //подписка на event(событие)
            car_1.TooFastDriving += HandleOnTooFast_1;
            car_1.TooFastDriving += HandleOnTooFast_1;
            //отписка
            car_1.TooFastDriving -= HandleOnTooFast_1;

            //ПОДПИСКА И ОТПИСКА НА ДЕЛЕГАТ
            /*
            carL.RegisterOnTooFast(HandleOnTooFastL);
            carL.RegisterOnTooFast(HandleOnTooFastL);
            //теперь при speed > 80 будут вызваны 2 метода HandleOnTooFast
            carL.UnregisterOnTooFast(HandleOnTooFastL);
            //но тут мы отсоединяем метод от делегата и будет вызван тогда один раз метод
            carL.Start();
            //система списка методов на делегате создана для того, что бы
            //несколько разных кусков системы могли обрабатывать одно событие
            //например генерируется событие "на часах 13:00" и один кусок системы
            //отправляет письмо, второй издаёт звуковой сигнал и тд(?)
            */

            for (int i = 0; i < 10; i++)
            {
                car_1.Accelerate();
            }
        }

        private static void HandleOnTooFast_1(int speed)
        {
            Console.WriteLine($"Oh, I got it, calling stop! Current speed = {speed}");
            car_1.Stop();
        }
        
        private static void lesson_92_ListDelegat_part_2()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += Timer_Elapsed;

            //каждые 5000 мкс будет вызываться обработчик
            timer.Interval = 5000;
            timer.Start();

            Console.ReadLine();

            CarWithEvent car_2 = new CarWithEvent();

            car_2.TooFastDriving += HandleOnTooFast_1;
            
            for (int i = 0; i < 10; i++)
            {
                car_2.Accelerate();
            }

            Console.ReadLine();
        }

        //sender - некая ссылка, которая "связывает" timer из lesson_92_ListDelegat_part_2()
        //с timer в Timer_Elapsed()
        //это позволяет не выводить ,например ,static CarWithEvent car_2 во вне методов
        //а также не делать его статическим
        private static void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            //var timer = (System.Timers.Timer)sender;
            Console.WriteLine("Handling Timer Elapsed Event");
        }

        //private static void HandleOnTooFast_1(object obj, int speed)
        private static void HandleOnTooFast_1(object obj, CarArgs speed)
        {
            var car = (CarWithEvent)obj;
            Console.WriteLine($"Oh, I got it, calling stop! Current speed = {speed.CurrentSpeed}");
            car.Stop();
            //car_2.Stop();
        }
    }
}