using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _45.Db.Models
{ 
    public class Data3
    {
        [Key]
        public int id { get; set; }
        public string bezrobocie { get; set; }
        public string wielkosc_rodziny { get; set; }
        public string wielkosc_ubostwa { get; set; }
        public string stan_zdrowotny { get; set; }
        public bool rezultat { get; set; }
    }
}
