using System;
using System.Text;
using iMax.Mathematics.Exceptions;

namespace iMax.Mathematics.Vectors
{
    /// <summary>
    /// Class is a N-dimensional Vector
    /// </summary>
    public class VectorN
    {
        private double[] _params;

        /// <summary>
        /// Initializes a new N-dimensional Vector
        /// </summary>
        /// <param name="source">Array of coordinates</param>
        public VectorN(params double[] source)
        {
            _params = source;
        }

        /// <summary>
        /// Initializes a new N-dimensional Vector
        /// </summary>
        /// <param name="vector">The exicting instance of class</param>
        public VectorN(VectorN vector)
        {
            _params = vector._params;
        }

        /// <summary>
        /// Coordinates of Vector
        /// </summary>
        public double[] Coordinates
        {
            get { return _params; }
        }

        /// <summary>
        /// Magnitude of Vector
        /// </summary>
        public double Magnitude
        {
            get
            {
                double sum = 0.0;
                for (int i = 0; i < _params.Length; i++)
                {
                    sum += Math.Pow(_params[i], 2);
                }
                return Math.Sqrt(sum);
            }
        }

        /// <summary>
        /// Addition of two Vectors
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static VectorN operator +(VectorN vector1, VectorN vector2)
        {
            if (vector1._params.Length != vector2._params.Length)
            {
                throw new VectorCoordinateCountException("Count of coordinate not are equals.");
            }
            double[] resultCoordinates = new double[vector1._params.Length];
            for (int i = 0; i < resultCoordinates.Length; i++)
            {
                resultCoordinates[i] += vector1._params[i] + vector2._params[i];
            }
            return new VectorN(resultCoordinates);
        }

        /// <summary>
        /// Addition of the Vector and the number
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static VectorN operator +(VectorN vector, double value)
        {
            VectorN resultVector = new VectorN(vector);
            for (int i = 0; i < resultVector._params.Length; i++)
            {
                resultVector._params[i] += value;
            }
            return resultVector;
        }

        /// <summary>
        /// Subtraction of two Vectors
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static VectorN operator -(VectorN vector1, VectorN vector2)
        {
            if (vector1._params.Length != vector2._params.Length)
            {
                throw new VectorCoordinateCountException("Count of coordinate not are equals.");
            }

            double[] resultCoordinates = new double[vector1._params.Length];

            for (int i = 0; i < resultCoordinates.Length; i++)
            {
                resultCoordinates[i] = vector1._params[i] - vector2._params[i];
            }

            return new VectorN(resultCoordinates);
        }

        /// <summary>
        /// Subtraction of the Vector and the number
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static VectorN operator -(VectorN vector, double value)
        {
            VectorN resultVector = new VectorN(vector);

            for (int i = 0; i < resultVector._params.Length; i++)
            {
                resultVector._params[i] -= value;
            }

            return resultVector;
        }

        /// <summary>
        /// Multiplication of the Vector and the number
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static VectorN operator *(VectorN vector, double value)
        {
            VectorN resultVector = new VectorN(vector);

            for (int i = 0; i < resultVector._params.Length; i++)
            {
                resultVector._params[i] *= value;
            }

            return resultVector;
        }

        /// <summary>
        /// Division of the Vector and the number
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static VectorN operator /(VectorN vector, double value)
        {
            VectorN resultVector = new VectorN(vector);
            for (int i = 0; i < resultVector._params.Length; i++)
            {
                resultVector._params[i] /= value;
            }
            return resultVector;
        }

        /// <summary>
        /// Shows are equal to whether the Vector
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static bool operator ==(VectorN vector1, VectorN vector2)
        {
            if (vector1._params.Length != vector2._params.Length)
            {
                throw new VectorCoordinateCountException("Count of coordinate not are equals.");
            }
            for (int i = 0; i < vector1._params.Length; i++)
            {
                if (vector1._params[i] != vector2._params[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Shows are not equal to whether the Vector
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static bool operator !=(VectorN vector1, VectorN vector2)
        {
            return !(vector1 == vector2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is VectorN))
            {
                throw new InvalidCastException("Invalid cast object to VectorN.");
            }
            return this == obj as VectorN;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns the Vector format (x1; x2; x3; ...; xn)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {           
            StringBuilder resultString = new StringBuilder();
            if (_params.Length != 0)
            {
                resultString.Append("(" + _params[0]);
                for (int i = 1; i < _params.Length; i++)
                {
                    resultString.Append("; " + _params[i]);
                }
                resultString.Append(")");
            }
            else
            {
                resultString.Append("VectorN is empty.");
            }
            
            return resultString.ToString();
        }
    }
}
