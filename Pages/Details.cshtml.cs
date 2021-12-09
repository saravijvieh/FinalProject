using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly FinalProject.Models.CatContext _context;

        public DetailsModel(FinalProject.Models.CatContext context)
        {
            _context = context;
        }

        public Cat Cat { get; set; }
        [BindProperty]
        public int ApplicationIDToDelete {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cat = await _context.Cat.Include(m => m.Application).FirstOrDefaultAsync(m => m.CatID == id);

            if (Cat == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostRemoveApplication(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Find the review in the database
            Application application = _context.Application.FirstOrDefault(r => r.ApplicationID == ApplicationIDToDelete);
            
            if (application != null)
            {
                _context.Remove(application); // Delete the Application
                _context.SaveChanges();
            }

            Cat = _context.Cat.Include(m => m.Application).FirstOrDefault(m => m.CatID == id);

            return Page();
        }        
    }
}