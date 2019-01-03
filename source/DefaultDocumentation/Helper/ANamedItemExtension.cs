using DefaultDocumentation.Model.Base;

namespace DefaultDocumentation.Helper
{
    internal static class ANamedItemExtension
    {
        public static string AsLinkTarget(this ANamedItem item) => $"<a name='{item.LinkName}'></a>";

        public static string AsLink(this ANamedItem item) => $"[{item.Name}](./{item.LinkName}.md '{item.FullName}')";

        public static string AsLinkWithTarget(this ANamedItem item, string page = null) => $"[{item.Name}](./{page ?? item.Parent.LinkName}.md#{item.LinkName} '{item.FullName}')";

        public static string AsPageLink(this ANamedItem item) => $"[{item.Name}](#{item.LinkName} '{item.FullName}')";
    }
}
