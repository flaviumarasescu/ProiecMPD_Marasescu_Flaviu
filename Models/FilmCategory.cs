using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProiecMPD_Marasescu_Flaviu.Models
{
    public class FilmCategory
    {
        public int ID { get; set; }
        public int FilmID { get; set; }
        public Film Film { get; set; }

        
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        
    }
}
