using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiecMPD_Marasescu_Flaviu.Data;
using ProiecMPD_Marasescu_Flaviu.Models;

namespace ProiecMPD_Marasescu_Flaviu.Pages.Films
{
    public class IndexModel : PageModel
    {
        private readonly ProiecMPD_Marasescu_Flaviu.Data.ProiecMPD_Marasescu_FlaviuContext _context;

        public IndexModel(ProiecMPD_Marasescu_Flaviu.Data.ProiecMPD_Marasescu_FlaviuContext context)
        {
            _context = context;
        }

        public IList<Film> Film { get;set; }
        public FilmData FilmD { get; set; }
        public int FilmID { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)
        {
            FilmD = new FilmData();

              FilmD.Films = await _context.Film
                .Include(b=>b.Distribution)
                .Include(b => b.FilmCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync();

            if (id != null)
            {
                FilmID = id.Value;
                Film film = FilmD.Films
                .Where(i => i.ID == id.Value).Single();
                FilmD.Categories = film.FilmCategories.Select(s => s.Category);
            }


        }
    }
}
