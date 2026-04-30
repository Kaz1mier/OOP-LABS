using Lab4;
using Lab4.Abstractions.Shapes;
using System;
using System.Drawing;
using System.Windows.Forms;
using Rectangle = Lab4.Abstractions.Shapes.Rectangle;

namespace Lab5
{
    public partial class mainForm : Form
    {
        private FigureList figureList;

        // Mouse drawing state
        private bool isDrawing = false;
        private Point startPoint;
        private Point currentPoint;

        public mainForm()
        {
            InitializeComponent();

            // Register figure creators (Factory)
            RegisterFigures();

            // Register render logic (Renderer)
            RegisterRenderers();

            PluginLoader.LoadPlugins("Plugins");

            cmbPlugins.Items.Add("Без обработки");

            foreach (var p in PluginManager.FilePlugins)
                cmbPlugins.Items.Add(p.Name);

            cmbPlugins.SelectedIndex = 0;

            // Initialize default data
            InitializeFigures();

            // Fill UI
            InitializeComboBox();

            // Events
            this.Paint += MainForm_Paint;
            this.MouseDown += mainForm_MouseDown;
            this.MouseMove += mainForm_MouseMove;
            this.MouseUp += mainForm_MouseUp;
        }

        private void InitializeComboBox()
        {
            cmbFigureType.Items.Clear();

            // Fill ComboBox with registered figure types
            foreach (var type in FigureFactory.GetTypes())
                cmbFigureType.Items.Add(type);

            if (cmbFigureType.Items.Count > 0)
                cmbFigureType.SelectedIndex = 0;
        }

        private void InitializeFigures()
        {
            figureList = new FigureList();

           

            UpdateInfoList();
        }

        private void UpdateInfoList()
        {
            listBoxInfo.Items.Clear();

            foreach (var figure in figureList)
            {
                listBoxInfo.Items.Add(figure);
            }

            this.Text = $"Фигуры: {figureList.Count}";
        }


        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (figureList == null) return;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw working area
            using (Pen pen = new Pen(Color.LightGray))
                e.Graphics.DrawRectangle(pen, 300, 20, 480, 550);

            // Draw all figures using renderer (no switch!)
            for (int i = 0; i < figureList.Count; i++)
                FigureRenderer.Draw(e.Graphics, figureList[i]);

            // Draw preview rectangle while user is dragging mouse
            if (isDrawing)
            {
                int x = Math.Min(startPoint.X, currentPoint.X);
                int y = Math.Min(startPoint.Y, currentPoint.Y);
                int w = Math.Abs(startPoint.X - currentPoint.X);
                int h = Math.Abs(startPoint.Y - currentPoint.Y);

                using (Pen pen = new Pen(Color.Gray))
                {
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    e.Graphics.DrawRectangle(pen, x, y, w, h);
                }
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

        private void BtnAddRandom_Click(object sender, EventArgs e)
        {
            string type = cmbFigureType.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(type)) return;

            Random rand = new Random();

            // Create figure via Factory (no switch!)
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

        // Mouse drawing logic

        private void mainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            isDrawing = true;
            startPoint = e.Location;
            currentPoint = e.Location;
        }

        private void mainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            currentPoint = e.Location;
            this.Invalidate();
        }

        private void mainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            isDrawing = false;

