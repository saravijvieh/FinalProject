using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace FinalProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CatContext _context;

        public List<Cat> Cat { get;set; }

        

        public IndexModel(CatContext context)
        {
            _context = context;
        }


        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 10;

        // Sorting support
        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;}
        // Second sorting technique with a SelectList
        public SelectList SortList {get; set;}
        public async Task OnGetAsync()
        {
            Cat = _context.Cat.ToList();
            var query = _context.Cat.Select(p => p);
            List<SelectListItem> sortItems = new List<SelectListItem> {
                new SelectListItem { Text = "Name Ascending", Value = "first_asc" },
                new SelectListItem { Text = "Name Descending", Value = "first_desc"},
                new SelectListItem { Text = "Female Cats", Value = "female"},
                new SelectListItem { Text = "Male Cats", Value = "male"},
                new SelectListItem { Text = "Breed", Value = "breed"}
            };
            SortList = new SelectList(sortItems, "Value", "Text", CurrentSort);

            switch (CurrentSort)
            {
                case "first_asc": 
                    query = query.OrderBy(p => p.Name);
                    break;
                case "first_desc":
                    query = query.OrderByDescending(p => p.Name);
                    break;
                case "male":
                    query = query.OrderByDescending(p => p.Gender);
                    break;
                case "female":
                    query = query.OrderBy(p => p.Gender);
                    break;
                case "breed":
                    query = query.OrderBy(p => p.Breed);
                    break;
            }

            Cat = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
        }

    }   
}