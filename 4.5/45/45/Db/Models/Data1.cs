using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _45.Db.Models
{
    public class Data1
    {
        [Key]
        public int id { get; set; }
        public string pogoda { get; set; }
        public string temperatura { get; set; }
        public string zachmurzenie { get; set; }
        public string wiatr { get; set; }
        public bool rezultat { get; set; }
    }
}
