//// <copyright file="Program.cs" company="MyCompany.com">
//// MyCompany.com. All rights reserved.
//// </copyright>
namespace MyCoffeeMachine_2_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// class program running all project
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Machine());
        }
    }
}
