using FriendOrganizer.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FriendOrganizer.DataAccess
{
    public class FriendOrganizerDbContext : DbContext
    {
        public FriendOrganizerDbContext() : base("FriendOrganizerDb")
        {
        }

        public DbSet<Friend> Friends { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Friend>().Property(t => t.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Friend>().Property(t => t.LastName).HasMaxLength(50);
            modelBuilder.Entity<Friend>().Property(t => t.Email).HasMaxLength(50);
        }
    }
}