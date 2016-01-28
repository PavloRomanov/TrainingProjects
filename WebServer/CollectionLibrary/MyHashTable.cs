using System;
using  System.Collections;
using System.Collections.Generic;

namespace CollectionLibrary
{
    [Serializable]
    public class MyHashTable<TKey, TValue> : IDictionary<TKey, TValue> where TKey : IComparable<TKey>
    {
        private MyKeyValuePair[] _hashTableArray;
        private int _count;
        private int _version;
        protected int _length;

        [Serializable]
        private class MyKeyValuePair : IComparable<TKey>
        {
            public TKey _Key { get; set; }
            public TValue _Value { get; set; }

            public MyKeyValuePair(TKey key, TValue value)
            {
                _Key = key;
                _Value = value;
            }

            public int CompareTo(TKey other)
            {
                if (_Key == null)
                    throw new ArgumentNullException();
                if (other == null)
                    throw new ArgumentNullException();
                return _Key.CompareTo(other);
            }
        }

        public MyHashTable()
        {
            _hashTableArray = new MyKeyValuePair[40];
            _count = 0;
            _version = 0;
            _length = _hashTableArray.Length;
        }


        private void Resize()
        {
            int newLength = _length * 2;
            MyKeyValuePair[] temp = new MyKeyValuePair[newLength];
            for (int i = 0; i < _length; i++)
            {
                if (_hashTableArray[i] == null)
                    continue;
                AddToArray(temp, _hashTableArray[i]);
            }
            _hashTableArray = temp;
        }

        private void AddToArray(MyKeyValuePair[] array, MyKeyValuePair pair)
        {
            int length = array.Length;
            int index = Math.Abs(pair._Key.GetHashCode() % length);
            
            while (true)
            {
                if (array[index] == null)
                {
                    array[index] = pair;
                    return;
                }
                index++;
            }
        }


        public TValue this[TKey key]
        {
            get
            {
                if (key == null)
                    throw new ArgumentNullException();

                int hash = Math.Abs(key.GetHashCode() % _length);
                for (int i = hash; i < _length; i++)
                {
                    if (_hashTableArray[i] == null)
                        throw new KeyNotFoundException();
                    if (_hashTableArray[i]._Key.CompareTo(key) == 0)
                        return _hashTableArray[i]._Value;
                }
                return default(TValue);
            }

            set
            {
                if (key == null)
                    throw new ArgumentNullException();
                if (IsReadOnly)
                    throw new NotSupportedException();

                int hash = Math.Abs(key.GetHashCode() % _length);

                for (int i = hash; i < _length; i++)
                {
                    /*if (_hashTableArray[i] == null)
                        throw new KeyNotFoundException();*/
                    if (_hashTableArray[i]._Key.CompareTo(key) == 0)
                        _hashTableArray[i]._Key = key;
                    _hashTableArray[i]._Value = value;
                }
            }
        }

        public int Count
        {
            get { return _count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                TKey[] arrayKeys = new TKey[_count];
                int i = 0;
                foreach (var item in this)
                {
                    arrayKeys[i] = item.Key;
                    i++;
                }
                return arrayKeys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                TValue[] arrValues = new TValue[_count];
                int i = 0;
                foreach (var item in this)
                {
                    arrValues[i] = item.Value;
                    i++;
                }
                return arrValues;
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Add(TKey key, TValue value)
        {
            if (IsReadOnly)
                throw new NotSupportedException();
            if (key == null)
                throw new ArgumentNullException();
            if (ContainsKey(key))
                throw new AggregateException();
            if (_length < _count * 2)
                Resize();

            MyKeyValuePair pair = new MyKeyValuePair(key, value);
            int hash = Math.Abs(pair._Key.GetHashCode() % _length);
            
            for (int i = hash; i < _length; i++)
            {
                if (_hashTableArray[i] == null)
                {
                    _hashTableArray[i] = pair;
                    _count++;
                    return;
                }
            }
        }

        public void Clear()
        {
            _count = 0;
            _version = 0;
            _hashTableArray = null;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ContainsKey(item.Key);
        }

        public bool ContainsKey(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException();

            int hash = Math.Abs(key.GetHashCode() % _length);
            
            for (int i = hash; i < _length; i++)
            {
                if (_hashTableArray[i] == null)
                    break;
                if (key.Equals(_hashTableArray[i]._Key))
                    return true;
            }
            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (array.Length - arrayIndex < Count)
                throw new ArgumentException();
            /* if(array.GetType() != _hashTableArray.GetType())
                 throw new ArgumentException();*/

            for (int i = arrayIndex, j = 0; i < (arrayIndex + Count) && j < _hashTableArray.Length; i++, j++)
            {
                while (_hashTableArray[j] == null)
                {
                    j++;
                }
                KeyValuePair<TKey, TValue> pair = new KeyValuePair<TKey, TValue>(_hashTableArray[j]._Key, _hashTableArray[j]._Value);
                array[i] = pair;
            }
        }



        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        public bool Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException();
            if (!ContainsKey(key))
                return false;
            int index = Math.Abs(key.GetHashCode() % _length);
            for (int i = index; i < _length; i++)
            {
                if (_hashTableArray[i] == null)
                    break;
                if (key.CompareTo(_hashTableArray[i]._Key) == 0)
                {
                    _hashTableArray[i]._Key = default(TKey);
                    _hashTableArray[i]._Value = default(TValue);
                }
            }
            return true;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            throw new NotImplementedException();
        }

        #region Enumerator

        private class HashTableEnumerator : IEnumerator<KeyValuePair<TKey, TValue>>
        {
            private MyHashTable<TKey, TValue> _hashTable;
            private int _versionEnumerator;
            private KeyValuePair<TKey, TValue> _currentPair;
            private int _currentIndex;
            private bool _moveNext;

            public HashTableEnumerator(MyHashTable<TKey, TValue> hashTable)
            {
                _hashTable = hashTable;
                _versionEnumerator = hashTable._version;
                _currentIndex = -1;
                _moveNext = false;
            }

            public KeyValuePair<TKey, TValue> Current
            {
                get
                {
                    if (_hashTable._hashTableArray[_currentIndex] == null)
                        this.MoveNext();
                    if (_moveNext)
                    {
                        return _currentPair;
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (_moveNext)
                    {
                        return _currentPair;
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                if (_versionEnumerator != _hashTable._version)
                    throw new InvalidOperationException();

                _currentIndex++;
                _moveNext = _currentIndex < _hashTable._length; //_hashTable._count;
                if (_moveNext)
                {
                    if (_hashTable._hashTableArray[_currentIndex] == null)
                        return MoveNext();
                    _currentPair = new KeyValuePair<TKey, TValue>(_hashTable._hashTableArray[_currentIndex]._Key, _hashTable._hashTableArray[_currentIndex]._Value);
                }
                return _moveNext;
            }

            public void Reset()
            {
                _currentIndex = -1;
                _moveNext = false;
            }
        }

        #endregion

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return new HashTableEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new HashTableEnumerator(this);
        }
    }
}
