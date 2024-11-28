using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
    
   public DbSet<User> Users { get; set; }
   public DbSet<Book> Books { get; set; }
   public DbSet<Loan> Loans { get; set; }
    
}