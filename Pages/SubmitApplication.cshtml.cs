using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Pages
{
    public class SumbitApplicationModel : PageModel
    {
        private readonly ILogger<SumbitApplicationModel> _logger;
        private readonly CatContext _context;
        [BindProperty]
        public Application Application {get; set;}
        public SelectList CatsDropDown {get; set;}

        public SumbitApplicationModel(CatContext context, ILogger<SumbitApplicationModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {
            CatsDropDown = new SelectList(_context.Cat.ToList(), "CatID", "Name");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Application.Add(Application);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}