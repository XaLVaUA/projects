using System;

namespace Task2.Polynomials.Exceptions
{
    public class PolynomialInvalidIndexException : PolynomialException
    {
        public PolynomialInvalidIndexException() { }

        public PolynomialInvalidIndexException(string message) : base(message) { }

        public PolynomialInvalidIndexException(string message, Exception inner) : base(message, inner) { }
    }
}