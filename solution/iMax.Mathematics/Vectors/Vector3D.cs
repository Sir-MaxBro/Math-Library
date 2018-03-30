using System;

namespace iMax.Mathematics.Vectors
{
    /// <summary>
    /// Class is a three-dimensional Vector
    /// </summary>
    public class Vector3D
    {
        private double _x;
        private double _y;
        private double _z;

        /// <summary>
        /// Initializes a new three-dimensional Vector
        /// </summary>
        /// <param name="x">Coordinate X</param>
        /// <param name="y">Coordinate Y</param>
        /// <param name="z">Coordinate Z</param>
        public Vector3D(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        /// <summary>
        /// Initializes a new three-dimensional Vector
        /// </summary>
        /// <param name="vector">The exicting instance of class</param>
        public Vector3D(Vector3D vector)
        {
            _x = vector._x;
            _y = vector._y;
            _z = vector._z;
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
        /// Coordinate Z
        /// </summary>
        public double Z
        {
            get { return _z; }
            set { _z = value; }
        }

        /// <summary>
        /// Magnitude of Vector
        /// </summary>
        public double Magnitude
        {
            get
            {
                return Math.Sqrt(Math.Pow(_x, 2) + Math.Pow(_y, 2) + Math.Pow(_z, 2));
            }
        }

        /// <summary>
        /// Inclination of Vector
        /// </summary>
        public double Inclination
        {
            get
            {
                return Math.Acos(_z / Magnitude);
            }
        }

        /// <summary>
        /// Azimuth of Vector
        /// </summary>
        public double Azimuth
        {
            get
            {
                return Math.Atan(_y / _x);
            }
        }

        /// <summary>
        /// Addition of two Vectors
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static Vector3D operator +(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1._x + vector2._x, vector1._y + vector2._y, vector1._z + vector2._z);
        }

        /// <summary>
        /// Addition of the Vector and the number
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector3D operator +(Vector3D vector, double value)
        {
            return new Vector3D(vector._x + value, vector._y + value, vector._z + value);
        }

        /// <summary>
        /// Subtraction of two Vectors
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static Vector3D operator -(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1._x - vector2._x, vector1._y - vector2._y, vector1._z - vector2._z);
        }

        /// <summary>
        /// Subtraction of the Vector and the number
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector3D operator -(Vector3D vector, double value)
        {
            return new Vector3D(vector._x - value, vector._y - value, vector._z - value);
        }

        /// <summary>
        /// Multiplication of the Vector and the number
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector3D operator *(Vector3D vector, double value)
        {
            return new Vector3D(vector._x * value, vector._y * value, vector._z * value);
        }

        /// <summary>
        /// Division of the Vector and the number
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Vector3D operator /(Vector3D vector, double value)
        {
            return new Vector3D(vector._x / value, vector._y / value, vector._z / value);
        }

        /// <summary>
        /// Shows are equal to whether the Vector
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static bool operator ==(Vector3D vector1, Vector3D vector2)
        {
            return vector1._x == vector2._x && vector1._y == vector2._y && vector1._z == vector2._z;
        }

        /// <summary>
        /// Shows are not equal to whether the Vector
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static bool operator !=(Vector3D vector1, Vector3D vector2)
        {
            return !(vector1 == vector2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector3D))
            {
                throw new InvalidCastException("Invalid cast object to Vector3D");
            }
            return this == obj as Vector3D;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Returns the Vector format (x; y; z)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("({0}; {1}; {2})", _x, _y, _z);
        }
    }
}
