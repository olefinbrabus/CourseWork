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
            // ControlWorks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1381, 450);
            Controls.Add(bDelete);
            Controls.Add(bClear);
            Controls.Add(bChange);
            Controls.Add(bAdd);
            Controls.Add(lbWorks);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ControlWorks";
            Text = "ControlWorks";
            ResumeLayout(false);
        }

        #endregion

        private ListBox lbWorks;
        private Button bAdd;
        private Button bChange;
        private Button bClear;
        private Button bDelete;
    }
}