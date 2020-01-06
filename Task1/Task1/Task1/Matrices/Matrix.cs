using System;
using System.Collections.Generic;
using Task1.Matrices.Exceptions;

namespace Task1.Matrices
{
    [Serializable]
    public class Matrix : ICloneable
    { 
        private List<List<double>> _elements;

        public int Rows => _elements.Count;

        public int Cols => _elements[0].Count;

        public Matrix()
        {
            _elements = new List<List<double>> { new List<double> { 0 } };
        }

        public Matrix(int i, int j) : this()
        {
            if (i < 1 || j < 1)
            {
                throw new MatrixInvalidIndexesException("Trying to create matrix with size: [" + i + ", " + j + "].");
            }

            AddRows(i - 1);
            AddColumns(j - 1);
        }

        public bool AddRows(int count = 1)
        {
            if (count < 1)
            {
                throw new MatrixException();
            }

            for (int k = 0; k < count; ++k)
            {
                _elements.Add(new List<double>());
                var cols = _elements[Rows - 1];
                for (int i = 0, size = Cols; i < size; ++i)
                {
                    cols.Add(0);
                }
            }

            return true;
        }

        public bool RemoveRow(int i)
        {
            if (!ValidRowIndex(i, this))
            {
                throw new MatrixInvalidIndexesException("Matrix size: [" + Rows + ", " + Cols + "]. Accessing i = " + i + ".");
            }

            if (Rows - i < 1)
            {
                throw new MatrixSizeChangeException("Matrix size: [" + Rows + ", " + Cols + "]. Trying change size to: [" + (Rows - i) + ", " + Cols + "].");
            }

            _elements.RemoveAt(i - 1);

            return true;
        }

        public bool AddColumns(int count = 1)
        {
            if (count < 1)
            {
                throw new MatrixException();
            }

            for (int k = 0; k < count; ++k)
            {
                for (int i = 0, size = Rows; i < size; ++i)
                {
                    _elements[i].Add(0);
                }
            }

            return true;
        }

        public bool RemoveColumn(int j)
        {
            if (!ValidColumnIndex(j, this))
            {
                throw new MatrixInvalidIndexesException("Matrix size: [" + Rows + ", " + Cols + "]. Accessing j = " + j + ".");
            }

            if (Cols - j < 1)
            {
                throw new MatrixSizeChangeException("Matrix size: [" + Rows + ", " + Cols + "]. Trying change size to: [" + Rows + ", " + (Cols - j) + "].");
            }

            --j;
            for (int i = 0, n = Rows; i < n; ++i)
            {
                _elements[i].RemoveAt(j);
            }

            return true;
        }

        public double GetElement(int i, int j)
        {
            if (!ValidIndexes(i, j, this))
            {
                throw new MatrixInvalidIndexesException("Matrix size: [" + Rows + ", " + Cols + "]. Accessing: [" + i + ", " + j + "].");
            }

            return _elements[i - 1][j - 1];
        }

        public bool SetElement(int i, int j, double value)
        {
            if (!ValidIndexes(i, j, this))
            {
                throw new MatrixInvalidIndexesException("Matrix size: [" + Rows + ", " + Cols + "]. Accessing: [" + i + ", " + j + "].");
            }

            _elements[i - 1][j - 1] = value;

            return true;
        }

        public bool AddMatrix(Matrix matrix)
        {
            if (!EqualSize(this, matrix))
            {
                throw new MatrixSizeException("Matrices have different size");
            }

            for (int i = 1, n = Rows; i <= n; ++i)
            {
                for (int j = 1, m = Cols; j <= m; ++j)
                {
                    this[i, j] += matrix.GetElement(i, j);
                }
            }

            return true;
        }

