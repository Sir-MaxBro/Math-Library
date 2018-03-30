using System;

namespace iMax.Mathematics.Vectors
{
    /// <summary>
    /// Class is a two-dimensional Vector
    /// </summary>
    public class Vector2D
    {
        private double _x;
        private double _y;

        /// <summary>
        /// Initializes a new two-dimensional Vector
        /// </summary>
        /// <param name="x">Coordinate X</param>
        /// <param name="y">Coordinate Y</param>
        public Vector2D(double x, double y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Initializes a new two-dimensional Vector
        /// </summary>
        /// <param name="vector">The exicting instance of class</param>
        public Vector2D(Vector2D vector)
        {
            _x = vector._x;
            _y = vector._y;
        }

        /// <summary>
        /// Coordinate X
        /// </summary>
        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// Coordinate Y
        /// </summary>
        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// Magnitude of Vector
        /// </summary>
        public double Magnitude
        {
            get
            {
                return Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(_y, 2));
            }
        }

        /// <summary>
        /// Inclination of Vector
        /// </summary>
        public double Inclination 
        {
            get
            {
                return Math.Pow(Math.Tan(_y / _x), -1);
            }
        }

        /// <summary>
        /// Addition of two Vectors
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static Vector2D operator +(Vector2D vector1, Vector2D vector2)
        {
            return new Vector2D(vector1._x + vector2._x, vector1._y + vector2._y);
        }

        /// <summary>
        /// Addition of the Vector and the number
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector2D operator +(Vector2D vector, double value)
        {
            return new Vector2D(vector._x + value, vector._y + value);
        }

        /// <summary>
        /// Subtraction of two Vectors
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static Vector2D operator -(Vector2D vector1, Vector2D vector2)
        {
            return new Vector2D(vector1._x - vector2._x, vector1._y - vector2._y);
        }

        /// <summary>
        /// Subtraction of the Vector and the number
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector2D operator -(Vector2D vector, double value)
        {
            return new Vector2D(vector._x - value, vector._y - value);
        }

        /// <summary>
        /// Multiplication of the Vector and the number
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector2D operator *(Vector2D vector, double value)
        {
            return new Vector2D(vector._x * value, vector._y * value);
        }

        /// <summary>
        /// Division of the Vector and the number
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector2D operator /(Vector2D vector, double value)
        {
            return new Vector2D(vector._x / value, vector._y / value);
        }

        /// <summary>
        /// Shows are equal to whether the Vector
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static bool operator ==(Vector2D vector1, Vector2D vector2)
        {
            return vector1._x == vector2._x && vector1._y == vector2._y;
        }

        /// <summary>
        /// Shows are not equal to whether the Vector
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static bool operator !=(Vector2D vector1, Vector2D vector2)
        {
            return !(vector1 == vector2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector2D))
            {
                throw new InvalidCastException("Invalid cast object to Vector2D");
            }
            return this == obj as Vector2D;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns the Vector format (x; y)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("({0}; {1})", _x, _y);
        }
    }
}
