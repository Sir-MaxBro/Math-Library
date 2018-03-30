using System.Collections;
using iMax.Mathematics.Exceptions;

namespace iMax.Mathematics
{
    public class Matrix : IEnumerable
    {
        private double[,] _matrix;
        public Matrix(int row, int column)
        {
            _matrix = new double[row, column];
        }

        public Matrix(Matrix matrix)
        {
            _matrix = matrix._matrix;
        }

        public Matrix(double[,] source)
        {
            _matrix = source;           
        }

        public double this[int i, int j]
        {
            get
            {
                return _matrix[i, j];
            }
            set
            {
                _matrix[i, j] = value;
            }
        }

        public int RowCount
        {
            get { return _matrix.GetLength(0); }
        }

        public int ColumnCount
        {
            get { return _matrix.GetLength(1); }
        }

        public IEnumerator GetEnumerator()
        {
            return _matrix.GetEnumerator();
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.ColumnCount != matrix2.ColumnCount || matrix1.RowCount != matrix2.RowCount)
            {
                throw new MatricesDifferentSizeException("Matrices of different size.");
            }

            double[,] resultMatrix = new double[matrix1.RowCount, matrix1.ColumnCount];

            for (int i = 0; i < matrix1.RowCount; i++)
            {
                for (int j = 0; j < matrix1.ColumnCount; j++)
                {
                    resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return new Matrix(resultMatrix);
        }

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.ColumnCount != matrix2.ColumnCount || matrix1.RowCount != matrix2.RowCount)
            {
                throw new MatricesDifferentSizeException("Matrices of different size.");
            }

            double[,] resultMatrix = new double[matrix1.RowCount, matrix1.ColumnCount];

            for (int i = 0; i < matrix1.RowCount; i++)
            {
                for (int j = 0; j < matrix1.ColumnCount; j++)
                {
                    resultMatrix[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return new Matrix(resultMatrix);
        }

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.ColumnCount != matrix2.RowCount || matrix1.RowCount != matrix2.ColumnCount)
            {
                throw new MatricesNotMatchedException("Matrices are not matched.");
            }
            double[,] resultMatrix = new double[matrix1.RowCount, matrix2.ColumnCount];
            for (int i = 0; i < matrix1.RowCount; i++)
            {
                for (int j = 0; j < matrix1.ColumnCount; j++)
                {
                    for (int k = 0; k < matrix1.ColumnCount; k++)
                    {
                        resultMatrix[i, j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
            return new Matrix(resultMatrix);
        }

        public static Matrix operator *(Matrix matrix, double value)
        {
            double[,] resultMatrix = new double[matrix.RowCount, matrix.ColumnCount];
            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    resultMatrix[i, j] = matrix[i, j] * value;
                }
            }
            return new Matrix(resultMatrix);
        }

        public Matrix Transpose()
        {
            double[,] resultMatrix = new double[this.ColumnCount, this.RowCount];
            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = 0; j < this.ColumnCount; j++)
                {
                    resultMatrix[j, i] = this[i, j];
                }
            }
            return new Matrix(resultMatrix);
        }

        public Matrix Pow(int degree)
        {
            Matrix matrix = new Matrix(_matrix);
            for (int i = 1; i < degree; i++)
            {
                matrix *= this;
            }
            return matrix;
        }

        public double Determinant
        {
            get
            {
                if (this.ColumnCount != this.RowCount)
                {
                    throw new MatrixSizeException("The number of rows and columns of the matrix is different.");
                }
                return GetDeterminant(this._matrix);
            }
        }

        private double GetDeterminant(double[,] matrix)
        {    
            if (matrix.Length == 1)
            {
                return matrix[0, 0];
            }
            else if (matrix.Length == 4)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }

            double sign = 1;
            double determinant = 0.0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                double[,] minor = GetMinor(matrix, i);
                determinant += sign * matrix[0, i] * GetDeterminant(minor);
                sign = -sign;
            }
            return determinant;
        }

        private double[,] GetMinor(double[,] matrix, int columnNumber)
        {
            double[,] result = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 0, col = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == columnNumber)
                        continue;
                    result[i - 1, col] = matrix[i, j];
                    col++;
                }
            }
            return result;
        }
    }
}
