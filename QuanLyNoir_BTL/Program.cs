using Microsoft.EntityFrameworkCore;

namespace QuanLyNoir_BTL
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new SignIn());
           // Application.Run(new ManageProduct());
            // Scaffold-DbContext "Server=LAPTOP-2L3R0R91\\MYCOMPUTER_DUY;Database=ShopNoir_Test.db;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
        }
    }
}