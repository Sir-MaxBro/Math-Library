using System;

namespace iMax.Mathematics.Exceptions
{
    public class MatricesDifferentSizeException : ApplicationException
    {
        public MatricesDifferentSizeException(string message)
            : base(message)
        { }
    }
}
