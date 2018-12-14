using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.NonMember;

namespace DefaultDocumentation.Model.Base
{
    internal abstract class ADocItem : ATextItem
    {
        private readonly Lazy<string> _linkName;

        public string Name { get; }
        public string Namespace => Parent?.FullName ?? Element.GetNamespace();
        public virtual string FullName => $"{Namespace}.{Name}";
        public RemarksItem Remarks
        {
            get
            {
                XElement remarksElement = Element.GetRemarks();
                return remarksElement != null ? new RemarksItem(this, remarksElement) : null;
            }
        }
        public ExampleItem Example
        {
            get
            {
                XElement exampleElement = Element.GetRemarks();
                return exampleElement != null ? new ExampleItem(this, exampleElement) : null;
            }
        }
        public IEnumerable<ExceptionItem> Exceptions => Element.GetExceptions().Select(i => new ExceptionItem(this, i));
        public string LinkName => _linkName.Value;

        protected ADocItem(ADocItem parent, string name, XElement element)
            : base(parent, element)
        {
            _linkName = new Lazy<string>(() => FullName.CleanForLink());

            Name = name;
        }

        protected ADocItem(XElement element, string name)
            : this(null, name, element)
        { }

        protected ADocItem(ADocItem parent, XElement element)
            : this(parent, element.GetName(), element)
        { }
    }
}
