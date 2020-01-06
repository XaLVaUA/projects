using System;

namespace Task2.Polynomials.Exceptions
{
    public class PolynomialException : Exception
    {
        public PolynomialException() { }

        public PolynomialException(string message) : base(message) { }

        public PolynomialException(string message, Exception inner) : base(message, inner) { }
    }
}