using System;

namespace Task1.Matrices.Exceptions
{
    public class MatrixException : Exception
    {
        public MatrixException() { }

        public MatrixException(string message) : base(message) { }

        public MatrixException(string message, Exception inner) : base(message, inner) { }
    }
}