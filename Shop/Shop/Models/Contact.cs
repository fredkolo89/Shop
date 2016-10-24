using System;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Contact
    {
        private const int minMessageLenght = 10;
        private const int maxMessageLenght = 1000;

        public int ContactId { get; set; }
        [Required(ErrorMessage = "Podaj swoje imię i nazwisko")]
        [Display(Name = "Imię i nazwisko")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Podaj swój email")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Musisz podać temat wiadomości")]
        public string Subject { get; set; }
     //   [Range(minMessageLenght, maxMessageLenght, ErrorMessage = "Wiadomosc musi miec min: {minMessageLenght} znaków oraz max: {maxMessageLenght} " )]
        public string Message { get; set; }

    }
}