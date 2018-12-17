using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsLesson
{
    class MyList<T> : IEnumerable<T>
    {
        private T[] _innerList = new T[100];
        private int _length;
        public int Length { get { return _length; } }

        private void DoubleSize()
        {
            T[] newList = new T[_length * 2];
            for (int i = 0; i < _length; i++)
            {
                newList[i] = _innerList[i];
            }
            _innerList = newList;
        }

        public void Add(T t)
        {
            if (_innerList.Length == _length)
            {
                DoubleSize();
            }
            _innerList[_length] = t;
            _length++;
        }
        public void Insert(T t, int index)
        {
            if (index > _length-1 || index < 0)
                throw new Exception("Wrong index");
            if (_innerList.Length == _length)
            {
                DoubleSize();
            }
            T[] newList = new T[_length + 1];
            for (int i = 0, j = 0; i < _length; i++, j++)
            {
                if (i == index)
                {
                    newList[i] = t;
                    j++;
                }
                newList[j] = _innerList[i];
            }
            _innerList = newList;
            _length++;
        }
        public void Clear()
        {
            _innerList = new T[100];
            _length = 0;
        }
        public void DeleteAt(int index)
        {
            if (index > _length - 1 || index < 0)
                throw new Exception("Wrong index");
            T[] newList = new T[_length - 1];
            for (int i = 0, j = 0; i < _length-1; i++, j++)
            {
                if (i == index)
                {
                    i++;
                }
                newList[j] = _innerList[i];
            }
            _innerList = newList;
            _length--;
        }
        public void Delete(T t)
        {
            T[] newList = new T[_length];
            int newLength = _length;
            for (int i = 0, j = 0; i < _length - 1; i++, j++)
            {
                if (_innerList[i].Equals(t))
                {
                    j--;
                    newLength--;
                    continue;
                }

            }
            _innerList = newList;
            _length = newLength;
            
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(_innerList, _length);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyEnumerator<T>(_innerList, _length);
        }
    }

}
