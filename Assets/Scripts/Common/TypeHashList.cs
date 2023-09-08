using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Common
{
    /// <summary>
    ///     Structure for storing list element hashed by theirs types
    /// </summary>
    /// <typeparam name="T">Common type for all elements</typeparam>
    public sealed class TypeHashList<T> : IEnumerable<T>
    {
        private readonly Dictionary<Type, T> _hash = new();

        public TypeHashList()
        {
        }

        public TypeHashList(IEnumerable<T> list)
        {
            foreach (var element in list)
            {
                TryAdd(element);
            }
        }

        /// <summary>
        ///     Clears all data
        /// </summary>
        public void Clear()
        {
            _hash.Clear();
        }

        /// <summary>
        ///     Tries to get element of necessary type
        /// </summary>
        /// <typeparam name="TT">Type of the necessary object</typeparam>
        /// <returns>Object of selected type if found</returns>
        public TT Get<TT>() where TT : T =>
            (TT) _hash.First(t => t.Value is TT).Value;

        public IEnumerator<T> GetEnumerator() =>
            _hash.Values.GetEnumerator();

        /// <summary>
        ///     Tries to add new element
        /// </summary>
        /// <param name="value">Element to add</param>
        /// <returns>True if added</returns>
        public bool TryAdd(T value) =>
            _hash.TryAdd(value.GetType(), value);

        IEnumerator IEnumerable.GetEnumerator() =>
            GetEnumerator();
    }
}