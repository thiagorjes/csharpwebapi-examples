using Microsoft.EntityFrameworkCore;
using sistema.Models;
namespace sistema.Models{
    public partial class SistemaContext: DbContext{
        
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Neighborhood> Neighborhood { get; set; }
    }
}