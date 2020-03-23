using TaxiQualifer.Common.Models;

namespace TaxiQualifer.Web.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string to, string subject, string body);
    }
}
