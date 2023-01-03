using Microsoft.EntityFrameworkCore;
using VendasWebMvc.Models;
using VendasWebMvc.Models.Enum;

namespace VendasWebMvc.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<Seller> Sellers { get; set; }
    public DbSet<SalesRecord> SalesRecord { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Department>().HasData(
        new Department { Id = 1, Name = "Computers" },
        new Department { Id = 2, Name = "Electronics" },
        new Department { Id = 3, Name = "Fashion" },
        new Department { Id = 4, Name = "Books" }
        );

        modelBuilder.Entity<Seller>().HasData(
        new Seller { Id = 1, Name = "Bob Brown", Email = "bob@gmail.com", BirthDate = DateTime.Parse("1998 04 21"), BaseSalary = 1000.0, DepartmentId = 1 },
        new Seller { Id = 2, Name = "Maria Green", Email = "maria@gmail.com", BirthDate = DateTime.Parse("1979, 12, 31"), BaseSalary = 3500.0, DepartmentId = 2 },
        new Seller { Id = 3, Name = "Alex Grey", Email = "alex@gmail.com", BirthDate = DateTime.Parse("1988, 1, 15"), BaseSalary = 2200.0, DepartmentId = 1 },
        new Seller { Id = 4, Name = "Martha Red", Email = "martha@gmail.com", BirthDate = DateTime.Parse("1993, 11, 30"), BaseSalary = 3000.0, DepartmentId = 4 },
        new Seller { Id = 5, Name = "Donald Blue", Email = "donald@gmail.com", BirthDate = DateTime.Parse("2000, 1, 9"), BaseSalary = 4000.0, DepartmentId = 3 },
        new Seller { Id = 6, Name = "Alex Pink", Email = "bob@gmail.com", BirthDate = DateTime.Parse("1997, 3, 4"), BaseSalary = 3000.0, DepartmentId = 2 }
        );

        modelBuilder.Entity<SalesRecord>().HasData(
        new SalesRecord { Id = 1, Date = DateTime.Parse("2018, 09, 25"), Amount = 11000.0, Status = SaleStatus.Billed, SellerId = 1 },
        new SalesRecord { Id = 2, Date = DateTime.Parse("2018, 09, 04"), Amount = 7000.0, Status = SaleStatus.Billed, SellerId = 5 },
        new SalesRecord { Id = 3, Date = DateTime.Parse("2018, 09, 13"), Amount = 4000.0, Status = SaleStatus.Canceled, SellerId = 4 },
        new SalesRecord { Id = 4, Date = DateTime.Parse("2018, 09, 01"), Amount = 8000.0, Status = SaleStatus.Billed, SellerId = 1 },
        new SalesRecord { Id = 5, Date = DateTime.Parse("2018, 09, 21"), Amount = 3000.0, Status = SaleStatus.Billed, SellerId = 3 },
        new SalesRecord { Id = 6, Date = DateTime.Parse("2018, 09, 15"), Amount = 2000.0, Status = SaleStatus.Billed, SellerId = 1 },
        new SalesRecord { Id = 7, Date = DateTime.Parse("2018, 09, 28"), Amount = 13000.0, Status = SaleStatus.Billed, SellerId = 2 },
        new SalesRecord { Id = 8, Date = DateTime.Parse("2018, 09, 11"), Amount = 4000.0, Status = SaleStatus.Billed, SellerId = 4 },
        new SalesRecord { Id = 9, Date = DateTime.Parse("2018, 09, 14"), Amount = 11000.0, Status = SaleStatus.Pending, SellerId = 6 },
        new SalesRecord { Id = 10, Date = DateTime.Parse("2018, 09, 07"), Amount = 9000.0, Status = SaleStatus.Billed, SellerId = 6 },
        new SalesRecord { Id = 11, Date = DateTime.Parse("2018, 09, 13"), Amount = 6000.0, Status = SaleStatus.Billed, SellerId = 2 },
        new SalesRecord { Id = 12, Date = DateTime.Parse("2018, 09, 25"), Amount = 7000.0, Status = SaleStatus.Pending, SellerId = 3 },
        new SalesRecord { Id = 13, Date = DateTime.Parse("2018, 09, 29"), Amount = 10000.0, Status = SaleStatus.Billed, SellerId = 4 },
        new SalesRecord { Id = 14, Date = DateTime.Parse("2018, 09, 04"), Amount = 3000.0, Status = SaleStatus.Billed, SellerId = 5 },
        new SalesRecord { Id = 15, Date = DateTime.Parse("2018, 09, 12"), Amount = 4000.0, Status = SaleStatus.Billed, SellerId = 1 },
        new SalesRecord { Id = 16, Date = DateTime.Parse("2018, 10, 05"), Amount = 2000.0, Status = SaleStatus.Billed, SellerId = 4 },
        new SalesRecord { Id = 17, Date = DateTime.Parse("2018, 10, 01"), Amount = 12000.0, Status = SaleStatus.Billed, SellerId = 1 },
        new SalesRecord { Id = 18, Date = DateTime.Parse("2018, 10, 24"), Amount = 6000.0, Status = SaleStatus.Billed, SellerId = 3 },
        new SalesRecord { Id = 19, Date = DateTime.Parse("2018, 10, 22"), Amount = 8000.0, Status = SaleStatus.Billed, SellerId = 5 },
        new SalesRecord { Id = 20, Date = DateTime.Parse("2018, 10, 15"), Amount = 8000.0, Status = SaleStatus.Billed, SellerId = 6 },
        new SalesRecord { Id = 21, Date = DateTime.Parse("2018, 10, 17"), Amount = 9000.0, Status = SaleStatus.Billed, SellerId = 2 },
        new SalesRecord { Id = 22, Date = DateTime.Parse("2018, 10, 24"), Amount = 4000.0, Status = SaleStatus.Billed, SellerId = 4 },
        new SalesRecord { Id = 23, Date = DateTime.Parse("2018, 10, 19"), Amount = 11000.0, Status = SaleStatus.Canceled, SellerId = 2 },
        new SalesRecord { Id = 24, Date = DateTime.Parse("2018, 10, 12"), Amount = 8000.0, Status = SaleStatus.Billed, SellerId = 5 },
        new SalesRecord { Id = 25, Date = DateTime.Parse("2018, 10, 31"), Amount = 7000.0, Status = SaleStatus.Billed, SellerId = 3 },
        new SalesRecord { Id = 26, Date = DateTime.Parse("2018, 10, 06"), Amount = 5000.0, Status = SaleStatus.Billed, SellerId = 4 },
        new SalesRecord { Id = 27, Date = DateTime.Parse("2018, 10, 13"), Amount = 9000.0, Status = SaleStatus.Pending, SellerId = 1 },
        new SalesRecord { Id = 28, Date = DateTime.Parse("2018, 10, 07"), Amount = 4000.0, Status = SaleStatus.Billed, SellerId = 3 },
        new SalesRecord { Id = 29, Date = DateTime.Parse("2018, 10, 23"), Amount = 12000.0, Status = SaleStatus.Billed, SellerId = 5 },
        new SalesRecord { Id = 30, Date = DateTime.Parse("2018, 10, 12"), Amount = 5000.0, Status = SaleStatus.Billed, SellerId = 2 }
        );

    }
}
