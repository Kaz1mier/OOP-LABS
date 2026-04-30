using Lab3.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    
    public class FigureList
    {
        // Internal list storing all figure objects
        private List<BasicFigures> figures;

        public FigureList()
        {
            // Initialize the internal list
            figures = new List<BasicFigures>();
        }

        // Adds a new figure to the list
        public void AddFigure(BasicFigures figure)
        {
            figures.Add(figure);
        }

        // Removes a specific figure from the list
        public void RemoveFigure(BasicFigures figure)
        {
            figures.Remove(figure);
        }

        // Clears all figures from the list
        public void Clear()
        {
            figures.Clear();
        }

        public IEnumerator<BasicFigures> GetEnumerator()
        {
            return figures.GetEnumerator();
        }

        // Returns a list of descriptive strings for all figures
        // This is used to populate the info list in the UI
        public List<string> GetAllInfo()
        {
            List<string> info = new List<string>();

            foreach (var figure in figures)
            {
                // Each figure knows how to provide its own info string
                info.Add(figure.GetInfo());
            }

            return info;
        }

        // Property to get the number of figures
        public int Count
        {
            get { return figures.Count; }
        }

        // Indexer to access figures directly by their position in the list
        public BasicFigures this[int index]
        {
            get { return figures[index]; }
        }

        
    }
}
