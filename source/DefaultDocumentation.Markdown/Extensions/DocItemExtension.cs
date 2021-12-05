using System.Linq;

namespace DefaultDocumentation.Models
{
    public static class DocItemExtension
    {
        public static string GetLongName(this DocItem item) => string.Join(".", item.GetParents().Skip(2).Select(p => p.Name).Concat(Enumerable.Repeat(item.Name, 1)));
    }
}
