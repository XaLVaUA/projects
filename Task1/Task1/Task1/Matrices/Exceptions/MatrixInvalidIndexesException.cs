using System;

namespace Task1.Matrices.Exceptions
{
    public class MatrixInvalidIndexesException : MatrixException
    {
        public MatrixInvalidIndexesException() { }

        public MatrixInvalidIndexesException(string message) : base(message) { }

        public MatrixInvalidIndexesException(string message, Exception inner) : base(message, inner) { }
    }
}