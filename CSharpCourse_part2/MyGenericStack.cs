using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part2
{
    internal class MyGenericStack<T>
    {
        private T[] _items;

        public int Count { get; private set; }
        public int Capacity
        {
            get { return _items.Length; }
        }

        public MyGenericStack()
        {
            const int defaultCapacity = 4;
            _items = new T[defaultCapacity];
        }

        public MyGenericStack(int capacity)
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

            //так как непозволительно обобщённому типу T присваивать null
            //так как у некоторых типов данных нельзя присваивать null
            //то следует использовать конструкцию default(T)
            //она присваивает переменной то значение, которые по
            //умолчанию у этого типа (null или 0 или ещё что-нибудь)
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
    }
}
