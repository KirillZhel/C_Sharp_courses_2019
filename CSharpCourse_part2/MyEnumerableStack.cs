using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part2
{
    internal class MyEnumerableStack<T> : IEnumerable<T>
    {
        private T[] _items;

        public int Count { get; private set; }
        public int Capacity
        {
            get { return _items.Length; }
        }

        public MyEnumerableStack()
        {
            const int defaultCapacity = 4;
            _items = new T[defaultCapacity];
        }

        public MyEnumerableStack(int capacity)
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

        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnumerator<T>(_items, Count);
        }

        //явная реализация метода, которая пришла из необобщённого типа IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
            //просто перекидываем выполнение в метод с обобщением, который выше
        }
    }

    public class StackEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] array;
        //переменная используемая для того, что бы проходиться по стеку с конца в начало
        //и наоборот
        private readonly int count;

        //итератор, по умолчанию -1, так как по умолчанию у нас ничего нет в стеке
        //при появлении нового элемента, становится 0, дальше 1 и тд
        private int position = -1;

        public StackEnumerator(T[] array, int count)
        {
            this.array = array;
            this.count = count;

            position = count;
        }

        public T Current
        {
            get
            {
                return array[position];
            }
        }

        //явная реализация метода, которая пришла из необобщённого типа IEnumerator
        object IEnumerator.Current
        {
            get
            {
                //просто перекидываем выполнение в метод с обобщением, который выше
                return Current;
            }
        }

        public void Dispose()
        {
            //в 99% случаях не используется, так как вряд ли понадобится чистить память
        }

        //возвращает true, если дальше есть элемент, false - если нет
        //также сдвигает position
        public bool MoveNext()
        {
            position--;
            return position >= 0;
        }

        //устанавливает курсор(индексатор) position в начальную позицию
        public void Reset()
        {
            position = count;
        }
    }
}
