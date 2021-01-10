using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiecMPD_Marasescu_Flaviu.Data;
using ProiecMPD_Marasescu_Flaviu.Models;

namespace ProiecMPD_Marasescu_Flaviu.Pages.Films
{
    public class CreateModel : FilmCategoriesPageModel
    {
        private readonly ProiecMPD_Marasescu_Flaviu.Data.ProiecMPD_Marasescu_FlaviuContext _context;

        public CreateModel(ProiecMPD_Marasescu_Flaviu.Data.ProiecMPD_Marasescu_FlaviuContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DistributionID"] = new SelectList(_context.Set<Distribution>(), "ID", "DistributionName");

            var film = new Film();
            film.FilmCategories = new List<FilmCategory>();
            PopulateAssignedCategoryData(_context, film);

            return Page();
        }

        [BindProperty]
        public Film Film { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newFilm = new Film();
            if (selectedCategories != null)
            {
                newFilm.FilmCategories = new List<FilmCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new FilmCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newFilm.FilmCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Film>(
            newFilm,
            "Film",
            i => i.FilmImg,
            i => i.Title, i => i.Director,
            i => i.Rating, i => i.ReleaseDate, i => i.DistributionID
            ))
            {
                _context.Film.Add(newFilm);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newFilm);
            return Page();
        }
    }
}
