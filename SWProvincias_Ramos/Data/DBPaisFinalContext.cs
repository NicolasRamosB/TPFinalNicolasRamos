using Microsoft.EntityFrameworkCore;
using SWProvincias_Ramos.Models;

namespace SWProvincias_Ramos.Data
{
    public class DBPaisFinalContext : DbContext
    {
        public DBPaisFinalContext(DbContextOptions<DBPaisFinalContext> options) : base(options){ }

        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
    }
}
