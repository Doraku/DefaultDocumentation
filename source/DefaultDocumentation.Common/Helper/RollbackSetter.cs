namespace DefaultDocumentation.Helper
{
    internal readonly ref struct RollbackSetter<T>
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
