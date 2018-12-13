using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Helper;
using DefaultDocumentation.Model.NonMember;

namespace DefaultDocumentation.Model.Base
{
    internal abstract class ADocItem
    {
        private readonly Lazy<string> _linkName;

        public ADocItem Parent { get; set; }

        public XElement Element { get; }
        public string Name { get; }
        public string Namespace => Parent?.FullName ?? Element.GetNamespace();
        public string FullName => $"{Namespace}.{Name}";
        public XElement Summary { get; }
        public RemarksItem Remarks { get; }
        public IEnumerable<ExceptionItem> Exceptions => Element.GetExceptions().Select(i => new ExceptionItem(this, i));
        public string LinkName => _linkName.Value;

        protected ADocItem(ADocItem parent, string name, XElement element)
        {
            _linkName = new Lazy<string>(() => FullName.CleanForLink());

            Element = element;
            Parent = parent;
            Name = name;
            Summary = Element.GetSummary() ?? Element;
            XElement remarksElement = Element.GetRemarks();
            Remarks = remarksElement != null ? new RemarksItem(this, remarksElement) : null;
        }

        protected ADocItem(XElement element, string name)
            : this(null, name, element)
        { }

        protected ADocItem(ADocItem parent, XElement element)
            : this(parent, element.GetName(), element)
        { }
    }
}
