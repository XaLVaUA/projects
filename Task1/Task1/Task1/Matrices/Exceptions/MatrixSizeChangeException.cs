using System;

namespace Task1.Matrices.Exceptions
{
    public class MatrixSizeChangeException : MatrixSizeException
    {
        public MatrixSizeChangeException() { }

        public MatrixSizeChangeException(string message) : base(message) { }

        public MatrixSizeChangeException(string message, Exception inner) : base(message, inner) { }
    }
}