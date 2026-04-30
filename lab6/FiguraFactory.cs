using Lab4.Abstractions.Shapes;
using System;
using System.Collections.Generic;

namespace Lab6
{
    public static class FigureFactory
    {
        // Function takes (x, y, width, height)
        private static Dictionary<string, Func<int, int, int, int, BasicFigures>> creators
            = new Dictionary<string, Func<int, int, int, int, BasicFigures>>();

        // Register creator
        public static void Register(string name, Func<int, int, int, int, BasicFigures> creator)
        {
            creators[name] = creator;
        }

        // Create figure
        public static BasicFigures Create(string name, int x, int y, int w, int h)
        {
            if (creators.TryGetValue(name, out var creator))
                return creator(x, y, w, h);

            return null;
        }

        // Get all types
        public static IEnumerable<string> GetTypes()
        {
            return creators.Keys;
        }

        public static BasicFigures CreateEmpty(string name)
        {
            if (creators.TryGetValue(name, out var creator))
                return creator(0, 0, 0, 0);

            return null;
        }
    }
}
