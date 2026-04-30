using Lab4.Abstractions.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lab4
{
    public static class FigureRenderer
    {
        // Dictionary: figure type -> drawing function
        private static Dictionary<Type, Action<Graphics, BasicFigures>> renderers
            = new Dictionary<Type, Action<Graphics, BasicFigures>>();

        // Register renderer for specific type
        public static void RegisterRenderer<T>(Action<Graphics, T> drawFunc)
            where T : BasicFigures
        {
            renderers[typeof(T)] = (g, f) => drawFunc(g, (T)f);
        }

        // Draw figure using registered renderer
        public static void Draw(Graphics g, BasicFigures figure)
        {
            if (renderers.TryGetValue(figure.GetType(), out var renderer))
            {
                renderer(g, figure);
            }
        }
    }
}
