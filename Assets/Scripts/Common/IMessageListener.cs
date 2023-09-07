namespace Common
{
    /// <summary>
    ///     Implement to have an ability to listen messages of provided type
    ///     You need to subscribe to receive the messages
    /// </summary>
    /// <typeparam name="T">Message type</typeparam>
    public interface IMessageListener<in T>
    {
        void OnMessage(T message);
    }
}