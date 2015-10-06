//// <copyright file="Order.cs" company="MyCompany.com">
//// MyCompany.com. All rights reserved.
//// </copyright>
namespace MyCoffeeMachine_2_
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// class Order
    /// </summary>
    public class Order : IOrder
    {
        /// <summary>
        /// field list of order
        /// </summary>
        private List<Ingredient> ordening;

        /// <summary>
        /// Initializes a new instance of the <see cref="Order" /> class
        /// </summary>
        public Order()
        {
            this.ordening = new List<Ingredient>();
        }

        /// <summary>
        /// Gets or sets ordering
        /// </summary>
        public List<Ingredient> Ordening
        {
            get { return this.ordening; }
            set { this.ordening = value; }
        }

        /// <summary>
        /// add Ingredient In Order
        /// </summary>
        /// <param name="i">some ingredient</param>
        public void AddIngredientInOrder(Ingredient i)
        {
            this.ordening.Add(i);
        }

        /// <summary>
        /// calculate Price Of Order
        /// </summary>
        /// <returns>price all ingredients</returns>
        public double CalculatePriceOfOrder()
        {
            double totalprice = 0.0;
            foreach (Ingredient i in this.ordening)
            {
                totalprice += i.Price;
            }

            return totalprice;
        }

        /// <summary>
        /// create Path For File With Order
        /// </summary>
        /// <returns>path to file</returns>
        public string CreatePathForFileWithOrder()
        {
            return @"C:\Users\Mykola\Desktop\" + DateTime.Today.Date.ToString("yyyy_MM_dd");
        }

        /// <summary>
        /// print in file
        /// </summary>
        /// <param name="p">price</param>
        /// <param name="r">rest</param>
        public void PrintOrderTXT(double p, double r)
        {
            string t = this.CreatePathForFileWithOrder() + ".txt";
            StreamWriter sw = new StreamWriter(t, true);
            
            foreach (Ingredient i in this.ordening)
            {
                sw.WriteLine("Ім'я інгредієнта {0}, ціна {1} грн.", i.Name.ToString(), i.Price.ToString());
            }

            sw.WriteLine("Загальна ціна {0} грн.", this.CalculatePriceOfOrder().ToString());
            sw.WriteLine("Внесені гроші {0} грн.", p);
            sw.WriteLine("Решта {0} грн.", r);
            sw.WriteLine();
            sw.Close();
        }

        /// <summary>
        /// print Order in XML file
        /// </summary>
        /// <param name="p">price</param>
        /// <param name="r">rest</param>
        public void PrintOrderXML(double p, double r)
        {
            string t = this.CreatePathForFileWithOrder() + ".xml";
            if (!File.Exists(t))
            {
                XmlTextWriter textWritter = new XmlTextWriter(t, Encoding.UTF8);
                textWritter.WriteStartDocument();
                textWritter.WriteStartElement("Список_всіх_замовлень");
                textWritter.WriteEndElement();
                textWritter.WriteEndDocument();
                textWritter.Close();
            }

                XmlDocument document = new XmlDocument();
                document.Load(t);
                XmlNode order = document.CreateElement("Замовлення");
                XmlAttribute attribute = document.CreateAttribute("час");
                attribute.Value = DateTime.Now.ToString("HH:mm:ss");
                order.Attributes.Append(attribute);

                XmlNode listOfIngredients = document.CreateElement("Список_інгредієнтів");
                
                foreach (Ingredient i in this.ordening)
                {
                    XmlNode ingredient = document.CreateElement("Назва_інгредієнту");
                    ingredient.InnerText = i.Name;
                    listOfIngredients.AppendChild(ingredient);

                    XmlNode price = document.CreateElement("Ціна");
                    price.InnerText = i.Price.ToString() + " грн.";
                    listOfIngredients.AppendChild(price);
                }

                order.AppendChild(listOfIngredients);
                
                XmlNode totalPrice = document.CreateElement("Загальна_вартість");
                totalPrice.InnerText = this.CalculatePriceOfOrder().ToString() + " грн.";
                order.AppendChild(totalPrice);

                XmlNode enterMoney = document.CreateElement("Внесені_гроші");
                enterMoney.InnerText = p.ToString() + " грн.";
                order.AppendChild(enterMoney);

                XmlNode rest = document.CreateElement("Решта");
                rest.InnerText = r.ToString() + " грн.";
                order.AppendChild(rest);

                document.DocumentElement.AppendChild(order);

                document.Save(t);
        }

        /// <summary>
        /// create new Order
        /// </summary>
        public void NewOrder()
        {
            this.ordening.Clear();
            this.ordening = new List<Ingredient>();
        }
    }
}
