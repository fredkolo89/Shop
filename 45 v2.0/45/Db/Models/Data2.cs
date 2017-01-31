using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _45.Db.Models
{
    public class Data2 
    {
        [Key]
        public int id { get; set; }
        public string studia { get; set; }
        public string doswiadczenie { get; set; }
        public string znajomoscAngielskiego { get; set; }
        public string plec { get; set; }
        public bool rezultat { get; set; }
    }
}
