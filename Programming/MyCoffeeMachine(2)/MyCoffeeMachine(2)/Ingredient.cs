//// <copyright file="Ingredient.cs" company="MyCompany.com">
//// MyCompany.com. All rights reserved.
//// </copyright>
namespace MyCoffeeMachine_2_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// class Ingredient
    /// </summary>
    [Serializable]
    public class Ingredient
    {
        /// <summary>
        /// field name
        /// </summary>
        private string name;

        /// <summary>
        /// field price
        /// </summary>
        private double price;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ingredient" /> class
        /// </summary>
        public Ingredient()
        {
            this.name = string.Empty;
            this.price = 0.0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ingredient" /> class
        /// </summary>
        /// <param name="Name">new name</param>
        /// <param name="Price">new price</param>
        public Ingredient(string anothername, double anotherprice)
        {
            this.name = anothername;
            this.price = anotherprice;
        }

        /// <summary>
        /// Gets or sets name
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets price
        /// </summary>
        public double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
    }
}
