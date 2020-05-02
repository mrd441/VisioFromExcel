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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // logBox
            // 
            this.logBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logBox.Location = new System.Drawing.Point(0, 156);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(800, 121);
            this.logBox.TabIndex = 0;
            this.logBox.Text = "";
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(104, 12);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(196, 20);
            this.fileName.TabIndex = 1;
            // 
            // make
            // 
            this.make.Location = new System.Drawing.Point(104, 39);
            this.make.Name = "make";
            this.make.Size = new System.Drawing.Size(100, 20);
            this.make.TabIndex = 2;
            // 
            // makeDate
            // 
            this.makeDate.Location = new System.Drawing.Point(248, 39);
            this.makeDate.Name = "makeDate";
            this.makeDate.Size = new System.Drawing.Size(52, 20);
            this.makeDate.TabIndex = 3;
            // 
            // chekedM
            // 
            this.chekedM.Location = new System.Drawing.Point(104, 65);
            this.chekedM.Name = "chekedM";
            this.chekedM.Size = new System.Drawing.Size(100, 20);
            this.chekedM.TabIndex = 4;
            // 
            // chekedDate
            // 
            this.chekedDate.Location = new System.Drawing.Point(248, 65);
            this.chekedDate.Name = "chekedDate";
            this.chekedDate.Size = new System.Drawing.Size(52, 20);
            this.chekedDate.TabIndex = 5;
            // 
            // city
            // 
            this.city.Location = new System.Drawing.Point(104, 118);
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(196, 20);
            this.city.TabIndex = 6;
            // 
            // tpType
            // 
            this.tpType.FormattingEnabled = true;
            this.tpType.Items.AddRange(new object[] {
            "Столбовая",
            "Мачтовая",
            "Закрытая",
            "Комплектная"});
            this.tpType.Location = new System.Drawing.Point(104, 91);
            this.tpType.Name = "tpType";
            this.tpType.Size = new System.Drawing.Size(196, 21);
            this.tpType.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Название файла";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Составил";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Дата";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Проверил";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Дата";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Тип подстанции";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Нас. пункт";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 277);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

