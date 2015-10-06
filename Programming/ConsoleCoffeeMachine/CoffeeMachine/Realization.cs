using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeMachine
{
    class Realization
    {
        /// <summary>
        /// Launches CoffeeMachine.
        /// </summary>
        public void Work()
        {
            Console.WriteLine("Hello! Welcome to our Coffee Machine Service!");
            MyCoffeeMachine machine = new MyCoffeeMachine();
            while (true)
            {
                machine.CheckCoffee();
                machine.AddMilk();
                machine.AddSugar();
                machine.Calculate();
                machine.InputCash();
                machine.Pay();
                machine.AnotherOperation();
            }
        }
    }
}
