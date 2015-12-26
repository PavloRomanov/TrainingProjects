using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionLibrary
{
    [Serializable]
    public class HashDictionary<TKey, TValue> : IDictionary<TKey, TValue>
        where TKey : IComparable<TKey>
    {

        private int _version = 1;
        private int _count;
        private CoupleKeyValuePair[] _array = new CoupleKeyValuePair[30];

        [Serializable]
        private class CoupleKeyValuePair : IComparable<CoupleKeyValuePair>
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }

            public CoupleKeyValuePair(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            public int CompareTo(CoupleKeyValuePair other)
            {

                if (Key == null || other.Key == null)
                    throw new ArgumentNullException();

                return Key.CompareTo(other.Key);

            }
        }

        #region HashNumerator

        private class HashNumerator : IEnumerator<KeyValuePair<TKey, TValue>>, IEnumerator, IDisposable
        {
            private int _version;
            private KeyValuePair<TKey, TValue> _current;
            private HashDictionary<TKey, TValue> _tab;
            private int _index;

            public HashNumerator(HashDictionary<TKey, TValue> tab)
            {
                _version = tab._version;
                _current = default(KeyValuePair<TKey, TValue>);
                _tab = tab;
                _index = 0;
            }

            public KeyValuePair<TKey, TValue> Current
            {
                get { return _current; }
            }

            object IEnumerator.Current
            {
                get { return _current; }
            }

            public void Dispose()
            {
                ((HashNumerator)this).Reset();
            }

            public bool MoveNext()
            {
                if (_version != _tab._version)
                    throw new InvalidOperationException("Failed Version");

                if (_index >= _tab._array.Length - 1)
                {
                    _index = -1;
                    _current = default(KeyValuePair<TKey, TValue>);
                    return false;
                }
                while (_tab._array[_index] == null)
                {
                    if (_index < _tab._array.Length - 1)
                    {
                        _index++;
                    }
                    else
                    {
                        return false;
                    }
                }

                var _item = _tab._array[_index];
                _current = new KeyValuePair<TKey, TValue>(_item.Key, _item.Value);
                _index++;
                return true;

            }
            public void Reset()
            {
                if (_version != _tab._version)
                    throw new InvalidOperationException("Failed Version");

                _index = 0;
                _current = default(KeyValuePair<TKey, TValue>);
            }
        }

        #endregion

        public TValue this[TKey key]
        {
            get
            {
                if (key == null)
                    throw new ArgumentNullException();
                int index = Math.Abs(key.GetHashCode() % _array.Length);
                while (true)
                {
                    if (_array[index].Key.CompareTo(key) == 0)
                    {
                        return _array[index].Value;
                    }
                    else
                    {
                        index++;
                    }
                    if (index > _array.Length - 1)
                        index = 0;
                    if (_array[index] == null)
                        throw new KeyNotFoundException();
                }

            }
            set
            {
                if (key == null)
                    throw new ArgumentNullException();
                int index = Math.Abs(key.GetHashCode() % _array.Length);
                while (true)
                {
                    if (_array[index].Key.CompareTo(key) == 0)
                    {
                        _array[index].Value = value;
                        return;  // добавила
                    }
                    else
                    {
                        index++;
                    }
                    if (index > _array.Length - 1)
                        index = 0;
                    if (_array[index] == null)
                        throw new KeyNotFoundException();
                }
            }

        }

        public int GetVersion()
        {
            return _version;
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
                TKey[] array = new TKey[_count];

                int i = 0;
                foreach (var element in _array)
                {
                    array.SetValue(element.Key, i);
                    i++;
                }
                return array;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                TValue[] array = new TValue[_count];

                int i = 0;
                foreach (var element in _array)
                {
                    array.SetValue(element.Value, i);
                    i++;
                }
                return array;
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Add(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException();
            if (IsReadOnly)
                throw new NotSupportedException();
            var hash = Math.Abs(key.GetHashCode());
            var index = Math.Abs(hash % _array.Length);
            var kvp = new CoupleKeyValuePair(key, value);
            while (true)
            {
                if (_array[index] == null)
                {
                    _array[index] = kvp;
                    break;
                }
                else
                {
                    index++;
                }
                if (index > _array.Length - 1)
                    index = 0;
            }
            _count++;
            _version++;
        }

        public void Clear()
        {
            _array = null;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ContainsKey(item.Key);
        }

        public bool ContainsKey(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException();
            if (_array == null)
                throw new ArgumentNullException();
            int index = Math.Abs(key.GetHashCode() % _array.Length);
            while (true)
            {
                if (_array[index] == null)
                    return false;

                if (_array[index].Key.CompareTo(key) == 0) //?
                {

                    return true;
                }
                else
                {
                    index++;
                }
                if (index >= _array.Length)
                    index = 0;
                if (_array[index] == null)
                    return false;
            }

        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("array");

            if (array.Rank != 1)
                throw new ArgumentException("array Rank");

            if (arrayIndex < 0 || arrayIndex >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("array Length");
            int i = arrayIndex;
            foreach (var element in _array)
            {
                array.SetValue(element, i);
                i++;
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return new HashNumerator(this);
        }
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        public bool Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException();
            if (IsReadOnly)
                throw new NotSupportedException();
            int index = Math.Abs(key.GetHashCode() % _array.Length);
            while (true)
            {
                if (_array[index].Key.CompareTo(key) == 0)
                {
                    _array[index] = null;
                    return true;
                }
                else
                {
                    index++;
                }
                if (index > _array.Length - 1)
                    index = 0;
                if (_array[index] == null)
                    return false;
            }
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            if (key == null)
                throw new ArgumentNullException();
            int index = Math.Abs(key.GetHashCode() % _array.Length);
            while (true)
            {
                if (_array[index].Key.CompareTo(key) == 0)
                {
                    value = _array[index].Value;
                    return true;
                }
                else
                {
                    index++;
                }
                if (index > _array.Length - 1)
                    index = 0;
                if (_array[index] == null)
                {
                    value = default(TValue);
                    return false;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new HashNumerator(this);
        }


    }
}
