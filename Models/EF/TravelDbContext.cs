using System.Data.Entity;

namespace Models.EF
{
    public partial class TravelDbContext : DbContext
    {
        public TravelDbContext()
            : base("name=TravelDbContext")
        {
        }

        public virtual DbSet<About> Abouts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Gallery> Galleries { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
        public virtual DbSet<TouristDestination> TouristDestinations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Email)
                .IsUnicode(false);


            modelBuilder.Entity<Feedback>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Feedback>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Tour>()
                .Property(e => e.Price)
                .HasPrecision(18, 0); 


           
        }

     

    }
}
