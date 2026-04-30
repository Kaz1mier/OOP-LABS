namespace Lab2
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxInfo = new ListBox();
            btnClear = new Button();
            btnAddRandom = new Button();
            cmbFigureType = new ComboBox();
            SuspendLayout();
            // 
            // listBoxInfo
            // 
            listBoxInfo.FormattingEnabled = true;
            listBoxInfo.ItemHeight = 25;
            listBoxInfo.Location = new Point(22, 117);
            listBoxInfo.Name = "listBoxInfo";
            listBoxInfo.Size = new Size(254, 179);
            listBoxInfo.TabIndex = 0;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(69, 411);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 2;
            btnClear.Text = "Очистить";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // btnAddRandom
            // 
            btnAddRandom.Location = new Point(60, 317);
            btnAddRandom.Name = "btnAddRandom";
            btnAddRandom.Size = new Size(131, 63);
            btnAddRandom.TabIndex = 3;
            btnAddRandom.Text = "Нарисовать";
            btnAddRandom.UseVisualStyleBackColor = true;
            btnAddRandom.Click += BtnAddRandom_Click;
            // 
            // cmbFigureType
            // 
            cmbFigureType.FormattingEnabled = true;
            cmbFigureType.Location = new Point(22, 78);
            cmbFigureType.Name = "cmbFigureType";
            cmbFigureType.Size = new Size(182, 33);
            cmbFigureType.TabIndex = 4;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(926, 644);
            Controls.Add(cmbFigureType);
            Controls.Add(btnAddRandom);
            Controls.Add(btnClear);
            Controls.Add(listBoxInfo);
            Name = "mainForm";
            Text = "Form1";
            MouseDown += mainForm_MouseDown;
            MouseMove += mainForm_MouseMove;
            ResumeLayout(false);
        }

        #endregion
        private ListBox listBoxInfo;
        private Button btnClear;
        private Button btnAddRandom;
        private ComboBox cmbFigureType;
    }
}
