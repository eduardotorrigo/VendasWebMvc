using Microsoft.EntityFrameworkCore;
using VendasWebMvc.Models;

namespace VendasWebMvc.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<SalesRecord> SalesRecord { get; set; }
    public DbSet<Department> Departments { get; set; }
}
