using CommunityApp.Data;
using CommunityApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CommunityApp.Pages.Cities
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public City City { get; set; }

        public IActionResult OnGet()
        {
            ViewData["ProvinceList"] = new SelectList(_context.Provinces, "ProvinceCode", "ProvinceName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("hi");
            if (!ModelState.IsValid)
            {
            Console.WriteLine("Model State Errors:");
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

                ViewData["ProvinceList"] = new SelectList(_context.Provinces, "ProvinceCode", "ProvinceName");
                return Page();
            }
            Console.WriteLine("hey");

            _context.Cities.Add(City);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
