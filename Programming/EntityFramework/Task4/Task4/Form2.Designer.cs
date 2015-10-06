namespace Task4
{
    partial class Form2
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
            this.buttonFind = new System.Windows.Forms.Button();
            this.listBoxCertificateFound = new System.Windows.Forms.ListBox();
            this.listBoxResultFound = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(175, 83);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(120, 40);
            this.buttonFind.TabIndex = 0;
            this.buttonFind.Text = "Пошук";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // listBoxCertificateFound
            // 
            this.listBoxCertificateFound.FormattingEnabled = true;
            this.listBoxCertificateFound.Location = new System.Drawing.Point(25, 28);
            this.listBoxCertificateFound.Name = "listBoxCertificateFound";
            this.listBoxCertificateFound.Size = new System.Drawing.Size(120, 95);
            this.listBoxCertificateFound.TabIndex = 1;
            // 
            // listBoxResultFound
            // 
            this.listBoxResultFound.FormattingEnabled = true;
            this.listBoxResultFound.Location = new System.Drawing.Point(334, 28);
            this.listBoxResultFound.Name = "listBoxResultFound";
            this.listBoxResultFound.Size = new System.Drawing.Size(120, 95);
            this.listBoxResultFound.TabIndex = 2;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 148);
            this.Controls.Add(this.listBoxResultFound);
            this.Controls.Add(this.listBoxCertificateFound);
            this.Controls.Add(this.buttonFind);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.ListBox listBoxCertificateFound;
        private System.Windows.Forms.ListBox listBoxResultFound;
    }
}