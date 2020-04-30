namespace VisioFromExcel
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.fileName = new System.Windows.Forms.TextBox();
            this.make = new System.Windows.Forms.TextBox();
            this.makeDate = new System.Windows.Forms.TextBox();
            this.chekedM = new System.Windows.Forms.TextBox();
            this.chekedDate = new System.Windows.Forms.TextBox();
            this.city = new System.Windows.Forms.TextBox();
            this.tpType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // logBox
            // 
            this.logBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logBox.Location = new System.Drawing.Point(0, 329);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(800, 121);
            this.logBox.TabIndex = 0;
            this.logBox.Text = "";
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(156, 13);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(100, 20);
            this.fileName.TabIndex = 1;
            // 
            // make
            // 
            this.make.Location = new System.Drawing.Point(156, 40);
            this.make.Name = "make";
            this.make.Size = new System.Drawing.Size(100, 20);
            this.make.TabIndex = 2;
            // 
            // makeDate
            // 
            this.makeDate.Location = new System.Drawing.Point(156, 67);
            this.makeDate.Name = "makeDate";
            this.makeDate.Size = new System.Drawing.Size(100, 20);
            this.makeDate.TabIndex = 3;
            // 
            // chekedM
            // 
            this.chekedM.Location = new System.Drawing.Point(156, 94);
            this.chekedM.Name = "chekedM";
            this.chekedM.Size = new System.Drawing.Size(100, 20);
            this.chekedM.TabIndex = 4;
            // 
            // chekedDate
            // 
            this.chekedDate.Location = new System.Drawing.Point(156, 121);
            this.chekedDate.Name = "chekedDate";
            this.chekedDate.Size = new System.Drawing.Size(100, 20);
            this.chekedDate.TabIndex = 5;
            // 
            // city
            // 
            this.city.Location = new System.Drawing.Point(156, 175);
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(100, 20);
            this.city.TabIndex = 6;
            // 
            // tpType
            // 
            this.tpType.FormattingEnabled = true;
            this.tpType.Location = new System.Drawing.Point(156, 148);
            this.tpType.Name = "tpType";
            this.tpType.Size = new System.Drawing.Size(121, 21);
            this.tpType.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tpType);
            this.Controls.Add(this.city);
            this.Controls.Add(this.chekedDate);
            this.Controls.Add(this.chekedM);
            this.Controls.Add(this.makeDate);
            this.Controls.Add(this.make);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.logBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.TextBox make;
        private System.Windows.Forms.TextBox makeDate;
        private System.Windows.Forms.TextBox chekedM;
        private System.Windows.Forms.TextBox chekedDate;
        private System.Windows.Forms.TextBox city;
        private System.Windows.Forms.ComboBox tpType;
    }
}

