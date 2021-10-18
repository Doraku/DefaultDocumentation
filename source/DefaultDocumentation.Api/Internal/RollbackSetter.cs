using System;

namespace DefaultDocumentation.Helper
{
    internal class RollbackSetter<T> : IDisposable
    {
        public delegate ref T Getter();

        private readonly Getter _getter;
        private readonly T _previousValue;

        public RollbackSetter(Getter getter, T newValue)
        {
            _getter = getter;
            _previousValue = _getter();
            _getter() = newValue;
        }

        public void Dispose()
        {
            _getter() = _previousValue;
        }
    }
}
