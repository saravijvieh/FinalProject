using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinalProject.Models;

namespace FinalProject.Pages
{
    public class CreateModel : PageModel
    {
        private readonly FinalProject.Models.CatContext _context;

        public CreateModel(FinalProject.Models.CatContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cat Cat { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cat.Add(Cat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}