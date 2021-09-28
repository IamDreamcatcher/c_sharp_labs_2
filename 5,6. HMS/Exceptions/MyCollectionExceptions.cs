using System;

namespace HMS.Exceptions
{
    class NoItemException<T> : Exception
    {
        public T Item { get; }
        public NoItemException(string message, T item) : base(message)
        {
            Item = item;
        }
    }
    class NullException : Exception
    {
        public NullException(string message) : base(message)
        {

        }
    }
}