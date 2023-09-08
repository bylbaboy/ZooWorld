using System;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    /// <summary>
    ///     Allows to send and receive messages of any types
    /// </summary>
    public static class Messenger
    {
        private static readonly Dictionary<Type, List<object>> Listeners = new();

        /// <summary>
        ///     Removes all listeners
        /// </summary>
        public static void Clear()
        {
            Listeners.Clear();
        }

        /// <summary>
        ///     Send provided message to all listeners
        /// </summary>
        /// <param name="message">Message to send</param>
        /// <typeparam name="T">Type of the message</typeparam>
        public static void Send<T>(in T message)
        {
            if (!Listeners.TryGetValue(typeof(T), out var listeners))
            {
                return;
            }
            try
            {
                for (var i = listeners.Count - 1; i >= 0; i--)
                {
                    ((IMessageListener<T>) listeners[i]).OnMessage(message);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        /// <summary>
        ///     Subscribes the listener to the messages of provided type
        /// </summary>
        /// <param name="listener">Listener to subscribe</param>
        /// <typeparam name="T">Message type to subscribe to</typeparam>
        public static void Subscribe<T>(in IMessageListener<T> listener)
        {
            if (Listeners.TryGetValue(typeof(T), out var listeners))
            {
                listeners.Insert(0, listener);
            }
            else
            {
                Listeners.Add(typeof(T), new List<object> {listener});
            }
        }

        /// <summary>
        ///     Unsubscribes the listener from the messages of provided type
        /// </summary>
        /// <param name="listener">Listener to unsubscribe</param>
        /// <typeparam name="T">Message type to unsubscribe from</typeparam>
        public static void Unsubscribe<T>(in IMessageListener<T> listener)
        {
            if (!Listeners.TryGetValue(typeof(T), out var listeners))
            {
                return;
            }

            listeners.Remove(listener);
        }
    }
}