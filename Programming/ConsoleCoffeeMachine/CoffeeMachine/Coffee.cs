
namespace CoffeeMachine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class for of Coffee
    /// </summary>
    public class Coffee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coffee" /> class.
        /// </summary>
        public Coffee()
        {
            this.Name = string.Empty;
            this.Price = new double();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Coffee" /> class.
        /// </summary>
        /// <param name="name">Name of Coffee</param>
        /// <param name="price">Price of Coffee</param>
        public Coffee(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Price.
        /// </summary>
        public double Price { get; set; }
    }
}
