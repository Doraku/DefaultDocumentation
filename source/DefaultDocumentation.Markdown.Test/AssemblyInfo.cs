using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.CSharp.Resolver;
using ICSharpCode.Decompiler.Documentation;

namespace DefaultDocumentation.Markdown
{
    public static class AssemblyInfo
    {
        private static readonly CSharpDecompiler _decompiler;
        private static readonly CSharpResolver _resolver;

        static AssemblyInfo()
        {
            _decompiler = new CSharpDecompiler(typeof(AssemblyInfo).Assembly.Location, new DecompilerSettings { ThrowOnAssemblyResolveErrors = false });
            _resolver = new CSharpResolver(_decompiler.TypeSystem);
        }

        public static T Get<T>(string id) => (T)IdStringProvider.FindEntity(id, _resolver);
    }
}
