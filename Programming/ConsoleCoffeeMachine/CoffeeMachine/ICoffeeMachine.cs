//// <copyright file="ICoffeeMachine.cs" company="MyCompany.com">
//// MyCompany.com. All rights reserved.
//// </copyright>

namespace CoffeeMachine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for CoffeeMachine and it's Service.
    /// </summary>
    public interface ICoffeeMachine
    {
        /// <summary>
        /// Inputs amount of cash from console.
        /// </summary>
        void InputCash();

        /// <summary>
        /// Lets user check type of coffee.
        /// </summary>
        void CheckCoffee();

        /// <summary>
        /// Lets user check to add milk or not.
        /// </summary>
        void AddMilk();

        /// <summary>
        /// Lets user check to add sugar or not.
        /// </summary>
        void AddSugar();

        /// <summary>
        /// Calculates total price.
        /// </summary>
        void Calculate();

        /// <summary>
        /// Lets user pay for purchase.
        /// </summary>
        void Pay();

        /// <summary>
        /// Lets user do another operation.
        /// </summary>
        void AnotherOperation();
    }
}
