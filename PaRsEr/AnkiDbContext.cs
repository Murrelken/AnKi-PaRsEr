using Microsoft.EntityFrameworkCore;
using PaRsEr.Entities;

namespace PaRsEr
{
    public class AnkiDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Note> Notes { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\Users\butin\Desktop\test\collection.anki2");
    }
}