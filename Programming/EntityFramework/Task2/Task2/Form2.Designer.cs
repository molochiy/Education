namespace Task2
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
            this.dataGridViewFindAnimals = new System.Windows.Forms.DataGridView();
            this.textBoxFindBreed = new System.Windows.Forms.TextBox();
            this.textBoxFindName = new System.Windows.Forms.TextBox();
            this.radioButtonFindFemale = new System.Windows.Forms.RadioButton();
            this.radioButtonFindMale = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFindAnimals)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(303, 55);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(75, 151);
            this.buttonFind.TabIndex = 27;
            this.buttonFind.Text = "Знайти";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // dataGridViewFindAnimals
            // 
            this.dataGridViewFindAnimals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFindAnimals.Location = new System.Drawing.Point(425, 57);
            this.dataGridViewFindAnimals.Name = "dataGridViewFindAnimals";
            this.dataGridViewFindAnimals.Size = new System.Drawing.Size(310, 149);
            this.dataGridViewFindAnimals.TabIndex = 26;
            // 
            // textBoxFindBreed
            // 
            this.textBoxFindBreed.Location = new System.Drawing.Point(182, 91);
            this.textBoxFindBreed.Name = "textBoxFindBreed";
            this.textBoxFindBreed.Size = new System.Drawing.Size(100, 20);
            this.textBoxFindBreed.TabIndex = 25;
            // 
            // textBoxFindName
            // 
            this.textBoxFindName.Location = new System.Drawing.Point(182, 57);
            this.textBoxFindName.Name = "textBoxFindName";
            this.textBoxFindName.Size = new System.Drawing.Size(100, 20);
            this.textBoxFindName.TabIndex = 24;
            // 
            // radioButtonFindFemale
            // 
            this.radioButtonFindFemale.AutoSize = true;
            this.radioButtonFindFemale.Location = new System.Drawing.Point(182, 164);
            this.radioButtonFindFemale.Name = "radioButtonFindFemale";
            this.radioButtonFindFemale.Size = new System.Drawing.Size(56, 17);
            this.radioButtonFindFemale.TabIndex = 23;
            this.radioButtonFindFemale.TabStop = true;
            this.radioButtonFindFemale.Text = "Жінка";
            this.radioButtonFindFemale.UseVisualStyleBackColor = true;
            this.radioButtonFindFemale.CheckedChanged += new System.EventHandler(this.radioButtonFindFemale_CheckedChanged);
            // 
            // radioButtonFindMale
            // 
            this.radioButtonFindMale.AutoSize = true;
            this.radioButtonFindMale.Location = new System.Drawing.Point(182, 123);
            this.radioButtonFindMale.Name = "radioButtonFindMale";
            this.radioButtonFindMale.Size = new System.Drawing.Size(65, 17);
            this.radioButtonFindMale.TabIndex = 22;
            this.radioButtonFindMale.TabStop = true;
            this.radioButtonFindMale.Text = "Чоловік";
            this.radioButtonFindMale.UseVisualStyleBackColor = true;
            this.radioButtonFindMale.CheckedChanged += new System.EventHandler(this.radioButtonFindMale_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(64, 144);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(111, 17);
            this.radioButton3.TabIndex = 21;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Пошук за статтю";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(64, 94);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(120, 17);
            this.radioButton2.TabIndex = 20;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Пошук за породою";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(64, 60);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(112, 17);
            this.radioButton1.TabIndex = 19;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Пошук за іменем";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 261);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.dataGridViewFindAnimals);
            this.Controls.Add(this.textBoxFindBreed);
            this.Controls.Add(this.textBoxFindName);
            this.Controls.Add(this.radioButtonFindFemale);
            this.Controls.Add(this.radioButtonFindMale);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Name = "Form2";
            this.Text = "Пошук в БД";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFindAnimals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.DataGridView dataGridViewFindAnimals;
        private System.Windows.Forms.TextBox textBoxFindBreed;
        private System.Windows.Forms.TextBox textBoxFindName;
        private System.Windows.Forms.RadioButton radioButtonFindFemale;
        private System.Windows.Forms.RadioButton radioButtonFindMale;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}