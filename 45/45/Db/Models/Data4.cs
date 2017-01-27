using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _45.Db.Models
{
    public class Data4 
    {
        [Key]
        public int id { get; set; }
        public string stan_ogolny { get; set; }
        public string choroba_na_oddziale { get; set; }
        public string samopoczucie { get; set; }
        public string goraczka { get; set; }
        public bool rezultat { get; set; }
    }
}
