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
            this.mainLine = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.radioButtonMetal = new System.Windows.Forms.RadioButton();
            this.radioButtonWood = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.clients = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ankers = new System.Windows.Forms.TextBox();
            this.routes = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineType = new System.Windows.Forms.DataGridView();
            this.type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.to = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Run = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.routes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineType)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // logBox
            // 
            this.logBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logBox.Location = new System.Drawing.Point(0, 293);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(879, 69);
            this.logBox.TabIndex = 0;
            this.logBox.Text = "";
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(104, 27);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(492, 20);
            this.fileName.TabIndex = 1;
            // 
            // make
            // 
            this.make.Location = new System.Drawing.Point(104, 54);
            this.make.Name = "make";
            this.make.Size = new System.Drawing.Size(100, 20);
            this.make.TabIndex = 2;
            // 
            // makeDate
            // 
            this.makeDate.Location = new System.Drawing.Point(248, 54);
            this.makeDate.Name = "makeDate";
            this.makeDate.Size = new System.Drawing.Size(52, 20);
            this.makeDate.TabIndex = 3;
            // 
            // chekedM
            // 
            this.chekedM.Location = new System.Drawing.Point(104, 80);
            this.chekedM.Name = "chekedM";
            this.chekedM.Size = new System.Drawing.Size(100, 20);
            this.chekedM.TabIndex = 4;
            // 
            // chekedDate
            // 
            this.chekedDate.Location = new System.Drawing.Point(248, 80);
            this.chekedDate.Name = "chekedDate";
            this.chekedDate.Size = new System.Drawing.Size(52, 20);
            this.chekedDate.TabIndex = 5;
            // 
            // city
            // 
            this.city.Location = new System.Drawing.Point(400, 54);
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
            this.tpType.Location = new System.Drawing.Point(400, 80);
            this.tpType.Name = "tpType";
            this.tpType.Size = new System.Drawing.Size(196, 21);
            this.tpType.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Название файла";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Составил";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Дата";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Проверил";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(209, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Дата";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(306, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Тип подстанции";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(333, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Нас. пункт";
            // 
            // mainLine
            // 
            this.mainLine.Location = new System.Drawing.Point(104, 27);
            this.mainLine.Name = "mainLine";
            this.mainLine.Size = new System.Drawing.Size(141, 20);
            this.mainLine.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Основная линия";
            // 
            // radioButtonMetal
            // 
            this.radioButtonMetal.AutoSize = true;
            this.radioButtonMetal.Location = new System.Drawing.Point(104, 54);
            this.radioButtonMetal.Name = "radioButtonMetal";
            this.radioButtonMetal.Size = new System.Drawing.Size(45, 17);
            this.radioButtonMetal.TabIndex = 17;
            this.radioButtonMetal.TabStop = true;
            this.radioButtonMetal.Text = "ЖД";
            this.radioButtonMetal.UseVisualStyleBackColor = true;
            // 
            // radioButtonWood
            // 
            this.radioButtonWood.AutoSize = true;
            this.radioButtonWood.Location = new System.Drawing.Point(155, 55);
            this.radioButtonWood.Name = "radioButtonWood";
            this.radioButtonWood.Size = new System.Drawing.Size(90, 17);
            this.radioButtonWood.TabIndex = 18;
            this.radioButtonWood.TabStop = true;
            this.radioButtonWood.Text = "Деревянные";
            this.radioButtonWood.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Тип опоры";
            // 
            // clients
            // 
            this.clients.Location = new System.Drawing.Point(104, 80);
            this.clients.Name = "clients";
            this.clients.Size = new System.Drawing.Size(141, 20);
            this.clients.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(41, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Абоненты";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 109);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Анкерные опоры";
            // 
            // ankers
            // 
            this.ankers.Location = new System.Drawing.Point(104, 106);
            this.ankers.Name = "ankers";
            this.ankers.Size = new System.Drawing.Size(141, 20);
            this.ankers.TabIndex = 22;
            // 
            // routes
            // 
            this.routes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.routes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Count});
            this.routes.Location = new System.Drawing.Point(609, 27);
            this.routes.Name = "routes";
            this.routes.Size = new System.Drawing.Size(224, 100);
            this.routes.TabIndex = 24;
            // 
            // id
            // 
            this.id.HeaderText = "№ Опоры";
            this.id.Name = "id";
            this.id.Width = 80;
            // 
            // Count
            // 
            this.Count.HeaderText = "Кол-во опор";
            this.Count.Name = "Count";
            // 
            // lineType
            // 
            this.lineType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lineType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.type,
            this.from,
            this.to});
            this.lineType.Location = new System.Drawing.Point(260, 27);
            this.lineType.Name = "lineType";
            this.lineType.Size = new System.Drawing.Size(343, 100);
            this.lineType.TabIndex = 25;
            // 
            // type
            // 
            this.type.HeaderText = "Тип линии";
            this.type.Items.AddRange(new object[] {
            "2АС-16",
            "СИП",
            "4АС-50"});
            this.type.Name = "type";
            this.type.Width = 200;
            // 
            // from
            // 
            this.from.HeaderText = "От";
            this.from.Name = "from";
            this.from.Width = 50;
            // 
            // to
            // 
            this.to.HeaderText = "До";
            this.to.Name = "to";
            this.to.Width = 50;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.fileName);
            this.groupBox1.Controls.Add(this.make);
            this.groupBox1.Controls.Add(this.city);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.makeDate);
            this.groupBox1.Controls.Add(this.chekedM);
            this.groupBox1.Controls.Add(this.chekedDate);
            this.groupBox1.Controls.Add(this.tpType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 121);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Файл";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.mainLine);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lineType);
            this.groupBox2.Controls.Add(this.radioButtonMetal);
            this.groupBox2.Controls.Add(this.routes);
            this.groupBox2.Controls.Add(this.radioButtonWood);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.ankers);
            this.groupBox2.Controls.Add(this.clients);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(15, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(852, 148);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Схема";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(681, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Ответвления";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(397, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Тип линий";
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(6, 20);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(75, 23);
            this.Run.TabIndex = 28;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Run);
            this.groupBox3.Location = new System.Drawing.Point(631, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(236, 121);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 362);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.logBox);
            this.MaximumSize = new System.Drawing.Size(895, 800);
            this.MinimumSize = new System.Drawing.Size(895, 400);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.routes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineType)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TextBox mainLine;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButtonMetal;
        private System.Windows.Forms.RadioButton radioButtonWood;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox clients;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ankers;
        private System.Windows.Forms.DataGridView routes;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridView lineType;
        private System.Windows.Forms.DataGridViewComboBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn from;
        private System.Windows.Forms.DataGridViewTextBoxColumn to;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

