using Lab4.Abstractions.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Abstractions
{
    public interface IAppContext
    {
        void RegisterFigure(string name, Func<int, int, int, int, BasicFigures> creator);
        void RegisterRenderer<T>(Action<Graphics, T> renderer) where T : BasicFigures;
    }
}
