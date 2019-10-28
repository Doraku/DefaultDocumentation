using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.NonMember;

namespace DefaultDocumentation.Model.Base
{
    internal abstract class AMemberItem : ANamedItem
    {
        public abstract string Title { get; }

        public RemarksItem Remarks { get; }
        public ExampleItem Example { get; }
        public ExceptionItem[] Exceptions { get; }

        protected AMemberItem(AMemberItem parent, string name, XElement element)
            : base(parent, name, element)
        {
            Remarks = RemarksItem.GetFrom(this);
            Example = ExampleItem.GetFrom(this);
            Exceptions = ExceptionItem.GetFrom(this);
        }

        protected AMemberItem(XElement element, string name)
            : this(null, name, element)
        { }

        protected AMemberItem(AMemberItem parent, XElement element)
            : this(parent, element.GetName(), element)
        { }

        public override void Write(Converter converter, DocWriter writer)
        {
            if (Exceptions?.Length > 0)
            {
                writer.WriteLine($"### {Exceptions[0].Header}");

                foreach (ExceptionItem exception in Exceptions)
                {
                    writer.Break();
                    exception.Write(converter, writer);
                }
            }

            Example?.Write(converter, writer);
            Remarks?.Write(converter, writer);
        }
    }
}
