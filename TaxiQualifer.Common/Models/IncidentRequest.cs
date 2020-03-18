using System.ComponentModel.DataAnnotations;

namespace TaxiQualifer.Common.Models
{
    public class IncidentRequest : TripRequest
    {
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Remarks { get; set; }
    }
}
