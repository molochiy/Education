namespace MyCoffeeMachine_2_
{
    /// <summary>
    /// class machine
    /// </summary>
    partial class Machine
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
            this.Americano = new System.Windows.Forms.Button();
            this.Espresso = new System.Windows.Forms.Button();
            this.Сappuccino = new System.Windows.Forms.Button();
            this.Latte = new System.Windows.Forms.Button();
            this.Ristretto = new System.Windows.Forms.Button();
            this.Sugar = new System.Windows.Forms.Button();
            this.Milk = new System.Windows.Forms.Button();
            this.labelAmericano = new System.Windows.Forms.Label();
            this.labelEspresso = new System.Windows.Forms.Label();
            this.labelСappuccino = new System.Windows.Forms.Label();
            this.labelLatte = new System.Windows.Forms.Label();
            this.labelRistretto = new System.Windows.Forms.Label();
            this.labelSugar = new System.Windows.Forms.Label();
            this.labelMilk = new System.Windows.Forms.Label();
            this.textBoxIngredients = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxTotalPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.money = new System.Windows.Forms.ComboBox();
            this.enterMoney = new System.Windows.Forms.Button();
            this.newOrder = new System.Windows.Forms.Button();
            this.textBoxRest = new System.Windows.Forms.TextBox();
            this.rest = new System.Windows.Forms.Label();
            this.takeRest = new System.Windows.Forms.Button();
            this.printOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Americano
            // 
            this.Americano.Location = new System.Drawing.Point(39, 61);
            this.Americano.Name = "Americano";
            this.Americano.Size = new System.Drawing.Size(75, 23);
            this.Americano.TabIndex = 0;
            this.Americano.Text = "Americano";
            this.Americano.UseVisualStyleBackColor = true;
            this.Americano.Click += new System.EventHandler(this.Americano_Click);
            // 
            // Espresso
            // 
            this.Espresso.Location = new System.Drawing.Point(39, 102);
            this.Espresso.Name = "Espresso";
            this.Espresso.Size = new System.Drawing.Size(75, 23);
            this.Espresso.TabIndex = 1;
            this.Espresso.Text = "Espresso";
            this.Espresso.UseVisualStyleBackColor = true;
            this.Espresso.Click += new System.EventHandler(this.Espresso_Click);
            // 
            // Сappuccino
            // 
            this.Сappuccino.Location = new System.Drawing.Point(39, 144);
            this.Сappuccino.Name = "Сappuccino";
            this.Сappuccino.Size = new System.Drawing.Size(75, 23);
            this.Сappuccino.TabIndex = 2;
            this.Сappuccino.Text = "Сappuccino";
            this.Сappuccino.UseVisualStyleBackColor = true;
            this.Сappuccino.Click += new System.EventHandler(this.Сappuccino_Click);
            // 
            // Latte
            // 
            this.Latte.Location = new System.Drawing.Point(39, 186);
            this.Latte.Name = "Latte";
            this.Latte.Size = new System.Drawing.Size(75, 23);
            this.Latte.TabIndex = 3;
            this.Latte.Text = "Latte";
            this.Latte.UseVisualStyleBackColor = true;
            this.Latte.Click += new System.EventHandler(this.Latte_Click);
            // 
            // Ristretto
            // 
            this.Ristretto.Location = new System.Drawing.Point(39, 228);
            this.Ristretto.Name = "Ristretto";
            this.Ristretto.Size = new System.Drawing.Size(75, 23);
            this.Ristretto.TabIndex = 4;
            this.Ristretto.Text = "Ristretto";
            this.Ristretto.UseVisualStyleBackColor = true;
            this.Ristretto.Click += new System.EventHandler(this.Ristretto_Click);
            // 
            // Sugar
            // 
            this.Sugar.Location = new System.Drawing.Point(39, 271);
            this.Sugar.Name = "Sugar";
            this.Sugar.Size = new System.Drawing.Size(75, 23);
            this.Sugar.TabIndex = 5;
            this.Sugar.Text = "Цукор";
            this.Sugar.UseVisualStyleBackColor = true;
            this.Sugar.Click += new System.EventHandler(this.Sugar_Click);
            // 
            // Milk
            // 
            this.Milk.Location = new System.Drawing.Point(39, 317);
            this.Milk.Name = "Milk";
            this.Milk.Size = new System.Drawing.Size(75, 23);
            this.Milk.TabIndex = 6;
            this.Milk.Text = "Молоко";
            this.Milk.UseVisualStyleBackColor = true;
            this.Milk.Click += new System.EventHandler(this.Milk_Click);
            // 
            // labelAmericano
            // 
            this.labelAmericano.AutoSize = true;
            this.labelAmericano.Location = new System.Drawing.Point(120, 66);
            this.labelAmericano.Name = "labelAmericano";
            this.labelAmericano.Size = new System.Drawing.Size(35, 13);
            this.labelAmericano.TabIndex = 7;
            this.labelAmericano.Text = "label1";
            // 
            // labelEspresso
            // 
            this.labelEspresso.AutoSize = true;
            this.labelEspresso.Location = new System.Drawing.Point(120, 107);
            this.labelEspresso.Name = "labelEspresso";
            this.labelEspresso.Size = new System.Drawing.Size(35, 13);
            this.labelEspresso.TabIndex = 8;
            this.labelEspresso.Text = "label2";
            // 
            // labelСappuccino
            // 
            this.labelСappuccino.AutoSize = true;
            this.labelСappuccino.Location = new System.Drawing.Point(120, 149);
            this.labelСappuccino.Name = "labelСappuccino";
            this.labelСappuccino.Size = new System.Drawing.Size(35, 13);
            this.labelСappuccino.TabIndex = 9;
            this.labelСappuccino.Text = "label3";
            // 
            // labelLatte
            // 
            this.labelLatte.AutoSize = true;
            this.labelLatte.Location = new System.Drawing.Point(120, 191);
            this.labelLatte.Name = "labelLatte";
            this.labelLatte.Size = new System.Drawing.Size(35, 13);
            this.labelLatte.TabIndex = 10;
            this.labelLatte.Text = "label4";
            // 
            // labelRistretto
            // 
            this.labelRistretto.AutoSize = true;
            this.labelRistretto.Location = new System.Drawing.Point(120, 233);
            this.labelRistretto.Name = "labelRistretto";
            this.labelRistretto.Size = new System.Drawing.Size(35, 13);
            this.labelRistretto.TabIndex = 11;
            this.labelRistretto.Text = "label5";
            // 
            // labelSugar
            // 
            this.labelSugar.AutoSize = true;
            this.labelSugar.Location = new System.Drawing.Point(120, 276);
            this.labelSugar.Name = "labelSugar";
            this.labelSugar.Size = new System.Drawing.Size(35, 13);
            this.labelSugar.TabIndex = 12;
            this.labelSugar.Text = "label6";
            // 
            // labelMilk
            // 
            this.labelMilk.AutoSize = true;
            this.labelMilk.Location = new System.Drawing.Point(120, 322);
            this.labelMilk.Name = "labelMilk";
            this.labelMilk.Size = new System.Drawing.Size(35, 13);
            this.labelMilk.TabIndex = 13;
            this.labelMilk.Text = "label7";
            // 
            // textBoxIngredients
            // 
            this.textBoxIngredients.Location = new System.Drawing.Point(232, 63);
            this.textBoxIngredients.Multiline = true;
            this.textBoxIngredients.Name = "textBoxIngredients";
            this.textBoxIngredients.Size = new System.Drawing.Size(114, 233);
            this.textBoxIngredients.TabIndex = 14;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(349, 61);
            this.textBoxPrice.Multiline = true;
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(64, 233);
            this.textBoxPrice.TabIndex = 15;
            // 
            // textBoxTotalPrice
            // 
            this.textBoxTotalPrice.Location = new System.Drawing.Point(313, 300);
            this.textBoxTotalPrice.Name = "textBoxTotalPrice";
            this.textBoxTotalPrice.Size = new System.Drawing.Size(100, 20);
            this.textBoxTotalPrice.TabIndex = 16;
            this.textBoxTotalPrice.Text = "0 грн";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Загальна ціна";
            // 
            // money
            // 
            this.money.FormattingEnabled = true;
            this.money.Items.AddRange(new object[] {
            "1 грн",
            "2 грн",
            "5 грн",
            "10 грн",
            "20 грн",
            "50 грн",
            "100 грн",
            "200 грн",
            "500 грн"});
            this.money.Location = new System.Drawing.Point(229, 337);
            this.money.Name = "money";
            this.money.Size = new System.Drawing.Size(114, 21);
            this.money.TabIndex = 18;
            this.money.Text = "Виберіть гроші";
            // 
            // enterMoney
            // 
            this.enterMoney.Location = new System.Drawing.Point(349, 335);
            this.enterMoney.Name = "enterMoney";
            this.enterMoney.Size = new System.Drawing.Size(64, 23);
            this.enterMoney.TabIndex = 19;
            this.enterMoney.Text = "Ввід";
            this.enterMoney.UseVisualStyleBackColor = true;
            this.enterMoney.Click += new System.EventHandler(this.enterMoney_Click);
            // 
            // newOrder
            // 
            this.newOrder.Location = new System.Drawing.Point(38, 13);
            this.newOrder.Name = "newOrder";
            this.newOrder.Size = new System.Drawing.Size(375, 23);
            this.newOrder.TabIndex = 20;
            this.newOrder.Text = "Нове замовлення";
            this.newOrder.UseVisualStyleBackColor = true;
            this.newOrder.Click += new System.EventHandler(this.newOrder_Click);
            // 
            // textBoxRest
            // 
            this.textBoxRest.Location = new System.Drawing.Point(123, 396);
            this.textBoxRest.Name = "textBoxRest";
            this.textBoxRest.Size = new System.Drawing.Size(100, 20);
            this.textBoxRest.TabIndex = 21;
            // 
            // rest
            // 
            this.rest.AutoSize = true;
            this.rest.Location = new System.Drawing.Point(56, 399);
            this.rest.Name = "rest";
            this.rest.Size = new System.Drawing.Size(39, 13);
            this.rest.TabIndex = 22;
            this.rest.Text = "Решта";
            // 
            // takeRest
            // 
            this.takeRest.Location = new System.Drawing.Point(243, 394);
            this.takeRest.Name = "takeRest";
            this.takeRest.Size = new System.Drawing.Size(170, 23);
            this.takeRest.TabIndex = 23;
            this.takeRest.Text = "Забрати решту і каву";
            this.takeRest.UseVisualStyleBackColor = true;
            this.takeRest.Click += new System.EventHandler(this.takeRest_Click);
            // 
            // printOrder
            // 
            this.printOrder.Location = new System.Drawing.Point(39, 446);
            this.printOrder.Name = "printOrder";
            this.printOrder.Size = new System.Drawing.Size(374, 23);
            this.printOrder.TabIndex = 24;
            this.printOrder.Text = "Друкувати чек";
            this.printOrder.UseVisualStyleBackColor = true;
            this.printOrder.Click += new System.EventHandler(this.printOrder_Click);
            // 
            // Machine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 493);
            this.Controls.Add(this.printOrder);
            this.Controls.Add(this.takeRest);
            this.Controls.Add(this.rest);
            this.Controls.Add(this.textBoxRest);
            this.Controls.Add(this.newOrder);
            this.Controls.Add(this.enterMoney);
            this.Controls.Add(this.money);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTotalPrice);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxIngredients);
            this.Controls.Add(this.labelMilk);
            this.Controls.Add(this.labelSugar);
            this.Controls.Add(this.labelRistretto);
            this.Controls.Add(this.labelLatte);
            this.Controls.Add(this.labelСappuccino);
            this.Controls.Add(this.labelEspresso);
            this.Controls.Add(this.labelAmericano);
            this.Controls.Add(this.Milk);
            this.Controls.Add(this.Sugar);
            this.Controls.Add(this.Ristretto);
            this.Controls.Add(this.Latte);
            this.Controls.Add(this.Сappuccino);
            this.Controls.Add(this.Espresso);
            this.Controls.Add(this.Americano);
            this.Name = "Machine";
            this.Text = "Coffee Machine";
            this.Load += new System.EventHandler(this.Machine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Americano;
        private System.Windows.Forms.Button Espresso;
        private System.Windows.Forms.Button Сappuccino;
        private System.Windows.Forms.Button Latte;
        private System.Windows.Forms.Button Ristretto;
        private System.Windows.Forms.Button Sugar;
        private System.Windows.Forms.Button Milk;
        private System.Windows.Forms.Label labelAmericano;
        private System.Windows.Forms.Label labelEspresso;
        private System.Windows.Forms.Label labelСappuccino;
        private System.Windows.Forms.Label labelLatte;
        private System.Windows.Forms.Label labelRistretto;
        private System.Windows.Forms.Label labelSugar;
        private System.Windows.Forms.Label labelMilk;
        private System.Windows.Forms.TextBox textBoxIngredients;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxTotalPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox money;
        private System.Windows.Forms.Button enterMoney;
        private System.Windows.Forms.Button newOrder;
        private System.Windows.Forms.TextBox textBoxRest;
        private System.Windows.Forms.Label rest;
        private System.Windows.Forms.Button takeRest;
        private System.Windows.Forms.Button printOrder;
    }
}

