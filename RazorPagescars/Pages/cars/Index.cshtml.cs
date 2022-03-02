#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagescars.Models;

namespace RazorPagescars.Pages_cars
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagescarsContext _context;

        public IndexModel(RazorPagescarsContext context)
        {
            _context = context;
        }

        public IList<cars> cars { get;set; }

        public async Task OnGetAsync()
        {
            cars = await _context.cars.ToListAsync();
        }
    }
}
