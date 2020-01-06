using System;

namespace Task1.Matrices.Exceptions
{
    public class MatrixSizeException : MatrixException
    {
        public MatrixSizeException() { }

        public MatrixSizeException(string message) : base(message) { }

        public MatrixSizeException(string message, Exception inner) : base(message, inner) { }
    }
}