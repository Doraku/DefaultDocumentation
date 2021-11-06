using System.Collections.Generic;
using DefaultDocumentation.Api;

namespace DefaultDocumentation
{
    public interface IContext
    {
        IFileNameFactory FileNameFactory { get; }

        IEnumerable<ISection> Sections { get; }

        T GetSetting<T>(string name);
    }
}
