using Microsoft.EntityFrameworkCore;
using PhoneBookCrud.Models;

namespace PhoneBookCrud.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Contact> Contacts => Set<Contact>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .Property(c => c.ContactId)
                .ValueGeneratedOnAdd();
        }
    }
}
