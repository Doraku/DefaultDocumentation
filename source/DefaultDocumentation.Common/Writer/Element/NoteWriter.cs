using System.Xml.Linq;
using DefaultDocumentation.Helper;

namespace DefaultDocumentation.Writer.Element
{
    internal sealed class NoteWriter : ElementWriter
    {
        public NoteWriter()
            : base("note")
        { }

        public override void Write(PageWriter writer, XElement element)
        {
            if (writer.DisplayAsSingleLine)
            {
                return;
            }

            string type = element.GetTypeAttribute()?.ToLower();
            string notePrefix = type switch
            {
                "note" or "tip" or "caution" or "warning" or "important" => char.ToUpper(type[0]) + type.Substring(1),
                "security" or "security note" => "Security Note",
                "implement" => "Notes to Implementers",
                "inherit" => "Notes to Inheritors",
                "caller" => "Notes to Callers",

                "cs" or "csharp" or "c#" or "visual c#" or "visual c# note" => "C# Note",
                "vb" or "vbnet" or "vb.net" or "visualbasic" or "visual basic" or "visual basic note" => "VB.NET Note",
                "fs" or "fsharp" or "f#" => "F# Note",
                // Legacy languages; SandCastle supported
                "cpp" or "c++" or "visual c++" or "visual c++ note" => "C++ Note",
                "jsharp" or "j#" or "visual j#" or "visual j# note" => "J# Note",

                _ => string.Empty
            };

            writer.EnsureLineStart();

            using (new RollbackSetter<string>(() => ref writer.LinePrefix, writer.LinePrefix + "> "))
            {
                if (!string.IsNullOrEmpty(notePrefix))
                {
                    writer
                        .Append("**")
                        .Append(notePrefix)
                        .AppendLine(":**");
                }

                writer.Append(element);
            }

            writer
                .EnsureLineStart()
                .AppendLine();
        }
    }
}
