using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiecMPD_Marasescu_Flaviu.Data;
using ProiecMPD_Marasescu_Flaviu.Models;

namespace ProiecMPD_Marasescu_Flaviu.Pages.FilmCategories
{
    public class EditModel : PageModel
    {
        private readonly ProiecMPD_Marasescu_Flaviu.Data.ProiecMPD_Marasescu_FlaviuContext _context;

        public EditModel(ProiecMPD_Marasescu_Flaviu.Data.ProiecMPD_Marasescu_FlaviuContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FilmCategory FilmCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FilmCategory = await _context.FilmCategory
                .Include(f => f.Category)
                .Include(f => f.Film).FirstOrDefaultAsync(m => m.ID == id);

            if (FilmCategory == null)
            {
                return NotFound();
            }
            //ViewData["CategoryID"] = new SelectList(_context.Category, "ID", "ID");
            ViewData["FilmID"] = new SelectList((from s in _context.Film.ToList()
                                                 select new
                                                 {
                                                     ID = s.ID,
                                                     FilmDirector = s.Title + " by " + s.Director
                                                 }),
                                              "ID",
                                              "FilmDirector",
                                              null);

            ViewData["FilmID"] = new SelectList(_context.Film, "ID", "Director");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FilmCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmCategoryExists(FilmCategory.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FilmCategoryExists(int id)
        {
            return _context.FilmCategory.Any(e => e.ID == id);
        }
    }
}
