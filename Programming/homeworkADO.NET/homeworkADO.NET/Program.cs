using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Configuration;

namespace homeworkADO.NET
{
    class Program
    {
        /// <summary>
        /// Show all info about the employee with ID 8.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        static string Task1(SqlCommand command)
        {
            string result = string.Empty;
            command.CommandText = "SELECT * FROM Employees WHERE EmployeeID = 8;";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    result += reader[i] + "\n";
                }
            }
            return result;
        }

        /// <summary>
        /// Calculate the greatest, the smallest and the average age of the employees for each city
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        static string Task7(SqlCommand command)
        {
            string result = string.Empty;
            command.CommandText = "SELECT City, MIN(BirthDate), MAX(BirthDate), FLOOR(AVG((cast(getdate() as float) - cast(BirthDate as float)) / 365.0)) FROM Employees GROUP BY City;";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    result += reader[i] + "\n";
                }
            }
            return result;
        }

        /// <summary>
        /// Show the first and last name(s) of the eldest employee(s)
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        static string Task9(SqlCommand command)
        {
            string result = string.Empty;
            command.CommandText = "SELECT FirstName, LastName, (SELECT MIN(BirthDate) FROM Employees) FROM Employees WHERE BirthDate = (SELECT MIN(BirthDate) FROM Employees);";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    result += reader[i] + "\n";
                }
            }
            return result;
        }

        /// <summary>
        /// Show the count of orders made by each customer from France
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        static string Task17(SqlCommand command)
        {
            string result = string.Empty;
            command.CommandText = "SELECT (SELECT ContactName FROM Customers WHERE Orders.CustomerID = Customers.CustomerID), COUNT(Orders.CustomerID) FROM Orders, Customers WHERE (Orders.CustomerID = Customers.CustomerId AND Country = 'France') GROUP BY Orders.CustomerID;";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    result += reader[i] + "\n";
                }
            }
            return result;
        }

        /// <summary>
        /// Show the list of customers’ names who used to order the ‘Tofu’ product
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        static string Task20(SqlCommand command)
        {
            string result = string.Empty;
            command.CommandText = "SELECT Customers.ContactName FROM Customers, Orders, [Order Details], Products WHERE(Products.ProductName = 'Tofu' AND Products.ProductId = [Order Details].ProductId AND [Order Details].OrderId = Orders.OrderId AND Orders.CustomerId = Customers.CustomerId);";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    result += reader[i] + "\n";
                }
            }
            return result;
        }

        /// <summary>
        /// Show the total ordering sum calculated for each country of customer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        static string Task25(SqlCommand command)
        {
            string result = string.Empty;
            command.CommandText = "SELECT Customers.Country, SUM([Order Details].UnitPrice * [Order Details].Quantity) FROM Customers, Orders, [Order Details] WHERE([Order Details].OrderId = Orders.OrderId AND Orders.CustomerId = Customers.CustomerId) GROUP BY Customers.Country;";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    result += reader[i] + "\n";
                }
            }
            return result;
        }

        /// <summary>
        /// Show the list of employees’ names along with names of their chiefs (use left join with the same table)
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        static string Task29(SqlCommand command)
        {
            string result = string.Empty;
            command.CommandText = "(SELECT * FROM Employees AS E1 LEFT JOIN Employees AS E2 ON E1.EmployeeId = E2.ReportsTo);";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    result += reader[i] + " ";
                }
                result += "\n";
            }
            return result;
        }

        static string Task31(SqlCommand command)
        {
            string result = string.Empty;
            command.CommandText = "INSERT INTO Employees(LastName, FirstName, BirthDate, HireDate, address, City, Country, Notes) VALUES('name1' , 'name1', 1995-04-08, 2010-08-01, 'address1', 'city1', 'country1', 'Mykola Molochiy');";
            for (int i = 0; i < 5; i++)
            {
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
            }
            command.CommandText = "SELECT * FROM Employees WHERE Notes = ['Mykola Molochiy'];";
            SqlDataReader reader2 = command.ExecuteReader();
            while (reader2.Read())
            {
                for (int i = 0; i < reader2.FieldCount; i++)
                {
                    result += reader2[i] + " ";
                }
                result += "\n";
            }
            return result;
        }

        static void Main()
        {
            string connect = System.Configuration.ConfigurationManager.ConnectionStrings["NORTHWNDEntities"].ConnectionString;
            EntityConnection con2 = new EntityConnection(connect);
            SqlConnection con = (SqlConnection)(con2.StoreConnection);
            con.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = con;

            //2.	Show the list of first and last names of the employees from London.
            /*com.CommandText = "select * from Employees;";
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                if (reader[8].Equals("London"))
                {
                    Console.Write("{0} {1}", reader[1], reader[2]);
                    Console.WriteLine();
                }
            }*/
            Console.WriteLine(Task31(command));
            Console.ReadLine();
        }
    }
}
