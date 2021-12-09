﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

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

        public void OnGet()
        {
            Cat = _context.Cat.ToList();
        }
    }
}