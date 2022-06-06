using Microsoft.EntityFrameworkCore;
using SSPTraining.Common.Helpers;
using SSPTraining.Model;

namespace SSPTraining.DataAccess.Context;

public class SspTrainingContext : DbContext
{
	public SspTrainingContext(DbContextOptions options) : base(options) { }

	public DbSet<Role>? Roles { get; set; }

	public DbSet<User>? Users { get; set; }

	public DbSet<Person>? Persons { get; set; }

	public DbSet<UserRole>? UserRoles { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Role>().HasData(new List<Role>
		{
			new()
			{
				Id = 1,
				Title = "Admin",
				Description = "Admin of Application"
			},
			new()
			{
				Id = 2,
				Title = "User",
				Description = "User of Application"
			}
		});

		modelBuilder.Entity<Person>().HasData(new List<Person>
		{
			new()
			{
				Id = 1,
				Name = "Mahyar",
				Family = "Hoorbakht"
			},
			new()
			{
				Id = 2,
				Name = "Arezu",
				Family = "Amarlu"
			}
		});

		modelBuilder.Entity<User>().HasData(new List<User>
		{
			new()
			{
				Id = 1,
				Username = "admin",
				Password = "admin".GetHashStringAsync().Result,
				PersonId = 1
			},
			new()
			{
				Id = 2,
				Username = "a.amarlu",
				Password = "amarlu".GetHashStringAsync().Result,
				PersonId = 2
			}
		});

		modelBuilder.Entity<UserRole>().HasData(new List<UserRole>
		{
			new()
			{
				Id = 1,
				UserId = 1,
				RoleId = 1
			},
			new()
			{
				Id = 2,
				UserId = 2,
				RoleId = 2
			}
		});
	}
}