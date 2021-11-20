namespace DefaultDocumentation.Api
{
    public interface ISection
    {
        string Name { get; }

        void Write(IWriter writer);
    }
}
