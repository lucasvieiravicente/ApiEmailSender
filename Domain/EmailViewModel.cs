using ApiEmails.Domain.Utils;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ApiEmails.Domain
{
    public class EmailViewModel
    {        
        [Required(ErrorMessage = ErrorMessages.NameNecessary)]
        public string Name { get; set; } 

        [Required(ErrorMessage = ErrorMessages.EmailNecessary)]
        [EmailAddress(ErrorMessage = ErrorMessages.EmailIncorrect)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorMessages.PhoneNecessary)]
        [RegularExpression("[\\d]", ErrorMessage = ErrorMessages.PhoneIncorrect)]
        public string PhoneNumber { get; set; }    

        [Required(ErrorMessage = ErrorMessages.BodyNecessary)]
        public string Body { get; set; }

        public string Subject { get; set; }
    }
}
