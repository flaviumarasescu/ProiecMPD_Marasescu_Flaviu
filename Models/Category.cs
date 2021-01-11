using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiecMPD_Marasescu_Flaviu.Models
{
    public class Category
    {
        public int ID { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Acest câmp trebuie să conțină litere și spații și să aibă o lungime mai mare de 2 caracte"), Required, StringLength(50, MinimumLength = 2)]
        public string CategoryName { get; set; }
        public ICollection<FilmCategory> FilmCategories { get; set; }
    }
}
