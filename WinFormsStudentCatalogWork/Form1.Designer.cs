namespace WinFormsStudentCatalogWork
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lvWorks = new ListView();
            id = new ColumnHeader();
            theme = new ColumnHeader();
            student = new ColumnHeader();
            teacher = new ColumnHeader();
            group = new ColumnHeader();
            year = new ColumnHeader();
            discipline = new ColumnHeader();
            degree = new ColumnHeader();
            tbSearch = new TextBox();
            bSearch = new Button();
            bAdd = new Button();
            lbFilter = new ListBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // lvWorks
            // 
            lvWorks.Columns.AddRange(new ColumnHeader[] { id, theme, student, teacher, group, year, discipline, degree });
            lvWorks.Location = new Point(182, 41);
            lvWorks.Name = "lvWorks";
            lvWorks.Size = new Size(1004, 264);
            lvWorks.TabIndex = 0;
            lvWorks.UseCompatibleStateImageBehavior = false;
            lvWorks.View = View.Details;
            // 
            // id
            // 
            id.Text = "Id";
            id.Width = 30;
            // 
            // theme
            // 
            theme.Text = "Тема роботи";
            theme.TextAlign = HorizontalAlignment.Center;
            theme.Width = 120;
            // 
            // student
            // 
            student.Text = "ПІБ Студента";
            student.TextAlign = HorizontalAlignment.Center;
            student.Width = 200;
            // 
            // teacher
            // 
            teacher.Text = "ПІБ Викладача";
            teacher.TextAlign = HorizontalAlignment.Center;
            teacher.Width = 200;
            // 
            // group
            // 
            group.Text = "Група";
            group.TextAlign = HorizontalAlignment.Center;
            // 
            // year
            // 
            year.Text = "рік";
            year.TextAlign = HorizontalAlignment.Center;
            // 
            // discipline
            // 
            discipline.Text = "Дісціплина";
            discipline.TextAlign = HorizontalAlignment.Center;
            discipline.Width = 200;
            // 
            // degree
            // 
            degree.Text = "кваліфікація";
            degree.TextAlign = HorizontalAlignment.Center;
            degree.Width = 120;
            // 
            // tbSearch
            // 
            tbSearch.Location = new Point(182, 12);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(910, 23);
            tbSearch.TabIndex = 1;
            // 
            // bSearch
            // 
            bSearch.Location = new Point(1098, 11);
            bSearch.Name = "bSearch";
            bSearch.Size = new Size(88, 23);
            bSearch.TabIndex = 2;
            bSearch.Text = "Пошук";
            bSearch.UseVisualStyleBackColor = true;
            // 
            // bAdd
            // 
            bAdd.Font = new Font("Segoe UI", 20F);
            bAdd.Location = new Point(12, 171);
            bAdd.Name = "bAdd";
            bAdd.Size = new Size(164, 134);
            bAdd.TabIndex = 3;
            bAdd.Text = "Управляти Каталогом";
            bAdd.UseVisualStyleBackColor = true;
            bAdd.Click += bAdd_Click;
            // 
            // lbFilter
            // 
            lbFilter.FormattingEnabled = true;
            lbFilter.ItemHeight = 15;
            lbFilter.Location = new Point(12, 41);
            lbFilter.Name = "lbFilter";
            lbFilter.Size = new Size(164, 124);
            lbFilter.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(48, 12);
            label1.Name = "label1";
            label1.Size = new Size(81, 21);
            label1.TabIndex = 5;
            label1.Text = "Пошук за:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1198, 317);
            Controls.Add(label1);
            Controls.Add(lbFilter);
            Controls.Add(bAdd);
            Controls.Add(bSearch);
            Controls.Add(tbSearch);
            Controls.Add(lvWorks);
            Font = new Font("Segoe UI", 9F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Каталог студентських робіт";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvWorks;
        private TextBox tbSearch;
        private Button bSearch;
        private Button bAdd;
        private ListBox lbFilter;
        private Label label1;
        private ColumnHeader id;
        private ColumnHeader theme;
        private ColumnHeader student;
        private ColumnHeader teacher;
        private ColumnHeader group;
        private ColumnHeader year;
        private ColumnHeader discipline;
        private ColumnHeader degree;
    }
}
