#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagescars.Models;

    public class RazorPagescarsContext : DbContext
    {
        public RazorPagescarsContext (DbContextOptions<RazorPagescarsContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagescars.Models.cars> cars { get; set; }
    }
