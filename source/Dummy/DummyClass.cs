﻿using System;
using System.Threading.Tasks;

namespace Dummy
{
    /// <summary ignorelinebreak="true">
    /// pouet
    /// pouet
    /// pouet
    /// </summary>
    public enum DummyEnum
    {
        /// <summary>
        /// yay
        /// </summary>
        Kikoo,
        /// <summary>
        /// uo
        /// </summary>
        Lol
    }

    /// <summary>
    /// pouet<br />pouet<br/>pouet<b>kapoue</b>.
    /// <list type="bullet">
    /// <item>pouet</item>
    /// <item>pouet</item>
    /// </list>
    /// <list type="number">
    /// <item>pouet</item>
    /// <item>pouet</item>
    /// </list>
    /// <list type="table">
    /// <listheader>
    /// <description>kikoo</description>
    /// <description>lol</description>
    /// </listheader>
    /// <item>
    /// <description>pouet</description>
    /// <description>pouet</description>
    /// </item>
    /// <item>
    /// <description>pouet</description>
    /// <description>pouet</description>
    /// </item>
    /// </list>
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
        /// <note type="note">Fizz</note>
        /// <note type="C#">Buzz</note>
        /// <note type="VB.NET">Foo</note>
        /// <note type="security">
        /// <para>Bar</para>
        /// <para>Testo
        /// Testus</para>
        /// </note>
        /// <list type="bullet">
        /// <item>
        /// <para>Abc</para>
        /// <note>Def</note>
        /// <note type="security">Ghi</note>
        /// </item>
        /// </list>
        /// <note>
        /// <code language="csharp">
        /// test
        /// </code>
        /// <list type="bullet">
        /// <item>
        /// <para>Abc</para>
        /// <note>Def</note>
        /// <note type="security">Ghi</note>
        /// </item>
        /// <item>
        /// <para>Item in a list that is in a note</para>
        /// </item>
        /// </list>
        /// <list type="table">
        /// <listheader>
        /// <description></description>
        /// <description>A</description>
        /// <description>a</description>
        /// </listheader>
        /// <item>
        /// <description>A</description>
        /// <description>AA</description>
        /// <description>Aa</description>
        /// </item>
        /// <item>
        /// <description>a</description>
        /// <description>Aa</description>
        /// <description>aa</description>
        /// </item>
        /// </list>
        /// </note>
        /// </remarks>        
        /// <code source=""/>
        public class DummyNested<T>
        {
            /// <summary>
            /// dummy
            /// </summary>
            public event Action<T> Action;
        }

        /// <summary>
        /// dummy record
        /// </summary>
        public record DummyRecord(int Id, string Value);

        public unsafe delegate*<DummyClass, object, int> DummyFunctionPointer;

        /// <summary>
        /// dummy method with function pointer parameter
        /// </summary>
        /// <param name="_">dummy</param>
        /// <param name="function">dummy</param>
        public unsafe void DummyMethodFunctionPointer(int _, delegate*<void> function) => function();

        /// <summary>
        /// Dummy
        /// </summary>
        public const int ConstField = 42;

        /// <summary>
        /// dummy
        /// </summary>
        public static int DummyField;

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
        /// <typeparam name="T">dummy</typeparam>
        /// <param name="value">dummy</param>
        /// <returns>dummy</returns>
        public async Task<dynamic> DummyAsync<T>(T value)
        {
            await Task.Delay(0);
            return value;
        }

        /// <summary>
        /// dummy
        /// </summary>
        public DummyClass()
        { }

        /// <summary>
        /// dummy
        /// </summary>
        /// <param name="p">dummy</param>
        /// <returns>dummy</returns>
        public unsafe int** Unsafe(void* p) => (int**)&p;

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
        public TaskContinuationOptions DummyOption { get; }

        /// <summary>
        /// dummy
        /// </summary>
        /// <typeparam name="T2">dummy</typeparam>
        /// <param name="pouet">dummy</param>
        /// <returns>dummy</returns>
        public (int, DummyClass) DummyTuple<T2>(T2 pouet) => (42, this);

        /// <summary>
        /// dummy
        /// </summary>
        /// <typeparam name="T2">dummy</typeparam>
        /// <param name="pouet">dummy</param>
        /// <returns>dummy</returns>
        public ValueTuple<int, DummyClass> DummyExplicitTuple<T2>(T2 pouet) => (42, this);

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
