namespace ебанешься
{
    partial class MainForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Сотрудники");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Отделы");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Организация задач");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Образование");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Должности");
            this.btnOk = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.findBox = new System.Windows.Forms.TextBox();
            this.NameOfTable = new System.Windows.Forms.Label();
            this.dgData = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.countzadButton = new System.Windows.Forms.Button();
            this.dismissed_workersBut = new System.Windows.Forms.Button();
            this.podzapSELECT = new System.Windows.Forms.Button();
            this.podzapWHERE = new System.Windows.Forms.Button();
            this.podzapfromm = new System.Windows.Forms.Button();
            this.korelzap = new System.Windows.Forms.Button();
            this.korelzap2 = new System.Windows.Forms.Button();
            this.kolzap3 = new System.Windows.Forms.Button();
            this.grouphaving = new System.Windows.Forms.Button();
            this.anyzap = new System.Windows.Forms.Button();
            this.satzh = new System.Windows.Forms.NumericUpDown();
            this.priozad = new System.Windows.Forms.NumericUpDown();
            this.anyzappick = new System.Windows.Forms.DateTimePicker();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.satzh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priozad)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(112, 33);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(103, 48);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Изменить запись";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 48);
            this.button2.TabIndex = 4;
            this.button2.Text = "Добавить запись";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(221, 33);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(94, 48);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Удалить запись";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(3, 4);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Personal";
            treeNode1.Text = "Сотрудники";
            treeNode2.Name = "Services";
            treeNode2.Text = "Отделы";
            treeNode3.Name = "Tasks";
            treeNode3.Text = "Организация задач";
            treeNode4.Name = "Узел0";
            treeNode4.Text = "Образование";
            treeNode5.Name = "dlozh";
            treeNode5.Text = "Должности";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.treeView1.Size = new System.Drawing.Size(258, 166);
            this.treeView1.TabIndex = 6;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.findBox);
            this.panel2.Controls.Add(this.NameOfTable);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Controls.Add(this.deleteButton);
            this.panel2.Location = new System.Drawing.Point(273, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(891, 84);
            this.panel2.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(592, 47);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(177, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Добавить задачу";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(488, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 8;
            this.button1.Text = "Найти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // findBox
            // 
            this.findBox.Location = new System.Drawing.Point(321, 46);
            this.findBox.Multiline = true;
            this.findBox.Name = "findBox";
            this.findBox.Size = new System.Drawing.Size(161, 24);
            this.findBox.TabIndex = 7;
            // 
            // NameOfTable
            // 
            this.NameOfTable.AutoSize = true;
            this.NameOfTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameOfTable.Location = new System.Drawing.Point(400, 0);
            this.NameOfTable.Name = "NameOfTable";
            this.NameOfTable.Size = new System.Drawing.Size(92, 32);
            this.NameOfTable.TabIndex = 6;
            this.NameOfTable.Text = "label1";
            // 
            // dgData
            // 
            this.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgData.Location = new System.Drawing.Point(15, 0);
            this.dgData.Name = "dgData";
            this.dgData.RowHeadersWidth = 51;
            this.dgData.RowTemplate.Height = 24;
            this.dgData.Size = new System.Drawing.Size(1186, 580);
            this.dgData.TabIndex = 2;
            this.dgData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgData_CellClick);
            this.dgData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgData_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.dgData);
            this.panel1.Location = new System.Drawing.Point(325, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 536);
            this.panel1.TabIndex = 7;
            // 
            // countzadButton
            // 
            this.countzadButton.Location = new System.Drawing.Point(3, 176);
            this.countzadButton.Name = "countzadButton";
            this.countzadButton.Size = new System.Drawing.Size(258, 42);
            this.countzadButton.TabIndex = 9;
            this.countzadButton.Text = "Наличие высшего образования сотрудиков";
            this.countzadButton.UseVisualStyleBackColor = true;
            this.countzadButton.Click += new System.EventHandler(this.countzadButton_Click);
            // 
            // dismissed_workersBut
            // 
            this.dismissed_workersBut.Location = new System.Drawing.Point(3, 176);
            this.dismissed_workersBut.Name = "dismissed_workersBut";
            this.dismissed_workersBut.Size = new System.Drawing.Size(258, 42);
            this.dismissed_workersBut.TabIndex = 10;
            this.dismissed_workersBut.Text = "Уволенные сотрудники";
            this.dismissed_workersBut.UseVisualStyleBackColor = true;
            this.dismissed_workersBut.Visible = false;
            this.dismissed_workersBut.Click += new System.EventHandler(this.dismissed_workersBut_Click);
            // 
            // podzapSELECT
            // 
            this.podzapSELECT.Location = new System.Drawing.Point(3, 224);
            this.podzapSELECT.Name = "podzapSELECT";
            this.podzapSELECT.Size = new System.Drawing.Size(258, 42);
            this.podzapSELECT.TabIndex = 11;
            this.podzapSELECT.Text = "Загруженность сотрудников";
            this.podzapSELECT.UseVisualStyleBackColor = true;
            this.podzapSELECT.Click += new System.EventHandler(this.podzapSELECT_Click);
            // 
            // podzapWHERE
            // 
            this.podzapWHERE.Location = new System.Drawing.Point(3, 272);
            this.podzapWHERE.Name = "podzapWHERE";
            this.podzapWHERE.Size = new System.Drawing.Size(155, 42);
            this.podzapWHERE.TabIndex = 12;
            this.podzapWHERE.Text = "Сотрудники со стажем, большим:";
            this.podzapWHERE.UseVisualStyleBackColor = true;
            this.podzapWHERE.Click += new System.EventHandler(this.podzapWHERE_Click);
            // 
            // podzapfromm
            // 
            this.podzapfromm.Location = new System.Drawing.Point(3, 320);
            this.podzapfromm.Name = "podzapfromm";
            this.podzapfromm.Size = new System.Drawing.Size(155, 42);
            this.podzapfromm.TabIndex = 13;
            this.podzapfromm.Text = "Задачи с приоритетом выше:";
            this.podzapfromm.UseVisualStyleBackColor = true;
            this.podzapfromm.Click += new System.EventHandler(this.podzapfromm_Click);
            // 
            // korelzap
            // 
            this.korelzap.Location = new System.Drawing.Point(3, 368);
            this.korelzap.Name = "korelzap";
            this.korelzap.Size = new System.Drawing.Size(258, 42);
            this.korelzap.TabIndex = 14;
            this.korelzap.Text = "Среднее количество задач на сотрудников";
            this.korelzap.UseVisualStyleBackColor = true;
            this.korelzap.Click += new System.EventHandler(this.korelzap_Click);
            // 
            // korelzap2
            // 
            this.korelzap2.Location = new System.Drawing.Point(3, 416);
            this.korelzap2.Name = "korelzap2";
            this.korelzap2.Size = new System.Drawing.Size(258, 42);
            this.korelzap2.TabIndex = 15;
            this.korelzap2.Text = "Количество сотрудников в каждом отделе";
            this.korelzap2.UseVisualStyleBackColor = true;
            this.korelzap2.Click += new System.EventHandler(this.korelzap2_Click);
            // 
            // kolzap3
            // 
            this.kolzap3.Location = new System.Drawing.Point(3, 464);
            this.kolzap3.Name = "kolzap3";
            this.kolzap3.Size = new System.Drawing.Size(258, 42);
            this.kolzap3.TabIndex = 16;
            this.kolzap3.Text = "Процент людей с высшим образованием в отделах";
            this.kolzap3.UseVisualStyleBackColor = true;
            this.kolzap3.Click += new System.EventHandler(this.kolzap3_Click);
            // 
            // grouphaving
            // 
            this.grouphaving.Location = new System.Drawing.Point(3, 512);
            this.grouphaving.Name = "grouphaving";
            this.grouphaving.Size = new System.Drawing.Size(258, 42);
            this.grouphaving.TabIndex = 17;
            this.grouphaving.Text = "Загруженные сотрудники";
            this.grouphaving.UseVisualStyleBackColor = true;
            this.grouphaving.Click += new System.EventHandler(this.grouphaving_Click);
            // 
            // anyzap
            // 
            this.anyzap.Location = new System.Drawing.Point(3, 560);
            this.anyzap.Name = "anyzap";
            this.anyzap.Size = new System.Drawing.Size(152, 42);
            this.anyzap.TabIndex = 18;
            this.anyzap.Text = "Дедлайн раньше:";
            this.anyzap.UseVisualStyleBackColor = true;
            this.anyzap.Click += new System.EventHandler(this.anyzap_Click);
            // 
            // satzh
            // 
            this.satzh.Location = new System.Drawing.Point(164, 283);
            this.satzh.Name = "satzh";
            this.satzh.Size = new System.Drawing.Size(155, 22);
            this.satzh.TabIndex = 20;
            // 
            // priozad
            // 
            this.priozad.Location = new System.Drawing.Point(161, 331);
            this.priozad.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.priozad.Name = "priozad";
            this.priozad.Size = new System.Drawing.Size(158, 22);
            this.priozad.TabIndex = 21;
            // 
            // anyzappick
            // 
            this.anyzappick.Location = new System.Drawing.Point(164, 568);
            this.anyzappick.Name = "anyzappick";
            this.anyzappick.Size = new System.Drawing.Size(158, 22);
            this.anyzappick.TabIndex = 22;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 692);
            this.Controls.Add(this.anyzappick);
            this.Controls.Add(this.priozad);
            this.Controls.Add(this.satzh);
            this.Controls.Add(this.anyzap);
            this.Controls.Add(this.grouphaving);
            this.Controls.Add(this.kolzap3);
            this.Controls.Add(this.korelzap2);
            this.Controls.Add(this.korelzap);
            this.Controls.Add(this.podzapfromm);
            this.Controls.Add(this.podzapWHERE);
            this.Controls.Add(this.podzapSELECT);
            this.Controls.Add(this.dismissed_workersBut);
            this.Controls.Add(this.countzadButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView1);
            this.Name = "MainForm";
            this.Text = "Добро пожаловать!";
            this.Load += new System.EventHandler(this.MainForm_Load_1);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.satzh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priozad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Label NameOfTable;
        private System.Windows.Forms.TextBox findBox;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.DataGridView dgData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button countzadButton;
        private System.Windows.Forms.Button dismissed_workersBut;
        private System.Windows.Forms.Button podzapSELECT;
        private System.Windows.Forms.Button podzapWHERE;
        private System.Windows.Forms.Button podzapFROM;
        private System.Windows.Forms.Button podzapfromm;
        private System.Windows.Forms.Button korelzap;
        private System.Windows.Forms.Button korelzap2;
        private System.Windows.Forms.Button kolzap3;
        private System.Windows.Forms.Button grouphaving;
        private System.Windows.Forms.Button anyzap;
        private System.Windows.Forms.NumericUpDown satzh;
        private System.Windows.Forms.NumericUpDown priozad;
        private System.Windows.Forms.DateTimePicker anyzappick;
        private System.Windows.Forms.Button button3;
    }
}

