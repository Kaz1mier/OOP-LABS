using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    
    public class FigureList
    {
        private List<BasicFigures> figures;

        public FigureList()
        {
            figures = new List<BasicFigures>();
        }

        public void AddFigure(BasicFigures figure)
        {
            figures.Add(figure);
        }


        public void RemoveFigure(BasicFigures figure)
        {
            figures.Remove(figure);
        }

        
        public void Clear()
        {
            figures.Clear();
        }
       
        public void DrawAll(Graphics g)
        {
            foreach (var figure in figures)
            {
                figure.Draw(g);
            }
        }

        public List<string> GetAllInfo()
        {
            List<string> info = new List<string>();
            foreach (var figure in figures)
            {
                info.Add(figure.GetInfo());
            }
            return info;
        }

        public int Count
        {
            get { return figures.Count; }
        }

        public BasicFigures this[int index]
        {
            get { return figures[index]; }
        }
    }
}
