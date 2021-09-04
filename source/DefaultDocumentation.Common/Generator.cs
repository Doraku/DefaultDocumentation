using System.Threading;
using DefaultDocumentation.Writer;

namespace DefaultDocumentation
{
    public static class Generator
    {
        public static void Execute(Settings settings)
        {
            using Mutex mutex = new(false, "DefaultDocumenation:" + settings.OutputDirectory.FullName.Replace('\\', '|'));
            if (!mutex.WaitOne(0))
            {
                settings.Logger.Warn($"An other instance of DefaultDocumentation is trying to generate a documentation to the same output directory \"{settings.OutputDirectory.FullName}\", the current one will stop");
                return;
            }

            try
            {
                new MarkdownWriter(settings).Execute();
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }
}
