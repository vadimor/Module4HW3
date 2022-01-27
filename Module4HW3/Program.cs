using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Module4HW3.Helper;

namespace Module4HW3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("config.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var options = optionsBuilder.
                UseSqlServer(connectionString)
                .Options;
            using (var db = new ApplicationDbContext(options))
            {
                var req = new Requests(db, new TransactionHelper(db));
                req.FirstRequest().GetAwaiter().GetResult();
                req.SecondRequest().GetAwaiter().GetResult();
                req.ThreeRequest().GetAwaiter().GetResult();
                req.FourRequest().GetAwaiter().GetResult();
                req.FiveRequest().GetAwaiter().GetResult();
                req.SixRequest().GetAwaiter().GetResult();
            }

            System.Console.ReadLine();
        }
    }
}
