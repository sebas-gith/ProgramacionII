using Microsoft.EntityFrameworkCore;
using Administradora_de_libros.Entities;

namespace Administradora_de_libros
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Book> Books => Set<Book>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasKey(x => x.Id);
            modelBuilder.Entity<Book>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Book>().Property(b => b.Title).HasMaxLength(50);
            modelBuilder.Entity<Book>().Property(b => b.Description).HasMaxLength(500);
            modelBuilder.Entity<Book>().Property(b => b.Author).HasMaxLength(50);
            modelBuilder.Entity<Book>().Property(b => b.ISBN).HasMaxLength(50);
            
        }

    }
}
