namespace MyCoffeeMachine_2_
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// class Machine
    /// </summary>
    public partial class Machine : Form
    {
        /// <summary>
        /// field ingredients
        /// </summary>
        public static List<Ingredient> ingredients = new List<Ingredient>();

        /// <summary>
        /// field order
        /// </summary>
        public static Order order = new Order();

        /// <summary>
        /// fields m, c, s
        /// </summary>
        public static int m = 0, c = 0, s = 0;

        /// <summary>
        /// field price
        /// </summary>
        public static double price = 0.0;

        /// <summary>
        /// Initializes a new instance of the <see cref="Machine" /> class
        /// </summary>
        public Machine()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Machine Load
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">event</param>
        private void Machine_Load(object sender, EventArgs e)
        {
            string[] data = File.ReadAllLines("ingredients.txt");
            foreach (string i in data)
            {
                string name = i.Substring(0, i.IndexOf(' '));
                double price = double.Parse(i.Remove(0, i.IndexOf(' ') + 1));
                
                ingredients.Add(new Ingredient(name, price));
            }

            labelAmericano.Text = System.Convert.ToString(ingredients[0].Price) + " грн";
            labelEspresso.Text = System.Convert.ToString(ingredients[1].Price) + " грн";
            labelСappuccino.Text = System.Convert.ToString(ingredients[2].Price) + " грн";
            labelLatte.Text = System.Convert.ToString(ingredients[3].Price) + " грн";
            labelRistretto.Text = System.Convert.ToString(ingredients[4].Price) + " грн";
            labelSugar.Text = System.Convert.ToString(ingredients[5].Price) + " грн";
            labelMilk.Text = System.Convert.ToString(ingredients[6].Price) + " грн";
            textBoxIngredients.ReadOnly = true;
            textBoxIngredients.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBoxPrice.ReadOnly = true;
            textBoxPrice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBoxTotalPrice.ReadOnly = true;
            textBoxRest.ReadOnly = true;
            takeRest.Enabled = false;
            printOrder.Enabled = false;
            enterMoney.Enabled = false;
            money.Enabled = false;
            Milk.Enabled = false;
            Sugar.Enabled = false;
        }

        /// <summary>
        /// add americano to list ordering
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">e</param>
        private void Americano_Click(object sender, EventArgs e)
        {
            textBoxIngredients.Text += ingredients[0].Name + Environment.NewLine;
            textBoxPrice.Text += ingredients[0].Price + " грн" + Environment.NewLine;
            
            textBoxTotalPrice.Clear();
            Espresso.Enabled = false;
            Сappuccino.Enabled = false;
            Latte.Enabled = false;
            Ristretto.Enabled = false;
            enterMoney.Enabled = true;
            money.Enabled = true;
            Milk.Enabled = true;
            Sugar.Enabled = true;

            order.AddIngredientInOrder(new Ingredient(ingredients[0].Name, ingredients[0].Price));

            textBoxTotalPrice.Text = System.Convert.ToString(order.CalculatePriceOfOrder() + " грн.");

            c++;

            if (c == 2)
            {
                Americano.Enabled = false;
                MessageBox.Show("Ви взяли подвійне Americano. \n Більше Ви не зможете взяти Americano!", "Americano");
            }

        }

        /// <summary>
        /// add espresso to list orders
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">e</param>
        private void Espresso_Click(object sender, EventArgs e)
        {
            textBoxIngredients.Text += ingredients[1].Name + Environment.NewLine;
            textBoxPrice.Text += ingredients[1].Price + " грн" + Environment.NewLine;

            textBoxTotalPrice.Clear();
            Americano.Enabled = false;
            Сappuccino.Enabled = false;
            Latte.Enabled = false;
            Ristretto.Enabled = false;
            enterMoney.Enabled = true;
            money.Enabled = true;
            Milk.Enabled = true;
            Sugar.Enabled = true;

            order.AddIngredientInOrder(new Ingredient(ingredients[1].Name, ingredients[1].Price));

            textBoxTotalPrice.Text = System.Convert.ToString(order.CalculatePriceOfOrder() + " грн.");

            c++;

            if (c == 2)
            {
                Espresso.Enabled = false;
                MessageBox.Show("Ви взяли подвійне Espresso. \n Більше Ви не зможете взяти Espresso!", "Espresso");
            }
        }

        /// <summary>
        /// add cappuccino to list orders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Сappuccino_Click(object sender, EventArgs e)
        {
            textBoxIngredients.Text += ingredients[2].Name + Environment.NewLine;
            textBoxPrice.Text += ingredients[2].Price + " грн" + Environment.NewLine;

            textBoxTotalPrice.Clear();
            Americano.Enabled = false;
            Espresso.Enabled = false;
            Latte.Enabled = false;
            Ristretto.Enabled = false;
            enterMoney.Enabled = true;
            money.Enabled = true;
            Milk.Enabled = true;
            Sugar.Enabled = true;

            order.AddIngredientInOrder(new Ingredient(ingredients[2].Name, ingredients[2].Price));

            textBoxTotalPrice.Text = System.Convert.ToString(order.CalculatePriceOfOrder() + " грн.");

            c++;

            if (c == 2)
            {
                Сappuccino.Enabled = false;
                MessageBox.Show("Ви взяли подвійне Сappuccino. \n Більше Ви не зможете взяти Сappuccino!", "Сappuccino");
            }

        }

        /// <summary>
        /// add latte to list orders
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">e</param>
        private void Latte_Click(object sender, EventArgs e)
        {
            textBoxIngredients.Text += ingredients[3].Name + Environment.NewLine;
            textBoxPrice.Text += ingredients[3].Price + " грн" + Environment.NewLine;

            textBoxTotalPrice.Clear();
            Americano.Enabled = false;
            Сappuccino.Enabled = false;
            Espresso.Enabled = false;
            Ristretto.Enabled = false;
            enterMoney.Enabled = true;
            money.Enabled = true;
            Milk.Enabled = true;
            Sugar.Enabled = true;

            order.AddIngredientInOrder(new Ingredient(ingredients[3].Name, ingredients[3].Price));

            textBoxTotalPrice.Text = System.Convert.ToString(order.CalculatePriceOfOrder() + " грн.");

            c++;

            if (c == 2)
            {
                Latte.Enabled = false;
                MessageBox.Show("Ви взяли подвійне Latte. \n Більше Ви не зможете взяти Latte!", "Latte");
            }

        }

        /// <summary>
        /// add ristretto to list orders
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">e</param>
        private void Ristretto_Click(object sender, EventArgs e)
        {
            textBoxIngredients.Text += ingredients[4].Name + Environment.NewLine;
            textBoxPrice.Text += ingredients[4].Price + " грн" + Environment.NewLine;

            textBoxTotalPrice.Clear();
            Americano.Enabled = false;
            Сappuccino.Enabled = false;
            Latte.Enabled = false;
            Espresso.Enabled = false;
            enterMoney.Enabled = true;
            money.Enabled = true;
            Milk.Enabled = true;
            Sugar.Enabled = true;

            order.AddIngredientInOrder(new Ingredient(ingredients[4].Name, ingredients[4].Price));

            textBoxTotalPrice.Text = System.Convert.ToString(order.CalculatePriceOfOrder() + " грн.");

            c++;

            if (c == 2)
            {
                Ristretto.Enabled = false;
                MessageBox.Show("Ви взяли подвійне Ristretto. \n Більше Ви не зможете взяти Ristretto!", "Ristretto");
            }

        }

        /// <summary>
        /// add sugar to list orders
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">e</param>
        private void Sugar_Click(object sender, EventArgs e)
        {
            textBoxIngredients.Text += ingredients[5].Name + Environment.NewLine;
            textBoxPrice.Text += ingredients[5].Price + " грн" + Environment.NewLine;

            enterMoney.Enabled = true;
            money.Enabled = true;

            order.AddIngredientInOrder(new Ingredient(ingredients[5].Name, ingredients[5].Price));

            textBoxTotalPrice.Text = System.Convert.ToString(order.CalculatePriceOfOrder() + " грн.");

            s++;

            if (s == 5)
            {
                Sugar.Enabled = false;
                MessageBox.Show("Ви взяли 5 порцій цукру. \nБільше Ви не зможете взяти цукор!", "Цукор");
            }

        }

        /// <summary>
        /// add milk to list orders
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">e</param>
        private void Milk_Click(object sender, EventArgs e)
        {
            textBoxIngredients.Text += ingredients[6].Name + Environment.NewLine;
            textBoxPrice.Text += ingredients[6].Price + " грн" + Environment.NewLine;

            enterMoney.Enabled = true;
            money.Enabled = true;

            order.AddIngredientInOrder(new Ingredient(ingredients[6].Name, ingredients[6].Price));

            textBoxTotalPrice.Text = System.Convert.ToString(order.CalculatePriceOfOrder() + " грн.");

            m++;

            if (m == 2)
            {
                Milk.Enabled = false;
                MessageBox.Show("Це було подвійне молоко. \nБільше Ви не зможете взяти молока!", "Молоко");
            }

        }

        /// <summary>
        /// enter money
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">e</param>
        private void enterMoney_Click(object sender, EventArgs e)
        {
                if (money.SelectedItem == "1 грн") price = price + 1;
                else if (money.SelectedItem == "2 грн") price = price + 2;
                else if (money.SelectedItem == "5 грн") price = price + 5;
                else if (money.SelectedItem == "10 грн") price = price + 10;
                else if (money.SelectedItem == "20 грн") price = price + 20;
                else if (money.SelectedItem == "50 грн") price = price + 50;
                else if (money.SelectedItem == "100 грн") price = price + 100;
                else if (money.SelectedItem == "200 грн") price = price + 200;
                else if (money.SelectedItem == "500 грн") price = price + 500;
            if (order.CalculatePriceOfOrder() <= price)
            {
                if (order.CalculatePriceOfOrder() != price)
                {
                    MessageBox.Show("Дякуємо за покупку. Смачного! \n Візьміть свої каву і решту.", "Дякуємо за покупку");
                    enterMoney.Enabled = false;
                    money.Enabled = false;
                    double t = System.Convert.ToInt16((price - order.CalculatePriceOfOrder()) * 100)/100.0;
                    textBoxRest.Text = System.Convert.ToString(t);
                    takeRest.Enabled = true;
                    printOrder.Enabled = true;
                    Americano.Enabled = false;
                    Espresso.Enabled = false;
                    Сappuccino.Enabled = false;
                    Latte.Enabled = false;
                    Ristretto.Enabled = false;
                    Milk.Enabled = false;
                    Sugar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Дякуємо за покупку. Смачного! \n Візьміть свою каву.", "Дякуємо за покупку");
                    Americano.Enabled = false;
                    takeRest.Enabled = true;
                    printOrder.Enabled = true;
                    Espresso.Enabled = false;
                    Сappuccino.Enabled = false;
                    Latte.Enabled = false;
                    Ristretto.Enabled = false;
                    Milk.Enabled = false;
                    Sugar.Enabled = false;
                }
            }
        }

        /// <summary>
        /// create new order
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">e</param>
        private void newOrder_Click(object sender, EventArgs e)
        {
            price = 0.0;
            textBoxTotalPrice.Clear();
            textBoxIngredients.Clear();
            textBoxPrice.Clear();
            Americano.Enabled = true;
            Espresso.Enabled = true;
            Сappuccino.Enabled = true;
            Latte.Enabled = true;
            Ristretto.Enabled = true;
            Milk.Enabled = false;
            Sugar.Enabled = false;
            takeRest.Enabled = false;
            textBoxRest.Clear();
            order.NewOrder();
            enterMoney.Enabled = false;
            money.Enabled = false;
            printOrder.Enabled = false;
            c = 0;
            m = 0;
            s = 0;
        }

        /// <summary>
        /// give rest
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">e</param>
        private void takeRest_Click(object sender, EventArgs e)
        {
            textBoxRest.Clear();
            textBoxTotalPrice.Clear();
            textBoxIngredients.Clear();
            textBoxPrice.Clear();          
            takeRest.Enabled = false;
            textBoxRest.Clear();
            enterMoney.Enabled = false;
            money.Enabled = false;
        }

        /// <summary>
        /// print order in files
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">e</param>
        private void printOrder_Click(object sender, EventArgs e)
        {
            order.PrintOrderTXT(price, System.Convert.ToInt16((price - order.CalculatePriceOfOrder()) * 100) / 100.0);
            order.PrintOrderXML(price, System.Convert.ToInt16((price - order.CalculatePriceOfOrder()) * 100) / 100.0);
            printOrder.Enabled = false;
            MessageBox.Show("Візьміть Ваш чек.", "Чек");

        }
    }
}
