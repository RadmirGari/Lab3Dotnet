using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CommunityApp.Data;
using CommunityApp.Models;

namespace CommunityApp.Pages.Provinces
{
    public class DetailsModel : PageModel
    {
        private readonly CommunityApp.Data.ApplicationDbContext _context;

        public DetailsModel(CommunityApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Province Province { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var province = await _context.Provinces.FirstOrDefaultAsync(m => m.ProvinceCode == id);

            if (province is not null)
            {
                Province = province;

                return Page();
            }

            return NotFound();
        }
    }
}
