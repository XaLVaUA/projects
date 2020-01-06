using System;
using System.Collections.Generic;
using Task2.Polynomials.Exceptions;

namespace Task2.Polynomials
{
    public class Polynomial : ICloneable
    {
        private List<double> _coefficients;

        public int Power => _coefficients.Count - 1;

        public Polynomial()
        {
            _coefficients = new List<double> { 0 };
        }

        public Polynomial(int power) : this()
        {
            AddPower(0, power);
        }

        public bool AddPower(double coefficientValue = 0, int count = 1)
        {
            for (int i = 0; i < count; ++i)
            {
                _coefficients.Add(coefficientValue);
            }

            return true;
        }

        public bool RemovePower(int count = 1)
        {
            if (Power - count < 0)
            {
                throw new PolynomialSizeChangeException("Polynomial power: " + Power + ". Trying change power to: " + (Power - count) + ".");
            }

            for (int i = 0; i < count; ++i)
            {
                _coefficients.RemoveAt(Power);
            }

            return true;
        }

        public double GetCoefficient(int index)
        {
            if (!ValidIndex(index, this))
            {
                throw new PolynomialInvalidIndexException("Polynomial power: " + Power + ". Accessing index: " + index + ".");
            }

            return _coefficients[index];
        }

        public bool SetCoefficient(int index, double value)
        {
            if (!ValidIndex(index, this))
            {
                throw new PolynomialInvalidIndexException("Polynomial power: " + Power + ". Accessing index: " + index + ".");
            }

            _coefficients[index] = value;

            return true;
        }

        public object Clone()
        {
            var resultPolynomial = new Polynomial(Power);

            for (int i = 0, power = resultPolynomial.Power; i <= power; ++i)
            {
                resultPolynomial[i] = this[i];
            }

            return resultPolynomial;
        }

        public static Polynomial operator +(Polynomial left, Polynomial right)
        {
            Polynomial biggerPolynomial;
            Polynomial smallerPolynomial;

            if (left > right)
            {
                biggerPolynomial = left;
                smallerPolynomial = right;
            }
            else
            {
                biggerPolynomial = right;
                smallerPolynomial = left;
            }

            var resultPolynomial = new Polynomial(biggerPolynomial.Power);

            for (int i = 0, smallerPower = smallerPolynomial.Power; i <= smallerPower; ++i)
            {
                resultPolynomial[i] = left[i] + right[i];
            }

            for (int i = smallerPolynomial.Power + 1, biggerPower = biggerPolynomial.Power; i <= biggerPower; ++i)
            {
                resultPolynomial[i] = biggerPolynomial[i];
            }

            return resultPolynomial;
        }

        public static Polynomial operator -(Polynomial left, Polynomial right)
        {
            Polynomial biggerPolynomial;
            Polynomial smallerPolynomial;
            var negativeRight = -right;

            if (left > right)
            {
                biggerPolynomial = left;
                smallerPolynomial = right;
            }
            else
            {
                biggerPolynomial = negativeRight;
                smallerPolynomial = left;
            }

            var resultPolynomial = new Polynomial(biggerPolynomial.Power);

            for (int i = 0, smallerPower = smallerPolynomial.Power; i <= smallerPower; ++i)
            {
                resultPolynomial[i] = left[i] + negativeRight[i];
            }

            for (int i = smallerPolynomial.Power + 1, biggerPower = biggerPolynomial.Power; i <= biggerPower; ++i)
            {
                resultPolynomial[i] = biggerPolynomial[i];
            }

            return resultPolynomial;
        }

        public static Polynomial operator *(Polynomial left, Polynomial right)
        {
            var resultPolynomial = new Polynomial(left.Power + right.Power);

            for (int i = 0, leftPower = left.Power; i <= leftPower; ++i)
            {
                for (int j = 0, rightPower = right.Power; j <= rightPower; ++j)
                {
                    resultPolynomial[i + j] += left[i] * right[j];
                }
            }

            return resultPolynomial;
        }

        public static Polynomial operator -(Polynomial polynomial)
        {
            var resultPolynomial = (Polynomial)polynomial.Clone();

            for (int i = 0, power = resultPolynomial.Power; i <= power; ++i)
            {
                resultPolynomial[i] = -resultPolynomial[i];
            }

            return resultPolynomial;
        }

        public static Polynomial operator ++(Polynomial polynomial)
        {
            var resultPolynomial = (Polynomial)polynomial.Clone();
            resultPolynomial.AddPower();
            return resultPolynomial;
        }

        public static Polynomial operator --(Polynomial polynomial)
        {
            var resultPolynomial = (Polynomial)polynomial.Clone();
            resultPolynomial.RemovePower();
            return resultPolynomial;
        }

        public static bool operator >(Polynomial left, Polynomial right)
        {
            return left.Power > right.Power;
        }

        public static bool operator <(Polynomial left, Polynomial right)
        {
            return left.Power < right.Power;
        }

        public double this[int index]
        {
            get => GetCoefficient(index);

            set => SetCoefficient(index, value);
        }

        public static bool ValidIndex(int index, Polynomial polynomial)
        {
            return !((index < 0) || (index > polynomial.Power));
        }
    }
}