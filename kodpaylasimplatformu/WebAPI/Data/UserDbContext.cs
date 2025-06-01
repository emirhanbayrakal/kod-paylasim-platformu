using Microsoft.EntityFrameworkCore;

public class UserDbContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Code> Codes { get; set; }
    public DbSet<Comment> Comments { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=UserDB;Trusted_Connection=True;");
	}
}
