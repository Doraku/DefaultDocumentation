using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Model
{
    internal sealed class NamespaceItem : ADocItem
    {
        public const string Id = "N:";

        public override string FullName => Name;

        public NamespaceItem(string name)
            : base(null, name, null)
        { }
    }
}
