using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Models
{ 
    public class Order
    {
        public int OrderId { get; set; }
       // public int AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CodeAndCity { get; set; }
        public decimal AllPrice { get; set; }
        public StatusOrder StatusOrder { get; set; }
        public string  Comment { get; set; }
        public DateTime DateCreated { get; set; }
       // public virtual Account Account { get; set; }
        public virtual ICollection<PositionOrder> PositionOrder { get; set; }

    }

    public enum StatusOrder
    {
        Shipped,
        Preparing
    }
}

