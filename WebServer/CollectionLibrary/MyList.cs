using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionLibrary
{
    public class MyList<T> : IList, IList<T>, ISortable<T> where T : IComparable<T>
    {
        private T[] _myArray;
        private int _count;
        private int _version;

        public MyList()
        {
            _myArray = new T[0];
            _count = 0;
            _version = 0;
        }

        #region Enumerator

        private class Enumerator : IEnumerator<T>, IEnumerator
        {
            public MyList<T> _myList;
            private int _currentIndex;
            private T _currentValue;
            private int _versionEnumerator;
            bool _moveNext;

            public Enumerator(MyList<T> myList)
            {
                _myList = myList;
                _currentIndex = -1;
                _versionEnumerator = myList._version;
                _moveNext = false;
            }

            object IEnumerator.Current
            {
                get
                {
                    if (_moveNext)
                    {
                        return (object)_myList._myArray[_currentIndex];
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }

                }
            }

            public T Current
            {
                get
                {
                    if (_moveNext)
                    {
                        return _currentValue;
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }

                }
            }

            public bool MoveNext()
            {
                if (_versionEnumerator != _myList._version)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    _currentIndex++;
                    _moveNext = _currentIndex < _myList._count;
                    if (_moveNext)
                        _currentValue = _myList[_currentIndex];
                    return _moveNext;
                }
            }

            public void Reset()
            {
                _moveNext = false;
                _currentIndex = -1;
            }

            void IDisposable.Dispose() { }
        }
        #endregion


        private void Resize()
        {
            int size = _myArray.Length;
            int newSize = _myArray.Length * 2;
            T[] newArray = new T[newSize];
            for (int i = 0; i < size; i++)
            {
                newArray[i] = _myArray[i];
            }
            _myArray = newArray;
        }

        int IList.Add(object value)
        {
            if (_count == 0)
            {
                T[] newArray = new T[4];
                _myArray = newArray;
            }
            else if (_count >= _myArray.Length)
            {
                Resize();
            }

            _myArray[_count] = (T)value;
            _count++;
            _version++;
            return _count - 1;
        }

        public void Clear()
        {
            _myArray = new T[0];
            _count = 0;
            _version = 0;
        }

        public bool Contains(object value)
        {
            return this.Contains((T)value);
        }

        public int IndexOf(object value)
        {
            return this.IndexOf((T)value);
        }

        void IList.Insert(int index, object value)
        {
            if (value is T)  //нужно ли проверять?
            {
                T item = (T)value;
                this.Insert(index, item);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public bool IsFixedSize
        {
            get { return false; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        void IList.Remove(object value)
        {
            for (int index = 0; index < _count; index++)
            {
                if (Equals(_myArray[index], value))
                {
                    for (int i = index; i < (_count - 1); i++)
                    {
                        _myArray[i] = _myArray[i + 1];
                    }
                    _count = _count - 1;
                }
            }
        }

        public void RemoveAt(int index)
        {
            try
            {
                if ((index >= 0) && (index < _count))
                {
                    for (int i = index; i < (_count - 1); i++)
                    {
                        _myArray[i] = _myArray[i + 1];
                    }
                    _count = _count - 1;
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        object IList.this[int index]
        {
            get
            {
                if ((index >= 0) && (index < _count))
                {
                    return _myArray[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                if ((index >= 0) && (index < _count))
                {
                    _myArray[index] = (T)value;
                    _version++;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        void ICollection.CopyTo(Array array, int index)
        {
            if (array != null)
            {
                if ((index >= 0) && (index < array.Length))
                {
                    if (this._myArray.Length > array.Length - index)
                    {
                        int j = index;
                        for (int i = 0; i < _count; i++)
                        {
                            array.SetValue(_myArray[i], j);
                            j++;
                        }
                    }
                    else
                    {
                        throw new ArgumentException("error", "Method 'CopyTo' - This array too small");
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                throw new ArgumentNullException("error", "This array is null");
            }
        }

        public int Count
        {
            get { return _count; }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
            //throw new NotImplementedException();
        }



        //**************************************************************************

        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Equals(_myArray[i], item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (item != null)
            {
                if ((index >= 0) && (index < _count))
                {
                    if (_count + 1 <= _myArray.Length)
                        Resize();
                    _count = _count + 1;
                    for (int i = _count - 1; i > index; i--)
                    {
                        _myArray[i] = _myArray[i - 1];
                    }
                    _myArray[index] = item;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public T this[int index]
        {
            get
            {
                if ((index >= 0) && (index <= _count))
                {
                    return _myArray[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            set
            {
                if ((index >= 0) && (index < _count))
                {
                    _myArray[index] = (T)value;
                    _version++;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void Add(T item)
        {
            if (_count == 0)
            {
                T[] newArray = new T[4];
                _myArray = newArray;
            }
            else if (_count >= _myArray.Length)
            {
                Resize();
            }

            _myArray[_count] = item;
            _count++;
            _version++;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Equals(_myArray[i], item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int index)
        {
            if ((index >= 0) && (index < array.Length))
                throw new ArgumentOutOfRangeException("error", "Method 'CopyTo' - Index is wrong");
            if (this._myArray.Length > array.Length - index)
                throw new ArgumentException("error", "Method 'CopyTo' - This array too small");
            if (array != null)
            {
                int j = index;
                for (int i = 0; i < _count; i++)
                {
                    array.SetValue(_myArray[i], j);
                    j++;
                }
            }
            else
            {
                throw new ArgumentNullException("error", "Method 'CopyTo' - This array is null");
            }
        }

        public bool Remove(T item)
        {
            for (int index = 0; index < _count; index++)
            {
                if (Equals(_myArray[index], item))
                {
                    for (int i = index; i < (_count - 1); i++)
                    {
                        _myArray[i] = _myArray[i + 1];
                    }
                    _count = _count - 1;
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        public void PrintContents()
        {
            Console.WriteLine("MyList contents: ");
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine(_myArray[i]);
            }
        }


        public void SelectionSort(IComparer<T> comp = null)
        {
            int lenght = _myArray.Length;
            int indexTemp;
            T temp;

            for (int i = 0; i < lenght; i++)
            {
                temp = _myArray[i];
                for (int j = i + 1; j < lenght; j++)
                {
                    indexTemp = i;
                    if (_myArray[j].CompareTo(temp) < 0)
                    {
                        indexTemp = j;
                        temp = _myArray[j];
                    }
                    _myArray[indexTemp] = _myArray[i];
                    _myArray[i] = temp;
                }
            }
        }

        public void InsertionSort(IComparer<T> comp = null)
        {
            int lenght = _myArray.Length;
            int index;
            T temp;

            for (int i = 0; i < lenght - 1; i++)
            {
                temp = _myArray[i];
                index = i;
                for (int j = (i + 1); j < lenght; j++)
                {

                    if (_myArray[j].CompareTo(temp) < 0)
                    {
                        index = j;
                        temp = _myArray[j];
                    }
                }
                temp = _myArray[i];
                _myArray[i] = _myArray[index];
                _myArray[index] = temp;
            }
        }


        public void ShellSort(IComparer<T> comp = null)
        {
            int lenght = _myArray.Length;
            int step = 1;
            T temp;
            do
            {
                step = 3 * step + 1;

            } while (step < lenght);

            do
            {
                step = (step - 1) / 3;
                for (int i = 0; i < lenght - step; i++)
                {
                    if (_myArray[i + step].CompareTo(_myArray[i]) < 0)
                    {
                        temp = _myArray[i + step];
                        _myArray[i + step] = _myArray[i];
                        _myArray[i] = temp;

                        for (int j = i - step; j > 0; j = j - step)
                        {
                            if (_myArray[j].CompareTo(temp) < 0)
                            {
                                break;
                            }
                            else
                            {
                                _myArray[j + step] = _myArray[j];
                                _myArray[j] = temp;
                            }
                        }
                    }
                }

            } while (step != 0);
        }

        public void MergeSort(IComparer<T> comp = null)
        {
            throw new NotImplementedException();
        }
    }
}
