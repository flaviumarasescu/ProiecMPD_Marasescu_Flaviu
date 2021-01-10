using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiecMPD_Marasescu_Flaviu.Models;

namespace ProiecMPD_Marasescu_Flaviu.Data
{
    public class ProiecMPD_Marasescu_FlaviuContext : DbContext
    {
        public ProiecMPD_Marasescu_FlaviuContext (DbContextOptions<ProiecMPD_Marasescu_FlaviuContext> options)
            : base(options)
        {
        }

        public DbSet<ProiecMPD_Marasescu_Flaviu.Models.Film> Film { get; set; }

        public DbSet<ProiecMPD_Marasescu_Flaviu.Models.Distribution> Distribution { get; set; }

        public DbSet<ProiecMPD_Marasescu_Flaviu.Models.Category> Category { get; set; }

        public DbSet<ProiecMPD_Marasescu_Flaviu.Models.FilmCategory> FilmCategory { get; set; }

     
    }
}
