using Lab4.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public static class PluginManager
    {
        public static List<IFilePlugin> FilePlugins =
            new List<IFilePlugin>();
    }
}
