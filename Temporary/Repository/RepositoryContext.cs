using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
namespace Repository;

public class RepositoryContext : IdentityDbContext<User>
{
	public RepositoryContext(DbContextOptions options)
		: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		////modelBuilder.Entity<Hotel>().OnDelete(DeleteBehavior.Cascade);
		//modelBuilder.Entity<Hotel>()
	 //  .HasMany(e => e.Comments)
	 //  .WithOne()
	 //  .OnDelete(DeleteBehavior.ClientCascade);

		//modelBuilder.Entity<Comment>()
	 //  .HasMany(e => e.Replys)
	 //  .WithOne()
	 //  .OnDelete(DeleteBehavior.ClientCascade);

	}

	public DbSet<Hotel>? Hotels { get; set; }
	public DbSet<Comment>? Comment { get; set; }
	public DbSet<Reply>? Reply { get; set; }
}