        public bool SubtractMatrix(Matrix matrix)
        {
            if (!EqualSize(this, matrix))
            {
                throw new MatrixSizeException("Matrices have different size");
            }

            for (int i = 1, n = Rows; i <= n; ++i)
            {
                for (int j = 1, m = Cols; j <= m; ++j)
                {
                    this[i, j] -= matrix[i, j];
                }
            }

            return true;
        }

        public bool Multiply(double constant)
        {
            for (int i = 1, n = Rows; i <= n; ++i)
            {
                for (int j = 1, m = Cols; j <= m; ++j)
                {
                    this[i, j] *= constant;
                }
            }

            return true;
        }

        public object Clone()
        {
            var resultMatrix = new Matrix(Rows, Cols);

            for (int i = 1, n = Rows; i <= n; ++i)
            {
                for (int j = 1, m = Cols; j <= m; ++j)
                {
                    resultMatrix[i, j] = this[i, j];
                }
            }

            return resultMatrix;
        }

        public static Matrix operator +(Matrix left, Matrix right)
        {
            if (!EqualSize(left, right))
            {
                throw new MatrixSizeException("Matrices have different size");
            }

            var resultMatrix = (Matrix)left.Clone();

            for (int i = 1, n = resultMatrix.Rows; i <= n; ++i)
            {
                for (int j = 1, m = resultMatrix.Cols; j <= m; ++j)
                {
                    resultMatrix[i, j] += right[i, j];
                }
            }

            return resultMatrix;
        }

        public static Matrix operator -(Matrix left, Matrix right)
        {
            if (!EqualSize(left, right))
            {
                throw new MatrixSizeException("Matrices have different size");
            }

            var resultMatrix = (Matrix)left.Clone();

            for (int i = 1, n = resultMatrix.Rows; i <= n; ++i)
            {
                for (int j = 1, m = resultMatrix.Cols; j <= m; ++j)
                {
                    resultMatrix[i, j] -= right[i, j];
                }
            }

            return resultMatrix;
        }

        public static Matrix operator *(Matrix left, Matrix right)
        {
            var resultMatrix = new Matrix();
            resultMatrix.AddRows(left.Rows - 1);
            resultMatrix.AddColumns(right.Cols - 1);

            for (int i = 1, n = resultMatrix.Rows; i <= n; ++i)
            {
                for (int j = 1, m = resultMatrix.Cols; j <= m; ++j)
                {
                    for (int k = 1, size = right.Rows; k <= size; ++k)
                    {
                        resultMatrix[i, j] += left[i, k] * right[k, j];
                    }
                }
            }

            return resultMatrix;
        }

        public static Matrix operator *(Matrix matrix, double constant)
        {
            var resultMatrix = (Matrix)matrix.Clone();

            for (int i = 1, n = resultMatrix.Rows; i <= n; ++i)
            {
                for (int j = 1, m = resultMatrix.Cols; j <= m; ++j)
                {
                    resultMatrix[i, j] *= constant;
                }
            }

            return resultMatrix;
        }

        public static Matrix operator *(double constant, Matrix matrix)
        {
            return matrix * constant;
        }

        public double this[int i, int j]
        {
            get => GetElement(i, j);

            set => SetElement(i, j, value);
        }

        public static bool ValidRowIndex(int i, Matrix matrix)
        {
            return !((i < 1) || (i > matrix.Rows));
        }

        public static bool ValidColumnIndex(int j, Matrix matrix)
        {
            return !((j < 1) || (j > matrix.Cols));
        }

        public static bool ValidIndexes(int i, int j, Matrix matrix)
        {
            return ValidRowIndex(i, matrix) && ValidColumnIndex(j, matrix);
        }

        public static bool EqualSize(Matrix left, Matrix right)
        {
            return (left.Rows == right.Rows) && (left.Cols == right.Cols);
        }

        protected bool Equals(Matrix other)
        {
            return Equals(_elements, other._elements);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Matrix) obj);
        }

        public override int GetHashCode()
        {
            return (_elements != null ? _elements.GetHashCode() : 0);
        }
    }
}