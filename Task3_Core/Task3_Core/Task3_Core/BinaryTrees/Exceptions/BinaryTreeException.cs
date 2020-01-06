using System;

namespace Task3_Core.BinaryTrees.Exceptions
{
    public class BinaryTreeException : Exception
    {
        public BinaryTreeException()
        {
        }

        public BinaryTreeException(string message) : base(message)
        {
        }

        public BinaryTreeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}