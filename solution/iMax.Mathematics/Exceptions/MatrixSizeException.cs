using System;

namespace iMax.Mathematics.Exceptions
{
    public class MatrixSizeException : ApplicationException
    {
        public MatrixSizeException(string message)
            : base(message)
        { }
    }
}
