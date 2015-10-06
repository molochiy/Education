namespace methods
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonIterations = new System.Windows.Forms.RadioButton();
            this.radioButtonChords = new System.Windows.Forms.RadioButton();
            this.radioButtonTangents = new System.Windows.Forms.RadioButton();
            this.radioButtonCombined = new System.Windows.Forms.RadioButton();
            this.textBoxFunction = new System.Windows.Forms.TextBox();
            this.textBoxLeftLimit = new System.Windows.Forms.TextBox();
            this.textBoxRightLimit = new System.Windows.Forms.TextBox();
            this.textBoxAccuracy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRoot = new System.Windows.Forms.TextBox();
            this.textBoxAmountIteration = new System.Windows.Forms.TextBox();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxFunction2 = new System.Windows.Forms.TextBox();
            this.textBoxFunction3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(326, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "f(x) = ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(36, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "a = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(223, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = " = b";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(293, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Точність";
            // 
            // radioButtonIterations
            // 
            this.radioButtonIterations.AutoSize = true;
            this.radioButtonIterations.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonIterations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonIterations.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radioButtonIterations.Location = new System.Drawing.Point(40, 38);
            this.radioButtonIterations.Name = "radioButtonIterations";
            this.radioButtonIterations.Size = new System.Drawing.Size(125, 21);
            this.radioButtonIterations.TabIndex = 4;
            this.radioButtonIterations.TabStop = true;
            this.radioButtonIterations.Text = "Метод ітерацій";
            this.radioButtonIterations.UseVisualStyleBackColor = false;
            // 
            // radioButtonChords
            // 
            this.radioButtonChords.AutoSize = true;
            this.radioButtonChords.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonChords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonChords.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radioButtonChords.Location = new System.Drawing.Point(40, 61);
            this.radioButtonChords.Name = "radioButtonChords";
            this.radioButtonChords.Size = new System.Drawing.Size(102, 21);
            this.radioButtonChords.TabIndex = 5;
            this.radioButtonChords.TabStop = true;
            this.radioButtonChords.Text = "Метод хорд";
            this.radioButtonChords.UseVisualStyleBackColor = false;
            // 
            // radioButtonTangents
            // 
            this.radioButtonTangents.AutoSize = true;
            this.radioButtonTangents.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonTangents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonTangents.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.radioButtonTangents.Location = new System.Drawing.Point(40, 84);
            this.radioButtonTangents.Name = "radioButtonTangents";
            this.radioButtonTangents.Size = new System.Drawing.Size(133, 21);
            this.radioButtonTangents.TabIndex = 6;
            this.radioButtonTangents.TabStop = true;
            this.radioButtonTangents.Text = "Метод дотичних";
            this.radioButtonTangents.UseVisualStyleBackColor = false;
            // 
            // radioButtonCombined
            // 
            this.radioButtonCombined.AutoSize = true;
            this.radioButtonCombined.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonCombined.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonCombined.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.radioButtonCombined.Location = new System.Drawing.Point(40, 107);
            this.radioButtonCombined.Name = "radioButtonCombined";
            this.radioButtonCombined.Size = new System.Drawing.Size(268, 21);
            this.radioButtonCombined.TabIndex = 7;
            this.radioButtonCombined.TabStop = true;
            this.radioButtonCombined.Text = "Комбінований метод хорд і дотичних";
            this.radioButtonCombined.UseVisualStyleBackColor = false;
            // 
            // textBoxFunction
            // 
            this.textBoxFunction.Location = new System.Drawing.Point(373, 39);
            this.textBoxFunction.Name = "textBoxFunction";
            this.textBoxFunction.Size = new System.Drawing.Size(181, 20);
            this.textBoxFunction.TabIndex = 8;
            // 
            // textBoxLeftLimit
            // 
            this.textBoxLeftLimit.Location = new System.Drawing.Point(77, 146);
            this.textBoxLeftLimit.Name = "textBoxLeftLimit";
            this.textBoxLeftLimit.Size = new System.Drawing.Size(63, 20);
            this.textBoxLeftLimit.TabIndex = 9;
            // 
            // textBoxRightLimit
            // 
            this.textBoxRightLimit.Location = new System.Drawing.Point(156, 146);
            this.textBoxRightLimit.Name = "textBoxRightLimit";
            this.textBoxRightLimit.Size = new System.Drawing.Size(61, 20);
            this.textBoxRightLimit.TabIndex = 10;
            // 
            // textBoxAccuracy
            // 
            this.textBoxAccuracy.Location = new System.Drawing.Point(373, 148);
            this.textBoxAccuracy.Name = "textBoxAccuracy";
            this.textBoxAccuracy.Size = new System.Drawing.Size(100, 20);
            this.textBoxAccuracy.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(306, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Корінь";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label6.Location = new System.Drawing.Point(306, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Кількість ітерацій";
            // 
            // textBoxRoot
            // 
            this.textBoxRoot.Location = new System.Drawing.Point(373, 189);
            this.textBoxRoot.Name = "textBoxRoot";
            this.textBoxRoot.Size = new System.Drawing.Size(183, 20);
            this.textBoxRoot.TabIndex = 14;
            // 
            // textBoxAmountIteration
            // 
            this.textBoxAmountIteration.Location = new System.Drawing.Point(454, 221);
            this.textBoxAmountIteration.Name = "textBoxAmountIteration";
            this.textBoxAmountIteration.Size = new System.Drawing.Size(102, 20);
            this.textBoxAmountIteration.TabIndex = 15;
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCalculate.Location = new System.Drawing.Point(40, 189);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(228, 52);
            this.buttonCalculate.TabIndex = 16;
            this.buttonCalculate.Text = "Обчислити";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label7.Location = new System.Drawing.Point(323, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "f\'(x) = ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label8.Location = new System.Drawing.Point(320, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "f\"(x) = ";
            // 
            // textBoxFunction2
            // 
            this.textBoxFunction2.Location = new System.Drawing.Point(373, 72);
            this.textBoxFunction2.Name = "textBoxFunction2";
            this.textBoxFunction2.Size = new System.Drawing.Size(181, 20);
            this.textBoxFunction2.TabIndex = 19;
            // 
            // textBoxFunction3
            // 
            this.textBoxFunction3.Location = new System.Drawing.Point(373, 105);
            this.textBoxFunction3.Name = "textBoxFunction3";
            this.textBoxFunction3.Size = new System.Drawing.Size(181, 20);
            this.textBoxFunction3.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(600, 317);
            this.Controls.Add(this.textBoxFunction3);
            this.Controls.Add(this.textBoxFunction2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.textBoxAmountIteration);
            this.Controls.Add(this.textBoxRoot);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxAccuracy);
            this.Controls.Add(this.textBoxRightLimit);
            this.Controls.Add(this.textBoxLeftLimit);
            this.Controls.Add(this.textBoxFunction);
            this.Controls.Add(this.radioButtonCombined);
            this.Controls.Add(this.radioButtonTangents);
            this.Controls.Add(this.radioButtonChords);
            this.Controls.Add(this.radioButtonIterations);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Чисельні методи";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButtonIterations;
        private System.Windows.Forms.RadioButton radioButtonChords;
        private System.Windows.Forms.RadioButton radioButtonTangents;
        private System.Windows.Forms.RadioButton radioButtonCombined;
        private System.Windows.Forms.TextBox textBoxFunction;
        private System.Windows.Forms.TextBox textBoxLeftLimit;
        private System.Windows.Forms.TextBox textBoxRightLimit;
        private System.Windows.Forms.TextBox textBoxAccuracy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRoot;
        private System.Windows.Forms.TextBox textBoxAmountIteration;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxFunction2;
        private System.Windows.Forms.TextBox textBoxFunction3;
    }
}

