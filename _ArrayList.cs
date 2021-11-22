using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arraylist
{
    public class _ArrayList
    {
        private Object[] _items;
        private int _size;
        private int _version;
        private const int defaultCapacity = 4;
        private static readonly Object[] emptyArray = new Array[0];

        public _ArrayList()
        {
            _items = emptyArray;
        }

        public _ArrayList(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentOutOfRangeException();

            if (capacity == 0)
                _items = emptyArray;
            else
                _items = new Object[capacity];
        }

        public virtual int Capacity
        {
            get
            {
                return _items.Length;
            }
            set
            {
                if (value < _size)
                    throw new ArgumentOutOfRangeException();

                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        Object[] newItems = new Object[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, 0, newItems, 0, _size);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = new Object[defaultCapacity];
                    }
                }
            }
        }
        public virtual int Count
        {
            get { return _size; }
        }

        public virtual Object this[int index]
        {
            get
            {
                if (index < 0 || index >= _size)
                    throw new ArgumentOutOfRangeException();

                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _size)
                    throw new ArgumentOutOfRangeException();
                _items[index] = value;
                _version++;
            }
        }

        public void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCapacity = _items.Length == 0 ? defaultCapacity : _items.Length * 2;
                if ((uint)newCapacity > 0X7FEFFFFF)
                    newCapacity = 0X7FEFFFFF;
                if (newCapacity < min)
                    newCapacity = min;
                Capacity = newCapacity;
            }
        }

        public virtual int Add(Object value)
        {
            if (_size == _items.Length)
                EnsureCapacity(_size + 1);
            _items[_size] = value;
            _version++;
            return _size++;
        }

        public virtual void Clear()
        {
            if (_size > 0)
            {
                Array.Clear(_items, 0, _size);
                _size = 0;
            }
            _version++;
        }

        public virtual bool Contains(Object item)
        {
            if (item == null)
            {
                for (int i = 0; i < _items.Length; i++)
                    if (_items[i] == null)
                        return true;
                return false;
            }
            else
            {
                for (int i = 0; i < _items.Length; i++)
                    if (_items[i] != null && _items[i].Equals(item))
                        return true;
                return false;
            }

        }

        public virtual void CopyTo(Array array)
        {
            CopyTo(array, 0);
        }

        public virtual void CopyTo(Array array, int arrayIndex)
        {
            if ((array != null) && (array.Rank != 1))
                throw new ArgumentException();
            Array.Copy(_items, 0, array, arrayIndex, _size);
        }

        public virtual void CopyTo(int index, Array array, int arrayIndex, int count)
        {
            if (_size - index < count)
                throw new ArgumentException();
            if ((array != null) && (array.Rank != 1))
                throw new ArgumentException();
            Array.Copy(_items, index, array, arrayIndex, count);
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(_items, _size);
        }

        public class Enumerator
        {
            private Object[] _items;
            private int _size;
            private int _count = 0;

            public Enumerator(Object[] items, int size)
            {
                _items = items;
                _size = size;
            }

            public Object Current { get => _items[_count++]; }

            public bool MoveNext()
            {
                return _count < _size;
            }
        }

        public virtual int IndexOf(Object value, int startIndex)
        {
            if (startIndex > _size)
                throw new ArgumentOutOfRangeException();
            return Array.IndexOf((Array)_items, value, startIndex, _size - startIndex);
        }

        public virtual int IndexOf(Object value, int startIndex, int count)
        {
            if (startIndex > _size)
                throw new ArgumentOutOfRangeException();
            if (count < 0 || startIndex > _size - count) throw new ArgumentOutOfRangeException();
            return Array.IndexOf((Array)_items, value, startIndex, count);
        }

        public virtual void Insert(int index, Object value)
        {
            if (index < 0 || index > _size) throw new ArgumentOutOfRangeException();

            if (_size == _items.Length) EnsureCapacity(_size + 1);
            if (index < _size)
            {
                Array.Copy(_items, index, _items, index + 1, _size - index);
            }
            _items[index] = value;
            _size++;
            _version++;
        }
    }
}
