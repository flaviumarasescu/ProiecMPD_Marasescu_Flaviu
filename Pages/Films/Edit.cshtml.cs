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

namespace ProiecMPD_Marasescu_Flaviu.Pages.Films
{
    public class EditModel : FilmCategoriesPageModel
    {
        private readonly ProiecMPD_Marasescu_Flaviu.Data.ProiecMPD_Marasescu_FlaviuContext _context;

        public EditModel(ProiecMPD_Marasescu_Flaviu.Data.ProiecMPD_Marasescu_FlaviuContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Film Film { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Film = await _context.Film
                .Include(b=>b.Distribution)
                .Include(b=>b.FilmCategories).ThenInclude(b=>b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Film == null)
            {
                return NotFound();
            }
            //apelam PopulateAssignedCategoryData pentru o obtine informatiile necesare checkbox-
            //urilor folosind clasa AssignedCategoryData 

            PopulateAssignedCategoryData(_context, Film);

            ViewData["DistributionID"] = new SelectList(_context.Set<Distribution>(), "ID", "DistributionName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var filmToUpdate = await _context.Film
            .Include(i => i.Distribution)
            .Include(i => i.FilmCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (filmToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Film>(
            filmToUpdate,
            "Film",
            i => i.FilmImg,
            i => i.Title, i => i.Director,
            i => i.Rating, i => i.ReleaseDate, i => i.DistributionID, i => i.FilmCategories
            ))
            {
                UpdateFilmCategories(_context, selectedCategories, filmToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateFilmCategories(_context, selectedCategories, filmToUpdate);
            PopulateAssignedCategoryData(_context, filmToUpdate);
            return Page();
        }
    }
}