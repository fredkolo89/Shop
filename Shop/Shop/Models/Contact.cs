using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }

        [StringLength(1000)]
        public string Message { get; set; }

    }
}