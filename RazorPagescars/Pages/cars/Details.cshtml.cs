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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagescarsContext _context;

        public DetailsModel(RazorPagescarsContext context)
        {
            _context = context;
        }

        public cars cars { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            cars = await _context.cars.FirstOrDefaultAsync(m => m.ID == id);

            if (cars == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
