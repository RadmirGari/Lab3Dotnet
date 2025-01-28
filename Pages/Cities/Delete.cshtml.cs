using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CommunityApp.Data;
using CommunityApp.Models;

namespace CommunityApp.Pages.Cities
{
    public class DeleteModel : PageModel
    {
        private readonly CommunityApp.Data.ApplicationDbContext _context;

        public DeleteModel(CommunityApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public City City { get; set; } = default!;

      public async Task<IActionResult> OnGetAsync(int? id)
        {   
            if (id == null)
            {
                return NotFound();
            }

            City = await _context.Cities
                .Include(c => c.Province) 
                .FirstOrDefaultAsync(m => m.CityId == id);

            if (City == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.Cities.FindAsync(id);
            if (city != null)
            {
                City = city;
                _context.Cities.Remove(City);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
