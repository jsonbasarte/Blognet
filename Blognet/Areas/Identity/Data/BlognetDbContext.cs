using Blognet.Areas.Identity.Data;
using Blognet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blognet.Data;

public class BlognetDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Category> Categories { get; set; }

    public BlognetDbContext(DbContextOptions<BlognetDbContext> options)
        : base(options)
    {
    
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        // Configure the relationships and foreign keys
        builder.Entity<Post>()
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId);

        builder.Entity<Post>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Posts)
            .HasForeignKey(p => p.CategoryId);
    }
}
