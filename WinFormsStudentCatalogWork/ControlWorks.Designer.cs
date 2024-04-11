namespace WinFormsStudentCatalogWork
{
    partial class ControlWorks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlWorks));
            lbWorks = new ListBox();
            bAdd = new Button();
            bChange = new Button();
            bClear = new Button();
            bDelete = new Button();
            label1 = new Label();
            tbTheme = new TextBox();
            tbStudent = new TextBox();
            label2 = new Label();
            tbTeacher = new TextBox();
            label3 = new Label();
            tbGroup = new TextBox();
            label4 = new Label();
            label5 = new Label();
            nudYear = new NumericUpDown();
            nudGrade = new NumericUpDown();
            label6 = new Label();
            tcWorks = new TabControl();
            tabPage1 = new TabPage();
            tbDiscipline = new TextBox();
            label7 = new Label();
            tabPage2 = new TabPage();
            lbDegrees = new ListBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudYear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudGrade).BeginInit();
            tcWorks.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // lbWorks
            // 
            lbWorks.FormattingEnabled = true;
            lbWorks.ItemHeight = 15;
            lbWorks.Location = new Point(12, 224);
            lbWorks.Name = "lbWorks";
            lbWorks.Size = new Size(1354, 214);
            lbWorks.TabIndex = 0;
            lbWorks.SelectedIndexChanged += lbWorks_SelectedIndexChanged;
            // 
            // bAdd
            // 
            bAdd.Location = new Point(12, 195);
            bAdd.Name = "bAdd";
            bAdd.Size = new Size(334, 23);
            bAdd.TabIndex = 2;
            bAdd.Text = "Добавити";
            bAdd.UseVisualStyleBackColor = true;
            bAdd.Click += bAdd_Click;
            // 
            // bChange
            // 
            bChange.Location = new Point(352, 195);
            bChange.Name = "bChange";
            bChange.Size = new Size(334, 23);
            bChange.TabIndex = 3;
            bChange.Text = "Змінити";
            bChange.UseVisualStyleBackColor = true;
            bChange.Click += bChange_Click;
            // 
            // bClear
            // 
            bClear.Location = new Point(692, 195);
            bClear.Name = "bClear";
            bClear.Size = new Size(334, 23);
            bClear.TabIndex = 4;
            bClear.Text = "Очистити";
            bClear.UseVisualStyleBackColor = true;
            bClear.Click += bClear_Click;
            // 
            // bDelete
            // 
            bDelete.Location = new Point(1032, 195);
            bDelete.Name = "bDelete";
            bDelete.Size = new Size(334, 23);
            bDelete.TabIndex = 5;
            bDelete.Text = "Видалити";
            bDelete.UseVisualStyleBackColor = true;
            bDelete.Click += bDelete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(104, 21);
            label1.TabIndex = 6;
            label1.Text = "Тема роботи:";
            // 
            // tbTheme
            // 
            tbTheme.Font = new Font("Segoe UI", 12F);
            tbTheme.Location = new Point(139, 12);
            tbTheme.Name = "tbTheme";
            tbTheme.Size = new Size(685, 29);
            tbTheme.TabIndex = 7;
            // 
            // tbStudent
            // 
            tbStudent.Font = new Font("Segoe UI", 12F);
            tbStudent.Location = new Point(139, 47);
            tbStudent.Name = "tbStudent";
            tbStudent.Size = new Size(685, 29);
            tbStudent.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(12, 55);
            label2.Name = "label2";
            label2.Size = new Size(104, 21);
            label2.TabIndex = 8;
            label2.Text = "ПІБ студента:";
            // 
            // tbTeacher
            // 
            tbTeacher.Font = new Font("Segoe UI", 12F);
            tbTeacher.Location = new Point(139, 82);
            tbTeacher.Name = "tbTeacher";
            tbTeacher.Size = new Size(685, 29);
            tbTeacher.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 90);
            label3.Name = "label3";
            label3.Size = new Size(116, 21);
            label3.TabIndex = 10;
            label3.Text = "ПІБ викладача:";
            // 
            // tbGroup
            // 
            tbGroup.Font = new Font("Segoe UI", 12F);
            tbGroup.Location = new Point(139, 117);
            tbGroup.Name = "tbGroup";
            tbGroup.Size = new Size(685, 29);
            tbGroup.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 125);
            label4.Name = "label4";
            label4.Size = new Size(55, 21);
            label4.TabIndex = 12;
            label4.Text = "Група:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(941, 20);
            label5.Name = "label5";
            label5.Size = new Size(91, 21);
            label5.TabIndex = 14;
            label5.Text = "Рік захисту:";
            // 
            // nudYear
            // 
            nudYear.Font = new Font("Segoe UI", 12F);
            nudYear.Location = new Point(1088, 12);
            nudYear.Maximum = new decimal(new int[] { 2024, 0, 0, 0 });
            nudYear.Minimum = new decimal(new int[] { 1970, 0, 0, 0 });
            nudYear.Name = "nudYear";
            nudYear.Size = new Size(120, 29);
            nudYear.TabIndex = 15;
            nudYear.Value = new decimal(new int[] { 1980, 0, 0, 0 });
            // 
            // nudGrade
            // 
            nudGrade.Font = new Font("Segoe UI", 12F);
            nudGrade.Location = new Point(1088, 47);
            nudGrade.Name = "nudGrade";
            nudGrade.Size = new Size(120, 29);
            nudGrade.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(941, 55);
            label6.Name = "label6";
            label6.Size = new Size(64, 21);
            label6.TabIndex = 16;
            label6.Text = "Оцінка:";
            // 
            // tcWorks
            // 
            tcWorks.Controls.Add(tabPage1);
            tcWorks.Controls.Add(tabPage2);
            tcWorks.Location = new Point(941, 82);
            tcWorks.Name = "tcWorks";
            tcWorks.SelectedIndex = 0;
            tcWorks.Size = new Size(267, 107);
            tcWorks.TabIndex = 18;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tbDiscipline);
            tabPage1.Controls.Add(label7);
            tabPage1.Font = new Font("Segoe UI", 12F);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(259, 79);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Курсова робота";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbDiscipline
            // 
            tbDiscipline.Location = new Point(6, 44);
            tbDiscipline.Name = "tbDiscipline";
            tbDiscipline.Size = new Size(247, 29);
            tbDiscipline.TabIndex = 20;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(3, 11);
            label7.Name = "label7";
            label7.Size = new Size(97, 21);
            label7.TabIndex = 19;
            label7.Text = "Дисципліна:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(lbDegrees);
            tabPage2.Controls.Add(label8);
            tabPage2.Font = new Font("Segoe UI", 12F);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(259, 79);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Дипломна робота";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbDegrees
            // 
            lbDegrees.Font = new Font("Segoe UI", 8F);
            lbDegrees.FormattingEnabled = true;
            lbDegrees.ItemHeight = 13;
            lbDegrees.Location = new Point(115, 6);
            lbDegrees.Name = "lbDegrees";
            lbDegrees.Size = new Size(138, 69);
            lbDegrees.TabIndex = 21;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(6, 11);
            label8.Name = "label8";
            label8.Size = new Size(103, 21);
            label8.TabIndex = 20;
            label8.Text = "Кваліфікація:";
            // 
            // ControlWorks
            // 
            AcceptButton = bAdd;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = bClear;
            ClientSize = new Size(1381, 450);
            Controls.Add(tcWorks);
            Controls.Add(nudGrade);
            Controls.Add(label6);
            Controls.Add(nudYear);
            Controls.Add(label5);
            Controls.Add(tbGroup);
            Controls.Add(label4);
            Controls.Add(tbTeacher);
            Controls.Add(label3);
            Controls.Add(tbStudent);
            Controls.Add(label2);
            Controls.Add(tbTheme);
            Controls.Add(label1);
            Controls.Add(bDelete);
            Controls.Add(bClear);
            Controls.Add(bChange);
            Controls.Add(bAdd);
            Controls.Add(lbWorks);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ControlWorks";
            Text = "ControlWorks";
            ((System.ComponentModel.ISupportInitialize)nudYear).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudGrade).EndInit();
            tcWorks.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbWorks;
        private Button bAdd;
        private Button bChange;
        private Button bClear;
        private Button bDelete;
        private Label label1;
        private TextBox tbTheme;
        private TextBox tbStudent;
        private Label label2;
        private TextBox tbTeacher;
        private Label label3;
        private TextBox tbGroup;
        private Label label4;
        private Label label5;
        private NumericUpDown nudYear;
        private NumericUpDown nudGrade;
        private Label label6;
        private TabControl tcWorks;
        private TabPage tabPage1;
        private TextBox tbDiscipline;
        private Label label7;
        private TabPage tabPage2;
        private ListBox lbDegrees;
        private Label label8;
    }
}