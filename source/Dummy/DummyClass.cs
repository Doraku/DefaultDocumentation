using System;

namespace Dummy
{
    /// <summary>
    /// dummy
    /// </summary>
    public class DummyClass
    {
        /// <summary>
        /// dummy
        /// </summary>
        /// <typeparam name="T"></typeparam>
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
        public int this[int index]
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
        public void DummyMethod()
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

        ///// <summary>
        ///// dummy
        ///// </summary>
        ///// <param name="c"></param>
        //public static implicit operator int(DummyClass c) => 0;

        ///// <summary>
        ///// dummy
        ///// </summary>
        ///// <param name="c"></param>
        //public static explicit operator double(DummyClass c) => 0;

        /// <summary>
        /// 
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
    }
}
