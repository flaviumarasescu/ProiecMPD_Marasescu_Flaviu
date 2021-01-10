using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProiecMPD_Marasescu_Flaviu.Models
{
    public class Film
    {

        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 2)]
        [Display(Name = "Film Title")]
        public string Title { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+\s[A-Z][a-z]+$", ErrorMessage = "Numele autorului trebuie sa fie de forma 'Prenume Nume'"), Required, StringLength(50,MinimumLength = 2)]
        //^ marcheaza inceputul sirului de caractere
        //[A-Z][a-z]+ prenumele -litera mare urmata de oricate litere mici
        //\s spatiu
        //[A-Z][a-z]+ numele- litera mare urmata de oricate litere mici
        //$ marcheaza sfarsitul sirului de caractere
        
       
        
        public string Director { get; set; }

        public string FilmImg { get; set; }

        [Range(1, 10)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Rating { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        public int DistributionID { get; set; }

        public Distribution Distribution { get; set; } //navigation property

        public ICollection<FilmCategory> FilmCategories { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = true)]
        //[Required(AllowEmptyStrings = true)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
        [Required(AllowEmptyStrings = true)]
        public string? FilmDirector
        {
            get
            {

                return Title + " directed by " + Director;
            }


        }
    }
}
