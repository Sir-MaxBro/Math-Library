using System;

namespace iMax.Mathematics.Exceptions
{
    public class VectorCoordinateCountException : ApplicationException
    {
        public VectorCoordinateCountException(string message)
            : base(message)
        { }
    }
}
