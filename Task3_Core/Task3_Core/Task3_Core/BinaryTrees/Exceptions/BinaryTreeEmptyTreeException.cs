using System;

namespace Task3_Core.BinaryTrees.Exceptions
{
    public class BinaryTreeEmptyTreeException : BinaryTreeException
    {
        public BinaryTreeEmptyTreeException()
        {
        }

        public BinaryTreeEmptyTreeException(string message) : base(message)
        {
        }

        public BinaryTreeEmptyTreeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}