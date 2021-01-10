using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiecMPD_Marasescu_Flaviu.Data;
using ProiecMPD_Marasescu_Flaviu.Models;

namespace ProiecMPD_Marasescu_Flaviu.Pages.FilmCategories
{
    public class CreateModel : PageModel
    {
        private readonly ProiecMPD_Marasescu_Flaviu.Data.ProiecMPD_Marasescu_FlaviuContext _context;

        public CreateModel(ProiecMPD_Marasescu_Flaviu.Data.ProiecMPD_Marasescu_FlaviuContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            //ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "ID");
            ViewData["FilmID"] = new SelectList((from s in _context.Film.ToList()
                                                 select new
                                                 {
                                                     ID = s.ID,
                                                     FilmDirector = s.Title + " directed by " + s.Director
                                                 }),
                                                            "ID",
                                                            "FilmDirector"
                                                            );
            ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "CategoryName");
            return Page();
        }

        [BindProperty]
        public FilmCategory FilmCategory { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FilmCategory.Add(FilmCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
