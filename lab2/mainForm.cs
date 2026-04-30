using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab2
{
    public partial class mainForm : Form
    {
        private FigureList figureList;

        // Variables to handle mouse-based drawing
        private bool isDrawing = false;
        private Point startPoint;
        private Point currentPoint;

        public mainForm()
        {
            InitializeComponent();

            // Register figure types in the factory
            RegisterFigures();

            // Initialize some default figures on canvas
            InitializeFigures();

            // Fill combo box with figure types
            InitializeComboBox();

            // Subscribe to paint event to draw figures
            this.Paint += MainForm_Paint;

            // Subscribe to mouse events for interactive drawing
            this.MouseDown += mainForm_MouseDown;
            this.MouseMove += mainForm_MouseMove;
            this.MouseUp += mainForm_MouseUp;
        }

        private void InitializeComboBox()
        {
            cmbFigureType.Items.Clear();

            // Populate combo box with all registered figure types
            foreach (var type in FigureFactory.GetTypes())
                cmbFigureType.Items.Add(type);

            if (cmbFigureType.Items.Count > 0)
                cmbFigureType.SelectedIndex = 0;
        }

        private void InitializeFigures()
        {
            figureList = new FigureList();

            // Add some default figures to the canvas
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

            // Display information about all figures in the listbox
            foreach (var item in figureList.GetAllInfo())
                listBoxInfo.Items.Add(item);

            this.Text = $"Фигуры: {figureList.Count}";
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (figureList == null) return;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw the main canvas rectangle
            using (Pen pen = new Pen(Color.LightGray))
                e.Graphics.DrawRectangle(pen, 300, 20, 480, 550);

            // Render all figures using FigureRenderer
            for (int i = 0; i < figureList.Count; i++)
                FigureRenderer.Draw(e.Graphics, figureList[i]);

            // If currently drawing with the mouse, show a dashed preview rectangle
            if (isDrawing)
            {
                int x = Math.Min(startPoint.X, currentPoint.X);
                int y = Math.Min(startPoint.Y, currentPoint.Y);
                int w = Math.Abs(startPoint.X - currentPoint.X);
                int h = Math.Abs(startPoint.Y - currentPoint.Y);

                // Use dashed pen to indicate preview of the figure being drawn
                using (Pen pen = new Pen(Color.Gray))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    e.Graphics.DrawRectangle(pen, x, y, w, h);
                }
            }
        }

        private void BtnDraw_Click(object sender, EventArgs e)
        {
            // Redraw the canvas
            this.Invalidate();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            // Clear all figures
            figureList.Clear();
            UpdateInfoList();
            this.Invalidate();
        }

        private void BtnAddRandom_Click(object sender, EventArgs e)
        {
            string type = cmbFigureType.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(type)) return;

            Random rand = new Random();

            // Use factory to create a random figure within specified bounds
            var figure = FigureFactory.Create(
                type,
                rand.Next(320, 700),
                rand.Next(40, 500),
                rand.Next(50, 150),
                rand.Next(50, 150)
            );

            if (figure != null)
            {
                figureList.AddFigure(figure);
                UpdateInfoList();
                this.Invalidate();
            }
        }

        // Mouse event handlers for interactive figure creation
        private void mainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            // Start drawing: save start point
            isDrawing = true;
            startPoint = e.Location;
            currentPoint = e.Location;
        }

        private void mainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            // Update current mouse position for live preview
            currentPoint = e.Location;
            this.Invalidate();
        }

        private void mainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            isDrawing = false;

            string type = cmbFigureType.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(type)) return;

            // Calculate rectangle bounds from start and end points
            int x = Math.Min(startPoint.X, currentPoint.X);
            int y = Math.Min(startPoint.Y, currentPoint.Y);
            int w = Math.Abs(startPoint.X - currentPoint.X);
            int h = Math.Abs(startPoint.Y - currentPoint.Y);

            // Create the figure using the factory
            var figure = FigureFactory.Create(type, x, y, w, h);

            if (figure != null)
            {
                figureList.AddFigure(figure);
                UpdateInfoList();
                this.Invalidate();
            }
        }

        // Register all figure types with the factory
        private void RegisterFigures()
        {
            // Each registration defines how to construct a figure given x, y, width, height
            FigureFactory.Register("Прямоугольник",
                (x, y, w, h) => new Rectangle(x, y, w, h, Color.Black));

            FigureFactory.Register("Эллипс",
                (x, y, w, h) => new Ellipse(x, y, w, h, Color.Blue));

            FigureFactory.Register("Круг",
                (x, y, w, h) => new Circle(x + w / 2, y + h / 2, Math.Min(w, h) / 2, Color.Red));

            FigureFactory.Register("Квадрат",
                (x, y, w, h) => new Square(x, y, Math.Min(w, h), Color.Green));

            FigureFactory.Register("Линия",
                (x, y, w, h) => new Line(x, y, x + w, y + h, Color.Black));

            FigureFactory.Register("Треугольник",
                (x, y, w, h) => new Triangle(
                    new Point(x, y + h),
                    new Point(x + w, y + h),
                    new Point(x + w / 2, y),
                    Color.Purple));
        }
    }
}
