using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharpCourse_part4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //lesson_94_LINQ();
            //lesson_95_LINQ();
            //lesson_96_LINQ();
            //lesson_97_Yield();
            //lesson_98_LINQ_AnonMethods();
            lesson_99_LINQ();
        }

        private static void lesson_94_LINQ()
        {
            string path = @"E:\Обучение\C_Sharp Udemy\С# Course videos";
            DisplayLargestFileWithoutLINQ(path);
            Console.WriteLine();
            DisplayLargestFileWithLINQ(path);

        }

        //метод без использования LINQ
        private static void DisplayLargestFileWithoutLINQ(string pathToDir)
        {
            var dirInfo = new DirectoryInfo(pathToDir);
            FileInfo[] files = dirInfo.GetFiles();

            //                делегат способа сортировки
            Array.Sort(files, FilesComparison);
            Array.Reverse(files);

            for (int i = 0; i < 5; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Name} weights {file.Length}");
            }
        }

        private static int FilesComparison(FileInfo x, FileInfo y)
        {
            // 1 - x больше y
            // 0 - x равен y
            // -1 - x меньше y
            //можно отсортировать в обратном порядке, заменив 1 на -1 и наоборот
            if (x.Length == y.Length) return 0;
            if (x.Length > y.Length) return 1;
            return -1;
        }

        //метод с использование LINQ
        private static void DisplayLargestFileWithLINQ(string pathToDir)
        {
            //var dirInfo = new DirectoryInfo(pathToDir);
            new DirectoryInfo(pathToDir)
            //FileInfo[] files = dirInfo.GetFiles();
                .GetFiles()
                //сортировка без лямбда выражения
                //с помощью делегата: 
                //.OrderBy(KeySelector)
                //
                //сортировка с лямбда-выражениями от большего к меньшему
                .OrderByDescending(file => file.Length)
            //если в выражении больше одной строчки то
            //
            //.OrderBy(file => {
            //           ***какой-то код***
            //           return file.Length;
            //              })
            //
            // взять 5
                .Take(5)
            // метод расширения, описанный в классе расширения
            // в LINQ нет foreach, написали свой
                .ForEach(file => Console.WriteLine($"{file.Name} weights {file.Length}"));

            /*
             * или не используя метод расширения
             * 
            IEnumerable<FileInfo> orderedFile = new DirectoryInfo(pathToDir)
                .GetFiles()
                .OrderBy(file => file.Length)
                .Take(5);

            foreach (var file in orderedFile)
            {
                Console.WriteLine($"{file.Name} weights {file.Length}");
            }
            */
        }

        static long KeySelector(FileInfo file)
        {
            return file.Length;
        }

        private static void lesson_95_LINQ()
        {
            MinMaxSumAverage("Top100ChessPlayers.csv");
        }

        static void MinMaxSumAverage(string file)
        {
            IEnumerable<ChessPlayer> list = File.ReadAllLines(file)
                                         //пропуск одной(первой) строки с заголовками колонок
                                         .Skip(1)
                                         //трансформируем коллекцию string[] в коллекцию ChessPlayer[]
                                         //Select(ChessPlayer.ParseFideCSV) - можно и так
                                         .Select(x => ChessPlayer.ParseFideCSV(x))
                                         //фильтрация по году рождения
                                         .Where(player => player.BirthYear > 1988)
                                         .OrderByDescending(player => player.Rating)
                                         //дополнительная сортировка
                                         //т.е. сначала по рейтингу, а потом по стране
                                         .ThenBy(player => player.Country)
                                         .Take(10);
                                         //приводим IEnumerable к типу List
                                         //.ToList();

            //самый маленький рейтинг игроков, родившихся после 1988 и входящих в топ 10 
            Console.WriteLine($"The lowest rating in TOP 10: {list.Min(x => x.Rating)}");
            //самый большой рейтинг игроков, родившихся после 1988 и входящих в топ 10 
            Console.WriteLine($"The highest rating in TOP 10: {list.Max(x => x.Rating)}");
            //средний рейтинг игроков, родившихся после 1988 и входящих в топ 10 
            Console.WriteLine($"The average rating in TOP 10: {list.Average(x => x.Rating)}");
        }

        private static void lesson_96_LINQ()
        {
            string path = @"Top100ChessPlayers.csv";
            IEnumerable<ChessPlayer> list = File.ReadAllLines(path)
                                                .Skip(1)
                                                .Select(x => ChessPlayer.ParseFideCSV(x))
                                                .Where(player => player.BirthYear > 1988)
                                                .OrderByDescending(player => player.Rating)
                                                .ThenBy(player => player.Country)
                                                .Take(10);
            //дополнительные методы
            //возврат первого и последнего элементов последовательности
            Console.WriteLine(list.First());
            Console.WriteLine(list.Last());
            //возврат первого/последнего элемента последовательности, который удовлетворяет 
            //некоторому условию
            Console.WriteLine(list.First(player => player.Country == "USA"));
            Console.WriteLine(list.Last(player => player.Country == "USA"));
            //то же самое, но если не найдёт ни одного экземпляра, то вернёт значение 
            //по умолчанию (в данном случае null)
            var firstFromBra = list.FirstOrDefault(player => player.Country == "BRA");
            var LastFromBra = list.LastOrDefault(player => player.Country == "BRA");

            if (firstFromBra != null)
            {
                Console.WriteLine(firstFromBra.LastName);
            }

            //Single - находит единственное вхождение по условию
            //если таких значений более одного, то вылетит исключение
            //т.е. гарантия, что такой элемент только один
            Console.WriteLine(list.Single(player => player.Country == "FRA"));
            //SingleOrDefault - если не найдёт ни одного элемента, удовлетворяющий
            //условию, то выкинет значение по умолчанию, а если элементов много, то
            // так же как и Single, выбросит исключение
            try
            {
                Console.WriteLine(list.SingleOrDefault(player => player.Country == "USA"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void lesson_97_Yield()
        {
            //Демонстрация подводных камней ключевого слова yeild
            //который повсеместно используется внутри LINQ
            var list = new List<int> { 1, 2, 3 };
            var query = list.Where(x => x >= 2);
            list.Remove(3);
            //по логике должно вернуться 2, так как в query должны быть { 2, 3 }
            //но выводится 1
            Console.WriteLine(query.Count());

            foreach (var item in query)
            {
                Console.WriteLine(item); //тут дожны выводить 2 и 3, но выводятся 2
            }

            //для борьбы с этим поступают следующим образов
            //var query = list.Where(x => x >= 2).ToList();
            //тогда LINQ-запрос выполнится сразу

            //всё из за того, что внутри методов расширения LINQ внутри foreach 
            //используется ключевое слово yield у некоторых методов, например, в Where
            //это делит методы расширения на отложенные(deferred) и жадные(greedy)
            //Запрос Where не выполняется сразу, а конструируется

            /*
             * DEFERRED METHODS:
             * Select
             * SelectMany
             * Take
             * Skip
             * Where
             * 
             * GREEDY METHODS:
             * Count
             * Average
             * Min
             * Max
             * Sum
             * First
             * Last
             * ToList
             * ToArray
             * RemoveAll
             */

            //получается, что запрос Where выполнится только когда будет вызван greedy оператор
            //в нашем случае Where выполнится, когда будет вызван метод Count. Так получается
            //что изъятие(Remove) элемента будет выполнено перед выполнением Where

            /*
             * IEnumerable<ChessPlayer> list = File.ReadAllLines(path)
                                                .Skip(1)
                                                .Select(x => ChessPlayer.ParseFideCSV(x))
                                                .Where(player => player.BirthYear > 1988)
                                                .OrderByDescending(player => player.Rating)
                                                .ThenBy(player => player.Country)
                                                .Take(10);
            * foreach(var player in list)
            * {
            *     Console.WriteLine(player)
            * }
            * 
            * foreach(var player in list)
            * {
            *     Console.WriteLine(player)
            * }
            * 
            * Вызов двух этих foreach приведёт к тому, что LINQ-запрос выше будет выполнен
            * дважды при каждом вызове foreach. Это из за того, что в запросе нет greedy 
            * методов (.ToList() в конце запроса, например). Это приводит к проблеме
            * с производительностью
             */
        }

        private static void lesson_98_LINQ_AnonMethods()
        {
            //Анонимнвые методы - устаревший синтаксис, на замену которому пришли 
            //лямбда выражения

            string path = @"Top100ChessPlayers.csv";
            IEnumerable<ChessPlayer> list = File.ReadAllLines(path)
                                                .Skip(1)
                                                .Select(ChessPlayer.ParseFideCSV)
                                                
                                                //синтаксис анонимных методов
                                                //.Where(delegate(ChessPlayer player)
                                                //{
                                                //    return player.BirthYear > 1988;
                                                //})
                                                
                                                .Where(player => player.BirthYear > 1988)
                                                .OrderByDescending(player => player.Rating)
                                                .ThenBy(player => player.Country)
                                                .Take(10)
                                                .ToList();

            //Ещё один SQL-подобный синтаксис, который иногда встречается
            //он чуть слабее чем LINQ, что не особо существенно
            IEnumerable<ChessPlayer> list2 = File.ReadAllLines(path)
                                                .Skip(1)
                                                .Select(ChessPlayer.ParseFideCSV);

            var filtered = from player in list2
                           where player.BirthYear > 1988
                           orderby player.Rating descending
                           select player;
        }

        private static void lesson_99_LINQ()
        {
            //удаление элементов из списка
            //оператор Foreach - проблемный, вызывает исключение
            RemoveInForeach();
            Console.WriteLine();
            //оператор For (прямой порядок) - менее проблемный, но тоже не очень
            RemoveInFor();
            Console.WriteLine();
            //оператор For (обратный порядок) - ещё менее проблемный, но есть и получше
            RemoveInForBackwards();
            Console.WriteLine();
            //с помощью LINQ-оператора
            RemoveAllDemo();
        }

        static void RemoveInForeach()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };
            try
            {
                foreach (var item in list)
                {
                    if (item % 2 == 0)
                    {
                        list.Remove(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //такой способ удаления элементов приведёт к исключению
            }

            //такой foreach раскладывается в (просто проход):
            /*List<int>.Enumerator = list.GetEnumerator();
             * try
             * {
             *    while (enumerator.MoveNext())
             *    {
             *       int item = enumerator.Current;
             *    }
             * }
             * finally
             * {
             *    enumerator.Dispose();
             * }
             * 
             * такой проход использует MoveNext, который в свою очередь
             * базируется на количестве элементов. Если оно изменяется, то
             * MoveNext выбрасывает исключение
             */
            
            Console.WriteLine(list.Count);
        }

        static void RemoveInFor()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };

            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                if (item <= 3)
                {
                    list.Remove(item);
                }
            }
            //при условии if (item % 2 == 0) в списке будет 3 элемента, как и положено

            //при условии if (item <= 3) по логике должно вывестись True, но это не так
            Console.WriteLine(list.Count == 2);

            //т.е. в одном случае всё будет нормально, а в другом нет
            //в данном случае это из-за смещения элементов в списке при
            //удалении из него элементов, что в свою очередь вызывает 
            //изменение индексов элементов и при условии (item <= 3)
            //будут пропущены некоторые элементы (1 и 3 останутся)
            //в for будут будут перескакивать элементы:
            //при первом заходе будет удалён 0, и на его место встанет 1,
            //но так как индекс i = 0 мы уже прошли, то возьмём индекс i = 1,
            //на котором уже стоит 2(после удаления 0)

            // можно добавить инкремент в if
            /*
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                if (item <= 3)
                {
                    list.Remove(item);
                    i--;
                }
            }
            */
            //так уже будет работать, но всё равно фигня
        }

        static void RemoveInForBackwards()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };

            //другой способ - пойти с конца в начало
            for (int i = list.Count - 1; i >= 0; i--)
            {
                var item = list[i];
                if (item <= 3)
                {
                    list.Remove(item);
                }
            }
            Console.WriteLine(list.Count == 2);
        }

        private static void RemoveAllDemo()
        {
            var list = new List<int> { 0, 1, 2, 3, 4, 5 };

            //greedy оператор
            list.RemoveAll(x => x <= 3);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            var list2 = new List<int> { 0, 1, 2, 3, 4, 5 };

            list2.RemoveAll(x => x % 2 == 0);

            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
