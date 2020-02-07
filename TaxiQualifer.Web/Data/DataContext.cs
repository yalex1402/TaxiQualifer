using Microsoft.EntityFrameworkCore;
using TaxiQualifer.Web.Data.Entities;

namespace TaxiQualifer.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<TaxiEntity> Taxis { get; set; }
    }
}
