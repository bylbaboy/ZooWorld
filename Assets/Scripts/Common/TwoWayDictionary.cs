using System.Collections.Generic;
using System.Linq;

namespace Common
{
    /// <summary>
    ///     Two way Dictionary implementation
    /// </summary>
    /// <typeparam name="TKey">Key type</typeparam>
    /// <typeparam name="TValue">Value type</typeparam>
    public class TwoWayDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _keyToValue = new();
        private readonly Dictionary<TValue, TKey> _valueToKey = new();

        public bool ContainsKey(TKey key) =>
            _keyToValue.ContainsKey(key);

        public bool ContainsValue(TValue value) =>
            _valueToKey.ContainsKey(value);

        public List<TKey> GetKeys() =>
            _keyToValue.Keys.ToList();

        public List<TValue> GetValues() =>
            _valueToKey.Keys.ToList();

        public bool Remove(TKey key)
        {
            if (_keyToValue.TryGetValue(key, out var value))
            {
                _keyToValue.Remove(key);
                _valueToKey.Remove(value);
                return true;
            }
            return false;
        }

        public bool RemoveByValue(TValue value)
        {
            if (_valueToKey.TryGetValue(value, out var key))
            {
                _valueToKey.Remove(value);
                _keyToValue.Remove(key);
                return true;
            }
            return false;
        }

        public bool TryAdd(TKey key, TValue value)
        {
            var success1 = _keyToValue.TryAdd(key, value);
            var success2 = _valueToKey.TryAdd(value, key);
            return success1 && success2;
        }

        public bool TryGetKeyByValue(TValue value, out TKey key) =>
            _valueToKey.TryGetValue(value, out key);

        public bool TryGetValueByKey(TKey key, out TValue value) =>
            _keyToValue.TryGetValue(key, out value);
    }
}