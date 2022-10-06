using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieApp.Areas.Identity.Data;
using MovieApp.Areas.Models;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace MovieApp.Areas.Identity.Data;

public class MovieAppDbContext : IdentityDbContext<MovieAppUser>
{
    public MovieAppDbContext(DbContextOptions<MovieAppDbContext> options)
        : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new MovieAppUserEntityConfiguration());
        builder.Entity<Movie>().HasData(
            new Movie { Id = Guid.NewGuid().ToString(), Title = "Iron Man", Path = "https://cdn-amz.woka.io/images/I/71lVAGaqBtL.jpg" },
            new Movie { Id = Guid.NewGuid().ToString(), Title = "Spider Man", Path = "https://m.media-amazon.com/images/I/51Ec5e2vz9L._AC_SY580_.jpg" },
            new Movie { Id = Guid.NewGuid().ToString(), Title = "Super Man", Path = "https://cdn11.bigcommerce.com/s-yzgoj/images/stencil/1280x1280/products/1519914/3835138/XPSMX5072__16213.1654734420.jpg?c=2" }
            );
    }

    public class MovieAppUserEntityConfiguration : IEntityTypeConfiguration<MovieAppUser>
    {
        public void Configure(EntityTypeBuilder<MovieAppUser> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(225);
            builder.Property(u => u.LastName).HasMaxLength(225);
        }
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Like> Likes { get; set; }

}
