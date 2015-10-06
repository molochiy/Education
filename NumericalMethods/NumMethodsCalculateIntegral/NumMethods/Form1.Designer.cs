namespace NumMethods
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
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.textBoxFunction = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxInitialFunction = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxE = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButtonLeftRectangle = new System.Windows.Forms.RadioButton();
            this.radioButtonRightRectangle = new System.Windows.Forms.RadioButton();
            this.radioButtonMidleRectangle = new System.Windows.Forms.RadioButton();
            this.radioButtonTrapeze = new System.Windows.Forms.RadioButton();
            this.radioButtonSimpson = new System.Windows.Forms.RadioButton();
            this.radioButtonThreeEighths = new System.Windows.Forms.RadioButton();
            this.textBoxIterations = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxInitial = new System.Windows.Forms.TextBox();
            this.textBoxIntegral = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.radioButtonChebyshev = new System.Windows.Forms.RadioButton();
            this.radioButtonGaus = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(75, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Підінтегральна функція";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(80, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "a=";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(298, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "=b";
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(113, 142);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(80, 20);
            this.textBoxA.TabIndex = 3;
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(212, 142);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(80, 20);
            this.textBoxB.TabIndex = 4;
            // 
            // textBoxFunction
            // 
            this.textBoxFunction.Location = new System.Drawing.Point(411, 53);
            this.textBoxFunction.Name = "textBoxFunction";
            this.textBoxFunction.Size = new System.Drawing.Size(279, 20);
            this.textBoxFunction.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(365, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "f(x)=";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(365, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "F(x)=";
            // 
            // textBoxInitialFunction
            // 
            this.textBoxInitialFunction.Location = new System.Drawing.Point(411, 97);
            this.textBoxInitialFunction.Name = "textBoxInitialFunction";
            this.textBoxInitialFunction.Size = new System.Drawing.Size(279, 20);
            this.textBoxInitialFunction.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(75, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(257, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Первісна підінтегральної функції";
            // 
            // textBoxE
            // 
            this.textBoxE.Location = new System.Drawing.Point(175, 192);
            this.textBoxE.Name = "textBoxE";
            this.textBoxE.Size = new System.Drawing.Size(80, 20);
            this.textBoxE.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(142, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "e=";
            // 
            // radioButtonLeftRectangle
            // 
            this.radioButtonLeftRectangle.AutoSize = true;
            this.radioButtonLeftRectangle.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonLeftRectangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonLeftRectangle.ForeColor = System.Drawing.Color.White;
            this.radioButtonLeftRectangle.Location = new System.Drawing.Point(369, 148);
            this.radioButtonLeftRectangle.Name = "radioButtonLeftRectangle";
            this.radioButtonLeftRectangle.Size = new System.Drawing.Size(252, 24);
            this.radioButtonLeftRectangle.TabIndex = 12;
            this.radioButtonLeftRectangle.TabStop = true;
            this.radioButtonLeftRectangle.Text = "Формула лівих прямокутників";
            this.radioButtonLeftRectangle.UseVisualStyleBackColor = false;
            // 
            // radioButtonRightRectangle
            // 
            this.radioButtonRightRectangle.AutoSize = true;
            this.radioButtonRightRectangle.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonRightRectangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonRightRectangle.ForeColor = System.Drawing.Color.White;
            this.radioButtonRightRectangle.Location = new System.Drawing.Point(369, 188);
            this.radioButtonRightRectangle.Name = "radioButtonRightRectangle";
            this.radioButtonRightRectangle.Size = new System.Drawing.Size(266, 24);
            this.radioButtonRightRectangle.TabIndex = 13;
            this.radioButtonRightRectangle.TabStop = true;
            this.radioButtonRightRectangle.Text = "Формула правих прямокутників";
            this.radioButtonRightRectangle.UseVisualStyleBackColor = false;
            // 
            // radioButtonMidleRectangle
            // 
            this.radioButtonMidleRectangle.AutoSize = true;
            this.radioButtonMidleRectangle.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonMidleRectangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonMidleRectangle.ForeColor = System.Drawing.Color.White;
            this.radioButtonMidleRectangle.Location = new System.Drawing.Point(369, 230);
            this.radioButtonMidleRectangle.Name = "radioButtonMidleRectangle";
            this.radioButtonMidleRectangle.Size = new System.Drawing.Size(279, 24);
            this.radioButtonMidleRectangle.TabIndex = 14;
            this.radioButtonMidleRectangle.TabStop = true;
            this.radioButtonMidleRectangle.Text = "Формула середніх прямокутників";
            this.radioButtonMidleRectangle.UseVisualStyleBackColor = false;
            // 
            // radioButtonTrapeze
            // 
            this.radioButtonTrapeze.AutoSize = true;
            this.radioButtonTrapeze.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonTrapeze.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonTrapeze.ForeColor = System.Drawing.Color.White;
            this.radioButtonTrapeze.Location = new System.Drawing.Point(369, 274);
            this.radioButtonTrapeze.Name = "radioButtonTrapeze";
            this.radioButtonTrapeze.Size = new System.Drawing.Size(167, 24);
            this.radioButtonTrapeze.TabIndex = 15;
            this.radioButtonTrapeze.TabStop = true;
            this.radioButtonTrapeze.Text = "Формула трапецій";
            this.radioButtonTrapeze.UseVisualStyleBackColor = false;
            // 
            // radioButtonSimpson
            // 
            this.radioButtonSimpson.AutoSize = true;
            this.radioButtonSimpson.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonSimpson.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonSimpson.ForeColor = System.Drawing.Color.White;
            this.radioButtonSimpson.Location = new System.Drawing.Point(369, 316);
            this.radioButtonSimpson.Name = "radioButtonSimpson";
            this.radioButtonSimpson.Size = new System.Drawing.Size(170, 24);
            this.radioButtonSimpson.TabIndex = 16;
            this.radioButtonSimpson.TabStop = true;
            this.radioButtonSimpson.Text = "Формула Сімпсона";
            this.radioButtonSimpson.UseVisualStyleBackColor = false;
            // 
            // radioButtonThreeEighths
            // 
            this.radioButtonThreeEighths.AutoSize = true;
            this.radioButtonThreeEighths.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonThreeEighths.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonThreeEighths.ForeColor = System.Drawing.Color.White;
            this.radioButtonThreeEighths.Location = new System.Drawing.Point(369, 354);
            this.radioButtonThreeEighths.Name = "radioButtonThreeEighths";
            this.radioButtonThreeEighths.Size = new System.Drawing.Size(210, 24);
            this.radioButtonThreeEighths.TabIndex = 17;
            this.radioButtonThreeEighths.TabStop = true;
            this.radioButtonThreeEighths.Text = "Формула трьох восьмих";
            this.radioButtonThreeEighths.UseVisualStyleBackColor = false;
            // 
            // textBoxIterations
            // 
            this.textBoxIterations.Location = new System.Drawing.Point(229, 395);
            this.textBoxIterations.Name = "textBoxIterations";
            this.textBoxIterations.Size = new System.Drawing.Size(80, 20);
            this.textBoxIterations.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(75, 395);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Кількість ітерацій=";
            // 
            // textBoxInitial
            // 
            this.textBoxInitial.Location = new System.Drawing.Point(130, 358);
            this.textBoxInitial.Name = "textBoxInitial";
            this.textBoxInitial.Size = new System.Drawing.Size(179, 20);
            this.textBoxInitial.TabIndex = 21;
            // 
            // textBoxIntegral
            // 
            this.textBoxIntegral.Location = new System.Drawing.Point(130, 317);
            this.textBoxIntegral.Name = "textBoxIntegral";
            this.textBoxIntegral.Size = new System.Drawing.Size(179, 20);
            this.textBoxIntegral.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(79, 358);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "F(x)=";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(79, 317);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "∫f(x)=";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(79, 245);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(253, 42);
            this.buttonCalculate.TabIndex = 24;
            this.buttonCalculate.Text = "Обчислити";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // radioButtonChebyshev
            // 
            this.radioButtonChebyshev.AutoSize = true;
            this.radioButtonChebyshev.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonChebyshev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonChebyshev.ForeColor = System.Drawing.Color.White;
            this.radioButtonChebyshev.Location = new System.Drawing.Point(369, 429);
            this.radioButtonChebyshev.Name = "radioButtonChebyshev";
            this.radioButtonChebyshev.Size = new System.Drawing.Size(180, 24);
            this.radioButtonChebyshev.TabIndex = 26;
            this.radioButtonChebyshev.TabStop = true;
            this.radioButtonChebyshev.Text = "Формула Чебишева";
            this.radioButtonChebyshev.UseVisualStyleBackColor = false;
            // 
            // radioButtonGaus
            // 
            this.radioButtonGaus.AutoSize = true;
            this.radioButtonGaus.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonGaus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonGaus.ForeColor = System.Drawing.Color.White;
            this.radioButtonGaus.Location = new System.Drawing.Point(369, 391);
            this.radioButtonGaus.Name = "radioButtonGaus";
            this.radioButtonGaus.Size = new System.Drawing.Size(143, 24);
            this.radioButtonGaus.TabIndex = 25;
            this.radioButtonGaus.TabStop = true;
            this.radioButtonGaus.Text = "Формула Гауса";
            this.radioButtonGaus.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(771, 500);
            this.Controls.Add(this.radioButtonChebyshev);
            this.Controls.Add(this.radioButtonGaus);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.textBoxIterations);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxInitial);
            this.Controls.Add(this.textBoxIntegral);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.radioButtonThreeEighths);
            this.Controls.Add(this.radioButtonSimpson);
            this.Controls.Add(this.radioButtonTrapeze);
            this.Controls.Add(this.radioButtonMidleRectangle);
            this.Controls.Add(this.radioButtonRightRectangle);
            this.Controls.Add(this.radioButtonLeftRectangle);
            this.Controls.Add(this.textBoxE);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxInitialFunction);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxFunction);
            this.Controls.Add(this.textBoxB);
            this.Controls.Add(this.textBoxA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.TextBox textBoxFunction;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxInitialFunction;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButtonLeftRectangle;
        private System.Windows.Forms.RadioButton radioButtonRightRectangle;
        private System.Windows.Forms.RadioButton radioButtonMidleRectangle;
        private System.Windows.Forms.RadioButton radioButtonTrapeze;
        private System.Windows.Forms.RadioButton radioButtonSimpson;
        private System.Windows.Forms.RadioButton radioButtonThreeEighths;
        private System.Windows.Forms.TextBox textBoxIterations;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxInitial;
        private System.Windows.Forms.TextBox textBoxIntegral;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.RadioButton radioButtonChebyshev;
        private System.Windows.Forms.RadioButton radioButtonGaus;
    }
}

