using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace Lab3
{
    public partial class EditForm : Form
    {
        private List<TextBox> inputs = new List<TextBox>();

        public Dictionary<string, string> Result { get; private set; }

        public EditForm(string title, List<EditField> fields)
        {
            Text = title;
            Width = 300;
            Height = 50 + fields.Count * 80;

            var panel = new FlowLayoutPanel()
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };

            foreach (var field in fields)
            {
                var lbl = new Label()
                {
                    Text = field.Name,
                    Width = 250
                };

                var txt = new TextBox()
                {
                    Text = field.Value,
                    Width = 250
                };

                inputs.Add(txt);

                panel.Controls.Add(lbl);
                panel.Controls.Add(txt);
            }

            var btnOk = new Button()
            {
                Text = "OK",
                Width = 100,
                Height = 40
            };

            var btnCancel = new Button()
            {
                Text = "Cancel",
                Width = 100,
                Height = 40
            };

            btnOk.Click += (s, e) =>
            {
                Result = new Dictionary<string, string>();

                for (int i = 0; i < fields.Count; i++)
                    Result[fields[i].Name] = inputs[i].Text;

                DialogResult = DialogResult.OK;
                Close();
            };

            btnCancel.Click += (s, e) =>
            {
                DialogResult = DialogResult.Cancel;
                Close();
            };

            panel.Controls.Add(btnOk);
            panel.Controls.Add(btnCancel);

            Controls.Add(panel);
        }
    }
}
