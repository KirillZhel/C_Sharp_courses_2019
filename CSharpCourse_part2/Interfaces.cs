using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part2
{
    //интерфейсы и частично абстрактные классы мы можем воспринимать
    //как некоторый контракт, который гарантирует нам,
    //что класс-наследник будет иметь некий список реализаций методов,
    //из чего мы будем уверены, что классы-наследники смогут сделать
    //то или иное действие
    public interface IBaseCollection
    {
        //интерфейс может содержать только сигнатуры
        //т.е. объявление методов
        //пример: double Area(double a, douable b);
        //нет модификатора доступа (public и тд)
        //нет слова abstract

        void Add(Object obj);
        void Remove(Object obj);
        //с C# 8 интерфейсы могут иметь реализацию по умолчанию!!!
    }

    //Мы могли бы использовать вместо интерфейсоф абстрактные классы, но...
    //public abstract class IBaseCollection
    //{
    //    public abstract void Add(object obj);
    //    public abstract void Remove(object obj);
    //}
    //класс не может иметь несколько родительских классов (т.е. нет множественного
    //наследования), а интерфейсы такое позволяет
    //интерфейсы - реализуют для классов абстрактное понятие "can do"(могу сделать)
    //абстрактные классы - реализуют понятие "is a" (являюсь)
    //
    //абстрактные классы - более расширяемы с точки зрения поставщика класса
    //интерфейсы - более расширяемы с точки зрения потребителя

    //класс может наследовать одновременно и от класса и от интерфейсов(одного или больше)
    public class BaseList : IBaseCollection
    {
        private object[] items;
        private int count = 0;

        public BaseList(int initialCapacity)
        {
            items = new object[initialCapacity];
        }

        public void Add(object obj)
        {
            items[count] = obj;
            count++;
        }

        public void Remove(object obj)
        {
            items[count] = null;
            count--;
        }
    }

    //методы расширения (урок 75)
    public static class BaseCollectionExtension
    {
                                    //сначала идёт интерфейс, который расширяем
                                                                    //потом параметры для метода расширения
                                                                    //в данном случае классы, которые реализуют интерфейс IEnumerable
                                                                    //например List, array, queue и любая другая коллекция
        public static void AddRange(this IBaseCollection collection, IEnumerable<object> objects)
        {
            foreach (var item in objects)
            {
                collection.Add(item);
            }
        }
    }

    //если у класса НЕТ реализации метода, а в интерфейсе есть реализация по умолчанию
    //то экземпляр класса вызванный как тип данного интерфейса и созданный как экземпляр наследуюзего класса
    //будет вызывать метод этого интерфейса
    //
    //ITestInterface1 test1 = new TestClass();
    //test1.TestMethod(); - test1                 
    //ITestInterface2 test2 = new TestClass();
    //test2.TestMethod(); - test2
    //
    //Если же класс имеет реализацию метода, то вне зависимости как экземпляр был объявлен, он 
    //будет использовать реализацию метода класса
    //
    //ITestInterface1 test1 = new TestClass();
    //test1.TestMethod(); - test3
    //ITestInterface2 test2 = new TestClass();
    //test2.TestMethod(); - test1
    //TestClass test3 = new TestClass();
    //test3.TestMethod(); - test3
    public interface ITestInterface1
    {
        void TestMethod()
        {
            Console.WriteLine("test1");
        }
    }

    public interface ITestInterface2
    {
        void TestMethod()
        {
            Console.WriteLine("test2");
        }
    }

    public class TestClass :ITestInterface1, ITestInterface2
    {
        //public void TestMethod()
        //{
        //    Console.WriteLine("test3");
        //}
    }
}
