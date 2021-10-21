namespace DefaultDocumentation.Writers
{
    public interface ISectionWriter
    {
        string Name { get; }

        void Write(IWriter writer);
    }
}
