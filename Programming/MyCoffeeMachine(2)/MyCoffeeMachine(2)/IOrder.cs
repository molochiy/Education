//// <copyright file="IOrder.cs" company="MyCompany.com">
//// MyCompany.com. All rights reserved.
//// </copyright>
namespace MyCoffeeMachine_2_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// interface order
    /// </summary>
    public interface IOrder
    {
        /// <summary>
        /// Add Ingredient In Order
        /// </summary>
        /// <param name="i">some ingredient</param>
        void AddIngredientInOrder(Ingredient i);

        /// <summary>
        /// Calculate Price Of Order
        /// </summary>
        /// <returns>price all ingredients</returns>
        double CalculatePriceOfOrder();

        /// <summary>
        /// print Order in TXT file
        /// </summary>
        /// <param name="p">price</param>
        /// <param name="r">rest</param>
        void PrintOrderTXT(double p, double r);

        /// <summary>
        /// print Order in XML file
        /// </summary>
        /// <param name="p">price</param>
        /// <param name="r">rest</param>
        void PrintOrderXML(double p, double r);

        /// <summary>
        /// create new order
        /// </summary>
        void NewOrder();
    }
}
