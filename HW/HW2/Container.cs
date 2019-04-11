using HW2.IntWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public class Container<TKey, TValue> where TKey : IntWrapperBase
    {
        private readonly int _arraMaxSize;

        private bool _isArrayStorage;
        private List<KeyValuePair<TKey, TValue>>[] _arrayStorage;
        private Dictionary<int, List<KeyValuePair<TKey, TValue>>> _dictionaryStorage;

        public Container(int arraMaxSize = 1000)
        {
            _arraMaxSize = arraMaxSize;
            _isArrayStorage = true;
            _arrayStorage = new List<KeyValuePair<TKey, TValue>>[0];
        }

        public void Add(TKey key, TValue value)
        {
            if (_isArrayStorage)
            {
                var isAdded = TryAddToArray(key, value);

                if (!isAdded)
                {
                    RebuildToDictionary();
                }
            }

            if (!_isArrayStorage)
            {
                AddToDictionary(key, value);
            }
        }

        private void AddToDictionary(TKey key, TValue value)
        {
            var dictionaryKey = Math.Abs(key.GetHashCode());

            if(!_dictionaryStorage.ContainsKey(dictionaryKey))
            {
                _dictionaryStorage[dictionaryKey] = new List<KeyValuePair<TKey, TValue>>();
            }

            _dictionaryStorage[dictionaryKey].Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        private void RebuildToDictionary()
        {
            _dictionaryStorage = _arrayStorage.Where(x => x != null).ToDictionary(x => x[0].Key.GetHashCode(), x => x);
            _arrayStorage = null;
            _isArrayStorage = false;
        }

        private bool TryAddToArray(TKey key, TValue value)
        {
            var index = Math.Abs(key.GetHashCode());

            if (_arrayStorage.Length <= index)
            {
                if (index > _arraMaxSize)
                {
                    return false;
                }

                var newArray = new List<KeyValuePair<TKey, TValue>>[index + 1];
                Array.Copy(_arrayStorage, newArray, _arrayStorage.Length);
                _arrayStorage = newArray;
            }

            var list = _arrayStorage[index] ?? new List<KeyValuePair<TKey, TValue>>();
            list.Add(new KeyValuePair<TKey, TValue>(key, value));
            _arrayStorage[index] = list;

            return true;
        }
    }
}
