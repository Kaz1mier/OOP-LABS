namespace Lab4
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
            btnDelete = new Button();
            btnEdit = new Button();
            btnSave = new Button();
            btnLoad = new Button();
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
            btnClear.Location = new Point(60, 485);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(144, 34);
            btnClear.TabIndex = 2;
            btnClear.Text = "Очистить";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += BtnClear_Click;
            // 
            // btnAddRandom
            // 
            btnAddRandom.Location = new Point(60, 317);
            btnAddRandom.Name = "btnAddRandom";
            btnAddRandom.Size = new Size(144, 63);
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
            // btnDelete
            // 
            btnDelete.Location = new Point(60, 439);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(144, 40);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(60, 395);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(144, 38);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Редактировать";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(12, 542);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(119, 48);
            btnSave.TabIndex = 5;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(137, 542);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(119, 48);
            btnLoad.TabIndex = 6;
            btnLoad.Text = "Загрузить";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1240, 644);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
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
        private Button btnDelete;
        private Button btnEdit;
        private ComboBox cmbFigureType;
        private Button btnSave;
        private Button btnLoad;
    }
}
