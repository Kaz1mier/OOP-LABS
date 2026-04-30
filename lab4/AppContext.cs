using Lab4.Abstractions;
using Lab4.Abstractions.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public class AppContext : IAppContext
    {
        public void RegisterFigure(string name, Func<int, int, int, int, BasicFigures> creator)
        {
            FigureFactory.Register(name, creator);
        }

        public void RegisterRenderer<T>(Action<Graphics, T> renderer) where T : BasicFigures
        {
            FigureRenderer.RegisterRenderer(renderer);
        }
    }

}
