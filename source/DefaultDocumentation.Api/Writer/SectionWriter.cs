using System;

namespace DefaultDocumentation.Writer
{
    public abstract class SectionWriter
    {
        public string Name { get; }

        protected SectionWriter(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public abstract void Write(PageWriter writer);
    }
}
