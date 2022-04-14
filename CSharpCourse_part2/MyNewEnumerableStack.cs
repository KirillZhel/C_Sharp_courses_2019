using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part2
{
    internal class MyNewEnumerableStack<T> : IEnumerable<T>
    {
        private T[] _items;

        public int Count { get; private set; }
        public int Capacity
        {
            get { return _items.Length; }
        }

        public MyNewEnumerableStack()
        {
            const int defaultCapacity = 4;
            _items = new T[defaultCapacity];
        }

        public MyNewEnumerableStack(int capacity)
        {
            _items = new T[capacity];
        }

        public void Push(T item)
        {
            if (_items.Length == Count)
            {
                T[] largeArray = new T[Count * 2];
                Array.Copy(_items, largeArray, Count);
                _items = largeArray;
            }
            _items[Count++] = item;
        }

        public void Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            _items[--Count] = default(T);
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return _items[Count - 1];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                //ключевое выражение yeild return устраняет необходимость
                //реализации класса с интерфейсом IEnumerator
                //компилятор автоматически реализует такой класс,
                //так как обычно такие реализации практически одинаковы
                yield return _items[i];
                //yield return реализует ленивые вычисления
                //вывод происходит постепенно (в foreach подаётся по одному элементу а не все сразу)
                //и если нам нужно 10 элементов  из 5млрд, то мы не будет ждать вечность, пока вернутся
                //5млрд, мы будем ждать только 10 нужных элементов
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
