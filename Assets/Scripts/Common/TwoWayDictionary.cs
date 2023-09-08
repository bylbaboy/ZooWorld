using System.Collections.Generic;
using System.Linq;
using Modules.Animals;

namespace Common
{
    public class TwoWayDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _keyToValue = new();
        private readonly Dictionary<TValue, TKey> _valueToKey = new();

        public bool TryAdd(TKey key, TValue value)
        {
            var success1 = _keyToValue.TryAdd(key, value);
            var success2 = _valueToKey.TryAdd(value, key);
            return success1 && success2;
        }

        public bool TryGetValueByKey(TKey key, out TValue value)
        {
            return _keyToValue.TryGetValue(key, out value);
        }

        public bool TryGetKeyByValue(TValue value, out TKey key)
        {
            return _valueToKey.TryGetValue(value, out key);
        }

        public bool ContainsKey(TKey key)
        {
            return _keyToValue.ContainsKey(key);
        }

        public bool ContainsValue(TValue value)
        {
            return _valueToKey.ContainsKey(value);
        }

        public bool Remove(TKey key)
        {
            if (_keyToValue.TryGetValue(key, out TValue value))
            {
                _keyToValue.Remove(key);
                _valueToKey.Remove(value);
                return true;
            }
            return false;
        }

        public bool RemoveByValue(TValue value)
        {
            if (_valueToKey.TryGetValue(value, out TKey key))
            {
                _valueToKey.Remove(value);
                _keyToValue.Remove(key);
                return true;
            }
            return false;
        }
        
        public List<TKey> GetKeys() =>
            _keyToValue.Keys.ToList();

        public List<TValue> GetValues() =>
            _valueToKey.Keys.ToList();
    }
}