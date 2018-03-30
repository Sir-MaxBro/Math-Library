using System;

namespace iMax.Mathematics.Exceptions
{
    public class MatricesNotMatchedException : ApplicationException
    {
        public MatricesNotMatchedException(string message)
            : base(message)
        { }
    }
}
