#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagescars.Models;

namespace RazorPagescars.Pages_cars
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagescarsContext _context;

        public CreateModel(RazorPagescarsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public cars cars { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.cars.Add(cars);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
