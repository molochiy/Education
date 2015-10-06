using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    public class MyCoffeeMachine: ICoffeeMachine
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyCoffeeMachine" /> class.
        /// </summary>
        public MyCoffeeMachine()
        {
            this.Cash = new double();
            this.TotalPrice = new double();
            this.MyCoffee = new Coffee();
        }

        /// <summary>
        /// Gets or sets Cash inside MyCoffeeMachine.
        /// </summary>
        public double Cash { get; set; }

        /// <summary>
        /// Gets or sets type of chosen Coffee.
        /// </summary>
        public Coffee MyCoffee { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Milk in Coffee.
        /// </summary>
        public bool Milk { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Sugar in Coffee.
        /// </summary>
        public bool Sugar { get; set; }
        
        /// <summary>
        /// Gets or sets total price of purchase.
        /// </summary>
        public double TotalPrice { get; set; }

        /// <summary>
        /// Inputs amount of cash from console.
        /// </summary>
        public void InputCash()
        {
            try
            {
                Console.WriteLine("Please input cash!");
                this.Cash += Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("You have now {0}$ on your balance.", this.Cash);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please input correct data!");
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Lets user check type of coffee.
        /// </summary>
        public void CheckCoffee()
        {
            try
            {
                Console.WriteLine("Please check coffee!");
                Console.WriteLine("1 for Americano.");
                Console.WriteLine("2 for Espresso.");
                Console.WriteLine("3 for Kapuchino.");
                int type = Convert.ToInt32(Console.ReadLine());
                switch (type)
                {
                    case 1:
                        this.MyCoffee = new Coffee("Americano", 3.0);
                        break;
                    case 2:
                        this.MyCoffee = new Coffee("Espresso", 4.0);
                        break;
                    case 3:
                        this.MyCoffee = new Coffee("Kapuchino", 3.5);
                        break;
                    default:
                        this.MyCoffee = new Coffee("Americano", 3.0);
                        break;
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please input correct data!");
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Lets user check to add milk or not.
        /// </summary>
        public void AddMilk()
        {
            try
            {
                Console.WriteLine("Please check if you want some milk!");
                Console.WriteLine("1 for yes.");
                Console.WriteLine("2 for no.");
                int check = Convert.ToInt32(Console.ReadLine());
                if (check == 1)
                {
                    this.Milk = true;
                }
                else
                {
                    this.Milk = false;
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please input correct data!");
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Lets user check to add sugar or not.
        /// </summary>
        public void AddSugar()
        {
            try
            {
                Console.WriteLine("Please check if you want some sugar!");
                Console.WriteLine("1 for yes.");
                Console.WriteLine("2 for no.");
                int check = Convert.ToInt32(Console.ReadLine());
                if (check == 1)
                {
                    this.Sugar = true;
                }
                else
                {
                    this.Sugar = false;
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please input correct data!");
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Calculates all the purchases in MyCoffeeMachine.
        /// </summary>
        public void Calculate()
        {
            this.TotalPrice = this.MyCoffee.Price;
            if (this.Milk)
            {
                this.TotalPrice += 0.75;
            }

            if (this.Sugar)
            {
                this.TotalPrice += 0.5;
            }

            Console.WriteLine("It will cost {0}$", this.TotalPrice);
        }

        /// <summary>
        /// Lets user pay for purchase.
        /// </summary>
        public void Pay()
        {
            if (this.Cash >= this.TotalPrice)
            {
                this.Cash -= this.TotalPrice;
                this.TotalPrice = 0;
                Console.WriteLine("Here is your {0}. Bon apetite!", this.MyCoffee.Name);
                this.MyCoffee = new Coffee();
            }
            else
            {
                Console.WriteLine("You can't afford that! It costs {0}$ Please input {1}$ more, or check another operation!", this.TotalPrice, this.TotalPrice - this.Cash);
            }
        }

        /// <summary>
        /// Lets user do another operation.
        /// </summary>
        public void AnotherOperation()
        {
            try
            {
                Console.WriteLine("You have now {0}$ on your balance.", this.Cash);
                Console.WriteLine("Would you like to do another operation?");
                Console.WriteLine("1 for yes.");
                Console.WriteLine("2 for no.");
                int check = Convert.ToInt32(Console.ReadLine());
                if (check == 2)
                {
                    Console.WriteLine("Thanks for using our Coffee Machine! Here is your {0}$ rest!", this.Cash);
                    System.Threading.Thread.Sleep(2000);
                    Environment.Exit(0);
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please input correct data!");
                System.Threading.Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }
    }
}
