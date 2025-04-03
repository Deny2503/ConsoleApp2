using System.ComponentModel.DataAnnotations;
using ConsoleApp2.DAL;
using ConsoleApp2.DAL.Entities;
using ConsoleApp2.DAL.NewFolder;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var menuService = new MenuService();
            menuService.ShowMenu();

            /*var context = new AppDbContext();

            var userWithOrders = context.Users
                .Include(x => x.Orders);

            foreach (var u in userWithOrders)
            {
                Console.WriteLine($"User: {u.Name} \nOrder: ");
                u.Orders.ToList().ForEach(o =>
                {
                    Console.WriteLine($"    ProductName: {o.ProductName} - DateCreated: {o.DateCreated}");
                });
            }*/
        }
    }
}
