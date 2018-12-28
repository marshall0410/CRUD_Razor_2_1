using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Razor_2_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Razor_2_1.Pages.BooksList
{
    public class IndexModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public IEnumerable<Book> Books {get; set;}

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task OnGet()
        {
            Books = await _db.Books.ToListAsync();
        }
    }
}