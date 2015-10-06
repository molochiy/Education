//// <copyright file="IngredientTest.cs" company="MyCompany.com">
//// MyCompany.com. All rights reserved.
//// </copyright>
namespace IngredientTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    /// <summary>
    /// class test class Ingredient
    /// </summary>
    [TestFixture]
    public class IngredientTest
    {
        /// <summary>
        /// field ingredinet
        /// </summary>
        private static MyCoffeeMachine_2_.Ingredient I = new MyCoffeeMachine_2_.Ingredient();

        /// <summary>
        /// test constructor without parameters name
        /// </summary>
        [Test]
        public void TestConstructorClassicName()
        {
            Assert.AreEqual(string.Empty, I.Name);
        }

        /// <summary>
        /// test constructor without parameters price
        /// </summary>
        [Test]
        public void TestConstructorClassicPrice()
        {
            Assert.AreEqual(0.0, I.Price);
        }

        /// <summary>
        /// test constructor with parameters name
        /// </summary>
        [Test]
        public void TestConstructorWithParametersClassicName()
        {
            string n = "qwerty";
            double p = 123.321;
            I = new MyCoffeeMachine_2_.Ingredient(n, p);
            Assert.AreEqual(n, I.Name);
        }

        /// <summary>
        /// test constructor with parameters price
        /// </summary>
        [Test]
        public void TestConstructorWithParametersClassicPrice()
        {
            string n = "qwerty";
            double p = 123.321;
            I = new MyCoffeeMachine_2_.Ingredient(n, p);
            Assert.AreEqual(p, I.Price);
        }

    }
}
