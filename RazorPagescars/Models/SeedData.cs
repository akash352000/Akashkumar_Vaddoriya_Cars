using Microsoft.EntityFrameworkCore;
using RazorPagescars.Models;

namespace RazorPagescars.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagescarsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagescarsContext>>()))
            {
                if (context == null || context.cars == null)
                {
                    throw new ArgumentNullException("Null RazorPagescarsContext");
                }

                // Look for any carss.
                if (context.cars.Any())
                {
                    return;   // DB has been seeded
                }

                context.cars.AddRange(
                    new cars
                    {
                        Name = "Toyota Supra",
                        BuyingDate = DateTime.Parse("2000-8-12"),
                        Type = "Sports Car",
                        Price = 50000
                    },

                    new cars
                    {
                       Name = "Ford F-150",
                        BuyingDate = DateTime.Parse("2009-6-18"),
                        Type = "Pick-up Truck",
                        Price = 45000
                    },

                    new cars
                    {
                        Name = "GMC Denali",
                        BuyingDate = DateTime.Parse("2010-12-03"),
                        Type = "SUV",
                        Price = 70000
                    },

                    new cars
                    {
                        Name = "Honda civic",
                        BuyingDate = DateTime.Parse("2017-12-19"),
                        Type = "Car",
                        Price = 9000
                    },

                    new cars
                    {
                        Name = "Cadillac Escalade",
                        BuyingDate = DateTime.Parse("2015-02-25"),
                        Type = "SUV",
                        Price = 100000
                    }

                    
                );
                context.SaveChanges();
            }
        }
    }
}