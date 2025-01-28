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
    public class DetailsModel : PageModel
    {
        private readonly CommunityApp.Data.ApplicationDbContext _context;

        public DetailsModel(CommunityApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public City City { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.Cities.FirstOrDefaultAsync(m => m.CityId == id);

            if (city is not null)
            {
                City = city;

                return Page();
            }

            return NotFound();
        }
    }
}
