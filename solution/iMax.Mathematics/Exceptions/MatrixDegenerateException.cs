using System;

namespace iMax.Mathematics.Exceptions
{
    public class MatrixDegenerateException : ApplicationException
    {
        public MatrixDegenerateException(string message)
            : base(message)
        { }
    }
}
