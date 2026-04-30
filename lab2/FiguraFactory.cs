using System;
using System.Collections.Generic;

namespace Lab2
{
    
    public static class FigureFactory
    {
        // Dictionary mapping figure names to creator functions
        // The Func parameters: x, y, width, height
        private static Dictionary<string, Func<int, int, int, int, BasicFigures>> creators
            = new Dictionary<string, Func<int, int, int, int, BasicFigures>>();

        // Register a new figure type with its creation function
        // Example: FigureFactory.Register("Circle", (x, y, w, h) => new Circle(...));
        public static void Register(string name, Func<int, int, int, int, BasicFigures> creator)
        {
            creators[name] = creator;
        }

        // Create a figure of the specified type with the given dimensions
        // Returns null if the type is not registered
        public static BasicFigures Create(string name, int x, int y, int w, int h)
        {
            return creators.ContainsKey(name) ? creators[name](x, y, w, h) : null;
        }

        // Returns all registered figure type names
        public static IEnumerable<string> GetTypes()
        {
            return creators.Keys;
        }
    }
}
