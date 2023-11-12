using OnlineStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace OnlineStore.DataAccess;

public class OnlineStoreDbContext : DbContext
{
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<ItemInShoppingCart> ItemsInShoppingCart { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderedPhone> OrderedPhones { get; set; }
    public DbSet<OrderState> OrderStates { get; set; }
    public DbSet<Phone> Phones { get; set; }
    public DbSet<PhoneComment> PhoneComments { get; set; }
    public DbSet<PhoneRating> PhoneRatings { get; set; }
    public DbSet<Processor> Processors { get; set; }
    public DbSet<User> Users { get; set; }

    public OnlineStoreDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>().HasKey(x => x.Id);
        builder.Entity<User>().HasIndex(x => x.ExternalId).IsUnique();

        builder.Entity<Administrator>().HasKey(x => x.Id);
        builder.Entity<Administrator>().HasIndex(x => x.ExternalId).IsUnique();

        builder.Entity<OrderState>().HasKey(x => x.Id);
        builder.Entity<OrderState>().HasIndex(x => x.ExternalId).IsUnique();

        builder.Entity<Order>().HasKey(x => x.Id);
        builder.Entity<Order>().HasIndex(x => x.ExternalId).IsUnique();
        builder.Entity<Order>()
            .HasOne(x => x.User)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.UserId);
        builder.Entity<Order>()
            .HasOne(x => x.OrderState)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.OrderStateId);

        builder.Entity<OrderedPhone>().HasKey(x => x.Id);
        builder.Entity<OrderedPhone>().HasIndex(x => x.ExternalId).IsUnique();
        builder.Entity<OrderedPhone>().HasKey(x => x.PhoneId);
        builder.Entity<OrderedPhone>()
            .HasOne(x => x.Phone)
            .WithMany(x => x.OrderedPhones)
            .HasForeignKey(x => x.PhoneId);
        builder.Entity<OrderedPhone>().HasKey(x => x.OrderId);
        builder.Entity<OrderedPhone>()
            .HasOne(x => x.Order)
            .WithMany(x => x.OrderedPhones)
            .HasForeignKey(x => x.OrderId);

        builder.Entity<Manufacturer>().HasKey(x => x.Id);
        builder.Entity<Manufacturer>().HasIndex(x => x.ExternalId).IsUnique();

        builder.Entity<Phone>().HasKey(x => x.Id);
        builder.Entity<Phone>().HasIndex(x => x.ExternalId).IsUnique();
        builder.Entity<Phone>()
            .HasOne(x => x.Manufacturer)
            .WithMany(x => x.Phones)
            .HasForeignKey(x => x.ManufacturerId);
        builder.Entity<Phone>()
            .HasOne(x => x.Processor)
            .WithMany(x => x.Phones)
            .HasForeignKey(x => x.ProcessorId);

        builder.Entity<Processor>().HasKey(x => x.Id);
        builder.Entity<Processor>().HasIndex(x => x.ExternalId).IsUnique();

        builder.Entity<PhoneRating>().HasKey(x => x.Id);
        builder.Entity<PhoneRating>().HasIndex(x => x.ExternalId).IsUnique();
        builder.Entity<PhoneRating>().HasKey(x => x.PhoneId);
        builder.Entity<PhoneRating>()
            .HasOne(x => x.Phone)
            .WithMany(x => x.Ratings)
            .HasForeignKey(x => x.PhoneId);
        builder.Entity<PhoneRating>().HasKey(x => x.UserId);
        builder.Entity<PhoneRating>()
            .HasOne(x => x.User)
            .WithMany(x => x.Ratings)
            .HasForeignKey(x => x.UserId);

        builder.Entity<PhoneComment>().HasKey(x => x.Id);
        builder.Entity<PhoneComment>().HasIndex(x => x.ExternalId).IsUnique();
        builder.Entity<PhoneComment>().HasKey(x => x.PhoneId);
        builder.Entity<PhoneComment>()
            .HasOne(x => x.Phone)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.PhoneId);
        builder.Entity<PhoneComment>().HasKey(x => x.UserId);
        builder.Entity<PhoneComment>()
            .HasOne(x => x.User)
            .WithMany(x => x.Comments)
            .HasForeignKey(x => x.UserId);

        builder.Entity<ItemInShoppingCart>().HasKey(x => x.Id);
        builder.Entity<ItemInShoppingCart>().HasIndex(x => x.ExternalId).IsUnique();
        builder.Entity<ItemInShoppingCart>().HasKey(x => x.PhoneId);
        builder.Entity<ItemInShoppingCart>()
            .HasOne(x => x.Phone)
            .WithMany(x => x.ItemsInShoppingCart)
            .HasForeignKey(x => x.PhoneId);
        builder.Entity<ItemInShoppingCart>().HasKey(x => x.UserId);
        builder.Entity<ItemInShoppingCart>()
            .HasOne(x => x.User)
            .WithMany(x => x.ItemsInShoppingCart)
            .HasForeignKey(x => x.UserId);
    }
}
