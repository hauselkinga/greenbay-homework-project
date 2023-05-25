namespace GreenBay_Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            modelBuilder.Entity<Item>()
                .HasOne(i => i.User)
                .WithMany(u => u.Items)
                .HasForeignKey(i => i.UserId);
            modelBuilder.Entity<Item>()
                .HasOne(i => i.Buyer)
                .WithMany(u => u.BoughtItems)
                .HasForeignKey(i => i.BuyerId);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "Test_User",
                    Password = "15E2B0D3C33891EBB0F1EF609EC419420C20E320CE94C65FBC8C3312448EB225",
                    Balance = 10000
                }
            );
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Name = "Test Item 1",
                    Description = "Test item description",
                    PhotoURL = "https://images.pexels.com/photos/4464484/pexels-photo-4464484.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    Price = 100,
                    UserId = 1
                },
                new Item
                {
                    Id = 2,
                    Name = "Test Item 2",
                    Description = "Test item description",
                    PhotoURL = "https://images.pexels.com/photos/4464484/pexels-photo-4464484.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    Price = 200,
                    UserId = 1
                },
                new Item
                {
                    Id = 3,
                    Name = "Test Item 3",
                    Description = "Test item description",
                    PhotoURL = "https://images.pexels.com/photos/4464484/pexels-photo-4464484.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                    Price = 100,
                    UserId = 1
                }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