            string type = cmbFigureType.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(type)) return;

            // Calculate bounding box
            int x = Math.Min(startPoint.X, currentPoint.X);
            int y = Math.Min(startPoint.Y, currentPoint.Y);
            int w = Math.Abs(startPoint.X - currentPoint.X);
            int h = Math.Abs(startPoint.Y - currentPoint.Y);

            // Create figure from mouse input
            var figure = FigureFactory.Create(type, x, y, w, h);

            if (figure != null)
            {
                figureList.AddFigure(figure);
                UpdateInfoList();
                this.Invalidate();
            }
        }

       
        // Factory registration

        private void RegisterFigures()
        {
            FigureFactory.Register("Rectangle",
                (x, y, w, h) => new Rectangle(x, y, w, h, Color.Black));

            FigureFactory.Register("Ellipse",
                (x, y, w, h) => new Ellipse(x, y, w, h, Color.Blue));

            FigureFactory.Register("Circle",
                (x, y, w, h) => new Circle(
                    x + w / 2,
                    y + h / 2,
                    Math.Min(w, h) / 2,
                    Color.Red));

            FigureFactory.Register("Square",
                (x, y, w, h) => new Square(
                    x,
                    y,
                    Math.Min(w, h),
                    Color.Green));

            FigureFactory.Register("Line",
                (x, y, w, h) => new Line(
                    x,
                    y,
                    x + w,
                    y + h,
                    Color.Black));

            FigureFactory.Register("Triangle",
                (x, y, w, h) => new Triangle(
                    new Point(x, y + h),
                    new Point(x + w, y + h),
                    new Point(x + w / 2, y),
                    Color.Purple));
        }

        // Renderer registration

        private void RegisterRenderers()
        {
            FigureRenderer.RegisterRenderer<Circle>((g, c) =>
            {
                using (Pen pen = new Pen(c.Color))
                    g.DrawEllipse(pen, c.X, c.Y, c.Radius * 2, c.Radius * 2);
            });

            FigureRenderer.RegisterRenderer<Rectangle>((g, r) =>
            {
                using (Pen pen = new Pen(r.Color))
                    g.DrawRectangle(pen, r.X, r.Y, r.Width, r.Height);
            });

            FigureRenderer.RegisterRenderer<Ellipse>((g, e) =>
            {
                using (Pen pen = new Pen(e.Color))
                    g.DrawEllipse(pen, e.X, e.Y, e.Width, e.Height);
            });

            FigureRenderer.RegisterRenderer<Line>((g, l) =>
            {
                using (Pen pen = new Pen(l.Color))
                    g.DrawLine(pen, l.X, l.Y, l.X2, l.Y2);
            });

            FigureRenderer.RegisterRenderer<Square>((g, s) =>
            {
                using (Pen pen = new Pen(s.Color))
                    g.DrawRectangle(pen, s.X, s.Y, s.Side, s.Side);
            });

            FigureRenderer.RegisterRenderer<Triangle>((g, t) =>
            {
                using (Pen pen = new Pen(t.Color))
                    g.DrawPolygon(pen, t.Points);
            });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBoxInfo.SelectedItem is BasicFigures fig)
            {
                figureList.RemoveFigure(fig);
                UpdateInfoList();
                this.Invalidate();
            }
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            int index = listBoxInfo.SelectedIndex;
            if (index < 0) return;

            var figure = figureList[index];

            var fields = new List<EditField>();

            if (figure is Circle c)
            {
                fields.Add(new EditField("X", c.X.ToString()));
                fields.Add(new EditField("Y", c.Y.ToString()));
                fields.Add(new EditField("Radius", c.Radius.ToString()));
                fields.Add(new EditField("Color", c.Color.Name));
            }
            else if (figure is Rectangle r)
            {
                fields.Add(new EditField("X", r.X.ToString()));
                fields.Add(new EditField("Y", r.Y.ToString()));
                fields.Add(new EditField("Width", r.Width.ToString()));
                fields.Add(new EditField("Height", r.Height.ToString()));
            }

            using (var form = new EditForm("Edit figure", fields))
            {
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                var res = form.Result;

                if (figure is Circle c2)
                {
                    c2.X = int.Parse(res["X"]);
                    c2.Y = int.Parse(res["Y"]);
                    c2.Radius = int.Parse(res["Radius"]);
                }
                else if (figure is Rectangle r2)
                {
                    r2.X = int.Parse(res["X"]);
                    r2.Y = int.Parse(res["Y"]);
                    r2.Width = int.Parse(res["Width"]);
                    r2.Height = int.Parse(res["Height"]);
                }
            }

            UpdateInfoList();
            Invalidate();
        }

        private Lab4.Abstractions.IFilePlugin GetSelectedPlugin()
        {
            if (cmbPlugins.SelectedIndex <= 0)
                return null;

            return PluginManager.FilePlugins[
                cmbPlugins.SelectedIndex - 1];
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Data file (*.dat)|*.dat";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    byte[] data;

                    using (MemoryStream ms = new MemoryStream())
                    using (BinaryWriter writer = new BinaryWriter(ms))
                    {
                        writer.Write(figureList.Count);

                        for (int i = 0; i < figureList.Count; i++)
                        {
                            var f = figureList[i];

                            writer.Write(f.GetType().Name);
                            f.Save(writer);
                        }

                        data = ms.ToArray();
                    }

                    var plugin = GetSelectedPlugin();

                    if (plugin != null)
                        data = plugin.BeforeSave(data);

                    File.WriteAllBytes(sfd.FileName, data);

                    MessageBox.Show("Saved");
                }
            }
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Data file (*.dat)|*.dat|All files (*.*)|*.*";

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    byte[] data = File.ReadAllBytes(ofd.FileName);

                    var plugin = GetSelectedPlugin();

                   
                    if (plugin != null)
                    {
                        try
                        {
                            data = plugin.AfterLoad(data);
                        }
                        catch
                        {
                            MessageBox.Show(
                                "Файл был сохранён другим методом архивации.\n" +
                                "Выберите другой плагин и повторите загрузку.",
                                "Ошибка распаковки",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }

                    using (MemoryStream ms = new MemoryStream(data))
                    using (BinaryReader reader = new BinaryReader(ms))
                    {
                        figureList.Clear();

                        int count = reader.ReadInt32();

                        for (int i = 0; i < count; i++)
                        {
                            string type = reader.ReadString();

                            var f = FigureFactory.CreateEmpty(type);

                            if (f == null)
                                throw new Exception("Неизвестный тип фигуры: " + type);

                            f.Load(reader);

                            figureList.AddFigure(f);
                        }
                    }

                    UpdateInfoList();
                    Invalidate();

                    MessageBox.Show(
                        "Файл успешно загружен.",
                        "Успех",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (EndOfStreamException)
                {
                    MessageBox.Show(
                        "Файл повреждён или выбран неверный метод обработки.",
                        "Ошибка загрузки",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(
                        "Ошибка чтения файла:\n" + ex.Message,
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Ошибка загрузки:\n" + ex.Message,
                        "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }



    }

}

