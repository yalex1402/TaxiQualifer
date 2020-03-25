using System;
using System.Collections.Generic;
using System.Text;
using TaxiQualifer.Common.Models;

namespace TaxiQualifer.Prism.Helpers
{
    public static class CombosHelper
    {
        public static List<Role> GetRoles()
        {
            return new List<Role>
            {
                new Role { Id = 1, Name = Languages.User },
                new Role { Id = 2, Name = Languages.Driver }
            };
        }
    }

}
