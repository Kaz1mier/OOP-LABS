using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Lab4.Abstractions;

namespace Lab4
{
    public static class PluginLoader
    {
        public static void LoadPlugins(string folder)
        {
            if (!Directory.Exists(folder))
                return;

            var dllFiles = Directory.GetFiles(folder, "*.dll");

            foreach (var file in dllFiles)
            {
                try
                {
                    var assembly = Assembly.LoadFrom(file);

                    var types = assembly.GetTypes()
                        .Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface);
                    var context = new AppContext();

                    foreach (var type in types)
                    {
                        var plugin = (IPlugin)Activator.CreateInstance(type);
                        plugin.Register(context);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Plugin load error: {ex.Message}");
                }
            }
        }
    }
}
