using Microsoft.EntityFrameworkCore;
using MusicStore.Models;

namespace MusicStore.Data
{
    public class MusicStoreContext : DbContext
    {
        public DbSet<Guitar> Guitars { get; set; }

        public MusicStoreContext(DbContextOptions<MusicStoreContext> options) : 
            base(options) { }        
    }
}
