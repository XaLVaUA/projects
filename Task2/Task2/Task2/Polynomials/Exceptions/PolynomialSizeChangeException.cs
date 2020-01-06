using System;

namespace Task2.Polynomials.Exceptions
{
    public class PolynomialSizeChangeException : PolynomialException
    {
        public PolynomialSizeChangeException() { }

        public PolynomialSizeChangeException(string message) : base(message) { }

        public PolynomialSizeChangeException(string message, Exception inner) : base(message, inner) { }
    }
}