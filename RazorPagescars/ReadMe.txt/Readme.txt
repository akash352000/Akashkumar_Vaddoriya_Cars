//to create new page 
    dotnet new webapp -o RazorPagescars 
    code -r RazorPagesMovie

//dotnet dev-certs https --trust // for run this app

//create new folder name Models
add new class cars.cs in Models

    using System.ComponentModel.DataAnnotations;

    namespace RazorPagescars.Models
    {
        public class cars
        {
            public int ID { get; set; }
            public string Name { get; set; } = string.Empty;

            [DataType(DataType.Date)]
            public DateTime BuyingDate { get; set; }
            public string Type { get; set; } = string.Empty;
            public decimal Price { get; set; }
        }
    }


// to add NuGet packages and EF tools

dotnet tool uninstall --global dotnet-aspnet-codegenerator
dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

// to Scaffold the cars model

dotnet-aspnet-codegenerator razorpage -m cars -dc RazorPagescarsContext -udl -outDir Pages/cars --referenceScriptLibraries -sqlite

// to get help 
dotnet-aspnet-codegenerator razorpage -h

// to Create the initial database schema using EF's migration feature

dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update

// to check the code
dotnet run

// create a new class called SeedData.cs in Models

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


// next update the program.cs file like this

using Microsoft.EntityFrameworkCore;

using RazorPagescars.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<RazorPagescarsContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagescarsContext")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


// lastly run the WebApplication

dotnet run

// i put the screenshot of the output in the ReadMe.txt folder