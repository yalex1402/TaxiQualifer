using System.Threading.Tasks;
using TaxiQualifer.Common.Models;

namespace TaxiQualifer.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetTaxiAsync(string plaque, string urlBase, string servicePrefix, string controller);
    }
}
