using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace NoxAdbDumper
{
    /// <summary>
    /// App.xaml 的互動邏輯
    /// </summary>
    public partial class App : Application
    {
        public static List<ProcInfo> procs = new List<ProcInfo>();
        public static List<ProcInfo> procs_t = new List<ProcInfo>();
        public static List<MemSection> sections = new List<MemSection>();
        public static string Root = Directory.GetCurrentDirectory();
        public static string proc_filter = "";
        public static string sect_filter = "";
    }
}
