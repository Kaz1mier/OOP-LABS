using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Lab1
{
    public partial class mainForm : Form
    {
        private FigureList figureList;
      

        private enum FigureType
        {
            Линия,
            Прямоугольник,
            Эллипс,
            Круг,
            Квадрат,
            Треугольник
        }

        public mainForm()
        {
            InitializeComponent();
            InitializeCustomSettings();
            InitializeFigures();
            InitializeComboBox();

            this.Paint += MainForm_Paint;
        }

        private void InitializeCustomSettings()
        {
            
        }

        private void InitializeComboBox()
        {
            cmbFigureType.Items.Clear();

            foreach (FigureType type in Enum.GetValues(typeof(FigureType)))
            {
                cmbFigureType.Items.Add(type.ToString());
            }

            if (cmbFigureType.Items.Count > 0)
            {
                cmbFigureType.SelectedIndex = 0;
            }
        }

        private void InitializeFigures()
        {
            figureList = new FigureList();

            figureList.AddFigure(new Line(350, 100, 450, 200, Color.Blue));
            figureList.AddFigure(new Rectangle(350, 250, 150, 100, Color.Red, false, 3));
            figureList.AddFigure(new Ellipse(350, 380, 120, 80, Color.Green, true));
            figureList.AddFigure(new Circle(550, 120, 50, Color.Orange, false, 2));
            figureList.AddFigure(new Square(550, 250, 80, Color.Purple, true));
            figureList.AddFigure(new Triangle(
                new Point(350, 500),
                new Point(450, 550),
                new Point(250, 550),
                Color.Brown, true));

            UpdateInfoList();
        }

        private void UpdateInfoList()
        {
            listBoxInfo.Items.Clear();
            var info = figureList.GetAllInfo();
            foreach (var item in info)
            {
                listBoxInfo.Items.Add(item);
            }

            this.Text = $"Графические фигуры (Всего фигур: {figureList.Count})";
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (figureList != null)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                using (Pen pen = new Pen(Color.LightGray, 1))
                {
                    e.Graphics.DrawRectangle(pen, 300, 20, 480, 550);
                }

                figureList.DrawAll(e.Graphics);
            }
        }

        private void BtnDraw_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            figureList.Clear();
            UpdateInfoList();
            this.Invalidate();
        }

        private BasicFigures CreateSelectedFigure(Random rand, int x, int y, Color color)
        {
            string selectedType = cmbFigureType.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedType))
                return null;

            switch (selectedType)
            {
                case "Линия":
                    return new Line(x, y, x + 80, y + 50, color, rand.Next(1, 5));

                case "Прямоугольник":
                    return new Rectangle(x, y, 70, 50, color, rand.Next(2) == 0, rand.Next(1, 5));

                case "Эллипс":
                    return new Ellipse(x, y, 80, 60, color, rand.Next(2) == 0, rand.Next(1, 5));

                case "Круг":
                    return new Circle(x + 40, y + 40, 35, color, rand.Next(2) == 0, rand.Next(1, 5));

                case "Квадрат":
                    return new Square(x, y, 60, color, rand.Next(2) == 0, rand.Next(1, 5));

                case "Треугольник":
                    return new Triangle(
                        new Point(x, y + 50),
                        new Point(x + 60, y + 50),
                        new Point(x + 30, y),
                        color, rand.Next(2) == 0, rand.Next(1, 5));

                default:
                    return null;
            }
        }

        private BasicFigures CreateRandomFigure(Random rand, int x, int y, Color color)
        {
            int figureType = rand.Next(0, 6);

            switch (figureType)
            {
                case 0:
                    return new Line(x, y, x + 80, y + 50, color, rand.Next(1, 5));
                case 1:
                    return new Rectangle(x, y, 70, 50, color, rand.Next(2) == 0, rand.Next(1, 5));
                case 2:
                    return new Ellipse(x, y, 80, 60, color, rand.Next(2) == 0, rand.Next(1, 5));
                case 3:
                    return new Circle(x + 40, y + 40, 35, color, rand.Next(2) == 0, rand.Next(1, 5));
                case 4:
                    return new Square(x, y, 60, color, rand.Next(2) == 0, rand.Next(1, 5));
                case 5:
                    return new Triangle(
                        new Point(x, y + 50),
                        new Point(x + 60, y + 50),
                        new Point(x + 30, y),
                        color, rand.Next(2) == 0, rand.Next(1, 5));
                default:
                    return null;
            }
        }

        private void BtnAddRandom_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            int x = rand.Next(320, 700);
            int y = rand.Next(40, 500);

            Color randomColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));

            BasicFigures newFigure;

            if (Control.ModifierKeys == Keys.Control)
            {
                newFigure = CreateRandomFigure(rand, x, y, randomColor);
            }
            else
            {
                
                newFigure = CreateSelectedFigure(rand, x, y, randomColor);
            }

            if (newFigure != null)
            {
                figureList.AddFigure(newFigure);
                UpdateInfoList();
                this.Invalidate();
            }
        }

   
    }
}