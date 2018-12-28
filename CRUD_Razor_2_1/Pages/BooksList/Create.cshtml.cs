using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Razor_2_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRUD_Razor_2_1.Pages.BooksList
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPost(Book Book)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Books.Add(Book);

            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}