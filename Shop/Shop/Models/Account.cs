using System.Collections.Generic;

namespace Shop.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Adress { get; set; }
        public string TelephoneNumber { get; set; }
        public string Mail { get; set; }
        public int AcessLevel { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}