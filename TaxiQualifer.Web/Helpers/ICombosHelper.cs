using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace TaxiQualifer.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboRoles();
    }
}
