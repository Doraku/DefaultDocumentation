using System;

namespace Dummy
{
    /// <summary>
    /// dummy
    /// </summary>
    public class DummyClass
    {
        /// <summary>
        /// dummy <c>test</c>
        /// linebreak
        /// <code>
        /// example
        /// yep
        /// </code>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <remarks>
        /// pouet
        /// </remarks>
        public class DummyNested<T>
        {
            /// <summary>
            /// dummy
            /// </summary>
            public event Action<T> Action;
        }

        /// <summary>
        /// dummy
        /// </summary>
        public int DummyField;

        /// <summary>
        /// dummy
        /// </summary>
        public int DummyProperty { get; }

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public dynamic this[int index]
        {
            get => index;
        }

        /// <summary>
        /// dummy
        /// </summary>
        public DummyClass()
        { }

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="pouet">kikoo</param>
        /// <typeparam name="T2">lol</typeparam>
        public void DummyMethod<T2>(T2 pouet)
        {
            var t = this;
            t += 0;
        }

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <param name="b">dummy</param>
        /// <returns>dummy</returns>
        public static DummyClass operator +(DummyClass a, int b) => a;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="c"></param>
        public static implicit operator int(DummyClass c) => 0;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="c"></param>
        public static explicit operator double(DummyClass c) => 0;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="c"></param>
        public static explicit operator DummyClass(int c) => null;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <param name="b">dummy</param>
        /// <returns>dummy</returns>
        public static bool operator ==(DummyClass a, DummyClass b) => true;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <param name="b">dummy</param>
        /// <returns>dummy</returns>
        public static bool operator !=(DummyClass a, DummyClass b) => false;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <param name="b">dummy</param>
        /// <returns>dummy</returns>
        public static bool operator -(DummyClass a, DummyClass b) => true;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <param name="b">dummy</param>
        /// <returns>dummy</returns>
        public static bool operator *(DummyClass a, DummyClass b) => true;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <param name="b">dummy</param>
        /// <returns>dummy</returns>
        public static bool operator /(DummyClass a, DummyClass b) => true;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <param name="b">dummy</param>
        /// <returns>dummy</returns>
        public static bool operator &(DummyClass a, DummyClass b) => true;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <param name="b">dummy</param>
        /// <returns>dummy</returns>
        public static bool operator |(DummyClass a, DummyClass b) => true;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <returns>dummy</returns>
        public static bool operator ~(DummyClass a) => true;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <param name="b">dummy</param>
        /// <returns>dummy</returns>
        public static bool operator ^(DummyClass a, DummyClass b) => true;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <returns>dummy</returns>
        public static DummyClass operator ++(DummyClass a) => a;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <returns>dummy</returns>
        public static DummyClass operator --(DummyClass a) => a;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <param name="b">dummy</param>
        /// <returns>dummy</returns>
        public static bool operator <(DummyClass a, DummyClass b) => false;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <param name="b">dummy</param>
        /// <returns>dummy</returns>
        public static bool operator >(DummyClass a, DummyClass b) => false;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <param name="b">dummy</param>
        /// <returns>dummy</returns>
        public static bool operator <=(DummyClass a, DummyClass b) => false;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <param name="b">dummy</param>
        /// <returns>dummy</returns>
        public static bool operator >=(DummyClass a, DummyClass b) => false;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <returns>dummy</returns>
        public static DummyClass operator -(DummyClass a) => a;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <returns>dummy</returns>
        public static DummyClass operator +(DummyClass a) => a;
        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <param name="b">dummy</param>
        /// <returns>dummy</returns>
        public static bool operator %(DummyClass a, DummyClass b) => false;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <param name="i">dummy</param>
        /// <returns>dummy</returns>
        public static DummyClass operator <<(DummyClass a, int i) => a;

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="a">dummy</param>
        /// <param name="i">dummy</param>
        /// <returns>dummy</returns>
        public static DummyClass operator >>(DummyClass a, int i) => a;
    }
}
