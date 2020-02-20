using TaxiQualifer.Common.Models;
using TaxiQualifer.Web.Data.Entities;

namespace TaxiQualifer.Web.Helpers
{
    public interface IConverterHelper
    {
        TaxiResponse ToTaxiResponse(TaxiEntity taxiEntity);
    }
}
