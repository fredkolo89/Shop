using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int AccountId { get; set; }
        public decimal AllPrice { get; set; }
        public string StatusOrder { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<PositionOrder> PositionOrder { get; set; }

    }
}
