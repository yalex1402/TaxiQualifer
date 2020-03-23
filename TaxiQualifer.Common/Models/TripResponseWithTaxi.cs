namespace TaxiQualifer.Common.Models
{
    public class TripResponseWithTaxi : TripResponse
    {
        public TaxiResponse Taxi { get; set; }
    }
}
