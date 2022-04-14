using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse_part2
{
    public class MyStack
    {
        private object[] _items;

        public int Count { get; private set; }
        public int Capacity 
        {
            get { return _items.Length; }
        }

        public MyStack()
        {
            const int defaultCapacity = 4;
            _items = new object[defaultCapacity];
        }

        public MyStack(int capacity)
        {
            _items = new object[capacity];
        }

        public void Push(object item)
        {
            if (_items.Length == Count)
            {
                object[] largeArray = new object[Count * 2];
                Array.Copy(_items, largeArray, Count);
                _items = largeArray;
            }
            _items[Count++] = item;
        }

        public void Pop()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException();
            }

            _items[--Count] = null;
        }

        public object Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return _items[Count - 1];
        }
    }
}
