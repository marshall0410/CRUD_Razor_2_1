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

        [TempData]
        public string Message { get; set; }

        public IEnumerable<Book> Books {get; set;}

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task OnGet()
        {
            Books = await _db.Books.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var Book = await _db.Books.FindAsync(id);
            _db.Books.Remove(Book);
            await _db.SaveChangesAsync();

            Message = "Book Deleted Successfully";

            return RedirectToPage("Index");
        }

    }
}