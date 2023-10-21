using System;
using System.IO;
using System.Reflection;

namespace Startup
{
    public class Paths
    {
        public static string AppName { get; private set; }
        public static string WorkingDirectory { get; private set; }
        public static string DocsFile { get; private set; }
        public static string Logs { get; private set; }

        public static void Init(string appName)
        {
            AppName = appName;
            WorkingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? throw new NullReferenceException();
            DocsFile = Path.Combine(WorkingDirectory, $"{AppName}.xml");
            Logs = Path.Combine(WorkingDirectory, "Logs");
        }
    }
}
