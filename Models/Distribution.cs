using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiecMPD_Marasescu_Flaviu.Models
{
    public class Distribution
    {
        public int ID { get; set; }
        public string DistributionName { get; set; }
        public ICollection<Film> Films { get; set; } //navigation property
    }
}
