using EFCoreScaffolding.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Homework_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json");

            var config = configuration.Build();

            var connectionString = config.GetConnectionString("NorthwindDbConnection");

            var options = new DbContextOptionsBuilder<NorthwindContext>()
                                .UseLazyLoadingProxies()
                                .UseSqlServer(connectionString)
                                .Options;

            var dbContext = new NorthwindContext(options);


           

            //Query - 1
           

            var Id = 2;
            var employeeList = dbContext.Employees.Where(e => e.EmployeeId == Id).Include(e => e.Territories).ToList();

            foreach (var employee in employeeList)
            {
                foreach (var emp in employee.Territories)
                {
                    Console.WriteLine(emp.TerritoryDescription);
                }
            }


            // Query -2





            // Query - 3
            var product = dbContext.Invoices.Select(x => new
            {
                productname = x.ProductName,
                ship_con = x.ShipCountry
            }).ToList();

            foreach(var x in product)
            {
                Console.WriteLine(x.productname + " " + x.ship_con);
            }


            //Query-4

            var dataList = dbContext.OrderDetails
                          .Select(a => new
                          {
                              productName = a.ProductName,
                              total_quan = a.Quantity,
                              sales = (double)(a.UnitPrice) * (1 - (a.Discount)) * (a.Quantity)

                          }).ToList();
            foreach (var x in dataList)
            {
                Console.WriteLine(x.productName + " " + x.total_quan + " " + x.sales);

            }








        }
    }
}
