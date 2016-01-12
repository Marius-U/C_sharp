namespace KeyPress
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textKey1 = new System.Windows.Forms.TextBox();
            this.textKey2 = new System.Windows.Forms.TextBox();
            this.textKey3 = new System.Windows.Forms.TextBox();
            this.textTime1 = new System.Windows.Forms.TextBox();
            this.textTime2 = new System.Windows.Forms.TextBox();
            this.textTime3 = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "KEY:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "TIME:";
            // 
            // textKey1
            // 
            this.textKey1.Location = new System.Drawing.Point(64, 27);
            this.textKey1.Name = "textKey1";
            this.textKey1.Size = new System.Drawing.Size(51, 20);
            this.textKey1.TabIndex = 1;
            // 
            // textKey2
            // 
            this.textKey2.Location = new System.Drawing.Point(121, 27);
            this.textKey2.Name = "textKey2";
            this.textKey2.Size = new System.Drawing.Size(51, 20);
            this.textKey2.TabIndex = 1;
            // 
            // textKey3
            // 
            this.textKey3.Location = new System.Drawing.Point(178, 27);
            this.textKey3.Name = "textKey3";
            this.textKey3.Size = new System.Drawing.Size(51, 20);
            this.textKey3.TabIndex = 1;
            // 
            // textTime1
            // 
            this.textTime1.Location = new System.Drawing.Point(64, 64);
            this.textTime1.Name = "textTime1";
            this.textTime1.Size = new System.Drawing.Size(51, 20);
            this.textTime1.TabIndex = 1;
            // 
            // textTime2
            // 
            this.textTime2.Location = new System.Drawing.Point(121, 64);
            this.textTime2.Name = "textTime2";
            this.textTime2.Size = new System.Drawing.Size(51, 20);
            this.textTime2.TabIndex = 1;
            // 
            // textTime3
            // 
            this.textTime3.Location = new System.Drawing.Point(178, 64);
            this.textTime3.Name = "textTime3";
            this.textTime3.Size = new System.Drawing.Size(51, 20);
            this.textTime3.TabIndex = 1;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(110, 116);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(121, 90);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(51, 20);
            this.textBox1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 155);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textKey3);
            this.Controls.Add(this.textKey2);
            this.Controls.Add(this.textTime3);
            this.Controls.Add(this.textTime2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textTime1);
            this.Controls.Add(this.textKey1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textKey1;
        private System.Windows.Forms.TextBox textKey2;
        private System.Windows.Forms.TextBox textKey3;
        private System.Windows.Forms.TextBox textTime1;
        private System.Windows.Forms.TextBox textTime2;
        private System.Windows.Forms.TextBox textTime3;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox textBox1;
    }
}

