/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Pages.Cats
{
    public class IndexModel : PageModel
    {
        private readonly FinalProject.Models.CatContext _context;

        public IndexModel(FinalProject.Models.CatContext context)
        {
            _context = context;
        }

        public IList<Cat> Cat { get;set; }

        public async Task OnGetAsync()
        {
            Cat = await _context.Cat.ToListAsync();
        }
    }
} */