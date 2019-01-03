using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model
{
    internal sealed class NamespaceItem : AMemberItem
    {
        public const string Id = "N:";

        public override string Title => string.Empty;
        public override string Header => string.Empty;
        public override string FullName => Name;

        public NamespaceItem(string name)
            : base(null, name, null)
        { }
    }
}
