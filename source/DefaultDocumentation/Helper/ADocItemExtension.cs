using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Helper
{
    internal static class ADocItemExtension
    {
        public static string AsLinkTarget(this ADocItem item) => $"<a name='{item.LinkName}'></a>";

        public static string AsLink(this ADocItem item) => $"[{item.Name}](./{item.LinkName}.md '{item.FullName}')";

        public static string AsLinkWithTarget(this ADocItem item, string page = null) => $"[{item.Name}](./{page ?? item.Parent.LinkName}.md#{item.LinkName} '{item.FullName}')";

        public static string AsPageLink(this ADocItem item) => $"[{item.Name}](#{item.LinkName} '{item.FullName}')";
    }
}
