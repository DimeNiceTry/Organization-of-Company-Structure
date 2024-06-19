namespace ебанешься
{
    partial class editTasksEmpl
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
            this.zadataOfDead = new System.Windows.Forms.DateTimePicker();
            this.addTask = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.zavalueOfWork = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.zadoneFlag = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.zadName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.zavalueOfWork)).BeginInit();
            this.SuspendLayout();
            // 
            // zadataOfDead
            // 
            this.zadataOfDead.Location = new System.Drawing.Point(351, 123);
            this.zadataOfDead.Name = "zadataOfDead";
            this.zadataOfDead.Size = new System.Drawing.Size(200, 22);
            this.zadataOfDead.TabIndex = 27;
            // 
            // addTask
            // 
            this.addTask.Location = new System.Drawing.Point(195, 332);
            this.addTask.Name = "addTask";
            this.addTask.Size = new System.Drawing.Size(251, 42);
            this.addTask.TabIndex = 26;
            this.addTask.Text = "Изменить";
            this.addTask.UseVisualStyleBackColor = true;
            this.addTask.Click += new System.EventHandler(this.addTask_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(174, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 25);
            this.label6.TabIndex = 25;
            this.label6.Text = "Объём задачи";
            // 
            // zavalueOfWork
            // 
            this.zavalueOfWork.Location = new System.Drawing.Point(351, 151);
            this.zavalueOfWork.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.zavalueOfWork.Name = "zavalueOfWork";
            this.zavalueOfWork.Size = new System.Drawing.Size(120, 22);
            this.zavalueOfWork.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(174, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 25);
            this.label5.TabIndex = 23;
            this.label5.Text = "Срок Выполнения";
            // 
            // zadoneFlag
            // 
            this.zadoneFlag.AutoSize = true;
            this.zadoneFlag.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.zadoneFlag.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zadoneFlag.Location = new System.Drawing.Point(261, 176);
            this.zadoneFlag.Margin = new System.Windows.Forms.Padding(0);
            this.zadoneFlag.Name = "zadoneFlag";
            this.zadoneFlag.Size = new System.Drawing.Size(137, 29);
            this.zadoneFlag.TabIndex = 20;
            this.zadoneFlag.Text = "Выполнена";
            this.zadoneFlag.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(174, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "Название";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(277, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 32);
            this.label1.TabIndex = 18;
            this.label1.Text = "Задача";
            // 
            // zadName
            // 
            this.zadName.Location = new System.Drawing.Point(351, 92);
            this.zadName.Name = "zadName";
            this.zadName.Size = new System.Drawing.Size(138, 22);
            this.zadName.TabIndex = 29;
            // 
            // editTasksEmpl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 501);
            this.Controls.Add(this.zadName);
            this.Controls.Add(this.zadataOfDead);
            this.Controls.Add(this.addTask);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.zavalueOfWork);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.zadoneFlag);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "editTasksEmpl";
            this.Text = "editTasksEmpl";
            ((System.ComponentModel.ISupportInitialize)(this.zavalueOfWork)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker zadataOfDead;
        private System.Windows.Forms.Button addTask;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown zavalueOfWork;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox zadoneFlag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox zadName;
    }
}