namespace ебанешься
{
    partial class editOtdel
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
            this.naming = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameEdit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.telEdit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.moneyEdit = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(151, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Изменить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // naming
            // 
            this.naming.AutoSize = true;
            this.naming.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.naming.Location = new System.Drawing.Point(200, 33);
            this.naming.Name = "naming";
            this.naming.Size = new System.Drawing.Size(79, 29);
            this.naming.TabIndex = 1;
            this.naming.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(62, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Наименование";
            // 
            // nameEdit
            // 
            this.nameEdit.Location = new System.Drawing.Point(231, 88);
            this.nameEdit.Multiline = true;
            this.nameEdit.Name = "nameEdit";
            this.nameEdit.Size = new System.Drawing.Size(204, 25);
            this.nameEdit.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(62, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Телефон";
            // 
            // telEdit
            // 
            this.telEdit.Location = new System.Drawing.Point(231, 134);
            this.telEdit.Multiline = true;
            this.telEdit.Name = "telEdit";
            this.telEdit.Size = new System.Drawing.Size(204, 25);
            this.telEdit.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(62, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "Доход";
            // 
            // moneyEdit
            // 
            this.moneyEdit.Location = new System.Drawing.Point(231, 182);
            this.moneyEdit.Multiline = true;
            this.moneyEdit.Name = "moneyEdit";
            this.moneyEdit.Size = new System.Drawing.Size(204, 25);
            this.moneyEdit.TabIndex = 17;
            // 
            // editOtdel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 471);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.moneyEdit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.telEdit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.naming);
            this.Controls.Add(this.button1);
            this.Name = "editOtdel";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label naming;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameEdit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox telEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox moneyEdit;
    }
}