using Lab4.Abstractions;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Lab5
{
    public static class PluginLoader
    {
        public static void LoadPlugins(string folder)
        {
            if (!Directory.Exists(folder))
                return;

            var files = Directory.GetFiles(folder, "*.dll");

            foreach (var file in files)
            {
                try
                {
                    var asm = Assembly.LoadFrom(file);

                    foreach (var type in asm.GetTypes())
                    {
                        if (!type.IsClass) continue;

                        // фигуры (старое)
                        if (typeof(IPlugin).IsAssignableFrom(type))
                        {
                            var plugin =
                                (IPlugin)Activator.CreateInstance(type);

                            plugin.Register(new AppContext());
                        }

                        // обработка файла (новое)
                        if (typeof(IFilePlugin).IsAssignableFrom(type))
                        {
                            var plugin =
                                (IFilePlugin)Activator.CreateInstance(type);

                            PluginManager.FilePlugins.Add(plugin);
                        }
                    }
                }
                catch { }
            }
        }
    }
}
