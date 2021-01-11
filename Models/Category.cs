using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiecMPD_Marasescu_Flaviu.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<FilmCategory> FilmCategories { get; set; }
    }
}
