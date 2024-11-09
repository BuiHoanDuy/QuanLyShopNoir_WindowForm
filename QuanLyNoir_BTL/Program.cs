using Microsoft.EntityFrameworkCore;
using QuanLyNoir_BTL.Views;
using System.Data.Entity;

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
            // Application.Run(new ManageProduct("Duy",true));
            //Application.Run(new AddNewProduct(true));
            //Scaffold-DbContext "Server=LAPTOP-2L3R0R91\\MYCOMPUTER_DUY;Database=ShopNoir.db;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
        }
    }
}