using System.ComponentModel.DataAnnotations;

namespace TaxiQualifer.Web.Models
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
