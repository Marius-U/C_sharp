namespace Lab_MTP_5
{
    partial class DeleteDialog
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
            this.buttonDa = new System.Windows.Forms.Button();
            this.buttonNu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sigur doriti stergerea studentului din baza de date?";
            // 
            // buttonDa
            // 
            this.buttonDa.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonDa.Location = new System.Drawing.Point(63, 76);
            this.buttonDa.Name = "buttonDa";
            this.buttonDa.Size = new System.Drawing.Size(75, 23);
            this.buttonDa.TabIndex = 1;
            this.buttonDa.Text = "Da";
            this.buttonDa.UseVisualStyleBackColor = true;
            // 
            // buttonNu
            // 
            this.buttonNu.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonNu.Location = new System.Drawing.Point(183, 76);
            this.buttonNu.Name = "buttonNu";
            this.buttonNu.Size = new System.Drawing.Size(75, 23);
            this.buttonNu.TabIndex = 1;
            this.buttonNu.Text = "Nu";
            this.buttonNu.UseVisualStyleBackColor = true;
            // 
            // DeleteDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 162);
            this.Controls.Add(this.buttonNu);
            this.Controls.Add(this.buttonDa);
            this.Controls.Add(this.label1);
            this.Name = "DeleteDialog";
            this.Text = "Confirmati stergerea";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDa;
        private System.Windows.Forms.Button buttonNu;
    }
}