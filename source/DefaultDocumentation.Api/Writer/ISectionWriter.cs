namespace DefaultDocumentation.Writer
{
    public interface ISectionWriter
    {
        string Name { get; }

        void Write(PageWriter writer);
    }
}
