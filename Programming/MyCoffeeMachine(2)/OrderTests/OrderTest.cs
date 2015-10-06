//// <copyright file="OrderTest.cs" company="MyCompany.com">
//// MyCompany.com. All rights reserved.
//// </copyright>
namespace OrderTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    /// <summary>
    /// class OrderTest testing class Order
    /// </summary>
    public class OrderTest
    {
        /// <summary>
        /// create new order O
        /// </summary>
        private static MyCoffeeMachine_2_.Order o = new MyCoffeeMachine_2_.Order();

        /// <summary>
        /// Test Add Ingredient In Order
        /// </summary>
        [Test]
        public void TestAddIngredientInOrder()
        {
            o.AddIngredientInOrder(new MyCoffeeMachine_2_.Ingredient("new", 0.0));
            Assert.AreNotEqual(null, o);
        }

        /// <summary>
        /// Test Calculate Price Of Order
        /// </summary>
        [Test]
        public void TestCalculatePriceOfOrder()
        {
            o.AddIngredientInOrder(new MyCoffeeMachine_2_.Ingredient("new1", 1.0));
            o.AddIngredientInOrder(new MyCoffeeMachine_2_.Ingredient("new2", 2.0));
            o.AddIngredientInOrder(new MyCoffeeMachine_2_.Ingredient("new3", 3.0));
            Assert.AreEqual(6.0, o.CalculatePriceOfOrder());
        }

        /// <summary>
        /// Test Exist Of TXT File With Order
        /// </summary>
        [Test]
        public void TestExistOfFileWithOrderTXT()
        {
            Assert.AreEqual(File.Exists(o.CreatePathForFileWithOrder() + ".txt"), true);
        }

        /// <summary>
        /// Test Exist Of XML File With Order
        /// </summary>
        [Test]
        public void TestExistOfFileWithOrderXML()
        {
            Assert.AreEqual(File.Exists(o.CreatePathForFileWithOrder() + ".xml"), true);
        }

        /// <summary>
        /// Test Empty Of TXT File With Order
        /// </summary>
        [Test]
        public void TestEmptyOfFileWithOrderTXT()
        {
            string[] line = File.ReadAllLines(o.CreatePathForFileWithOrder() + ".txt");
            bool check = line.Length == 0;
            Assert.AreNotEqual(check, true);
        }

        /// <summary>
        /// Test Empty Of XML File With Order
        /// </summary>
        [Test]
        public void TestEmptyOfFileWithOrderXML()
        {
            string[] line = File.ReadAllLines(o.CreatePathForFileWithOrder() + ".xml");
            bool check = line.Length == 0;
            Assert.AreNotEqual(check, true);
        }
    }
}
