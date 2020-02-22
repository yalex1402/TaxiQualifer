using System.Threading.Tasks;

namespace TaxiQualifer.Common.Services
{
    public interface IGeolocatorService
    {
        double Latitude { get; set; }

        double Longitude { get; set; }

        Task GetLocationAsync();

    }
}
