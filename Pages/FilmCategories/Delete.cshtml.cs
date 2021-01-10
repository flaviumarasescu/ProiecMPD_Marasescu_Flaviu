using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiecMPD_Marasescu_Flaviu.Data;
using ProiecMPD_Marasescu_Flaviu.Models;

namespace ProiecMPD_Marasescu_Flaviu.Pages.FilmCategories
{
    public class DeleteModel : PageModel
    {
        private readonly ProiecMPD_Marasescu_Flaviu.Data.ProiecMPD_Marasescu_FlaviuContext _context;

        public DeleteModel(ProiecMPD_Marasescu_Flaviu.Data.ProiecMPD_Marasescu_FlaviuContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FilmCategory = await _context.FilmCategory.FindAsync(id);

            if (FilmCategory != null)
            {
                _context.FilmCategory.Remove(FilmCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
