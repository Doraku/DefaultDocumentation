using System.Collections.Generic;
using DefaultDocumentation.Writers;

namespace DefaultDocumentation
{
    public interface IContext
    {
        IFileNameFactory FileNameFactory { get; }

        IEnumerable<ISectionWriter> Sections { get; }

        T GetSetting<T>(string name);
    }
}
