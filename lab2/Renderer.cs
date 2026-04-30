using System;
using System.Drawing;
using System.Reflection;
using System.Security.Policy;

namespace Lab2
{
    public static class FigureRenderer
    {
        public static void Draw(Graphics g, BasicFigures figure)
        {
            switch (figure)
            {
                case Circle c:
                    DrawCircle(g, c);
                    break;

                case Rectangle r:
                    DrawRectangle(g, r);
                    break;

                case Ellipse e:
                    DrawEllipse(g, e);
                    break;

                case Line l:
                    DrawLine(g, l);
                    break;

                case Square s:
                    DrawSquare(g, s);
                    break;

                case Triangle t:
                    DrawTriangle(g, t);
                    break;

            }
        }

        private static void DrawCircle(Graphics g, Circle c)
        {
            using (Pen pen = new Pen(c.Color))
            {
                g.DrawEllipse(pen, c.X, c.Y, c.Radius * 2, c.Radius * 2);
            }
        }


        public static void DrawRectangle(Graphics g, Rectangle r)
        {
            using (Pen pen = new Pen(r.Color))
                {
                    g.DrawRectangle(pen, r.X, r.Y, r.Width, r.Height);
                }
        }

        public static void DrawEllipse(Graphics g, Ellipse e)
        {
           using (Pen pen = new Pen(e.Color))
                {
                    g.DrawEllipse(pen, e.X, e.Y, e.Width, e.Height);
                }
            
        }


        public static void DrawLine(Graphics g, Line l)
        {
            using (Pen pen = new Pen(l.Color))
            {
                g.DrawLine(pen, l.X, l.Y, l.X2, l.Y2);
            }
        }

        public static void DrawSquare(Graphics g, Square s)
        {
            using (Pen pen = new Pen(s.Color))
                {
                    g.DrawRectangle(pen, s.X, s.Y, s.Side, s.Side);
                }
           
        }

        public static void DrawTriangle(Graphics g, Triangle t)
        {
            using (Pen pen = new Pen(t.Color))
                {
                    g.DrawPolygon(pen, t.Points);
                }
            }
        }

    }


