using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Shop.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public bool Avaliability { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateAdded { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
