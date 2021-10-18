using System;
using System.Xml.Linq;

namespace DefaultDocumentation.Writer
{
    public abstract class ElementWriter
    {
        public string Name { get; }

        protected ElementWriter(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public abstract void Write(PageWriter writer, XElement element);
    }
}
