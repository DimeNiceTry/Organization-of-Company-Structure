namespace ебанешься





{
    partial class addOtdel
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.otdelAddName = new System.Windows.Forms.TextBox();
            this.otdelAddTel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.otdelAddMoney = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(159, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(45, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Наименование";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // otdelAddName
            // 
            this.otdelAddName.Location = new System.Drawing.Point(200, 40);
            this.otdelAddName.Multiline = true;
            this.otdelAddName.Name = "otdelAddName";
            this.otdelAddName.Size = new System.Drawing.Size(212, 25);
            this.otdelAddName.TabIndex = 2;
            // 
            // otdelAddTel
            // 
            this.otdelAddTel.Location = new System.Drawing.Point(200, 71);
            this.otdelAddTel.Multiline = true;
            this.otdelAddTel.Name = "otdelAddTel";
            this.otdelAddTel.Size = new System.Drawing.Size(212, 25);
            this.otdelAddTel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(45, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Телефон";
            // 
            // otdelAddMoney
            // 
            this.otdelAddMoney.Location = new System.Drawing.Point(200, 102);
            this.otdelAddMoney.Multiline = true;
            this.otdelAddMoney.Name = "otdelAddMoney";
            this.otdelAddMoney.Size = new System.Drawing.Size(212, 25);
            this.otdelAddMoney.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(45, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Доход";
            // 
            // addOtdel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 334);
            this.Controls.Add(this.otdelAddMoney);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.otdelAddTel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.otdelAddName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "addOtdel";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox otdelAddName;
        private System.Windows.Forms.TextBox otdelAddTel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox otdelAddMoney;
        private System.Windows.Forms.Label label3;
    }
}