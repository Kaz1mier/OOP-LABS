using Lab4;
using Lab4.Abstractions.Shapes;
using System.Drawing;
using System.Windows.Forms;
using Lab4.Abstractions;

namespace Lab4Plugin
{
    public class Plugin : IPlugin
    {
        // Register method - called by the host application to initialize the plugin
        public void Register(IAppContext context)
        {
            // Register the Pentagon figure type with the context
            // The lambda creates a new Pentagon instance with specified position, size, and color
            context.RegisterFigure("Pentagon",
                (x, y, w, h) => new Pentagon(x, y, w, Color.DarkCyan));

            // Register a rendering delegate for Pentagon objects
            // This tells the application how to draw a pentagon on a Graphics surface
            context.RegisterRenderer<Pentagon>((g, p) =>
            {
                // Calculate the 5 vertices of the pentagon
                // The shape is drawn around the center point (p.X, p.Y)
                Point[] pts = new Point[]
                {
                new Point(p.X, p.Y),                         // Vertex 1: top center
                new Point(p.X + p.Size, p.Y + p.Size/3),     // Vertex 2: right-upper
                new Point(p.X + p.Size/2, p.Y + p.Size),     // Vertex 3: right-lower
                new Point(p.X - p.Size/2, p.Y + p.Size),     // Vertex 4: left-lower
                new Point(p.X - p.Size, p.Y + p.Size/3)      // Vertex 5: left-upper
                };

                // Draw the pentagon outline using the specified color
                using (Pen pen = new Pen(p.Color))
                    g.DrawPolygon(pen, pts);
            });
        }
    }
}